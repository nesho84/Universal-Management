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

namespace Universal_Management
{
    public partial class Firmenbuch_Extra : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Firmenbuch_Extra()
        {
            InitializeComponent();

            //fill combobox function
            Fillcombo();
        }

        private void Firmenbuch_Extra_Load(object sender, EventArgs e)
        {
            //firma detail visible false
            lblName.Visible = false;
            lblSAdress.Visible = false;
            lblTel.Visible = false;
            lblEmail.Visible = false;
        }

        //Fill combobox with db rows
        void Fillcombo()
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
                    //string sAdress = myReader.GetString("Adress");
                    //comboBox1.Items.Add(sName+" "+sAdress);
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

        //Load datagridview if combobox item is clicked
        DataTable dbdataset;

        private void comboFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List Firmen from database START************
            try
            {
                string Query2 = "select * from um_db.firmenbuch where Firma='" + this.comboFirma.SelectedItem.ToString() + "';";
                MySqlConnection conDataBase2 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase2.Open();

                myReader = cmdDataBase2.ExecuteReader();
                while (myReader.Read())
                {
                    //get strings
                    string sFName = myReader.GetString("Firma");
                    lblName.Text = sFName;

                    string sPLZ = myReader.GetString("PLZ");

                    string sOrt = myReader.GetString("Ort");

                    string sAdress = myReader.GetString("Strasse");
                    lblSAdress.Text = sAdress + ", " + sPLZ + ", " + sOrt;

                    string sEmail = myReader.GetString("Email");
                    lblTel.Text = sEmail;

                    string sTel = myReader.GetString("Telefon");
                    lblEmail.Text = sTel;

                    //Getting Image from database
                    byte[] imgg = (byte[])(myReader["Logo"]);
                    if (imgg == null)
                    {
                        //pictureBox1.Image = Properties.Resources.errorx;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    }
                }

                //Close Connection
                conDataBase2.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            //List Firmen from database END************

            btnPrint.Enabled = true;
            //firma detail visible true
            lblName.Visible = true;
            lblSAdress.Visible = true;
            lblTel.Visible = true;
            lblEmail.Visible = true;

            //List Users from database START************
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select MITID,bild as Bild,M_DNr as DNr,Familienname,Vorname,Geschlecht,G_Datum as Geburtsdatum,StaatBurg_ as Staatsbürgerschaft,status from um_db.mitarbeiter where M_Leiarbeiter='" + this.comboFirma.SelectedItem.ToString() + "' order by M_DNr ASC;", conDataBase);
                
                //Connection Open
                conDataBase.Open();

                //Fill datagridview
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                //Refresh data (allways after bindigSource)
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //Hidde dataGridView1 if no rows awailable
                if (dataGridView1.Rows.Count > 0)
                {
                    //Change Column Order for Status2
                    dataGridView1.Columns["Status2"].DisplayIndex = 8;
                    //Hide "Status" Column to replace it with "custom image column (ColumnName=Status2)"
                    dataGridView1.Columns["status"].Visible = false;

                    //Custom Image Column
                    Mit_Status();

                    //Show results in datagridview
                    dataGridView1.Visible = true;
                    dataGridView1.ColumnHeadersVisible = true;
                    groupBox_error.Visible = false;

                    //Design datagridview columns before starting form
                    DataGridViewColumn column0 = dataGridView1.Columns[0];
                    column0.SortMode = DataGridViewColumnSortMode.NotSortable;
                    DataGridViewColumn column1 = dataGridView1.Columns[1];
                    column1.SortMode = DataGridViewColumnSortMode.NotSortable;
                    DataGridViewColumn column2 = dataGridView1.Columns[2];
                    column2.SortMode = DataGridViewColumnSortMode.NotSortable;
                    DataGridViewColumn column3 = dataGridView1.Columns[3];
                    column3.SortMode = DataGridViewColumnSortMode.NotSortable;
                    DataGridViewColumn column4 = dataGridView1.Columns[4];
                    column4.SortMode = DataGridViewColumnSortMode.NotSortable;
                    DataGridViewColumn column5 = dataGridView1.Columns[5];
                    column5.SortMode = DataGridViewColumnSortMode.NotSortable;
                    DataGridViewColumn column6 = dataGridView1.Columns[6];
                    column6.SortMode = DataGridViewColumnSortMode.NotSortable;
                    DataGridViewColumn column7 = dataGridView1.Columns[7];
                    column7.SortMode = DataGridViewColumnSortMode.NotSortable;

                    //show lblAnzahl
                    lblBeforlblAnzahl.Visible = true;
                    lblAnzahl.Visible = true;

                    //Info Return true
                    picAkt.Enabled = true;
                    lblAkt.Enabled = true;
                    picKr.Enabled = true;
                    lblKr.Enabled = true;
                    picUr.Enabled = true;
                    lblUr.Enabled = true;
                }
                else
                {
                    //Hide results
                    dataGridView1.Visible = false;
                    dataGridView1.ColumnHeadersVisible = false;
                    //pictureBox1.Image = Properties.Resources.page_loader;
                    groupBox_error.Visible = true;

                    //hide lblAnzahl
                    lblBeforlblAnzahl.Visible = false;
                    lblAnzahl.Visible = false;
                }

                //Get Count mitarbeiterAnzahl Rows for this Event ***** START ************************************
                string Query4 = "select count(*) from um_db.mitarbeiter where M_Leiarbeiter='" + this.comboFirma.SelectedItem.ToString() + "';";
                MySqlConnection conDataBase4 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase4 = new MySqlCommand(Query4, conDataBase4);
                conDataBase4.Open();
                int SeenRows = 0;
                SeenRows = int.Parse(cmdDataBase4.ExecuteScalar().ToString());
                lblAnzahl.Text = SeenRows.ToString();
                conDataBase4.Close();
                //Get Count mitarbeiterAnzahl Rows for this Event ***** END ***************************************

                //Get Count AnzahlAktiv Rows for this Event ***** START ************************************
                string Query5 = "select count(status) from um_db.mitarbeiter where M_Leiarbeiter='" + this.comboFirma.SelectedItem.ToString() + "' and status='" + "aktiv" + "';";
                MySqlConnection conDataBase5 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase5 = new MySqlCommand(Query5, conDataBase5);
                conDataBase5.Open();
                int CountAktiv = 0;
                CountAktiv = int.Parse(cmdDataBase5.ExecuteScalar().ToString());
                lblAnzahlAktiv.Text = CountAktiv.ToString();
                conDataBase5.Close();
                //Get Count AnzahlAktiv Rows for this Event ***** END ***************************************

                //Get Count AnzahlKrank Rows for this Event ***** START ************************************
                string Query6 = "select count(status) from um_db.mitarbeiter where M_Leiarbeiter='" + this.comboFirma.SelectedItem.ToString() + "' and status='" + "krank" + "';";
                MySqlConnection conDataBase6 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase6 = new MySqlCommand(Query6, conDataBase6);
                conDataBase6.Open();
                int CountKrank= 0;
                CountKrank = int.Parse(cmdDataBase6.ExecuteScalar().ToString());
                lblAnzahlKrank.Text = CountKrank.ToString();
                conDataBase6.Close();
                //Get Count AnzahlKrank Rows for this Event ***** END ***************************************

                //Get Count AnzahlUrlaub Rows for this Event ***** START ************************************
                string Query7 = "select count(status) from um_db.mitarbeiter where M_Leiarbeiter='" + this.comboFirma.SelectedItem.ToString() + "' and status='" + "urlaub" + "';";
                MySqlConnection conDataBase7 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase7 = new MySqlCommand(Query7, conDataBase7);
                conDataBase7.Open();
                int CountUrlaub = 0;
                CountUrlaub = int.Parse(cmdDataBase7.ExecuteScalar().ToString());
                lblAnzahlUrlaub.Text = CountUrlaub.ToString();
                conDataBase7.Close();
                //Get Count AnzahlUrlaub Rows for this Event ***** END ***************************************

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //List Users from database END************
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            //code here
        }

        //Search datagridview and replace with image
        private void Mit_Status()
        {
            //Stop datagridview self selection at start
            dataGridView1.ClearSelection();

            //Show custom column
            dataGridView1.Columns["Status2"].Visible = true;

            //hide custom column
            dataGridView1.Columns["MITID"].Visible = false;

            //Fit image to row "Stretch" bild column
            if (dataGridView1.Columns[2] is DataGridViewImageColumn)
            {
                ((DataGridViewImageColumn)dataGridView1.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                ((DataGridViewImageColumn)dataGridView1.Columns[2]).Width = 40;
            }

            //Replace rows with image status
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["status"].Value.ToString().Equals("aktiv"))
                {
                    Image image = (Image)Properties.Resources.active_small;
                    row.Cells["Status2"].Value = image;
                }
                else if (row.Cells["status"].Value.ToString().Equals("urlaub"))
                {
                    Image image = (Image)Properties.Resources.Murlaub_info;
                    row.Cells["Status2"].Value = image;
                }
                else if (row.Cells["status"].Value.ToString().Equals("krank"))
                {
                    Image image = (Image)Properties.Resources.passive_small;
                    row.Cells["Status2"].Value = image;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Solid);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pictureBox1.ClientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Solid);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel2.ClientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Solid);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.dataGridView1.ClientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Solid);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel4.ClientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Solid);
        }

        //Close form button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Firmenbuch_Extra_Report frm_extra_rep = new Firmenbuch_Extra_Report();

            frm_extra_rep.lblFirmaName.Text = this.lblName.Text;

            frm_extra_rep.ShowDialog();
        }

        private void Firmenbuch_Extra_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            var Firmenbuch = new Firmenbuch();
            Firmenbuch.ShowDialog();
        }

        private void comboFirma_SelectionChangeCommitted(object sender, EventArgs e)
        {
          //
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Mitarbeiter_Profile M_Profile = new Mitarbeiter_Profile();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Load data from ddb table Mitarbeiter
                M_Profile.lblMID.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                M_Profile.lblM_DNr.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();

                this.Hide();

                M_Profile.ShowDialog();
            }
        }

    }
}
