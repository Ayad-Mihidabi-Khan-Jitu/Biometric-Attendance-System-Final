using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biometric_Attendence_System
    {
    public partial class AdminPanel : Form
        {
        public static string teacher_name;
        public static string teacher_department;
        public static string teacher_faculty;
        public static string teacher_email;
        public static string teacher_moblile;
        public static string teacher_password;
        public static string teacher_fingerprint;
        public static string course_title;
        public static string course_code;
        public static string credit_hour;
        public static int course_semester;
        public static int TsL;
        public static int CsL;
        public string photoLocation;
        public string adminNodelete;
        byte[] byteimage = null;

        MemoryStream msimgtobi;
        OpenFileDialog fileOpen;

        DB dbAccess = new DB();
        SerialCommunication communication = new SerialCommunication();
        LoadingForm loadingForm = new LoadingForm();
        MailCreator mail = new MailCreator();


        ///data table is like an database, our data source of this combobox is data table
        DataTable DepartmentTbl = new DataTable();
        DataTable FacultyTbl = new DataTable();
        DataTable TeacherTbl = new DataTable();
        DataTable CourseTbl = new DataTable();
        DataTable AvailableFIngerIDTbl = new DataTable();

        public AdminPanel()
            {
            InitializeComponent();
            SerialCommunication.serialPortClose();
            this.Controls.Add(SerialCommunication.textboxserialmonitor);
            communication.serialmoniproperty(620, 27, 76, 300, "HP Simplified", 9.0f, true, true,true);
            loadingForm.sketchwithProgessbar(communication.actionEnroll);
            loadingForm.ShowDialog();
            //SerialCommunication.serialPortClose();
            communication.SerialPort(SerialCommunication.SerialPortNumber);
            SerialCommunication.serialPortOpen();
            communication.serialDataReceived();
            }

        ///Methods in this form///
        private void LogOutImg_Click(object sender, EventArgs e)
            {
            EnterHomeFORM();
            }

        private void btnAllTeacher_Click(object sender, EventArgs e)
            {
            EnterAllTeacherFORM();
            }

        private void AddButton_Click(object sender, EventArgs e)
            {
            teacherInsertValidation();
            //clearTextboxValue();
            }

        private void UpdateButton_Click(object sender, EventArgs e)
            {
            teacherUpdateValidation();
            //clearTextboxValue();
            }

        private void DeleteButton_Click(object sender, EventArgs e)
            {
            teacherDeleteValidation();
            }

        private void buttonAddCourse_Click(object sender, EventArgs e)
            {
            courseInsertValidation();
            clearCourseTextBoxValue();    
            }

        private void buttonUpdateCourse_Click(object sender, EventArgs e)
            {
             courseUpdateValidation();
             clearCourseTextBoxValue();
            }

        private void buttonDeleteCourse_Click(object sender, EventArgs e)
            {
            courseDeleteValidation();
            clearCourseTextBoxValue();
            }

        private void btntest_Click(object sender, EventArgs e)
            {
            //SerialCommunication.dataReceived(this.textboxSerialMonitor);
            communication.dataWrite(FingerPrintTextBox);
            }

        private void lebelEnableFingerprint_Click(object sender, EventArgs e)
            {
            FingerPrintTextBox.Enabled = true;
            lebelEnableFingerprint.Visible = false;
            }

        private void LblBrowseImage_Click(object sender, EventArgs e)
            {
            browsePhoto();
            }


        ///Events in this form///
        private void AdminPanel_Load(object sender, EventArgs e)
            {

            labelAdminName.Text = AdminLogin.username;
            this.ActiveControl = labelAdminName;
            fillFacultyCombo();
            fillDepartCombo();
            fillTeacherCombo();
            FingerIDAvailable();

            facultyComboBox.DataSource = FacultyTbl;
            facultyComboBox.DisplayMember = "Faculty_Name";

            departCompoBox.DataSource = DepartmentTbl;
            departCompoBox.DisplayMember = "Department_Name";

            comboBoxTeacher.DataSource = TeacherTbl;
            comboBoxTeacher.DisplayMember = "Teacher_Name";


            clearTextLebelValue();
            clearTextboxValue();

            CourseTable();
            activeTab(0);

            pictureBoxTeacher.Image = null;
            pictureBoxTeacher.Visible = false;

            FingerPrintTextBox.Enabled = false;
            lebelEnableFingerprint.Visible = true;

            SplashWithSketch.FmatchSkachUpload = false;
            }

        private void comboBoxTeacher_SelectedIndexChanged(object sender, EventArgs e)
            {
            pictureBoxTeacher.Visible = true;
            if (comboBoxTeacher.SelectedIndex != -1)
                {
                TeacherNameLbl.Text = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Name"].ToString();
                DepartmentLbl.Text ="Department of "+ TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Department"].ToString();
                FacultyLbl.Text = "Faculty of " + TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Faculty"].ToString();
                emailLbl.Text ="Email: " + TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Email"].ToString();
                mobileLbl.Text ="Contact: " + TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Mobile"].ToString();
                FingerPrintTextBox.Text = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Fingerprint_ID"].ToString();

                TeacherName.Text = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Name"].ToString();
                facultyComboBox.Text = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Faculty"].ToString();
                departCompoBox.Text = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Department"].ToString();
                email.Text = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Email"].ToString();
                mobile.Text = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Mobile"].ToString();
                password.Text = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Password"].ToString();
                confirmpass.Text = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Password"].ToString();
                maskingPassword();
                FingerPrintTextBox.Enabled = false;
                lebelEnableFingerprint.Visible = true;

                adminNodelete = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Role"].ToString();
                //string adminTeacher = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Role"].ToString();
                labelAdmin.Text = adminNodelete;
                //courselabel.Text = CsL.ToString();
                checkBoxPasshow.Checked = false;

                if (TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Photo"] == null)
                    {
                    pictureBoxTeacher.Image = null;
                    }
                else
                    {
                    try
                        {
                        MemoryStream ms = new MemoryStream((byte[])TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Photo"]);
                        pictureBoxTeacher.Image = new Bitmap(ms);
                        //pictureBoxTeacher.Image = Image.FromStream(ms);
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show(ex.Message);
                        }
                    }

                TsL = Convert.ToInt32(TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Serial"].ToString());
                }
            }

        private void dataGridCourse_CellClick(object sender, DataGridViewCellEventArgs e)
            {
            //CsL = Convert.ToInt32(TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Serial"].ToString());
            //CsL = dataGridCourse.SelectedRows.ToString();
            //DataRowView dataRowView = (DataRowView)dataGridCourse.SelectedItem;

            if (e.RowIndex >= 0)
                {
                DataGridViewRow row = dataGridCourse.Rows[e.RowIndex];
                CsL = Convert.ToInt32(row.Cells[0].Value.ToString());
                textBoxCourseTitle.Text = row.Cells[1].Value.ToString();
                textBoxCourseCode.Text = row.Cells[2].Value.ToString();
                textBoxCreditHour.Text = row.Cells[3].Value.ToString();
                }

            }


        ///Functions of the forms///
        void EnterHomeFORM()
            {
            try
                {
                SerialCommunication.serialPortClose();
                this.Hide();
                //this.Close();
                Login login = new Login();
                login.Show();
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }

            }
        void EnterAllTeacherFORM()
            {
            try
                {
                TeachersList teachers = new TeachersList();
                teachers.Show();
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }


        void teacherInsertValidation()
            {
            try
                {
                teacher_name = TeacherName.Text.Trim();
                teacher_department = DepartmentTbl.Rows[departCompoBox.SelectedIndex]["Department_Name"].ToString();
                teacher_faculty = FacultyTbl.Rows[facultyComboBox.SelectedIndex]["Faculty_name"].ToString();
                teacher_email = email.Text.Trim();
                teacher_moblile = mobile.Text.Trim();
                teacher_password = password.Text.Trim();
                string confirm_teacher_password = confirmpass.Text.Trim();
                teacher_fingerprint = FingerPrintTextBox.Text.Trim();
                //ImgToBinary();
                byte[] image = ImgToBinaryMem();
                string email_subject = mail.emailSubject + "Teacher Enrollment Successful";
                string email_body =mail.email_body_header + teacher_name+"<br>"+"Department of "+ teacher_department+"<br>"+"Faculty of "+ teacher_faculty+"<br>"+"Email: "+teacher_email+"<br>"+"Contact: "+teacher_moblile+"<br>"+"Password: "+ teacher_password+ "<br>"+ "FingerID: " + teacher_fingerprint + mail.email_body_footer + mail.soft_detail;

                if (teacher_name == "" || teacher_department == "" || teacher_email == "" || teacher_moblile == "" || teacher_password == "" || teacher_faculty == "" || teacher_fingerprint == "")
                    { MessageBox.Show("Fields can not be Empty!"); }
                else
                    {
                    if (confirm_teacher_password == teacher_password)
                        {
                        if(IsIDuplicateFID() == 0)
                            {
                                SqlCommand insertCommand;
                        
                                string query = "INSERT INTO Teacher(Teacher_Name, Teacher_Department, Teacher_Email, Teacher_Mobile, Password, Photo, Teacher_Faculty, Teacher_Fingerprint_ID)" +
                                "VALUES (@teacher_name, @teacher_department, @teacher_email, @teacher_moblile, @teacher_password, @image, @teacher_faculty, @teacher_fingerprint)";
                                insertCommand = new SqlCommand(query);
                                insertCommand.Parameters.AddWithValue("@teacher_name", teacher_name);
                                insertCommand.Parameters.AddWithValue("@teacher_department", teacher_department);
                                insertCommand.Parameters.AddWithValue("@teacher_email", teacher_email);
                                insertCommand.Parameters.AddWithValue("@teacher_moblile", teacher_moblile);
                                insertCommand.Parameters.AddWithValue("@teacher_password", teacher_password);
                                insertCommand.Parameters.AddWithValue("@image", image);
                                insertCommand.Parameters.AddWithValue("@teacher_faculty", teacher_faculty);
                                insertCommand.Parameters.AddWithValue("@teacher_fingerprint", teacher_fingerprint);
                                
                                int row = dbAccess.executeQuery(insertCommand);
                                dbAccess.closeConn();

                                if (row == 1) 
                                {
                                mail.SendEmail(mail.defalultSender, teacher_email, email_subject, email_body);
                                MessageBox.Show("New Teacher Added!!");
                                refreshCombo();
                                refreshFingerIDAvailable();
                                FingerIDAvailable();
                                }
                                else { MessageBox.Show("Could not Insert.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                        else { MessageBox.Show("Sorry, could't add this teacher.\n" + "Finger ID " + teacher_fingerprint + " is already exists!! ", "Could not Insert", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                    else { MessageBox.Show("Password Should Be Same."); }

                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }


        int IsIDuplicateFID()
            {
            string finger_Id = FingerPrintTextBox.Text.Trim();
            DataTable IsIDAvailable = new DataTable();
            string query = " SELECT Teacher_Name FROM Teacher WHERE Teacher_Fingerprint_ID ='" + finger_Id + "' ";
            dbAccess.readDatathroughAdapter(query, IsIDAvailable);
            int i = IsIDAvailable.Rows.Count;
            dbAccess.closeConn();
            return i;
            }

        void teacherUpdateValidation()
            {
            try
                {
                teacher_name = TeacherName.Text.Trim();
                teacher_department = DepartmentTbl.Rows[departCompoBox.SelectedIndex]["Department_Name"].ToString();
                teacher_faculty = FacultyTbl.Rows[facultyComboBox.SelectedIndex]["Faculty_name"].ToString();
                teacher_email = email.Text.Trim();
                teacher_moblile = mobile.Text.Trim();
                teacher_fingerprint = FingerPrintTextBox.Text;
                teacher_password = password.Text.Trim();
                string confirm_teacher_password = confirmpass.Text.Trim();
                byte[] image = ImgToBinaryMem();

                string email_subject = mail.emailSubject + "Teacher Update Successful";
                string email_body = mail.email_body_header + teacher_name + "<br>" + "Department of " + teacher_department + "<br>" + "Faculty of " + teacher_faculty + "<br>" + "Email: " + teacher_email + "<br>" + "Contact: " + teacher_moblile + "<br>" + "Password: " + teacher_password + "<br>" + "FingerID: " + teacher_fingerprint + mail.email_body_footer+mail.soft_detail;


                if (teacher_name == "" || teacher_department == "" || teacher_email == "" || teacher_moblile == "" || teacher_password == "" || teacher_faculty == "")
                    { MessageBox.Show("Fields can not be Empty!"); }
                else
                    {
                    if (confirm_teacher_password == teacher_password)
                        {
                        SqlCommand updateCommand;
                        if (photoLocation == null)
                            {

                            string query = " UPDATE Teacher SET Teacher_Name = @teacher_name, Teacher_Department = @teacher_department , Teacher_Email = @teacher_email ,"+
                                "Teacher_Mobile = @teacher_moblile, Password = @teacher_password, Teacher_Faculty = @teacher_faculty WHERE Serial = '" + TsL + "' ";
                            //string query = " UPDATE Teacher SET Teacher_Name = '" + teacher_name + "', Teacher_Department = '" + teacher_department + "' ,Teacher_Email = '"
                            //+ teacher_email + "' ,Teacher_Mobile = '" + teacher_moblile + "', Password = '" + teacher_password + "', Photo = '" + image + "', Teacher_Faculty = '" + teacher_faculty +
                            //"' WHERE Serial = '" + TsL + "' ";

                            updateCommand = new SqlCommand(query);
                            updateCommand.Parameters.AddWithValue("@teacher_name", teacher_name);
                            updateCommand.Parameters.AddWithValue("@teacher_department", teacher_department);
                            updateCommand.Parameters.AddWithValue("@teacher_email", teacher_email);
                            updateCommand.Parameters.AddWithValue("@teacher_moblile", teacher_moblile);
                            updateCommand.Parameters.AddWithValue("@teacher_password", teacher_password);
                            updateCommand.Parameters.AddWithValue("@teacher_faculty", teacher_faculty);
                            }
                        else
                            {
                            string query = " UPDATE Teacher SET Teacher_Name = @teacher_name, Teacher_Department = @teacher_department , Teacher_Email = @teacher_email ,"+
                                "Teacher_Mobile = @teacher_moblile, Password = @teacher_password, Photo=@image, Teacher_Faculty = @teacher_faculty WHERE Serial = '" + TsL + "' ";
                            //string query = " UPDATE Teacher SET Teacher_Name = '" + teacher_name + "', Teacher_Department = '" + teacher_department + "' ,Teacher_Email = '"
                            //+ teacher_email + "' ,Teacher_Mobile = '" + teacher_moblile + "', Password = '" + teacher_password + "', Photo = '" + images + "', Teacher_Faculty = '" + teacher_faculty +
                            //"' WHERE Serial = '" + TsL + "' ";

                            updateCommand = new SqlCommand(query);
                            updateCommand.Parameters.AddWithValue("@teacher_name", teacher_name);
                            updateCommand.Parameters.AddWithValue("@teacher_department", teacher_department);
                            updateCommand.Parameters.AddWithValue("@teacher_email", teacher_email);
                            updateCommand.Parameters.AddWithValue("@teacher_moblile", teacher_moblile);
                            updateCommand.Parameters.AddWithValue("@teacher_password", teacher_password);
                            updateCommand.Parameters.AddWithValue("@image", image);
                            updateCommand.Parameters.AddWithValue("@teacher_faculty", teacher_faculty);
                            }

                                      
                        int row = dbAccess.executeQuery(updateCommand);
                        dbAccess.closeConn();

                        if (row == 1) 
                            {
                            mail.SendEmail(mail.defalultSender, teacher_email, email_subject, email_body);
                            MessageBox.Show("Teacher Updated!!!"); 
                            refreshCombo();
                            }
                        else { MessageBox.Show("Could not Update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    else { MessageBox.Show("Password: "+teacher_password+"#"+"\nConfirm Password: "+ confirm_teacher_password+"#"+ "\nPassword Should Be Same"); }

                    }
                }
            catch(Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        void teacherDeleteValidation()
            {
            DialogResult d;
            d = MessageBox.Show("Do you want to delete? ", " Warning!! ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
                {
                //string Nodelete = "admin";
                if (String.Equals("admin", adminNodelete))
                    {
                    MessageBox.Show("Sorry!\nCould not Delete the Teacher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                else
                    {
                    try
                        {
                        string query = " DELETE FROM Teacher WHERE Serial = '" + TsL + "' ";
                        SqlCommand deleteCommand = new SqlCommand(query);

                        int row = dbAccess.executeQuery(deleteCommand);
                        dbAccess.closeConn();

                        if (row == 1) 
                            { 
                            MessageBox.Show("Teacher Deleted!!!");
                            refreshCombo();
                            refreshFingerIDAvailable();
                            FingerIDAvailable();                           
                            }
                        else { MessageBox.Show("Could not Delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show(ex.Message);
                        }
                    }
                }
           
            }


        void refreshCombo()
            {
            TeacherTbl.Rows.Clear();
            TeacherTbl.Columns.Clear();
            TeacherTbl.Clear();

            fillTeacherCombo();
            comboBoxTeacher.DataSource = null;
            comboBoxTeacher.Items.Clear();
            comboBoxTeacher.DataSource = TeacherTbl;
            comboBoxTeacher.DisplayMember = "Teacher_Name";
            clearTextboxValue();
            clearTextLebelValue();
            pictureBoxTeacher.Image = null;
            pictureBoxTeacher.Visible = false;
            }

        void courseInsertValidation()
            {
            try
                {
                course_title = textBoxCourseTitle.Text.Trim();
                course_code = textBoxCourseCode.Text.Trim();
                credit_hour = textBoxCreditHour.Text.Trim();
                course_semester = courseCodeToSemester(course_code);

                if (course_title == "" || course_code == "" || credit_hour == "")
                    { MessageBox.Show("Fields can not be Empty!"); }
                else
                    {
                    double double_credit_hour = Convert.ToDouble(credit_hour);

                    string query = " INSERT INTO Course(Course_Title, Course_Code, Credit_Hour, Course_Semester)" +
                                               "VALUES (@course_title, @course_code, @double_credit_hour, @course_semester) ";
                    SqlCommand insertCommand = new SqlCommand(query);
                    insertCommand.Parameters.AddWithValue("@course_title", course_title);
                    insertCommand.Parameters.AddWithValue("@course_code", course_code);
                    insertCommand.Parameters.AddWithValue("@double_credit_hour", double_credit_hour);
                    insertCommand.Parameters.AddWithValue("@course_semester", course_semester);

                    int row = dbAccess.executeQuery(insertCommand);
                    dbAccess.closeConn();

                    if (row == 1) { MessageBox.Show("New Course Added!!!"); refreshCourseTbl(); CourseTable(); }
                    else { MessageBox.Show("Could not Insert."); }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        void courseUpdateValidation()
            {
            try
                {
                course_title = textBoxCourseTitle.Text.Trim();
                course_code = textBoxCourseCode.Text.Trim();
                credit_hour = textBoxCreditHour.Text.Trim();
                course_semester = courseCodeToSemester(course_code);

                if (course_title == "" || course_code == "" || credit_hour == "")
                    { MessageBox.Show("Fields can not be Empty!"); }
                else
                    {
                    double double_credit_hour = Convert.ToDouble(credit_hour);

                    string query = " UPDATE Course SET Course_Title = '" + course_title + "', Course_Code = '" + course_code + "' ,credit_hour = '" + double_credit_hour +
                                                "', Course_Semester = '" + course_semester + "'WHERE Serial = '" + CsL + "'  ";

                    SqlCommand updateCommand = new SqlCommand(query);
                    updateCommand.Parameters.AddWithValue("@course_title", course_title);
                    updateCommand.Parameters.AddWithValue("@course_code", course_code);
                    updateCommand.Parameters.AddWithValue("@double_credit_hour", double_credit_hour);
                    updateCommand.Parameters.AddWithValue("@course_semester", course_semester);

                    int row = dbAccess.executeQuery(updateCommand);
                    dbAccess.closeConn();

                    if (row == 1) { MessageBox.Show("Course Updated!!!"); refreshCourseTbl(); CourseTable(); }
                    else { MessageBox.Show("Could not Update."); }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        void courseDeleteValidation()
            {
            DialogResult d;
            d = MessageBox.Show("Do you want to delete? ", " Warning!! ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
                {
                try
                    {
                    string query = " DELETE FROM Course WHERE Serial = '" + CsL + "' ";
                    SqlCommand deleteCommand = new SqlCommand(query);

                    int row = dbAccess.executeQuery(deleteCommand);
                    dbAccess.closeConn();

                    if (row == 1) { MessageBox.Show("Course Deleted!!!"); refreshCourseTbl(); CourseTable(); }
                    else { MessageBox.Show("Could not Delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show(ex.Message);
                    }
                }
            }

        void fillFacultyCombo()
            {
            string query = " SELECT Faculty_Name FROM Faculty ";
            dbAccess.readDatathroughAdapter(query, FacultyTbl);
            dbAccess.closeConn();
            }

        void fillDepartCombo()
            {
            string query = " SELECT Department_Name FROM Department ";
            dbAccess.readDatathroughAdapter(query, DepartmentTbl);
            dbAccess.closeConn();
            }

        void fillTeacherCombo()
            {
            //TeacherTbl.Columns.Clear();
            //TeacherTbl.Rows.Clear();
            //TeacherTbl.Clear();
            string query = " SELECT * FROM Teacher ";
            dbAccess.readDatathroughAdapter(query, TeacherTbl);
            dbAccess.closeConn();
            }


        void CourseTable()
            {
            string query = " SELECT * FROM Course ";
            dbAccess.readDatathroughAdapter(query, CourseTbl);
            dbAccess.closeConn();
            dataGridCourse.DataSource = CourseTbl;

            //dataGridCourse.RowHeadersVisible = false;
            //this.dataGridCourse.DefaultCellStyle.Font = new Font("Tahoma", 10);
            }

        void FingerIDAvailable()
            {
            string query = " SELECT MAX(FingerPrintID) FROM FingerprintID ";
            dbAccess.readDatathroughAdapter(query, AvailableFIngerIDTbl);
            dbAccess.closeConn();

            int afid = Convert.ToInt32(AvailableFIngerIDTbl.Rows[0][0])+1;
            lblavailableFinger.Text = afid.ToString();
            }

        void refreshFingerIDAvailable()
            {
            AvailableFIngerIDTbl.Columns.Clear();
            AvailableFIngerIDTbl.Rows.Clear();
            AvailableFIngerIDTbl.Clear();
            }

        void clearTextboxValue()
            {
            facultyComboBox.Text = "--Select--";
            departCompoBox.Text = "--Select--";
            TeacherName.Text = "";
            email.Text = "";
            mobile.Text = "";
            password.Text = "";
            confirmpass.Text = "";
            FingerPrintTextBox.Text = "";
            }
        void clearTextLebelValue()
            {
            comboBoxTeacher.Text = "--Select Teacher--";
            TeacherNameLbl.Text = "";
            FacultyLbl.Text = "";
            DepartmentLbl.Text = "";
            emailLbl.Text = "";
            mobileLbl.Text = "";
            }
        void clearCourseTextBoxValue()
            {
            textBoxCourseTitle.Text = "";
            textBoxCourseCode.Text = "";
            textBoxCreditHour.Text = "";
            }

        void refreshTeacherTbl()
            {
            //TeacherTbl.Columns.Clear();
            //TeacherTbl.Rows.Clear();
            //TeacherTbl.Clear();
            comboBoxTeacher.DataSource = TeacherTbl;
            comboBoxTeacher.DisplayMember = "Teacher_Name";
            }
        void refreshCourseTbl()
            {
            CourseTbl.Columns.Clear();
            CourseTbl.Rows.Clear();
            CourseTbl.Clear();
            }

        /*
        void browsePhoto()
            {
                OpenFileDialog fileOpen = new OpenFileDialog();
                fileOpen.Title = "Open Image file";
                fileOpen.Filter = "JPG Files (*.jpg)| *.jpg|PNG Files (*.png)| *.png";

                if (fileOpen.ShowDialog() == DialogResult.OK)
                    {
                    photoLocation = fileOpen.FileName.ToString();
                    pictureBoxUpload.ImageLocation = photoLocation;
                    fileOpen.Dispose();
                    }
                fileOpen.Dispose();
            }
        */

        
        void browsePhoto()
            {
                //OpenFileDialog fileOpen = new OpenFileDialog();
                fileOpen = new OpenFileDialog();
                fileOpen.Title = "Open Image file";
                fileOpen.Filter = "JPG Files (*.jpg)| *.jpg";

                if (fileOpen.ShowDialog() == DialogResult.OK)
                    {
                    photoLocation = fileOpen.FileName.ToString();
                    pictureBoxUpload.Image = Image.FromFile(fileOpen.FileName);
                    }
                fileOpen.Dispose();
            }

        byte[] ImgToBinaryMem()
            {

                msimgtobi = new MemoryStream();
                pictureBoxUpload.Image.Save(msimgtobi, ImageFormat.Jpeg);
                byteimage = new byte[msimgtobi.Length];
                msimgtobi.Position = 0;
                msimgtobi.Read(byteimage, 0, byteimage.Length);
                return byteimage;
                
            }


        /*
        void ImgToBinary()
            {
            try 
                {
                if(photoLocation == null)
                    {
                    images = null;
                    }
                else
                    {
                    FileStream Stream = new FileStream(photoLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(Stream);
                    images = binaryReader.ReadBytes((int)Stream.Length);
                    }
                }
            catch
                {
                MessageBox.Show("No photo is selected");
                } 
            }
        */

        void selfFORM()
            {
            this.Hide();
            AdminPanel adminPanel = new AdminPanel();      
            adminPanel.Show();
            }

        void activeTab(int i)
            {
            this.ActiveControl = tabAdminPanel;
            tabAdminPanel.SelectTab(i);
           }

        int courseCodeToSemester(string coursecode)
            {
            int j = 0, semester = 0;
            int[] code = new int[3];
            string courseCode = coursecode;

            for (int i = 0; i < courseCode.Length; i++)
                {
                if (courseCode[i] >= 48 && courseCode[i] <= 56)
                    {
                    code[j] = courseCode[i] - 48;
                    j++;
                    }
                }

            if (code[1] % 2 == 0)
                { semester = code[0] * code[1]; }
            else
                { semester = (code[0] * 2) - code[1]; }
            return semester;
            }

        void maskingPassword()
            {
            password.PasswordChar = '*';
            confirmpass.PasswordChar = '*';
            }

        private void checkBoxPasshow_CheckedChanged(object sender, EventArgs e)
            {
            password.PasswordChar = checkBoxPasshow.Checked ? '\0' : '*';
            confirmpass.PasswordChar = checkBoxPasshow.Checked ? '\0' : '*';
            if (checkBoxPasshow.Checked)
                { checkBoxPasshow.ForeColor = Color.Black; }
            else { checkBoxPasshow.ForeColor = Color.White; }
            }


        private void textBoxSearch_TextChanged(object sender, EventArgs e)
            {
            TeacherTbl.Columns.Clear();
            TeacherTbl.Rows.Clear();
            TeacherTbl.Clear();

            string name = textBoxSearch.Text;
            string query = " SELECT * FROM Teacher WHERE Teacher_Name LIKE '%" + name + "%' ";
            dbAccess.readDatathroughAdapter(query, TeacherTbl);

            if (TeacherTbl.Rows.Count >= 1)
                {
                if (comboBoxTeacher.SelectedIndex != -1)
                    {
                    TeacherNameLbl.Text = TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Name"].ToString();
                    DepartmentLbl.Text = "Department of " + TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Department"].ToString();
                    FacultyLbl.Text = "Faculty of " + TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Faculty"].ToString();
                    emailLbl.Text = "Email: " + TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Email"].ToString();
                    mobileLbl.Text = "Contact: " + TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Teacher_Mobile"].ToString();

                    if (TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Photo"] == null)
                        {
                        pictureBoxTeacher.Image = null;
                        }
                    else
                        {
                        try
                            {
                            MemoryStream ms = new MemoryStream((byte[])TeacherTbl.Rows[comboBoxTeacher.SelectedIndex]["Photo"]);
                            pictureBoxTeacher.Image = new Bitmap(ms);
                            }
                        catch (Exception ex)
                            {
                            MessageBox.Show(ex.Message);
                            }
                        }

                    }
                }
            else
                {
                TeacherNameLbl.Text = "Name";
                FacultyLbl.Text = "Faculty";
                DepartmentLbl.Text = "Department";
                emailLbl.Text = "Email";
                mobileLbl.Text = "Mobile";
                comboBoxTeacher.Text = "No teacher found";
                pictureBoxTeacher.Image = null;
                }

            }

        private void textBoxSearch_Click(object sender, EventArgs e)
            {
            var search = (TextBox)sender;
            search.SelectAll();
            search.Focus();
            }



        private void AddButton_MouseLeave(object sender, EventArgs e)
            {
            AddButton.ForeColor = Color.Lime;
            AddButton.BackColor = Color.Black;
            }

        private void AddButton_MouseHover(object sender, EventArgs e)
            {
            AddButton.ForeColor = Color.Black;
            AddButton.BackColor = Color.Lime;
            }

        private void UpdateButton_MouseLeave(object sender, EventArgs e)
            {
            UpdateButton.ForeColor = Color.Yellow;
            UpdateButton.BackColor = Color.Black;
            }

        private void UpdateButton_MouseHover(object sender, EventArgs e)
            {
            UpdateButton.ForeColor = Color.Black;
            UpdateButton.BackColor = Color.Yellow;
            }

        private void DeleteButton_MouseLeave(object sender, EventArgs e)
            {
            DeleteButton.ForeColor = Color.Red;
            DeleteButton.BackColor = Color.Black;
            }

        private void DeleteButton_MouseHover(object sender, EventArgs e)
            {
            DeleteButton.ForeColor = Color.Black;
            DeleteButton.BackColor = Color.Red;
            }

        private void btnAllTeacher_MouseLeave(object sender, EventArgs e)
            {
            btnAllTeacher.ForeColor = Color.PowderBlue;
            btnAllTeacher.BackColor = Color.Black;
            }

        private void btnAllTeacher_MouseHover(object sender, EventArgs e)
            {
            btnAllTeacher.ForeColor = Color.Black;
            btnAllTeacher.BackColor = Color.PowderBlue;
            }

        private void buttonAddCourse_MouseLeave(object sender, EventArgs e)
            {
            buttonAddCourse.ForeColor = Color.Lime;
            buttonAddCourse.BackColor = Color.Black;
            }

        private void buttonAddCourse_MouseHover(object sender, EventArgs e)
            {
            buttonAddCourse.ForeColor = Color.Black;
            buttonAddCourse.BackColor = Color.Lime;
            }

        private void buttonUpdateCourse_MouseLeave(object sender, EventArgs e)
            {
            buttonUpdateCourse.ForeColor = Color.Gold;
            buttonUpdateCourse.BackColor = Color.Black;
            }

        private void buttonUpdateCourse_MouseHover(object sender, EventArgs e)
            {
            buttonUpdateCourse.ForeColor = Color.Black;
            buttonUpdateCourse.BackColor = Color.Gold;
            }

        private void buttonDeleteCourse_MouseLeave(object sender, EventArgs e)
            {
            buttonDeleteCourse.ForeColor = Color.Red;
            buttonDeleteCourse.BackColor = Color.Black;
            }

        private void buttonDeleteCourse_MouseHover(object sender, EventArgs e)
            {
            buttonDeleteCourse.ForeColor = Color.Black;
            buttonDeleteCourse.BackColor = Color.Red;
            }
        private void label9_MouseHover(object sender, EventArgs e)
            {
            LblBrowseImage.ForeColor = Color.Black;
            }
        private void label9_MouseLeave(object sender, EventArgs e)
            {
            LblBrowseImage.ForeColor = Color.White;
            }

        private void password_Click(object sender, EventArgs e)
            {
            var password = (TextBox)sender;
            password.SelectAll();
            password.Focus();
            }

        private void confirmpass_Click(object sender, EventArgs e)
            {
            var password = (TextBox)sender;
            confirmpass.SelectAll();
            confirmpass.Focus();
            }

        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
            {
            Application.Exit();
            }


        }
    }
