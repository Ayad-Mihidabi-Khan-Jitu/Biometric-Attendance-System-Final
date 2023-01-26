using ArduinoUploader;
using ArduinoUploader.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DomainUpDown;

namespace Biometric_Attendence_System
    {
    //public delegate void sketchwithProgessbarDele();

    public partial class TeachersPanel : Form
        {
        private Stopwatch stopwatch;
        bool state = false;
        bool state1 = true;
        string durationHrMin = "00:00";
        double durationSec;

        string LogedInTeacher = Login.username;
        public static string SelectedCourseCode;
        public static string SelectedSemester;
        public static string SelectedTeacherFaculty;
        public static string SelectedTeacherEmail;
        public static string date;
        bool SemesterChoose = false;
        bool CourseCodeChoose = false;
        string fingerID;
        
        
        bool isSelectedClassNo = false;

        DB dbAccess = new DB();
        DataTable CourseTbl = new DataTable();
        DataTable SemesterTbl = new DataTable();
        DataTable SpecificCourseCodeTbl = new DataTable();
        DataTable SelectedStudentTbl = new DataTable();
        DataTable SelectedTeacherTbl = new DataTable();

        SerialCommunication serial = new SerialCommunication();


        public TeachersPanel()
            {
            InitializeComponent();
            this.Controls.Add(SerialCommunication.textboxserialmonitor);
            serial.serialmoniproperty(148, 214, 10, 50, "HP Simplified", 11.0f, false, true, true);
            serial.serialDataReceived();
            }

        /// Form Events///
        private void TeachersPanel_Load(object sender, EventArgs e)
            {
            checkBoxID.Visible = false;

            date = dateTimPickr.Value.ToShortDateString();
            stopwatch = new Stopwatch();
            currenttimer.Start();
            stopwatchtimer.Start();

            //Teacher Name from the login form
            labelTeacherName.Text = LogedInTeacher;

            insertDataSemesterTable();
            comboBoxSemester.DataSource = SemesterTbl;
            comboBoxSemester.DisplayMember = "Semester";

            comboBoxCourse.Enabled = false;
            fillCourseCombo();
            comboBoxCourse.DataSource = CourseTbl;
            comboBoxCourse.DisplayMember = "Course_Code";

            comboBoxSemester.Text = "Semester";
            comboBoxCourse.Text = "Course Code";

            this.ActiveControl = dateTimPickr;

            StartTButton.Enabled = false;
            StartTButton.BackColor = Color.White;
            LblSemCCodeSelect.Visible = true;

            checkBoxSemCcode.Enabled = false;
            checkBoxSemCcode.ForeColor = Color.Black;

            fillDomainUpDown();
            //classNodomainUpDownDefault();

            selectedTeacher(LogedInTeacher);
            SelectedTeacherEmail = SelectedTeacherTbl.Rows[0].Field<string>("Teacher_Email");
            SelectedTeacherFaculty = SelectedTeacherTbl.Rows[0].Field<string>("Teacher_Faculty");

            if(SplashWithSketch.FmatchSkachUpload != true)
                {
                LoadingForm loadingForm = new LoadingForm();
                //loadingForm.sketchwithProgessbar(sketchaction);
                loadingForm.sketchwithProgessbar(serial.actionMatch);
                loadingForm.ShowDialog();
                SplashWithSketch.FmatchSkachUpload = true;
                }
            
            serial.SerialPort(SerialCommunication.SerialPortNumber);
            SerialCommunication.serialPortOpen();
            //SerialPortCon("COM4");
            }

        private void comboBoxSemester_SelectedIndexChanged(object sender, EventArgs e)
            {
            try
                {
                comboBoxCourse.Enabled = true;
                SpecificCourseCodeTbl = CourseTbl.Select("Course_Semester = " + SemesterTbl.Rows[comboBoxSemester.SelectedIndex]["SL"]).CopyToDataTable();
                comboBoxCourse.DataSource = SpecificCourseCodeTbl;
                comboBoxCourse.DisplayMember = "Course_Code";
                SelectedSemester = comboBoxSemester.Text;
                SemesterLbl.Text = SelectedSemester;
                SemesterChoose = true;
                selectedStudent(comboBoxSemester.Text);
                checkBoxSemCcodeDefault();
                classNodomainUpDownDefault();

                if (isSemesterCourseSelected(SemesterChoose, CourseCodeChoose))
                    {
                    StartTButton.BackColor = Color.White;
                    LblSemCCodeSelect.Visible = false;
                    checkBoxSemCcode.Enabled = true;
                    }
                }
            catch
                {
                ///Ekhane akta expection ache:
                // [Course_Semester] could not found ashe.
                }
            }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
            {
            SelectedCourseCode = comboBoxCourse.Text;
            CourseCodeLbl.Text = SelectedCourseCode;
            CourseCodeChoose = true;
            }
        private void classNodomainUpDown_SelectedItemChanged(object sender, EventArgs e)
            {
            isSelectedClassNo = true;
            }
        void classNodomainUpDownDefault()
            {
            classNodomainUpDown.Text = "Class No.";
            classNodomainUpDown.SelectedIndex.Equals(null);
            }

        ///Methods in this form///
        private void HomeImg_Click(object sender, EventArgs e)
            {
            EnterHomeFORM();
            }

        private void timer_Tick(object sender, EventArgs e)
            {
            Timelabel.Text = DateTime.Now.ToString("hh:mm");
            AMPMlabel.Text = DateTime.Now.ToString("tt");
            Seclabel.Text = DateTime.Now.ToString("ss");
            Datelabel.Text = DateTime.Now.ToString("dd MMMM yyyy");
            Daylabel.Text = DateTime.Now.ToString("dddd");
            }

        private void StartTButton_Click(object sender, EventArgs e)
            {
            StartTButton.Location = new Point(400, 300);
           
            PauseButton.Visible = true;
            if (state)
                {
                stopwatch.Reset();
                PauseButton.Visible = false;
                startState();
                durationVisibility(true);
                //duraTimeLabel.Text = Convert.ToString(durationSec);
                checkBoxSemCcodeNoWhenClassRunning(false);
                IsActivecomboBoxSemester_CourseCode_ClassNo(false);
                }
            else
                {
                stopwatch.Start();
                stopState();
                pauseState();
                durationVisibility(false);
                checkBoxSemCcodeNoWhenClassRunning(true);
                IsActivecomboBoxSemester_CourseCode_ClassNo(true);
                fingerIDtimer.Enabled = true;
                }
            }

        private void PauseButton_Click(object sender, EventArgs e)
            {
            if (state1)
                {
                stopwatch.Stop();
                resumeState();
                }
            else
                {
                stopwatch.Start();
                pauseState();
                }
            }

        private void stopwatchtimer_Tick(object sender, EventArgs e)
            {
            minlabel.Text = string.Format("{0:hh\\:mm\\:ss}", stopwatch.Elapsed);
            durationHrMin = string.Format("{0:hh\\:mm}", stopwatch.Elapsed);
            durationSec = stopwatch.Elapsed.TotalSeconds;      
            }

        ///Methods in this FORM

        private void StuPanelButton_Click(object sender, EventArgs e)
            {
            // if (serialPort1.IsOpen){serialPort1.Close(); }
            SerialCommunication.serialPortClose();
            fingerIDtimer.Stop();
            //this.Close();
            this.Hide();
            StudentsPanel studentsPanel = new StudentsPanel();
            studentsPanel.Show();
            }

        private void ViewButton_Click(object sender, EventArgs e)
            {
            EnterVIewSheetFORM();
            }

        private void checkBoxSemCcode_CheckedChanged(object sender, EventArgs e)
            {
            if (checkBoxSemCcode.Checked)
                {
                paneClassDuration.Visible = false;
                StartTButton.Location = new Point(400, 230);
                StartTButton.Visible = true;
                if (!isSelectedClassNo)
                    {
                    DialogResult d;
                    d = MessageBox.Show("Class No. is not selected.\nDo you want to select?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (d == DialogResult.Yes)
                        {
                        this.ActiveControl = classNodomainUpDown;
                        checkBoxSemCcodeDefault();
                        AttendenceInsertToTable();
                        }
                    else
                        {
                        checkBoxSemCcodeNoDefault();
                        AttendenceInsertToTable();
                        }
                    }
                else
                    {
                    checkBoxSemCcodeNoDefault();
                    AttendenceInsertToTable();
                    }

                }
            else
                {
                paneClassDuration.Visible = true;
                StartTButton.Visible = false;
                checkBoxSemCcodeDefault();
                }
            }

        void checkBoxSemCcodeDefault()
            {
            checkBoxSemCcode.Checked = false;
            checkBoxSemCcode.Text = "Confirm";
            checkBoxSemCcode.ForeColor = Color.Black;
            }

        void checkBoxSemCcodeNoDefault()
            {
            checkBoxSemCcode.Text = "Confirmed";
            checkBoxSemCcode.ForeColor = Color.DarkGreen;
            StartTButton.Enabled = true;
            }

        void checkBoxSemCcodeNoWhenClassRunning(bool r)
            {
            if (r)
                {
                checkBoxSemCcode.Enabled = false;
                checkBoxSemCcode.Text = "Confirmed";
                checkBoxSemCcode.ForeColor = Color.Black;
                }
            else
                {
                checkBoxSemCcode.Checked = false;
                checkBoxSemCcode.Enabled = true;
                checkBoxSemCcode.Text = "Confirm";
                }
            }

        void IsActivecomboBoxSemester_CourseCode_ClassNo(bool r)
            {
            if (r)
                {
                comboBoxSemester.Enabled = !r;
                comboBoxCourse.Enabled = !r;
                classNodomainUpDown.Enabled = !r;
                }
            else
                {
                comboBoxSemester.Enabled = !r;
                comboBoxCourse.Enabled = !r;
                classNodomainUpDown.Enabled = !r;
                }
            }


        ///Functions in this FORM
        void pauseState()
            {
            PauseButton.Text = "Pause";
            PauseButton.ForeColor = Color.DarkOrange;
            state1 = true;
            }
        void resumeState()
            {
            PauseButton.Text = "Resume";
            PauseButton.ForeColor = Color.GreenYellow;
            state1 = false;
            }
        void startState()
            {
            StartTButton.Text = "Start";
            StartTButton.ForeColor = Color.Lime;
            StartTButton.BackColor = Color.White;
            state = false;
            }
        void stopState()
            {
            StartTButton.Text = "Stop";
            StartTButton.ForeColor = Color.Red;
            StartTButton.BackColor = Color.White;
            state = true;
            }
        void durationVisibility(bool isvisible)
            {
            duraTimeLabel.Text = durationHrMin;
            durationLabel.Visible = isvisible;
            duraTimeLabel.Visible = isvisible;
            duHr.Visible = isvisible;
            duMin.Visible = isvisible;
            }
        void EnterHomeFORM()
            {
            //if (serialPort1.IsOpen) serialPort1.Close();
            SerialCommunication.serialPortClose();
            fingerIDtimer.Stop();
            //this.Close();
            this.Hide();
            Login login = new Login();
            login.Show();
            }

        void EnterVIewSheetFORM()
            {
            AttendenceDetails attendenceDetail = new AttendenceDetails();
            attendenceDetail.Show();
            }

        void insertDataSemesterTable()
            {
            SemesterTbl.Columns.Add("SL", typeof(int));
            SemesterTbl.Columns.Add("Semester", typeof(string));

            string[] semesterList = { "Semester-1", "Semester-2", "Semester-3", "Semester-4", "Semester-5", "Semester-6", "Semester-7", "Semester-8" };
            for (int i = 0; i < semesterList.Length; i++)
                {
                SemesterTbl.Rows.Add(i + 1, semesterList[i]);
                }
            }

        void fillCourseCombo()
            {
            string query = " SELECT * FROM Course ";
            dbAccess.readDatathroughAdapter(query, CourseTbl);
            }
        void fillDomainUpDown()
            {
            DomainUpDownItemCollection DClassNoItem = this.classNodomainUpDown.Items;
            for (int i = 1; i <= 100; i++)
                {
                DClassNoItem.Add(i);
                }
            }

        ///Course Code theke Semester Create kore 
        int courseCodeToSemester(string coursecode)
            {
            int j = 0, semester = 0;
            int[] code = new int[3];
            string courseCode = coursecode;

            for (int i = 0; i < courseCode.Length; i++)
                { if (courseCode[i] >= 48 && courseCode[i] <= 56)
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
        bool isSemesterCourseSelected(bool s, bool c)
            {
            return (s && c);
            }

        /*
        /// ai function ta dynamically Semester/Semester er index er combination e  
        /// specific course table e data generate kore
        void showSpecificCourse()
            {
            ///nicher 1 and 2 Form Load er vitore dite hoy  
            ///1. SpecificCourseCodeTbl.Columns.Add("SL", typeof(int));
            ///2. SpecificCourseCodeTbl.Columns.Add("Course_Code", typeof(string));
            int indexofsem = comboBoxSemester.SelectedIndex + 1;
            int rows = CourseTbl.Rows.Count, j = 0;
            for (int i = 0; i < rows; i++)
                {
                string coursecode = CourseTbl.Rows[i]["Course_Code"].ToString();
                int code = courseCodeToSemester(coursecode);
                if (indexofsem == code)
                    {
                    SpecificCourseCodeTbl.Rows.Add(j, coursecode);
                    }
                }
            }
        */

        /*
        ///ai function ti CourseTbl run time e new Column 'Semester' create kore
        ///abong course code theke 'Semester' column e data insert kore 
        void addSemesterToCourse()
            {
            CourseTbl.Columns.Add("Semester", typeof(int));
            int rows = CourseTbl.Rows.Count;
            for (int i = 0; i < rows; i++)
                {
                string coursecode = CourseTbl.Rows[i]["Course_Code"].ToString();
                int semester = courseCodeToSemester(coursecode);
                int sl = Convert.ToInt32(CourseTbl.Rows[i]["Serial"].ToString());
                string coursetitle = CourseTbl.Rows[i]["Course_Title"].ToString();
                double credithour = Convert.ToDouble(CourseTbl.Rows[i]["Credit_Hour"].ToString());

                CourseTbl.Rows[i]["Serial"] = sl;
                CourseTbl.Rows[i]["Course_Title"] = coursetitle;
                CourseTbl.Rows[i]["Course_Code"] = coursecode;
                CourseTbl.Rows[i]["Credit_Hour"] = credithour;
                CourseTbl.Rows[i]["Semester"] = semester;
                }
            }
        */

        ///Attendence Table er kaj///
        void AttendenceInsertToTable()
            {
            int countSelectedStudent = 0;
            string teacher_name = LogedInTeacher;
            string teacher_email = SelectedTeacherEmail;
            string course_code = comboBoxCourse.Text.Trim();
            string semester = comboBoxSemester.Text.Trim();
            string classno = classNodomainUpDown.Text.Trim();
            string date = dateTimPickr.Value.ToShortDateString();

            countSelectedStudent = selectedStudent(semester);

            for (int r = 0; r < countSelectedStudent; r++)
                {
                string student_id;
                string student_name;
                string attendence_state = "Absent";
                int student_fid;

                student_id = SelectedStudentTbl.Rows[r].Field<string>("Student_ID");
                student_name = SelectedStudentTbl.Rows[r].Field<string>("Student_Name");
                student_fid = SelectedStudentTbl.Rows[r].Field<int>("Student_Fingerprint_ID");

                string query = " INSERT INTO Attendence(Course_Code, Course_Teacher, Course_Teacher_Email, Student_ID, Student_Name, Semester, Class_No, Attendence_Status, Date, Student_Fingerprint_ID)" +
                                  "VALUES (@course_code, @teacher_name, @teacher_email, @student_id, @student_name, @semester, @classno, @attendence_state, @date, @student_fid) ";
                SqlCommand insertCommand = new SqlCommand(query);
                insertCommand.Parameters.AddWithValue("@course_code", course_code);
                insertCommand.Parameters.AddWithValue("@teacher_name", teacher_name);
                insertCommand.Parameters.AddWithValue("@teacher_email", teacher_email);
                insertCommand.Parameters.AddWithValue("@student_id", student_id);
                insertCommand.Parameters.AddWithValue("@student_name", student_name);
                insertCommand.Parameters.AddWithValue("@semester", semester);
                insertCommand.Parameters.AddWithValue("@classno", classno);
                insertCommand.Parameters.AddWithValue("@attendence_state", attendence_state);
                insertCommand.Parameters.AddWithValue("@date", date);
                insertCommand.Parameters.AddWithValue("@student_fid", student_fid);

                int row = dbAccess.executeQuery(insertCommand);
                dbAccess.closeConn();
                if (row == 1)
                    {
                    //MessageBox.Show("Attendence Row Added!!!"); 
                    }
                }

            }

        void AttendenceChackTable(string fid)
            {
            string attendence = "Present";
            string query = " UPDATE Attendence SET Attendence_Status = @attendence  WHERE Student_Fingerprint_ID = @fid ";
            SqlCommand updateCommand = new SqlCommand(query);
            updateCommand.Parameters.AddWithValue("@attendence", attendence);
            updateCommand.Parameters.AddWithValue("@fid", fid);
            int row = dbAccess.executeQuery(updateCommand);
            dbAccess.closeConn();
            if (row >= 1) 
                {
                string student_id = null;
                for (int r = 0; r < SelectedStudentTbl.Rows.Count; r++)
                    {
                    if (SelectedStudentTbl.Rows[r].Field<int>("Student_Fingerprint_ID") == Convert.ToInt32(fid))
                        {
                        student_id = SelectedStudentTbl.Rows[r].Field<string>("Student_ID");
                        break;
                        }
                    }
                    MessageBox.Show("Student ID "+student_id + " Present!!!"); 
                }
            else { MessageBox.Show("Fingerprint ID"+fid + "does not contain any student."); }
            }


        int selectedStudent(string semester)
            {
            int noOfRows = 0;
            try
                {
                SelectedStudentTbl.Clear();
                string query = " SELECT Student_ID, Student_Name, Student_Reg, Student_Session, Student_Fingerprint_ID FROM Student  WHERE Student_Semester = '" + semester + "'  ";
                dbAccess.readDatathroughAdapter(query, SelectedStudentTbl);
                noOfRows = SelectedStudentTbl.Rows.Count;
                if (noOfRows > 0)
                    {
                    //MessageBox.Show(noOfRows+ " Student data found");
                    }
                else
                    {
                    MessageBox.Show("No Student data found");
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            return noOfRows;
            }

        void selectedTeacher(string user)
            {
            try
                {
                string query = " SELECT Teacher_Name, Teacher_Department, Teacher_Email, Teacher_Faculty FROM Teacher WHERE Teacher_Name = '" + user + "'  ";
                dbAccess.readDatathroughAdapter(query, SelectedTeacherTbl);
                if (SelectedTeacherTbl.Rows.Count == 1)
                    {
                    //MessageBox.Show("One Teacher data found");
                    }
                else
                    {
                    MessageBox.Show("No Teacher data found");
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        /*
        bool SerialPortCon(string port)
            {
            try
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
            catch
                {        
                MessageBox.Show("Arduino and Fingerprint Module are not connected.\nPlease Connect");
                return false;
                }
      
            }

        */



        /*
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
            try
                {
                string mydata = "";
                mydata = serialPort1.ReadExisting();
                if (TextBoxFingerPrintID.InvokeRequired)
                    {
                    //textBoxStudent.Invoke((MethodInvoker)() => textBoxStudent.Text += mydata);
                    TextBoxFingerPrintID.Invoke((MethodInvoker)delegate { TextBoxFingerPrintID.Text += mydata; });
                    //textBoxStudent.Invoke(new MethodInvoker(delegate { textBoxStudent.Text += mydata; }));
                    }
                else
                    {
                    TextBoxFingerPrintID.Text += mydata;
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }
        */

        private void fingerIDtimer_Tick(object sender, EventArgs e)
            {
            check();
            //TextBoxFingerPrintID.Text = "";
            SerialCommunication.textboxserialmonitor.Text = "";
            lblCountPresent.Text = totalPresent("Present").ToString();
            }
        
        void check()
            {

            if (state)
                {

                int noOfRow = SelectedStudentTbl.Rows.Count;
                for (int i = 0; i < noOfRow; i++)
                    {
                    string rowFID = SelectedStudentTbl.Rows[i].Field<int>("Student_Fingerprint_ID").ToString();
                    try
                        {
                        if (SerialCommunication.textboxserialmonitor.Text.Trim().Equals(rowFID))
                            {
                            fingerID = rowFID;
                            checkBoxID.Checked = true;
                            checkBoxID.Text = fingerID + " Present";
                            SerialCommunication.textboxserialmonitor.Text = "";
                            break;
                            }
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show(ex.Message);
                        }
                    }
                }

            /*
            int noOfRow = SelectedStudentTbl.Rows.Count;
            for (int i = 0; i < noOfRow; i++)
                {
                int rowFID = SelectedStudentTbl.Rows[i].Field<int>("Student_Fingerprint_ID");
                try
                    {
                    if (Convert.ToInt32(TextBoxFingerPrintID.Text.Trim()) == rowFID)
                        {
                        fingerID = rowFID;
                        checkBoxID.Checked = true;
                        checkBoxID.Text = fingerID + " Present";
                        TextBoxFingerPrintID.Text = "";
                        }
                    }
                catch(Exception ex) 
                    {
                    MessageBox.Show(ex.Message);
                    }
                }
            }

          */
            //string rowFID = SelectedStudentTbl.Rows[i].Field<int>("Student_Fingerprint_ID").ToString();
            //rowFID = rowFID.Trim();

            // if (Convert.ToBoolean(TextBoxFingerPrintID.Text.IndexOf(rowID)+1 & Convert.ToInt32(check1 == 0)))
            /*if (Convert.ToBoolean(TextBoxFingerPrintID.Text.IndexOf(rowFID)+1 ))
                {
                fingerID = rowFID;
                checkBoxID.Checked = true;
                checkBoxID.Text = fingerID + " Present";
                //check1 = 0;
                TextBoxFingerPrintID.Text = "";
                }
            */

            /*
             //int check1 = 0;
            if (Convert.ToBoolean(TextBoxFingerPrintID.Text.IndexOf("1702028")+1 & Convert.ToInt32(check1 == 0)))
                {
                ID = "1702028";
                checkBoxID.Checked = true;
                checkBoxID.Text =TextBoxFingerPrintID.Text + " Present";
                check1 = 0;
                //TextBoxFingerPrintID.Text = "";
                }

            if (Convert.ToBoolean(TextBoxFingerPrintID.Text.IndexOf("1702009") + 1 & Convert.ToInt32(check1 == 0)))
                {
                ID = "1702009";
                checkBoxID.Checked = true;
                checkBoxID.Text =TextBoxFingerPrintID.Text+ " Present";
                check1 = 0;
                //TextBoxFingerPrintID.Text = "";
                }
            */
            }

        private void checkBoxID_CheckedChanged(object sender, EventArgs e)
            {
            if (checkBoxID.Checked == true)
                {
                AttendenceChackTable(fingerID);
                }
            checkBoxID.Checked = false;
            }

        /*
        public static void uploadSketchFileEnroll()
            {
            try
                {
                var uploader = new ArduinoSketchUploader(new ArduinoSketchUploaderOptions()
                    {
                    FileName = @"C:\Users\HP 840 G1\Documents\Visual Studio 2019\Projects\Biometric Attendence System\Biometric_Attendence_FMatch.ino.hex",
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

        int totalPresent(string attend)
            {
            DataTable presentTbl = new DataTable();
            string query = " SELECT DISTINCT Student_ID from Attendence WHERE Attendence_Status = '" + attend + "' AND Course_Teacher = '" + LogedInTeacher +
                    "' AND Semester = '" + SelectedSemester + "' AND Course_Code = '" + SelectedCourseCode + "' AND [Date] = '" + date + "' ";

            dbAccess.readDatathroughAdapter(query, presentTbl);
            return presentTbl.Rows.Count;
            }


        private void StartTButton_MouseHover(object sender, EventArgs e)
            {
            if (StartTButton.Text == "Stop")
                {
                StartTButton.BackColor = Color.Red;
                StartTButton.ForeColor = Color.Black;
                }
            else
                {
                StartTButton.BackColor = Color.Lime;
                StartTButton.ForeColor = Color.Black;
                }
            }

        private void StartTButton_MouseLeave(object sender, EventArgs e)
            {
            if (StartTButton.Text == "Stop")
                {
                StartTButton.BackColor = Color.Black;
                StartTButton.ForeColor = Color.Red;
                }
            else
                {
                StartTButton.BackColor = Color.Black;
                StartTButton.ForeColor = Color.Lime;
                }
           
            }

        private void ViewButton_MouseHover(object sender, EventArgs e)
            {
            ViewButton.BackColor = Color.DarkTurquoise;
            ViewButton.ForeColor = Color.Black;
            }

        private void ViewButton_MouseLeave(object sender, EventArgs e)
            {
            ViewButton.BackColor = Color.Black;
            ViewButton.ForeColor = Color.DarkTurquoise;
            }
        private void PauseButton_MouseHover(object sender, EventArgs e)
            {
            if(PauseButton.Text == "Resume")
                {          
                PauseButton.BackColor = Color.GreenYellow;
                PauseButton.ForeColor = Color.Black;
                }
            else
                {
                PauseButton.BackColor = Color.DarkOrange;
                PauseButton.ForeColor = Color.Black;
                }
            
            }

        private void PauseButton_MouseLeave(object sender, EventArgs e)
            {
            if (PauseButton.Text == "Resume")
                {
                PauseButton.BackColor = Color.Black;
                PauseButton.ForeColor = Color.GreenYellow;
                }
            else
                {
                PauseButton.BackColor = Color.Black;
                PauseButton.ForeColor = Color.DarkOrange;
                }
            
            }
        private void StuPanelButton_MouseHover(object sender, EventArgs e)
            {
            StuPanelButton.BackColor = Color.Yellow;
            StuPanelButton.ForeColor = Color.Black;
            }

        private void StuPanelButton_MouseLeave(object sender, EventArgs e)
            {
            StuPanelButton.BackColor = Color.Black;
            StuPanelButton.ForeColor = Color.Yellow;
            }

        private void LblSemCCodeSelect_Click(object sender, EventArgs e)
            {
            this.ActiveControl = comboBoxSemester;
            }

        private void LblSemCCodeSelect_MouseHover(object sender, EventArgs e)
            {
            LblSemCCodeSelect.ForeColor = Color.Green;
            }

        private void LblSemCCodeSelect_MouseLeave(object sender, EventArgs e)
            {
            LblSemCCodeSelect.ForeColor = Color.Orange;
            }


        private void TeachersPanel_FormClosing(object sender, FormClosingEventArgs e)
            {
            Application.Exit();
            }
        }
    }