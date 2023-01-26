using ArduinoUploader;
using ArduinoUploader.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biometric_Attendence_System
    {
    //public delegate void sketchwithProgessbarDele();
    public partial class LoadingForm : Form
        {
        
        public LoadingForm()
            {
            InitializeComponent();
            }
       
        private void LoadingForm_Load(object sender, EventArgs e)
            {
            //sketchwithProgessbar(sketchaction);
            //sketchwithProgessbar(deleSkaPro);
            //uploadSketchFileEnroll();
           // sketchwithProgessbar();
            }

        //public void sketchwithProgessbar(sketchwithProgessbarDele action)
        public void sketchwithProgessbar(Action action)
        //public void sketchwithProgessbar()
                {
                Thread backgroundThread = new Thread(
                    new ThreadStart(() =>
                              {
                                    action.Invoke();
                                    //uploadSketchFileEnroll();
                                    if (progressBar1.InvokeRequired)
                                        {
                                             progressBar1.Invoke( new Action(() =>
                                                    {
                                                        progressBar1.Value = 50;
                                                    }));

                                        }
                                    else
                                        {
                                            progressBar1.Value = 50;
                                        }

                                     if (this.InvokeRequired)
                                        {
                                        this.Invoke(new Action(() => this.Close()));
                                        }
                                       else
                                        {
                                        this.Close();
                                        }
                
                            }
                    ));
            backgroundThread.Start();
           }

        public void SaveAsProgessbar(Action<string,string> action,string p,string n)
            {
            Thread backgroundThread = new Thread(
                new ThreadStart(() =>
                {
                    action.Invoke(p,n);
                                      
                    if (this.InvokeRequired)
                        {
                        this.Invoke(new Action(() => this.Close()));
                        }
                    else
                        {
                        this.Close();
                        }
                }
                ));
            backgroundThread.Start();
            }


        /*   
       public void uploadSketchFileEnroll()
               {
               try
                   {
                   var uploader = new ArduinoSketchUploader(new ArduinoSketchUploaderOptions()
                       {
                      FileName = @"C:\Users\HP 840 G1\Documents\Visual Studio 2019\Projects\Biometric Attendence System\Biometric_Attendence_FEnroll.ino.hex",
                       //FileName = @"C:\Users\HP 840 G1\Documents\Visual Studio 2019\Projects\Biometric Attendence System\Biometric_Attendence_FMatch.ino.hex",
                       //PortName = StudentsPanel.arduinoPort,
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
           //Action sketchaction = uploadSketchFileEnroll;

           */



        /*
        
        private void button1_Click(object sender, EventArgs e)
            {
            backgroundWorker1.RunWorkerAsync();
            }

        private void button2_Click(object sender, EventArgs e)
            {
            backgroundWorker1.CancelAsync();
            }


        int i;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
           // for(int i =0;i <=100;i++)
              //  {
              //  if (backgroundWorker1.CancellationPending)
                 //   {
                 //   e.Cancel = true;
               //     }
           //     else
                //    {
                    //HeavyTask();
                    uploadSkachFileEnroll();
                    backgroundWorker1.ReportProgress(i);
                 //   }
             //   }
            }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
            progressBar1.Value = e.ProgressPercentage;
            }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
            if (e.Cancelled)
                {
                display("Work Cancelled");
                progressBar1.Value = 0;
                }
            else
                {
                display("Work done");
                }
            }
        void HeavyTask()
            {
            Thread.Sleep(100);
            }

        private void display(String text)
            {
            MessageBox.Show(text);
            }
        
        bool uploadSkachFileEnroll()
            {
            try
                {
                var uploader = new ArduinoSketchUploader(new ArduinoSketchUploaderOptions()
                    {
                    //FileName = @"C:\Users\HP 840 G1\Documents\Visual Studio 2019\Projects\Biometric Attendence System\Biometric_Attendence_FEnroll.ino.hex",
                    FileName = @"C:\Users\HP 840 G1\Documents\Visual Studio 2019\Projects\Biometric Attendence System\Biometric_Attendence_FMatch.ino.hex",
                    //PortName = StudentsPanel.arduinoPort,
                    PortName = "COM4",
                    ArduinoModel = ArduinoModel.UnoR3
                    });
                uploader.UploadSketch();
                //done = true;
                return true;
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                return false;
                }
            }

        */


        }
    }