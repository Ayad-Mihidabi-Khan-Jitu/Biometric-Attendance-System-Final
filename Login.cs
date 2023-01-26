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
    public partial class Login : Form
        {
        public static string username;
        public static string password;
        //public static bool FmatchSkachUpload;
        string fingerID;
        bool state;


        DB dbAccess = new DB();
        DataTable TeacherTbl = new DataTable();
        SerialCommunication serial = new SerialCommunication();

        public Login()
            {
            InitializeComponent();
            //SerialCommunication.serialPortClose();
            this.Controls.Add(SerialCommunication.textboxserialmonitor);
            serial.serialmoniproperty(45, 75, 10, 50, "HP Simplified", 11.0f, false, false,false);
            serial.serialDataReceived();
            }

       ///Methods in this form///
        private void LoginButton_Click(object sender, EventArgs e)
            {
            LoginValidation();
            }

        private void ClearButton_Click(object sender, EventArgs e)
            {
            UserName.Text = "";
            Password.Text = "";
            }
        private void AdminImg_Click(object sender, EventArgs e)
            {
            DialogResult d;
            d =  MessageBox.Show("Are you an ADMIN ", " Warning ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(d == DialogResult.Yes)
                {
                EnterAdminLoginFORM();
                }
            }

        private void ExitBtn_Click(object sender, EventArgs e)
            {
            Application.Exit();
            }


        ///Events in this form///

        ///1. Press Enter to perform Press "Login"
        private void Login_Load(object sender, EventArgs e)
            {
            ///Form load howar sathe sathei box guli te ja thakar dorkar ta assign kore dewar kotha shob guli form ei
            fillTeacherTbl();
            maskingPassword();

            if (SplashWithSketch.FmatchSkachUpload != true)
                {
                backgroundWorker1.RunWorkerAsync();
                SplashWithSketch.FmatchSkachUpload = true;
                }
            else
                {
                lblLoading.Visible = false;
                radioBtnFinger.Visible = true;
                SerialCommunication.serialPortOpen();
                }
           
            }

        ///2. Press Enter to perform Press "Login"
        private void Login_KeyPress(object sender, KeyPressEventArgs e)
            {
            if (e.KeyChar == (char)Keys.Enter)
                {
                LoginValidation();
                }
            }

        


        ///Functions of the forms///

        // 1.TeacherPanel Form 
        void EnterTeachersPanelFORM()
            {
            timerFingerprint.Stop();
            SerialCommunication.serialPortClose();
            //this.Close();
            this.Hide();
            TeachersPanel teachersPanel = new TeachersPanel();
            teachersPanel.Show();
            }

        // 2.TeacherPanel Form 
        void EnterAdminLoginFORM()
            {
            timerFingerprint.Stop();
            SerialCommunication.serialPortClose();
            this.Hide();
            AdminLogin adminlogin = new AdminLogin();
            adminlogin.Show();
            }

        //3. LoginValidation
        void LoginValidation()
            {
             username = UserName.Text.Trim();
             password = Password.Text.Trim();

            if (username == "" || password == "") MessageBox.Show("Fields can not be Empty!");
            else
                {
                refreshTeacherTbl();
                string query = "  Select * from Teacher Where Teacher_Name = '"+  username  + "' AND Password = '"+ password + "'  ";
                dbAccess.readDatathroughAdapter(query, TeacherTbl);
                dbAccess.closeConn();
                
                if (TeacherTbl.Rows.Count == 1)
                    { EnterTeachersPanelFORM(); }
                else{ MessageBox.Show("Username or Password Incorrect", "Error"); }
                }


            }

        void fillTeacherTbl()
            {
            string query = "  Select * from Teacher ";
            dbAccess.readDatathroughAdapter(query, TeacherTbl);
            dbAccess.closeConn();
            }


        void maskingPassword()
            {
            Password.PasswordChar = '*';
            }

        private void checkBoxPasshow_CheckedChanged(object sender, EventArgs e)
            {
            Password.PasswordChar = checkBoxPasshow.Checked ? '\0' : '*';
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

        void IsEnabledUsernamePassword(bool e)
            {
            UserName.Enabled = e;
            Password.Enabled = e;
            checkBoxPasshow.Enabled = e;
            }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                serial.actionMatch();               
            }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
            if (lblLoading.InvokeRequired)
                {
                lblLoading.BeginInvoke(new Action(() => lblLoading.Visible = false));
                }
            else
                {
                lblLoading.Visible = false;
                }

            radioBtnFinger.Visible = true;
            SerialCommunication.serialPortClose();
            serial.SerialPort(SerialCommunication.SerialPortNumber);
            SerialCommunication.serialPortOpen();
            }


        private void timerFingerprint_Tick(object sender, EventArgs e)
            {
            //MessageBox.Show(TeacherTbl.Rows[1].Field<int>("Teacher_Fingerprint_ID").ToString());
            check();
            SerialCommunication.textboxserialmonitor.Text = "";
            }

        void check()
            {

            if (state)
                {
                int noOfRow = TeacherTbl.Rows.Count;
                //MessageBox.Show(noOfRow.ToString());
                for (int i =0; i < noOfRow; i++)
                    {
                    string rowFID = TeacherTbl.Rows[i].Field<int>("Teacher_Fingerprint_ID").ToString();
                    //string rowFID = "";
                    //MessageBox.Show(rowFID);
                    //MessageBox.Show(SerialCommunication.textboxserialmonitor.Text.Trim());
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
                string query = "  Select * from Teacher Where Teacher_Fingerprint_ID = '"+fid+"'  ";
                dbAccess.readDatathroughAdapter(query, TeacherTbl);
                dbAccess.closeConn();

                if (TeacherTbl.Rows.Count == 1)
                    {
                     username = TeacherTbl.Rows[0].Field<string>("Teacher_Name");
                     password = TeacherTbl.Rows[0].Field<string>("Password");
                     UserName.Text = username;
                     Password.Text = password;
                     MessageBox.Show("Login Successful!\nUsername: "+username,"Welcome");
                
                    EnterTeachersPanelFORM();
                    }
                else { MessageBox.Show("Fingerprint Doesn't Match.\nPlease Try Again", "Error"); }

            }

        private void checkBoxID_CheckedChanged(object sender, EventArgs e)
            {
            if (checkBoxID.Checked == true)
                {
                LoginChackTable(fingerID);
                }
            checkBoxID.Checked = false;
            }


        void refreshTeacherTbl()
            {
            TeacherTbl.Rows.Clear();
            TeacherTbl.Columns.Clear();
            TeacherTbl.Clear();
            }


            private void LoginButton_MouseLeave(object sender, EventArgs e)
            {
            LoginButton.ForeColor = Color.Lime;
            LoginButton.BackColor = Color.Black;
            }

        private void LoginButton_MouseHover(object sender, EventArgs e)
            {
            LoginButton.ForeColor = Color.Black;
            LoginButton.BackColor = Color.Lime;
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

        }
    }
