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
    public partial class Bewerber_Profile_Report : Form
    {
        public Bewerber_Profile_Report()
        {
            InitializeComponent();
        }

        private void Bewerber_Profile_Report_Load(object sender, EventArgs e)
        {
            //Convert Kontostand textbox to integer
            int intMITID;
            intMITID = Convert.ToInt32(lblID.Text);
            intMITID = int.Parse(lblID.Text);

            // TODO: This line of code loads data into the 'um_db_DataSet.mitarbeiter' table. You can move, or remove it, as needed.
            this.mitarbeiterTableAdapter.FillBy_Bew_Profile(this.um_db_DataSet.mitarbeiter, intMITID);

            this.reportViewer1.RefreshReport();
        }
    }
}
