namespace Universal_Management
{
    partial class Bewerber_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bewerber_Report));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.um_db_DataSet = new Universal_Management.um_db_DataSet();
            this.einstellungenfirmaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.einstellungen_firmaTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mitarbeiterTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.mitarbeiterTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungenfirmaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Bewerber_DataSet";
            reportDataSource1.Value = this.bindingSource1;
            reportDataSource2.Name = "Firma_Bewerber_DataSet";
            reportDataSource2.Value = this.einstellungenfirmaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Universal_Management.Bewerberliste_Report_View.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1008, 611);
            this.reportViewer1.TabIndex = 0;
            // 
            // um_db_DataSet
            // 
            this.um_db_DataSet.DataSetName = "um_db_DataSet";
            this.um_db_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // einstellungenfirmaBindingSource
            // 
            this.einstellungenfirmaBindingSource.DataMember = "einstellungen_firma";
            this.einstellungenfirmaBindingSource.DataSource = this.um_db_DataSet;
            // 
            // einstellungen_firmaTableAdapter
            // 
            this.einstellungen_firmaTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "mitarbeiter";
            this.bindingSource1.DataSource = this.um_db_DataSet;
            // 
            // mitarbeiterTableAdapter
            // 
            this.mitarbeiterTableAdapter.ClearBeforeFill = true;
            // 
            // Bewerber_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 611);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Bewerber_Report";
            this.Text = "Bewerber Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Bewerber_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungenfirmaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private um_db_DataSet um_db_DataSet;
        private System.Windows.Forms.BindingSource einstellungenfirmaBindingSource;
        private um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter einstellungen_firmaTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource1;
        private um_db_DataSetTableAdapters.mitarbeiterTableAdapter mitarbeiterTableAdapter;
    }
}