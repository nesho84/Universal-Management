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
    public partial class FeierTage_Update : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form FeierTage
        FeierTage obj_Feiertage = (FeierTage)Application.OpenForms["FeierTage"];

        public FeierTage_Update()
        {
            InitializeComponent();
        }

        public string gesetzlich;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.txtMonat.Enabled = true;
            this.dateTimePicker_von.Enabled = true;
            this.dateTimePicker_bis.Enabled = true;
            this.txtTag.Enabled = true;
            this.txtJahr.Enabled = true;
            this.txtFeiertag.Enabled = true;
            this.radioButton1.Enabled = true;
            this.radioButton2.Enabled = true;
           
            this.btnSave.Visible = true;
            btnDel.Visible = false;
            btnEdit.Visible = false;
        }

        private void FeierTage_Update_Load(object sender, EventArgs e)
        {
            //Konsumiert button aktivieren
            if (gesetzlich == "Ja")
            {
                radioButton1.Checked = true;
            }
            if (gesetzlich == "Nein")
            {
                radioButton2.Checked = true;
            }
            else if (gesetzlich == "")
            {

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gesetzlich = "Ja";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gesetzlich = "Nein";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Year of DateTime
        string currentYear = DateTime.Now.Year.ToString();

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtFeiertag.TextLength == 0)
            {
                this.txtFeiertag.Focus();
                MessageBox.Show("Bitte Feiertag eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    string Query = "update um_db.feiertage set FEID='" + this.txtFEID.Text + "',Monat='" + txtMonat.Text + "',von='" + this.dateTimePicker_von.Text + "',bis='" + this.dateTimePicker_bis.Text + "',Tag='" + this.txtTag.Text + "',Feiertag='" + this.txtFeiertag.Text + "',gesetzlich='" + gesetzlich + "',Jahr='" + this.txtJahr.Text + "' where FEID='" + this.txtFEID.Text + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Die Daten wurden aktualisiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Refresh datagridview on form Urlaube
                    obj_Feiertage.load_table();
                    obj_Feiertage.dataGridView1.Update();
                    obj_Feiertage.dataGridView1.Refresh();
                    obj_Feiertage.comboJahr.SelectedItem = currentYear;

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sind Sie sicher?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string Query = "delete from um_db.feiertage where FEID='" + this.txtFEID.Text + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Feiertag erfolgreich gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Refresh datagridview on form FeierTage form
                    obj_Feiertage.load_table();
                    obj_Feiertage.dataGridView1.Update();
                    obj_Feiertage.dataGridView1.Refresh();
                    obj_Feiertage.comboJahr.SelectedItem = currentYear;

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
        }

    }
}
