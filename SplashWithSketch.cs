using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biometric_Attendence_System
    {
    public partial class SplashWithSketch : Form
        {
        public static bool FmatchSkachUpload;
        SerialCommunication serial = new SerialCommunication();
        DataTable Device_Port = SerialCommunication.SerialPortLists();

        public SplashWithSketch()
            {
            InitializeComponent();
            }

        private void SplashWithSketch_Load(object sender, EventArgs e)
            {
            comboBoxPorts.DataSource = Device_Port;
            comboBoxPorts.DisplayMember = "Desc_Port";
            //comboBoxPorts.SelectedIndex = -1;
            comboBoxPorts.Text = "Select Arduino COM Port";

            }

         void sketchwithProgessbar(Action action)
            {
            Thread backgroundThread = new Thread(
                new ThreadStart(() =>
                {
                    action.Invoke();

                    if (this.InvokeRequired)
                        {
                        this.Invoke(new Action(() => {
                            SerialCommunication.serialPortClose();
                            try 
                                {
                                serial.SerialPort(SerialCommunication.SerialPortNumber);
                                }
                            catch(Exception ex) 
                                {
                                MessageBox.Show(ex.ToString());
                                }
                           
                            //SerialCommunication.serialPortOpen();
                            FmatchSkachUpload = true; 
                            this.Hide(); 
                            Login login = new Login(); 
                            login.Show();  
                        }));
                        }
                    else
                        {
                        SerialCommunication.serialPortClose();
                        serial.SerialPort(SerialCommunication.SerialPortNumber);
                        //SerialCommunication.serialPortOpen();
                        FmatchSkachUpload = true;
                        this.Hide();
                        Login login = new Login();
                        login.Show();
                        }

                }
                ));
            backgroundThread.Start();
            }

        private void comboBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (comboBoxPorts.SelectedIndex != -1)
                {
                SerialCommunication.SerialPortNumber = Device_Port.Rows[comboBoxPorts.SelectedIndex]["Port"].ToString();
                //MessageBox.Show(SerialCommunication.SerialPortNumber);
                }
            
            }

        private void buttonSelect_Click(object sender, EventArgs e)
            {
            try
                {
                sketchwithProgessbar(serial.actionMatch);
                }
            catch (Exception ex) 
                {
                MessageBox.Show(ex.ToString());
                }
            }

        private void reFreshpictureBox_Click(object sender, EventArgs e)
            {
            SerialCommunication.refreshSerialPortLists();
            comboBoxPorts.DataSource = null;
            comboBoxPorts.Items.Clear();
            comboBoxPorts.DataSource = SerialCommunication.SerialPortLists();
            comboBoxPorts.SelectedIndex = -1;
            comboBoxPorts.DisplayMember = "Desc_Port";
            //comboBoxPorts.SelectedIndex = -1;
            comboBoxPorts.Text = "Select Arduino COM Port";
            }


        }
    }
