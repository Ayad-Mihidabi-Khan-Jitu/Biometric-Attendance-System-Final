using ArduinoUploader;
using ArduinoUploader.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biometric_Attendence_System
    {
    public partial class StudentsPanel : Form
        {
        string student_faculty = TeachersPanel.SelectedTeacherFaculty;
        public static string student_name;
        public static string student_id;
        public static string student_registration;
        public static string student_semester;
        public static string student_session;
        public static string student_email;
        public static string student_fingerprint;
        public static int SsL;
        string photoLocation;
        byte[] byteimage = null;
        public static string arduinoPort;

        MemoryStream msimgtobi;
        OpenFileDialog fileOpen;

        ///data table is like an database, our data source of this combobox is data table
        SerialCommunication communication = new SerialCommunication();
        LoadingForm loadingForm = new LoadingForm();
        DB dbAccess = new DB();
        DataTable StudentTbl = new DataTable();
        DataTable SemesterTbl = new DataTable();
        DataTable AvailableFIngerIDTbl = new DataTable();
        
        MailCreator mail = new MailCreator();

        public StudentsPanel()
            {
            InitializeComponent();
            SerialCommunication.serialPortClose();
            this.Controls.Add(SerialCommunication.textboxserialmonitor);
            communication.serialmoniproperty(45, 75, 96, 394, "HP Simplified", 11.0f, true, true,true);
            loadingForm.sketchwithProgessbar(communication.actionEnroll);
            loadingForm.ShowDialog();
            //SerialCommunication.serialPortClose();
            communication.SerialPort(SerialCommunication.SerialPortNumber);
            SerialCommunication.serialPortOpen();
            communication.serialDataReceived();
            }
        ///Methods in this FORM///

        private void HomeImg_Click(object sender, EventArgs e)
            {
            EnterHomeFORM();
            }

        private void BackBtn_Click(object sender, EventArgs e)
            {
            EnterTeacherPanelFORM();
            }

        private void AddStudentBtn_Click(object sender, EventArgs e)
            {
            studentInsertValidation();
            }
        private void UpdateStudentBtn_Click(object sender, EventArgs e)
            {
            studentUpdateValidation();
            }

        private void DeleteStudentBtn_Click(object sender, EventArgs e)
            {
            studentDeleteValidation();
            }
        private void btn_All_stu_Click(object sender, EventArgs e)
            {
            EnterStudentListFORM();
            }
        private void lebelEnableFingerprint_Click(object sender, EventArgs e)
            {
            FingerPrintTextBox.Enabled = true;
            lebelEnableFingerprint.Visible = false;
            }
        private void btntest_Click(object sender, EventArgs e)
            {
            communication.dataWrite(FingerPrintTextBox);
            }
        private void LblImageBrowse_Click(object sender, EventArgs e)
            {
            browsePhoto();
            }


        ///Events in this FORM///
        private void StudentsPanel_Load(object sender, EventArgs e)
            {
            this.ActiveControl = NameTxtBox;

            insertDataSemesterTable();
            fillStudentCombo();
            FingerIDAvailable();

            semesterCompoBox.DataSource = SemesterTbl;
            semesterCompoBox.DisplayMember = "Semester";

            studentComboBox.DataSource = StudentTbl;
            studentComboBox.DisplayMember = "Student_Name";

            initiateTextboxValue("","","","--Select--","","","");
            initiateTextLebelValue("--Select Student--","","","","","","");


            pictureBoxStudent.Image = null;
            pictureBoxStudent.Visible = false;
            SplashWithSketch.FmatchSkachUpload = false;

            //LoadingForm loadingForm = new LoadingForm();
            //loadingForm.sketchwithProgessbar(sketchaction);
            //loadingForm.ShowDialog();
            //SerialPortCon("COM4");
            }

        private void studentComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            pictureBoxStudent.Visible = true;
            if(studentComboBox.SelectedIndex != -1)
                {
                NameTxtBox.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Name"].ToString();
                IDTxtBox.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_ID"].ToString();
                RegisTxtBox.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Reg"].ToString();
                semesterCompoBox.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Semester"].ToString();
                sessionTxtBox.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Session"].ToString();
                emailTextBox.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Email"].ToString();
                FingerPrintTextBox.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Fingerprint_ID"].ToString();
                //student_fingerprint = FingerPrintTextBox.Text;

                studentComboBox.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Name"].ToString();
                StudentNameLbl.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Name"].ToString();
                IDLbl.Text = "ID: " + StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_ID"].ToString();
                RegisLbl.Text = "Reg. " + StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Reg"].ToString();
                SemesterLbl.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Semester"].ToString();
                sessionLbl.Text = "Session: " + StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Session"].ToString();
                mobileLbl.Text = "Email: " + StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Email"].ToString();
               

                FingerPrintTextBox.Enabled = false;
                lebelEnableFingerprint.Visible = true;

                if (StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Photo"] == null)
                    {
                    pictureBoxStudent.Image = null;
                    }
                else
                    {
                    try
                        {
                        MemoryStream ms = new MemoryStream((byte[])StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Photo"]);
                        pictureBoxStudent.Image = new Bitmap(ms);
                        //pictureBoxTeacher.Image = Image.FromStream(ms);
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show(ex.Message);
                        }
                    }

                SsL = Convert.ToInt32(StudentTbl.Rows[studentComboBox.SelectedIndex]["Serial"].ToString());
                }
            }



        ///Functions in this FORM///
        void EnterHomeFORM()
            {
            try
                {
                SerialCommunication.serialPortClose();
                //this.Close();
                this.Hide();
                Login login = new Login();
                login.Show();
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        void EnterTeacherPanelFORM()
            {
            try
                {
                SerialCommunication.serialPortClose();
                //this.Close();
                this.Hide();
                TeachersPanel teachersPanel = new TeachersPanel();                
                teachersPanel.Show();
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        void EnterStudentListFORM()
            {
            try
                {
                //this.Close();
                StudentsList students = new StudentsList();
                students.Show();
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }


        void studentInsertValidation()
            {
            try
                {
                student_name = NameTxtBox.Text;
                student_id = IDTxtBox.Text.Trim();
                student_registration = RegisTxtBox.Text.Trim();
                student_semester = SemesterTbl.Rows[semesterCompoBox.SelectedIndex]["Semester"].ToString();
                student_session = sessionTxtBox.Text.Trim();
                student_email = emailTextBox.Text.Trim();
                student_fingerprint = FingerPrintTextBox.Text.Trim();
                byte[] image = ImgToBinaryMem();
                string email_subject = mail.emailSubject + "Student Enrollment Successful";
                string email_body = mail.email_body_header + student_name + "<br>" + "ID:  " + student_id + "<br>" + "Reg. No. " + student_registration + "<br>" + "Email: " + student_semester + "<br>" + "Session: " + student_session + "<br>" + "Email: " + student_email + "<br>" + "FingerID: " + student_fingerprint + mail.email_body_footer + mail.soft_detail;


                if (student_name == "" || student_id == "" || student_registration == "" || student_semester == "" || student_session == "" || student_email == "" || student_fingerprint == "")
                    { MessageBox.Show("Fields can not be Empty!"); }
                else if (IsIDuplicateFID() == 0 && IsIDuplicateSID() ==0)
                    {
                    int int_student_fingerprint = Convert.ToInt32(FingerPrintTextBox.Text);
                    string query = "INSERT INTO Student(Student_ID, Student_Name, Student_Reg, Student_Session, Student_Semester, Student_Email, Student_Photo, Student_Fingerprint_ID, Student_Faculty)" +
                    "VALUES (@student_id, @student_name, @student_registration, @student_session, @student_semester, @student_email, @image, @int_student_fingerprint, @student_faculty)";
                    //string query = "INSERT INTO Student(Student_ID, Student_Name, Student_Reg, Student_Session, Student_Semester, Student_Mobile, Student_Fingerprint_ID)" +
                    // "VALUES (@student_id, @student_name, @student_registration, @student_session, @student_semester, @student_mobile, @int_student_fingerprint)";
                    SqlCommand insertCommand = new SqlCommand(query);
                    insertCommand.Parameters.AddWithValue("@student_id", student_id);
                    insertCommand.Parameters.AddWithValue("@student_name", student_name);
                    insertCommand.Parameters.AddWithValue("@student_registration", student_registration);
                    insertCommand.Parameters.AddWithValue("@student_session", student_session);
                    insertCommand.Parameters.AddWithValue("@student_semester", student_semester);
                    insertCommand.Parameters.AddWithValue("@student_email", student_email);
                    insertCommand.Parameters.AddWithValue("@int_student_fingerprint", int_student_fingerprint);
                    insertCommand.Parameters.AddWithValue("@student_faculty", student_faculty);
                    insertCommand.Parameters.AddWithValue("@image", image);

                    int row = dbAccess.executeQuery(insertCommand);
                    dbAccess.closeConn();

                    if (row == 1) 
                        {
                        mail.SendEmail(mail.defalultSender, student_email, email_subject, email_body);
                        MessageBox.Show("New Student Added!!"); 
                        refreshCombo();
                        refreshFingerIDAvailable();
                        FingerIDAvailable();                       
                        }
                    else { MessageBox.Show("Could not Insert.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else
                    {
                    MessageBox.Show("Sorry, could't add this student.\n" + "Student ID " + student_id +" or Finger ID "+ student_fingerprint+ " is already exists!! ", "Could not Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        void refreshCombo()
            {
            StudentTbl.Rows.Clear();
            StudentTbl.Columns.Clear();
            StudentTbl.Clear();

            fillStudentCombo();
            studentComboBox.DataSource = null;
            studentComboBox.Items.Clear();
            studentComboBox.DataSource = StudentTbl;
            studentComboBox.DisplayMember = "Student_Name";
            initiateTextboxValue("", "", "", "--Select--", "", "", "");
            initiateTextLebelValue("--Select Student--", "", "", "", "", "", "");
            pictureBoxStudent.Image = null;
            pictureBoxStudent.Visible = false;
            }

        int IsIDuplicateSID()
            {
            string student_Id = IDTxtBox.Text.Trim();
            DataTable IsIDAvailable = new DataTable();
            string query = " SELECT Student_ID FROM Student WHERE Student_ID ='" + student_Id + "' ";
            dbAccess.readDatathroughAdapter(query, IsIDAvailable);
            int i = IsIDAvailable.Rows.Count;
            dbAccess.closeConn();
            return i;
            }

        int IsIDuplicateFID()
            {
            string finger_Id = FingerPrintTextBox.Text.Trim();
            DataTable IsIDAvailable = new DataTable();
            string query = " SELECT Student_ID FROM Student WHERE Student_Fingerprint_ID ='" + finger_Id + "' ";
            dbAccess.readDatathroughAdapter(query, IsIDAvailable);
            int i = IsIDAvailable.Rows.Count;
            dbAccess.closeConn();
            return i;
            }

        void studentUpdateValidation()
            {
            try
                {
                student_name = NameTxtBox.Text;
                student_id = IDTxtBox.Text.Trim();
                student_registration = RegisTxtBox.Text.Trim();
                student_semester = SemesterTbl.Rows[semesterCompoBox.SelectedIndex]["Semester"].ToString();
                student_session = sessionTxtBox.Text.Trim();
                student_email = emailTextBox.Text.Trim();
                student_fingerprint = FingerPrintTextBox.Text;
                byte[] image = ImgToBinaryMem();
                string email_subject = mail.emailSubject + "Student Update Successful";
                string email_body = mail.email_body_header + student_name + "<br>" + "ID:  " + student_id + "<br>" + "Reg. No. " + student_registration + "<br>" + "Email: " + student_semester + "<br>" + "Session: " + student_session + "<br>" + "Email: " + student_email + "<br>" + "FingerID: " + student_fingerprint + mail.email_body_footer + mail.soft_detail;


                if (student_name == "" || student_id == "" || student_registration == "" || student_semester == "" || student_session == "" || student_email == "" || student_fingerprint == "")
                    { MessageBox.Show("Fields can not be Empty!"); }
                else
                    {
                    SqlCommand updateCommand;
                    if (photoLocation == null) 
                        {
                        string query = " UPDATE Student SET Student_ID = @student_id, Student_Name = @student_name , Student_Reg = @student_registration ," +
                               "Student_Session = @student_session, Student_Semester = @student_semester, Student_Email = @student_email WHERE Serial = '" + SsL + "' ";
                        //string query = " UPDATE Student SET Student_ID = '" + student_id + "', Student_Name = '" + student_name + "' ,Student_Reg = '"
                       //+ student_registration + "' ,Student_Session = '" + student_session + "', Student_Semester = '" + student_semester + "', Student_Mobile = '" + student_mobile +
                       //"' WHERE Serial = '" + SsL + "' ";
                        updateCommand = new SqlCommand(query);
                        updateCommand.Parameters.AddWithValue("@student_id", student_id);
                        updateCommand.Parameters.AddWithValue("@student_name", student_name);
                        updateCommand.Parameters.AddWithValue("@student_registration", student_registration);
                        updateCommand.Parameters.AddWithValue("@student_session", student_session);
                        updateCommand.Parameters.AddWithValue("@student_semester", student_semester);
                        updateCommand.Parameters.AddWithValue("@student_email", student_email);
                        //updateCommand.Parameters.AddWithValue("@int_student_fingerprint", int_student_fingerprint);
                        }
                    else
                        {
                        string query = " UPDATE Student SET Student_ID = @student_id, Student_Name = @student_name , Student_Reg = @student_registration ," +
                             "Student_Session = @student_session, Student_Semester = @student_semester, Student_Email = @student_email, Student_Photo = @image WHERE Serial = '" + SsL + "' ";
                        //string query = " UPDATE Student SET Student_ID = '" + student_id + "', Student_Name = '" + student_name + "' ,Student_Reg = '"
                        //+ student_registration + "' ,Student_Session = '" + student_session + "', Student_Semester = '" + student_semester + "', Student_Mobile = '" + student_mobile +
                        //"' WHERE Serial = '" + SsL + "' ";
                        updateCommand = new SqlCommand(query);
                        updateCommand.Parameters.AddWithValue("@student_id", student_id);
                        updateCommand.Parameters.AddWithValue("@student_name", student_name);
                        updateCommand.Parameters.AddWithValue("@student_registration", student_registration);
                        updateCommand.Parameters.AddWithValue("@student_session", student_session);
                        updateCommand.Parameters.AddWithValue("@student_semester", student_semester);
                        updateCommand.Parameters.AddWithValue("@student_email", student_email);
                        updateCommand.Parameters.AddWithValue("@image", image);
                        //updateCommand.Parameters.AddWithValue("@int_student_fingerprint", int_student_fingerprint);

                        }
                        int row = dbAccess.executeQuery(updateCommand);
                        dbAccess.closeConn();

                        if (row == 1) 
                            {
                            mail.SendEmail(mail.defalultSender, student_email, email_subject, email_body);
                            MessageBox.Show("Student Updated!!!"); 
                            refreshCombo(); 
                            }
                        else { MessageBox.Show("Could not Update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }
        void studentDeleteValidation()
            {
            DialogResult d;
            d = MessageBox.Show("Do you want to delete? ", " Warning!! ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
                {
            
                    try
                        {
                        string query = " DELETE FROM Student WHERE Serial = '" + SsL + "' ";
                        SqlCommand deleteCommand = new SqlCommand(query);

                        int row = dbAccess.executeQuery(deleteCommand);
                        dbAccess.closeConn();

                        if (row == 1) 
                            { 
                               MessageBox.Show("Student Deleted!!!");
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


        void initiateTextboxValue(string name, string id, string reg, string semester, string session, string mobile,string fid)
            {
            NameTxtBox.Text = name;
            IDTxtBox.Text = id;
            RegisTxtBox.Text = reg;
            semesterCompoBox.Text = semester;
            sessionTxtBox.Text = session;
            emailTextBox.Text = mobile;
            FingerPrintTextBox.Text = fid;
            //ImgToBinary();
            }
        void initiateTextLebelValue(string comboItem, string name, string id, string reg, string semester, string session, string mobile)
            {
            studentComboBox.Text = comboItem;
            StudentNameLbl.Text = name;
            IDLbl.Text = id;
            RegisLbl.Text = reg;
            SemesterLbl.Text = semester;
            sessionLbl.Text = session;            
            mobileLbl.Text = mobile;
            }
          void insertDataSemesterTable()
            {
            SemesterTbl.Columns.Add("SL", typeof(int));
            SemesterTbl.Columns.Add("Semester", typeof(string));

            string[] semesterList = { "Semester-1", "Semester-2", "Semester-3", "Semester-4", "Semester-5", "Semester-6", "Semester-7", "Semester-8" };
            for(int i = 0; i < semesterList.Length; i++)
                {
                SemesterTbl.Rows.Add(i+1, semesterList[i]);
                }
            }
        void fillStudentCombo()
            {
            string query = " SELECT * FROM Student ";
            dbAccess.readDatathroughAdapter(query, StudentTbl);
            dbAccess.closeConn();
            }

        void FingerIDAvailable()
            {
            string query = " SELECT MAX(FingerPrintID) FROM FingerprintID ";
            dbAccess.readDatathroughAdapter(query, AvailableFIngerIDTbl);
            dbAccess.closeConn();

            int afid = Convert.ToInt32(AvailableFIngerIDTbl.Rows[0][0]) + 1;
            lblavailableFinger.Text = afid.ToString();
            }

        void refreshFingerIDAvailable()
            {
            AvailableFIngerIDTbl.Columns.Clear();
            AvailableFIngerIDTbl.Rows.Clear();
            AvailableFIngerIDTbl.Clear();
            }


        void browsePhoto()
            {
            //OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen = new OpenFileDialog();
            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg";

            if (fileOpen.ShowDialog() == DialogResult.OK)
                {
                photoLocation = fileOpen.FileName.ToString();
                pictureBoxBrowse.Image = Image.FromFile(fileOpen.FileName);
                }
            fileOpen.Dispose();
            }

        byte[] ImgToBinaryMem()
            {

            msimgtobi = new MemoryStream();
            pictureBoxBrowse.Image.Save(msimgtobi, ImageFormat.Jpeg);
            byteimage = new byte[msimgtobi.Length];
            msimgtobi.Position = 0;
            msimgtobi.Read(byteimage, 0, byteimage.Length);
            return byteimage;
            }


        private void textBoxSearch_TextChanged(object sender, EventArgs e)
            {
            StudentTbl.Columns.Clear();
            StudentTbl.Rows.Clear();
            StudentTbl.Clear();

            string name = textBoxSearch.Text;
            string query = " SELECT * FROM Student WHERE Student_Name LIKE '%" + name + "%' ";
            dbAccess.readDatathroughAdapter(query, StudentTbl);

            if (StudentTbl.Rows.Count >= 1)
                {
                if (studentComboBox.SelectedIndex != -1)
                    {
                    StudentNameLbl.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Name"].ToString();
                    IDLbl.Text = "ID: " + StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_ID"].ToString();
                    RegisLbl.Text = "Reg. " + StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Reg"].ToString();
                    SemesterLbl.Text = StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Semester"].ToString();
                    sessionLbl.Text = "Session: " + StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Session"].ToString();
                    mobileLbl.Text = "Email: " + StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Email"].ToString();

                    if (StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Photo"] == null)
                        {
                        pictureBoxStudent.Image = null;
                        }
                    else
                        {
                        try
                            {
                            MemoryStream ms = new MemoryStream((byte[])StudentTbl.Rows[studentComboBox.SelectedIndex]["Student_Photo"]);
                            pictureBoxStudent.Image = new Bitmap(ms);
                            //pictureBoxTeacher.Image = Image.FromStream(ms);
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
                studentComboBox.Text = "No Student found";
                StudentNameLbl.Text = "Name";
                IDLbl.Text = "Student ID";
                RegisLbl.Text = "Registration No.";
                SemesterLbl.Text = "Semester";
                sessionLbl.Text = "Session ";
                mobileLbl.Text = "Email";
                pictureBoxStudent.Image = null;
                }

            }

        private void textBoxSearch_Click(object sender, EventArgs e)
            {
            var search = (TextBox)sender;
            search.SelectAll();
            search.Focus();
            }



        private void AddStudentBtn_MouseHover(object sender, EventArgs e)
            {
            AddStudentBtn.ForeColor = Color.Black;
            AddStudentBtn.BackColor = Color.Lime;
            }

        private void AddStudentBtn_MouseLeave(object sender, EventArgs e)
            {
            AddStudentBtn.ForeColor = Color.Lime;
            AddStudentBtn.BackColor = Color.Black;
            }

        private void UpdateStudentBtn_MouseHover(object sender, EventArgs e)
            {
            UpdateStudentBtn.ForeColor = Color.Black;
            UpdateStudentBtn.BackColor = Color.Gold;
            }

        private void UpdateStudentBtn_MouseLeave(object sender, EventArgs e)
            {
            UpdateStudentBtn.ForeColor = Color.Gold;
            UpdateStudentBtn.BackColor = Color.Black;
            }
        private void DeleteStudentBtn_MouseHover(object sender, EventArgs e)
            {
            DeleteStudentBtn.ForeColor = Color.Black;
            DeleteStudentBtn.BackColor = Color.Red;
            }
        private void DeleteStudentBtn_MouseLeave(object sender, EventArgs e)
            {
            DeleteStudentBtn.ForeColor = Color.Red;
            DeleteStudentBtn.BackColor = Color.Black;
            }

        private void btn_All_stu_MouseHover(object sender, EventArgs e)
            {
            btn_All_stu.ForeColor = Color.Black;
            btn_All_stu.BackColor = Color.Pink;
            }

        private void btn_All_stu_MouseLeave(object sender, EventArgs e)
            {
            btn_All_stu.ForeColor = Color.Pink;
            btn_All_stu.BackColor = Color.Black;
            }

        private void btntest_MouseLeave(object sender, EventArgs e)
            {
            btntest.ForeColor = Color.Black;
            btntest.BackColor = Color.GreenYellow;
            }

        private void btntest_MouseHover(object sender, EventArgs e)
            {
            btntest.ForeColor = Color.GreenYellow;
            btntest.BackColor = Color.Black;
            }

        private void lebelEnableFingerprint_MouseHover(object sender, EventArgs e)
            {
            lebelEnableFingerprint.ForeColor = Color.LimeGreen;
            }
        private void lebelEnableFingerprint_MouseLeave(object sender, EventArgs e)
            {
            lebelEnableFingerprint.ForeColor = Color.Black;
            }

        private void StudentsPanel_FormClosing(object sender, FormClosingEventArgs e)
            {
            Application.Exit();
            }



        /*
void selfFORM()
    {
    //this.Close();
    this.Hide();
    StudentsPanel studentPanel = new StudentsPanel();
    studentPanel.Show();
    }
*/

        /*
bool SerialPortCon(string port)
    {
    serialPort1.Close();
    serialPort1.PortName = port;
    serialPort1.BaudRate = 9600; // use same baud rate as used in Arduino
    serialPort1.DataBits = 8;
    serialPort1.Parity = Parity.None;
    serialPort1.StopBits = StopBits.One;
    serialPort1.Handshake = Handshake.None;
    serialPort1.Encoding = System.Text.Encoding.Default;
    serialPort1.Open();
    return true;
    }


private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
    try
        {
        string mydata = "";
        mydata = serialPort1.ReadExisting();
        //mydata = mydata.Trim();
        if (textboxSerialMonitor.InvokeRequired)
            {
            //textBoxStudent.Invoke((MethodInvoker)() => textBoxStudent.Text += mydata);
            textboxSerialMonitor.Invoke((MethodInvoker)delegate { textboxSerialMonitor.AppendText(mydata) ; });
            //textBoxStudent.Invoke(new MethodInvoker(delegate { textBoxStudent.Text += mydata; }));
            }
        else
            {
            textboxSerialMonitor.AppendText(mydata);
            }
        }
    catch (Exception ex)
        {
        MessageBox.Show(ex.Message);
        }
    }   

void dataWrite()
    {
    try
        {
        int id = Convert.ToInt32(FingerPrintTextBox.Text.Trim());
        if (id >= 1 && id <= 127)
            {
            serialPort1.WriteLine(id.ToString());
            }
        else
            {
            MessageBox.Show("Fingerprint ID should be between 1-127");
            }
        }
    catch(Exception ex)
        {
        MessageBox.Show(ex.Message);
        }
    }




public static string DetectArduino()
    {
    ManagementScope connectionScope = new ManagementScope();
    SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);
    try
        {
        foreach (ManagementObject item in searcher.Get())
            {
            string desc = item["Description"].ToString();
            string deviceId = item["DeviceID"].ToString();
            if (desc.Contains("USB Serial Device"))
                {
                //MessageBox.Show("Arduino details: " + desc + " on " + deviceId);
                return deviceId;
                }
            }
        }
    catch (ManagementException e)
        {
        //Do Nothing
        MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
        }
    return null;
    }

*/



        /*

                public static void uploadSketchFileEnroll()
                    {
                    try
                        {
                        var uploader = new ArduinoSketchUploader(new ArduinoSketchUploaderOptions()
                            {
                            FileName = @"C:\Users\HP 840 G1\Documents\Visual Studio 2019\Projects\Biometric Attendence System\Biometric_Attendence_FEnroll.ino.hex",
                            PortName = "COM4",
                            ArduinoModel = ArduinoModel.UnoR3
                            });
                        uploader.UploadSketch();
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show(ex.Message);
                        }
                    }

                //sketchwithProgessbarDele deleSkaPro = uploadSketchFileEnroll;
                Action sketchaction = uploadSketchFileEnroll;
                */

        }
    }

