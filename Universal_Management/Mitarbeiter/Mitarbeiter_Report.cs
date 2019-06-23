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
    public partial class Mitarbeiter_Report : Form
    {
        public Mitarbeiter_Report()
        {
            InitializeComponent();
        }

        private void Mitarbeiter_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'um_db_DataSet.mitarbeiter' table. You can move, or remove it, as needed.
            this.mitarbeiterTableAdapter.FillBy_Mitarbeiter(this.um_db_DataSet.mitarbeiter);
            // TODO: This line of code loads data into the 'um_db_DataSet.einstellungen_firma' table. You can move, or remove it, as needed.
            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);
            // TODO: This line of code loads data into the 'um_db_DataSet.mitarbeiter' table. You can move, or remove it, as needed.

            this.reportViewer_Mitarbeiterliste.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'um_db_DataSet.mitarbeiter' table. You can move, or remove it, as needed.
            this.mitarbeiterTableAdapter.FillBy_Status(this.um_db_DataSet.mitarbeiter, comboStatus.SelectedItem.ToString());
            // TODO: This line of code loads data into the 'um_db_DataSet.einstellungen_firma' table. You can move, or remove it, as needed.
            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);
            // TODO: This line of code loads data into the 'um_db_DataSet.mitarbeiter' table. You can move, or remove it, as needed.

            this.reportViewer_Mitarbeiterliste.RefreshReport();
        }

    }
}
