namespace Universal_Management
{
    partial class Stundenliste_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stundenliste_Report));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblMonat = new System.Windows.Forms.Label();
            this.lblJahr = new System.Windows.Forms.Label();
            this.comboMonat = new System.Windows.Forms.ComboBox();
            this.comboJahr = new System.Windows.Forms.ComboBox();
            this.stundenliste_monatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.um_db_DataSet = new Universal_Management.um_db_DataSet();
            this.einstellungen_firmaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stundenliste_monatTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.stundenliste_monatTableAdapter();
            this.einstellungen_firmaTableAdapter = new Universal_Management.um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.stundenliste_monatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungen_firmaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Stundenliste_DataSet";
            reportDataSource1.Value = this.stundenliste_monatBindingSource;
            reportDataSource2.Name = "Stundenliste_Firma_DataSet";
            reportDataSource2.Value = this.einstellungen_firmaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Universal_Management.Stundenliste_Report_Viewer.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1028, 608);
            this.reportViewer1.TabIndex = 0;
            // 
            // lblMonat
            // 
            this.lblMonat.AutoSize = true;
            this.lblMonat.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonat.Location = new System.Drawing.Point(860, 8);
            this.lblMonat.Name = "lblMonat";
            this.lblMonat.Size = new System.Drawing.Size(39, 12);
            this.lblMonat.TabIndex = 205;
            this.lblMonat.Text = "Monat";
            // 
            // lblJahr
            // 
            this.lblJahr.AutoSize = true;
            this.lblJahr.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJahr.Location = new System.Drawing.Point(701, 8);
            this.lblJahr.Name = "lblJahr";
            this.lblJahr.Size = new System.Drawing.Size(30, 12);
            this.lblJahr.TabIndex = 204;
            this.lblJahr.Text = "Jahr";
            // 
            // comboMonat
            // 
            this.comboMonat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMonat.Enabled = false;
            this.comboMonat.FormattingEnabled = true;
            this.comboMonat.Items.AddRange(new object[] {
            "Januar",
            "Februar",
            "März",
            "April",
            "Mai",
            "Juni",
            "Juli",
            "August",
            "September",
            "Oktober",
            "November",
            "Dezember"});
            this.comboMonat.Location = new System.Drawing.Point(903, 2);
            this.comboMonat.Name = "comboMonat";
            this.comboMonat.Size = new System.Drawing.Size(119, 21);
            this.comboMonat.TabIndex = 203;
            this.comboMonat.SelectedIndexChanged += new System.EventHandler(this.comboMonat_SelectedIndexChanged);
            // 
            // comboJahr
            // 
            this.comboJahr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboJahr.FormattingEnabled = true;
            this.comboJahr.Items.AddRange(new object[] {
            "2022",
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014",
            "2013"});
            this.comboJahr.Location = new System.Drawing.Point(734, 2);
            this.comboJahr.Name = "comboJahr";
            this.comboJahr.Size = new System.Drawing.Size(119, 21);
            this.comboJahr.TabIndex = 202;
            this.comboJahr.SelectedIndexChanged += new System.EventHandler(this.comboJahr_SelectedIndexChanged);
            // 
            // stundenliste_monatBindingSource
            // 
            this.stundenliste_monatBindingSource.DataMember = "stundenliste_monat";
            this.stundenliste_monatBindingSource.DataSource = this.um_db_DataSet;
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
            // stundenliste_monatTableAdapter
            // 
            this.stundenliste_monatTableAdapter.ClearBeforeFill = true;
            // 
            // einstellungen_firmaTableAdapter
            // 
            this.einstellungen_firmaTableAdapter.ClearBeforeFill = true;
            // 
            // Stundenliste_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 608);
            this.Controls.Add(this.lblMonat);
            this.Controls.Add(this.lblJahr);
            this.Controls.Add(this.comboMonat);
            this.Controls.Add(this.comboJahr);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Stundenliste_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Stundenliste Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Stundenliste_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stundenliste_monatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.um_db_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.einstellungen_firmaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource stundenliste_monatBindingSource;
        private um_db_DataSet um_db_DataSet;
        private um_db_DataSetTableAdapters.stundenliste_monatTableAdapter stundenliste_monatTableAdapter;
        private System.Windows.Forms.BindingSource einstellungen_firmaBindingSource;
        private um_db_DataSetTableAdapters.einstellungen_firmaTableAdapter einstellungen_firmaTableAdapter;
        public System.Windows.Forms.Label lblMonat;
        public System.Windows.Forms.Label lblJahr;
        public System.Windows.Forms.ComboBox comboMonat;
        public System.Windows.Forms.ComboBox comboJahr;
    }
}