namespace Universal_Management
{
    partial class Dokumente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dokumente));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.rdoListIcon = new System.Windows.Forms.RadioButton();
            this.rdoDetailIcon = new System.Windows.Forms.RadioButton();
            this.rdoLargeIcon = new System.Windows.Forms.RadioButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ListBoxFolderPath = new System.Windows.Forms.ListBox();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button2);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(0, 534);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1008, 73);
            this.groupBox7.TabIndex = 190;
            this.groupBox7.TabStop = false;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Image = global::Universal_Management.Properties.Resources.door_in_icon;
            this.button2.Location = new System.Drawing.Point(860, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 43);
            this.button2.TabIndex = 17;
            this.button2.Text = "   Schließen";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rdoListIcon
            // 
            this.rdoListIcon.AutoSize = true;
            this.rdoListIcon.Location = new System.Drawing.Point(619, 496);
            this.rdoListIcon.Name = "rdoListIcon";
            this.rdoListIcon.Size = new System.Drawing.Size(47, 17);
            this.rdoListIcon.TabIndex = 198;
            this.rdoListIcon.Text = "Liste";
            this.rdoListIcon.UseVisualStyleBackColor = true;
            this.rdoListIcon.CheckedChanged += new System.EventHandler(this.rdoListIcon_CheckedChanged);
            // 
            // rdoDetailIcon
            // 
            this.rdoDetailIcon.AutoSize = true;
            this.rdoDetailIcon.Checked = true;
            this.rdoDetailIcon.Location = new System.Drawing.Point(672, 496);
            this.rdoDetailIcon.Name = "rdoDetailIcon";
            this.rdoDetailIcon.Size = new System.Drawing.Size(52, 17);
            this.rdoDetailIcon.TabIndex = 197;
            this.rdoDetailIcon.TabStop = true;
            this.rdoDetailIcon.Text = "Detail";
            this.rdoDetailIcon.UseVisualStyleBackColor = true;
            this.rdoDetailIcon.CheckedChanged += new System.EventHandler(this.rdoDetailIcon_CheckedChanged);
            // 
            // rdoLargeIcon
            // 
            this.rdoLargeIcon.AutoSize = true;
            this.rdoLargeIcon.Location = new System.Drawing.Point(516, 496);
            this.rdoLargeIcon.Name = "rdoLargeIcon";
            this.rdoLargeIcon.Size = new System.Drawing.Size(97, 17);
            this.rdoLargeIcon.TabIndex = 196;
            this.rdoLargeIcon.Text = "Große Symbole";
            this.rdoLargeIcon.UseVisualStyleBackColor = true;
            this.rdoLargeIcon.CheckedChanged += new System.EventHandler(this.rdoLargeIcon_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Filename});
            this.listView1.Location = new System.Drawing.Point(341, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(655, 467);
            this.listView1.TabIndex = 194;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // Filename
            // 
            this.Filename.Text = "Filename";
            this.Filename.Width = 237;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ListBoxFolderPath
            // 
            this.ListBoxFolderPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBoxFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxFolderPath.FormattingEnabled = true;
            this.ListBoxFolderPath.HorizontalScrollbar = true;
            this.ListBoxFolderPath.ItemHeight = 15;
            this.ListBoxFolderPath.Location = new System.Drawing.Point(12, 12);
            this.ListBoxFolderPath.Name = "ListBoxFolderPath";
            this.ListBoxFolderPath.Size = new System.Drawing.Size(314, 437);
            this.ListBoxFolderPath.TabIndex = 199;
            this.ListBoxFolderPath.SelectedIndexChanged += new System.EventHandler(this.ListBoxFolderPath_SelectedIndexChanged_1);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(11, 459);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            this.tbFilePath.Size = new System.Drawing.Size(314, 20);
            this.tbFilePath.TabIndex = 204;
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::Universal_Management.Properties.Resources.folder_new;
            this.btnCreate.Location = new System.Drawing.Point(760, 488);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(115, 32);
            this.btnCreate.TabIndex = 205;
            this.btnCreate.Text = "Neuer Ordner";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Enabled = false;
            this.btnOpenFolder.Image = global::Universal_Management.Properties.Resources.Folder_Open2_24px;
            this.btnOpenFolder.Location = new System.Drawing.Point(881, 488);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(115, 32);
            this.btnOpenFolder.TabIndex = 203;
            this.btnOpenFolder.Text = "   Ordner öffnen";
            this.btnOpenFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Enabled = false;
            this.btnLoad.Image = global::Universal_Management.Properties.Resources.upload_file24px;
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.Location = new System.Drawing.Point(341, 488);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(140, 32);
            this.btnLoad.TabIndex = 202;
            this.btnLoad.Text = "   Datei-Upload";
            this.btnLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Image = global::Universal_Management.Properties.Resources.folder_delete;
            this.button3.Location = new System.Drawing.Point(186, 488);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 32);
            this.button3.TabIndex = 201;
            this.button3.Text = "Pfad löschen";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Universal_Management.Properties.Resources.new_folder24px;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(11, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 32);
            this.button1.TabIndex = 200;
            this.button1.Text = "Neuen Pfad erstellen";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dokumente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Universal_Management.Properties.Resources.url6_edited;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(1008, 607);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListBoxFolderPath);
            this.Controls.Add(this.rdoListIcon);
            this.Controls.Add(this.rdoDetailIcon);
            this.Controls.Add(this.rdoLargeIcon);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox7);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Dokumente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dokumente";
            this.Load += new System.EventHandler(this.Dokumente_Load);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.ListBox ListBoxFolderPath;
        public System.Windows.Forms.Button btnOpenFolder;
        public System.Windows.Forms.Button btnLoad;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.Button btnCreate;
        public System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.RadioButton rdoListIcon;
        public System.Windows.Forms.RadioButton rdoDetailIcon;
        public System.Windows.Forms.RadioButton rdoLargeIcon;
        public System.Windows.Forms.ColumnHeader Filename;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.TextBox tbFilePath;
    }
}