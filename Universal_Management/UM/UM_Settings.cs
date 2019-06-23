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
using System.IO;

namespace Universal_Management
{
    public partial class UM_Settings : Form
    {
        //ConString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form Notizen
        Home obj_Home_Form = (Home)Application.OpenForms["Home"];
        public UM_Settings()
        {
            InitializeComponent();

            um_setting_fill();
        }

        private void settings_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.txtAktPass.Text = "";
            this.txtNeuPass.Text = "";
        }

        private void btnSavePass_Click(object sender, EventArgs e)
        {
            //Textboxes Validation
            if (txtAktPass.TextLength < 6)
            {
                MessageBox.Show("Aktuelles Passwort zu kurz (mindestens 6 Zeichen)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.ActiveControl = txtAktPass;

                return;
            }

            if (txtNeuPass.TextLength < 6)
            {
                MessageBox.Show("Neues Passwort zu kurz (mindestens 6 Zeichen)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.ActiveControl = txtNeuPass;

                return;
            }

            try //See if AKtueles password exist
            {
                string Query_Select = "select password from um_db.users;";
                MySqlConnection conDataBase_Select = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_Select = new MySqlCommand(Query_Select, conDataBase_Select);
                MySqlDataReader myReader_Select;

                //Connection Open
                conDataBase_Select.Open();
                
                myReader_Select = cmdDataBase_Select.ExecuteReader();

                if (myReader_Select.HasRows)
                {
                    while (myReader_Select.Read())
                    {
                        string sPassword = myReader_Select.GetString("password");

                        if (txtAktPass.Text == sPassword)
                        {
                            //MessageBox.Show("Pass exists!");

                            try////Update Password
                            {
                                string Query_Update = "update um_db.users set password='" + this.txtNeuPass.Text + "';";
                                MySqlConnection conDataBase_Update = new MySqlConnection(constring);
                                MySqlCommand cmdDataBase_Update = new MySqlCommand(Query_Update, conDataBase_Update);
                                MySqlDataReader myReader_Update;
                                conDataBase_Update.Open();
                                myReader_Update = cmdDataBase_Update.ExecuteReader();
                                MessageBox.Show("Die Daten wurden aktualisiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.txtNeuPass.Text = "";
                                this.txtAktPass.Text = "";
                                conDataBase_Update.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Aktuelles Passwort ist nicht vorhanden, versuchen Sie es erneut!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                //Connection Close
                conDataBase_Select.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Close the form
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //on form load
        private void um_settings_Load(object sender, EventArgs e)
        {
            //Refresh datagridview on form Notizen
            Home obj_Home_Form = (Home)Application.OpenForms["Home"];
        }

        private void radio_a1_CheckedChanged(object sender, EventArgs e)
        {
            obj_Home_Form.FrmBgColor = "a1";

            obj_Home_Form.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a1));

            obj_Home_Form.updateBgFormImage();
        }

        private void radio_a2_CheckedChanged(object sender, EventArgs e)
        {
            obj_Home_Form.FrmBgColor = "a2";

            obj_Home_Form.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a2));

            obj_Home_Form.updateBgFormImage();
        }

        private void radio_a3_CheckedChanged(object sender, EventArgs e)
        {
            obj_Home_Form.FrmBgColor = "a3";

            obj_Home_Form.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a3));

            obj_Home_Form.updateBgFormImage();
        }

        private void radio_a4_CheckedChanged(object sender, EventArgs e)
        {
            obj_Home_Form.FrmBgColor = "a4";

            obj_Home_Form.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a4));

            obj_Home_Form.updateBgFormImage();
        }

        private void radio_a5_CheckedChanged(object sender, EventArgs e)
        {
            obj_Home_Form.FrmBgColor = "a5";

            obj_Home_Form.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a5));

            obj_Home_Form.updateBgFormImage();
        }

        private void radio_a6_CheckedChanged(object sender, EventArgs e)
        {
            obj_Home_Form.FrmBgColor = "a6";

            obj_Home_Form.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a6));

            obj_Home_Form.updateBgFormImage();
        }

        private void radio_a7_CheckedChanged(object sender, EventArgs e)
        {
            obj_Home_Form.FrmBgColor = "a7";

            obj_Home_Form.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a7));

            obj_Home_Form.updateBgFormImage();
        }

        private void radio_a8_CheckedChanged(object sender, EventArgs e)
        {
            obj_Home_Form.FrmBgColor = null;

            obj_Home_Form.BackgroundImage = null;

            obj_Home_Form.updateBgFormImage();
        }

        //Password buttons panel
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, SystemColors.ControlLight, ButtonBorderStyle.Solid);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            txtAdress.Clear();
            txtName.Clear();
            txtPLZ_Ort.Clear();
            txtEmail.Clear();
            txtFax.Clear();
            txtWWW.Clear();
            txtTel.Clear();
        }

        private void btnBild_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Bild(*.*)|*.*|JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|GIF Files(*.gif)|*.gif";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                textBox_image_path.Text = picPath;
                //Bildauswahl Tab
                pictureBox12.ImageLocation = picPath;
            }
        }

        public void get_settings_image()
        {
            try
            {
                string Query = "select * from um_db.einstellungen_firma;";
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
                        pictureBox12.Image = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox12.Image = System.Drawing.Image.FromStream(mstream);
                    }
                }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void um_setting_fill()
        {
            try
            {
                //Get settings Data from Database
                string Query = "select * from um_db.einstellungen_firma;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();
                
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sName = myReader.GetString("Name");
                    string sAdress = myReader.GetString("Adresse");
                    string sPLZ = myReader.GetString("PLZ_Ort");
                    string sTel = myReader.GetString("Tel");
                    string sFax = myReader.GetString("Fax");
                    string sEmail = myReader.GetString("Email");
                    string sWWW = myReader.GetString("www");

                    txtName.Text = sName;
                    txtAdress.Text = sAdress;
                    txtPLZ_Ort.Text = sPLZ;
                    txtTel.Text = sTel;
                    txtFax.Text = sFax;
                    txtEmail.Text = sEmail;
                    txtWWW.Text = sWWW;
                }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Get Image from function get_image()
            get_settings_image();
        }

        private void btnSpeichernEin_Click(object sender, EventArgs e)
        {
            //Keine build validation
            if (textBox_image_path.TextLength == 0)
            {
                MessageBox.Show("Kein Logo ausgewählt!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox_image_path.Text = textBox_image_path.Text = (Application.StartupPath) + "\\" + "Resources" + "\\" + "kein_logo.png";

                pictureBox12.Image = Properties.Resources.kein_logo;
            }
            //Keine Firmaname Validation
            if (txtName.TextLength == 0)
            {
                this.txtName.Focus();
                txtName.BackColor = Color.Tomato;
                return;
            }
            else
            {
                try //If firmendaten exists
                {
                    string Query_frmExist = "select * from um_db.einstellungen_firma;";
                    MySqlConnection conDataBase_frmExist = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase_frmExist = new MySqlCommand(Query_frmExist, conDataBase_frmExist);
                    MySqlDataReader myReader_frmExist;

                    //Connection Open
                    conDataBase_frmExist.Open();

                    myReader_frmExist = cmdDataBase_frmExist.ExecuteReader();

                    if (myReader_frmExist.HasRows)
                    {
                        try
                        {
                            //Getting Image content and ImagePath to store in database
                            byte[] imageBt = null;
                            FileStream fstream = new FileStream(this.textBox_image_path.Text, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fstream);
                            imageBt = br.ReadBytes((int)fstream.Length);

                            string Update_frmExist = "update um_db.einstellungen_firma set Name='" + this.txtName.Text + "', Adresse='" + this.txtAdress.Text + "', PLZ_Ort='" + this.txtPLZ_Ort.Text + "', Tel='" + this.txtTel.Text + "', Fax='" + this.txtFax.Text + "', Email='" + this.txtEmail.Text + "', www='" + this.txtWWW.Text + "', Logo=@IMG;";
                            MySqlConnection conDataBaseUpdate_frmExist = new MySqlConnection(constring);
                            MySqlCommand cmdDataBaseUpdate_frmExist = new MySqlCommand(Update_frmExist, conDataBaseUpdate_frmExist);
                            MySqlDataReader myReaderUpdate_frmExist;
                            conDataBaseUpdate_frmExist.Open();
                            cmdDataBaseUpdate_frmExist.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                            myReaderUpdate_frmExist = cmdDataBaseUpdate_frmExist.ExecuteReader();
                            MessageBox.Show("Die Daten wurden aktualisiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            while (myReaderUpdate_frmExist.Read()) { }
                            //Fill textboxes
                            um_setting_fill();
                            conDataBaseUpdate_frmExist.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        //Save in MySQL
                        //Getting Image content and ImagePath to store in database
                        byte[] imageBt = null;
                        FileStream fstream = new FileStream(this.textBox_image_path.Text, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fstream);
                        imageBt = br.ReadBytes((int)fstream.Length);

                        try
                        {
                            string Query2 = "insert into um_db.einstellungen_firma (Name, Adresse, PLZ_Ort, Tel, Fax, Email, www, Logo) values('" + txtName.Text + "', '" + txtAdress.Text + "', '" + txtPLZ_Ort.Text + "', '" + txtTel.Text + "', '" + txtFax.Text + "', '" + txtEmail.Text + "', '" + txtWWW.Text + "', @IMG) ;";
                            MySqlConnection conDataBase2 = new MySqlConnection(constring);
                            MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2);
                            MySqlDataReader myReader2;
                            conDataBase2.Open();
                            cmdDataBase2.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                            myReader2 = cmdDataBase2.ExecuteReader();

                            MessageBox.Show("Firmendaten erfolgreich eingegeben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Fill textboxes
                            um_setting_fill();

                            while (myReader2.Read()) { }
                            conDataBase2.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    //Close Connection
                    conDataBase_frmExist.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel3.ClientRectangle, SystemColors.ControlLight, ButtonBorderStyle.Solid);
        }

        private void btnDatenSichern_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In die nächste Version verfügbar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
