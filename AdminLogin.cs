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
    public partial class AdminLogin : Form
        {
        public static string username;
        public static string password;
        string fingerID;
        bool state;

        DB dbAccess = new DB();
        DataTable TeacherTbl = new DataTable();
        SerialCommunication serial = new SerialCommunication();

        public AdminLogin()
            {
            InitializeComponent();
            this.Controls.Add(SerialCommunication.textboxserialmonitor);
            serial.serialmoniproperty(45, 75, 10, 50, "HP Simplified", 11.0f, false, false, false);
            serial.serialDataReceived();
            }

        ///Methods in this form///

        private void BackBtn_Click(object sender, EventArgs e)
            {
            EnterHomeFORM();
            }
        private void AdLoginButton_Click(object sender, EventArgs e)
            {
            LoginValidation();
            }

        private void ClearButton_Click(object sender, EventArgs e)
            {
            AdminName.Text = "";
            AdPassword.Text = "";
            }
        private void Close_Img_Click(object sender, EventArgs e)
            {
            Application.Exit();
            }

        ///Methods in this form///
        private void AdminLogin_Load(object sender, EventArgs e)
            {
            maskingPassword();
            fillTeacherTbl();
            if (SplashWithSketch.FmatchSkachUpload != true)
                {
                SplashWithSketch.FmatchSkachUpload = true;
                }
            else
                {
                radioBtnFinger.Visible = true;
                //serial.SerialPort("COM4");
                //SerialCommunication.serialPortOpen();
                }
            

            if (!SerialCommunication.serialPort.IsOpen)
                {
                serial.SerialPort(SerialCommunication.SerialPortNumber);
                SerialCommunication.serialPortOpen();
                } 


           
            }


        ///Functions of the forms///

        // 1.TeacherPanel Form 
        void EnterHomeFORM()
            {
            timerFingerprint.Stop();
            SerialCommunication.serialPortClose();
            this.Hide();
            Login login = new Login();
            login.Show();
            }

        // 2.TeacherPanel Form 
        void EnterAdminPanelFORM()
            {
            timerFingerprint.Stop();
            SerialCommunication.serialPortClose();
            this.Hide();
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            }

        //3. LoginValidation
        void LoginValidation()
            {
            username = AdminName.Text.Trim();
            password = AdPassword.Text.Trim();

            if (username == "" || password == "") MessageBox.Show("Fields can not be Empty!");
            else
                {
                refreshTeacherTbl();
                string query = "  Select * from Teacher WHERE Role = 'admin' AND Teacher_Name = '" + username + "' AND Password = '" + password + "'  ";
                dbAccess.readDatathroughAdapter(query, TeacherTbl);
                dbAccess.closeConn();

                if (TeacherTbl.Rows.Count == 1)
                    { EnterAdminPanelFORM(); }
                else { MessageBox.Show("Username or Password Incorrect", "Error"); }
                }
            }

            void maskingPassword()
                {
                AdPassword.PasswordChar = '*';
                }

        void fillTeacherTbl()
            {
            string query = "  Select * from Teacher WHERE Role = 'admin'  ";
            dbAccess.readDatathroughAdapter(query, TeacherTbl);
            dbAccess.closeConn();
            }

        private void checkBoxPasshow_CheckedChanged(object sender, EventArgs e)
            {
                AdPassword.PasswordChar = checkBoxPasshow.Checked ? '\0' : '*';
                if (checkBoxPasshow.Checked)
                    { checkBoxPasshow.ForeColor = Color.BlueViolet; }
                else { checkBoxPasshow.ForeColor = Color.Gray; }              
            }

        private void radioBtnPass_CheckedChanged(object sender, EventArgs e)
            {
            if (radioBtnPass.Checked)
                {
                SerialCommunication.serialPortClose();
                }
            }

        private void radioBtnFinger_CheckedChanged(object sender, EventArgs e)
            {
            if (radioBtnFinger.Checked)
                {
                IsEnabledUsernamePassword(false);
                state = true;
                }
            else
                {
                IsEnabledUsernamePassword(true);
                SerialCommunication.serialPortClose();
                }
            }

        private void timerFingerprint_Tick(object sender, EventArgs e)
            {
            check();
            SerialCommunication.textboxserialmonitor.Text = "";
            }

        void check()
            {

            if (state)
                {
                int noOfRow = TeacherTbl.Rows.Count;
                for (int i = 0; i < noOfRow; i++)
                    {
                    string rowFID = TeacherTbl.Rows[i].Field<int>("Teacher_Fingerprint_ID").ToString();
                    try
                        {
                        if (SerialCommunication.textboxserialmonitor.Text.Trim().Equals(rowFID))
                            {
                            fingerID = rowFID;
                            checkBoxID.Checked = true;
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

            }

        void LoginChackTable(string fid)
            {
            refreshTeacherTbl();
            string query = "  Select * from Teacher Where Role = 'admin' AND Teacher_Fingerprint_ID = '" + fid + "'  ";
            dbAccess.readDatathroughAdapter(query, TeacherTbl);
            dbAccess.closeConn();

            if (TeacherTbl.Rows.Count == 1)
                {
                username = TeacherTbl.Rows[0].Field<string>("Teacher_Name");
                password = TeacherTbl.Rows[0].Field<string>("Password");
                AdminName.Text = username;
                AdPassword.Text = password;
                MessageBox.Show("Login Successful!\nAdmin: " + username, "Welcome");

                EnterAdminPanelFORM();
                }
            else { MessageBox.Show("Fingerprint Doesn't Match.\nPlease Try Again", "Error"); }

            }


        void IsEnabledUsernamePassword(bool e)
            {
            AdminName.Enabled = e;
            AdPassword.Enabled = e;
            checkBoxPasshow.Enabled = e;
            }

        void refreshTeacherTbl()
            {
            TeacherTbl.Rows.Clear();
            TeacherTbl.Columns.Clear();
            TeacherTbl.Clear();
            }

        private void AdLoginButton_MouseLeave(object sender, EventArgs e)
            {
            AdLoginButton.ForeColor = Color.Lime;
            AdLoginButton.BackColor = Color.Black;
            }

        private void AdLoginButton_MouseHover(object sender, EventArgs e)
            {
            AdLoginButton.ForeColor = Color.Black;
            AdLoginButton.BackColor = Color.Lime;
            }

        private void ClearButton_MouseLeave(object sender, EventArgs e)
            {
            ClearButton.ForeColor = Color.Red;
            ClearButton.BackColor = Color.Black;
            }

        private void ClearButton_MouseHover(object sender, EventArgs e)
            {
            ClearButton.ForeColor = Color.Black;
            ClearButton.BackColor = Color.Red;
            }

        private void checkBoxID_CheckedChanged(object sender, EventArgs e)
            {
            if (checkBoxID.Checked == true)
                {
                LoginChackTable(fingerID);
                }
            checkBoxID.Checked = false;
            }

        }
    }
