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
    public partial class Stundenliste_Konto_Report : Form
    {
        public Stundenliste_Konto_Report()
        {
            InitializeComponent();
        }

        private void Stundenliste_Konto_Report_Load(object sender, EventArgs e)
        {
            Stundenliste_Konto std_konto = (Stundenliste_Konto)Application.OpenForms["Stundenliste_Konto"];
            //Convert Kontostand textbox to integer
            int intDNr;
            intDNr = Convert.ToInt32(std_konto.txtDNr.Text);
            intDNr = int.Parse(std_konto.txtDNr.Text);

            string txtJahr = std_konto.comboJahr.SelectedItem.ToString();

            // TODO: This line of code loads data into the 'um_db_DataSet.stundenliste_konto' table. You can move, or remove it, as needed.
            this.stundenliste_kontoTableAdapter.Fill(this.um_db_DataSet.stundenliste_konto, intDNr, txtJahr);

            // TODO: This line of code loads data into the 'um_db_DataSet.einstellungen_firma' table. You can move, or remove it, as needed.
            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);

            this.reportViewer1.RefreshReport();
        }
    }
}
