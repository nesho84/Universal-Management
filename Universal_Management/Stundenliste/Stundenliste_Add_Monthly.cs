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
    public partial class Stundenliste_Add_Monthly : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Message for textboxes
        ToolTip t1 = new ToolTip();

        public Stundenliste_Add_Monthly()
        {
            InitializeComponent();
            GetMonthNameGerman();
            //Firmenbuch
            Fillcombobox3();
            //Mitarbeiter
            Fillcombobox1();
        }

        //Get week number
        public int GetWeekNumber(DateTime dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            txtKW.Text = weekNum.ToString();

            return weekNum;
        }
        //Fill combobox1 with db Firmenbuch
        public void Fillcombobox3()
        {
            try
            {
                string Query = "select * from um_db.firmenbuch;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString("Firma");

                    comboFirma.Items.Add(sName);
                }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Fill combobox1 with db with Mitarbeiter
        void Fillcombobox1()
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
                    string sDNr = myReader.GetString("M_DNr");

                    comboDNr.Items.Add(sDNr);
                }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ////get 24 hours date format
        public void GetMonthNameGerman()
        {
            txtTag.Text = (new CultureInfo("de")).DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            txtMonat.Text = (new CultureInfo("de")).DateTimeFormat.GetMonthName(DateTime.Now.Month);
            txtJahr.Text = DateTime.Now.Year.ToString();
        }

        private void Stundenliste_Add_Load(object sender, EventArgs e)
        {
            if (comboDNr.Items.Count > 0)
            {
                comboDNr.SelectedIndex = 0;
            }
            if (comboDNr.SelectedIndex > -1)
            {
                //comboFirma.SelectedIndex = 0;
                comboMonat.SelectedIndex = 0;
                comboJahr.SelectedItem = txtJahr.Text;

                GetMonthNameGerman();

                GetWeekNumber(DateTime.Now);

                //RegStd.Mask = "00/00/0000";
            }
            else
            {
                this.btnSpeichern.Enabled = false;
                RegStd.ReadOnly = true;
                UberStd.ReadOnly = true;
            }
        }

        public void cal_stunden()
        {
            if (RegStd.TextLength == 0)
            {
                //Error
            }
            else if (UberStd.TextLength == 0)
            {
                //Error
            }
            else
            {
                //Convert RegStd textbox to integer
                decimal anIntegerRegStd;
                anIntegerRegStd = Convert.ToDecimal(RegStd.Text);
                anIntegerRegStd = decimal.Parse(RegStd.Text);

                //Convert UberStd textbox to integer
                decimal anIntegerUberStd;
                anIntegerUberStd = Convert.ToDecimal(UberStd.Text);
                anIntegerUberStd = decimal.Parse(UberStd.Text);

                //Calculate RegStunden and Uberstunden
                decimal GesStdSum = anIntegerRegStd + anIntegerUberStd;
                GesStd.Text = GesStdSum.ToString();
            }
        }

        public void calc_stunden_dif()
        {
            //Convert GesStd textbox to integer
            decimal anIntegerGesStd;
            anIntegerGesStd = Convert.ToDecimal(GesStd.Text);
            anIntegerGesStd = decimal.Parse(GesStd.Text);
            //Convert txtMonatStd textbox to integer
            decimal anIntegerMonatStd;
            anIntegerMonatStd = Convert.ToDecimal(txtMonatlicheStd.Text);
            anIntegerMonatStd = decimal.Parse(txtMonatlicheStd.Text);

            decimal DecStdDif = anIntegerGesStd - anIntegerMonatStd;
            txtStdDif.Text = DecStdDif.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "select * from um_db.mitarbeiter where M_DNr='" + comboDNr.SelectedItem.ToString() + "';";
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
                    string sFirma = myReader.GetString("M_Leiarbeiter");
                    string dRegStd = myReader.GetString("M_RegStunden");

                    txtMonatlicheStd.Text = dRegStd;
                    txtVorname.Text = sVorname;
                    txtNachname.Text = sNachname;
                    comboFirma.SelectedItem = sFirma;
                }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Mitarbeiter Dienstnummer.", this.comboDNr);
        }

        private void comboBox3_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Mitarbeiter Firma.", this.comboFirma);
        }

        private void GesStd_TextChanged(object sender, EventArgs e)
        {
            calc_stunden_dif();
        }

        private void RegStd_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 44 && RegStd.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void UberStd_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 44 && UberStd.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void RegStd_TextChanged(object sender, EventArgs e)
        {
            if (UberStd.TextLength == 0)
            {
                UberStd.Text = "0,00";
                cal_stunden();
            }
            else
            {
                cal_stunden();
            }
        }

        private void UberStd_TextChanged(object sender, EventArgs e)
        {
            if (RegStd.TextLength == 0)
            {
                RegStd.Text = "0,00";
                cal_stunden();
            }
            else
            {
                cal_stunden();
            }
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            //Validating
            if (RegStd.TextLength == 0)
            {
                this.RegStd.Focus();
                MessageBox.Show("Bitte reguläre Stunden eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (RegStd.Text == "0,00")
            {
                this.RegStd.Focus();
                MessageBox.Show("Bitte reguläre Stunden eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //First create Stunden konto
                create_stunden_konto();

                //Now Year
                string Jahrr = DateTime.Now.Year.ToString();
                //Check if A DNr exist in db Table Stundenliste_konto
                string DNrForKonto = this.comboDNr.SelectedItem.ToString();
                //DateTime Now
                DateTime dateTime = DateTime.Now;
                DateTime nowTime = Convert.ToDateTime(dateTime);

                try //Insert stunden START
                {
                    string Query2 = "insert into um_db.stundenliste_monat (DNr, Familienname, Vorname, Firma, Monat, Jahr, RegulareStunden, UberStunden, GesamtStunden, StundenDifferenz, Kommentar, Datum) values('" + this.comboDNr.SelectedItem.ToString() + "','" + this.txtNachname.Text + "','" + this.txtVorname.Text + "','" + this.comboFirma.SelectedItem.ToString() + "','" + this.comboMonat.SelectedItem.ToString() + "','" + this.comboJahr.SelectedItem.ToString() + "','" + this.RegStd.Text + "','" + this.UberStd.Text + "','" + this.GesStd.Text + "','" + this.txtStdDif.Text + "','" + this.txtKommentar.Text + "','" + this.dateTimeNow.Text + "') ;";
                    MySqlConnection conDataBase2 = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2);
                    MySqlDataReader myReader2;

                    //Connection Open
                    conDataBase2.Open();

                    myReader2 = cmdDataBase2.ExecuteReader();

                    //Update Kontostand START***************************
                    try //Select Kontostand
                    {
                        string Query3 = "select * from um_db.stundenliste_konto where DNr='" + DNrForKonto + "' and Jahr='" + this.comboJahr.SelectedItem.ToString() + "';";
                        MySqlConnection conDataBase3 = new MySqlConnection(constring);
                        MySqlCommand cmdDataBase3 = new MySqlCommand(Query3, conDataBase3);
                        MySqlDataReader myReader3;

                        //Open Connection
                        conDataBase3.Open();

                        myReader3 = cmdDataBase3.ExecuteReader();
                        if (myReader3.HasRows == true)
                        {
                            while (myReader3.Read())
                            {
                                string kontostand = myReader3.GetString("Kontostand");
                                //Convert kontostand to decimal
                                decimal anIntegerkontostand;
                                anIntegerkontostand = Convert.ToDecimal(kontostand);
                                anIntegerkontostand = decimal.Parse(kontostand);

                                //Convert txtStdDif to decimal
                                decimal anIntegertxtStdDif;
                                anIntegertxtStdDif = Convert.ToDecimal(txtStdDif.Text);
                                anIntegertxtStdDif = decimal.Parse(txtStdDif.Text);

                                decimal DecKontoStand = anIntegerkontostand + anIntegertxtStdDif;
                                //for db
                                string KontoStandCalculated = DecKontoStand.ToString();

                                try //Update kontostand
                                {
                                    string Query = "update um_db.stundenliste_konto set Kontostand='" + KontoStandCalculated + "', Datum_Aktualisiert='" + nowTime + "', Jahr='" + this.comboJahr.SelectedItem.ToString() + "' where DNr='" + this.comboDNr.Text + "' and Jahr='" + this.comboJahr.SelectedItem.ToString() + "';";
                                    MySqlConnection conDataBase = new MySqlConnection(constring);
                                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                                    MySqlDataReader myReader;

                                    conDataBase.Open();
                                    myReader = cmdDataBase.ExecuteReader();

                                    //MessageBox.Show("Kontostand Aktualisiert..", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (myReader.HasRows == true)
                                    {
                                        while (myReader.Read()) { }
                                    }
                                    conDataBase.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }

                        //Close Connection
                        conDataBase3.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }//Update Kontostand END******************************                    

                    MessageBox.Show("Monatliche Stunden erfolgreich eingegeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader2.Read()) { }

                    //Refresh datagridview on Stundenliste Form
                    Stundenliste std = (Stundenliste)Application.OpenForms["Stundenliste"];
                    std.getData_form_Load();
                    std.dataGridView1.Update();
                    std.dataGridView1.Refresh();

                    //Close Connection
                    conDataBase2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Close();
                }//Insert Stunden END
            }

        }

        //Create Stundenliste Konto
        public void create_stunden_konto()
        {
            //DateTime Now
            DateTime dateTime = DateTime.Now;
            DateTime nowTime = Convert.ToDateTime(dateTime);

            try //stundenliste_konto
            {
                string Query = "select * from um_db.stundenliste_konto where DNr='" + this.comboDNr.SelectedItem.ToString() + "' and Jahr='" + this.comboJahr.SelectedItem.ToString() + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();

                if (!(myReader.HasRows))
                {
                    try //Create Konto
                    {
                        string Query2 = "insert into um_db.stundenliste_konto (DNr, Jahr, Datum_Aktualisiert) values('" + this.comboDNr.SelectedItem.ToString() + "','" + this.comboJahr.SelectedItem.ToString() + "','" + nowTime + "') ;";
                        MySqlConnection conDataBase2 = new MySqlConnection(constring);
                        MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2);
                        MySqlDataReader myReader2;

                        //Connection Open
                        conDataBase2.Open();

                        myReader2 = cmdDataBase2.ExecuteReader();

                        //MessageBox.Show("Kontostand Gespeichert..", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);   

                        //Close Connection
                        conDataBase2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
    }
}
