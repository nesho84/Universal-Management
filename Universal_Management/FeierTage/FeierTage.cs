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
    public partial class FeierTage : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public FeierTage()
        {
            InitializeComponent();

            load_table();
        }

        DataTable dbdataset;

        public void load_table()
        {
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select FEID, Monat, von as Von, bis as Bis, Tag, Feiertag, gesetzlich as Gesetzlich, Jahr from um_db.feiertage WHERE Jahr='" + currentYear + "' order by FEID ASC;", conDataBase);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //Design datagridview columns before starting form
                DataGridViewColumn column7 = dataGridView1.Columns[7];
                column7.Visible = false;

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Year of DateTime
        string currentYear = DateTime.Now.Year.ToString();

        private void FeierTage_Load(object sender, EventArgs e)
        {
            //FeierTage Message
            check_Holiday_dates();

            //Select default combobox(if dropdownlist) just first click
            comboJahr.SelectedItem = currentYear;

            //Stop datagridview self selection at start
            dataGridView1.ClearSelection();

            //Design datagridview columns before starting form
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var FeierTage_Add = new FeierTage_Add();
            FeierTage_Add.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        void Show_Feiertag() 
        {
            FeierTage_Update f_update = new FeierTage_Update();

            //Load data from datagridview to form Feiertage_Update
            f_update.txtFEID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            f_update.txtMonat.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

            f_update.dateTimePicker_von.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();

            f_update.dateTimePicker_bis.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

            f_update.txtTag.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();

            f_update.txtFeiertag.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

            f_update.gesetzlich = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();

            f_update.txtJahr.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();

            f_update.ShowDialog();
        }

        private void btnAnsicht_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Show_Feiertag();
            }
        }

        private void FeierTage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnAnsicht.Enabled = true;
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            if (comboJahr.Items.Contains("Bitte Jahr wählen"))
            {
                comboJahr.Items.Remove("Bitte Jahr wählen");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select FEID, Monat, von as Von, bis as Bis, Tag, Feiertag, gesetzlich as Gesetzlich, Jahr from um_db.feiertage WHERE Jahr='" + this.comboJahr.SelectedItem.ToString() + "' ORDER BY FEID ASC ;", conDataBase);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Check and Holiday dates START*************************************
        public void check_Holiday_dates()
        {
            //Get date and time Now
            DateTime DateNow = DateTime.Now;
            string DateNowJustDate = DateNow.Date.AddDays(1).ToShortDateString();

            try
            {
                //Select "Date" rows in database.table "feiertage"
                string Query1 = "select * from um_db.feiertage where von='" + DateNowJustDate + "' ;";
                MySqlConnection conDataBase1 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase1 = new MySqlCommand(Query1, conDataBase1);
                MySqlDataReader myReader1;
                //Open Connection
                conDataBase1.Open();                
                myReader1 = cmdDataBase1.ExecuteReader();

                //check if Old row exist and then update with "Expired"
                if (myReader1.HasRows)
                {
                    while (myReader1.Read())
                    {
                        string datevon = myReader1.GetString("von");
                        string datebis = myReader1.GetString("bis");
                        string feiertag = myReader1.GetString("Feiertag");

                        if (datevon == DateNowJustDate) //If founded rows "End" that are smaller than Today Date
                        {
                            //Msg to save in Nachrichten
                            var boxMessage = "Am " + datevon + " bis " + datebis + " ist " + feiertag;
                           
                            //Insert into nachrichten START **************************************************************
                            try //check if msg exist to avoid duplicate start
                            {
                                string Query_checkmsg = "select * from um_db.nachrichten where msg='" + boxMessage + "';";
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
                                        String Query = "INSERT INTO um_db.nachrichten (msg,menu,datetime) values('" + boxMessage + "','" + "Feiertage" + "','" + DateNow + "');";
                                        MySqlConnection con = new MySqlConnection(constring);
                                        MySqlCommand cmd = new MySqlCommand(Query, con);
                                        //Open Connection
                                        con.Open();
                                        //Execute Command
                                        cmd.ExecuteNonQuery();
                                        //Close Connection
                                        con.Close();
                                    }
                                    catch (Exception) { MessageBox.Show("Feiertage Fehler: in Nachrichten eingeben!"); }
                                }
                                //Close Connection
                                conDataBase_checkmsg.Close();
                            } 
                            catch (Exception) { MessageBox.Show("Feiertage Fehler: in Nachrichten check!"); }                           
                            //Insert into nachrichten END ******************************************************************
                        }
                    }
                }
                //Close Connection
                conDataBase1.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        } //Check Holiday dates END*************************************

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Show_Feiertag();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FeierTage_Report feier_rep = new FeierTage_Report();
            feier_rep.ShowDialog();
        }

    }
}
