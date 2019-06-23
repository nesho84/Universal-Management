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
    public partial class Firmenbuch_Add : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Firmenbuch_Add()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Keine build validation
            if (txtLogo.TextLength == 0)
            {
                MessageBox.Show("Kein Logo ausgewählt!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtLogo.Text = txtLogo.Text = (Application.StartupPath) + "\\" + "Resources" + "\\" + "kein_logo.png";
            }
            //Validate textBoxes
            if (Validation() == true)
            {
                //Getting Image content and ImagePath to store in database
                byte[] imageBt = null;
                FileStream fstream = new FileStream(this.txtLogo.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);

                ////Random ID Nummer
                //string sFRMID;
                //Random random = new Random();
                //int randomNumber = random.Next(0, 9999);
                //sFRMID = randomNumber.ToString();

                try
                {
                    string Query = "insert into um_db.firmenbuch (Firma,Strasse,PLZ,Ort,Land,Telefon,Mobil,Fax,Email,www,Bank,BIC,IBAN,BLZ,Zusatz,Logo,UID,FN) values('" + this.txtFirma.Text + "','" + this.txtStraße.Text + "','" + this.txtPLZ.Text + "','" + this.txtOrt.Text + "','" + this.comboBoxLand.Text + "','" + this.txtTelefon.Text + "','" + this.txtMobil.Text + "','" + this.txtFax.Text + "','" + this.txtEmail.Text + "','" + this.txtWWW.Text + "','" + this.txtBank.Text + "','" + this.txtBIC.Text + "','" + this.txtIBAN.Text + "','" + this.txtBLZ.Text + "','" + this.txtZusatz.Text + "',@IMG,'" + this.txtUID.Text + "','" + this.txtFN.Text + "') ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                    myReader = cmdDataBase.ExecuteReader();

                    MessageBox.Show("Kunde erfolgreich eingegeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    try
                    {
                        //Get date and time Now
                        DateTime DateTimeNow = DateTime.Now;
                        //Message String
                        string NeueKuMsg = "Neue Kunde (" + this.txtFirma.Text + ") wurde erfolgreich eingegeben.";

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
                    catch (Exception) { MessageBox.Show("Kunden Speichern Fehler: in Nachrichten eingeben!"); }
                    //Insert into nachrichten END ******************************************************************

                    //Close Firmenbuch_add Form
                    this.Close();
                }
            }
            else
            {
                Validation();
            }      
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PNG Files(*.png)|*.png|JPG Files(*.jpg)|*.jpg|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                txtLogo.Text = picPath;
                txtLogo.ForeColor = Color.Black;
            }
        }

        private void txtPLZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txtPLZ.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txtTelefon.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtMobil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txtMobil.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txtFax.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtBLZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txtBLZ.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Firmenbuch_Add_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            var Firmenbuch = new Firmenbuch();
            Firmenbuch.ShowDialog();
        }

        private bool Validation()
        {
            //Validating textBox
            if (txtFirma.TextLength == 0)
            {
                this.txtFirma.Focus();
                txtFirma.BackColor = Color.Tomato;
                return false;                
            }

            //Validating textBox
            else if (txtStraße.TextLength == 0)
            {
                this.txtStraße.Focus();
                txtStraße.BackColor = Color.Tomato;
                return false;                
            }

            //Validating textBox
            else if (txtPLZ.TextLength == 0)
            {
                this.txtPLZ.Focus();
                txtPLZ.BackColor = Color.Tomato;
                return false;
            }

            //Validating textBox
            else if (txtOrt.TextLength == 0)
            {
                this.txtOrt.Focus();
                txtOrt.BackColor = Color.Tomato;
                return false;
            }
            else //Validated
            {
                return true;
            }
        }

        private void txtFirma_TextChanged(object sender, EventArgs e)
        {
            if (txtFirma.TextLength > 0)
            {
                txtFirma.BackColor = SystemColors.Menu;
            }
        }

        private void txtStraße_TextChanged(object sender, EventArgs e)
        {
            if (txtStraße.TextLength > 0)
            {
                txtStraße.BackColor = SystemColors.Menu;
            }
        }

        private void txtPLZ_TextChanged(object sender, EventArgs e)
        {
            if (txtPLZ.TextLength > 0)
            {
                txtPLZ.BackColor = SystemColors.Menu;
            }
        }

        private void txtOrt_TextChanged(object sender, EventArgs e)
        {
            if (txtOrt.TextLength > 0)
            {
                txtOrt.BackColor = SystemColors.Menu;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ////Email validation with Regex
            //Regex RX = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            //if (RX.IsMatch(txtEmail.Text))
            //{
            //    txtEmail.BackColor = SystemColors.Menu;
            //}
        }

    }
}
