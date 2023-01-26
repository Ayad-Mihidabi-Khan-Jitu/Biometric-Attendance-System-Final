
namespace Biometric_Attendence_System
    {
    partial class TeachersList
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
            this.dataGridTeachers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFaculty = new System.Windows.Forms.ComboBox();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTeachers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTeachers
            // 
            this.dataGridTeachers.AllowUserToAddRows = false;
            this.dataGridTeachers.AllowUserToDeleteRows = false;
            this.dataGridTeachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridTeachers.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.dataGridTeachers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTeachers.GridColor = System.Drawing.Color.Black;
            this.dataGridTeachers.Location = new System.Drawing.Point(99, 74);
            this.dataGridTeachers.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridTeachers.Name = "dataGridTeachers";
            this.dataGridTeachers.RowHeadersVisible = false;
            this.dataGridTeachers.RowHeadersWidth = 51;
            this.dataGridTeachers.RowTemplate.Height = 24;
            this.dataGridTeachers.RowTemplate.ReadOnly = true;
            this.dataGridTeachers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridTeachers.Size = new System.Drawing.Size(1044, 471);
            this.dataGridTeachers.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("HP Simplified", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(536, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 32);
            this.label1.TabIndex = 61;
            this.label1.Text = "Teachers Data";
            // 
            // comboBoxFaculty
            // 
            this.comboBoxFaculty.FormattingEnabled = true;
            this.comboBoxFaculty.Location = new System.Drawing.Point(99, 43);
            this.comboBoxFaculty.Name = "comboBoxFaculty";
            this.comboBoxFaculty.Size = new System.Drawing.Size(121, 24);
            this.comboBoxFaculty.TabIndex = 62;
            this.comboBoxFaculty.Text = "Faculty";
            this.comboBoxFaculty.SelectedIndexChanged += new System.EventHandler(this.comboBoxFaculty_SelectedIndexChanged);
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(251, 43);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(121, 24);
            this.comboBoxDepartment.TabIndex = 63;
            this.comboBoxDepartment.Text = "Department";
            this.comboBoxDepartment.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepartment_SelectedIndexChanged);
            // 
            // TeachersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1231, 558);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.comboBoxFaculty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridTeachers);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TeachersList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeachersList";
            this.Load += new System.EventHandler(this.TeachersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTeachers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.DataGridView dataGridTeachers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFaculty;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        }
    }