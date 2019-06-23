namespace Universal_Management
{
    partial class UM_Backup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UM_Backup));
            this.label8 = new System.Windows.Forms.Label();
            this.txtPath_Zip = new System.Windows.Forms.TextBox();
            this.btnMysqlPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmySqlPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZipPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFileZip = new System.Windows.Forms.TextBox();
            this.btnPathBackup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPath_Zip = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.backup_box = new System.Windows.Forms.GroupBox();
            this.btnStartBackup = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.backup_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "ZIP Pfad";
            // 
            // txtPath_Zip
            // 
            this.txtPath_Zip.Location = new System.Drawing.Point(7, 36);
            this.txtPath_Zip.Name = "txtPath_Zip";
            this.txtPath_Zip.ReadOnly = true;
            this.txtPath_Zip.Size = new System.Drawing.Size(221, 20);
            this.txtPath_Zip.TabIndex = 1;
            // 
            // btnMysqlPath
            // 
            this.btnMysqlPath.Location = new System.Drawing.Point(234, 73);
            this.btnMysqlPath.Name = "btnMysqlPath";
            this.btnMysqlPath.Size = new System.Drawing.Size(77, 23);
            this.btnMysqlPath.TabIndex = 10;
            this.btnMysqlPath.Text = "Pfad wählen";
            this.btnMysqlPath.UseVisualStyleBackColor = true;
            this.btnMysqlPath.Click += new System.EventHandler(this.btnMysqlPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "mysqldump.exe Pfad";
            // 
            // txtmySqlPath
            // 
            this.txtmySqlPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmySqlPath.Location = new System.Drawing.Point(7, 75);
            this.txtmySqlPath.Name = "txtmySqlPath";
            this.txtmySqlPath.ReadOnly = true;
            this.txtmySqlPath.Size = new System.Drawing.Size(221, 18);
            this.txtmySqlPath.TabIndex = 8;
            this.txtmySqlPath.Text = "C:\\Program Files\\MySQL\\MySQL Server 5.6\\bin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DB Dateiname (.sql)";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(7, 117);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(304, 20);
            this.txtFilename.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "DB Speichern Pfad";
            // 
            // txtZipPass
            // 
            this.txtZipPass.Location = new System.Drawing.Point(7, 114);
            this.txtZipPass.Name = "txtZipPass";
            this.txtZipPass.Size = new System.Drawing.Size(305, 20);
            this.txtZipPass.TabIndex = 8;
            this.txtZipPass.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "ZIP Dateiname";
            // 
            // txtFileZip
            // 
            this.txtFileZip.Location = new System.Drawing.Point(6, 75);
            this.txtFileZip.Name = "txtFileZip";
            this.txtFileZip.Size = new System.Drawing.Size(305, 20);
            this.txtFileZip.TabIndex = 4;
            // 
            // btnPathBackup
            // 
            this.btnPathBackup.Location = new System.Drawing.Point(234, 34);
            this.btnPathBackup.Name = "btnPathBackup";
            this.btnPathBackup.Size = new System.Drawing.Size(77, 23);
            this.btnPathBackup.TabIndex = 2;
            this.btnPathBackup.Text = "Pfad wählen";
            this.btnPathBackup.UseVisualStyleBackColor = true;
            this.btnPathBackup.Click += new System.EventHandler(this.btnPathBackup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtZipPass);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFileZip);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnPath_Zip);
            this.groupBox1.Controls.Add(this.txtPath_Zip);
            this.groupBox1.Location = new System.Drawing.Point(12, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 162);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ZIP erstellen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Zip Passwort";
            // 
            // btnPath_Zip
            // 
            this.btnPath_Zip.Location = new System.Drawing.Point(234, 34);
            this.btnPath_Zip.Name = "btnPath_Zip";
            this.btnPath_Zip.Size = new System.Drawing.Size(77, 23);
            this.btnPath_Zip.TabIndex = 2;
            this.btnPath_Zip.Text = "Pfad wählen";
            this.btnPath_Zip.UseVisualStyleBackColor = true;
            this.btnPath_Zip.Click += new System.EventHandler(this.btnPath_Zip_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(7, 36);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(221, 20);
            this.txtPath.TabIndex = 1;
            this.txtPath.Text = "C:\\";
            // 
            // backup_box
            // 
            this.backup_box.Controls.Add(this.btnMysqlPath);
            this.backup_box.Controls.Add(this.label2);
            this.backup_box.Controls.Add(this.txtmySqlPath);
            this.backup_box.Controls.Add(this.label3);
            this.backup_box.Controls.Add(this.txtFilename);
            this.backup_box.Controls.Add(this.label1);
            this.backup_box.Controls.Add(this.btnPathBackup);
            this.backup_box.Controls.Add(this.txtPath);
            this.backup_box.Location = new System.Drawing.Point(12, 12);
            this.backup_box.Name = "backup_box";
            this.backup_box.Size = new System.Drawing.Size(330, 150);
            this.backup_box.TabIndex = 16;
            this.backup_box.TabStop = false;
            this.backup_box.Text = "Datenbank sichern";
            // 
            // btnStartBackup
            // 
            this.btnStartBackup.Image = global::Universal_Management.Properties.Resources.Save_icon;
            this.btnStartBackup.Location = new System.Drawing.Point(12, 367);
            this.btnStartBackup.Name = "btnStartBackup";
            this.btnStartBackup.Size = new System.Drawing.Size(136, 43);
            this.btnStartBackup.TabIndex = 15;
            this.btnStartBackup.Text = "   Daten sichern";
            this.btnStartBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStartBackup.UseVisualStyleBackColor = true;
            this.btnStartBackup.Click += new System.EventHandler(this.btnStartBackup_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Universal_Management.Properties.Resources.door_in_icon;
            this.btnClose.Location = new System.Drawing.Point(208, 367);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 43);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "   Schließen";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 349);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 73);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // UM_Backup
            // 
            this.AcceptButton = this.btnStartBackup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(356, 422);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.backup_box);
            this.Controls.Add(this.btnStartBackup);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UM_Backup";
            this.Text = "Daten sichern";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.backup_box.ResumeLayout(false);
            this.backup_box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPath_Zip;
        private System.Windows.Forms.Button btnMysqlPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmySqlPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZipPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFileZip;
        private System.Windows.Forms.Button btnPathBackup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPath_Zip;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.GroupBox backup_box;
        private System.Windows.Forms.Button btnStartBackup;
        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}