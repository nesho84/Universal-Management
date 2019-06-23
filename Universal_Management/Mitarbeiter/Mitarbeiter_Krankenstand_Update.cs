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
    public partial class Mitarbeiter_Krankenstand_Update : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Mitarbeiter_Krankenstand_Update()
        {
            InitializeComponent();
        }

        //Calculate days on edit
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
            //Validating
            if (dateTimePicker_von.CustomFormat == " ")
            {
                this.dateTimePicker_von.Focus();
                MessageBox.Show("Bitte alle Felder ausfüllen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ////Validating
            //else if (dateTimePicker_bis.CustomFormat == " ")
            //{
            //    this.dateTimePicker_bis.Focus();
            //    MessageBox.Show("Bitte alle Felder ausfüllen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            ////Validating
            //else if (txtAnzahlTage.TextLength == 0)
            //{
            //    this.txtAnzahlTage.Focus();
            //    MessageBox.Show("Bitte Anzahl der Tage eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            else
            {
                //avoid integer null value
                if (txtAnzahlTage.TextLength == 0)
                {
                    txtAnzahlTage.Text = "0";
                }
                if (dateTimePicker_bis.CustomFormat == " ")
                {
                    dateTimePicker_bis.CustomFormat = " ";
                }
                try
                {
                    string Query = "update um_db.krankenstand set K_von='" + this.dateTimePicker_von.Text + "', K_bis='" + this.dateTimePicker_bis.Text + "', K_anzahl_tage='" + this.txtAnzahlTage.Text + "' where KID='" + this.lblMITID.Text + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();
                    
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Krakenstand erfolgreich aktualisiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Refresh datagridview on form Mitarbeiter_Profile
                    Mitarbeiter_Profile obj_mitarbeiter_profile = (Mitarbeiter_Profile)Application.OpenForms["Mitarbeiter_Profile"];
                    //Refresh datagridview on form Krankenstand
                    obj_mitarbeiter_profile.dataGridView_Krank.Rows.Remove(obj_mitarbeiter_profile.dataGridView_Krank.CurrentRow);
                    obj_mitarbeiter_profile.dataGridView_Krank.DataSource = null;
                    obj_mitarbeiter_profile.load_table_Krankenstand();
                    obj_mitarbeiter_profile.dataGridView_Krank.Update();
                    obj_mitarbeiter_profile.dataGridView_Krank.Refresh();

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

        private void btnLoschen_Click(object sender, EventArgs e)
        {
            string KID = this.lblMITID.Text;

            if (MessageBox.Show("Sind Sie sicher?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string Query = "delete from um_db.krankenstand where KID='" + KID + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection open
                    conDataBase.Open();
                    
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Krankenstand erfolgreich gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Refresh datagridview on form Mitarbeiter_Profile
                    Mitarbeiter_Profile obj_mitarbeiter_profile = (Mitarbeiter_Profile)Application.OpenForms["Mitarbeiter_Profile"];
                    //Refresh datagridview on form Notizen
                    obj_mitarbeiter_profile.dataGridView_Krank.Rows.Remove(obj_mitarbeiter_profile.dataGridView_Krank.CurrentRow);
                    obj_mitarbeiter_profile.dataGridView_Krank.DataSource = null;
                    obj_mitarbeiter_profile.load_table_Krankenstand();
                    obj_mitarbeiter_profile.dataGridView_Krank.Update();
                    obj_mitarbeiter_profile.dataGridView_Krank.Refresh();

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

        //Get data from database when button edit from somewhere is clicked with posted MITID
        public void view_posted_data_from_editButton()
        {
            try
            {
                string Query = "select * from um_db.krankenstand where KID='" + lblMITID.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read()) 
                {
                    string sK_von = myReader.GetString("K_von");
                    string sK_bis = myReader.GetString("K_bis");
                    string sK_anzahl_tage = myReader.GetString("K_anzahl_tage");

                    dateTimePicker_von.Text = sK_von;
                    dateTimePicker_bis.CustomFormat = sK_bis;
                    txtAnzahlTage.Text = sK_anzahl_tage;
                }
                
                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker_von_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_von.CustomFormat = "dd.MM.yyyy";
            calcDays();
        }

        private void dateTimePicker_bis_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_bis.CustomFormat = "dd.MM.yyyy";
            calcDays();
        }

        private void Mitarbeiter_Krankenstand_Update_Shown(object sender, EventArgs e)
        {
            //calcDays();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Mitarbeiter_Krankenstand_Update_Load(object sender, EventArgs e)
        {
            //Fill textboxes with posted data and known MITID
            view_posted_data_from_editButton();
        }

        //Check Krankendstand dates START*************************************
        public void check_Krankenstand_dates()
        {
            try
            {
                //Select "Seen" rows in database.table "krankendstand"
                string Query1 = "select * from um_db.krankenstand where Gesehen='" + "Nein" + "';";
                MySqlConnection conDataBase1 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase1 = new MySqlCommand(Query1, conDataBase1);
                MySqlDataReader myReader1;

                //Connection Open
                conDataBase1.Open();

                myReader1 = cmdDataBase1.ExecuteReader();

                //check if Old row exist and then update with "Expired"
                if (myReader1.HasRows)
                {
                    while (myReader1.Read())
                    {
                        string datevon = myReader1.GetString("K_von");
                        string datebis = myReader1.GetString("K_bis");
                        string mDN_Nr = myReader1.GetString("M_DNr");

                        //Get date and time Now MissedDates
                        DateTime DateTimeNow_Missed = DateTime.Now.Date;

                        //Krankenstand row von converting to shortdate String
                        DateTime KrankDatum = Convert.ToDateTime(datevon);

                        if (KrankDatum <= DateTimeNow_Missed) //If founded rows "End" are smaller than Today Date
                        {
                            var boxMessage = "DNr: " + mDN_Nr + " ist von (" + datevon + ") bis (" + datebis + ") in Krankendstand.";
                            //Show missed krankendstand in messageBox
                            DialogResult result = MessageBox.Show(boxMessage, "Krankendstand", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            try //Update Krankenstand Table (Gesehen) ***** START *****
                            {
                                string Query2 = "update um_db.krankenstand set Gesehen='" + "Ja" + "' where M_DNr='" + mDN_Nr + "';";
                                MySqlConnection conDataBase2 = new MySqlConnection(constring);
                                MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2);
                                MySqlDataReader myReader2;
                                conDataBase2.Open();
                                myReader2 = cmdDataBase2.ExecuteReader();
                                conDataBase2.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            } //Update krankendstand Table (Gesehen)***** END *****


                            try //Update Mitarbeiter Status***** START *****
                            {
                                string Query3 = "update um_db.mitarbeiter set status='" + "krank" + "' where M_DNr='" + mDN_Nr + "';";
                                MySqlConnection conDataBase3 = new MySqlConnection(constring);
                                MySqlCommand cmdDataBase3 = new MySqlCommand(Query3, conDataBase3);
                                MySqlDataReader myReader3;
                                conDataBase3.Open();
                                myReader3 = cmdDataBase3.ExecuteReader();
                                conDataBase3.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            } //Update Mitarbeiter Status***** END *****
                        }
                    }

                }

                //Close Connection
                conDataBase1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //Check Krankendstand dates END*************************************
    }
}
