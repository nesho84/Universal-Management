namespace Universal_Management
{
    partial class Mitarbeiter_DNr_Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mitarbeiter_DNr_Update));
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_DNr = new System.Windows.Forms.NumericUpDown();
            this.btnDNrSpeichern = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMITID = new System.Windows.Forms.Label();
            this.comboBox_lei = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBeschAls = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBrGehalt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.einTritt = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_DNr)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 50;
            this.label2.Text = "Dienstnummer:";
            // 
            // numeric_DNr
            // 
            this.numeric_DNr.Location = new System.Drawing.Point(12, 29);
            this.numeric_DNr.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_DNr.Name = "numeric_DNr";
            this.numeric_DNr.Size = new System.Drawing.Size(278, 20);
            this.numeric_DNr.TabIndex = 0;
            this.numeric_DNr.ValueChanged += new System.EventHandler(this.numeric_DNr_ValueChanged);
            // 
            // btnDNrSpeichern
            // 
            this.btnDNrSpeichern.Image = global::Universal_Management.Properties.Resources.Save_icon;
            this.btnDNrSpeichern.Location = new System.Drawing.Point(12, 19);
            this.btnDNrSpeichern.Name = "btnDNrSpeichern";
            this.btnDNrSpeichern.Size = new System.Drawing.Size(136, 43);
            this.btnDNrSpeichern.TabIndex = 0;
            this.btnDNrSpeichern.Tag = "mit_profile_open";
            this.btnDNrSpeichern.Text = "     Speichern";
            this.btnDNrSpeichern.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDNrSpeichern.UseVisualStyleBackColor = true;
            this.btnDNrSpeichern.Click += new System.EventHandler(this.btnDNrSpeichern_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnDNrSpeichern);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 336);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 73);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Universal_Management.Properties.Resources.door_in_icon;
            this.btnClose.Location = new System.Drawing.Point(154, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 43);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "     Abrechen";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMITID
            // 
            this.lblMITID.AutoSize = true;
            this.lblMITID.Location = new System.Drawing.Point(255, 2);
            this.lblMITID.Name = "lblMITID";
            this.lblMITID.Size = new System.Drawing.Size(47, 13);
            this.lblMITID.TabIndex = 55;
            this.lblMITID.Text = "lblMITID";
            this.lblMITID.Visible = false;
            // 
            // comboBox_lei
            // 
            this.comboBox_lei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_lei.FormattingEnabled = true;
            this.comboBox_lei.Items.AddRange(new object[] {
            "Nein"});
            this.comboBox_lei.Location = new System.Drawing.Point(12, 136);
            this.comboBox_lei.Name = "comboBox_lei";
            this.comboBox_lei.Size = new System.Drawing.Size(278, 21);
            this.comboBox_lei.Sorted = true;
            this.comboBox_lei.TabIndex = 2;
            this.comboBox_lei.SelectedIndexChanged += new System.EventHandler(this.comboBox_lei_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(9, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 249;
            this.label1.Text = "Beschäftigt bei:";
            // 
            // txtMS
            // 
            this.txtMS.Location = new System.Drawing.Point(12, 194);
            this.txtMS.Name = "txtMS";
            this.txtMS.Size = new System.Drawing.Size(278, 20);
            this.txtMS.TabIndex = 3;
            this.txtMS.TextChanged += new System.EventHandler(this.txtMS_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SeaGreen;
            this.label3.Location = new System.Drawing.Point(9, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 16);
            this.label3.TabIndex = 251;
            this.label3.Text = "Monatliche Arbeitsstunden:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SeaGreen;
            this.label4.Location = new System.Drawing.Point(9, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 253;
            this.label4.Text = "Beschäftigt als:";
            // 
            // txtBeschAls
            // 
            this.txtBeschAls.Location = new System.Drawing.Point(12, 81);
            this.txtBeschAls.Name = "txtBeschAls";
            this.txtBeschAls.Size = new System.Drawing.Size(278, 20);
            this.txtBeschAls.TabIndex = 1;
            this.txtBeschAls.TextChanged += new System.EventHandler(this.txtBeschAls_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SeaGreen;
            this.label5.Location = new System.Drawing.Point(9, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 255;
            this.label5.Text = "Brutto Gehalt:";
            // 
            // txtBrGehalt
            // 
            this.txtBrGehalt.Location = new System.Drawing.Point(12, 249);
            this.txtBrGehalt.Name = "txtBrGehalt";
            this.txtBrGehalt.Size = new System.Drawing.Size(278, 20);
            this.txtBrGehalt.TabIndex = 4;
            this.txtBrGehalt.TextChanged += new System.EventHandler(this.txtBrGehalt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SeaGreen;
            this.label6.Location = new System.Drawing.Point(9, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 257;
            this.label6.Text = "Eintritt:";
            // 
            // einTritt
            // 
            this.einTritt.CustomFormat = "yyyy-MM-dd";
            this.einTritt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.einTritt.Location = new System.Drawing.Point(12, 305);
            this.einTritt.Name = "einTritt";
            this.einTritt.Size = new System.Drawing.Size(278, 20);
            this.einTritt.TabIndex = 5;
            // 
            // Mitarbeiter_DNr_Update
            // 
            this.AcceptButton = this.btnDNrSpeichern;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(306, 409);
            this.Controls.Add(this.einTritt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBrGehalt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBeschAls);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_lei);
            this.Controls.Add(this.numeric_DNr);
            this.Controls.Add(this.lblMITID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mitarbeiter_DNr_Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mitarbeiter Daten Eingeben";
            this.Load += new System.EventHandler(this.Mitarbeiter_DNr_Update_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_DNr)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numeric_DNr;
        public System.Windows.Forms.Button btnDNrSpeichern;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblMITID;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.ComboBox comboBox_lei;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtMS;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtBeschAls;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtBrGehalt;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker einTritt;
    }
}