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
    public partial class Daily_Report_View : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Datatable datagridview1
        DataTable dbdataset;

        public Daily_Report_View()
        {
            InitializeComponent();
        }
        private void Daily_Report_View_Load(object sender, EventArgs e)
        {
            //Diferent Message Functions
            if (this.Text == "History")
            {
                View_History();
            }
            else if (this.Text == "History" && dataGridView1.RowCount < 1)
            {
                this.panelHistory.Enabled = false;
                this.lblMsgNull.Visible = true;
            }
            else
            {
                View_Message();
            }
        }

        //Function to check Feiertage Messages
        public void View_Message()
        {
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select * from um_db.nachrichten WHERE menu='" + this.Text + "' AND seen='" + "no" + "' ORDER BY date_time DESC ;", conDataBase);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //Design and Hide Columns in Datagridview
                //image column
                DataGridViewColumn column0 = dataGridView1.Columns[0];
                column0.Width = 25;
                //button column
                DataGridViewColumn column1 = dataGridView1.Columns[1];
                column1.DisplayIndex = 6;
                DataGridViewColumn column2 = dataGridView1.Columns[2];
                column2.Visible = false;
                DataGridViewColumn column4 = dataGridView1.Columns[4];
                column4.Visible = false;
                DataGridViewColumn column5 = dataGridView1.Columns[5];
                column5.Visible = false;
                DataGridViewColumn column6 = dataGridView1.Columns[6];
                column6.Visible = false;

                //Connection Close
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Function to check All Messages
        public void View_History()
        {
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select * from um_db.nachrichten where seen='" + "yes" + "' ORDER BY date_time DESC ;", conDataBase);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //Design and Hide Columns in Datagridview
                DataGridViewColumn column0 = dataGridView1.Columns[0];
                column0.Width = 25;
                DataGridViewColumn column1 = dataGridView1.Columns[1];
                column1.Visible = false;
                DataGridViewColumn column2 = dataGridView1.Columns[2];
                column2.Visible = false;
                DataGridViewColumn column4 = dataGridView1.Columns[4];
                column4.Visible = false;
                DataGridViewColumn column5 = dataGridView1.Columns[5];
                column5.Width = 48;
                DataGridViewColumn column6 = dataGridView1.Columns[6];
                column6.Visible = false;

                //Connection Close
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Update message to seen=yes
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if wanted column was clicked 
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                //Update nachrichten Table set (seen=yes) ***** START *****
                if (dataGridView1.RowCount > 0)
                {
                    try
                    {
                        string naid_row = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        string menu_row = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();

                        string Query = "update um_db.nachrichten set seen='" + "yes" + "' where menu='" + menu_row + "' and NAID='" + naid_row + "';";
                        MySqlConnection conDataBase = new MySqlConnection(constring);
                        MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                        MySqlDataReader myReader;
                        conDataBase.Open();
                        myReader = cmdDataBase.ExecuteReader();
                        //Refresh datagridview
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        conDataBase.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                //Update nachrichten Table set (seen=yes) ***** END ********
            }
        }

        private void Daily_Report_View_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void Daily_Report_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Show Daily_Report form again
            Daily_Report d_report = new Daily_Report();
            this.Dispose();
            d_report.ShowDialog();
        }

        //Delete History
        private void btnClear_Click(object sender, EventArgs e)
        {
            //Show Termin MessageBox
            var myMessageBox = new MyMessageBox();
            myMessageBox.btnJa.Text = "Ja";
            myMessageBox.btnNein.Text = "Nein";
            myMessageBox.Text = "Löschen";
            myMessageBox.txtText.Text = "\nSind Sie sicher?";
            DialogResult result = myMessageBox.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    string Query = "delete from um_db.nachrichten where seen='" + "yes" + "';";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Nachricten-Verlauf erfolgreich gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Connection Close
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Close();
                }
            }
            else if (result == DialogResult.Cancel)
            {
                myMessageBox.Close();
            }
        }
    }
}
