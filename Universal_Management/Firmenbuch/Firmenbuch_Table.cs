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
    public partial class Firmenbuch_Table : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Firmenbuch_Table()
        {
            InitializeComponent();

            //Search Database with autocomplete
            AutoCompleteText();

            load_table();
        }

        //datagridview set
        DataTable dbdataset;

        private void button1_Click(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("Firma  LIKE '%{0}%'", Search_txt.Text);
            dataGridView1.DataSource = DV;
        }

        public void load_table()
        {
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select * from um_db.firmenbuch ORDER BY FRMID DESC;", conDataBase);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //hide columns
                design_dgview();

                //Design datagridview columns NotSortable
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

                DataGridViewColumn column9 = dataGridView1.Columns[9];
                column9.SortMode = DataGridViewColumnSortMode.NotSortable;

                DataGridViewColumn column10 = dataGridView1.Columns[10];
                column10.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void design_dgview()
        {
            //Design datagridview columns before starting form
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Visible = false; //hide column ID

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 80;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 80;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 40;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 50;

            //Hide colums
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Visible = false;
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Visible = false;
            DataGridViewColumn column8 = dataGridView1.Columns[8];
            column8.Visible = false;
            DataGridViewColumn column11 = dataGridView1.Columns[11];
            column11.Visible = false;
            DataGridViewColumn column12 = dataGridView1.Columns[12];
            column12.Visible = false;
            DataGridViewColumn column13 = dataGridView1.Columns[13];
            column13.Visible = false;
            DataGridViewColumn column14 = dataGridView1.Columns[14];
            column14.Visible = false;
            DataGridViewColumn column15 = dataGridView1.Columns[15];
            column15.Visible = false;

            //Show full image to column
            if (dataGridView1.Columns[16] is DataGridViewImageColumn)
            {
                ((DataGridViewImageColumn)dataGridView1.Columns[16]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.Columns[16].Width = 80;
            }

            //UID
            DataGridViewColumn column17 = dataGridView1.Columns[17];
            column17.Visible = false;
            //FN
            DataGridViewColumn column18 = dataGridView1.Columns[18];
            column18.Visible = false;
        }

        void AutoCompleteText()//Search Database with autocomplete
        {
            Search_txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Search_txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

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
                    string sFirma = myReader.GetString("Firma");
                    coll.Add(sFirma);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Search_txt.Text = "";
            load_table();
        }

         void Show_Firma() 
         {
                Firmenbuch_View Frm_View = new Firmenbuch_View();

                //Load data from datagridview to form Notizen_Update

                Frm_View.id.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Frm_View.firma.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Frm_View.strasse.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Frm_View.plz.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Frm_View.ort.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                Frm_View.land.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                Frm_View.tel.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                Frm_View.mob.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                Frm_View.fax.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                Frm_View.email.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
                Frm_View.www.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
                Frm_View.bank.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString();
                Frm_View.bic.Text = this.dataGridView1.CurrentRow.Cells[12].Value.ToString();
                Frm_View.iban.Text = this.dataGridView1.CurrentRow.Cells[13].Value.ToString();
                Frm_View.blz.Text = this.dataGridView1.CurrentRow.Cells[14].Value.ToString();
                Frm_View.zusatz.Text = this.dataGridView1.CurrentRow.Cells[15].Value.ToString();
                //Cells[16] ist Image
                Frm_View.UID.Text = this.dataGridView1.CurrentRow.Cells[17].Value.ToString();
                Frm_View.fn.Text = this.dataGridView1.CurrentRow.Cells[18].Value.ToString();

                Frm_View.ShowDialog();
         }

         private void Firmenbuch_Table_Load(object sender, EventArgs e)
         {
                //code here
         }

         private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
         {
             if (dataGridView1.SelectedRows.Count > 0)
             {
                 Show_Firma();
             }
         }

         private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
         {
             if (dataGridView1.SelectedRows.Count > 0)
             {
                 if (e.KeyCode == Keys.Enter)
                 {
                     Show_Firma();
                 }
             }
         }

         private void Firmenbuch_Table_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == (char)27)
             {
                 this.Hide();
             }
         }

         private void Firmenbuch_Table_FormClosing(object sender, FormClosingEventArgs e)
         {
             this.Hide();
             var Firmenbuch = new Firmenbuch();
             Firmenbuch.ShowDialog();
         }

    }
}
