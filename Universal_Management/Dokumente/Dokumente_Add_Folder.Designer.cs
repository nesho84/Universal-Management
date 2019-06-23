namespace Universal_Management
{
    partial class Dokumente_Add_Folder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dokumente_Add_Folder));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDNrSpeichern = new System.Windows.Forms.Button();
            this.TextBoxFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnDNrSpeichern);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 73);
            this.groupBox1.TabIndex = 195;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.CausesValidation = false;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Image = global::Universal_Management.Properties.Resources.door_in_icon;
            this.button1.Location = new System.Drawing.Point(157, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 43);
            this.button1.TabIndex = 56;
            this.button1.Text = "     Abrechen";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDNrSpeichern
            // 
            this.btnDNrSpeichern.Image = global::Universal_Management.Properties.Resources.Save_icon;
            this.btnDNrSpeichern.Location = new System.Drawing.Point(12, 19);
            this.btnDNrSpeichern.Name = "btnDNrSpeichern";
            this.btnDNrSpeichern.Size = new System.Drawing.Size(136, 43);
            this.btnDNrSpeichern.TabIndex = 54;
            this.btnDNrSpeichern.Text = "     Speichern";
            this.btnDNrSpeichern.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDNrSpeichern.UseVisualStyleBackColor = true;
            this.btnDNrSpeichern.Click += new System.EventHandler(this.btnDNrSpeichern_Click);
            // 
            // TextBoxFolderPath
            // 
            this.TextBoxFolderPath.AcceptsReturn = true;
            this.TextBoxFolderPath.Location = new System.Drawing.Point(12, 31);
            this.TextBoxFolderPath.Name = "TextBoxFolderPath";
            this.TextBoxFolderPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxFolderPath.Size = new System.Drawing.Size(281, 20);
            this.TextBoxFolderPath.TabIndex = 196;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 197;
            this.label1.Text = "Ordner Name eingeben:";
            // 
            // Dokumente_Add_Folder
            // 
            this.AcceptButton = this.btnDNrSpeichern;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(307, 131);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TextBoxFolderPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Dokumente_Add_Folder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Neuer Ordner";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dokumente_Add_Folder_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btnDNrSpeichern;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TextBoxFolderPath;
    }
}