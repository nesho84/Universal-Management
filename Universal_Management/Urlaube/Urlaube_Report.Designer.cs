namespace Universal_Management
{
    partial class Urlaube_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Urlaube_Report));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.um_db_DataSet = new Universal_Management.um_db_DataSet();
            this.urlaubeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.urlaubeTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.urlaubeTableAdapter();
            this.einstellungen_firmaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.einstellungen_firmaTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.comboDNr = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlaubeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungen_firmaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Urlaube_DataSet";
            reportDataSource1.Value = this.urlaubeBindingSource;
            reportDataSource2.Name = "Firma_DataSet";
            reportDataSource2.Value = this.einstellungen_firmaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Universal_Management.Urlaube_Report_View.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1003, 621);
            this.reportViewer1.TabIndex = 0;
            // 
            // um_db_DataSet
            // 
            this.um_db_DataSet.DataSetName = "um_db_DataSet";
            this.um_db_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // urlaubeBindingSource
            // 
            this.urlaubeBindingSource.DataMember = "urlaube";
            this.urlaubeBindingSource.DataSource = this.um_db_DataSet;
            // 
            // urlaubeTableAdapter
            // 
            this.urlaubeTableAdapter.ClearBeforeFill = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(753, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 213;
            this.label1.Text = "DNr.";
            // 
            // comboDNr
            // 
            this.comboDNr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDNr.FormattingEnabled = true;
            this.comboDNr.Location = new System.Drawing.Point(785, 2);
            this.comboDNr.Name = "comboDNr";
            this.comboDNr.Size = new System.Drawing.Size(119, 21);
            this.comboDNr.TabIndex = 212;
            this.comboDNr.SelectedIndexChanged += new System.EventHandler(this.comboDNr_SelectedIndexChanged);
            // 
            // Urlaube_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 621);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDNr);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Urlaube_Report";
            this.Text = "Urlaube Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Urlaube_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlaubeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungen_firmaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource urlaubeBindingSource;
        private um_db_DataSet um_db_DataSet;
        private System.Windows.Forms.BindingSource einstellungen_firmaBindingSource;
        private um_db_DataSetTableAdapters.urlaubeTableAdapter urlaubeTableAdapter;
        private um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter einstellungen_firmaTableAdapter;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboDNr;
    }
}