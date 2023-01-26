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
    public partial class TeachersList : Form
        {
        DB dbAccess = new DB();
        DataTable TeacherTbl = new DataTable();
        DataTable FacultyTbl = new DataTable();
        DataTable DepartmentTbl = new DataTable();

        public TeachersList()
            {
            InitializeComponent();
            }
        ///Methods in this FORM
        private void BackBtn_Click(object sender, EventArgs e)
            {
            EnterAdminPanelFORM();
            }
        private void HomeImg_Click(object sender, EventArgs e)
            {
            EnterHomeFORM();
            }

        ///Events in this FORM
        private void TeachersList_Load(object sender, EventArgs e)
            {
            
            ShowTeacherTbl("ALL");
            fillDepartment("ALL");
            fillFaculty();
            
            comboBoxFaculty.DataSource = FacultyTbl;
           
            comboBoxFaculty.DisplayMember = "Teacher_Faculty";
            comboBoxFaculty.SelectedIndex = -1;
            comboBoxFaculty.Text = "Faculty";
            
            comboBoxDepartment.DataSource = DepartmentTbl;
            comboBoxDepartment.DisplayMember = "Teacher_Department";
            comboBoxDepartment.Text = "Department";

            dataGridTeachers.DataSource = TeacherTbl;
            dataGridTeachers.DefaultCellStyle.Font = new Font("Tahoma", 11);

            fitImage();
            }

        private void comboBoxFaculty_SelectedIndexChanged(object sender, EventArgs e)
            {
            
            //SpecificDepartmentTbl = TeacherTbl.Select("Teacher_Faculty = " + FacultyTbl.Rows[comboBoxFaculty.SelectedIndex]["Teacher_Faculty"]).CopyToDataTable();
            //SpecificDepartmentTbl = TeacherTbl.Select("Teacher_Faculty IN ('BAM')").CopyToDataTable();
            refreshTeacherTbl();
            refreshDepartmentTbl();
            if (comboBoxFaculty.SelectedIndex != -1)
                {
                string facalty = FacultyTbl.Rows[comboBoxFaculty.SelectedIndex].Field<string>("Teacher_Faculty");
                fillDepartment(facalty);
                comboBoxDepartment.DataSource = DepartmentTbl;
                comboBoxDepartment.DisplayMember = "Teacher_Department";
                comboBoxDepartment.Text = "Department";

                ShowTeacherTbl(facalty);
                dataGridTeachers.DataSource = TeacherTbl;
                fitImage();
                }
            else
                {
                ShowTeacherTbl("ALL");
                dataGridTeachers.DataSource = TeacherTbl;
                fitImage();

                fillDepartment("ALL");
                comboBoxDepartment.DataSource = DepartmentTbl;
                comboBoxDepartment.DisplayMember = "Teacher_Department";
                }
               
            }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
            {
            
            if (comboBoxDepartment.SelectedIndex != -1)
                {
                refreshTeacherTbl();

                string depart = DepartmentTbl.Rows[comboBoxDepartment.SelectedIndex].Field<string>("Teacher_Department");
                //string depart = comboBoxDepartment.Text;
                DepartTeacherTbl(depart);
                dataGridTeachers.DataSource = TeacherTbl;
                fitImage();
                }
            }


        ///Functions in this FORM
        void EnterHomeFORM()
            {
            this.Hide();
            Login login = new Login();
            login.Show();
            }

        void EnterAdminPanelFORM()
            {
            this.Hide();
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            }

        void ShowTeacherTbl(string faculty)
            {
            if(faculty == "ALL")
                {
                string query = " SELECT Teacher_Name,Teacher_Department,Teacher_Faculty,Teacher_Email ,Teacher_Mobile,Teacher_Fingerprint_ID,Photo FROM Teacher ";
                dbAccess.readDatathroughAdapter(query, TeacherTbl);
                dbAccess.closeConn();
                }
            else
                {
                string query = "SELECT Teacher_Name,Teacher_Department,Teacher_Faculty,Teacher_Email ,Teacher_Mobile,Teacher_Fingerprint_ID,Photo FROM Teacher WHERE Teacher_Faculty = '" + faculty + "'";
                dbAccess.readDatathroughAdapter(query, TeacherTbl);
                dbAccess.closeConn();
                }
           
            }

        void DepartTeacherTbl(string depart)
            {
 
                string query = "SELECT Teacher_Name,Teacher_Department,Teacher_Faculty,Teacher_Email ,Teacher_Mobile,Teacher_Fingerprint_ID,Photo FROM Teacher WHERE Teacher_Department = '" + depart + "'";
                dbAccess.readDatathroughAdapter(query, TeacherTbl);
                dbAccess.closeConn();
                
            }

        void fillFaculty()
            {
            string query = "SELECT DISTINCT Teacher_Faculty FROM Teacher";
            //string query = "SELECT Teacher_Faculty, Teacher_Department having DISTINCT Teacher_Faculty FROM Teacher";
            dbAccess.readDatathroughAdapter(query, FacultyTbl);
            dbAccess.closeConn();
            }

        void fillDepartment(string faculty)
            {
            if(faculty == "ALL")
                {
                string query = "SELECT DISTINCT Teacher_Department FROM Teacher";
                dbAccess.readDatathroughAdapter(query, DepartmentTbl);
                dbAccess.closeConn();
                }
            else
                { 
                string query = "SELECT DISTINCT Teacher_Department FROM Teacher WHERE Teacher_Faculty = '" + faculty + "'";
                dbAccess.readDatathroughAdapter(query, DepartmentTbl);
                dbAccess.closeConn();
                }
            
            }

        void refreshDepartmentTbl()
            {
            DepartmentTbl.Columns.Clear();
            DepartmentTbl.Rows.Clear();
            DepartmentTbl.Clear();                
            }

        void refreshTeacherTbl()
            {
            TeacherTbl.Columns.Clear();
            TeacherTbl.Rows.Clear();
            TeacherTbl.Clear();
            }
        void fitImage()
            {
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridTeachers.Columns[6];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }

        }
    }
