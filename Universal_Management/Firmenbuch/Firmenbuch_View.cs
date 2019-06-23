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
    public partial class Firmenbuch_View : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form Bewerber
        Firmenbuch_Table obj_firmenbuch = (Firmenbuch_Table)Application.OpenForms["Firmenbuch_Table"];
        public Firmenbuch_View()
        {
            InitializeComponent();
        }

        void get_image()
        {
            try
            {
                string Query = "select * from um_db.firmenbuch where FRMID='" + this.id.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    //Getting Image from database
                    byte[] imgg = (byte[])(myReader["Logo"]);
                    if (imgg == null)
                    {
                        pictureBox2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.none_icon));
                    }
                    else
                    {
                        pictureBox2.BackgroundImage = null;
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox2.Image = System.Drawing.Image.FromStream(mstream);
                    }
                }

                //Connection Close
                conDataBase.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void Firmenbuch_View_Load(object sender, EventArgs e)
        {
            get_image();

            //Fill textBoxes with data from db
            boxid.Text = id.Text;
            boxid.TabStop = false;

            boxfirma.Text = firma.Text;
            boxfirma.TabStop = false;

            boxbank.Text = bank.Text;
            boxbank.TabStop = false;

            boxblz.Text = blz.Text;
            boxblz.TabStop = false;

            boxemail.Text = email.Text;
            boxemail.TabStop = false;

            boxfax.Text = fax.Text;
            boxfax.TabStop = false;

            boxbic.Text = bic.Text;
            boxbic.TabStop = false;

            boxiban.Text = iban.Text;
            boxiban.TabStop = false;

            boxland.Text = land.Text;
            boxland.TabStop = false;

            boxort.Text = ort.Text;
            boxort.TabStop = false;

            boxplz.Text = plz.Text;
            boxplz.TabStop = false;

            boxstrasse.Text = strasse.Text;
            boxstrasse.TabStop = false;

            boxtel.Text = tel.Text;
            boxtel.TabStop = false;

            boxwww.Text = www.Text;
            boxwww.TabStop = false;

            boxzusatz.Text = zusatz.Text;
            boxzusatz.TabStop = false;

            boxmob.Text = mob.Text;
            boxmob.TabStop = false;

            boxFN.Text = fn.Text;
            boxFN.TabStop = false;

            boxUID.Text = UID.Text;
            boxUID.TabStop = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string command = "mailto:info@codegain.com?subject=The Subject&bcc=vrrave@codegaim.com";
            System.Diagnostics.Process.Start(command); 
        }

        private void www_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(www.Text);
        }

        private void btnBearbeiten_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;

            btnPrint.Visible = false;

            btnBearbeiten.Visible = false;

            btnDelete.Visible = false;

            this.boxid.ReadOnly = true;
            boxid.TabStop = false;
            boxid.Text = id.Text;

            this.boxfirma.ReadOnly = false;
            boxfirma.Text = firma.Text;
            boxfirma.BackColor = SystemColors.Window;

            this.boxbank.ReadOnly = false;
            boxbank.Text = bank.Text;
            boxbank.BackColor = SystemColors.Window;

            this.boxblz.ReadOnly = false;
            boxblz.Text = blz.Text;
            boxblz.BackColor = SystemColors.Window;

            this.boxemail.ReadOnly = false;
            boxemail.Text = email.Text;
            boxemail.BackColor = SystemColors.Window;

            this.boxfax.ReadOnly = false;
            boxfax.Text = fax.Text;
            boxfax.BackColor = SystemColors.Window;

            this.boxbic.ReadOnly = false;
            boxbic.Text = bic.Text;
            boxbic.BackColor = SystemColors.Window;

            this.boxiban.ReadOnly = false;
            boxiban.Text = iban.Text;
            boxiban.BackColor = SystemColors.Window;

            this.boxland.ReadOnly = false;
            boxland.Text = land.Text;
            boxland.BackColor = SystemColors.Window;

            this.boxort.ReadOnly = false;
            boxort.Text = ort.Text;
            boxort.BackColor = SystemColors.Window;

            this.boxplz.ReadOnly = false;
            boxplz.Text = plz.Text;
            boxplz.BackColor = SystemColors.Window;

            this.boxstrasse.ReadOnly = false;
            boxstrasse.Text = strasse.Text;
            boxstrasse.BackColor = SystemColors.Window;

            this.boxtel.ReadOnly = false;
            boxtel.Text = tel.Text;
            boxtel.BackColor = SystemColors.Window;

            this.boxwww.ReadOnly = false;
            boxwww.Text = www.Text;
            boxwww.BackColor = SystemColors.Window;

            this.boxzusatz.ReadOnly = false;
            boxzusatz.Text = zusatz.Text;
            boxzusatz.BackColor = SystemColors.Window;

            this.boxmob.ReadOnly = false;
            boxmob.Text = mob.Text;
            boxmob.BackColor = SystemColors.Window;

            this.boxUID.ReadOnly = false;
            boxUID.Text = UID.Text;
            boxUID.BackColor = SystemColors.Window;

            this.boxFN.ReadOnly = false;
            boxFN.Text = fn.Text;
            boxFN.BackColor = SystemColors.Window;
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                    string Query = "delete from um_db.firmenbuch where FRMID='" + this.id.Text + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Kunde erfolgreich gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Refresh datagridview on form Firmenbuchtable
                    obj_firmenbuch.dataGridView1.Rows.Remove(obj_firmenbuch.dataGridView1.CurrentRow);
                    obj_firmenbuch.dataGridView1.DataSource = null;
                    obj_firmenbuch.load_table();
                    obj_firmenbuch.dataGridView1.Update();
                    obj_firmenbuch.dataGridView1.Refresh();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validating textBox
            if (boxfirma.Text == "")
            {
                boxfirma.BackColor = Color.Tomato;
                this.boxfirma.Focus();
                MessageBox.Show("Bitte Firma Name ausfüllen.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Changing validation textboxes background
                boxfirma.BackColor = SystemColors.Menu;

                try
                {
                    string Query = "update um_db.firmenbuch set Firma='" + this.boxfirma.Text + "', Strasse='" + this.boxstrasse.Text + "', PLZ='" + this.boxplz.Text + "', Ort='" + this.boxort.Text + "', Telefon='" + this.boxtel.Text + "', Mobil='" + this.boxmob.Text + "', Fax='" + this.boxfax.Text + "', Email='" + this.boxemail.Text + "', www='" + this.boxwww.Text + "', Bank='" + this.boxbank.Text + "', BIC='" + this.boxbic.Text + "', IBAN='" + this.boxiban.Text + "', BLZ='" + this.boxblz.Text + "', Zusatz='" + this.boxzusatz.Text + "', FN='" + this.boxFN.Text + "', UID='" + this.boxUID.Text + "'  where FRMID='" + this.id.Text + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Die Daten wurden aktualisiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Refresh datagridview on form Firmenbuch
                    obj_firmenbuch.load_table();
                    obj_firmenbuch.dataGridView1.Update();
                    obj_firmenbuch.dataGridView1.Refresh();

                    //Connection Close
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //Insert into nachrichten START **************************************************************
                    try
                    {
                        //Get date and time Now
                        DateTime DateTimeNow = DateTime.Now;
                        //Message String
                        string NeueKuMsg = "Achtung: die Kundendaten (" + this.boxfirma.Text + ") wurden aktualisiert.";

                        string Query_newKun = "insert into um_db.nachrichten (msg,menu,datetime) values('" + NeueKuMsg + "','" + "Kunden" + "','" + DateTimeNow + "');";
                        MySqlConnection conDataBase_newKun = new MySqlConnection(constring);
                        MySqlCommand cmdDataBase_newKun = new MySqlCommand(Query_newKun, conDataBase_newKun);
                        MySqlDataReader myReader_newKun;
                        //Open Connection
                        conDataBase_newKun.Open();
                        myReader_newKun = cmdDataBase_newKun.ExecuteReader();
                        //Close Connection
                        conDataBase_newKun.Close();
                    }
                    catch (Exception) { MessageBox.Show("Kunden Bearbeiten Fehler: in Nachrichten eingeben!"); }
                    //Insert into nachrichten END ******************************************************************

                    //Close the Form
                    this.Close();
                }
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Firmenbuch_Profile_Report frm_pro_report = new Firmenbuch_Profile_Report();
            frm_pro_report.ShowDialog();
        }

    }
}
