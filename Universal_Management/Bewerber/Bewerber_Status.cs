using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Universal_Management
{
    public partial class Bewerber_Status : Form
    {
        //ConnString
        //string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form Urlaube
        Bewerber obj_bewerber = (Bewerber)Application.OpenForms["Bewerber"];

        public Bewerber_Status()
        {
            InitializeComponent();
        }

        private void btnAktiv_Click(object sender, EventArgs e)
        {
            var Mit_DNr_Update = new Mitarbeiter_DNr_Update();

            Mit_DNr_Update.lblMITID.Text = this.txtMITID.Text;

            this.Hide();
            this.Dispose();
            obj_bewerber.Hide();
            obj_bewerber.Dispose();

            Mit_DNr_Update.ShowDialog();
        }

        private void Bewerber_Status_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

    }
}
