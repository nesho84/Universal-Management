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
    public partial class Urlaube_Add : Form
    {
        //ConString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Urlaube_Add()
        {
            InitializeComponent();

            fill_combobox_DNr();
        }

        public string UrlaubTypeInsert;
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            UrlaubTypeInsert = "Urlaub";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            UrlaubTypeInsert = "Sonderurlaub";
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            UrlaubTypeInsert = "Zeitausgleich";
        }

        private void fill_combobox_DNr()
        {
            try
            {
                string Query = "select * from um_db.mitarbeiter where status<>'" + "passiv" + "' and M_DNr<>'" + "0" + "' ORDER BY M_DNr ASC ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();
                
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    //Getting text fields from database
                    string uDNr = myReader.GetString("M_DNr");
                    comboDNr.Items.Add(uDNr);
                }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void calcDays() //Calculate days and days into months
        {
            DateTime oldDate = dateTimePicker_von.Value;
            DateTime newDate = dateTimePicker_bis.Value;

            //if (oldDate.DayOfWeek == DayOfWeek.Saturday && oldDate.DayOfWeek == DayOfWeek.Sunday)
            //{
            //    oldDate.AddDays(-1);
            //}
            //if (newDate.DayOfWeek == DayOfWeek.Saturday && newDate.DayOfWeek == DayOfWeek.Sunday)
            //{
            //    newDate.AddDays(-1);
            //}

            //// Difference in days, hours, and minutes.
            //TimeSpan ts = newDate - oldDate;
            //// Difference in days.
            //int differenceInDays = ts.Days;
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

        //Custom datetime Format
        private void dateTimePicker_von_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_von.CustomFormat = "dd.MM.yyyy";
            calcDays();
        }
        //Custom datetime Format
        private void dateTimePicker_bis_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_bis.CustomFormat = "dd.MM.yyyy";
            calcDays();
        }

        private void Urlaube_Add_Load(object sender, EventArgs e)
        {
            //Auto Check radiobutton1 
            this.radioButton1.Checked = true;
            //Clear datetimepicker in order to calculate correctly
            dateTimePicker_von.CustomFormat = " ";
            dateTimePicker_bis.CustomFormat = " ";
        }

        public void Add_just_Urlaub()
        {
            //Validating
            if (dateTimePicker_von.CustomFormat == " ")
            {
                this.dateTimePicker_von.Focus();
                MessageBox.Show("Bitte alle Felder ausfüllen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Validating
            else if (dateTimePicker_bis.CustomFormat == " ")
            {
                this.dateTimePicker_bis.Focus();
                MessageBox.Show("Bitte alle Felder ausfüllen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Validating
            else if (txtAnzahlTage.TextLength == 0)
            {
                this.txtAnzahlTage.Focus();
                MessageBox.Show("Bitte Anzahl der Tage eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else 
            {
                try //Insert Urlaub to db START
                {
                    string Query = "insert into um_db.urlaube (Type,Arbeitstage_von,Arbeitstage_bis,Anzahl_Tage,M_Vorname,M_Nachname,DN_Nr) values('" + UrlaubTypeInsert + "','" + this.dateTimePicker_von.Text + "','" + this.dateTimePicker_bis.Text + "','" + this.txtAnzahlTage.Text + "','" + this.txtVorname.Text + "','" + this.txtNachname.Text + "','" + this.comboDNr.SelectedItem.ToString() + "') ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Urlaub erfolgreich eingegeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //To avoid error in Mitarbeiterstatus add Urlaub
                    if (btnSpeichern.Text == "   Speichern")
                    {
                        //Open form Urlaube
                        Urlaube obj_urlaube = (Urlaube)Application.OpenForms["Urlaube"];
                        //Refresh datagridview on form Urlaube
                        obj_urlaube.load_table();
                        obj_urlaube.dataGridView1.Update();
                        obj_urlaube.dataGridView1.Refresh();
                    }

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
                } //Insert Urlaub to db END

            }  
        }

        public void Add_Urlabe_and_MitStatus()
        {
            //Insert Urlaub to db START******************
            //Validating
            if (dateTimePicker_von.CustomFormat == " ")
            {
                this.dateTimePicker_von.Focus();
                MessageBox.Show("Bitte alle Felder ausfüllen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Validating
            else if (dateTimePicker_bis.CustomFormat == " ")
            {
                this.dateTimePicker_bis.Focus();
                MessageBox.Show("Bitte alle Felder ausfüllen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Validating
            else if (txtAnzahlTage.TextLength == 0)
            {
                this.txtAnzahlTage.Focus();
                MessageBox.Show("Bitte Anzahl der Tage eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    string Query = "insert into um_db.urlaube (Type,Arbeitstage_von,Arbeitstage_bis,Anzahl_Tage,M_Vorname,M_Nachname,DN_Nr) values('" + UrlaubTypeInsert + "','" + this.dateTimePicker_von.Text + "','" + this.dateTimePicker_bis.Text + "','" + this.txtAnzahlTage.Text + "','" + this.txtVorname.Text + "','" + this.txtNachname.Text + "','" + this.comboDNr.Text + "') ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Urlaub erfolgreich eingegeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Close Connection
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //Insert Urlaub to db END******************

            }

            try //Change mitarbeiter status START******************
            {
                //Set Mitarbeiter status as Urlaub
                string Query_status = "update um_db.mitarbeiter set status='" + "urlaub" + "' where M_DNr='" + this.comboDNr.SelectedItem.ToString() + "';";
                MySqlConnection conDataBase_status = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_status = new MySqlCommand(Query_status, conDataBase_status);
                MySqlDataReader myReader_status;

                //Connection Open
                conDataBase_status.Open();
                myReader_status = cmdDataBase_status.ExecuteReader();
                MessageBox.Show("Mitarbeiter wurde als in Urlaub geschpeichert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader_status.Read()) { }

                //Open form Mitarbeiter
                Mitarbeiter obj_mitarbeiter = (Mitarbeiter)Application.OpenForms["Mitarbeiter"];
                //Refresh datagridview on form Urlaube
                obj_mitarbeiter.load_table();
                obj_mitarbeiter.dataGridView1.Update();
                obj_mitarbeiter.dataGridView1.Refresh();

                //Close Connection
                conDataBase_status.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
                //Close Form Mitarbeiter_Status
                Mitarbeiter_Status obj_mitarbeiter_Status = (Mitarbeiter_Status)Application.OpenForms["Mitarbeiter_Status"];
                obj_mitarbeiter_Status.Close();
            } //Change mitarbeiter status END******************
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            //Convert btnSpeichern to string
            string btnTag = this.btnSpeichern.Tag.ToString();

            //button.Tag="save_just_urlaub" to insert just Urlaub
            if (btnTag == "save_just_urlaub")
            {
                Add_just_Urlaub();
            }
            //button.Tag="save_urlaub_and_mitarbeiter_status" to insert Urlaub and edit mitarbeiter_status
            else if (btnTag == "save_urlaub_and_mitarbeiter_status")
            {
                Add_Urlabe_and_MitStatus();
            }
        }

        private void txtDNNr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "select * from um_db.mitarbeiter where M_DNr='" + comboDNr.Text + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    //Getting text fields from database
                    string sVorname = myReader.GetString("Vorname");
                    string sNachname = myReader.GetString("Familienname");
                    txtVorname.Text = sVorname;
                    txtNachname.Text = sNachname;
                }

                btnPrint.Enabled = true;
                btnSpeichern.Enabled = true;

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSchliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDNNr_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Urlaube_Report_New url_rep_new = new Urlaube_Report_New();

            url_rep_new.lblUrlaubTyp.Text = UrlaubTypeInsert;

            url_rep_new.ShowDialog();
        }

    }
}
