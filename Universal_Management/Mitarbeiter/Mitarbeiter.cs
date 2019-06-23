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
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Universal_Management
{
    public partial class Mitarbeiter : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Mitarbeiter()
        {
            InitializeComponent();

            //Load datagridview1
            load_table();

            //Search Database with autocomplete
            AutoCompleteText();
        }

        //Load datagridview1
        DataTable dbdataset;

        //String to select query from db
        string aktivvv = "aktiv";
        string krankkk = "krank";
        string urlaubbb = "urlaub";

        //Load Table Mitarbeiter
        public void load_table()
        {
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select MITID, M_DNr as DNr, Familienname, Vorname, Geschlecht, Strasse as Adresse, Plz_Ort as PLZ_Ort, Tel, Email, G_Datum as Geb_Datum, Bild from um_db.mitarbeiter WHERE status='" + aktivvv + "' or status='" + krankkk + "' or status='" + urlaubbb + "' ORDER BY M_DNr ASC ;", conDataBase);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //Connection Close
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Search Database with autocomplete
        void AutoCompleteText()
        {
            Search_txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Search_txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            try
            {
                string Query = "select * from um_db.mitarbeiter;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sFamilienname = myReader.GetString("Familienname");
                    string sVorname = myReader.GetString("Vorname");
                    coll.Add(sFamilienname);
                    coll.Add(sVorname);
                }

                //Connection Close
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Search_txt.AutoCompleteCustomSource = coll;
        }

        public void Mitarbeiter_Load(object sender, EventArgs e)
        {            
            //release btnDrucken
            if (dataGridView1.Rows.Count > 0)
            {
                btnPrint.Enabled = true;
            }
            else
            {
                btnPrint.Enabled = false;
            }

            //Count mitarb.
            count_mitarbeiter();

            //Stop datagridview self selection at start
            dataGridView1.ClearSelection();

            //Design datagridview columns before starting form
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Visible = false;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 30;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 80;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 80;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 50;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 80;
            //Plz ort
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 40;
            column6.HeaderText = "PLZ Ort";
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Width = 80;
            DataGridViewColumn column8 = dataGridView1.Columns[8];
            column8.Width = 100;
            //GebDatum
            DataGridViewColumn column9 = dataGridView1.Columns[9];
            column9.Width = 50;
            column9.HeaderText = "Geb.Datum";
            DataGridViewColumn column10 = dataGridView1.Columns[10];
            column10.Width = 40;
            //Fit Images to dataGridView Table List
            if (dataGridView1.Columns[10] is DataGridViewImageColumn)
            {
                ((DataGridViewImageColumn)dataGridView1.Columns[10]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
        }

        //Get Count mitarbeiterAnzahl Rows for this Event ***** START ************************************
        public void count_mitarbeiter()
        {
            try
            {
                string Query4 = "select count(*) from um_db.mitarbeiter WHERE  (status <> 'passiv');";
                MySqlConnection conDataBase4 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase4 = new MySqlCommand(Query4, conDataBase4);
                
                //Connection Open
                conDataBase4.Open();

                int SeenRows = 0;
                SeenRows = int.Parse(cmdDataBase4.ExecuteScalar().ToString());
                if (SeenRows > 0)
                {
                    lblAnzahl.Text = SeenRows.ToString();
                }
                else if (SeenRows == 0)
                {
                    this.dataGridView1.DataSource = null;
                    load_table();
                }

                //Connection Close
                conDataBase4.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Get Count mitarbeiterAnzahl Rows for this Event ***** END ***************************************

        private void button1_Click_1(object sender, EventArgs e)
        {
            var Mitarbeiter_Add = new Mitarbeiter_Add();

            this.Hide();

            Mitarbeiter_Add.ShowDialog();
        }

        //Search Database with autocomplete
        private void Search_txt_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("Familienname + Vorname LIKE '%{0}%'", Search_txt.Text);
            dataGridView1.DataSource = DV;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Show_Profile();
        }

        public void Show_Profile()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Mitarbeiter_Profile M_Profile = new Mitarbeiter_Profile();

                //Load data from ddb table Mitarbeiter
                M_Profile.lblMID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                M_Profile.lblM_DNr.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

                this.Hide();

                M_Profile.ShowDialog();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Show_Profile();
            }
        }

        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Show_Profile();
                }
            }
        }

        private void Mitarbeiter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var M_Status = new Mitarbeiter_Status();

                //Load data from datagridview from this
                M_Status.txtM_DNr.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

                M_Status.ShowDialog();
            }
        }

        //Enable Status and Ansicht buttons when entering a row
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnAnsicht.Enabled = true;
                btnStatus.Enabled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var mitarbeiter_Report = new Mitarbeiter_Report();
            mitarbeiter_Report.ShowDialog();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //try
            //{
            //    dataGridView1.DataSource = null;
            //    dataGridView1.DataSource = dbdataset;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        //Check Visum dates START*************************************
        public void check_expired_visum()
        {
            try
            {
                //Select Erlaubnis rows in database.table "Mitarbeiter"
                string Query1 = "select * from um_db.mitarbeiter where M_DNr <> '" + "0" + "'";
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
                        //Get db strings
                        string erlaubnis = myReader1.GetString("Erlaubnis");
                        string mDN_Nr = myReader1.GetString("M_DNr");

                        //Just string from db that are DateTime (Format 24.11.1984, Language: DE)
                        DateTime myDate;
                        if ((DateTime.TryParseExact(erlaubnis, "dd.MM.yyyy", new System.Globalization.CultureInfo("de-DE"), System.Globalization.DateTimeStyles.None, out myDate)))
                        {
                            //Get date and time Now
                            DateTime DateTimeNow = DateTime.Now.Date;
                            //Erlaubnis row von converting to shortdate
                            DateTime ExpireDatum = Convert.ToDateTime(erlaubnis);

                            if (ExpireDatum.ToShortDateString() == DateTime.Now.AddDays(30).ToShortDateString())
                            {
                                //Fix 30 Days
                                //Calculate days left
                                TimeSpan daysLeft = ExpireDatum - DateTimeNow;
                                int daysLeftDiff = daysLeft.Days;

                                var boxMessage = "Mitarbeiter mit DNr (" + mDN_Nr + ") hat Arbeitserlaubnis gültig bis " + erlaubnis + ". \nNoch " + daysLeftDiff.ToString() + " Tage.";

                                //Insert into nachrichten START **************************************************************
                                try //check if msg exist to avoid duplicate start
                                {
                                    string Query_checkmsg = "select * from um_db.nachrichten where msg='" + boxMessage + "' ;";
                                    MySqlConnection conDataBase_checkmsg = new MySqlConnection(constring);
                                    MySqlCommand cmdDataBase_checkmsg = new MySqlCommand(Query_checkmsg, conDataBase_checkmsg);
                                    MySqlDataReader myReader_checkmsg;
                                    //Open Connection
                                    conDataBase_checkmsg.Open();
                                    myReader_checkmsg = cmdDataBase_checkmsg.ExecuteReader();
                                    if (!(myReader_checkmsg.HasRows))
                                    {
                                        try
                                        {
                                            //Get date and time Now
                                            DateTime DateNow = DateTime.Now;
                                            string Query = "insert into um_db.nachrichten (msg,menu,datetime) values('" + boxMessage + "','" + "Mitarbeiter" + "','" + DateNow + "');";
                                            MySqlConnection conDataBase = new MySqlConnection(constring);
                                            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                                            MySqlDataReader myReader;
                                            //Open Connection
                                            conDataBase.Open();
                                            myReader = cmdDataBase.ExecuteReader();
                                            while (myReader.Read()) { }
                                            //Close Connection
                                            conDataBase.Close();
                                        }
                                        catch (Exception)
                                        {
                                            MessageBox.Show("Mitarbeiter Visum Fehler: in Nachrichten eingeben!");
                                        }
                                    }
                                    //Close Connection
                                    conDataBase_checkmsg.Close();
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Mitarbeiter Visum Fehler: in Nachrichten check!");
                                } //check if msg exist to avoid duplicate end                             
                                //Insert into nachrichten END ******************************************************************
                            }
                            else if (ExpireDatum.ToShortDateString() == DateTime.Now.AddDays(21).ToShortDateString())
                            {
                                //Fix 30 Days
                                //Calculate days left
                                TimeSpan daysLeft = ExpireDatum - DateTimeNow;
                                int daysLeftDiff = daysLeft.Days;

                                var boxMessage = "Mitarbeiter mit DNr (" + mDN_Nr + ") hat Arbeitserlaubnis gültig bis: " + erlaubnis + ". \n Noch " + daysLeftDiff.ToString() + " Tage.";

                                //Insert into nachrichten START **************************************************************
                                try //check if msg exist to avoid duplicate start
                                {
                                    string Query_checkmsg = "select * from um_db.nachrichten where msg='" + boxMessage + "' ;";
                                    MySqlConnection conDataBase_checkmsg = new MySqlConnection(constring);
                                    MySqlCommand cmdDataBase_checkmsg = new MySqlCommand(Query_checkmsg, conDataBase_checkmsg);
                                    MySqlDataReader myReader_checkmsg;
                                    //Open Connection
                                    conDataBase_checkmsg.Open();
                                    myReader_checkmsg = cmdDataBase_checkmsg.ExecuteReader();
                                    if (!(myReader_checkmsg.HasRows))
                                    {
                                        try
                                        {
                                            //Get date and time Now
                                            DateTime DateNow = DateTime.Now;
                                            string Query = "insert into um_db.nachrichten (msg,menu,datetime) values('" + boxMessage + "','" + "Mitarbeiter" + "','" + DateNow + "');";
                                            MySqlConnection conDataBase = new MySqlConnection(constring);
                                            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                                            MySqlDataReader myReader;
                                            //Open Connection
                                            conDataBase.Open();
                                            myReader = cmdDataBase.ExecuteReader();
                                            while (myReader.Read()) { }
                                            //Close Connection
                                            conDataBase.Close();
                                        }
                                        catch (Exception)
                                        {
                                            MessageBox.Show("Mitarbeiter Geb.Datum Fehler: in Nachrichten eingeben!");
                                        }
                                    }
                                    //Close Connection
                                    conDataBase_checkmsg.Close();
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Mitarbeiter Geb.Datum Fehler: in Nachrichten check!");
                                } //check if msg exist to avoid duplicate end                             
                                //Insert into nachrichten END ******************************************************************
                            }
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
        } //Check Visum dates END*************************************

        //Check Birthdays START*************************************
        public void check_Birthdays()
        {
            //Get date and time Now
            DateTime DateNow = DateTime.Now;
            try
            {
                //Select "Seen" rows in database.table "events"
                string Query1 = "select * from um_db.mitarbeiter where M_DNr <> '" + "0" + "';";
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
                        string gebDatum = myReader1.GetString("G_Datum");
                        string mDN_Nr = myReader1.GetString("M_DNr");

                        //Convert G_Datum row to DateTime
                        DateTime GebDatum_converted = Convert.ToDateTime(gebDatum); //Musst be standard Format (dd.MM.yyyy 00:00:00) everywhere

                        if (GebDatum_converted.Day == DateTime.Now.AddDays(1).Day && GebDatum_converted.Month == DateTime.Now.Month)
                        {
                            var boxMessage = "Mitarbeiter mit DNr (" + mDN_Nr + ") hat am " + DateNow.AddDays(1).ToShortDateString() + " Geburtstag.";

                            //Insert into nachrichten START **************************************************************
                            try //check if msg exist to avoid duplicate start
                            {
                                string Query_checkmsg = "select * from um_db.nachrichten where msg='" + boxMessage + "' ;";
                                MySqlConnection conDataBase_checkmsg = new MySqlConnection(constring);
                                MySqlCommand cmdDataBase_checkmsg = new MySqlCommand(Query_checkmsg, conDataBase_checkmsg);
                                MySqlDataReader myReader_checkmsg;
                                //Open Connection
                                conDataBase_checkmsg.Open();
                                myReader_checkmsg = cmdDataBase_checkmsg.ExecuteReader();
                                if (!(myReader_checkmsg.HasRows))
                                {
                                    try
                                    {
                                        string Query_BirthD = "insert into um_db.nachrichten (msg,menu,datetime) values('" + boxMessage + "','" + "Mitarbeiter" + "','" + DateNow + "');";
                                        MySqlConnection conDataBase_BirthD = new MySqlConnection(constring);
                                        MySqlCommand cmdDataBase_BirthD = new MySqlCommand(Query_BirthD, conDataBase_BirthD);
                                        MySqlDataReader myReader_BirthD;
                                        //Open Connection
                                        conDataBase_BirthD.Open();
                                        myReader_BirthD = cmdDataBase_BirthD.ExecuteReader();
                                        while (myReader_BirthD.Read()) { }
                                        //Close Connection
                                        conDataBase_BirthD.Close();
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Mitarbeiter Fehler: in Birthday Nachrichten eingeben!");
                                    }
                                }
                                //Close Connection
                                conDataBase_checkmsg.Close();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Mitarbeiter Fehler: in Birthday Nachrichten check!");
                            } //check if msg exist to avoid duplicate end                             
                            //Insert into nachrichten END ******************************************************************
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
        }
        //Check Birthdays END*************************************

    }
}
