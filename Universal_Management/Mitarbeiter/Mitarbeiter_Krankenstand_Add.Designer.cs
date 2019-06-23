namespace Universal_Management
{
    partial class Mitarbeiter_Krankenstand_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mitarbeiter_Krankenstand_Add));
            this.dateTimePicker_bis = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_von = new System.Windows.Forms.DateTimePicker();
            this.txtDNNr = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAnzahlTage = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMITID = new System.Windows.Forms.TextBox();
            this.txtMitarbeiter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker_bis
            // 
            this.dateTimePicker_bis.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker_bis.CalendarTitleForeColor = System.Drawing.SystemColors.Window;
            this.dateTimePicker_bis.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker_bis.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_bis.Location = new System.Drawing.Point(109, 85);
            this.dateTimePicker_bis.Name = "dateTimePicker_bis";
            this.dateTimePicker_bis.Size = new System.Drawing.Size(323, 20);
            this.dateTimePicker_bis.TabIndex = 2;
            this.dateTimePicker_bis.ValueChanged += new System.EventHandler(this.dateTimePicker_bis_ValueChanged);
            // 
            // dateTimePicker_von
            // 
            this.dateTimePicker_von.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker_von.CalendarTitleForeColor = System.Drawing.SystemColors.Window;
            this.dateTimePicker_von.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker_von.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_von.Location = new System.Drawing.Point(109, 51);
            this.dateTimePicker_von.Name = "dateTimePicker_von";
            this.dateTimePicker_von.Size = new System.Drawing.Size(323, 20);
            this.dateTimePicker_von.TabIndex = 1;
            this.dateTimePicker_von.ValueChanged += new System.EventHandler(this.dateTimePicker_von_ValueChanged);
            // 
            // txtDNNr
            // 
            this.txtDNNr.Location = new System.Drawing.Point(109, 20);
            this.txtDNNr.Name = "txtDNNr";
            this.txtDNNr.ReadOnly = true;
            this.txtDNNr.Size = new System.Drawing.Size(323, 20);
            this.txtDNNr.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "DNr.:";
            // 
            // txtAnzahlTage
            // 
            this.txtAnzahlTage.Location = new System.Drawing.Point(109, 119);
            this.txtAnzahlTage.Name = "txtAnzahlTage";
            this.txtAnzahlTage.Size = new System.Drawing.Size(323, 20);
            this.txtAnzahlTage.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSize = true;
            this.txtUsername.Location = new System.Drawing.Point(16, 122);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(88, 13);
            this.txtUsername.TabIndex = 62;
            this.txtUsername.Text = "Anzahl der Tage:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Arbeitstage bis:";
            // 
            // lblMITID
            // 
            this.lblMITID.Enabled = false;
            this.lblMITID.Location = new System.Drawing.Point(2, 1);
            this.lblMITID.Name = "lblMITID";
            this.lblMITID.ReadOnly = true;
            this.lblMITID.Size = new System.Drawing.Size(42, 20);
            this.lblMITID.TabIndex = 55;
            this.lblMITID.Visible = false;
            // 
            // txtMitarbeiter
            // 
            this.txtMitarbeiter.AutoSize = true;
            this.txtMitarbeiter.Location = new System.Drawing.Point(16, 54);
            this.txtMitarbeiter.Name = "txtMitarbeiter";
            this.txtMitarbeiter.Size = new System.Drawing.Size(84, 13);
            this.txtMitarbeiter.TabIndex = 59;
            this.txtMitarbeiter.Text = "Arbeitstage von:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = ":";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSpeichern);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 73);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Image = global::Universal_Management.Properties.Resources.Save_icon;
            this.btnSpeichern.Location = new System.Drawing.Point(12, 19);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(136, 43);
            this.btnSpeichern.TabIndex = 0;
            this.btnSpeichern.Tag = "save_just_krankenstand";
            this.btnSpeichern.Text = "   Speichern";
            this.btnSpeichern.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Universal_Management.Properties.Resources.door_in_icon;
            this.btnClose.Location = new System.Drawing.Point(296, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 43);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "   Schließen";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Mitarbeiter_Krankenstand_Add
            // 
            this.AcceptButton = this.btnSpeichern;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(446, 229);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker_bis);
            this.Controls.Add(this.dateTimePicker_von);
            this.Controls.Add(this.txtDNNr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAnzahlTage);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMITID);
            this.Controls.Add(this.txtMitarbeiter);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mitarbeiter_Krankenstand_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mitarbeiter Krankenstand erstellen";
            this.Load += new System.EventHandler(this.Mitarbeiter_Krankenstand_Add_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtDNNr;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtAnzahlTage;
        public System.Windows.Forms.Label txtUsername;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox lblMITID;
        public System.Windows.Forms.Label txtMitarbeiter;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnSpeichern;
        public System.Windows.Forms.DateTimePicker dateTimePicker_bis;
        public System.Windows.Forms.DateTimePicker dateTimePicker_von;
        public System.Windows.Forms.GroupBox groupBox1;

    }
}