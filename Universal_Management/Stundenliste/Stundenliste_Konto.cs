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
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;
using Microsoft.Reporting;
using Microsoft.ReportingServices;

namespace Universal_Management
{
    public partial class Stundenliste_Konto : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456;pooling=false;";

        public Stundenliste_Konto()
        {
            InitializeComponent();
        }

        private void RegStd_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 44 && AuszahlenStd.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void comboJahr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try //stundenliste_konto
            {
                string Query = "select * from um_db.stundenliste_konto where Jahr='" + comboJahr.SelectedItem.ToString() + "' and DNr='" + txtDNr.Text + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();

                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            //Getting text fields from database
                            string sAktualisiert = myReader.GetString("Datum_Aktualisiert");
                            string sKontostand = myReader.GetString("Kontostand");

                            this.txtKontostand.Text = sKontostand;
                            this.txtAktualisiert.Text = sAktualisiert;

                            //If kontostand < 0
                            kontostand_permission_buttons();
                        }
                    }
                    else
                    {
                        this.txtKontostand.Text = "0";
                        this.txtAktualisiert.Clear();

                        //If kontostand < 0
                        kontostand_permission_buttons();
                    }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void Stundenliste_Konto_Load(object sender, EventArgs e)
        {
            string Jahrr = DateTime.Now.Year.ToString();
            comboJahr.SelectedItem = Jahrr;

            //If kontostand < 0
            kontostand_permission_buttons();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kontostand_permission_buttons()
        {
            //If kontostand < 0
            //Convert Kontostand textbox to integer
            decimal Kontostand;
            Kontostand = Convert.ToDecimal(txtKontostand.Text);
            Kontostand = decimal.Parse(txtKontostand.Text);

            if (Kontostand > 0)
            {
                txtKontostand.Text = "+" + Kontostand;
                txtKontostand.BackColor = Color.PaleGreen;
                AuszahlenStd.Enabled = true;                
                btnAuszahlen.Enabled = true;
            }
            else
            {
                txtKontostand.BackColor = Color.Tomato;

                AuszahlenStd.Enabled = false;
                btnAuszahlen.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Get date and time Now
            DateTime DateTimeNow = DateTime.Now;
            DateTime DateNow = Convert.ToDateTime(DateTimeNow);

            //Show MessageBox
            var myMessageBox = new MyMessageBox();
            myMessageBox.btnJa.Text = "Ja";
            myMessageBox.btnNein.Text = "Nein";
            myMessageBox.Text = "Wichtige Hinweis:";
            myMessageBox.txtText.Text= "\n   Sind Sie sicher alle Stunden auszuzahlen?";

            DialogResult result = myMessageBox.ShowDialog();

            //If MessageBox "OK" Clicked
            if (result == DialogResult.OK)
            {
                try
                {
                    string Query = "update um_db.stundenliste_konto set Kontostand='" + "0" + "', Datum_Aktualisiert='" + DateNow.ToString() + "' where DNr='" + this.txtDNr.Text + "' and Jahr='" + comboJahr.SelectedItem.ToString() + "';";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Stunden ausbezahlt.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    txtKontostand.Text = "0";
                    txtAktualisiert.Text = DateNow.ToString();

                    //Close Connection
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAuszahlen_Click(object sender, EventArgs e)
        {
            //Convert Kontostand textbox to integer
            decimal Kontostand;
            Kontostand = Convert.ToDecimal(txtKontostand.Text);
            Kontostand = decimal.Parse(txtKontostand.Text);

            //Convert Kontostand textbox to integer
            decimal RegStdtoDecimal;
            RegStdtoDecimal = Convert.ToDecimal(AuszahlenStd.Text);
            RegStdtoDecimal = decimal.Parse(AuszahlenStd.Text);

            //AUsbezahlte stunden Calculated
            decimal ausbezahlteStd = Kontostand - RegStdtoDecimal;


            //Get date and time Now
            DateTime DateTimeNow = DateTime.Now;
            DateTime DateNow = Convert.ToDateTime(DateTimeNow);

            //Show MessageBox
            var myMessageBox = new MyMessageBox();
            myMessageBox.btnJa.Text = "Ja";
            myMessageBox.btnNein.Text = "Nein";
            myMessageBox.Text = "Wichtige Hinweis:";
            myMessageBox.txtText.Text = "\n   Sind Sie sicher " + (AuszahlenStd.Text) + " Stunden auszuzahlen?";
            DialogResult result = myMessageBox.ShowDialog();

            //If MessageBox "OK" Clicked
            if (result == DialogResult.OK)
            {
                try
                {
                    string Query = "update um_db.stundenliste_konto set Kontostand='" + ausbezahlteStd.ToString() + "', Datum_Aktualisiert='" + DateNow.ToString() + "' where DNr='" + this.txtDNr.Text + "' and Jahr='" + comboJahr.SelectedItem.ToString() + "';";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Stunden ausbezahlt.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    txtKontostand.Text = ausbezahlteStd.ToString();
                    txtAktualisiert.Text = DateNow.ToString();
                    AuszahlenStd.Text = "0,00";

                    //Close Connection
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Stundenliste_Konto_Report std_konto_report = new Stundenliste_Konto_Report();
            std_konto_report.ShowDialog();
        }
    }
}
