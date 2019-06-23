namespace Universal_Management
{
    partial class Firmenbuch_Extra_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Firmenbuch_Extra_Report));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.lblFirmaName = new System.Windows.Forms.Label();
            this.mitarbeiterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.um_db_DataSet = new Universal_Management.um_db_DataSet();
            this.firmenbuchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mitarbeiterTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.mitarbeiterTableAdapter();
            this.firmenbuchTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.firmenbuchTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.mitarbeiterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmenbuchBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Firmenbuch_Extra_DataSet";
            reportDataSource1.Value = this.mitarbeiterBindingSource;
            reportDataSource2.Name = "Firmenbuch_Profile_DataSet";
            reportDataSource2.Value = this.firmenbuchBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Universal_Management.Firmenbuch_Extra_Report_View.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(919, 590);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(752, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 213;
            this.label1.Text = "Status:";
            // 
            // comboStatus
            // 
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "Aktiv",
            "Krank",
            "Urlaub"});
            this.comboStatus.Location = new System.Drawing.Point(795, 3);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(119, 21);
            this.comboStatus.TabIndex = 212;
            this.comboStatus.SelectedIndexChanged += new System.EventHandler(this.comboStatus_SelectedIndexChanged);
            // 
            // lblFirmaName
            // 
            this.lblFirmaName.AutoSize = true;
            this.lblFirmaName.Location = new System.Drawing.Point(637, 7);
            this.lblFirmaName.Name = "lblFirmaName";
            this.lblFirmaName.Size = new System.Drawing.Size(70, 13);
            this.lblFirmaName.TabIndex = 214;
            this.lblFirmaName.Text = "lblFirmaName";
            this.lblFirmaName.Visible = false;
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
            // firmenbuchBindingSource
            // 
            this.firmenbuchBindingSource.DataMember = "firmenbuch";
            this.firmenbuchBindingSource.DataSource = this.um_db_DataSet;
            // 
            // mitarbeiterTableAdapter
            // 
            this.mitarbeiterTableAdapter.ClearBeforeFill = true;
            // 
            // firmenbuchTableAdapter
            // 
            this.firmenbuchTableAdapter.ClearBeforeFill = true;
            // 
            // Firmenbuch_Extra_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 590);
            this.Controls.Add(this.lblFirmaName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Firmenbuch_Extra_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Firmenbuch Extra Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Firmenbuch_Extra_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mitarbeiterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmenbuchBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource mitarbeiterBindingSource;
        private um_db_DataSet um_db_DataSet;
        private System.Windows.Forms.BindingSource firmenbuchBindingSource;
        private um_db_DataSetTableAdapters.mitarbeiterTableAdapter mitarbeiterTableAdapter;
        private um_db_DataSetTableAdapters.firmenbuchTableAdapter firmenbuchTableAdapter;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboStatus;
        public System.Windows.Forms.Label lblFirmaName;
    }
}