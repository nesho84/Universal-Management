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
    public partial class FeierTage_Report : Form
    {
        public FeierTage_Report()
        {
            InitializeComponent();
        }

        private void Feirtage_Report_Load(object sender, EventArgs e)
        {
            FeierTage Fe_obj = (FeierTage)Application.OpenForms["FeierTage"];

            string tJahr = Fe_obj.comboJahr.SelectedItem.ToString();
            // TODO: This line of code loads data into the 'um_db_DataSet.feiertage' table. You can move, or remove it, as needed.
            this.feiertageTableAdapter.Fill(this.um_db_DataSet.feiertage, tJahr);
            // TODO: This line of code loads data into the 'um_db_DataSet.einstellungen_firma' table. You can move, or remove it, as needed.
            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);

            this.reportViewer1.RefreshReport();
        }
    }
}
