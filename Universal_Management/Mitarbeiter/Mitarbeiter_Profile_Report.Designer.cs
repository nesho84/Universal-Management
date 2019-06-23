namespace Universal_Management
{
    partial class Mitarbeiter_Profile_Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mitarbeiter_Profile_Report));
            this.mitarbeiterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.um_db_DataSet = new Universal_Management.um_db_DataSet();
            this.reportViewer_Mit_Profile = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mitarbeiterTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.mitarbeiterTableAdapter();
            this.lblDNr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mitarbeiterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // mitarbeiterBindingSource
            // 
            this.mitarbeiterBindingSource.DataMember = "mitarbeiter";
            this.mitarbeiterBindingSource.DataSource = this.um_db_DataSet;
            // 
            // um_db_DataSet
            // 
            this.um_db_DataSet.DataSetName = "um_db_DataSet";
            this.um_db_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer_Mit_Profile
            // 
            this.reportViewer_Mit_Profile.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Mit_Profile_DataSet";
            reportDataSource1.Value = this.mitarbeiterBindingSource;
            this.reportViewer_Mit_Profile.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer_Mit_Profile.LocalReport.ReportEmbeddedResource = "Universal_Management.Mitarbeiter_Report_View_Profile.rdlc";
            this.reportViewer_Mit_Profile.Location = new System.Drawing.Point(0, 0);
            this.reportViewer_Mit_Profile.Name = "reportViewer_Mit_Profile";
            this.reportViewer_Mit_Profile.Size = new System.Drawing.Size(1060, 569);
            this.reportViewer_Mit_Profile.TabIndex = 213;
            // 
            // mitarbeiterTableAdapter
            // 
            this.mitarbeiterTableAdapter.ClearBeforeFill = true;
            // 
            // lblDNr
            // 
            this.lblDNr.AutoSize = true;
            this.lblDNr.Location = new System.Drawing.Point(896, 7);
            this.lblDNr.Name = "lblDNr";
            this.lblDNr.Size = new System.Drawing.Size(36, 13);
            this.lblDNr.TabIndex = 214;
            this.lblDNr.Text = "lblDNr";
            this.lblDNr.Visible = false;
            // 
            // Mitarbeiter_Profile_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 569);
            this.Controls.Add(this.lblDNr);
            this.Controls.Add(this.reportViewer_Mit_Profile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Mitarbeiter_Profile_Report";
            this.Text = "Mitarbeiter Profile Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Mitarbeiter_Profile_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mitarbeiterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_Mit_Profile;
        private System.Windows.Forms.BindingSource mitarbeiterBindingSource;
        private um_db_DataSet um_db_DataSet;
        private um_db_DataSetTableAdapters.mitarbeiterTableAdapter mitarbeiterTableAdapter;
        public System.Windows.Forms.Label lblDNr;
    }
}