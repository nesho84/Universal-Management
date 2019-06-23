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
    public partial class Mitarbeiter_Krankenstand_Add : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Mitarbeiter_Krankenstand_Add()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void calcDays() //Calculate days and days into months code by NESHO
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

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            //Convert btnSpeichern to string
            string btnTag = this.btnSpeichern.Tag.ToString();

            //button text with 3 empty spaces to insert just Krankenstand
            if (btnTag == "save_just_krankenstand")
            {
                Add_just_Krankendstand();
            }
            //button text with 2 empty spaces to insert Krankenstand and edit mitarbeiter_status
            else if (btnTag == "save_krankenstand_and_mitarbeiter_status")
            {
                Add_Krankendstand_and_MitStatus();
            }                
        }

        private void dateTimePicker_von_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_von.CustomFormat = "dd.MM.yyyy";

            if (dateTimePicker_bis.CustomFormat != " ")
            {
                calcDays();
            }
        }

        private void dateTimePicker_bis_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_bis.CustomFormat = "dd.MM.yyyy";

            if (dateTimePicker_von.Text != " ")
            {
                calcDays();
            }
        }

        //Add just krankendstand
        //Insert from Mitarbeiter_Profile
        public void Add_just_Krankendstand()
        {
            //Validating von
            if (dateTimePicker_von.CustomFormat == " ")
            {
                this.dateTimePicker_von.Focus();
                MessageBox.Show("Bitte Arbeitstage von eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ////Validating bis
            //else if (dateTimePicker_bis.CustomFormat == " ")
            //{
            //    //this.dateTimePicker_bis.Focus();
            //    //MessageBox.Show("Bitte alle Felder ausfüllen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //return;
            //}
            ////Validating anzahlTage
            //else if (txtAnzahlTage.TextLength == 0)
            //{
            //    txtAnzahlTage.Text = "0";
            //    //this.txtAnzahlTage.Focus();
            //    //MessageBox.Show("Bitte Anzahl der Tage eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //return;
            //}
            else
            {
                //avoid integer null value
                if (txtAnzahlTage.TextLength == 0)
                {
                    txtAnzahlTage.Text = "0";
                }
                try
                {
                    string Query = "insert into um_db.krankenstand (M_DNr,K_von,K_bis,K_anzahl_tage) values('" + txtDNNr.Text + "','" + this.dateTimePicker_von.Text + "','" + this.dateTimePicker_bis.Text + "','" + this.txtAnzahlTage.Text + "') ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();
                    
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Krakenstand erfolgreich geschpeichert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Refresh datagridview on form Mitarbeiter_Profile
                    Mitarbeiter_Profile obj_mitarbeiter_profile = (Mitarbeiter_Profile)Application.OpenForms["Mitarbeiter_Profile"];
                    //Refresh datagridview on form Krankenstand
                    obj_mitarbeiter_profile.load_table_Krankenstand();
                    obj_mitarbeiter_profile.dataGridView_Krank.Update();
                    obj_mitarbeiter_profile.dataGridView_Krank.Refresh();

                    obj_mitarbeiter_profile.lblCheckRows.Visible = false;

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

        //Add krankenstand and update mitarbeiter_status
        //Insert from Mitarbeiter_Status
        private void Add_Krankendstand_and_MitStatus()
        {
            //Insert Krankenstand START**********************
            //Validating
            if (dateTimePicker_von.CustomFormat == " ")
            {
                this.dateTimePicker_von.Focus();
                MessageBox.Show("Bitte Arbeitstage von eingebenn!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ////Validating bis
            //else if (dateTimePicker_bis.CustomFormat == " ")
            //{
            //    //this.dateTimePicker_bis.Focus();
            //    //MessageBox.Show("Bitte alle Felder ausfüllen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //return;
            //}
            ////Validating anzahlTage
            //else if (txtAnzahlTage.TextLength == 0)
            //{
            //    txtAnzahlTage.Text = "0";
            //    //this.txtAnzahlTage.Focus();
            //    //MessageBox.Show("Bitte Anzahl der Tage eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //return;
            //}
            else
            {
                if (txtAnzahlTage.TextLength == 0)
                {
                    txtAnzahlTage.Text = "0";
                    //this.txtAnzahlTage.Focus();
                    //MessageBox.Show("Bitte Anzahl der Tage eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                }

                try
                {
                    string Query = "insert into um_db.krankenstand (M_DNr,K_von,K_bis,K_anzahl_tage) values('" + txtDNNr.Text + "','" + this.dateTimePicker_von.Text + "','" + this.dateTimePicker_bis.Text + "','" + this.txtAnzahlTage.Text + "') ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();
                    
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Krakenstand erfolgreich geschpeichert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

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
                } //Insert Krankenstand END**********************

                try //Update Mitarbeiter status START**********************
                {
                    string Query = "update um_db.mitarbeiter set status='" + "krank" + "' where M_DNr='" + this.txtDNNr.Text + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();
                    
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Mitarbeiter wurde als Krank geschpeichert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Open form Mitarbeiter
                    Mitarbeiter obj_mitarbeiter = (Mitarbeiter)Application.OpenForms["Mitarbeiter"];
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
                    //Close Form Mitarbeiter_Status
                    Mitarbeiter_Status obj_mitarbeiter_Status = (Mitarbeiter_Status)Application.OpenForms["Mitarbeiter_Status"];
                    obj_mitarbeiter_Status.Close();
                }
                //Update Mitarbeiter status END**********************
            }
        }

        private void Mitarbeiter_Krankenstand_Add_Load(object sender, EventArgs e)
        {
            //Set empty datetimepicker
            this.dateTimePicker_von.CustomFormat = " ";
            this.dateTimePicker_bis.CustomFormat = " ";
        }

    }
}
