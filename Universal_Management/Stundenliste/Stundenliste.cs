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
    public partial class Stundenliste : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Message for textboxes
        ToolTip t1 = new ToolTip();

        public Stundenliste()
        {
            InitializeComponent();

            Fillcombobox1();
        }

        //Fill combobox1 with db Mitarbeiter
        void Fillcombobox1()
        {
            try
            {
                string Query = "select * from um_db.mitarbeiter where status<>'" + "passiv" + "' and M_DNr<>'" + "0" + "' ORDER BY M_DNr ASC;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Open Connection
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    double sDNr = myReader.GetDouble("M_DNr");
                    //string sVorname= myReader.GetString("Vorname");
                    //string sName = myReader.GetString("Familienname");
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

        private void Stundenliste_Load(object sender, EventArgs e)
        {
            GetMonthNameGerman();

            getData_form_Load();
        }

        DataTable dbdataset;

        public void getData_form_Load()
        {
            string Jahrr = DateTime.Now.Year.ToString();
            //List Users from database START************
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select DNr, Familienname, Vorname, Firma as Firma_Leiarbeiter, Monat, Jahr, RegulareStunden as ReguläreStd, UberStunden as ÜberStd, GesamtStunden as GesamtStd, StundenDifferenz, Kommentar, stdID from um_db.stundenliste_monat where Jahr='" + Jahrr + "';", conDataBase);
                
                //Open Connection
                conDataBase.Open();

                //Fill datagridview
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //Hide Columns
                DataGridViewColumn column8 = dataGridView1.Columns[8];
                column8.Visible = false;
                DataGridViewColumn column9 = dataGridView1.Columns[9];
                column9.Visible = false;
                //Column stdID
                DataGridViewColumn column11 = dataGridView1.Columns[11];
                column11.Visible = false;

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show(ex.Message);
            }
            //List Users from database END************
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBearbeiten_Click(object sender, EventArgs e)
        {
            Stundenliste_Add_Monthly stundenliste_add = new Stundenliste_Add_Monthly();
            stundenliste_add.ShowDialog();
        }

        private void comboDNr_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //Clear textboxes
            txtSoll.Clear();
            txtIst.Clear();
            txtDif.Clear();
            
            try //Get StundenListe
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select DNr, Familienname, Vorname, Firma as Firma_Leiarbeiter, Monat, Jahr, RegulareStunden as ReguläreStd, UberStunden as ÜberStd, GesamtStunden as GesamtStd, StundenDifferenz, Kommentar, stdID from um_db.stundenliste_monat where DNr='" + comboDNr.SelectedItem.ToString() + "';", conDataBase);
                
                //Open Connection
                conDataBase.Open();

                //Fill datagridview
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                this.dataGridView1.DataSource = null;
                this.dataGridView1.Refresh();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //Hide Columns
                DataGridViewColumn column8 = dataGridView1.Columns[8];
                column8.Visible = false;
                DataGridViewColumn column9 = dataGridView1.Columns[9];
                column9.Visible = false;
                //Column stdID
                DataGridViewColumn column11 = dataGridView1.Columns[11];
                column11.Visible = false;

                //comboBox1.Enabled = false;
                comboJahr.Visible = true;
                lblJahr.Visible = true;
                comboJahr.Enabled = true;

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show(ex.Message);
            }

            try //Mitarbeiter name and surname
            {
                string Query = "select * from um_db.mitarbeiter where M_DNr='" + comboDNr.SelectedItem.ToString() + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Open Connection
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    //Getting text fields from database
                    string sVorname = myReader.GetString("Vorname");
                    string sNachname = myReader.GetString("Familienname");

                    string sM_RegStunden = myReader.GetString("M_RegStunden");
                    txtSoll.Text = sM_RegStunden;

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
        }

        ////get 24 hours date format
        public void GetMonthNameGerman()
        {
            string Tagg = (new CultureInfo("de")).DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            string Monatt = (new CultureInfo("de")).DateTimeFormat.GetMonthName(DateTime.Now.Month);
            string Jahrr = DateTime.Now.Year.ToString();
        }

        private void comboJahr_SelectedIndexChanged(object sender, EventArgs e)
        {
                try //Get StundenListe
                {
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand("select DNr, Familienname, Vorname, Firma as Firma_Leiarbeiter, Monat, Jahr, RegulareStunden as ReguläreStd, UberStunden as ÜberStd, GesamtStunden as GesamtStd, StundenDifferenz, Kommentar, stdID from um_db.stundenliste_monat where Jahr='" + comboJahr.SelectedItem.ToString() + "' and DNr='" + comboDNr.SelectedItem.ToString() + "';", conDataBase);
                    
                    //Open Connection
                    conDataBase.Open();

                    //Fill datagridview
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDataBase;
                    dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.Refresh();

                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;
                    sda.Update(dbdataset);

                    //Hide Columns
                    DataGridViewColumn column8 = dataGridView1.Columns[8];
                    column8.Visible = false;
                    DataGridViewColumn column9 = dataGridView1.Columns[9];
                    column9.Visible = false;
                    //Column stdID
                    DataGridViewColumn column11 = dataGridView1.Columns[11];
                    column11.Visible = false;

                    comboDNr.Enabled = false;
                    comboMonat.Visible = true;
                    lblMonat.Visible = true;
                    comboMonat.Enabled = true;

                    //Close Connection
                    conDataBase.Close();
                }
                catch (Exception /*ex*/)
                {
                    //MessageBox.Show(ex.Message);
                }
        }

        private void comboMonat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try //Get StundenListe
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select DNr, Familienname, Vorname, Firma as Firma_Leiarbeiter, Monat, Jahr, RegulareStunden as ReguläreStd, UberStunden as ÜberStd, GesamtStunden as GesamtStd, StundenDifferenz, Kommentar, stdID from um_db.stundenliste_monat where Monat='" + comboMonat.SelectedItem.ToString() + "' and Jahr='" + comboJahr.SelectedItem.ToString() + "' and DNr='" + comboDNr.SelectedItem.ToString() + "';", conDataBase);
                
                //Open Connection
                conDataBase.Open();

                //Fill datagridview
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                this.dataGridView1.DataSource = null;
                this.dataGridView1.Refresh();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //Hide Columns
                DataGridViewColumn column8 = dataGridView1.Columns[8];
                column8.Visible = false;
                DataGridViewColumn column9 = dataGridView1.Columns[9];
                column9.Visible = false;
                //Column stdID
                DataGridViewColumn column11 = dataGridView1.Columns[11];
                column11.Visible = false;

                comboDNr.Enabled = true;
                comboJahr.Enabled = false;

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void comboMonat_DropDown(object sender, EventArgs e)
        {
            comboJahr.Enabled = false;
            comboDNr.Enabled = false;
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboMonat.Enabled = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Code here
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //RELEASE BUTON
                btnStdLoschen.Enabled = true;

                //Load data from datagridview
                txtIst.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtDif.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();

                //Convert GesStd textbox to integer
                decimal anIntegertxtDif;
                anIntegertxtDif = Convert.ToDecimal(txtDif.Text);
                anIntegertxtDif = decimal.Parse(txtDif.Text);

                if (anIntegertxtDif > 0)
                {
                    txtDif.Text = "+" + this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
                }

                string DNrFrom = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

                try //Mitarbeiter
                {
                    string Query = "select * from um_db.mitarbeiter where M_DNr='" + DNrFrom + "';";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Open Connection
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    while (myReader.Read())
                    {
                        //Getting text fields from database
                        string sVorname = myReader.GetString("Vorname");
                        string sNachname = myReader.GetString("Familienname");

                        string sM_RegStunden = myReader.GetString("M_RegStunden");
                        txtSoll.Text = sM_RegStunden;
                    }


                    //Close Connection
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                btnStdLoschen.Enabled = false;

                txtSoll.Clear();
                txtIst.Clear();
                txtDif.Clear();
            }
        }

        private void btnKonto_Click(object sender, EventArgs e)
        {
            //Now Year
            string Jahrr = DateTime.Now.Year.ToString();
            //Check if A DNr exist in db Table Stundenliste_konto
            string DNrForKonto = this.comboDNr.SelectedItem.ToString();
            //DateTime Now
            DateTime dateTime = DateTime.Now;
            DateTime nowTime = Convert.ToDateTime(dateTime);

            try //stundenliste_konto
            {
                string Query = "select * from um_db.stundenliste_konto where DNr='" + DNrForKonto + "' and Jahr='" + Jahrr + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Open Connection
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        //Show Konto form
                        Stundenliste_Konto std_konto = new Stundenliste_Konto();

                        std_konto.txtDNr.Text = this.comboDNr.SelectedItem.ToString();
                        std_konto.txtVorname.Text = this.txtVorname.Text;
                        std_konto.txtNachname.Text = this.txtNachname.Text;
                        std_konto.txtAktualisiert.Text = myReader.GetString("Datum_Aktualisiert");

                        std_konto.txtKontostand.Text = myReader.GetString("Kontostand");

                        std_konto.ShowDialog();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Stundenliste_Report std_report = new Stundenliste_Report();

            std_report.ShowDialog();
        }

        private void comboDNr_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try //Release konto and print buttons if stundenliste for this DNr exist
            {
                string Query = "select DNr from um_db.stundenliste_monat where DNr='" + comboDNr.SelectedItem.ToString() + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Open Connection
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                    if (count > 0)
                    {
                        btnKonto.Enabled = true;
                        btnPrint.Enabled = true;
                        //btnStdLoschen.Enabled = true;
                    }
                    else if (count == 0)
                    {
                        btnKonto.Enabled = false;
                        btnPrint.Enabled = false;
                        btnStdLoschen.Enabled = false;
                    }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnStdLoschen.Enabled = true;
            }
        }

        private void btnStdLoschen_Click(object sender, EventArgs e)
        {
            string txtstdID = this.dataGridView1.CurrentRow.Cells[11].Value.ToString();

            if (MessageBox.Show("Sind Sie sicher?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    string Query = "delete from um_db.stundenliste_monat where stdID='" + txtstdID + "';";
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Open Connection
                    conDataBase.Open();
                    
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Stunden wurden gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    //Refresh dataGridView1
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    this.dataGridView1.Refresh();

                    //Release buttons
                    btnStdLoschen.Enabled = false;
                }
            }
        }
    }
}
