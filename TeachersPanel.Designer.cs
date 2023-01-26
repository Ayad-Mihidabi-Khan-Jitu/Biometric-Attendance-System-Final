namespace Biometric_Attendence_System
    {
    partial class TeachersPanel
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeachersPanel));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTeacherName = new System.Windows.Forms.Label();
            this.comboBoxSemester = new System.Windows.Forms.ComboBox();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.StartTButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.minlabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Timelabel = new System.Windows.Forms.Label();
            this.Seclabel = new System.Windows.Forms.Label();
            this.Datelabel = new System.Windows.Forms.Label();
            this.Daylabel = new System.Windows.Forms.Label();
            this.ViewButton = new System.Windows.Forms.Button();
            this.StuPanelButton = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblCountPresent = new System.Windows.Forms.Label();
            this.currenttimer = new System.Windows.Forms.Timer(this.components);
            this.AMPMlabel = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.stopwatchtimer = new System.Windows.Forms.Timer(this.components);
            this.PauseButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.duraTimeLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.duMin = new System.Windows.Forms.Label();
            this.duHr = new System.Windows.Forms.Label();
            this.LogOutImg = new System.Windows.Forms.PictureBox();
            this.dateTimPickr = new System.Windows.Forms.DateTimePicker();
            this.CourseCodeLbl = new System.Windows.Forms.Label();
            this.SemesterLbl = new System.Windows.Forms.Label();
            this.LblSemCCodeSelect = new System.Windows.Forms.Label();
            this.classNodomainUpDown = new System.Windows.Forms.DomainUpDown();
            this.checkBoxSemCcode = new System.Windows.Forms.CheckBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.fingerIDtimer = new System.Windows.Forms.Timer(this.components);
            this.checkBoxID = new System.Windows.Forms.CheckBox();
            this.paneClassDuration = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogOutImg)).BeginInit();
            this.paneClassDuration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HP Simplified", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(603, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to Biometric Attendence System";
            // 
            // labelTeacherName
            // 
            this.labelTeacherName.AutoSize = true;
            this.labelTeacherName.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeacherName.Location = new System.Drawing.Point(88, 83);
            this.labelTeacherName.Name = "labelTeacherName";
            this.labelTeacherName.Size = new System.Drawing.Size(111, 32);
            this.labelTeacherName.TabIndex = 2;
            this.labelTeacherName.Text = "Teacher";
            // 
            // comboBoxSemester
            // 
            this.comboBoxSemester.BackColor = System.Drawing.Color.Black;
            this.comboBoxSemester.Font = new System.Drawing.Font("HP Simplified", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSemester.ForeColor = System.Drawing.Color.White;
            this.comboBoxSemester.FormattingEnabled = true;
            this.comboBoxSemester.Location = new System.Drawing.Point(28, 211);
            this.comboBoxSemester.Name = "comboBoxSemester";
            this.comboBoxSemester.Size = new System.Drawing.Size(131, 29);
            this.comboBoxSemester.TabIndex = 3;
            this.comboBoxSemester.Text = "Seme";
            this.comboBoxSemester.SelectedIndexChanged += new System.EventHandler(this.comboBoxSemester_SelectedIndexChanged);
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.BackColor = System.Drawing.Color.Black;
            this.comboBoxCourse.Font = new System.Drawing.Font("HP Simplified", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCourse.ForeColor = System.Drawing.Color.White;
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(198, 211);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(131, 29);
            this.comboBoxCourse.TabIndex = 4;
            this.comboBoxCourse.Text = "C Code";
            this.comboBoxCourse.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourse_SelectedIndexChanged);
            // 
            // StartTButton
            // 
            this.StartTButton.BackColor = System.Drawing.Color.Black;
            this.StartTButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartTButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartTButton.Font = new System.Drawing.Font("HP Simplified", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTButton.ForeColor = System.Drawing.Color.Lime;
            this.StartTButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StartTButton.Location = new System.Drawing.Point(529, 282);
            this.StartTButton.Name = "StartTButton";
            this.StartTButton.Size = new System.Drawing.Size(119, 64);
            this.StartTButton.TabIndex = 5;
            this.StartTButton.Text = "Start";
            this.StartTButton.UseVisualStyleBackColor = false;
            this.StartTButton.Click += new System.EventHandler(this.StartTButton_Click);
            this.StartTButton.MouseLeave += new System.EventHandler(this.StartTButton_MouseLeave);
            this.StartTButton.MouseHover += new System.EventHandler(this.StartTButton_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Digital", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(886, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Time Elapsed";
            // 
            // minlabel
            // 
            this.minlabel.AutoSize = true;
            this.minlabel.Font = new System.Drawing.Font("Digital", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minlabel.ForeColor = System.Drawing.Color.White;
            this.minlabel.Image = ((System.Drawing.Image)(resources.GetObject("minlabel.Image")));
            this.minlabel.Location = new System.Drawing.Point(866, 317);
            this.minlabel.Name = "minlabel";
            this.minlabel.Size = new System.Drawing.Size(192, 42);
            this.minlabel.TabIndex = 9;
            this.minlabel.Text = "00:00:00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Digital", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.Location = new System.Drawing.Point(890, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "hr";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Digital", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(943, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "min";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Chartreuse;
            this.label9.Font = new System.Drawing.Font("HP Simplified", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(89, 545);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(193, 36);
            this.label9.TabIndex = 13;
            this.label9.Text = "Total Present ";
            // 
            // Timelabel
            // 
            this.Timelabel.AutoSize = true;
            this.Timelabel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Timelabel.Font = new System.Drawing.Font("DS-Digital", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timelabel.ForeColor = System.Drawing.Color.White;
            this.Timelabel.Image = ((System.Drawing.Image)(resources.GetObject("Timelabel.Image")));
            this.Timelabel.Location = new System.Drawing.Point(791, 25);
            this.Timelabel.Name = "Timelabel";
            this.Timelabel.Size = new System.Drawing.Size(216, 79);
            this.Timelabel.TabIndex = 15;
            this.Timelabel.Text = "00:00";
            // 
            // Seclabel
            // 
            this.Seclabel.AutoSize = true;
            this.Seclabel.BackColor = System.Drawing.Color.Transparent;
            this.Seclabel.Font = new System.Drawing.Font("DS-Digital", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seclabel.ForeColor = System.Drawing.Color.White;
            this.Seclabel.Image = ((System.Drawing.Image)(resources.GetObject("Seclabel.Image")));
            this.Seclabel.Location = new System.Drawing.Point(994, 65);
            this.Seclabel.Name = "Seclabel";
            this.Seclabel.Size = new System.Drawing.Size(43, 30);
            this.Seclabel.TabIndex = 16;
            this.Seclabel.Text = "00";
            // 
            // Datelabel
            // 
            this.Datelabel.AutoSize = true;
            this.Datelabel.BackColor = System.Drawing.Color.Transparent;
            this.Datelabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datelabel.ForeColor = System.Drawing.Color.White;
            this.Datelabel.Image = ((System.Drawing.Image)(resources.GetObject("Datelabel.Image")));
            this.Datelabel.Location = new System.Drawing.Point(915, 110);
            this.Datelabel.Name = "Datelabel";
            this.Datelabel.Size = new System.Drawing.Size(196, 24);
            this.Datelabel.TabIndex = 17;
            this.Datelabel.Text = "9 December, 2020";
            // 
            // Daylabel
            // 
            this.Daylabel.AutoSize = true;
            this.Daylabel.BackColor = System.Drawing.Color.Transparent;
            this.Daylabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Daylabel.ForeColor = System.Drawing.Color.White;
            this.Daylabel.Image = ((System.Drawing.Image)(resources.GetObject("Daylabel.Image")));
            this.Daylabel.Location = new System.Drawing.Point(784, 109);
            this.Daylabel.Name = "Daylabel";
            this.Daylabel.Size = new System.Drawing.Size(128, 24);
            this.Daylabel.TabIndex = 18;
            this.Daylabel.Text = "Wednesday";
            // 
            // ViewButton
            // 
            this.ViewButton.BackColor = System.Drawing.Color.Black;
            this.ViewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewButton.Font = new System.Drawing.Font("HP Simplified", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewButton.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.ViewButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ViewButton.Location = new System.Drawing.Point(499, 526);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(212, 61);
            this.ViewButton.TabIndex = 21;
            this.ViewButton.Text = "View Sheet";
            this.ViewButton.UseVisualStyleBackColor = false;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            this.ViewButton.MouseLeave += new System.EventHandler(this.ViewButton_MouseLeave);
            this.ViewButton.MouseHover += new System.EventHandler(this.ViewButton_MouseHover);
            // 
            // StuPanelButton
            // 
            this.StuPanelButton.BackColor = System.Drawing.Color.Black;
            this.StuPanelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StuPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StuPanelButton.Font = new System.Drawing.Font("HP Simplified", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StuPanelButton.ForeColor = System.Drawing.Color.Yellow;
            this.StuPanelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StuPanelButton.Location = new System.Drawing.Point(873, 526);
            this.StuPanelButton.Name = "StuPanelButton";
            this.StuPanelButton.Size = new System.Drawing.Size(261, 55);
            this.StuPanelButton.TabIndex = 22;
            this.StuPanelButton.Text = "Student Panel";
            this.StuPanelButton.UseVisualStyleBackColor = false;
            this.StuPanelButton.Click += new System.EventHandler(this.StuPanelButton_Click);
            this.StuPanelButton.MouseLeave += new System.EventHandler(this.StuPanelButton_MouseLeave);
            this.StuPanelButton.MouseHover += new System.EventHandler(this.StuPanelButton_MouseHover);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(801, 526);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(57, 55);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 23;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(27, 536);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // lblCountPresent
            // 
            this.lblCountPresent.AutoSize = true;
            this.lblCountPresent.Font = new System.Drawing.Font("HP Simplified", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountPresent.Location = new System.Drawing.Point(288, 542);
            this.lblCountPresent.Name = "lblCountPresent";
            this.lblCountPresent.Size = new System.Drawing.Size(60, 44);
            this.lblCountPresent.TabIndex = 25;
            this.lblCountPresent.Text = "00";
            // 
            // currenttimer
            // 
            this.currenttimer.Interval = 1000;
            this.currenttimer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // AMPMlabel
            // 
            this.AMPMlabel.AutoSize = true;
            this.AMPMlabel.BackColor = System.Drawing.Color.Transparent;
            this.AMPMlabel.Font = new System.Drawing.Font("DS-Digital", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AMPMlabel.ForeColor = System.Drawing.Color.White;
            this.AMPMlabel.Image = ((System.Drawing.Image)(resources.GetObject("AMPMlabel.Image")));
            this.AMPMlabel.Location = new System.Drawing.Point(1032, 36);
            this.AMPMlabel.Name = "AMPMlabel";
            this.AMPMlabel.Size = new System.Drawing.Size(87, 59);
            this.AMPMlabel.TabIndex = 30;
            this.AMPMlabel.Text = "00";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(772, 16);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(366, 128);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 31;
            this.pictureBox5.TabStop = false;
            // 
            // stopwatchtimer
            // 
            this.stopwatchtimer.Interval = 1000;
            this.stopwatchtimer.Tick += new System.EventHandler(this.stopwatchtimer_Tick);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.Black;
            this.PauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseButton.Font = new System.Drawing.Font("HP Simplified", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.PauseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PauseButton.Location = new System.Drawing.Point(512, 282);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(156, 64);
            this.PauseButton.TabIndex = 32;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Visible = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            this.PauseButton.MouseLeave += new System.EventHandler(this.PauseButton_MouseLeave);
            this.PauseButton.MouseHover += new System.EventHandler(this.PauseButton_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Digital", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(1003, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 22);
            this.label4.TabIndex = 33;
            this.label4.Text = "sec";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(862, 255);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(206, 109);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 34;
            this.pictureBox6.TabStop = false;
            // 
            // duraTimeLabel
            // 
            this.duraTimeLabel.AutoSize = true;
            this.duraTimeLabel.Font = new System.Drawing.Font("Digital", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duraTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.duraTimeLabel.Location = new System.Drawing.Point(41, 44);
            this.duraTimeLabel.Name = "duraTimeLabel";
            this.duraTimeLabel.Size = new System.Drawing.Size(106, 36);
            this.duraTimeLabel.TabIndex = 35;
            this.duraTimeLabel.Text = "00:00";
            this.duraTimeLabel.Visible = false;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Font = new System.Drawing.Font("Digital", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationLabel.ForeColor = System.Drawing.Color.Black;
            this.durationLabel.Location = new System.Drawing.Point(5, 7);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(190, 31);
            this.durationLabel.TabIndex = 36;
            this.durationLabel.Text = "Class Duration";
            this.durationLabel.Visible = false;
            // 
            // duMin
            // 
            this.duMin.AutoSize = true;
            this.duMin.Font = new System.Drawing.Font("Digital", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duMin.ForeColor = System.Drawing.Color.Black;
            this.duMin.Location = new System.Drawing.Point(160, 61);
            this.duMin.Name = "duMin";
            this.duMin.Size = new System.Drawing.Size(36, 19);
            this.duMin.TabIndex = 38;
            this.duMin.Text = "min";
            this.duMin.Visible = false;
            // 
            // duHr
            // 
            this.duHr.AutoSize = true;
            this.duHr.BackColor = System.Drawing.Color.Transparent;
            this.duHr.Font = new System.Drawing.Font("Digital", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duHr.ForeColor = System.Drawing.Color.Black;
            this.duHr.Location = new System.Drawing.Point(13, 58);
            this.duHr.Name = "duHr";
            this.duHr.Size = new System.Drawing.Size(23, 19);
            this.duHr.TabIndex = 37;
            this.duHr.Text = "hr";
            this.duHr.Visible = false;
            // 
            // LogOutImg
            // 
            this.LogOutImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogOutImg.Image = ((System.Drawing.Image)(resources.GetObject("LogOutImg.Image")));
            this.LogOutImg.Location = new System.Drawing.Point(28, 122);
            this.LogOutImg.Name = "LogOutImg";
            this.LogOutImg.Size = new System.Drawing.Size(56, 24);
            this.LogOutImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogOutImg.TabIndex = 28;
            this.LogOutImg.TabStop = false;
            this.LogOutImg.Click += new System.EventHandler(this.HomeImg_Click);
            // 
            // dateTimPickr
            // 
            this.dateTimPickr.CalendarForeColor = System.Drawing.Color.White;
            this.dateTimPickr.CalendarMonthBackground = System.Drawing.Color.Black;
            this.dateTimPickr.CalendarTitleBackColor = System.Drawing.Color.Black;
            this.dateTimPickr.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dateTimPickr.Font = new System.Drawing.Font("HP Simplified", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimPickr.Location = new System.Drawing.Point(28, 165);
            this.dateTimPickr.Name = "dateTimPickr";
            this.dateTimPickr.Size = new System.Drawing.Size(301, 28);
            this.dateTimPickr.TabIndex = 39;
            // 
            // CourseCodeLbl
            // 
            this.CourseCodeLbl.AutoSize = true;
            this.CourseCodeLbl.Font = new System.Drawing.Font("HP Simplified", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourseCodeLbl.ForeColor = System.Drawing.Color.Blue;
            this.CourseCodeLbl.Location = new System.Drawing.Point(132, 462);
            this.CourseCodeLbl.Name = "CourseCodeLbl";
            this.CourseCodeLbl.Size = new System.Drawing.Size(27, 20);
            this.CourseCodeLbl.TabIndex = 41;
            this.CourseCodeLbl.Text = "CC";
            // 
            // SemesterLbl
            // 
            this.SemesterLbl.AutoSize = true;
            this.SemesterLbl.Font = new System.Drawing.Font("HP Simplified", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SemesterLbl.ForeColor = System.Drawing.Color.OrangeRed;
            this.SemesterLbl.Location = new System.Drawing.Point(28, 462);
            this.SemesterLbl.Name = "SemesterLbl";
            this.SemesterLbl.Size = new System.Drawing.Size(39, 20);
            this.SemesterLbl.TabIndex = 42;
            this.SemesterLbl.Text = "Sem";
            // 
            // LblSemCCodeSelect
            // 
            this.LblSemCCodeSelect.AutoSize = true;
            this.LblSemCCodeSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblSemCCodeSelect.Font = new System.Drawing.Font("Digital", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSemCCodeSelect.ForeColor = System.Drawing.Color.OrangeRed;
            this.LblSemCCodeSelect.Location = new System.Drawing.Point(454, 348);
            this.LblSemCCodeSelect.Name = "LblSemCCodeSelect";
            this.LblSemCCodeSelect.Size = new System.Drawing.Size(260, 15);
            this.LblSemCCodeSelect.TabIndex = 43;
            this.LblSemCCodeSelect.Text = "Please Select Semester and Course Code";
            this.LblSemCCodeSelect.Click += new System.EventHandler(this.LblSemCCodeSelect_Click);
            this.LblSemCCodeSelect.MouseLeave += new System.EventHandler(this.LblSemCCodeSelect_MouseLeave);
            this.LblSemCCodeSelect.MouseHover += new System.EventHandler(this.LblSemCCodeSelect_MouseHover);
            // 
            // classNodomainUpDown
            // 
            this.classNodomainUpDown.BackColor = System.Drawing.Color.Black;
            this.classNodomainUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classNodomainUpDown.Font = new System.Drawing.Font("HP Simplified", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classNodomainUpDown.ForeColor = System.Drawing.Color.White;
            this.classNodomainUpDown.Location = new System.Drawing.Point(28, 264);
            this.classNodomainUpDown.Name = "classNodomainUpDown";
            this.classNodomainUpDown.Size = new System.Drawing.Size(131, 27);
            this.classNodomainUpDown.TabIndex = 44;
            this.classNodomainUpDown.Text = "Class No.";
            this.classNodomainUpDown.SelectedItemChanged += new System.EventHandler(this.classNodomainUpDown_SelectedItemChanged);
            // 
            // checkBoxSemCcode
            // 
            this.checkBoxSemCcode.AutoSize = true;
            this.checkBoxSemCcode.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSemCcode.ForeColor = System.Drawing.Color.Black;
            this.checkBoxSemCcode.Location = new System.Drawing.Point(28, 319);
            this.checkBoxSemCcode.Name = "checkBoxSemCcode";
            this.checkBoxSemCcode.Size = new System.Drawing.Size(99, 28);
            this.checkBoxSemCcode.TabIndex = 47;
            this.checkBoxSemCcode.Text = "Confirm";
            this.checkBoxSemCcode.UseVisualStyleBackColor = true;
            this.checkBoxSemCcode.CheckedChanged += new System.EventHandler(this.checkBoxSemCcode_CheckedChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            // 
            // fingerIDtimer
            // 
            this.fingerIDtimer.Enabled = true;
            this.fingerIDtimer.Interval = 1000;
            this.fingerIDtimer.Tick += new System.EventHandler(this.fingerIDtimer_Tick);
            // 
            // checkBoxID
            // 
            this.checkBoxID.AutoSize = true;
            this.checkBoxID.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxID.ForeColor = System.Drawing.Color.Black;
            this.checkBoxID.Location = new System.Drawing.Point(28, 381);
            this.checkBoxID.Name = "checkBoxID";
            this.checkBoxID.Size = new System.Drawing.Size(49, 28);
            this.checkBoxID.TabIndex = 49;
            this.checkBoxID.Text = "ID";
            this.checkBoxID.UseVisualStyleBackColor = true;
            this.checkBoxID.CheckedChanged += new System.EventHandler(this.checkBoxID_CheckedChanged);
            // 
            // paneClassDuration
            // 
            this.paneClassDuration.Controls.Add(this.durationLabel);
            this.paneClassDuration.Controls.Add(this.duraTimeLabel);
            this.paneClassDuration.Controls.Add(this.duHr);
            this.paneClassDuration.Controls.Add(this.duMin);
            this.paneClassDuration.Location = new System.Drawing.Point(483, 264);
            this.paneClassDuration.Name = "paneClassDuration";
            this.paneClassDuration.Size = new System.Drawing.Size(200, 100);
            this.paneClassDuration.TabIndex = 50;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(427, 528);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 59);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 51;
            this.pictureBox3.TabStop = false;
            // 
            // TeachersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1154, 624);
            this.Controls.Add(this.StartTButton);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LblSemCCodeSelect);
            this.Controls.Add(this.checkBoxID);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.checkBoxSemCcode);
            this.Controls.Add(this.classNodomainUpDown);
            this.Controls.Add(this.SemesterLbl);
            this.Controls.Add(this.CourseCodeLbl);
            this.Controls.Add(this.dateTimPickr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Datelabel);
            this.Controls.Add(this.Daylabel);
            this.Controls.Add(this.AMPMlabel);
            this.Controls.Add(this.Seclabel);
            this.Controls.Add(this.Timelabel);
            this.Controls.Add(this.LogOutImg);
            this.Controls.Add(this.lblCountPresent);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.StuPanelButton);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.ViewButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.minlabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxCourse);
            this.Controls.Add(this.comboBoxSemester);
            this.Controls.Add(this.labelTeacherName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.paneClassDuration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TeachersPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeachersPanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeachersPanel_FormClosing);
            this.Load += new System.EventHandler(this.TeachersPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogOutImg)).EndInit();
            this.paneClassDuration.ResumeLayout(false);
            this.paneClassDuration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTeacherName;
        private System.Windows.Forms.ComboBox comboBoxSemester;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.Button StartTButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label minlabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Timelabel;
        private System.Windows.Forms.Label Seclabel;
        private System.Windows.Forms.Label Datelabel;
        private System.Windows.Forms.Label Daylabel;
        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.Button StuPanelButton;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblCountPresent;
        private System.Windows.Forms.Timer currenttimer;
        private System.Windows.Forms.Label AMPMlabel;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Timer stopwatchtimer;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label duraTimeLabel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label duMin;
        private System.Windows.Forms.Label duHr;
        private System.Windows.Forms.PictureBox LogOutImg;
        private System.Windows.Forms.DateTimePicker dateTimPickr;
        private System.Windows.Forms.Label CourseCodeLbl;
        private System.Windows.Forms.Label SemesterLbl;
        private System.Windows.Forms.Label LblSemCCodeSelect;
        private System.Windows.Forms.DomainUpDown classNodomainUpDown;
        private System.Windows.Forms.CheckBox checkBoxSemCcode;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer fingerIDtimer;
        private System.Windows.Forms.CheckBox checkBoxID;
        private System.Windows.Forms.Panel paneClassDuration;
        private System.Windows.Forms.PictureBox pictureBox3;
        }
    }