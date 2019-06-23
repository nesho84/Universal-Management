namespace Universal_Management
{
    partial class Firmenbuch_Extra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Firmenbuch_Extra));
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox_error = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Status2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblSAdress = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboFirma = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblBeforlblAnzahl = new System.Windows.Forms.Label();
            this.lblAnzahl = new System.Windows.Forms.Label();
            this.lblUr = new System.Windows.Forms.Label();
            this.lblKr = new System.Windows.Forms.Label();
            this.lblAkt = new System.Windows.Forms.Label();
            this.picAkt = new System.Windows.Forms.Button();
            this.picKr = new System.Windows.Forms.Button();
            this.picUr = new System.Windows.Forms.Button();
            this.lblAnzahlAktiv = new System.Windows.Forms.Label();
            this.lblAnzahlKrank = new System.Windows.Forms.Label();
            this.lblAnzahlUrlaub = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.groupBox_error.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox_error);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Location = new System.Drawing.Point(12, 124);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(984, 362);
            this.panel4.TabIndex = 47;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // groupBox_error
            // 
            this.groupBox_error.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_error.Controls.Add(this.label1);
            this.groupBox_error.Location = new System.Drawing.Point(371, 140);
            this.groupBox_error.Name = "groupBox_error";
            this.groupBox_error.Size = new System.Drawing.Size(243, 83);
            this.groupBox_error.TabIndex = 42;
            this.groupBox_error.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(60, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Keine Daten vorhanden!";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CausesValidation = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status2});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(984, 362);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Status2
            // 
            this.Status2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status2.FillWeight = 45F;
            this.Status2.HeaderText = "Status";
            this.Status2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Status2.MinimumWidth = 45;
            this.Status2.Name = "Status2";
            this.Status2.ReadOnly = true;
            this.Status2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Status2.Visible = false;
            this.Status2.Width = 45;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(526, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.DimGray;
            this.lblEmail.Location = new System.Drawing.Point(8, 70);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "lblEmail";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.ForeColor = System.Drawing.Color.DimGray;
            this.lblTel.Location = new System.Drawing.Point(8, 50);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(32, 13);
            this.lblTel.TabIndex = 3;
            this.lblTel.Text = "lblTel";
            // 
            // lblSAdress
            // 
            this.lblSAdress.AutoSize = true;
            this.lblSAdress.ForeColor = System.Drawing.Color.DimGray;
            this.lblSAdress.Location = new System.Drawing.Point(8, 30);
            this.lblSAdress.Name = "lblSAdress";
            this.lblSAdress.Size = new System.Drawing.Size(49, 13);
            this.lblSAdress.TabIndex = 2;
            this.lblSAdress.Text = "lblAdress";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.DimGray;
            this.lblName.Location = new System.Drawing.Point(8, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "lblName";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblEmail);
            this.panel2.Controls.Add(this.lblSAdress);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.lblTel);
            this.panel2.Location = new System.Drawing.Point(729, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 94);
            this.panel2.TabIndex = 38;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(32, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bitte wählen Sie einen Kunden:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboFirma);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 94);
            this.panel1.TabIndex = 45;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboFirma
            // 
            this.comboFirma.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboFirma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboFirma.DropDownHeight = 200;
            this.comboFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFirma.FormattingEnabled = true;
            this.comboFirma.IntegralHeight = false;
            this.comboFirma.ItemHeight = 20;
            this.comboFirma.Location = new System.Drawing.Point(18, 46);
            this.comboFirma.Name = "comboFirma";
            this.comboFirma.Size = new System.Drawing.Size(462, 28);
            this.comboFirma.TabIndex = 38;
            this.comboFirma.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboFirma.SelectedIndexChanged += new System.EventHandler(this.comboFirma_SelectedIndexChanged);
            this.comboFirma.SelectionChangeCommitted += new System.EventHandler(this.comboFirma_SelectionChangeCommitted);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnPrint);
            this.groupBox7.Controls.Add(this.button2);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(0, 538);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1008, 73);
            this.groupBox7.TabIndex = 189;
            this.groupBox7.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::Universal_Management.Properties.Resources.Print_Icon32px;
            this.btnPrint.Location = new System.Drawing.Point(718, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(136, 43);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "   Drucken";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Image = global::Universal_Management.Properties.Resources.door_in_icon;
            this.button2.Location = new System.Drawing.Point(860, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 43);
            this.button2.TabIndex = 17;
            this.button2.Text = "   Schließen";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblBeforlblAnzahl
            // 
            this.lblBeforlblAnzahl.AutoSize = true;
            this.lblBeforlblAnzahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeforlblAnzahl.ForeColor = System.Drawing.Color.DimGray;
            this.lblBeforlblAnzahl.Location = new System.Drawing.Point(810, 509);
            this.lblBeforlblAnzahl.Name = "lblBeforlblAnzahl";
            this.lblBeforlblAnzahl.Size = new System.Drawing.Size(149, 15);
            this.lblBeforlblAnzahl.TabIndex = 39;
            this.lblBeforlblAnzahl.Text = "Anzahl der Mitarbeiter   =  ";
            // 
            // lblAnzahl
            // 
            this.lblAnzahl.AutoSize = true;
            this.lblAnzahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnzahl.ForeColor = System.Drawing.Color.DimGray;
            this.lblAnzahl.Location = new System.Drawing.Point(958, 509);
            this.lblAnzahl.Name = "lblAnzahl";
            this.lblAnzahl.Size = new System.Drawing.Size(15, 15);
            this.lblAnzahl.TabIndex = 190;
            this.lblAnzahl.Text = "0";
            // 
            // lblUr
            // 
            this.lblUr.AutoSize = true;
            this.lblUr.Enabled = false;
            this.lblUr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUr.Location = new System.Drawing.Point(262, 504);
            this.lblUr.Name = "lblUr";
            this.lblUr.Size = new System.Drawing.Size(105, 14);
            this.lblUr.TabIndex = 5;
            this.lblUr.Text = "Mitarbeiter in Urlaub ";
            // 
            // lblKr
            // 
            this.lblKr.AutoSize = true;
            this.lblKr.Enabled = false;
            this.lblKr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKr.Location = new System.Drawing.Point(154, 504);
            this.lblKr.Name = "lblKr";
            this.lblKr.Size = new System.Drawing.Size(77, 14);
            this.lblKr.TabIndex = 4;
            this.lblKr.Text = "Krankenstand ";
            // 
            // lblAkt
            // 
            this.lblAkt.AutoSize = true;
            this.lblAkt.Enabled = false;
            this.lblAkt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAkt.Location = new System.Drawing.Point(37, 505);
            this.lblAkt.Name = "lblAkt";
            this.lblAkt.Size = new System.Drawing.Size(86, 14);
            this.lblAkt.TabIndex = 3;
            this.lblAkt.Text = "Mitarbeiter Aktiv ";
            // 
            // picAkt
            // 
            this.picAkt.BackgroundImage = global::Universal_Management.Properties.Resources.active_small;
            this.picAkt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAkt.Enabled = false;
            this.picAkt.FlatAppearance.BorderSize = 0;
            this.picAkt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.picAkt.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picAkt.ForeColor = System.Drawing.Color.White;
            this.picAkt.Location = new System.Drawing.Point(12, 498);
            this.picAkt.Name = "picAkt";
            this.picAkt.Size = new System.Drawing.Size(24, 24);
            this.picAkt.TabIndex = 191;
            this.picAkt.UseVisualStyleBackColor = true;
            // 
            // picKr
            // 
            this.picKr.BackgroundImage = global::Universal_Management.Properties.Resources.passive_small;
            this.picKr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picKr.Enabled = false;
            this.picKr.FlatAppearance.BorderSize = 0;
            this.picKr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.picKr.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picKr.ForeColor = System.Drawing.Color.White;
            this.picKr.Location = new System.Drawing.Point(129, 498);
            this.picKr.Name = "picKr";
            this.picKr.Size = new System.Drawing.Size(24, 24);
            this.picKr.TabIndex = 192;
            this.picKr.UseVisualStyleBackColor = true;
            // 
            // picUr
            // 
            this.picUr.BackgroundImage = global::Universal_Management.Properties.Resources.Murlaub_info;
            this.picUr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picUr.Enabled = false;
            this.picUr.FlatAppearance.BorderSize = 0;
            this.picUr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.picUr.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picUr.ForeColor = System.Drawing.Color.White;
            this.picUr.Location = new System.Drawing.Point(237, 498);
            this.picUr.Name = "picUr";
            this.picUr.Size = new System.Drawing.Size(24, 24);
            this.picUr.TabIndex = 193;
            this.picUr.UseVisualStyleBackColor = true;
            // 
            // lblAnzahlAktiv
            // 
            this.lblAnzahlAktiv.AutoSize = true;
            this.lblAnzahlAktiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnzahlAktiv.ForeColor = System.Drawing.Color.DimGray;
            this.lblAnzahlAktiv.Location = new System.Drawing.Point(68, 517);
            this.lblAnzahlAktiv.Name = "lblAnzahlAktiv";
            this.lblAnzahlAktiv.Size = new System.Drawing.Size(22, 13);
            this.lblAnzahlAktiv.TabIndex = 194;
            this.lblAnzahlAktiv.Text = "(0)";
            // 
            // lblAnzahlKrank
            // 
            this.lblAnzahlKrank.AutoSize = true;
            this.lblAnzahlKrank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnzahlKrank.ForeColor = System.Drawing.Color.DimGray;
            this.lblAnzahlKrank.Location = new System.Drawing.Point(178, 518);
            this.lblAnzahlKrank.Name = "lblAnzahlKrank";
            this.lblAnzahlKrank.Size = new System.Drawing.Size(22, 13);
            this.lblAnzahlKrank.TabIndex = 195;
            this.lblAnzahlKrank.Text = "(0)";
            // 
            // lblAnzahlUrlaub
            // 
            this.lblAnzahlUrlaub.AutoSize = true;
            this.lblAnzahlUrlaub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnzahlUrlaub.ForeColor = System.Drawing.Color.DimGray;
            this.lblAnzahlUrlaub.Location = new System.Drawing.Point(296, 517);
            this.lblAnzahlUrlaub.Name = "lblAnzahlUrlaub";
            this.lblAnzahlUrlaub.Size = new System.Drawing.Size(22, 13);
            this.lblAnzahlUrlaub.TabIndex = 196;
            this.lblAnzahlUrlaub.Text = "(0)";
            // 
            // Firmenbuch_Extra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Universal_Management.Properties.Resources.url6_edited;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(1008, 611);
            this.Controls.Add(this.lblAnzahlUrlaub);
            this.Controls.Add(this.lblAnzahlKrank);
            this.Controls.Add(this.lblAnzahlAktiv);
            this.Controls.Add(this.picUr);
            this.Controls.Add(this.picKr);
            this.Controls.Add(this.lblUr);
            this.Controls.Add(this.lblBeforlblAnzahl);
            this.Controls.Add(this.picAkt);
            this.Controls.Add(this.lblAnzahl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblKr);
            this.Controls.Add(this.lblAkt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Firmenbuch_Extra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kundebuch Extra Optionen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Firmenbuch_Extra_FormClosing);
            this.Load += new System.EventHandler(this.Firmenbuch_Extra_Load);
            this.panel4.ResumeLayout(false);
            this.groupBox_error.ResumeLayout(false);
            this.groupBox_error.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox_error;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblSAdress;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblBeforlblAnzahl;
        private System.Windows.Forms.Label lblAnzahl;
        public System.Windows.Forms.Label lblUr;
        public System.Windows.Forms.Label lblKr;
        public System.Windows.Forms.Label lblAkt;
        public System.Windows.Forms.Button picAkt;
        public System.Windows.Forms.Button picKr;
        public System.Windows.Forms.Button picUr;
        private System.Windows.Forms.Label lblAnzahlAktiv;
        private System.Windows.Forms.Label lblAnzahlKrank;
        private System.Windows.Forms.Label lblAnzahlUrlaub;
        public System.Windows.Forms.ComboBox comboFirma;
        public System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewImageColumn Status2;
        public System.Windows.Forms.Label lblName;

    }
}