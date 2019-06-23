namespace Universal_Management
{
    partial class FeierTage_Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeierTage_Report));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.um_db_DataSet = new Universal_Management.um_db_DataSet();
            this.feiertageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.feiertageTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.feiertageTableAdapter();
            this.einstellungen_firmaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.einstellungen_firmaTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feiertageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungen_firmaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Feiertage_DataSet";
            reportDataSource1.Value = this.feiertageBindingSource;
            reportDataSource2.Name = "Firma_DataSet";
            reportDataSource2.Value = this.einstellungen_firmaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Universal_Management.Feiertage_Report_View.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1019, 593);
            this.reportViewer1.TabIndex = 0;
            // 
            // um_db_DataSet
            // 
            this.um_db_DataSet.DataSetName = "um_db_DataSet";
            this.um_db_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // feiertageBindingSource
            // 
            this.feiertageBindingSource.DataMember = "feiertage";
            this.feiertageBindingSource.DataSource = this.um_db_DataSet;
            // 
            // feiertageTableAdapter
            // 
            this.feiertageTableAdapter.ClearBeforeFill = true;
            // 
            // einstellungen_firmaBindingSource
            // 
            this.einstellungen_firmaBindingSource.DataMember = "einstellungen_firma";
            this.einstellungen_firmaBindingSource.DataSource = this.um_db_DataSet;
            // 
            // einstellungen_firmaTableAdapter
            // 
            this.einstellungen_firmaTableAdapter.ClearBeforeFill = true;
            // 
            // FeierTage_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 593);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FeierTage_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Feiertage Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Feirtage_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feiertageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungen_firmaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource feiertageBindingSource;
        private um_db_DataSet um_db_DataSet;
        private System.Windows.Forms.BindingSource einstellungen_firmaBindingSource;
        private um_db_DataSetTableAdapters.feiertageTableAdapter feiertageTableAdapter;
        private um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter einstellungen_firmaTableAdapter;
    }
}