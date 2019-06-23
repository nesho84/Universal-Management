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
    public partial class Mitarbeiter_Profile_Report : Form
    {
        public Mitarbeiter_Profile_Report()
        {
            InitializeComponent();
        }

        private void Mitarbeiter_Profile_Report_Load(object sender, EventArgs e)
        {
            //Convert Kontostand textbox to integer
            int intDNr;
            intDNr = Convert.ToInt32(lblDNr.Text);
            intDNr = int.Parse(lblDNr.Text);

            // TODO: This line of code loads data into the 'um_db_DataSet.mitarbeiter' table. You can move, or remove it, as needed.
            this.mitarbeiterTableAdapter.FillBy_Profile(this.um_db_DataSet.mitarbeiter, intDNr);

            this.reportViewer_Mit_Profile.RefreshReport();
        }
    }
}
