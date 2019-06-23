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
    public partial class Bewerber : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";
        public Bewerber()
        {
            InitializeComponent();

            //Search Database with autocomplete
            AutoCompleteText();
        }

        //datagridview dataset
        DataTable dbdataset;

        public void load_table()
        {
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select * from um_db.mitarbeiter where status='" + "passiv" + "' ORDER BY Familienname ASC;", conDataBase);
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

                //Design datagrid
                design_datagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        void AutoCompleteText()//Search Database with autocomplete
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

                //Open Connection
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString("Familienname");
                    string sVorname = myReader.GetString("Vorname");
                    coll.Add(sName);
                    coll.Add(sVorname);
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

        void Show_Profile() 
        {
                Bewerber_Profile bew_profile = new Bewerber_Profile();

                //Load data from datagridview

                bew_profile.lblID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

                this.Hide();

                bew_profile.ShowDialog();
        }

        public void count_mitarbeiter()
        {
            //Get Count BewerberAnzahl Rows for this Event ***** START ************************************
            try
            {
                string Query4 = "select count(*) from um_db.mitarbeiter WHERE  (status = 'passiv');";
                MySqlConnection conDataBase4 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase4 = new MySqlCommand(Query4, conDataBase4);

                //Open Connection
                conDataBase4.Open();
                
                int SeenRows = 0;
                SeenRows = int.Parse(cmdDataBase4.ExecuteScalar().ToString());
                lblAnzahl.Text = SeenRows.ToString();

                //Close Connection
                conDataBase4.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Get Count BewerberAnzahl Rows for this Event ***** END ***************************************
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Bewerber_Add = new M_Neu();

            this.Hide();
            this.Dispose();

            Bewerber_Add.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bewerber_Status bew_update = new Bewerber_Status();

            //Load data from datagridview from this
            bew_update.txtMITID.Visible = false;

            bew_update.txtMITID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            this.Hide();
            this.Dispose();

            bew_update.ShowDialog();
        }

        //Button bewerberliste
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Show_Profile();
            }
        }

        private void Search_txt_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("Familienname + Vorname  LIKE '%{0}%'", Search_txt.Text);
            dataGridView1.DataSource = DV;
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
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

        private void Bewerber_KeyPress(object sender, KeyPressEventArgs e)
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
                btnStatus.Enabled = true;
                btnListe.Enabled = true;
            }
        }

        public void Bewerber_Load(object sender, EventArgs e)
        {
            //Count bewerber
            count_mitarbeiter();

            //List Bewerber
            load_table();

            //
            dataGridView1.ClearSelection();

            //Fit Images to dataGridView Table List
            DataGridViewColumn column25 = dataGridView1.Columns[25];
            column25.Width = 40;
            if (dataGridView1.Columns[25] is DataGridViewImageColumn)
            {
                ((DataGridViewImageColumn)dataGridView1.Columns[25]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            }

            //release btnDrucken
            if (dataGridView1.Rows.Count > 0)
            {
                btnPrint.Enabled = true;

                Search_txt.Enabled = true;

                btnListe.Enabled = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var bewerber_report = new Bewerber_Report();
            bewerber_report.ShowDialog();
        }

        private void design_datagrid()
        {
            //Design datagridview columns before starting form
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Visible = false;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Visible = false;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 30;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 80;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 80;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 50;
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 90;
            //Plz ort
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Width = 80;
            column7.HeaderText = "PLZ Ort";
            DataGridViewColumn column8 = dataGridView1.Columns[8];
            column8.Width = 80;
            DataGridViewColumn column9 = dataGridView1.Columns[9];
            column9.Width = 100;
            DataGridViewColumn column10 = dataGridView1.Columns[10];
            column10.Visible = false;
            //GebDatum
            DataGridViewColumn column11 = dataGridView1.Columns[11];
            column11.Width = 60;
            column11.HeaderText = "Geb.Datum";
            DataGridViewColumn column12 = dataGridView1.Columns[12];
            column12.Visible = false;
            DataGridViewColumn column13 = dataGridView1.Columns[13];
            column13.Visible = false;
            DataGridViewColumn column14 = dataGridView1.Columns[14];
            column14.Visible = false;
            DataGridViewColumn column15 = dataGridView1.Columns[15];
            column15.Visible = false;
            DataGridViewColumn column16 = dataGridView1.Columns[16];
            column16.Visible = false;
            DataGridViewColumn column17 = dataGridView1.Columns[17];
            column17.Visible = false;
            DataGridViewColumn column18 = dataGridView1.Columns[18];
            column18.Visible = false;
            DataGridViewColumn column19 = dataGridView1.Columns[19];
            column19.Visible = false;
            DataGridViewColumn column20 = dataGridView1.Columns[20];
            column20.Visible = false;
            DataGridViewColumn column21 = dataGridView1.Columns[21];
            column21.Visible = false;
            DataGridViewColumn column22 = dataGridView1.Columns[22];
            column22.Visible = false;
            DataGridViewColumn column23 = dataGridView1.Columns[23];
            column23.Visible = false;
            DataGridViewColumn column24 = dataGridView1.Columns[24];
            column24.Visible = false;
            DataGridViewColumn column25 = dataGridView1.Columns[25];
            column25.Visible = false;
            DataGridViewColumn column26 = dataGridView1.Columns[26];
            column26.Visible = false;
            
            //Bild
            DataGridViewColumn column27 = dataGridView1.Columns[27];
            column27.Width = 40;
            column27.HeaderText = "Bild";

            DataGridViewColumn column28 = dataGridView1.Columns[28];
            column28.Visible = false;
            DataGridViewColumn column29 = dataGridView1.Columns[29];
            column29.Visible = false;
            DataGridViewColumn column30 = dataGridView1.Columns[30];
            column30.Visible = false;
            DataGridViewColumn column31 = dataGridView1.Columns[31];
            column31.Visible = false;
            DataGridViewColumn column32 = dataGridView1.Columns[32];
            column32.Visible = false; 
            
            //Fit Images to dataGridView Table List
            if (dataGridView1.Columns[27] is DataGridViewImageColumn)
            {
                ((DataGridViewImageColumn)dataGridView1.Columns[27]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
        }

    }
}
