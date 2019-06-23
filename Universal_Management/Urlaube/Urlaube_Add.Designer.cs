namespace Universal_Management
{
    partial class Urlaube_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Urlaube_Add));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSchliessen = new System.Windows.Forms.Button();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.dateTimePicker_bis = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_von = new System.Windows.Forms.DateTimePicker();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtNachname = new System.Windows.Forms.TextBox();
            this.txtVorname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAnzahlTage = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtURLID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMitarbeiter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboDNr = new System.Windows.Forms.ComboBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnSchliessen);
            this.groupBox2.Controls.Add(this.btnSpeichern);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 73);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::Universal_Management.Properties.Resources.Print_Icon32px;
            this.btnPrint.Location = new System.Drawing.Point(154, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(136, 43);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "   Drucken";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSchliessen
            // 
            this.btnSchliessen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSchliessen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSchliessen.Image = global::Universal_Management.Properties.Resources.door_in_icon;
            this.btnSchliessen.Location = new System.Drawing.Point(296, 19);
            this.btnSchliessen.Name = "btnSchliessen";
            this.btnSchliessen.Size = new System.Drawing.Size(136, 43);
            this.btnSchliessen.TabIndex = 2;
            this.btnSchliessen.Text = "   Schließen";
            this.btnSchliessen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSchliessen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSchliessen.UseVisualStyleBackColor = true;
            this.btnSchliessen.Click += new System.EventHandler(this.btnSchliessen_Click);
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Enabled = false;
            this.btnSpeichern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSpeichern.Image = global::Universal_Management.Properties.Resources.Save_icon;
            this.btnSpeichern.Location = new System.Drawing.Point(12, 19);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(136, 43);
            this.btnSpeichern.TabIndex = 0;
            this.btnSpeichern.Tag = "save_just_urlaub";
            this.btnSpeichern.Text = "   Speichern";
            this.btnSpeichern.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSpeichern.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // dateTimePicker_bis
            // 
            this.dateTimePicker_bis.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker_bis.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_bis.Location = new System.Drawing.Point(99, 109);
            this.dateTimePicker_bis.Name = "dateTimePicker_bis";
            this.dateTimePicker_bis.Size = new System.Drawing.Size(230, 20);
            this.dateTimePicker_bis.TabIndex = 5;
            this.dateTimePicker_bis.ValueChanged += new System.EventHandler(this.dateTimePicker_bis_ValueChanged);
            // 
            // dateTimePicker_von
            // 
            this.dateTimePicker_von.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker_von.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_von.Location = new System.Drawing.Point(99, 75);
            this.dateTimePicker_von.Name = "dateTimePicker_von";
            this.dateTimePicker_von.Size = new System.Drawing.Size(230, 20);
            this.dateTimePicker_von.TabIndex = 4;
            this.dateTimePicker_von.ValueChanged += new System.EventHandler(this.dateTimePicker_von_ValueChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(344, 46);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(88, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "Zeitausgleich";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged_1);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(202, 46);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(88, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Sonderurlaub";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(99, 46);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(56, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Urlaub";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // txtNachname
            // 
            this.txtNachname.Location = new System.Drawing.Point(99, 204);
            this.txtNachname.Name = "txtNachname";
            this.txtNachname.ReadOnly = true;
            this.txtNachname.Size = new System.Drawing.Size(333, 20);
            this.txtNachname.TabIndex = 8;
            // 
            // txtVorname
            // 
            this.txtVorname.Location = new System.Drawing.Point(99, 174);
            this.txtVorname.Name = "txtVorname";
            this.txtVorname.ReadOnly = true;
            this.txtVorname.Size = new System.Drawing.Size(333, 20);
            this.txtVorname.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 93;
            this.label7.Text = "DNr.:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "Nachname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "Vorname:";
            // 
            // txtAnzahlTage
            // 
            this.txtAnzahlTage.Location = new System.Drawing.Point(99, 143);
            this.txtAnzahlTage.Name = "txtAnzahlTage";
            this.txtAnzahlTage.Size = new System.Drawing.Size(333, 20);
            this.txtAnzahlTage.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSize = true;
            this.txtUsername.Location = new System.Drawing.Point(9, 146);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(63, 13);
            this.txtUsername.TabIndex = 90;
            this.txtUsername.Text = "Arbeitstage:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 89;
            this.label5.Text = "Arbeitstage bis:";
            // 
            // txtURLID
            // 
            this.txtURLID.Location = new System.Drawing.Point(99, 13);
            this.txtURLID.Name = "txtURLID";
            this.txtURLID.ReadOnly = true;
            this.txtURLID.Size = new System.Drawing.Size(333, 20);
            this.txtURLID.TabIndex = 0;
            this.txtURLID.Text = "#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "URLID:";
            // 
            // txtMitarbeiter
            // 
            this.txtMitarbeiter.AutoSize = true;
            this.txtMitarbeiter.Location = new System.Drawing.Point(9, 75);
            this.txtMitarbeiter.Name = "txtMitarbeiter";
            this.txtMitarbeiter.Size = new System.Drawing.Size(84, 13);
            this.txtMitarbeiter.TabIndex = 87;
            this.txtMitarbeiter.Text = "Arbeitstage von:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "Typ:";
            // 
            // comboDNr
            // 
            this.comboDNr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDNr.FormattingEnabled = true;
            this.comboDNr.Location = new System.Drawing.Point(99, 234);
            this.comboDNr.Name = "comboDNr";
            this.comboDNr.Size = new System.Drawing.Size(333, 21);
            this.comboDNr.TabIndex = 9;
            this.comboDNr.SelectedIndexChanged += new System.EventHandler(this.txtDNNr_SelectedIndexChanged);
            this.comboDNr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNNr_KeyPress);
            // 
            // textBox25
            // 
            this.textBox25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox25.Location = new System.Drawing.Point(335, 75);
            this.textBox25.Name = "textBox25";
            this.textBox25.ReadOnly = true;
            this.textBox25.Size = new System.Drawing.Size(97, 20);
            this.textBox25.TabIndex = 245;
            this.textBox25.Text = "Tag-Monat-Jahr";
            this.textBox25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(335, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(97, 20);
            this.textBox1.TabIndex = 246;
            this.textBox1.Text = "Tag-Monat-Jahr";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Urlaube_Add
            // 
            this.AcceptButton = this.btnSpeichern;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnSchliessen;
            this.ClientSize = new System.Drawing.Size(444, 342);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox25);
            this.Controls.Add(this.comboDNr);
            this.Controls.Add(this.dateTimePicker_bis);
            this.Controls.Add(this.dateTimePicker_von);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.txtNachname);
            this.Controls.Add(this.txtVorname);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAnzahlTage);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtURLID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMitarbeiter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Urlaube_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Urlaub erstellen";
            this.Load += new System.EventHandler(this.Urlaube_Add_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnSchliessen;
        public System.Windows.Forms.Button btnSpeichern;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtNachname;
        public System.Windows.Forms.TextBox txtVorname;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtAnzahlTage;
        public System.Windows.Forms.Label txtUsername;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtURLID;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label txtMitarbeiter;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox25;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.ComboBox comboDNr;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.DateTimePicker dateTimePicker_bis;
        public System.Windows.Forms.DateTimePicker dateTimePicker_von;
        public System.Windows.Forms.RadioButton radioButton3;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
    }
}