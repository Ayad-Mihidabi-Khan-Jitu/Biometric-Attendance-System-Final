
namespace Biometric_Attendence_System
    {
    partial class AttendenceDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendenceDetails));
            this.label8 = new System.Windows.Forms.Label();
            this.SemesterLbl = new System.Windows.Forms.Label();
            this.SendtoAnother = new System.Windows.Forms.Button();
            this.mobileLbl = new System.Windows.Forms.Label();
            this.RegisLbl = new System.Windows.Forms.Label();
            this.IDLbl = new System.Windows.Forms.Label();
            this.StudentNameLbl = new System.Windows.Forms.Label();
            this.pictureBoxStudent = new System.Windows.Forms.PictureBox();
            this.ComboAtten = new System.Windows.Forms.ComboBox();
            this.dataGridStudentAttendence = new System.Windows.Forms.DataGridView();
            this.SendMeButton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.TextBoxMail = new System.Windows.Forms.TextBox();
            this.LblCourseCode = new System.Windows.Forms.Label();
            this.LblSemester = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.Lbldirectory = new System.Windows.Forms.Label();
            this.LocationLbl = new System.Windows.Forms.Label();
            this.SessionLbl = new System.Windows.Forms.Label();
            this.saveFileAs = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudentAttendence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("HP Simplified", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(452, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(324, 46);
            this.label8.TabIndex = 83;
            this.label8.Text = "Attendence Sheet";
            // 
            // SemesterLbl
            // 
            this.SemesterLbl.AutoSize = true;
            this.SemesterLbl.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold);
            this.SemesterLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SemesterLbl.Location = new System.Drawing.Point(984, 378);
            this.SemesterLbl.Name = "SemesterLbl";
            this.SemesterLbl.Size = new System.Drawing.Size(128, 32);
            this.SemesterLbl.TabIndex = 78;
            this.SemesterLbl.Text = "Semester";
            // 
            // SendtoAnother
            // 
            this.SendtoAnother.BackColor = System.Drawing.Color.Black;
            this.SendtoAnother.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendtoAnother.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendtoAnother.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendtoAnother.ForeColor = System.Drawing.Color.SpringGreen;
            this.SendtoAnother.Location = new System.Drawing.Point(47, 516);
            this.SendtoAnother.Name = "SendtoAnother";
            this.SendtoAnother.Size = new System.Drawing.Size(134, 44);
            this.SendtoAnother.TabIndex = 77;
            this.SendtoAnother.Text = "Send to mail";
            this.SendtoAnother.UseVisualStyleBackColor = false;
            this.SendtoAnother.Click += new System.EventHandler(this.SendtoAnother_Click);
            this.SendtoAnother.MouseLeave += new System.EventHandler(this.SendtoAnother_MouseLeave);
            this.SendtoAnother.MouseHover += new System.EventHandler(this.SendtoAnother_MouseHover);
            // 
            // mobileLbl
            // 
            this.mobileLbl.AutoSize = true;
            this.mobileLbl.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold);
            this.mobileLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mobileLbl.Location = new System.Drawing.Point(984, 444);
            this.mobileLbl.Name = "mobileLbl";
            this.mobileLbl.Size = new System.Drawing.Size(93, 32);
            this.mobileLbl.TabIndex = 76;
            this.mobileLbl.Text = "Mobile";
            // 
            // RegisLbl
            // 
            this.RegisLbl.AutoSize = true;
            this.RegisLbl.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold);
            this.RegisLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RegisLbl.Location = new System.Drawing.Point(984, 346);
            this.RegisLbl.Name = "RegisLbl";
            this.RegisLbl.Size = new System.Drawing.Size(202, 32);
            this.RegisLbl.TabIndex = 75;
            this.RegisLbl.Text = "Registration No";
            // 
            // IDLbl
            // 
            this.IDLbl.AutoSize = true;
            this.IDLbl.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold);
            this.IDLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.IDLbl.Location = new System.Drawing.Point(984, 313);
            this.IDLbl.Name = "IDLbl";
            this.IDLbl.Size = new System.Drawing.Size(76, 32);
            this.IDLbl.TabIndex = 74;
            this.IDLbl.Text = "ID No";
            // 
            // StudentNameLbl
            // 
            this.StudentNameLbl.AutoSize = true;
            this.StudentNameLbl.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold);
            this.StudentNameLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StudentNameLbl.Location = new System.Drawing.Point(984, 274);
            this.StudentNameLbl.Name = "StudentNameLbl";
            this.StudentNameLbl.Size = new System.Drawing.Size(202, 32);
            this.StudentNameLbl.TabIndex = 73;
            this.StudentNameLbl.Text = "Student\'s Name";
            // 
            // pictureBoxStudent
            // 
            this.pictureBoxStudent.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBoxStudent.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStudent.Image")));
            this.pictureBoxStudent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxStudent.Location = new System.Drawing.Point(990, 127);
            this.pictureBoxStudent.Name = "pictureBoxStudent";
            this.pictureBoxStudent.Size = new System.Drawing.Size(184, 144);
            this.pictureBoxStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStudent.TabIndex = 72;
            this.pictureBoxStudent.TabStop = false;
            // 
            // ComboAtten
            // 
            this.ComboAtten.BackColor = System.Drawing.Color.White;
            this.ComboAtten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboAtten.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold);
            this.ComboAtten.FormattingEnabled = true;
            this.ComboAtten.Items.AddRange(new object[] {
            "All",
            "Present",
            "Absent"});
            this.ComboAtten.Location = new System.Drawing.Point(47, 81);
            this.ComboAtten.Name = "ComboAtten";
            this.ComboAtten.Size = new System.Drawing.Size(143, 40);
            this.ComboAtten.TabIndex = 60;
            this.ComboAtten.Text = "Attend";
            this.ComboAtten.SelectedIndexChanged += new System.EventHandler(this.ComboAtten_SelectedIndexChanged);
            // 
            // dataGridStudentAttendence
            // 
            this.dataGridStudentAttendence.AllowUserToAddRows = false;
            this.dataGridStudentAttendence.AllowUserToDeleteRows = false;
            this.dataGridStudentAttendence.BackgroundColor = System.Drawing.Color.White;
            this.dataGridStudentAttendence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStudentAttendence.Location = new System.Drawing.Point(47, 127);
            this.dataGridStudentAttendence.Name = "dataGridStudentAttendence";
            this.dataGridStudentAttendence.RowHeadersVisible = false;
            this.dataGridStudentAttendence.RowHeadersWidth = 51;
            this.dataGridStudentAttendence.RowTemplate.Height = 24;
            this.dataGridStudentAttendence.Size = new System.Drawing.Size(773, 303);
            this.dataGridStudentAttendence.TabIndex = 84;
            this.dataGridStudentAttendence.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridStudentAttendence_CellClick);
            // 
            // SendMeButton
            // 
            this.SendMeButton.BackColor = System.Drawing.Color.Black;
            this.SendMeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendMeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendMeButton.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendMeButton.ForeColor = System.Drawing.Color.DodgerBlue;
            this.SendMeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SendMeButton.Location = new System.Drawing.Point(47, 448);
            this.SendMeButton.Name = "SendMeButton";
            this.SendMeButton.Size = new System.Drawing.Size(135, 43);
            this.SendMeButton.TabIndex = 85;
            this.SendMeButton.Text = "Send Me";
            this.SendMeButton.UseVisualStyleBackColor = false;
            this.SendMeButton.Click += new System.EventHandler(this.SendMeButton_Click);
            this.SendMeButton.MouseLeave += new System.EventHandler(this.SendMeButton_MouseLeave);
            this.SendMeButton.MouseHover += new System.EventHandler(this.SendMeButton_MouseHover);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(164, 444);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(90, 55);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 86;
            this.pictureBox3.TabStop = false;
            // 
            // TextBoxMail
            // 
            this.TextBoxMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxMail.Location = new System.Drawing.Point(190, 525);
            this.TextBoxMail.Name = "TextBoxMail";
            this.TextBoxMail.Size = new System.Drawing.Size(362, 30);
            this.TextBoxMail.TabIndex = 87;
            this.TextBoxMail.Text = "@gmail.com";
            // 
            // LblCourseCode
            // 
            this.LblCourseCode.AutoSize = true;
            this.LblCourseCode.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold);
            this.LblCourseCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCourseCode.Location = new System.Drawing.Point(660, 84);
            this.LblCourseCode.Name = "LblCourseCode";
            this.LblCourseCode.Size = new System.Drawing.Size(160, 32);
            this.LblCourseCode.TabIndex = 88;
            this.LblCourseCode.Text = "Course Code";
            // 
            // LblSemester
            // 
            this.LblSemester.AutoSize = true;
            this.LblSemester.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold);
            this.LblSemester.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblSemester.Location = new System.Drawing.Point(471, 84);
            this.LblSemester.Name = "LblSemester";
            this.LblSemester.Size = new System.Drawing.Size(128, 32);
            this.LblSemester.TabIndex = 89;
            this.LblSemester.Text = "Semester";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold);
            this.LblDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblDate.Location = new System.Drawing.Point(306, 84);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(72, 32);
            this.LblDate.TabIndex = 90;
            this.LblDate.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(215, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 32);
            this.label1.TabIndex = 91;
            this.label1.Text = "Date:";
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.Black;
            this.buttonPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.ForeColor = System.Drawing.Color.Cyan;
            this.buttonPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonPrint.Location = new System.Drawing.Point(685, 444);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(135, 43);
            this.buttonPrint.TabIndex = 92;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            this.buttonPrint.MouseLeave += new System.EventHandler(this.buttonPrint_MouseLeave);
            this.buttonPrint.MouseHover += new System.EventHandler(this.buttonPrint_MouseHover);
            // 
            // Lbldirectory
            // 
            this.Lbldirectory.AutoSize = true;
            this.Lbldirectory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Lbldirectory.Font = new System.Drawing.Font("HP Simplified", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbldirectory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Lbldirectory.Location = new System.Drawing.Point(364, 615);
            this.Lbldirectory.Name = "Lbldirectory";
            this.Lbldirectory.Size = new System.Drawing.Size(125, 17);
            this.Lbldirectory.TabIndex = 94;
            this.Lbldirectory.Text = "Excel Sheet Saved in";
            // 
            // LocationLbl
            // 
            this.LocationLbl.AutoSize = true;
            this.LocationLbl.BackColor = System.Drawing.Color.Transparent;
            this.LocationLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LocationLbl.Font = new System.Drawing.Font("HP Simplified", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LocationLbl.Location = new System.Drawing.Point(725, 489);
            this.LocationLbl.Name = "LocationLbl";
            this.LocationLbl.Size = new System.Drawing.Size(91, 17);
            this.LocationLbl.TabIndex = 97;
            this.LocationLbl.Text = "Show Location";
            this.LocationLbl.Click += new System.EventHandler(this.LocationLbl_Click);
            this.LocationLbl.MouseLeave += new System.EventHandler(this.LocationLbl_MouseLeave);
            this.LocationLbl.MouseHover += new System.EventHandler(this.LocationLbl_MouseHover);
            // 
            // SessionLbl
            // 
            this.SessionLbl.AutoSize = true;
            this.SessionLbl.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold);
            this.SessionLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SessionLbl.Location = new System.Drawing.Point(984, 410);
            this.SessionLbl.Name = "SessionLbl";
            this.SessionLbl.Size = new System.Drawing.Size(107, 32);
            this.SessionLbl.TabIndex = 98;
            this.SessionLbl.Text = "Session";
            // 
            // AttendenceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 641);
            this.Controls.Add(this.SessionLbl);
            this.Controls.Add(this.LocationLbl);
            this.Controls.Add(this.Lbldirectory);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.LblSemester);
            this.Controls.Add(this.LblCourseCode);
            this.Controls.Add(this.TextBoxMail);
            this.Controls.Add(this.SendMeButton);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.dataGridStudentAttendence);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SemesterLbl);
            this.Controls.Add(this.SendtoAnother);
            this.Controls.Add(this.mobileLbl);
            this.Controls.Add(this.RegisLbl);
            this.Controls.Add(this.IDLbl);
            this.Controls.Add(this.StudentNameLbl);
            this.Controls.Add(this.pictureBoxStudent);
            this.Controls.Add(this.ComboAtten);
            this.Name = "AttendenceDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttendenceDetails";
            this.Load += new System.EventHandler(this.AttendenceDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudentAttendence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label SemesterLbl;
        private System.Windows.Forms.Button SendtoAnother;
        private System.Windows.Forms.Label mobileLbl;
        private System.Windows.Forms.Label RegisLbl;
        private System.Windows.Forms.Label IDLbl;
        private System.Windows.Forms.Label StudentNameLbl;
        private System.Windows.Forms.PictureBox pictureBoxStudent;
        private System.Windows.Forms.ComboBox ComboAtten;
        private System.Windows.Forms.DataGridView dataGridStudentAttendence;
        private System.Windows.Forms.Button SendMeButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox TextBoxMail;
        private System.Windows.Forms.Label LblCourseCode;
        private System.Windows.Forms.Label LblSemester;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Label Lbldirectory;
        private System.Windows.Forms.Label LocationLbl;
        private System.Windows.Forms.Label SessionLbl;
        private System.Windows.Forms.SaveFileDialog saveFileAs;
        }
    }