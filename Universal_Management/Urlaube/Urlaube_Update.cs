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
    public partial class Urlaube_Update : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form Urlaube
        Urlaube u_urlaubee = (Urlaube)Application.OpenForms["Urlaube"];

        public Urlaube_Update()
        {
            InitializeComponent();
        }

        public string UrlaubTypeUpdate;

        public string Konsumiert;

        private void calcDays() //Calculate days and days into months code by NESHO
        {
            DateTime newDate = dateTimePicker_bis.Value;
            DateTime oldDate = dateTimePicker_von.Value;

            //// Difference in days, hours, and minutes.
            //TimeSpan ts = newDate - oldDate;
            //// Difference in days.
            //int differenceInDays = ts.Days + 1;
            //txtAnzahlTage.Text = differenceInDays.ToString();

            int daycount = 0;
            while (oldDate <= newDate)
            {
                oldDate = oldDate.AddDays(1);
                int DayNumInWeek = (int)oldDate.DayOfWeek;

                if (DayNumInWeek != 0)
                {
                    if (DayNumInWeek != 6)
                    {
                        daycount += 1;
                    }
                }

                txtAnzahlTage.Text = Convert.ToString(daycount);
            }
        }

        private void Urlaube_Update_Load(object sender, EventArgs e)
        {
            try
            {
                //Getting rows from database
                string Query = "select * from um_db.urlaube where URLID='" + this.txtURLID.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sVorname = myReader.GetString("M_Vorname");
                    string sNachname = myReader.GetString("M_Nachname");

                    txtVorname.Text = sVorname;
                    txtNachname.Text = sNachname;
                }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Getting radiobutton selected from database (Code generated *</by nesho>*)
            if (UrlaubTypeUpdate == "Urlaub")
            {
                radioButton1.Checked = true;
            }
            if (UrlaubTypeUpdate == "Sonderurlaub")
            {
                radioButton2.Checked = true;
            }
            else if (UrlaubTypeUpdate == "Zeitausgleich")
            {
                radioButton3.Checked = true;
            }

            //Konsumiert button aktivieren
            if (Konsumiert == "Ja")
            {
                btnJa.Enabled = false;
                btnNein.Enabled = true;
            }
            if (Konsumiert == "Nein")
            {
                btnNein.Enabled = false;
                btnJa.Enabled = true;
            }
            else if (Konsumiert == "")
            {
                btnNein.Enabled = true;
                btnJa.Enabled = true;
            }
            
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            UrlaubTypeUpdate = "Urlaub";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            UrlaubTypeUpdate = "Sonderurlaub";
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            UrlaubTypeUpdate = "Zeitausgleich";
        }

        //button Speichern Update Urlaube
        private void button2_Click(object sender, EventArgs e)
        {
            //Validating
            if (txtAnzahlTage.TextLength == 0)
            {
                this.txtAnzahlTage.Focus();
                MessageBox.Show("Bitte Anzahl der Tage eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    string Query = "update um_db.urlaube set Type='" + UrlaubTypeUpdate + "', Arbeitstage_von='" + this.dateTimePicker_von.Text + "', Arbeitstage_bis='" + this.dateTimePicker_bis.Text + "', Anzahl_Tage='" + this.txtAnzahlTage.Text + "', M_Vorname='" + this.txtVorname.Text + "', M_Nachname='" + this.txtNachname.Text + "', DN_Nr='" + this.txtDNNr.Text + "' where URLID='" + this.txtURLID.Text + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();
                    
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Die Daten wurden aktualisiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Refresh datagridview on form Urlaube
                    u_urlaubee.load_table();
                    u_urlaubee.dataGridView1.Update();
                    u_urlaubee.dataGridView1.Refresh();

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
        }

        //button Loschen delete Urlaube
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sind Sie sicher?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string URLID = this.txtURLID.Text;

                    string Query = "delete from um_db.urlaube where URLID='" + URLID + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Urlaub erfolgreich gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    u_urlaubee.load_table();
                    while (myReader.Read()) { }

                    u_urlaubee.toolStripStatusLabel1.Text = "Urlaub gelöscht.";

                    //Close Connection
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (u_urlaubee.dataGridView1.SelectedRows.Count > 0)
                    {
                        u_urlaubee.btnBearbeiten.Enabled = true;
                        u_urlaubee.btnPrint.Enabled = true;
                    }
                    else
                    {
                        u_urlaubee.btnBearbeiten.Enabled = false;
                        u_urlaubee.btnPrint.Enabled = false;
                    }
                    this.Close();
                }
            }
        }

        private void btnJa_Click(object sender, EventArgs e)
        {
            try
            {
                string Ja = "Ja";

                string Query = "update um_db.urlaube set Konsumiert='" + Ja + "' where URLID='" + this.txtURLID.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();
                
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Urlaub wurde Konsumiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read()) { }

                //Refresh datagridview on form Urlaube
                u_urlaubee.load_table();
                u_urlaubee.dataGridView1.Update();
                u_urlaubee.dataGridView1.Refresh();

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

        private void btnNein_Click(object sender, EventArgs e)
        {
            try
            {
                string Nein = "Nein";

                string Query = "update um_db.urlaube set Konsumiert='" + Nein + "' where URLID='" + this.txtURLID.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();
                
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Urlaub nicht Konsumiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read()) { }

                //Refresh datagridview on form Urlaube
                u_urlaubee.load_table();
                u_urlaubee.dataGridView1.Update();
                u_urlaubee.dataGridView1.Refresh();

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

        //button to close the form
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDNNr_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void txtDNNr_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void dateTimePicker_von_ValueChanged(object sender, EventArgs e)
        {
            calcDays();
        }

        private void dateTimePicker_bis_ValueChanged(object sender, EventArgs e)
        {
            calcDays();
        }

        private void Urlaube_Update_Shown(object sender, EventArgs e)
        {
            //calcDays();
        }

    }
}
