namespace Biometric_Attendence_System
    {
    partial class AdminLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.AdLoginButton = new System.Windows.Forms.Button();
            this.AdPassword = new System.Windows.Forms.TextBox();
            this.AdminName = new System.Windows.Forms.TextBox();
            this.BackBtn = new System.Windows.Forms.Label();
            this.Close_Img = new System.Windows.Forms.PictureBox();
            this.checkBoxPasshow = new System.Windows.Forms.CheckBox();
            this.radioBtnFinger = new System.Windows.Forms.RadioButton();
            this.radioBtnPass = new System.Windows.Forms.RadioButton();
            this.timerFingerprint = new System.Windows.Forms.Timer(this.components);
            this.checkBoxID = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Img)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 345);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Black;
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.Color.Red;
            this.ClearButton.Location = new System.Drawing.Point(413, 415);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(100, 43);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            this.ClearButton.MouseLeave += new System.EventHandler(this.ClearButton_MouseLeave);
            this.ClearButton.MouseHover += new System.EventHandler(this.ClearButton_MouseHover);
            // 
            // AdLoginButton
            // 
            this.AdLoginButton.BackColor = System.Drawing.Color.Black;
            this.AdLoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdLoginButton.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdLoginButton.ForeColor = System.Drawing.Color.Lime;
            this.AdLoginButton.Location = new System.Drawing.Point(167, 415);
            this.AdLoginButton.Name = "AdLoginButton";
            this.AdLoginButton.Size = new System.Drawing.Size(99, 43);
            this.AdLoginButton.TabIndex = 10;
            this.AdLoginButton.Text = "Login";
            this.AdLoginButton.UseVisualStyleBackColor = false;
            this.AdLoginButton.Click += new System.EventHandler(this.AdLoginButton_Click);
            this.AdLoginButton.MouseLeave += new System.EventHandler(this.AdLoginButton_MouseLeave);
            this.AdLoginButton.MouseHover += new System.EventHandler(this.AdLoginButton_MouseHover);
            // 
            // AdPassword
            // 
            this.AdPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AdPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AdPassword.Font = new System.Drawing.Font("HP Simplified", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdPassword.Location = new System.Drawing.Point(167, 251);
            this.AdPassword.MaxLength = 8;
            this.AdPassword.Name = "AdPassword";
            this.AdPassword.Size = new System.Drawing.Size(375, 47);
            this.AdPassword.TabIndex = 9;
            this.AdPassword.Text = "Password";
            // 
            // AdminName
            // 
            this.AdminName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AdminName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AdminName.Font = new System.Drawing.Font("HP Simplified", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminName.Location = new System.Drawing.Point(167, 151);
            this.AdminName.MaxLength = 20;
            this.AdminName.Name = "AdminName";
            this.AdminName.Size = new System.Drawing.Size(375, 47);
            this.AdminName.TabIndex = 8;
            this.AdminName.Text = "Username";
            // 
            // BackBtn
            // 
            this.BackBtn.AutoSize = true;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackBtn.Font = new System.Drawing.Font("Forte", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.ForeColor = System.Drawing.Color.White;
            this.BackBtn.Location = new System.Drawing.Point(1, 407);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(69, 66);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "<";
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // Close_Img
            // 
            this.Close_Img.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close_Img.Image = ((System.Drawing.Image)(resources.GetObject("Close_Img.Image")));
            this.Close_Img.Location = new System.Drawing.Point(614, 1);
            this.Close_Img.Name = "Close_Img";
            this.Close_Img.Size = new System.Drawing.Size(48, 38);
            this.Close_Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Close_Img.TabIndex = 28;
            this.Close_Img.TabStop = false;
            this.Close_Img.Click += new System.EventHandler(this.Close_Img_Click);
            // 
            // checkBoxPasshow
            // 
            this.checkBoxPasshow.AutoSize = true;
            this.checkBoxPasshow.BackColor = System.Drawing.Color.White;
            this.checkBoxPasshow.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkBoxPasshow.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.checkBoxPasshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.checkBoxPasshow.ForeColor = System.Drawing.Color.Gray;
            this.checkBoxPasshow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxPasshow.Location = new System.Drawing.Point(167, 305);
            this.checkBoxPasshow.Name = "checkBoxPasshow";
            this.checkBoxPasshow.Size = new System.Drawing.Size(129, 21);
            this.checkBoxPasshow.TabIndex = 69;
            this.checkBoxPasshow.Text = "Show Password";
            this.checkBoxPasshow.UseVisualStyleBackColor = false;
            this.checkBoxPasshow.CheckedChanged += new System.EventHandler(this.checkBoxPasshow_CheckedChanged);
            // 
            // radioBtnFinger
            // 
            this.radioBtnFinger.AutoSize = true;
            this.radioBtnFinger.BackColor = System.Drawing.Color.White;
            this.radioBtnFinger.ForeColor = System.Drawing.Color.Crimson;
            this.radioBtnFinger.Location = new System.Drawing.Point(445, 124);
            this.radioBtnFinger.Name = "radioBtnFinger";
            this.radioBtnFinger.Size = new System.Drawing.Size(97, 21);
            this.radioBtnFinger.TabIndex = 68;
            this.radioBtnFinger.Text = "Fingerprint";
            this.radioBtnFinger.UseVisualStyleBackColor = false;
            this.radioBtnFinger.CheckedChanged += new System.EventHandler(this.radioBtnFinger_CheckedChanged);
            // 
            // radioBtnPass
            // 
            this.radioBtnPass.AutoSize = true;
            this.radioBtnPass.BackColor = System.Drawing.Color.White;
            this.radioBtnPass.Checked = true;
            this.radioBtnPass.ForeColor = System.Drawing.Color.MediumBlue;
            this.radioBtnPass.Location = new System.Drawing.Point(167, 124);
            this.radioBtnPass.Name = "radioBtnPass";
            this.radioBtnPass.Size = new System.Drawing.Size(90, 21);
            this.radioBtnPass.TabIndex = 67;
            this.radioBtnPass.TabStop = true;
            this.radioBtnPass.Text = "Password";
            this.radioBtnPass.UseVisualStyleBackColor = false;
            this.radioBtnPass.CheckedChanged += new System.EventHandler(this.radioBtnPass_CheckedChanged);
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
            this.checkBoxID.BackColor = System.Drawing.Color.White;
            this.checkBoxID.Location = new System.Drawing.Point(263, 125);
            this.checkBoxID.Name = "checkBoxID";
            this.checkBoxID.Size = new System.Drawing.Size(49, 21);
            this.checkBoxID.TabIndex = 70;
            this.checkBoxID.Text = "Fid";
            this.checkBoxID.UseVisualStyleBackColor = false;
            this.checkBoxID.Visible = false;
            this.checkBoxID.CheckedChanged += new System.EventHandler(this.checkBoxID_CheckedChanged);
            // 
            // AdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(664, 482);
            this.Controls.Add(this.checkBoxID);
            this.Controls.Add(this.checkBoxPasshow);
            this.Controls.Add(this.radioBtnFinger);
            this.Controls.Add(this.radioBtnPass);
            this.Controls.Add(this.Close_Img);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.AdLoginButton);
            this.Controls.Add(this.AdPassword);
            this.Controls.Add(this.AdminName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.AdminLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button AdLoginButton;
        private System.Windows.Forms.TextBox AdPassword;
        private System.Windows.Forms.TextBox AdminName;
        private System.Windows.Forms.Label BackBtn;
        private System.Windows.Forms.PictureBox Close_Img;
        private System.Windows.Forms.CheckBox checkBoxPasshow;
        private System.Windows.Forms.RadioButton radioBtnFinger;
        private System.Windows.Forms.RadioButton radioBtnPass;
        private System.Windows.Forms.Timer timerFingerprint;
        private System.Windows.Forms.CheckBox checkBoxID;
        }
    }