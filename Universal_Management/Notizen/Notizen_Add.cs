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
    public partial class Notizen_Add : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form Notizen
        Notizen obj = (Notizen)Application.OpenForms["Notizen"];
        public Notizen_Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Get date and time Now
            DateTime dateTimeNow = DateTime.Now;
            DateTime dateNow = Convert.ToDateTime(dateTimeNow);

            try
            {
                string Query = "insert into um_db.notizen (kommentar,username,m_vorname,m_nachname,datum) values('" + this.txtKommentar.Text + "','" + this.txtBenutzer2.Text + "','" + this.txtVorname.Text + "','" + this.txtNachname2.Text + "','" + this.dateTimePicker1.Text + "') ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Kommentar erfolgreich eingegeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //Insert into nachrichten START **************************************************************
                try //Insert into Nachrichten start
                {
                    string Query_notizenMsg = "insert into um_db.nachrichten (msg,menu,datetime) values('" + this.txtKommentar.Text + "','" + "Notizen" + "','" + dateNow + "');";
                    MySqlConnection conDataBase_notizenMsg = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase_notizenMsg = new MySqlCommand(Query_notizenMsg, conDataBase_notizenMsg);
                    MySqlDataReader myReader_notizenMsg;
                    //Open Connection
                    conDataBase_notizenMsg.Open();
                    myReader_notizenMsg = cmdDataBase_notizenMsg.ExecuteReader();
                    while (myReader_notizenMsg.Read()) { }
                    //Close Connection
                    conDataBase_notizenMsg.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Notizen Fehler: in Nachrichten eingeben!");
                    MessageBox.Show(ex.Message);
                } //Insert into Nachrichten end
                //Insert into nachrichten END ******************************************************************

                this.Close();
            }
        }
    }
}
