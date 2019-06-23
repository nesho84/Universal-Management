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
    public partial class M_Neu : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public M_Neu()
        {
            InitializeComponent();

            clear_endeTab_labels();

            no_pic();
        }

        //String date for txtGBDatum
        string nowDate = DateTime.Now.ToString("dd.MM.yyyy");

        //string Staat radiobuttons
        string Erlaubnisss;
        //string Geschlecht radiobuttons
        string Geschlechttt;        
        string Eintrittt;
        string Ausmasss;
        string Staplerscheinnn;
        string Fuhrerscheinnn;
        string PKW_zu_Verfugunggg;
        string Reisebereitschafttt;
        string Schichtbereitschafttt;
        public string statusss = "passiv";

        private void M_Neu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            var Bewerber = new Bewerber();
            Bewerber.ShowDialog();
        }

        private void no_pic()
        {
            string address = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources", "no_profile_pic.png");
            string result;
            result = Path.GetFileName(address);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Validating textBox
            if (txtFamilienname.TextLength == 0)
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
            else if (txtPLZ_Ort.TextLength == 0)
            {
                this.txtPLZ_Ort.Focus();
                txtPLZ_Ort.BackColor = Color.Tomato;
                return;
            }
            else if (txtTel.TextLength == 0)
            {
                this.txtTel.Focus();
                txtTel.BackColor = Color.Tomato;
                return;
            }
            else if (txtSV_Nummer.TextLength == 0)
            {
                this.txtSV_Nummer.Focus();
                txtSV_Nummer.BackColor = Color.Tomato;
                return;
            }
            //Geburtsdatum Validation
            else if (txtGDatum.Text == nowDate)
            {
                MessageBox.Show("Geburtsdatum ändern!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                txtGDatum.BackColor = Color.Tomato;
                txtGDatum.Focus();
                return;
            }
            else
            {
                //Change background of textboxes after validation is true
                txtFamilienname.BackColor = SystemColors.Menu;
                txtVorname.BackColor = SystemColors.Menu;
                txtStrasse.BackColor = SystemColors.Menu;
                txtGDatum.BackColor = SystemColors.Menu;
                txtSV_Nummer.BackColor = SystemColors.Menu;
                txtTel.BackColor = SystemColors.Menu;
                txtPLZ_Ort.BackColor = SystemColors.Menu;

                //Hide other tabPages
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                //show tab page:
                tabControl1.TabPages.Add(tabPage2);
                tabControl1.SelectTab(tabPage2);
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            //Hide other tabPages
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            //show tab page:
            tabControl1.TabPages.Add(tabPage1);
            tabControl1.SelectTab(tabPage1);
        }

        public void clear_endeTab_labels()
        {
            //Ende Tab Eingegebene Daten to ingnore duplicate
            label48.Text = "";
            label49.Text = "";
            label50.Text = "";
            label51.Text = "";
            label52.Text = "";
            Erlaubnisss = ""; label53.Text = "";
            label54.Text = "";
            label55.Text = "";
            label56.Text = "";
            label57.Text = "";
            label58.Text = "";
            label59.Text = "";
            label60.Text = "";
            Eintrittt = ""; label61.Text = "";
            label62.Text = "";
            label63.Text = "";
            Ausmasss = ""; label64.Text = "";
            Staplerscheinnn = ""; label65.Text = "";
            Fuhrerscheinnn = ""; label66.Text = "";
            label67.Text = "";
            label68.Text = "";
            label69.Text = "";
            label70.Text = "";
            label71.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Validation
            if (txtMonatliche_Std.Text == "")
            {
                txtMonatliche_Std.BackColor = Color.Tomato;
                txtMonatliche_Std.Focus();
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

                clear_endeTab_labels(); //function created to ignore duplicates
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //Hide other tabPages
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage4);
            //show tab page:
            tabControl1.TabPages.Add(tabPage3);
            tabControl1.SelectTab(tabPage3);
        }

        private void button5_Click(object sender, EventArgs e)  //Button to insert data in mysql
        {
            //Getting Image content and ImagePath to store in database
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox_image_path.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);
            

            ////Random ID Nummer
            //string sMITID;
            //Random random = new Random();
            //int randomNumber = random.Next(0, 9999);
            //sMITID = randomNumber.ToString();            

            try
            {
                string Query = "insert into um_db.mitarbeiter (Titel,Familienname,Vorname,Geschlecht,Strasse,Plz_Ort,Tel,Email,SV_Nummer,G_Datum,Familienstand,StaatBurg_,Erlaubnis,F_Eintriit,L_a_Tatigkeit,Gehaltsvorstell_,Arb_im_Ausmass,M_RegStunden,Staplerschein,Fuhrerschein,PKW_zu_Verfugung,Reisebereitschaft,Schichtbereitschaft,Anmerkugen,bild,status) values('" + this.txtTitel.Text + "','" + this.txtFamilienname.Text + "','" + this.txtVorname.Text + "','" + Geschlechttt + "','" + this.label50.Text + "','" + this.txtPLZ_Ort.Text + "','" + this.txtTel.Text + "','" + this.txtEmail.Text + "','" + this.txtSV_Nummer.Text + "','" + this.txtGDatum.Text + "','" + this.txtFamilienstand.Text + "','" + this.txtStaat.Text + "','" + this.label53.Text + "','" + Eintrittt + "','" + this.txtLTag.Text + "','" + this.txtGehaltVor.Text + "','" + this.label64.Text + "','" + this.txtMonatliche_Std.Text + "','" + this.label65.Text + "','" + this.label66.Text + "','" + PKW_zu_Verfugunggg + "','" + Reisebereitschafttt + "','" + Schichtbereitschafttt + "','" + this.richTextBox_Anm.Text + "',@IMG,'" + statusss + "') ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Open Connection
                conDataBase.Open();

                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                myReader = cmdDataBase.ExecuteReader();

                MessageBox.Show("Bewerber erfolgreich eingegeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                //Insert into nachrichten START **************************************************************
                //Get date and time Now
                DateTime DateTimeNow = DateTime.Now;
                //Message String
                string NeueMitMsg = "Neue Bewerber (" + txtFamilienname.Text + " " + txtVorname.Text + ") wurde erfolgreich eingegeben.";
                try
                {
                    string Query_newBew = "insert into um_db.nachrichten (msg,menu,datetime) values('" + NeueMitMsg + "','" + "Bewerber" + "','" + DateTimeNow + "');";
                    MySqlConnection conDataBase_newBew = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase_newBew = new MySqlCommand(Query_newBew, conDataBase_newBew);
                    MySqlDataReader myReader_newBew;
                    //Open Connection
                    conDataBase_newBew.Open();
                    myReader_newBew = cmdDataBase_newBew.ExecuteReader();
                    while (myReader_newBew.Read()) { }
                    //Close Connection
                    conDataBase_newBew.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Bewerber Speichern Fehler: in Nachrichten eingeben!");
                }
                //Insert into nachrichten END ******************************************************************

                //Close Form Bewerber_Add
                this.Close();
            }
        }

        private void radio_GeschlechtM_CheckedChanged(object sender, EventArgs e)
        {
            Geschlechttt = "Männlich";
        }

        private void radio_GeschlechtW_CheckedChanged(object sender, EventArgs e)
        {
            Geschlechttt = "Weiblich";
        }

        private void radio_Re_Ja_CheckedChanged(object sender, EventArgs e)
        {
            Reisebereitschafttt = this.radio_Re_Ja.Text;
        }

        private void radio_Re_Nein_CheckedChanged(object sender, EventArgs e)
        {
            Reisebereitschafttt = this.radio_Re_Nein.Text;
        }

        private void radio_PKW_Ja_CheckedChanged(object sender, EventArgs e)
        {
            PKW_zu_Verfugunggg = "Ja";
        }

        private void radio_PKW_Nein_CheckedChanged(object sender, EventArgs e)
        {
            PKW_zu_Verfugunggg = "Nein";
        }

        private void radio_Sch_Ja_CheckedChanged(object sender, EventArgs e)
        {
            Schichtbereitschafttt = "Ja";
        }

        private void radio_Sch_Nein_CheckedChanged(object sender, EventArgs e)
        {
            Schichtbereitschafttt = "Nein";
        }

        private void M_Neu_Load(object sender, EventArgs e)
        {
            //Focus on first required textbox to activate validation
            txtTitel.Focus();
            txtTitel.Select();
            this.ActiveControl = txtTitel;

            //Remove other tabs
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Hide other tabPages
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            //show tab page:
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.SelectTab(tabPage2);
        }

        private void button8_Click(object sender, EventArgs e) //next button to EndeTab
        {
            //Keine build validation
            if (textBox_image_path.TextLength == 0)
            {
                MessageBox.Show("Kein Bild ausgewählt!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox_image_path.Text = textBox_image_path.Text = (Application.StartupPath) + "\\" + "Resources" + "\\" + "no_profile_pic.png";

                pictureBox2.Image = Properties.Resources.no_profile_pic;
            }
                //Hide other tabPages
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
                //show tab page:
                tabControl1.TabPages.Add(tabPage4);
                tabControl1.SelectTab(tabPage4);

                //EndeTab Eingegebene Daten
                label48.Text = txtTitel.Text;
                label49.Text = txtFamilienname.Text;
                label50.Text = txtStrasse.Text;
                label51.Text = txtTel.Text;
                label52.Text = txtSV_Nummer.Text;

                //Arbeitserlaubnis
                if (chkArb.Checked) { Erlaubnisss = Erlaubnisss + this.txtArb_3.Text; }
                if (chkNied.Checked) { Erlaubnisss = Erlaubnisss + this.dateTimePicker_Nied_2.Text; }
                if (chkBef.Checked) { Erlaubnisss = Erlaubnisss + this.dateTimePicker_Bef_1.Text; }
                label53.Text = Erlaubnisss;

                label54.Text = txtStaat.Text;
                label55.Text = Geschlechttt;
                label56.Text = txtVorname.Text;
                label57.Text = txtPLZ_Ort.Text;
                label58.Text = txtEmail.Text;
                label59.Text = txtGDatum.Text;
                label60.Text = txtFamilienstand.Text;

                //label61 Eintritt
                if (radio_Sofort.Checked) { Eintrittt = Eintrittt + this.radio_Sofort.Text; }
                if (radio_Moglich.Checked) { Eintrittt = Eintrittt + this.radio_Moglich.Text + "  " + this.dateTimePicker_Mog.Text; }
                label61.Text = Eintrittt;

                label62.Text = txtLTag.Text;
                label63.Text = txtGehaltVor.Text;

                //label64.Text = Ausmasss
                if (radio_Vollzeit.Checked) { Ausmasss = Ausmasss + this.radio_Vollzeit.Text; }
                if (radio_Teilzeit.Checked) { Ausmasss = Ausmasss + this.radio_Teilzeit.Text; }
                label64.Text = Ausmasss;

                //label65 Staplerschein
                //Staplerschein:
                if (radio_Stap_Nein.Checked) { Staplerscheinnn = Staplerscheinnn + this.radio_Stap_Nein.Text; }
                if (radio_Stap_Ja.Checked) { Staplerscheinnn = Staplerscheinnn + this.radio_Stap_Ja.Text + "  " + this.dateTimePicker_Stap.Text; }
                label65.Text = Staplerscheinnn;

                ////label66.Text Fuhrerschein
                if (chkA.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkA.Text + "  "; }
                if (chkB.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkB.Text + "  "; }
                if (chkC.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkC.Text + "  "; }
                if (chkD.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkD.Text + "  "; }
                if (chkE.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkE.Text + "  "; }
                if (chkF.Checked) { Fuhrerscheinnn = Fuhrerscheinnn + this.chkF.Text + "  "; }
                label66.Text = Fuhrerscheinnn;

                label67.Text = PKW_zu_Verfugunggg;
                label68.Text = Reisebereitschafttt;
                label69.Text = Schichtbereitschafttt;
                label70.Text = richTextBox_Anm.Text;

                richTextBox70.Text = label70.Text;

                //Keine build ausgewahlt text
                if (textBox_image_path.Text == "keine-profile-bild.png") { label71.Text = "Kein Bild ausgewählt!"; }
                else { label71.Visible = false; }
        }

        private void button6_Click(object sender, EventArgs e) //button to browse pictures
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|GIF Files(*.gif)|*.gif";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                textBox_image_path.Text = picPath;
                //Bildauswahl Tab
                pictureBox1.ImageLocation = picPath;
                //Ende tab
                pictureBox2.ImageLocation = picPath;
            }
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

        //Arbeitserlaubnis: groupbox validation
        private void groupBox6_Validating(object sender, CancelEventArgs e)
        {
            int msg = 0;

            if (chkBef.Checked == true)
            {
                msg++;
            }

            if (chkNied.Checked == true)
            {
                msg++;
            }

            if (chkArb.Checked == true)
            {
                msg++;
            }

            if (msg > 1)
            {
                MessageBox.Show("Arbeitserlaubnis: wird nur eine ausgewählt!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                chkArb.BackColor = Color.Tomato;
                chkNied.BackColor = Color.Tomato;
                chkBef.BackColor = Color.Tomato;

                e.Cancel = true;
            }
        }
        //Arbeitserlaubnis: groupbox validated
        private void groupBox6_Validated(object sender, EventArgs e)
        {
            chkArb.BackColor = SystemColors.Menu;
            chkNied.BackColor = SystemColors.Menu;
            chkBef.BackColor = SystemColors.Menu;
        }

        private void M_Neu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void txtWStd_KeyPress(object sender, KeyPressEventArgs e)
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