using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universal_Management
{
    public partial class Firmenbuch_Extra_Report : Form
    {
        public Firmenbuch_Extra_Report()
        {
            InitializeComponent();
        }

        private void Firmenbuch_Extra_Report_Load(object sender, EventArgs e)
        {
            string frm_name = lblFirmaName.Text;

            // TODO: This line of code loads data into the 'um_db_DataSet.firmenbuch' table. You can move, or remove it, as needed.
            this.firmenbuchTableAdapter.FillBy_Name(this.um_db_DataSet.firmenbuch, frm_name);

            // TODO: This line of code loads data into the 'um_db_DataSet.mitarbeiter' table. You can move, or remove it, as needed.
            this.mitarbeiterTableAdapter.FillBy_FirmaName(this.um_db_DataSet.mitarbeiter, frm_name);

            this.reportViewer1.RefreshReport();
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string frm_name = lblFirmaName.Text;
            string status = this.comboStatus.SelectedItem.ToString();

            // TODO: This line of code loads data into the 'um_db_DataSet.mitarbeiter' table. You can move, or remove it, as needed.
            this.mitarbeiterTableAdapter.FillBy_Firma_and_Status(this.um_db_DataSet.mitarbeiter, status, frm_name);

            // TODO: This line of code loads data into the 'um_db_DataSet.firmenbuch' table. You can move, or remove it, as needed.
            this.firmenbuchTableAdapter.FillBy_Name(this.um_db_DataSet.firmenbuch, frm_name);

            this.reportViewer1.RefreshReport();
        }
    }
}
