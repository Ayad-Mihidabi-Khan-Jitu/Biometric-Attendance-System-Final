using System;

namespace Biometric_Attendence_System
    {
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.AdminImg = new System.Windows.Forms.PictureBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Label();
            this.radioBtnPass = new System.Windows.Forms.RadioButton();
            this.radioBtnFinger = new System.Windows.Forms.RadioButton();
            this.checkBoxPasshow = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblLoading = new System.Windows.Forms.Label();
            this.timerFingerprint = new System.Windows.Forms.Timer(this.components);
            this.checkBoxID = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdminImg)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(669, 484);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(301, 262);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(301, 337);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 58);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // AdminImg
            // 
            this.AdminImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdminImg.Image = ((System.Drawing.Image)(resources.GetObject("AdminImg.Image")));
            this.AdminImg.Location = new System.Drawing.Point(12, 304);
            this.AdminImg.Name = "AdminImg";
            this.AdminImg.Size = new System.Drawing.Size(67, 58);
            this.AdminImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AdminImg.TabIndex = 3;
            this.AdminImg.TabStop = false;
            this.AdminImg.Click += new System.EventHandler(this.AdminImg_Click);
            // 
            // UserName
            // 
            this.UserName.BackColor = System.Drawing.Color.Aquamarine;
            this.UserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserName.Font = new System.Drawing.Font("HP Simplified", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.Location = new System.Drawing.Point(381, 271);
            this.UserName.MaxLength = 20;
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(353, 39);
            this.UserName.TabIndex = 4;
            this.UserName.Text = "Username";
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.Aquamarine;
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password.Font = new System.Drawing.Font("HP Simplified", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(381, 346);
            this.Password.MaxLength = 8;
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(353, 39);
            this.Password.TabIndex = 5;
            this.Password.Text = "Password";
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.Black;
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.Lime;
            this.LoginButton.Location = new System.Drawing.Point(381, 427);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(99, 43);
            this.LoginButton.TabIndex = 6;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            this.LoginButton.MouseLeave += new System.EventHandler(this.LoginButton_MouseLeave);
            this.LoginButton.MouseHover += new System.EventHandler(this.LoginButton_MouseHover);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Black;
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.Color.Red;
            this.ClearButton.Location = new System.Drawing.Point(634, 427);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(100, 43);
            this.ClearButton.TabIndex = 7;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            this.ClearButton.MouseLeave += new System.EventHandler(this.ClearButton_MouseLeave);
            this.ClearButton.MouseHover += new System.EventHandler(this.ClearButton_MouseHover);
            // 
            // ExitBtn
            // 
            this.ExitBtn.AutoSize = true;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitBtn.Font = new System.Drawing.Font("Forte", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.Red;
            this.ExitBtn.Location = new System.Drawing.Point(698, 5);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(40, 36);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "X";
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // radioBtnPass
            // 
            this.radioBtnPass.AutoSize = true;
            this.radioBtnPass.Checked = true;
            this.radioBtnPass.ForeColor = System.Drawing.Color.MediumBlue;
            this.radioBtnPass.Location = new System.Drawing.Point(381, 244);
            this.radioBtnPass.Name = "radioBtnPass";
            this.radioBtnPass.Size = new System.Drawing.Size(90, 21);
            this.radioBtnPass.TabIndex = 9;
            this.radioBtnPass.TabStop = true;
            this.radioBtnPass.Text = "Password";
            this.radioBtnPass.UseVisualStyleBackColor = true;
            this.radioBtnPass.CheckedChanged += new System.EventHandler(this.radioBtnPass_CheckedChanged);
            // 
            // radioBtnFinger
            // 
            this.radioBtnFinger.AutoSize = true;
            this.radioBtnFinger.ForeColor = System.Drawing.Color.Crimson;
            this.radioBtnFinger.Location = new System.Drawing.Point(637, 244);
            this.radioBtnFinger.Name = "radioBtnFinger";
            this.radioBtnFinger.Size = new System.Drawing.Size(97, 21);
            this.radioBtnFinger.TabIndex = 10;
            this.radioBtnFinger.Text = "Fingerprint";
            this.radioBtnFinger.UseVisualStyleBackColor = true;
            this.radioBtnFinger.Visible = false;
            this.radioBtnFinger.CheckedChanged += new System.EventHandler(this.radioBtnFinger_CheckedChanged);
            // 
            // checkBoxPasshow
            // 
            this.checkBoxPasshow.AutoSize = true;
            this.checkBoxPasshow.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkBoxPasshow.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.checkBoxPasshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.checkBoxPasshow.ForeColor = System.Drawing.Color.Gray;
            this.checkBoxPasshow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxPasshow.Location = new System.Drawing.Point(381, 391);
            this.checkBoxPasshow.Name = "checkBoxPasshow";
            this.checkBoxPasshow.Size = new System.Drawing.Size(129, 21);
            this.checkBoxPasshow.TabIndex = 66;
            this.checkBoxPasshow.Text = "Show Password";
            this.checkBoxPasshow.UseVisualStyleBackColor = true;
            this.checkBoxPasshow.CheckedChanged += new System.EventHandler(this.checkBoxPasshow_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.ForeColor = System.Drawing.Color.Crimson;
            this.lblLoading.Location = new System.Drawing.Point(595, 246);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(143, 17);
            this.lblLoading.TabIndex = 67;
            this.lblLoading.Text = "Loading Fingerprint...";
            // 
            // timerFingerprint
            // 
            this.timerFingerprint.Enabled = true;
            this.timerFingerprint.Interval = 1000;
            this.timerFingerprint.Tick += new System.EventHandler(this.timerFingerprint_Tick);
            // 
            // checkBoxID
            // 
            this.checkBoxID.AutoSize = true;
            this.checkBoxID.Location = new System.Drawing.Point(491, 246);
            this.checkBoxID.Name = "checkBoxID";
            this.checkBoxID.Size = new System.Drawing.Size(49, 21);
            this.checkBoxID.TabIndex = 68;
            this.checkBoxID.Text = "Fid";
            this.checkBoxID.UseVisualStyleBackColor = true;
            this.checkBoxID.Visible = false;
            this.checkBoxID.CheckedChanged += new System.EventHandler(this.checkBoxID_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(746, 482);
            this.Controls.Add(this.checkBoxID);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.checkBoxPasshow);
            this.Controls.Add(this.radioBtnFinger);
            this.Controls.Add(this.radioBtnPass);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.AdminImg);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdminImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox AdminImg;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label ExitBtn;
        private System.Windows.Forms.RadioButton radioBtnPass;
        private System.Windows.Forms.RadioButton radioBtnFinger;
        private System.Windows.Forms.CheckBox checkBoxPasshow;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Timer timerFingerprint;
        private System.Windows.Forms.CheckBox checkBoxID;
        }
    }