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
    public partial class Termine_View : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Termine_View()
        {
            InitializeComponent();
        }

        //Refresh Termine form
        Termine termine = (Termine)Application.OpenForms["Termine"];

        private void Termine_View_Load(object sender, EventArgs e)
        {
            //LblStatus
            if (lblStatus.Text == "Termin erledigt")
            {
                lblStatus.ForeColor = Color.Green;
                btnErledigt.Enabled = false;
                btnLaufend.Enabled = true;
                btnVerpasst.Enabled = true;
            }
            else if (lblStatus.Text == "Laufend")
            {
                lblStatus.ForeColor = Color.Black;
                btnLaufend.Enabled = false;
                btnErledigt.Enabled = true;
                btnVerpasst.Enabled = true;
            }
            else if (lblStatus.Text == "Termin verpasst")
            {
                lblStatus.ForeColor = Color.Red;
                btnVerpasst.Enabled = false;
                btnErledigt.Enabled = true;
                btnLaufend.Enabled = true;
            }
        }

        //Termin Loschen
        private void button5_Click(object sender, EventArgs e)
        {
            string rowEID = txtEID.Text;

            try
            {
                string Query = "delete from um_db.events where EID='" + rowEID + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;
                
                //Connection Open
                conDataBase.Open();
                
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Termin wurde gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                while (myReader.Read()) { }

                termine.load_table_events();
                termine.dataGridView1.ClearSelection();

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void btnErledigt_Click(object sender, EventArgs e)
        {
            try
            {
                string termin_erledigt = "Termin erledigt";

                string Query1 = "update um_db.events set Status='" + termin_erledigt + "' where EID='" + txtEID.Text + "' ;";
                MySqlConnection conDataBase1 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase1 = new MySqlCommand(Query1, conDataBase1);
                MySqlDataReader myReader1;

                //Connection Open
                conDataBase1.Open();

                myReader1 = cmdDataBase1.ExecuteReader();
                MessageBox.Show("Termin erledigt.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader1.Read()) { }

                //Refresh datagridview on form Mitarbeiter
                termine.load_table_events();
                termine.dataGridView1.Update();
                termine.dataGridView1.Refresh();

                //Close Connection
                conDataBase1.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void btnVerpasst_Click(object sender, EventArgs e)
        {
            try
            {
                string Query1 = "update um_db.events set Status='" + "Termin verpasst" + "' where EID='" + txtEID.Text + "' ;";
                MySqlConnection conDataBase1 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase1 = new MySqlCommand(Query1, conDataBase1);
                MySqlDataReader myReader1;

                //Connection Open
                conDataBase1.Open();
                
                myReader1 = cmdDataBase1.ExecuteReader();
                MessageBox.Show("Termin verpasst.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader1.Read()) { }

                //Refresh datagridview on form Mitarbeiter
                termine.load_table_events();
                termine.dataGridView1.Update();
                termine.dataGridView1.Refresh();

                //Close Connection
                conDataBase1.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void btnLaufend_Click(object sender, EventArgs e)
        {
            try
            {
                string Query1 = "update um_db.events set Status='" + "Laufend" + "' where EID='" + txtEID.Text + "' ;";
                MySqlConnection conDataBase1 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase1 = new MySqlCommand(Query1, conDataBase1);
                MySqlDataReader myReader1;

                //Connection Open
                conDataBase1.Open();
                
                myReader1 = cmdDataBase1.ExecuteReader();
                MessageBox.Show("Laufend.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader1.Read()) { }

                //Refresh datagridview on form Mitarbeiter
                termine.load_table_events();
                termine.dataGridView1.Update();
                termine.dataGridView1.Refresh();

                //Close Connection
                conDataBase1.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void Termine_View_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
