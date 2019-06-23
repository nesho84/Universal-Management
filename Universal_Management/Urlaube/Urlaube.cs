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

namespace Universal_Management
{
    public partial class Urlaube : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Urlaube()
        {
            InitializeComponent();

            //Load datagridview1
            load_table();

            //Search Database with autocomplete
            AutoCompleteText();
        }

        DataTable dbdataset;

        public void load_table()
        {
            //Stop datagridview self selection at start
            dataGridView1.ClearSelection();

            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select URLID, DN_Nr AS DNr, CONCAT(M_Vorname, '  ', M_Nachname) as Mitarbeiter, Arbeitstage_von as Von, Arbeitstage_bis as Bis, Anzahl_Tage as AnzahlderTage, Type as Typ, Konsumiert from um_db.urlaube ORDER BY Arbeitstage_von DESC ;", conDataBase);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //SET Rows height manually
                DataGridViewRow row = this.dataGridView1.RowTemplate;
                //row.DefaultCellStyle.BackColor = Color.SkyBlue;
                row.Height = 30;
                row.MinimumHeight = 20;

                //Close Connection
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
                string Query = "select * from um_db.urlaube;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sName = myReader.GetString("M_Vorname");
                    coll.Add(sName);
                }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Search_txt.AutoCompleteCustomSource = coll;
        }

        private void Urlaube_Load(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnBearbeiten.Enabled = true;
                btnPrint.Enabled = true;
            }
            else
            {
                btnBearbeiten.Enabled = false;
                btnPrint.Enabled = false;
            }
        }

        private void Search_txt_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("Mitarbeiter + DNr  LIKE '%{0}%'", Search_txt.Text);
            dataGridView1.DataSource = DV;
        }

        private void Urlaube_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void btnNeu_Click(object sender, EventArgs e)
        {
            var Urlaube_Add = new Urlaube_Add();
            Urlaube_Add.ShowDialog();
        }

        private void btnBearbeiten_Click(object sender, EventArgs e)
        {
            //Fill Urlaube_Update form with data from datagridview and database

            Urlaube_Update u_updatee = new Urlaube_Update();

            //Load data from datagridview to form Urlaube_Update
            u_updatee.txtURLID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            u_updatee.txtDNNr.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

            u_updatee.dateTimePicker_von.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

            u_updatee.dateTimePicker_bis.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();

            u_updatee.txtAnzahlTage.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

            u_updatee.UrlaubTypeUpdate = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();

            u_updatee.Konsumiert = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();

            u_updatee.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnBearbeiten.Enabled = true;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Fill Urlaube_Update form with data from datagridview and database

                Urlaube_Update u_updatee = new Urlaube_Update();

                //Load data from datagridview to form Urlaube_Update
                u_updatee.txtURLID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

                u_updatee.txtDNNr.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

                u_updatee.dateTimePicker_von.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

                u_updatee.dateTimePicker_bis.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();

                u_updatee.txtAnzahlTage.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

                u_updatee.UrlaubTypeUpdate = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();

                u_updatee.Konsumiert = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();

                u_updatee.ShowDialog();
            }
        }

        //Check Urlaube dates START*************************************
        public void check_Urlaube_dates()
        {
            try
            {
            //Select "Seen" rows in database.table "events"
            string Query1 = "select * from um_db.urlaube where Gesehen='" + "Nein" + "';";
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
                    string datevon = myReader1.GetString("Arbeitstage_von");
                    string datebis = myReader1.GetString("Arbeitstage_bis");
                    string mVorname = myReader1.GetString("M_Vorname");
                    string mNachname = myReader1.GetString("M_Nachname");
                    string mDN_Nr = myReader1.GetString("DN_Nr");

                    //Get date and time Now MissedDates
                    DateTime DateTimeNow_Missed = DateTime.Now.Date;

                    //Urlaub row von converting to shortdate String
                    DateTime UrlaubDatum = Convert.ToDateTime(datevon);

                    if (UrlaubDatum <= DateTimeNow_Missed) //If founded rows "End" are smaller than Today Date
                    //if (FeierTagDatumJustDate == DateNowJustDate)
                    {
                        var boxMessage = "DNr: " + mDN_Nr + " " + mVorname + " " + mNachname + " ist von (" + datevon + ") bis (" + datebis + ") in Urlaub.";
                        //Show missed events in messageBox
                        DialogResult result = MessageBox.Show(boxMessage, "Urlaub", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        try //Update urlaube Table (Gesehen) ***** START *****
                        {
                            string Query2 = "update um_db.urlaube set Gesehen='" + "Ja" + "' where DN_Nr='" + mDN_Nr + "';";
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
                        } //Update events Table (Gesehen)***** END *****


                        try //Update Mitarbeiter Status***** START *****
                        {
                            string Query3 = "update um_db.mitarbeiter set status='" + "urlaub" + "' where M_DNr='" + mDN_Nr + "';";
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
        }
        //Check Urlaube dates END*************************************
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Urlaube_Report url_report = new Urlaube_Report();
            url_report.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var Urlaube_Add = new Urlaube_Add();
            Urlaube_Add.ShowDialog();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnBearbeiten.Enabled = true;
                btnPrint.Enabled = true;
            }
            else
            {
                btnBearbeiten.Enabled = false;
                btnPrint.Enabled = false;
            }
        }

    }
}
