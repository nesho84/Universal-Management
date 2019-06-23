namespace Universal_Management
{
    partial class Firmenbuch_Profile_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Firmenbuch_Profile_Report));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.um_db_DataSet = new Universal_Management.um_db_DataSet();
            this.firmenbuchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.firmenbuchTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.firmenbuchTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmenbuchBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Firmenbuch_Profile_DataSet";
            reportDataSource1.Value = this.firmenbuchBindingSource;
            reportDataSource2.Name = "Firmenbuch_extra_DataSet";
            reportDataSource2.Value = this.firmenbuchBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Universal_Management.Firmenbuch_Profile_Report_View.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1061, 611);
            this.reportViewer1.TabIndex = 0;
            // 
            // um_db_DataSet
            // 
            this.um_db_DataSet.DataSetName = "um_db_DataSet";
            this.um_db_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // firmenbuchBindingSource
            // 
            this.firmenbuchBindingSource.DataMember = "firmenbuch";
            this.firmenbuchBindingSource.DataSource = this.um_db_DataSet;
            // 
            // firmenbuchTableAdapter
            // 
            this.firmenbuchTableAdapter.ClearBeforeFill = true;
            // 
            // Firmenbuch_Profile_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 611);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Firmenbuch_Profile_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kunden Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Firmenbuch_Profile_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmenbuchBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource firmenbuchBindingSource;
        private um_db_DataSet um_db_DataSet;
        private um_db_DataSetTableAdapters.firmenbuchTableAdapter firmenbuchTableAdapter;
    }
}