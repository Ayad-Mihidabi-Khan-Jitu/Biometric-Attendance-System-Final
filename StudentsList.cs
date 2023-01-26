using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biometric_Attendence_System
    {
    public partial class StudentsList : Form
        {
        DB dbAccess = new DB();
        public DataTable StudentTbl = new DataTable();
        public DataTable SemesterStudentTbl = new DataTable();
        string current_sem = TeachersPanel.SelectedSemester;

        string semester_status;

        public StudentsList()
            {
            InitializeComponent();
            }


        ///Events in this FORM
        private void StudentsList_Load(object sender, EventArgs e)
            {
            StudentTable();

            if(current_sem == null)
                {
                comboBoxStudent.SelectedIndex = 0;
                }
            else
                {
                comboBoxStudent.SelectedIndex = comboBoxStudent.FindString(current_sem);
                }

            // comboBoxStudent.SelectedIndex = 0;
            //comboBoxStudent.SelectedItem = comboBoxStudent.FindString(current_sem);
            }

        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
            {
            refreshSemesterStudentTbl();

            semester_status = comboBoxStudent.SelectedItem.ToString();
            if (semester_status == "All")
                {
                StudentTable();
                }
            else
                {
                SpecificSemesterStudentTbl(semester_status);
                dataGridStudents.DataSource = SemesterStudentTbl;
                fitImage();
                dataGridStudents.Columns["Student_Photo"].Width = 60;
                dataGridStudents.Columns["Serial"].Width = 45;
                dataGridStudents.Columns["Student_Reg"].Width = 75;
                dataGridStudents.Columns["Student_Name"].Width = 140;
                }
            
            }

        ///Functions in this FORM
        void EnterStudentsPanelFORM()
            {
            try
                {
                //this.Close();
                this.Hide();
                StudentsPanel studentsPanel = new StudentsPanel();
                studentsPanel.Show();
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        void EnterHomeFORM()
            {
            try
                {
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
        public  void StudentTable()
            {
            refreshStudentTbl();

            string query = " SELECT * FROM Student ";
            dbAccess.readDatathroughAdapter(query, StudentTbl);
            //dataGridStudents.Columns[7].AutoSizeMode.Equals(false);
            
            dataGridStudents.DataSource = StudentTbl;
            fitImage();
            dataGridStudents.Columns["Student_Photo"].Width = 50;
            dataGridStudents.Columns["Serial"].Width = 50;
            dataGridStudents.Columns["Student_Reg"].Width = 75;
            dataGridStudents.Columns["Student_Name"].Width = 140;

            //dataGridStudents.Columns[7].AutoSizeMode.Equals(false);

            //dataGridCourse.RowHeadersVisible = false;
            //this.dataGridCourse.DefaultCellStyle.Font = new Font("Tahoma", 10);
            }

        void SpecificSemesterStudentTbl(string semester)
            {
            try
                {
                string query = " SELECT * from Student WHERE Student_Semester = '" + semester + "'  ";
                dbAccess.readDatathroughAdapter(query, SemesterStudentTbl);
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        void fitImage()
            {
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridStudents.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }

        public void refreshSemesterStudentTbl()
            {
            SemesterStudentTbl.Columns.Clear();
            SemesterStudentTbl.Rows.Clear();
            SemesterStudentTbl.Clear();
            }
        public void refreshStudentTbl()
            {
            StudentTbl.Columns.Clear();
            StudentTbl.Rows.Clear();
            StudentTbl.Clear();
            }

        }
    }
