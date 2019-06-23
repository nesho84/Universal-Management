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
    public partial class Firmenbuch_Profile_Report : Form
    {
        public Firmenbuch_Profile_Report()
        {
            InitializeComponent();
        }

        private void Firmenbuch_Profile_Report_Load(object sender, EventArgs e)
        {
            Firmenbuch_View F_pr_report = (Firmenbuch_View)Application.OpenForms["Firmenbuch_View"];
            //Convert Kontostand textbox to integer
            int intFRMID;
            intFRMID = Convert.ToInt32(F_pr_report.boxid.Text);
            intFRMID = int.Parse(F_pr_report.boxid.Text);

             // TODO: This line of code loads data into the 'um_db_DataSet.firmenbuch' table. You can move, or remove it, as needed.
            this.firmenbuchTableAdapter.Fill(this.um_db_DataSet.firmenbuch, intFRMID);

            this.reportViewer1.RefreshReport();
        }
    }
}
