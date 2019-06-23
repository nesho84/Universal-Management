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
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;

namespace Universal_Management
{
    public partial class Mitarbeiter_DNr_Update : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form Mitarbeiter_Profile
        Mitarbeiter_Profile obj_mitarbeiter_profile = (Mitarbeiter_Profile)Application.OpenForms["Mitarbeiter_Profile"];

        public Mitarbeiter_DNr_Update()
        {
            InitializeComponent();
        }

        //Disable Close(x) Button on the form
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void btnDNrSpeichern_Click(object sender, EventArgs e)
        {
            if (numeric_DNr.Text == "0")
            {
                MessageBox.Show("DNr muss mehr als 0 sein!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.numeric_DNr.Focus();
                numeric_DNr.BackColor = Color.Tomato;
                return;
            }
            else if (numeric_DNr.Text == "")
            {
                MessageBox.Show("Bitte DNr eingeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.numeric_DNr.Focus();
                numeric_DNr.BackColor = Color.Tomato;
                return;
            }

            //Check DNr on database START **************************
            MySqlConnection myConn2 = new MySqlConnection(constring);
            MySqlCommand command = new MySqlCommand(constring, myConn2);
            command.CommandText = "SELECT M_DNr FROM um_db.mitarbeiter WHERE M_DNr = '" + this.numeric_DNr.Value + "'";            
            //Connection Open
            myConn2.Open();            
            MySqlDataReader Reader;
            Reader = command.ExecuteReader();
            int count = 0;
            while (Reader.Read())
            {
                count = count + 1;
            }
            //Connection Close
            Reader.Close();
            myConn2.Close();

            if (count > 1)
            {
                myConn2.Open();
                Reader = command.ExecuteReader();
                myConn2.Close();
                MessageBox.Show("Doppelte DNr!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.numeric_DNr.Focus();
                numeric_DNr.BackColor = Color.Tomato;
                return;
            }
            else if (count == 1)
            {
                MessageBox.Show("DNr existiert bereits!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.numeric_DNr.Focus();
                numeric_DNr.BackColor = Color.Tomato;
                return;
            } //Check DNr on database END **************************

            else if (this.txtBeschAls.TextLength == 0)
            {
                MessageBox.Show("Bitte (Beschäftigt als) ausfüllen.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtBeschAls.Focus();
                txtBeschAls.BackColor = Color.Tomato;
                return;
            }
            else if (this.comboBox_lei.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte (Beschäftigt bei) wählen.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.comboBox_lei.Focus();
                comboBox_lei.BackColor = Color.Tomato;
                return;
            }
            else if (this.txtMS.TextLength == 0)
            {
                MessageBox.Show("Bitte (Monatliche Arbeitsstunden) ausfüllen.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMS.Focus();
                txtMS.BackColor = Color.Tomato;
                return;
            }
            else if (this.txtBrGehalt.TextLength == 0)
            {
                MessageBox.Show("Bitte (Brutto Gehalt) ausfüllen.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtBrGehalt.Focus();
                txtBrGehalt.BackColor = Color.Tomato;
                return;
            }

            else
            {
                try //Update Mitarbeiter
                {
                    string UpdateM_Query = "update um_db.mitarbeiter set M_DNr='" + this.numeric_DNr.Value + "', status='" + "aktiv" + "', M_Leiarbeiter='" + this.comboBox_lei.SelectedItem.ToString() + "', M_RegStunden='" + this.txtMS.Text + "', M_Besch_als='" + this.txtBeschAls.Text + "', M_Gehalt='" + this.txtBrGehalt.Text + "', M_Eintritt='" + this.einTritt.Text + "' where MITID='" + this.lblMITID.Text + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(UpdateM_Query, conDataBase);
                    MySqlDataReader myReader2;

                    //Connection Open
                    conDataBase.Open();

                    myReader2 = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Bewerber wurde als Mitarbeiter geschpeichert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader2.Read()) { }

                    //Create Mitarbeiter folder after DNr is created start
                    try
                    {
                        // Create new folder in "C:\ volume or in this case our app Debug folder.
                        Directory.CreateDirectory("MDoku" + "\\" + this.numeric_DNr.Value);
                        // Create an already-existing directory (does nothing).
                        Directory.CreateDirectory(@"MDoku" + "\\" + this.numeric_DNr.Value);
                        //MessageBox.Show("Ordner erstellt!");
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //Create Mitarbeiter folder after DNr is created end

                    //Connection Close
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //Show Mitarbeiter Profile
                    Mitarbeiter_Profile M_Profile = new Mitarbeiter_Profile();
                    M_Profile.lblMID.Text = this.lblMITID.Text;
                    M_Profile.lblM_DNr.Text = this.numeric_DNr.Value.ToString();
                    this.Hide();
                    this.Dispose();
                    M_Profile.ShowDialog();

                    //Insert into nachrichten START **************************************************************
                    //Get date and time Now
                    DateTime DateTimeNow = DateTime.Now;
                    //Message String
                    string NeueMitMsg = "Bewerber wurde als Mitarbeiter mit DNr (" + this.numeric_DNr.Value.ToString() + ") geschpeichert.";
                    try
                    {
                        string Query_alsMit = "insert into um_db.nachrichten (msg,menu,datetime) values('" + NeueMitMsg + "','" + "Bewerber" + "','" + DateTimeNow + "');";
                        MySqlConnection conDataBase_alsMit = new MySqlConnection(constring);
                        MySqlCommand cmdDataBase_alsMit = new MySqlCommand(Query_alsMit, conDataBase_alsMit);
                        MySqlDataReader myReader_alsMit;
                        //Open Connection
                        conDataBase_alsMit.Open();
                        myReader_alsMit = cmdDataBase_alsMit.ExecuteReader();
                        while (myReader_alsMit.Read()) { }
                        //Close Connection
                        conDataBase_alsMit.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bewerber Als Mitatbeiter Speichern Fehler: in Nachrichten eingeben!");
                    }
                    //Insert into nachrichten END ******************************************************************
                }
            }            
        }

        //Combobox Beschaftig bei
        private void fill_combobox_lei()
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
                    //Getting text fields from database
                    string fName = myReader.GetString("Firma");
                    comboBox_lei.Items.Add(fName);
                }
                //Connection Close
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Mitarbeiter_DNr_Update_Load(object sender, EventArgs e)
        {
            //Fill combobox Beschaftig bei
            fill_combobox_lei();
        }

        private void numeric_DNr_ValueChanged(object sender, EventArgs e)
        {
            numeric_DNr.BackColor = SystemColors.Menu;
        }

        private void txtBeschAls_TextChanged(object sender, EventArgs e)
        {
            if (txtBeschAls.TextLength > 0)
            {
                txtBeschAls.BackColor = SystemColors.Menu;
            }
        }

        private void comboBox_lei_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_lei.SelectedIndex > -1)
            {
                comboBox_lei.BackColor = SystemColors.Menu;
            }
        }

        private void txtMS_TextChanged(object sender, EventArgs e)
        {
            if (txtMS.TextLength > 0)
            {
                txtMS.BackColor = SystemColors.Menu;
            }
        }

        private void txtBrGehalt_TextChanged(object sender, EventArgs e)
        {
            if (txtBrGehalt.TextLength > 0)
            {
                txtBrGehalt.BackColor = SystemColors.Menu;
            }
        }
               
    }
}
