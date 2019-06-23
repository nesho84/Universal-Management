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
    public partial class Notizen_Update : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form Notizen
        Notizen obj = (Notizen)Application.OpenForms["Notizen"];

        public Notizen_Update()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "update um_db.notizen set m_vorname='" + this.txtVorname.Text + "', m_nachname='" + this.txtNachname.Text + "', kommentar='" + this.txtKommentar.Text + "', datum='" + this.dateTimePicker1.Text + "' where NID='" + this.txtNID.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Die Daten wurden aktualisiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read()) { }
                
                //Refresh datagridview on form Notizen
                obj.load_table();
                obj.dataGridView1.Update();
                obj.dataGridView1.Refresh();

                //Close Connection
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Notizen_Update_Load(object sender, EventArgs e)
        {
            try
            {
                //Getting rows from database
                string Query = "select * from um_db.notizen where NID='" + this.txtNID.Text + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sVorname = myReader.GetString("m_vorname");
                    string sNachname = myReader.GetString("m_nachname");

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

        private void button3_Click(object sender, EventArgs e)
        {
            string Notizen_ID = this.txtNID.Text;

            if (MessageBox.Show("Sind Sie sicher?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string Query = "delete from um_db.notizen where NID='" + Notizen_ID + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Kommentar erfolgreich gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    obj.load_table();
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
                    if (obj.dataGridView1.SelectedRows.Count > 0)
                    {
                        obj.btnView.Enabled = true;
                        obj.btnPrint.Enabled = true;
                    }
                    else
                    {
                        obj.btnView.Enabled = false;
                        obj.btnPrint.Enabled = false;
                    }
                    this.Close(); 
                }
            }

        }
    }
}
