namespace Universal_Management
{
    partial class Stundenliste_Konto_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stundenliste_Konto_Report));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.um_db_DataSet = new Universal_Management.um_db_DataSet();
            this.stundenliste_kontoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stundenliste_kontoTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.stundenliste_kontoTableAdapter();
            this.einstellungen_firmaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.einstellungen_firmaTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stundenliste_kontoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungen_firmaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Std_Konto_DataSet";
            reportDataSource1.Value = this.stundenliste_kontoBindingSource;
            reportDataSource2.Name = "Std_Konto_Firma_DataSet";
            reportDataSource2.Value = this.einstellungen_firmaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Universal_Management.Stundenliste_Konto_Report_Viewer.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1028, 605);
            this.reportViewer1.TabIndex = 0;
            // 
            // um_db_DataSet
            // 
            this.um_db_DataSet.DataSetName = "um_db_DataSet";
            this.um_db_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stundenliste_kontoBindingSource
            // 
            this.stundenliste_kontoBindingSource.DataMember = "stundenliste_konto";
            this.stundenliste_kontoBindingSource.DataSource = this.um_db_DataSet;
            // 
            // stundenliste_kontoTableAdapter
            // 
            this.stundenliste_kontoTableAdapter.ClearBeforeFill = true;
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
            // Stundenliste_Konto_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 605);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Stundenliste_Konto_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stundenliste Konto Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Stundenliste_Konto_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stundenliste_kontoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungen_firmaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource stundenliste_kontoBindingSource;
        private um_db_DataSet um_db_DataSet;
        private System.Windows.Forms.BindingSource einstellungen_firmaBindingSource;
        private um_db_DataSetTableAdapters.stundenliste_kontoTableAdapter stundenliste_kontoTableAdapter;
        private um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter einstellungen_firmaTableAdapter;
    }
}