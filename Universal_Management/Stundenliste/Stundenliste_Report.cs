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
    public partial class Stundenliste_Report : Form
    {
        public Stundenliste_Report()
        {
            InitializeComponent();
        }

        private void Stundenliste_Report_Load(object sender, EventArgs e)
        {
            Stundenliste std = (Stundenliste)Application.OpenForms["Stundenliste"];
            //Convert Kontostand textbox to integer
            int intDNr;
            intDNr = Convert.ToInt32(std.comboDNr.SelectedItem.ToString());
            intDNr = int.Parse(std.comboDNr.SelectedItem.ToString());

            this.stundenliste_monatTableAdapter.Fill(this.um_db_DataSet.stundenliste_monat, intDNr);

            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);  

            this.reportViewer1.RefreshReport();
        }

        private void comboJahr_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stundenliste std = (Stundenliste)Application.OpenForms["Stundenliste"];
            //Convert Kontostand textbox to integer
            int intDNr;
            intDNr = Convert.ToInt32(std.comboDNr.SelectedItem.ToString());
            intDNr = int.Parse(std.comboDNr.SelectedItem.ToString());

            this.stundenliste_monatTableAdapter.Jahr(this.um_db_DataSet.stundenliste_monat, intDNr, comboJahr.SelectedItem.ToString());

            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);

            this.reportViewer1.RefreshReport();

            comboMonat.Enabled = true;
        }

        private void comboMonat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stundenliste std = (Stundenliste)Application.OpenForms["Stundenliste"];
            //Convert Kontostand textbox to integer
            int intDNr;
            intDNr = Convert.ToInt32(std.comboDNr.SelectedItem.ToString());
            intDNr = int.Parse(std.comboDNr.SelectedItem.ToString());

            this.stundenliste_monatTableAdapter.Monat(this.um_db_DataSet.stundenliste_monat, intDNr, comboJahr.SelectedItem.ToString(), comboMonat.SelectedItem.ToString());

            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);

            this.reportViewer1.RefreshReport();
        }
    }
}
