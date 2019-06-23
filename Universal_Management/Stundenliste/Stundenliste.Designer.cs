namespace Universal_Management
{
    partial class Stundenliste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stundenliste));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAddMonStd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboDNr = new System.Windows.Forms.ComboBox();
            this.txtNachname = new System.Windows.Forms.TextBox();
            this.txtVorname = new System.Windows.Forms.TextBox();
            this.comboJahr = new System.Windows.Forms.ComboBox();
            this.comboMonat = new System.Windows.Forms.ComboBox();
            this.lblJahr = new System.Windows.Forms.Label();
            this.lblMonat = new System.Windows.Forms.Label();
            this.txtDif = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIst = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoll = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnStdLoschen = new System.Windows.Forms.Button();
            this.btnKonto = new System.Windows.Forms.Button();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button2);
            this.groupBox7.Controls.Add(this.button1);
            this.groupBox7.Controls.Add(this.btnPrint);
            this.groupBox7.Controls.Add(this.btnAddMonStd);
            this.groupBox7.Controls.Add(this.btnClose);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(0, 538);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1008, 73);
            this.groupBox7.TabIndex = 189;
            this.groupBox7.TabStop = false;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Image = global::Universal_Management.Properties.Resources.add_Stunden;
            this.button2.Location = new System.Drawing.Point(154, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 43);
            this.button2.TabIndex = 22;
            this.button2.TabStop = false;
            this.button2.Text = "   Wochentlich";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Image = global::Universal_Management.Properties.Resources.add_Stunden;
            this.button1.Location = new System.Drawing.Point(296, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 43);
            this.button1.TabIndex = 21;
            this.button1.TabStop = false;
            this.button1.Text = "   Täglich";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::Universal_Management.Properties.Resources.Print_Icon32px;
            this.btnPrint.Location = new System.Drawing.Point(718, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(136, 43);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "   Drucken";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddMonStd
            // 
            this.btnAddMonStd.Image = global::Universal_Management.Properties.Resources.add_Stunden;
            this.btnAddMonStd.Location = new System.Drawing.Point(12, 20);
            this.btnAddMonStd.Name = "btnAddMonStd";
            this.btnAddMonStd.Size = new System.Drawing.Size(136, 43);
            this.btnAddMonStd.TabIndex = 20;
            this.btnAddMonStd.TabStop = false;
            this.btnAddMonStd.Text = "   Monatlich";
            this.btnAddMonStd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMonStd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddMonStd.UseVisualStyleBackColor = true;
            this.btnAddMonStd.Click += new System.EventHandler(this.btnBearbeiten_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Universal_Management.Properties.Resources.door_in_icon;
            this.btnClose.Location = new System.Drawing.Point(860, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 43);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "   Schließen";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 195;
            this.label1.Text = "DNr.";
            // 
            // comboDNr
            // 
            this.comboDNr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDNr.FormattingEnabled = true;
            this.comboDNr.Location = new System.Drawing.Point(45, 12);
            this.comboDNr.Name = "comboDNr";
            this.comboDNr.Size = new System.Drawing.Size(132, 21);
            this.comboDNr.TabIndex = 194;
            this.comboDNr.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboDNr.SelectedIndexChanged += new System.EventHandler(this.comboDNr_SelectedIndexChanged);
            this.comboDNr.SelectionChangeCommitted += new System.EventHandler(this.comboDNr_SelectionChangeCommitted);
            // 
            // txtNachname
            // 
            this.txtNachname.Location = new System.Drawing.Point(325, 13);
            this.txtNachname.Name = "txtNachname";
            this.txtNachname.ReadOnly = true;
            this.txtNachname.Size = new System.Drawing.Size(136, 20);
            this.txtNachname.TabIndex = 197;
            this.txtNachname.TabStop = false;
            // 
            // txtVorname
            // 
            this.txtVorname.Location = new System.Drawing.Point(183, 13);
            this.txtVorname.Name = "txtVorname";
            this.txtVorname.ReadOnly = true;
            this.txtVorname.Size = new System.Drawing.Size(136, 20);
            this.txtVorname.TabIndex = 196;
            this.txtVorname.TabStop = false;
            // 
            // comboJahr
            // 
            this.comboJahr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboJahr.FormattingEnabled = true;
            this.comboJahr.Items.AddRange(new object[] {
            "2022",
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014",
            "2013"});
            this.comboJahr.Location = new System.Drawing.Point(504, 12);
            this.comboJahr.Name = "comboJahr";
            this.comboJahr.Size = new System.Drawing.Size(136, 21);
            this.comboJahr.TabIndex = 198;
            this.comboJahr.Visible = false;
            this.comboJahr.SelectedIndexChanged += new System.EventHandler(this.comboJahr_SelectedIndexChanged);
            // 
            // comboMonat
            // 
            this.comboMonat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMonat.FormattingEnabled = true;
            this.comboMonat.Items.AddRange(new object[] {
            "Januar",
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
            this.comboMonat.Location = new System.Drawing.Point(689, 12);
            this.comboMonat.Name = "comboMonat";
            this.comboMonat.Size = new System.Drawing.Size(132, 21);
            this.comboMonat.TabIndex = 199;
            this.comboMonat.Visible = false;
            this.comboMonat.DropDown += new System.EventHandler(this.comboMonat_DropDown);
            this.comboMonat.SelectedIndexChanged += new System.EventHandler(this.comboMonat_SelectedIndexChanged);
            // 
            // lblJahr
            // 
            this.lblJahr.AutoSize = true;
            this.lblJahr.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJahr.Location = new System.Drawing.Point(472, 17);
            this.lblJahr.Name = "lblJahr";
            this.lblJahr.Size = new System.Drawing.Size(30, 12);
            this.lblJahr.TabIndex = 200;
            this.lblJahr.Text = "Jahr";
            this.lblJahr.Visible = false;
            // 
            // lblMonat
            // 
            this.lblMonat.AutoSize = true;
            this.lblMonat.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonat.Location = new System.Drawing.Point(647, 17);
            this.lblMonat.Name = "lblMonat";
            this.lblMonat.Size = new System.Drawing.Size(39, 12);
            this.lblMonat.TabIndex = 201;
            this.lblMonat.Text = "Monat";
            this.lblMonat.Visible = false;
            // 
            // txtDif
            // 
            this.txtDif.Location = new System.Drawing.Point(718, 512);
            this.txtDif.Name = "txtDif";
            this.txtDif.ReadOnly = true;
            this.txtDif.Size = new System.Drawing.Size(136, 20);
            this.txtDif.TabIndex = 203;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(716, 497);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 12);
            this.label4.TabIndex = 204;
            this.label4.Text = "Stunden Differenz +/-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(574, 497);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 12);
            this.label5.TabIndex = 206;
            this.label5.Text = "Gesamt Std.";
            // 
            // txtIst
            // 
            this.txtIst.Location = new System.Drawing.Point(576, 512);
            this.txtIst.Name = "txtIst";
            this.txtIst.ReadOnly = true;
            this.txtIst.Size = new System.Drawing.Size(136, 20);
            this.txtIst.TabIndex = 205;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(432, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 12);
            this.label6.TabIndex = 208;
            this.label6.Text = "Monatliche Std.";
            // 
            // txtSoll
            // 
            this.txtSoll.Location = new System.Drawing.Point(434, 512);
            this.txtSoll.Name = "txtSoll";
            this.txtSoll.ReadOnly = true;
            this.txtSoll.Size = new System.Drawing.Size(136, 20);
            this.txtSoll.TabIndex = 207;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(0, 48);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1008, 436);
            this.dataGridView1.TabIndex = 212;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // btnStdLoschen
            // 
            this.btnStdLoschen.Enabled = false;
            this.btnStdLoschen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStdLoschen.Image = global::Universal_Management.Properties.Resources.editdelete16px;
            this.btnStdLoschen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStdLoschen.Location = new System.Drawing.Point(860, 10);
            this.btnStdLoschen.Name = "btnStdLoschen";
            this.btnStdLoschen.Size = new System.Drawing.Size(136, 24);
            this.btnStdLoschen.TabIndex = 213;
            this.btnStdLoschen.Text = " Stunden löschen";
            this.btnStdLoschen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStdLoschen.UseVisualStyleBackColor = true;
            this.btnStdLoschen.Click += new System.EventHandler(this.btnStdLoschen_Click);
            // 
            // btnKonto
            // 
            this.btnKonto.Enabled = false;
            this.btnKonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKonto.Image = global::Universal_Management.Properties.Resources.Stunden_Konto16px;
            this.btnKonto.Location = new System.Drawing.Point(860, 510);
            this.btnKonto.Name = "btnKonto";
            this.btnKonto.Size = new System.Drawing.Size(136, 24);
            this.btnKonto.TabIndex = 23;
            this.btnKonto.Text = " Stunden Konto";
            this.btnKonto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKonto.UseVisualStyleBackColor = true;
            this.btnKonto.Click += new System.EventHandler(this.btnKonto_Click);
            // 
            // Stundenliste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Universal_Management.Properties.Resources.url6_edited;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1008, 611);
            this.Controls.Add(this.btnStdLoschen);
            this.Controls.Add(this.btnKonto);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSoll);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIst);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDif);
            this.Controls.Add(this.lblMonat);
            this.Controls.Add(this.lblJahr);
            this.Controls.Add(this.comboMonat);
            this.Controls.Add(this.comboJahr);
            this.Controls.Add(this.txtNachname);
            this.Controls.Add(this.txtVorname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDNr);
            this.Controls.Add(this.groupBox7);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Stundenliste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stundenliste";
            this.Load += new System.EventHandler(this.Stundenliste_Load);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.Button btnAddMonStd;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Button btnKonto;
        public System.Windows.Forms.ComboBox comboDNr;
        public System.Windows.Forms.TextBox txtNachname;
        public System.Windows.Forms.TextBox txtVorname;
        public System.Windows.Forms.ComboBox comboJahr;
        public System.Windows.Forms.ComboBox comboMonat;
        public System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblJahr;
        public System.Windows.Forms.Label lblMonat;
        public System.Windows.Forms.TextBox txtDif;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtIst;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtSoll;
        public System.Windows.Forms.Button btnStdLoschen;
    }
}