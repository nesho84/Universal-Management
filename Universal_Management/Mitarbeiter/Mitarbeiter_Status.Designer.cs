namespace Universal_Management
{
    partial class Mitarbeiter_Status
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mitarbeiter_Status));
            this.txtM_DNr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnKrank = new System.Windows.Forms.Button();
            this.btnAktiv = new System.Windows.Forms.Button();
            this.btnUrlaub = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtM_DNr
            // 
            this.txtM_DNr.Location = new System.Drawing.Point(403, 3);
            this.txtM_DNr.Name = "txtM_DNr";
            this.txtM_DNr.ReadOnly = true;
            this.txtM_DNr.Size = new System.Drawing.Size(35, 20);
            this.txtM_DNr.TabIndex = 16;
            this.txtM_DNr.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mitarbeiterstatus ändern.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Universal_Management.Properties.Resources.info24px;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnKrank
            // 
            this.btnKrank.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKrank.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKrank.Image = global::Universal_Management.Properties.Resources.passive_small;
            this.btnKrank.Location = new System.Drawing.Point(153, 51);
            this.btnKrank.Name = "btnKrank";
            this.btnKrank.Size = new System.Drawing.Size(135, 134);
            this.btnKrank.TabIndex = 13;
            this.btnKrank.Text = "Krank";
            this.btnKrank.UseVisualStyleBackColor = true;
            this.btnKrank.Click += new System.EventHandler(this.btnKrank_Click);
            // 
            // btnAktiv
            // 
            this.btnAktiv.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAktiv.ForeColor = System.Drawing.Color.White;
            this.btnAktiv.Image = global::Universal_Management.Properties.Resources.active_small;
            this.btnAktiv.Location = new System.Drawing.Point(12, 51);
            this.btnAktiv.Name = "btnAktiv";
            this.btnAktiv.Size = new System.Drawing.Size(135, 134);
            this.btnAktiv.TabIndex = 12;
            this.btnAktiv.Text = "Aktiv";
            this.btnAktiv.UseVisualStyleBackColor = true;
            this.btnAktiv.Click += new System.EventHandler(this.btnAktiv_Click);
            // 
            // btnUrlaub
            // 
            this.btnUrlaub.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUrlaub.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUrlaub.Image = global::Universal_Management.Properties.Resources.Murlaub;
            this.btnUrlaub.Location = new System.Drawing.Point(294, 51);
            this.btnUrlaub.Name = "btnUrlaub";
            this.btnUrlaub.Size = new System.Drawing.Size(135, 134);
            this.btnUrlaub.TabIndex = 17;
            this.btnUrlaub.Text = "Urlaub";
            this.btnUrlaub.UseVisualStyleBackColor = true;
            this.btnUrlaub.Click += new System.EventHandler(this.btnUrlaub_Click);
            // 
            // Mitarbeiter_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 196);
            this.Controls.Add(this.btnUrlaub);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnKrank);
            this.Controls.Add(this.btnAktiv);
            this.Controls.Add(this.txtM_DNr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mitarbeiter_Status";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Status ändern ";
            this.Load += new System.EventHandler(this.Mitarbeiter_Status_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Mitarbeiter_Status_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtM_DNr;
        public System.Windows.Forms.Button btnAktiv;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnKrank;
        public System.Windows.Forms.Button btnUrlaub;
    }
}