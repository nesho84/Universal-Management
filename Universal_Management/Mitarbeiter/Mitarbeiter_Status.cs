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
    public partial class Mitarbeiter_Status : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form Urlaube
        Urlaube_Add obj_urlaube_add = (Urlaube_Add)Application.OpenForms["Urlaube_Add"];

        //Refresh datagridview on form Mitarbeiter
        Mitarbeiter obj_mitarbeiter = (Mitarbeiter)Application.OpenForms["Mitarbeiter"];
        public Mitarbeiter_Status()
        {
            InitializeComponent();

            M_StatusCheck();
        }

        //String to select Query from db
        public string aktivvv = "aktiv";
        //public string krankkk = "krank";
        //public string urlaubbb = "urlaub";

        private void M_StatusCheck()
        {
            try
            {
                string Query = "select status from um_db.mitarbeiter where M_DNr='" + this.txtM_DNr.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sMStatus = myReader.GetString("status");

                    if (sMStatus == "aktiv") 
                    {
                        btnAktiv.Enabled = false;
                        btnUrlaub.Enabled = true;
                        btnKrank.Enabled = true;
                    }
                    if (sMStatus == "urlaub")
                    {
                        btnAktiv.Enabled = true;
                        btnUrlaub.Enabled = false;
                        btnKrank.Enabled = true;
                    }
                    if (sMStatus == "krank")
                    {
                        btnAktiv.Enabled = true;
                        btnUrlaub.Enabled = true;
                        btnKrank.Enabled = false;
                    }    
                }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAktiv_Click(object sender, EventArgs e)
        {
            try
            {
                string constring = "datasource=localhost;port=3306;username=root;password=123456";
                string Query = "update um_db.mitarbeiter set status='" + aktivvv + "' where M_DNr='" + this.txtM_DNr.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Mitarbeiter wurde als Aktiv geschpeichert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read()) { }

                //Refresh datagridview on form Mitarbeiter
                obj_mitarbeiter.load_table();
                obj_mitarbeiter.dataGridView1.Update();
                obj_mitarbeiter.dataGridView1.Refresh();

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void btnKrank_Click(object sender, EventArgs e)
        {
            //Open Form Mitarbeiter_Krankenstand
            Mitarbeiter_Krankenstand_Add Krankenstand_Add = new Mitarbeiter_Krankenstand_Add();
            Krankenstand_Add.txtDNNr.Text = txtM_DNr.Text;
            //Form Mit..krank.Add btnSpeichern Button btnSpeichern.Tag="save_krankend_and_mitarbeiter_status" to save both status for Mitarbeiter and Krankendstand
            Krankenstand_Add.btnSpeichern.Tag = "save_krankenstand_and_mitarbeiter_status";

            //Show form Urlaube
            Krankenstand_Add.ShowDialog();

            //...Krankenstand insert and Mitatbeiter status edit code is inside form Mitarbeiter_Krankenstand_Add
        }

        private void btnUrlaub_Click(object sender, EventArgs e)
        {
            //Open Form UrlaubADD
            Urlaube_Add Urlaube_Add = new Urlaube_Add(); 
            Urlaube_Add.comboDNr.Text = txtM_DNr.Text;
            Urlaube_Add.comboDNr.Enabled = false;

            //Form Urlaube_Add btnSpeichern Button btnSpeichern.Tag="save_urlaub_and_mitarbeiter_status" to save both status for Mitarbeiter and Urlaub
            Urlaube_Add.btnSpeichern.Tag = "save_urlaub_and_mitarbeiter_status";

            //Show form Urlaube
            Urlaube_Add.ShowDialog();

            //...Urlaube insert and Mitatbeiter status edit code is inside form Urlaube_Add
        }

        private void Mitarbeiter_Status_Load(object sender, EventArgs e)
        {
            M_StatusCheck();
        }

        private void Mitarbeiter_Status_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

    }
}