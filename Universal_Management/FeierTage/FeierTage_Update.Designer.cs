namespace Universal_Management
{
    partial class FeierTage_Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeierTage_Update));
            this.txtTag = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.txtMonat = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dateTimePicker_bis = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_von = new System.Windows.Forms.DateTimePicker();
            this.txtFeiertag = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFEID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMitarbeiter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtJahr = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTag
            // 
            this.txtTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTag.Enabled = false;
            this.txtTag.Items.AddRange(new object[] {
            "Montag",
            "Dienstag",
            "Mittwoch",
            "Donnerstag",
            "Freitag",
            "Samstag ",
            "Sonntag"});
            this.txtTag.Location = new System.Drawing.Point(104, 131);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(438, 21);
            this.txtTag.TabIndex = 57;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(389, 274);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 17);
            this.radioButton2.TabIndex = 56;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Nein";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // txtMonat
            // 
            this.txtMonat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtMonat.Enabled = false;
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
            this.txtMonat.Location = new System.Drawing.Point(104, 94);
            this.txtMonat.Name = "txtMonat";
            this.txtMonat.Size = new System.Drawing.Size(438, 21);
            this.txtMonat.TabIndex = 54;
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
            this.groupBox1.Size = new System.Drawing.Size(562, 311);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Feirtagdaten";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Jahr:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(233, 274);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 55;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Ja";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // dateTimePicker_bis
            // 
            this.dateTimePicker_bis.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker_bis.Enabled = false;
            this.dateTimePicker_bis.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_bis.Location = new System.Drawing.Point(104, 204);
            this.dateTimePicker_bis.Name = "dateTimePicker_bis";
            this.dateTimePicker_bis.Size = new System.Drawing.Size(438, 20);
            this.dateTimePicker_bis.TabIndex = 53;
            // 
            // dateTimePicker_von
            // 
            this.dateTimePicker_von.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker_von.Enabled = false;
            this.dateTimePicker_von.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_von.Location = new System.Drawing.Point(104, 170);
            this.dateTimePicker_von.Name = "dateTimePicker_von";
            this.dateTimePicker_von.Size = new System.Drawing.Size(438, 20);
            this.dateTimePicker_von.TabIndex = 52;
            // 
            // txtFeiertag
            // 
            this.txtFeiertag.Enabled = false;
            this.txtFeiertag.Location = new System.Drawing.Point(104, 239);
            this.txtFeiertag.Name = "txtFeiertag";
            this.txtFeiertag.Size = new System.Drawing.Size(438, 20);
            this.txtFeiertag.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Gesetzlicher Feiertag:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Feiertag:";
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSize = true;
            this.txtUsername.Location = new System.Drawing.Point(14, 134);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(85, 13);
            this.txtUsername.TabIndex = 38;
            this.txtUsername.Text = "Tag der Woche:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Datum bis:";
            // 
            // txtFEID
            // 
            this.txtFEID.Enabled = false;
            this.txtFEID.Location = new System.Drawing.Point(104, 24);
            this.txtFEID.Name = "txtFEID";
            this.txtFEID.Size = new System.Drawing.Size(438, 20);
            this.txtFEID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "FEID:";
            // 
            // txtMitarbeiter
            // 
            this.txtMitarbeiter.AutoSize = true;
            this.txtMitarbeiter.Location = new System.Drawing.Point(14, 170);
            this.txtMitarbeiter.Name = "txtMitarbeiter";
            this.txtMitarbeiter.Size = new System.Drawing.Size(62, 13);
            this.txtMitarbeiter.TabIndex = 23;
            this.txtMitarbeiter.Text = "Datum von:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Monat:";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnEdit.Image = global::Universal_Management.Properties.Resources.edit_icon32px1;
            this.btnEdit.Location = new System.Drawing.Point(12, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(136, 43);
            this.btnEdit.TabIndex = 60;
            this.btnEdit.Text = "   Bearbeiten";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnDel.Image = global::Universal_Management.Properties.Resources.delete_icon32px;
            this.btnDel.Location = new System.Drawing.Point(154, 19);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(136, 43);
            this.btnDel.TabIndex = 59;
            this.btnDel.Text = "   Löschen";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSave.Image = global::Universal_Management.Properties.Resources.Save_icon;
            this.btnSave.Location = new System.Drawing.Point(296, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 43);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "   Speichern";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Image = global::Universal_Management.Properties.Resources.door_in_icon;
            this.btnClose.Location = new System.Drawing.Point(438, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 43);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "   Schließen";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 337);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 73);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            // 
            // txtJahr
            // 
            this.txtJahr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtJahr.Enabled = false;
            this.txtJahr.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.txtJahr.Location = new System.Drawing.Point(104, 57);
            this.txtJahr.Name = "txtJahr";
            this.txtJahr.Size = new System.Drawing.Size(438, 21);
            this.txtJahr.TabIndex = 61;
            // 
            // FeierTage_Update
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(587, 410);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FeierTage_Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Feiertage Ansicht / Bearbeiten";
            this.Load += new System.EventHandler(this.FeierTage_Update_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtFeiertag;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label txtUsername;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.TextBox txtFEID;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label txtMitarbeiter;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnDel;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.ComboBox txtTag;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.ComboBox txtMonat;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.DateTimePicker dateTimePicker_bis;
        public System.Windows.Forms.DateTimePicker dateTimePicker_von;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox txtJahr;
    }
}