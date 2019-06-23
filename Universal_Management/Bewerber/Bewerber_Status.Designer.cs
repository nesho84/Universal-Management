namespace Universal_Management
{
    partial class Bewerber_Status
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bewerber_Status));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAktiv = new System.Windows.Forms.Button();
            this.txtMITID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Drucken Sie auf Aktiv, um diesen \r\nBewerber als Mitarbeiter zu wechseln.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Universal_Management.Properties.Resources.info24px;
            this.pictureBox1.Location = new System.Drawing.Point(43, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = global::Universal_Management.Properties.Resources.passive_small;
            this.button2.Location = new System.Drawing.Point(154, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 134);
            this.button2.TabIndex = 6;
            this.button2.Text = "Passive";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnAktiv
            // 
            this.btnAktiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAktiv.ForeColor = System.Drawing.Color.Green;
            this.btnAktiv.Image = global::Universal_Management.Properties.Resources.active_small;
            this.btnAktiv.Location = new System.Drawing.Point(13, 63);
            this.btnAktiv.Name = "btnAktiv";
            this.btnAktiv.Size = new System.Drawing.Size(135, 134);
            this.btnAktiv.TabIndex = 5;
            this.btnAktiv.Text = "Aktiv";
            this.btnAktiv.UseVisualStyleBackColor = true;
            this.btnAktiv.Click += new System.EventHandler(this.btnAktiv_Click);
            // 
            // txtMITID
            // 
            this.txtMITID.Location = new System.Drawing.Point(2, 2);
            this.txtMITID.Name = "txtMITID";
            this.txtMITID.Size = new System.Drawing.Size(35, 20);
            this.txtMITID.TabIndex = 11;
            // 
            // Bewerber_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 207);
            this.Controls.Add(this.txtMITID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAktiv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Bewerber_Status";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bewerber Status";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Bewerber_Status_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button btnAktiv;
        public System.Windows.Forms.TextBox txtMITID;
    }
}