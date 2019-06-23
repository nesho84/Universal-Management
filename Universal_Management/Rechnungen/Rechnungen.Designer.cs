namespace Universal_Management
{
    partial class Rechnungen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rechnungen));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.DropDown_Rechnungen = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnLoschen = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button1);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(0, 538);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(768, 73);
            this.groupBox7.TabIndex = 189;
            this.groupBox7.TabStop = false;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Image = global::Universal_Management.Properties.Resources.door_in_icon;
            this.button1.Location = new System.Drawing.Point(617, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 43);
            this.button1.TabIndex = 17;
            this.button1.Text = "   Schließen";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView2.Location = new System.Drawing.Point(12, 76);
            this.listView2.Name = "listView2";
            this.listView2.Scrollable = false;
            this.listView2.Size = new System.Drawing.Size(741, 456);
            this.listView2.TabIndex = 194;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.ItemActivate += new System.EventHandler(this.listView2_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Rechnungsliste";
            this.columnHeader1.Width = 744;
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(12, 47);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            this.tbFilePath.Size = new System.Drawing.Size(741, 20);
            this.tbFilePath.TabIndex = 191;
            // 
            // DropDown_Rechnungen
            // 
            this.DropDown_Rechnungen.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DropDown_Rechnungen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DropDown_Rechnungen.DropDownHeight = 200;
            this.DropDown_Rechnungen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDown_Rechnungen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DropDown_Rechnungen.FormattingEnabled = true;
            this.DropDown_Rechnungen.IntegralHeight = false;
            this.DropDown_Rechnungen.ItemHeight = 20;
            this.DropDown_Rechnungen.Location = new System.Drawing.Point(178, 11);
            this.DropDown_Rechnungen.Name = "DropDown_Rechnungen";
            this.DropDown_Rechnungen.Size = new System.Drawing.Size(482, 28);
            this.DropDown_Rechnungen.TabIndex = 196;
            this.DropDown_Rechnungen.SelectedIndexChanged += new System.EventHandler(this.DropDown_Rechnungen_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnLoschen
            // 
            this.btnLoschen.Enabled = false;
            this.btnLoschen.Image = global::Universal_Management.Properties.Resources.editdelete;
            this.btnLoschen.Location = new System.Drawing.Point(666, 10);
            this.btnLoschen.Name = "btnLoschen";
            this.btnLoschen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLoschen.Size = new System.Drawing.Size(87, 30);
            this.btnLoschen.TabIndex = 197;
            this.btnLoschen.Text = "Löschen";
            this.btnLoschen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoschen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoschen.UseVisualStyleBackColor = true;
            this.btnLoschen.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::Universal_Management.Properties.Resources.new_folder22px;
            this.btnCreate.Location = new System.Drawing.Point(12, 10);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCreate.Size = new System.Drawing.Size(161, 30);
            this.btnCreate.TabIndex = 192;
            this.btnCreate.Text = "   Ordner anlegen";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // Rechnungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Universal_Management.Properties.Resources.url6_edited;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(768, 611);
            this.Controls.Add(this.btnLoschen);
            this.Controls.Add(this.DropDown_Rechnungen);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.groupBox7);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Rechnungen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rechnungsliste";
            this.Load += new System.EventHandler(this.Rechnungen_Load);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.ListView listView2;
        public System.Windows.Forms.Button btnCreate;
        public System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.ComboBox DropDown_Rechnungen;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Button btnLoschen;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}