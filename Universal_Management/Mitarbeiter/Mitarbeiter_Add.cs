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
    public partial class Mitarbeiter_Add : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form Notizen
        Mitarbeiter obj_Mitarbeiter = (Mitarbeiter)Application.OpenForms["Mitarbeiter"];

        public Mitarbeiter_Add()
        {
            InitializeComponent();

            fill_combobox_lei();

            no_pic();
        }

        //String date for txtGBDatum
        string nowDate = DateTime.Now.ToString("dd.MM.yyyy");

        //string Staat radiobuttons
        string Erlaubnisss;
        //string Geschlecht radiobuttons
        string Geschlechttt;
        string Fahrkostennn;
        //string Eintrittt;
        string Ausmasss;
        string Leiarbeittt;
        string Staplerscheinnn;
        string Fuhrerscheinnn;
        string PKW_zu_Verfugunggg;       

        public string statusss = "aktiv";

        private void Mitarbeiter_Add_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            var Mitarbeiter = new Mitarbeiter();
            Mitarbeiter.ShowDialog();
        }

        //Create Folder for Mitarbeiter Documents Function
        private void CreateFolder()
        {
            try
            {                
                //Application Path
                string address_MDoku = (Application.StartupPath) + "\\" + "MDoku" + "\\" + txtDNr.Value.ToString();

                // Create new folder in "C:\ volume or in this case our app Debug folder.
                Directory.CreateDirectory(address_MDoku);

                // Create an already-existing directory (does nothing).
                Directory.CreateDirectory(@address_MDoku);

                //MessageBox.Show("Ordner für diesen Mitarbeiter erstellt.");
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void no_pic()
        {
            string address = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources", "no_profile_pic.png");
            string result;

            result = Path.GetFileName(address);
        }

        private void btnWeiter1_Click(object sender, EventArgs e)
        {
            //DNr Validation
            if (txtDNr.Text == "0")
            {
                MessageBox.Show("Biite DNr eingeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNr.BackColor = Color.Tomato;
                txtDNr.Focus();
                return;
            }
            //Validating textBox
            else if (txtFamilienname.TextLength == 0)
            {
                this.txtFamilienname.Focus();
                txtFamilienname.BackColor = Color.Tomato;
                return;
            }
            else if (txtVorname.TextLength == 0)
            {
                this.txtVorname.Focus();
                txtVorname.BackColor = Color.Tomato;
                return;
            }
            else if (txtStrasse.TextLength == 0)
            {
                this.txtStrasse.Focus();
                txtStrasse.BackColor = Color.Tomato;
                return;
            }
            else if (txtPLZ.TextLength == 0)
            {
                this.txtPLZ.Focus();
                txtPLZ.BackColor = Color.Tomato;
                return;
            }
            else if (txtTel.TextLength == 0)
            {
                this.txtTel.Focus();
                txtTel.BackColor = Color.Tomato;
                return;
            }
            //Geburtsdatum Validation
            else if (txtGDatum.Text == nowDate)
            {
                MessageBox.Show("Bitte Geburtsdatum eingeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGDatum.BackColor = Color.Tomato;
                txtGDatum.Focus();
                return;
            }
            else if (txtSV_Nummer.TextLength == 0)
            {
                this.txtSV_Nummer.Focus();
                txtSV_Nummer.BackColor = Color.Tomato;
                return;
            }
            else
            {
                //Change background of textboxes after validation is true
                txtDNr.BackColor = SystemColors.Menu;
                txtFamilienname.BackColor = SystemColors.Menu;
                txtVorname.BackColor = SystemColors.Menu;
                txtStrasse.BackColor = SystemColors.Menu;
                txtGDatum.BackColor = SystemColors.Menu;
                txtSV_Nummer.BackColor = SystemColors.Menu;
                txtTel.BackColor = SystemColors.Menu;
                txtPLZ.BackColor = SystemColors.Menu;

                //Hide other tabPages
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                //show tabPage2:
                tabControl1.TabPages.Add(tabPage2);
                tabControl1.SelectTab(tabPage2);
                //comboBox_lei select index
                if (comboBox_lei.SelectedIndex > -1)
                {
                    comboBox_lei.SelectedIndex = 0;
                }
            }
        }

        private void btnZuruck1_Click(object sender, EventArgs e)
        {
            //Hide other tabPages
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            //show tabPage1:
            tabControl1.TabPages.Add(tabPage1);
            tabControl1.SelectTab(tabPage1);
        }

        private void btnWeiter2_Click(object sender, EventArgs e)
        {
            //Validation
            if (txtMonatliche_Std.Text == "")
            {
                txtMonatliche_Std.Focus();
                txtMonatliche_Std.BackColor = Color.Tomato;
                MessageBox.Show("Bitte Monatliche Stunden eingeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //Change textbox background
                txtMonatliche_Std.BackColor = SystemColors.Menu;

                //Hide other tabPages
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage4);
                //show tab page:
                tabControl1.TabPages.Add(tabPage3);
                tabControl1.SelectTab(tabPage3);
            }
        }

        private void btnWeiter3_Click(object sender, EventArgs e)
        {
            //Keine build validation
            if (textBox_image_path.TextLength == 0)
            {
                MessageBox.Show("Kein Bild ausgewählt!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox_image_path.Text = (Application.StartupPath) + "\\" + "Resources" + "\\" + "no_profile_pic.png";
            }
            //Hide other tabPages
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            //show tab page:
            tabControl1.TabPages.Add(tabPage4);
            tabControl1.SelectTab(tabPage4);
        }

        private void btnZuruck2_Click(object sender, EventArgs e)
        {
            //Hide other tabPages
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            //show tab page:
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.SelectTab(tabPage2);
        }

        private void btnZuruck3_Click(object sender, EventArgs e)
        {
            //Hide other tabPages
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage4);
            //show tab page:
            tabControl1.TabPages.Add(tabPage3);
            tabControl1.SelectTab(tabPage3);
        }

        private void radio_GeschlechtM_CheckedChanged(object sender, EventArgs e)
        {
            Geschlechttt = "Männlich";
        }

        private void radio_GeschlechtW_CheckedChanged(object sender, EventArgs e)
        {
            Geschlechttt = "Weiblich";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Arbeitserlaubnis:
            if (chkArb.Checked) { Erlaubnisss = Erlaubnisss + this.txtArb_3.Text; }
            if (chkNied.Checked) { Erlaubnisss = Erlaubnisss + this.dateTimePicker_Nied_2.Text; }

            //Vollzeit teilzeit:
            if (radio_Vollzeit.Checked) { Ausmasss = Ausmasss + this.radio_Vollzeit.Text; }
            if (radio_Teilzeit.Checked) { Ausmasss = Ausmasss + this.radio_Teilzeit.Text; }

            //Vollzeit teilzeit:
            if (radio_lei_nein.Checked) { Leiarbeittt = Leiarbeittt + this.radio_lei_nein.Text; }
            if (radio_lei_ja.Checked) { Leiarbeittt = this.comboBox_lei.Text; }

            //Staplerschein:
            if (radio_Stap_Nein.Checked) { Staplerscheinnn = Staplerscheinnn + this.radio_Stap_Nein.Text; }
            if (radio_Stap_Ja.Checked) { Staplerscheinnn = Staplerscheinnn + this.radio_Stap_Ja.Text + "  " + this.dateTimePicker_Stapler.Text; }

            ////Fuhrerschein:
            if (chkA.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkA.Text + "  "; }
            if (chkB.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkB.Text + "  "; }
            if (chkC.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkC.Text + "  "; }
            if (chkD.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkD.Text + "  "; }
            if (chkE.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkE.Text + "  "; }
            if (chkF.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkF.Text + "  "; }

            //Save in MySQL
            //Getting Image content and ImagePath to store in database
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox_image_path.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            //Random ID Nummer
            //string sMITID;
            //Random random = new Random();
            //int randomNumber = random.Next(0, 9999);
            //sMITID = randomNumber.ToString();

            try
            {
                string Query = "insert into um_db.mitarbeiter (M_DNr,Titel,Familienname,Vorname,Geschlecht,Strasse,Plz_Ort,Tel,Email,SV_Nummer,G_Datum,Familienstand,StaatBurg_,Erlaubnis,M_Eintritt,M_Besch_als,M_Gehalt,Arb_im_Ausmass,M_RegStunden,M_Leiarbeiter,Staplerschein,Fuhrerschein,PKW_zu_Verfugung,M_Fahrkosten,Anmerkugen,bild,status) values('" + txtDNr.Value + "','" + txtTitel.Text + "','" + txtFamilienname.Text + "','" + txtVorname.Text + "','" + Geschlechttt + "','" + txtStrasse.Text + "','" + txtPLZ.Text + "','" + txtTel.Text + "','" + txtEmail.Text + "','" + txtSV_Nummer.Text + "','" + txtGDatum.Text + "','" + txtFamilienstand.Text + "','" + txtStaat.Text + "','" + Erlaubnisss + "','" + dateTimePicker_Eintritt.Text + "','" + txtBeschAls.Text + "','" + txtBGehalt.Text + "','" + Ausmasss + "','" + txtMonatliche_Std.Text + "','" + Leiarbeittt + "','" + Staplerscheinnn + "','" + Fuhrerscheinnn + "','" + PKW_zu_Verfugunggg + "','" + Fahrkostennn + "','" + txtAnm.Text + "',@IMG,'" + statusss + "') ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                myReader = cmdDataBase.ExecuteReader();

                //Create Folder Inside Program for This Mitarbeiter
                CreateFolder();

                MessageBox.Show("Mitarbeiter wurde erfolgreich eingegeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                while (myReader.Read()) { }

                //Refresh datagridview on form Notizen
                obj_Mitarbeiter.load_table();
                obj_Mitarbeiter.dataGridView1.Update();
                obj_Mitarbeiter.dataGridView1.Refresh();

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
                //Get date and time Now
                DateTime DateTimeNow = DateTime.Now;
                //Message String
                string NeueMitMsg = "Neue Mitarbeiter mit DNr (" + txtDNr.Value + ") wurde erfolgreich eingegeben.";
                try
                {
                    string Query_newMit = "insert into um_db.nachrichten (msg,menu,datetime) values('" + NeueMitMsg + "','" + "Mitarbeiter" + "','" + DateTimeNow + "');";
                    MySqlConnection conDataBase_newMit = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase_newMit = new MySqlCommand(Query_newMit, conDataBase_newMit);
                    MySqlDataReader myReader_newMit;
                    //Open Connection
                    conDataBase_newMit.Open();
                    myReader_newMit = cmdDataBase_newMit.ExecuteReader();
                    while (myReader_newMit.Read()) { }
                    //Close Connection
                    conDataBase_newMit.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Mitarbeiter Speichern Fehler: in Nachrichten eingeben!");
                }
                //Insert into nachrichten END ******************************************************************

                //Close Mitarbeiter_Add form
                this.Close();
            }
        }

        private void btnBild_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|GIF Files(*.gif)|*.gif";


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                textBox_image_path.Text = picPath;
                //Bildauswahl Tab
                pictureBox1.ImageLocation = picPath;
            }
        }

        private void radio_PKW_Ja_CheckedChanged(object sender, EventArgs e)
        {
            PKW_zu_Verfugunggg = "Ja";
        }

        private void radio_PKW_Nein_CheckedChanged(object sender, EventArgs e)
        {
            PKW_zu_Verfugunggg = "Nein";
        }

        private void radio_FahrKosten_Ja_CheckedChanged(object sender, EventArgs e)
        {
            Fahrkostennn = "Ja";
        }

        private void radio_FahrKosten_Nein_CheckedChanged(object sender, EventArgs e)
        {
            Fahrkostennn = "Nein";
        }

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

        private void Mitarbeiter_Add_Load(object sender, EventArgs e)
        {
            //Focus on first required textbox to activate validation
            txtDNr.Focus();
            txtDNr.Select();
            this.ActiveControl = txtDNr;

            //Remove other tabs
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
        }

        private void comboBox_lei_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtDNr_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(constring);
                MySqlCommand SelectCommand = new MySqlCommand("select M_DNr from um_db.mitarbeiter where M_DNr='" + this.txtDNr.Value + "' ;", myConn);
                MySqlDataReader myReader;

                //Connection Open
                myConn.Open();
                
                myReader = SelectCommand.ExecuteReader();

                int count = 0;

                while (myReader.Read())
                {
                    count = count + 1;
                }
                    //sDNr = myReader.GetDecimal("M_DNr");
                    //if (sDNr == this.txtDNr.Value)
                    if (count > 0)
                    {
                        MessageBox.Show("Doppelte DNr nummer!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        //Changing validation textboxes background
                        txtDNr.BackColor = Color.Tomato;

                        e.Cancel = true;
                    }

                    else if (this.txtDNr.Value == 0)
                    {
                        MessageBox.Show("Falsche DNr!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        //Changing validation textboxes background
                        txtDNr.BackColor = Color.Tomato;

                        e.Cancel = true;
                    }

                    else if (this.txtDNr.Text == "")
                    {
                        MessageBox.Show("Falsche DNr!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        //Changing validation textboxes background
                        txtDNr.BackColor = Color.Tomato;

                        e.Cancel = true;
                    }

                    //Connection Close
                    myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDNr_Validated(object sender, EventArgs e)
        {
            //Changing validation textboxes background
            txtDNr.BackColor = SystemColors.Menu;
        }

        //Arbeitserlaubnis: groupbox validation
        private void groupBox6_Validating(object sender, CancelEventArgs e)
        {
            int msg = 0;

            if (chkArb.Checked == true)
            {
                msg++;
            }

            if (chkNied.Checked == true)
            {
                msg++;
            }

            if (msg > 1)
            {
                MessageBox.Show("Arbeitserlaubnis: wird nur das oberste und unterste ausgewählt!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                chkArb.BackColor = Color.Tomato;
                chkNied.BackColor = Color.Tomato;

                e.Cancel = true;
            }
        }
        //Arbeitserlaubnis: groupbox validated
        private void groupBox6_Validated(object sender, EventArgs e)
        {
            chkArb.BackColor = SystemColors.Menu;
            chkNied.BackColor = SystemColors.Menu;
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txtTel.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtSV_Nummer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txtSV_Nummer.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }     
        }

        //Esc close
        private void Mitarbeiter_Add_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void txtWStd_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 44 && txtMonatliche_Std.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ////Email validation with Regex
            //Regex RX = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            //if (!RX.IsMatch(txtEmail.Text))
            //{
            //    MessageBox.Show("Falsche Email Adresse!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtEmail.BackColor = Color.Tomato;
            //    txtEmail.Focus();
            //}
        }

    }
}
