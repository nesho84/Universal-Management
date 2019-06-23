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
    public partial class FeierTage_Add : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form FeierTage
        FeierTage obj_feiertage = (FeierTage)Application.OpenForms["FeierTage"];

        string gesetzlich;

        public FeierTage_Add()
        {
            InitializeComponent();
        }

        private void FeierTage_Add_Load(object sender, EventArgs e)
        {
            //txtFEID.Enabled = false;
            //Random random = new Random();
            //int randomNumber = random.Next(0, 9999);
            //txtFEID.Text = randomNumber.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gesetzlich = "Ja";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gesetzlich = "Nein";
        }

        //Year of DateTime
        string currentYear = DateTime.Now.Year.ToString();

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtJahr.SelectedIndex == -1)
            {
                this.txtJahr.Focus();
                MessageBox.Show("Bitte Jahr wählen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtMonat.SelectedIndex == -1)
            {
                this.txtJahr.Focus();
                MessageBox.Show("Bitte Monat wählen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtTag.SelectedIndex == -1)
            {
                this.txtJahr.Focus();
                MessageBox.Show("Bitte Tag wählen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtFeiertag.TextLength == 0)
            {
                this.txtFeiertag.Focus();
                MessageBox.Show("Bitte Feiertag eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    string Query = "insert into um_db.feiertage (Monat,von,bis,Tag,Feiertag,gesetzlich,Jahr) values('" + txtMonat.Text + "','" + this.dateTimePicker_von.Text + "','" + this.dateTimePicker_bis.Text + "','" + this.txtTag.Text + "','" + this.txtFeiertag.Text + "','" + gesetzlich + "','" + this.txtJahr.Text + "') ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Open Connection
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Feiertag erfolgreich eingegeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Refresh datagridview on form Notizen
                    obj_feiertage.load_table();
                    obj_feiertage.dataGridView1.Update();
                    obj_feiertage.dataGridView1.Refresh();
                    obj_feiertage.comboJahr.SelectedItem = currentYear;

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
