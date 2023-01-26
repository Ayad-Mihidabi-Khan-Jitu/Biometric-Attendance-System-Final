using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;

namespace Biometric_Attendence_System
    {
    //public delegate void SaveAsExDele(string p, string n);
    public partial class AttendenceDetails : Form
        {       
        DB dbAccess = new DB();
        DataTable AttendenceSheetTbl = new DataTable();
        DataTable SelectedStudentTbl = new DataTable();

        ExcelCreator excelCreator = new ExcelCreator();
        MailCreator mail = new MailCreator();

        string teacher_name = Login.username;
        string current_semester = TeachersPanel.SelectedSemester;
        string current_course_code = TeachersPanel.SelectedCourseCode;
        string current_date = TeachersPanel.date;
        string attendence_status;
        
        string main_sheet_header = "Attendence_" +TeachersPanel.SelectedCourseCode;
        string sub_sheet_header = "Date_" + TeachersPanel.date;
        string filedirectory;

        //string sender_email = "amkhanshadhin@gmail.com";
        //string recipient_email_me = "jitu15@cse.pstu.ac.bd";
        string recipient_email_me = TeachersPanel.SelectedTeacherEmail;
        string email_subject = "Attendance " + TeachersPanel.SelectedCourseCode + "_" + TeachersPanel.date;
        string email_body = "Attendance Report<br>------------------------------" + "<br>Course Code " + TeachersPanel.SelectedCourseCode + "<br>Date " 
                                                + TeachersPanel.date + "<br>";
        string attachment_filename = "Attendance_" + TeachersPanel.SelectedCourseCode + "_" + "Date_" + TeachersPanel.date+".xlsx";
        string student_id;
        public AttendenceDetails()
            {
            InitializeComponent();
            }

        ///Methods in this FORM

        private void SendtoAnother_Click(object sender, EventArgs e)
            {
            string recipient_email_to_other = TextBoxMail.Text.ToLower().Trim();
            string filepath = filedirectory;
            string filename = main_sheet_header + "_" + sub_sheet_header + ".xlsx";
            //email_subject = mail.emailSubject + email_subject;
            //email_body = mail.email_body_header + email_body+mail.email_body_footer+mail.soft_detail;
            string subject = mail.emailSubject + email_subject;
            string body = mail.email_body_header + email_body+mail.email_body_footer+mail.soft_detail;
            try
                {
                string backcolor_cell = "#F0FFFF";
                var textcolor = System.Drawing.Color.DarkBlue;

                MemoryStream attachment = new MemoryStream();
                excelCreator.DataTableToExcel(AttendenceSheetTbl, current_course_code, main_sheet_header, sub_sheet_header);
                excelCreator.FormattingExcelCells(ExcelCreator.excelCellrange, backcolor_cell, textcolor, true);
                //excelCreator.excelSaveAs(filepath, filename);
                
                ///To show the excelCreator.excelSaveAs(filepath, filename); 
                Action<string, string> SaveAsEx = excelCreator.excelSaveAs;
                LoadingForm loadingForm = new LoadingForm();
                loadingForm.SaveAsProgessbar(SaveAsEx, filepath, filename);
                loadingForm.ShowDialog();
                ///To show the excelCreator.excelSaveAs(filepath, filename);

                attachment = excelCreator.ReadingFileIntoMemoryStream(filepath, filename);
                mail.SendEmail(mail.defalultSender, recipient_email_to_other, subject, body, attachment, attachment_filename);
                attachment.Close();
                attachment.Dispose();
                excelCreator.ProcessTermination();
                excelCreator.ReleaseAllComObjects();
                MessageBox.Show("Attendance Sheet Emailed Successfully to\n" + recipient_email_to_other);
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }      

            }

        private void SendMeButton_Click(object sender, EventArgs e)
            {
            string filepath = filedirectory;
            string filename = main_sheet_header + "_" + sub_sheet_header + ".xlsx";
            //email_subject = mail.emailSubject + email_subject;
            //email_body = mail.email_body_header + email_body+mail.email_body_footer+mail.soft_detail;
            string subject = mail.emailSubject + email_subject;
            string body = mail.email_body_header + email_body + mail.email_body_footer + mail.soft_detail;
            try
                {
                string backcolor_cell = "#F0FFFF";
                var textcolor = System.Drawing.Color.DarkBlue;

                MemoryStream attachment = new MemoryStream();
                excelCreator.DataTableToExcel(AttendenceSheetTbl, current_course_code, main_sheet_header, sub_sheet_header);
                excelCreator.FormattingExcelCells(ExcelCreator.excelCellrange, backcolor_cell, textcolor, true);
                //excelCreator.excelSaveAs(filepath, filename);

                ///To show the excelCreator.excelSaveAs(filepath, filename); 
                Action<string, string> SaveAsEx = excelCreator.excelSaveAs;
                LoadingForm loadingForm = new LoadingForm();
                loadingForm.SaveAsProgessbar(SaveAsEx, filepath, filename);
                loadingForm.ShowDialog();
                ///To show the excelCreator.excelSaveAs(filepath, filename);

                attachment = excelCreator.ReadingFileIntoMemoryStream(filepath, filename);   
                excelCreator.ProcessTermination();

                mail.SendEmail(mail.defalultSender, recipient_email_me, subject, body, attachment, attachment_filename);
                attachment.Close();
                attachment.Dispose();
                excelCreator.ReleaseAllComObjects();

                MessageBox.Show("Attendance Sheet Emailed Successfully to\n" + recipient_email_me);
                }
            catch(Exception ex)
                {
                MessageBox.Show(ex.Message);
                }

            }

        private void buttonPrint_Click(object sender, EventArgs e)
            {

            LocationLbl.Visible = true;

            string backcolor_cell = "#F0FFFF";
            var textcolor = System.Drawing.Color.DarkBlue;

            string filepath = filedirectory;
            string filename = main_sheet_header + "_" + sub_sheet_header + ".xlsx";
            excelCreator.DataTableToExcel(AttendenceSheetTbl, current_course_code, main_sheet_header, sub_sheet_header);
            excelCreator.FormattingExcelCells(ExcelCreator.excelCellrange, backcolor_cell, textcolor, true);

            try
                {
                saveFileAs.FileName = filename;
                saveFileAs.InitialDirectory = filedirectory;
                if (saveFileAs.ShowDialog() == DialogResult.OK)
                    {
                    string currentPath = saveFileAs.FileName;
                    excelCreator.excelSaveFileAs(currentPath);
                    }
                }
            catch(Exception ex)
                {
                MessageBox.Show(ex.ToString());
                }

            excelCreator.ProcessTermination();
            excelCreator.ReleaseAllComObjects();

            /*
            ///This saved file in a specific file path
            LocationLbl.Visible = true;

            string backcolor_cell = "#F0FFFF";
            var textcolor = System.Drawing.Color.DarkBlue;

            string filepath = filedirectory;
            string filename = main_sheet_header + "_" + sub_sheet_header + ".xlsx";
            excelCreator.DataTableToExcel(AttendenceSheetTbl, current_course_code, main_sheet_header, sub_sheet_header);
            excelCreator.FormattingExcelCells(ExcelCreator.excelCellrange, backcolor_cell, textcolor, true);
            //excelCreator.excelSaveAs(filepath, filename);

            ///To show the excelCreator.excelSaveAs(filepath, filename); 
            Action<string,string> SaveAsEx = excelCreator.excelSaveAs;
            LoadingForm loadingForm = new LoadingForm();
            loadingForm.SaveAsProgessbar(SaveAsEx, filepath, filename);
            loadingForm.ShowDialog();
            ///To show the excelCreator.excelSaveAs(filepath, filename);

            excelCreator.ProcessTermination();
            excelCreator.ReleaseAllComObjects();

            */

            /*
            ///This button successfully save the file as name. this is taken from Comment to Attandence
            private void button7_Click(object sender, EventArgs e)
            {

            sheetname = textBox3.Text;
            string filename = sheetname +"Lecture No. "+ textBox4.Text+ "_Attendance_" + date;
            saveFileDialog1.FileName = filename;
            saveFileDialog1.InitialDirectory = initialDirectory;

                try
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                        string backcolor_cell = "#F0FFFF";
                        var textcolor = System.Drawing.Color.DarkBlue;

                        currentDirectory = saveFileDialog1.FileName;

                        excelCreator.DataTableToExcel(StudentTbl, sheetname, sheetname + " Attendance", date);
                        excelCreator.FormattingExcelCells(ExcelCreator.excelCellrange, backcolor_cell, textcolor, true);
                        //excelCreator.excelSaveAs(filepath, filename);
                        excelCreator.excelSaveAsFile(currentDirectory);

                        excelCreator.ProcessTermination();
                        excelCreator.ReleaseAllComObjects();

                        isPrintedwhole = true;
                        button6.Enabled = isPrintedwhole;
                    }
                }
            catch 
                {
                MessageBox.Show("Course Code/Lecture No. is not given");
                }
            } 
            */

            }

        ///Events in this FORM
        private void AttendenceDetails_Load(object sender, EventArgs e)
            {
            LblSemester.Text = current_semester;
            LblCourseCode.Text = current_course_code;
            LblDate.Text = current_date;
            filedirectory = Directory.GetCurrentDirectory();
            
            AllAttendenceStatusTbl();
            dataGridStudentAttendence.DataSource = AttendenceSheetTbl;
            ComboAtten.SelectedIndex = 0;

            LocationLbl.Visible = false;

            LocationLbl.Text = "Show Location";
            Lbldirectory.Visible = false;
            }
        private void ComboAtten_SelectedIndexChanged(object sender, EventArgs e)
            {

            //dataGridStudentAttendence.Columns.Clear();
            //dataGridStudentAttendence.Rows.Clear();
            //dataGridStudentAttendence.DataSource = null;
            //dataGridStudentAttendence.Refresh();

            AttendenceSheetTblRefresh();

            attendence_status = ComboAtten.SelectedItem.ToString();
            if(attendence_status == "All")
                {
                AllAttendenceStatusTbl();
                }
            else
                {
                AttendenceStatusTbl(attendence_status);
                dataGridStudentAttendence.DataSource = AttendenceSheetTbl;
                }
            
            }


        ///Functions in this FORM
        void AttendenceStatusTbl(string attend)
            {
            try
                {
                //AttendenceSheetTbl.Clear();
                string query = " SELECT DISTINCT Student_ID, Student_Name, Semester, Class_No, Attendence_Status, [Date] from Attendence WHERE Attendence_Status = '"+ attend+"' AND Course_Teacher = '" + teacher_name +
                    "' AND Semester = '" + current_semester + "' AND Course_Code = '" + current_course_code + "' AND [Date] = '" + current_date + "' ";

                dbAccess.readDatathroughAdapter(query, AttendenceSheetTbl);
                
                //if (AttendenceSheetTbl.Rows.Count >= 1)

                }
            catch(Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            
            }

        void AllAttendenceStatusTbl()
            {
            try
                {
                //AttendenceSheetTbl.Clear();
                string query = " SELECT DISTINCT Student_ID, Student_Name, Semester, Class_No, Attendence_Status, [Date] from Attendence WHERE Course_Teacher = '" + teacher_name +
                    "' AND Semester = '" + current_semester + "' AND Course_Code = '" + current_course_code + "' AND [Date] = '"+current_date+ "' ";

                dbAccess.readDatathroughAdapter(query, AttendenceSheetTbl);
                dbAccess.closeConn();

                //if (AttendenceSheetTbl.Rows.Count >= 1)

                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }

            }

        bool showstate = false;
        private void LocationLbl_Click(object sender, EventArgs e)
            {
            if (showstate)
                {
                LocationLbl.Text = "Show Location";
                Lbldirectory.Visible = false;
                showstate = !showstate;
                }
            else
                {
                Lbldirectory.Visible = true;
                Lbldirectory.Text = filedirectory;
                LocationLbl.Text = "Hide";
                showstate = !showstate;
                }

            }
      
        private void dataGridStudentAttendence_CellClick(object sender, DataGridViewCellEventArgs e)
            {   
              if (e.RowIndex >= 0)
                  {
                   DataGridViewRow row = dataGridStudentAttendence.Rows[e.RowIndex];
                   student_id = row.Cells[0].Value.ToString();
                   IDLbl.Text = student_id;
                   selected_student();

                    StudentNameLbl.Text = SelectedStudentTbl.Rows[0].Field<string>("Student_Name");
                    IDLbl.Text = "ID: " + student_id;
                    RegisLbl.Text = "Reg. " + SelectedStudentTbl.Rows[0].Field<string>("Student_Reg");
                    SemesterLbl.Text = SelectedStudentTbl.Rows[0].Field<string>("Student_Semester");
                    SessionLbl.Text = "Session: " + SelectedStudentTbl.Rows[0].Field<string>("Student_Session");
                    mobileLbl.Text = "Email: " + SelectedStudentTbl.Rows[0].Field<string>("Student_Email");

                    MemoryStream ms = new MemoryStream(SelectedStudentTbl.Rows[0].Field<byte[]>("Student_Photo"));
                    pictureBoxStudent.Image = new Bitmap(ms);
                }
                          
            }

       void selected_student()
            {
            refreshSelectedStudentTbl();
            string query = "SELECT Student_Name, Student_Reg, Student_Semester, Student_Session, Student_Email, Student_Photo FROM Student" +
                                         " WHERE Student_ID='"+student_id+"' ";
            
            dbAccess.readDatathroughAdapter(query, SelectedStudentTbl);
            dbAccess.closeConn();
            }

        void AttendenceSheetTblRefresh()
            {
            AttendenceSheetTbl.Columns.Clear();
            AttendenceSheetTbl.Rows.Clear();
            AttendenceSheetTbl.Clear();
            }

        void refreshSelectedStudentTbl()
            {
            SelectedStudentTbl.Columns.Clear();
            SelectedStudentTbl.Rows.Clear();
            SelectedStudentTbl.Clear();
            }




        private void SendMeButton_MouseLeave(object sender, EventArgs e)
            {
            SendMeButton.ForeColor = Color.DodgerBlue;
            SendMeButton.BackColor = Color.Black;
            }

        private void SendMeButton_MouseHover(object sender, EventArgs e)
            {
            SendMeButton.ForeColor = Color.Black;
            SendMeButton.BackColor = Color.DodgerBlue;
            }

        private void SendtoAnother_MouseLeave(object sender, EventArgs e)
            {
            SendtoAnother.ForeColor = Color.SpringGreen;
            SendtoAnother.BackColor = Color.Black;
            }

        private void SendtoAnother_MouseHover(object sender, EventArgs e)
            {
            SendtoAnother.ForeColor = Color.Black;
            SendtoAnother.BackColor = Color.SpringGreen;
            }

        private void buttonPrint_MouseLeave(object sender, EventArgs e)
            {
            buttonPrint.ForeColor = Color.Cyan;
            buttonPrint.BackColor = Color.Black;
            }

        private void buttonPrint_MouseHover(object sender, EventArgs e)
            {
            buttonPrint.ForeColor = Color.Black;
            buttonPrint.BackColor = Color.Cyan;
            }


        private void LocationLbl_MouseLeave(object sender, EventArgs e)
            {
            LocationLbl.ForeColor = Color.Black;
            }

        private void LocationLbl_MouseHover(object sender, EventArgs e)
            {
            LocationLbl.ForeColor = Color.Crimson;
            }



        /*
         void savedialog()
             {
             SaveFileDialog save = new SaveFileDialog();
             save.Title = "Save Excel as";
             save.Filter = "Excel Files (*.xlsx)|*.xlsx";
             if(save.ShowDialog() == DialogResult.OK)
                 {
                 StreamWriter streamWriter = new StreamWriter(File.Create(save.FileName));
                 //streamWriter.Write(excelCreator.excelToBinary());
                 streamWriter.Write(ExcelCreator.excelworkBook);              
                 streamWriter.Dispose();
              }
             }
         */

        /*
        private void Lbldirectory_Click(object sender, EventArgs e)
            {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog fileOpen = new OpenFileDialog())
                {
                fileOpen.Title = "Open Excel file";
                fileOpen.Filter = "Excel File (*.xlsx)| *.xlsx| All Filex (*.*)|*.*";
                fileOpen.InitialDirectory = filedirectory;
                if (fileOpen.ShowDialog() == DialogResult.OK)
                    {
                    //Get the path of specified file
                    filePath = fileOpen.FileName;
                    Process.Start(filePath);
                    //Read the contents of the file into a stream
                    //var fileStream = fileOpen.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                       // {
                        //fileContent = reader.ReadToEnd();
                        //}
                    }
                }
            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            }
        */


        }
    }
