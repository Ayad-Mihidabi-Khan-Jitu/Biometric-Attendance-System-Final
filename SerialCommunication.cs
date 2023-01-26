using ArduinoUploader;
using ArduinoUploader.Hardware;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biometric_Attendence_System
    {
    class SerialCommunication
        {
        private static string indata;
        public static string SerialPortNumber;

        public static SerialPort serialPort = new SerialPort();
        public static ManagementScope connectionScope = new ManagementScope();
        public static SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
        public static ManagementObjectSearcher  searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

        public static TextBox textboxserialmonitor = new TextBox();

        public static DataTable PortsTable;


        public void serialmoniproperty(int x, int y, int height, int width, string font, float fontsize, bool isMultiline, bool isVisible, bool isReadOnly)
            {
            SerialCommunication.textboxserialmonitor.Name = "textboxserialmonitor";
            SerialCommunication.textboxserialmonitor.Location = new System.Drawing.Point(x, y);
            SerialCommunication.textboxserialmonitor.Size = new System.Drawing.Size(width, height);
            SerialCommunication.textboxserialmonitor.Font = new System.Drawing.Font(font, fontsize);
            SerialCommunication.textboxserialmonitor.BackColor = System.Drawing.Color.Azure;
            SerialCommunication.textboxserialmonitor.ForeColor = System.Drawing.Color.Crimson;
            SerialCommunication.textboxserialmonitor.BringToFront();
            SerialCommunication.textboxserialmonitor.Multiline = isMultiline;
            SerialCommunication.textboxserialmonitor.Visible = isVisible;
            SerialCommunication.textboxserialmonitor.ReadOnly = isReadOnly;
            //resources.ApplyResources(SerialCommunication.textboxserialmonitor, "textboxserialmonitor");
            }


        public void SerialPort(string port)
            {
            serialPort.PortName = port;
            serialPort.BaudRate = 9600; // use same baud rate as used in Arduino
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;
            serialPort.DtrEnable = true; // chilo na
            serialPort.RtsEnable = true; // chilo na
            serialPort.Encoding = System.Text.Encoding.Default;       
            }
        public  void serialDataReceived()
            {
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            }

        public static bool serialPortOpen()
            {
            try
                {
                serialPort.Open();
                return true;
                }
            catch (Exception ex)
                {              
                MessageBox.Show(ex.Message);
                return false;
                }         
            }

        public static  bool serialPortClose()
            {
            try
                {
                serialPort.Close();
                return true;
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                return false;
                }     
            }

        public string DetectArduino()
            {
            try
                {
                foreach (ManagementObject item in searcher.Get())
                    {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();
                    //if (desc.Contains("Arduino Uno")) // for real arduino
                    if (desc.Contains("USB Serial Device"))
                        {
                        MessageBox.Show("Arduino details: " + desc + " on " + deviceId);
                        return deviceId;
                        }
                    }
                }
            catch (ManagementException e)
                {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
            return null;
            }

        public static DataTable SerialPortLists()
            {
            PortsTable = new DataTable();
            PortsTable.Columns.Add("SL", typeof(int));
            PortsTable.Columns.Add("Desc", typeof(string));
            PortsTable.Columns.Add("Port", typeof(string));
            PortsTable.Columns.Add("Desc_Port", typeof(string));
            int index=0;
            try
                {
                foreach (ManagementObject item in searcher.Get())
                    {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();
                    string desc_deviceId = desc + " -- " + deviceId;
                    PortsTable.Rows.Add(index++, desc, deviceId, desc_deviceId);
                    //MessageBox.Show("Arduino details: " + PortList[index]);
                   
                    }
                return PortsTable;
                }
            catch (ManagementException e)
                {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
            return null;
            }

        public static void refreshSerialPortLists()
            {
            PortsTable.Rows.Clear();
            PortsTable.Columns.Clear();
            PortsTable.Clear();
            SerialPortLists();
            }

        public static void uploadSketchFileEnroll()
            {
          //  try
            //    {
                //var hex = Biometric_Attendence_System.Properties.Resources.Biometric_Attendence_FEnroll_ino;
                //string [] hexFileContents = File.ReadAllLines(hex.ToString());
                var uploader = new ArduinoSketchUploader(new ArduinoSketchUploaderOptions()
                    {
                    FileName = @"C:\Users\HP 840 G1\Documents\Visual Studio 2019\Projects\Biometric Attendence System\Biometric_Attendence_FEnroll.ino.hex",
                    //FileName = hex.ToString(),
                    PortName = SerialCommunication.SerialPortNumber,
                    ArduinoModel = ArduinoModel.UnoR3
                    });
                uploader.UploadSketch();
               // }
           // catch (Exception ex)
              //  {
              //  MessageBox.Show(ex.Message);
               // }
            }
       public Action actionEnroll = uploadSketchFileEnroll;

        public static void uploadSketchFileFmatch()
            {
            //try
            //    {
                //var hex = Biometric_Attendence_System.Properties.Resources.Biometric_Attendence_FMatch_ino;
                var uploader = new ArduinoSketchUploader(new ArduinoSketchUploaderOptions()
                    {
                    FileName = @"C:\Users\HP 840 G1\Documents\Visual Studio 2019\Projects\Biometric Attendence System\Biometric_Attendence_FMatch.ino.hex",
                    //FileName = hex.ToString(),
                    PortName = SerialCommunication.SerialPortNumber,
                    ArduinoModel = ArduinoModel.UnoR3
                    });
                uploader.UploadSketch();
              //  }
           // catch (Exception ex)
             //   {
              //  MessageBox.Show(ex.Message);
               // }
            }
        public Action actionMatch = uploadSketchFileFmatch;

        public void dataWrite(TextBox textBox)
            {
            try
                {
                int id = Convert.ToInt32(textBox.Text.Trim());
                if (id >= 1 && id <= 127)
                    {
                    serialPort.WriteLine(id.ToString());
                    }
                else
                    {
                    MessageBox.Show("Fingerprint ID should be between 1-127");
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
            {
            try
                {
                indata = "";
                SerialPort sp = (SerialPort)sender;
                indata = sp.ReadExisting();

                if (textboxserialmonitor.InvokeRequired)
                    {
                    textboxserialmonitor.Invoke((MethodInvoker)delegate { textboxserialmonitor.AppendText(indata); });
                    }
                else
                    {
                    textboxserialmonitor.AppendText(indata);
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }


        }
    }
