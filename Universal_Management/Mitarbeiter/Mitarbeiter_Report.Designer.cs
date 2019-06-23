namespace Universal_Management
{
    partial class Mitarbeiter_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mitarbeiter_Report));
            this.reportViewer_Mitarbeiterliste = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.mitarbeiterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.um_db_DataSet = new Universal_Management.um_db_DataSet();
            this.einstellungen_firmaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mitarbeiterTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.mitarbeiterTableAdapter();
            this.einstellungen_firmaTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.mitarbeiterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungen_firmaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer_Mitarbeiterliste
            // 
            this.reportViewer_Mitarbeiterliste.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Mitarbeiter_DataSet";
            reportDataSource1.Value = this.mitarbeiterBindingSource;
            reportDataSource2.Name = "Firma_DataSet";
            reportDataSource2.Value = this.einstellungen_firmaBindingSource;
            this.reportViewer_Mitarbeiterliste.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer_Mitarbeiterliste.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer_Mitarbeiterliste.LocalReport.ReportEmbeddedResource = "Universal_Management.Mitarbeiter_Report_View.rdlc";
            this.reportViewer_Mitarbeiterliste.Location = new System.Drawing.Point(0, 0);
            this.reportViewer_Mitarbeiterliste.Name = "reportViewer_Mitarbeiterliste";
            this.reportViewer_Mitarbeiterliste.Size = new System.Drawing.Size(1140, 611);
            this.reportViewer_Mitarbeiterliste.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(942, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 211;
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
            this.comboStatus.Location = new System.Drawing.Point(985, 3);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(119, 21);
            this.comboStatus.TabIndex = 210;
            this.comboStatus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
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
            // einstellungen_firmaBindingSource
            // 
            this.einstellungen_firmaBindingSource.DataMember = "einstellungen_firma";
            this.einstellungen_firmaBindingSource.DataSource = this.um_db_DataSet;
            // 
            // mitarbeiterTableAdapter
            // 
            this.mitarbeiterTableAdapter.ClearBeforeFill = true;
            // 
            // einstellungen_firmaTableAdapter
            // 
            this.einstellungen_firmaTableAdapter.ClearBeforeFill = true;
            // 
            // Mitarbeiter_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 611);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.reportViewer_Mitarbeiterliste);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Mitarbeiter_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mitarbeiter Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Mitarbeiter_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mitarbeiterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungen_firmaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_Mitarbeiterliste;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.BindingSource mitarbeiterBindingSource;
        private um_db_DataSet um_db_DataSet;
        private System.Windows.Forms.BindingSource einstellungen_firmaBindingSource;
        private um_db_DataSetTableAdapters.mitarbeiterTableAdapter mitarbeiterTableAdapter;
        private um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter einstellungen_firmaTableAdapter;

    }
}