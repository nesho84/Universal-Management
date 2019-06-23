namespace Universal_Management
{
    partial class Termine_View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Termine_View));
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.date1 = new System.Windows.Forms.TextBox();
            this.date2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEID = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnErledigt = new System.Windows.Forms.Button();
            this.btnVerpasst = new System.Windows.Forms.Button();
            this.btnLaufend = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "Ort";
            // 
            // txtOrt
            // 
            this.txtOrt.Location = new System.Drawing.Point(22, 263);
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.ReadOnly = true;
            this.txtOrt.Size = new System.Drawing.Size(229, 20);
            this.txtOrt.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Titel";
            // 
            // txtTitel
            // 
            this.txtTitel.Location = new System.Drawing.Point(22, 126);
            this.txtTitel.Name = "txtTitel";
            this.txtTitel.ReadOnly = true;
            this.txtTitel.Size = new System.Drawing.Size(229, 20);
            this.txtTitel.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Beschreibung";
            // 
            // richTextBox1
            // 
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(21, 318);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(230, 96);
            this.richTextBox1.TabIndex = 43;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Ende";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Start";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 432);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 54);
            this.panel1.TabIndex = 49;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Image = global::Universal_Management.Properties.Resources.ok24px;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(153, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 34);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "   OK";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Image = global::Universal_Management.Properties.Resources.delete24px;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.Location = new System.Drawing.Point(22, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 34);
            this.button5.TabIndex = 34;
            this.button5.Text = "  Löschen";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(22, 170);
            this.date1.Name = "date1";
            this.date1.ReadOnly = true;
            this.date1.Size = new System.Drawing.Size(229, 20);
            this.date1.TabIndex = 50;
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(22, 216);
            this.date2.Name = "date2";
            this.date2.ReadOnly = true;
            this.date2.Size = new System.Drawing.Size(229, 20);
            this.date2.TabIndex = 51;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtEID);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Location = new System.Drawing.Point(21, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 50);
            this.panel2.TabIndex = 52;
            // 
            // txtEID
            // 
            this.txtEID.AutoSize = true;
            this.txtEID.Enabled = false;
            this.txtEID.Location = new System.Drawing.Point(201, 0);
            this.txtEID.Name = "txtEID";
            this.txtEID.Size = new System.Drawing.Size(25, 13);
            this.txtEID.TabIndex = 53;
            this.txtEID.Text = "EID";
            this.txtEID.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(226, 46);
            this.lblStatus.TabIndex = 53;
            this.lblStatus.Text = "Termin verpasst";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnErledigt
            // 
            this.btnErledigt.Location = new System.Drawing.Point(21, 69);
            this.btnErledigt.Name = "btnErledigt";
            this.btnErledigt.Size = new System.Drawing.Size(71, 23);
            this.btnErledigt.TabIndex = 53;
            this.btnErledigt.Text = "Erledigt";
            this.btnErledigt.UseVisualStyleBackColor = true;
            this.btnErledigt.Click += new System.EventHandler(this.btnErledigt_Click);
            // 
            // btnVerpasst
            // 
            this.btnVerpasst.Location = new System.Drawing.Point(101, 69);
            this.btnVerpasst.Name = "btnVerpasst";
            this.btnVerpasst.Size = new System.Drawing.Size(71, 23);
            this.btnVerpasst.TabIndex = 54;
            this.btnVerpasst.Text = "Verpasst";
            this.btnVerpasst.UseVisualStyleBackColor = true;
            this.btnVerpasst.Click += new System.EventHandler(this.btnVerpasst_Click);
            // 
            // btnLaufend
            // 
            this.btnLaufend.Location = new System.Drawing.Point(180, 69);
            this.btnLaufend.Name = "btnLaufend";
            this.btnLaufend.Size = new System.Drawing.Size(71, 23);
            this.btnLaufend.TabIndex = 55;
            this.btnLaufend.Text = "Laufend";
            this.btnLaufend.UseVisualStyleBackColor = true;
            this.btnLaufend.Click += new System.EventHandler(this.btnLaufend_Click);
            // 
            // Termine_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(274, 486);
            this.Controls.Add(this.btnLaufend);
            this.Controls.Add(this.btnVerpasst);
            this.Controls.Add(this.btnErledigt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOrt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTitel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Termine_View";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Termin Ansicht";
            this.Load += new System.EventHandler(this.Termine_View_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Termine_View_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtOrt;
        public System.Windows.Forms.TextBox txtTitel;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox date1;
        public System.Windows.Forms.TextBox date2;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Label txtEID;
        public System.Windows.Forms.Button btnErledigt;
        public System.Windows.Forms.Button btnVerpasst;
        public System.Windows.Forms.Button btnLaufend;
        private System.Windows.Forms.Button btnClose;
    }
}