namespace Universal_Management
{
    partial class MyMessageBox
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
            this.txtText = new System.Windows.Forms.Label();
            this.btnNein = new System.Windows.Forms.Button();
            this.btnJa = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtText
            // 
            this.txtText.AutoSize = true;
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(12, 9);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(39, 13);
            this.txtText.TabIndex = 4;
            this.txtText.Text = "txtText";
            // 
            // btnNein
            // 
            this.btnNein.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNein.Location = new System.Drawing.Point(165, 13);
            this.btnNein.Name = "btnNein";
            this.btnNein.Size = new System.Drawing.Size(86, 28);
            this.btnNein.TabIndex = 2;
            this.btnNein.Text = "Ignorieren";
            this.btnNein.UseVisualStyleBackColor = true;
            // 
            // btnJa
            // 
            this.btnJa.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnJa.Location = new System.Drawing.Point(73, 13);
            this.btnJa.Name = "btnJa";
            this.btnJa.Size = new System.Drawing.Size(86, 28);
            this.btnJa.TabIndex = 1;
            this.btnJa.Text = "OK";
            this.btnJa.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.btnNein);
            this.panel1.Controls.Add(this.btnJa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 52);
            this.panel1.TabIndex = 5;
            // 
            // MyMessageBox
            // 
            this.AcceptButton = this.btnJa;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelButton = this.btnNein;
            this.ClientSize = new System.Drawing.Size(263, 124);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyMessageBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MyMessageBox_Load);
            this.Shown += new System.EventHandler(this.MyMessageBox_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label txtText;
        public System.Windows.Forms.Button btnNein;
        public System.Windows.Forms.Button btnJa;
        public System.Windows.Forms.Panel panel1;
    }
}