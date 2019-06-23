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
    public partial class Notizen : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Notizen()
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
                MySqlCommand cmdDataBase = new MySqlCommand("select NID, kommentar as Kommentare, username as Benutzer, CONCAT(m_vorname, '  ', m_nachname) as Mitarbeiter, datum as Datum from um_db.notizen ORDER BY NID DESC;", conDataBase);
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

        private void Notizen_Load(object sender, EventArgs e)
        {
            //Button edit release
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnView.Enabled = true;
                btnPrint.Enabled = true;
            }
            else
            {
                btnView.Enabled = false;
                btnPrint.Enabled = false;
            }

            //Design datagridview columns before starting form
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 20;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 350;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 40;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 80;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 125;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //Fill Notizen_Update form with data from datagridview and database
            Notizen_Update n_update = new Notizen_Update();

            //Load data from datagridview to form Notizen_Update
            n_update.txtNID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            n_update.txtBenutzer.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();

            n_update.dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            n_update.txtKommentar.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

            n_update.txtNID.Enabled = false;
            n_update.txtBenutzer.Enabled = false;

            n_update.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var Notizen_Add = new Notizen_Add();

            Notizen_Add.txtBenutzer2.Text = this.User.Text;

            Notizen_Add.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var Notizen_Report = new Notizen_Report();
            Notizen_Report.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Fill Notizen_Update form with data from datagridview and database
                Notizen_Update n_update = new Notizen_Update();

                //Load data from datagridview to form Notizen_Update
                n_update.txtNID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                n_update.txtBenutzer.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();

                n_update.dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                n_update.txtKommentar.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

                n_update.txtNID.Enabled = false;
                n_update.txtBenutzer.Enabled = false;

                n_update.ShowDialog();
            }
        }

        private void Notizen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select NID, kommentar as Kommentare, username as Benutzer, CONCAT(m_vorname, ' - ', m_nachname) as Mitarbeiter, datum as Datum from um_db.notizen where datum='" + this.dateTimePicker1.Text + "' ORDER BY datum DESC;", conDataBase);
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

        private void btnResset_Click(object sender, EventArgs e)
        {
            load_table();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //Button edit release
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnView.Enabled = true;
                btnPrint.Enabled = true;
            }
            else
            {
                btnView.Enabled = false;
                btnPrint.Enabled = false;
            }
        }

    }
}
