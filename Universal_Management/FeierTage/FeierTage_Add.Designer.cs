namespace Universal_Management
{
    partial class FeierTage_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeierTage_Add));
            this.dateTimePicker_bis = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_von = new System.Windows.Forms.DateTimePicker();
            this.txtFeiertag = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFEID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtMitarbeiter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtJahr = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtMonat = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker_bis
            // 
            this.dateTimePicker_bis.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker_bis.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_bis.Location = new System.Drawing.Point(106, 196);
            this.dateTimePicker_bis.Name = "dateTimePicker_bis";
            this.dateTimePicker_bis.Size = new System.Drawing.Size(268, 20);
            this.dateTimePicker_bis.TabIndex = 53;
            // 
            // dateTimePicker_von
            // 
            this.dateTimePicker_von.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker_von.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_von.Location = new System.Drawing.Point(106, 162);
            this.dateTimePicker_von.Name = "dateTimePicker_von";
            this.dateTimePicker_von.Size = new System.Drawing.Size(268, 20);
            this.dateTimePicker_von.TabIndex = 52;
            // 
            // txtFeiertag
            // 
            this.txtFeiertag.Location = new System.Drawing.Point(106, 230);
            this.txtFeiertag.Name = "txtFeiertag";
            this.txtFeiertag.Size = new System.Drawing.Size(268, 20);
            this.txtFeiertag.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Gesetzlicher Feiertag:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Feiertag:";
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSize = true;
            this.txtUsername.Location = new System.Drawing.Point(16, 130);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(85, 13);
            this.txtUsername.TabIndex = 38;
            this.txtUsername.Text = "Tag der Woche:";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.Image = global::Universal_Management.Properties.Resources.door_in_icon;
            this.button1.Location = new System.Drawing.Point(270, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 43);
            this.button1.TabIndex = 8;
            this.button1.Text = "   Schließen";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Datum bis:";
            // 
            // txtFEID
            // 
            this.txtFEID.Enabled = false;
            this.txtFEID.Location = new System.Drawing.Point(106, 27);
            this.txtFEID.Name = "txtFEID";
            this.txtFEID.ReadOnly = true;
            this.txtFEID.Size = new System.Drawing.Size(268, 20);
            this.txtFEID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "FEID:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button2.Image = global::Universal_Management.Properties.Resources.Save_icon;
            this.button2.Location = new System.Drawing.Point(12, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 43);
            this.button2.TabIndex = 7;
            this.button2.Text = "   Speichern";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtMitarbeiter
            // 
            this.txtMitarbeiter.AutoSize = true;
            this.txtMitarbeiter.Location = new System.Drawing.Point(16, 162);
            this.txtMitarbeiter.Name = "txtMitarbeiter";
            this.txtMitarbeiter.Size = new System.Drawing.Size(62, 13);
            this.txtMitarbeiter.TabIndex = 23;
            this.txtMitarbeiter.Text = "Datum von:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Monat:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtJahr);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTag);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.txtMonat);
            this.groupBox1.Controls.Add(this.dateTimePicker_bis);
            this.groupBox1.Controls.Add(this.dateTimePicker_von);
            this.groupBox1.Controls.Add(this.txtFeiertag);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtFEID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMitarbeiter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 300);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Feirtagdaten";
            // 
            // txtJahr
            // 
            this.txtJahr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtJahr.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.txtJahr.Location = new System.Drawing.Point(106, 59);
            this.txtJahr.Name = "txtJahr";
            this.txtJahr.Size = new System.Drawing.Size(268, 21);
            this.txtJahr.TabIndex = 59;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Jahr:";
            // 
            // txtTag
            // 
            this.txtTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTag.Items.AddRange(new object[] {
            "Montag",
            "Dienstag",
            "Mittwoch",
            "Donnerstag",
            "Freitag",
            "Samstag ",
            "Sonntag"});
            this.txtTag.Location = new System.Drawing.Point(106, 126);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(268, 21);
            this.txtTag.TabIndex = 57;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(258, 262);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 17);
            this.radioButton2.TabIndex = 56;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Nein";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(159, 263);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 55;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Ja";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtMonat
            // 
            this.txtMonat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtMonat.Items.AddRange(new object[] {
            "Jänner",
            "Februar",
            "März",
            "April",
            "Mai",
            "Juni",
            "Juli",
            "August",
            "September",
            "Oktober",
            "November",
            "Dezember"});
            this.txtMonat.Location = new System.Drawing.Point(106, 93);
            this.txtMonat.Name = "txtMonat";
            this.txtMonat.Size = new System.Drawing.Size(268, 21);
            this.txtMonat.TabIndex = 54;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 323);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 73);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // FeierTage_Add
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(420, 396);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FeierTage_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Feiertag erstellen";
            this.Load += new System.EventHandler(this.FeierTage_Add_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_bis;
        private System.Windows.Forms.DateTimePicker dateTimePicker_von;
        public System.Windows.Forms.TextBox txtFeiertag;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label txtUsername;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtFEID;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label txtMitarbeiter;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox txtMonat;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox txtTag;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox txtJahr;
        public System.Windows.Forms.Label label7;
    }
}