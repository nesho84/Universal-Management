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
    public partial class Bewerber_Profile : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh datagridview on form Bewerber
        Bewerber obj_bewerber = (Bewerber)Application.OpenForms["Bewerber"];
        public Bewerber_Profile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void get_profile_data_from_db()
        {
            try
            {
                //Get Mitarbeiter Data from Database
                string Query = "select * from um_db.mitarbeiter where MITID='" + this.lblID.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Open Connection
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();

                if (myReader.HasRows == true)//Abvoid Reader error
                {
                    while (myReader.Read())
                    {
                        string sAG = myReader.GetString("Titel");
                        string sFamilienname = myReader.GetString("Familienname");
                        string sVorname = myReader.GetString("Vorname");
                        string sGeschlecht = myReader.GetString("Geschlecht");
                        string sGDatum = myReader.GetString("G_Datum");
                        string sTel = myReader.GetString("Tel");
                        string sPLZ = myReader.GetString("PLZ_Ort");
                        string sFS = myReader.GetString("Familienstand");
                        string sST = myReader.GetString("Strasse");
                        string sEM = myReader.GetString("Email");
                        string sSV = myReader.GetString("SV_Nummer");
                        string sA = myReader.GetString("Erlaubnis");
                        string sS = myReader.GetString("StaatBurg_");
                        string sEintrit = myReader.GetString("F_Eintriit");
                        string sB = myReader.GetString("M_Besch_als");
                        string sGehaltsvorstell = myReader.GetString("Gehaltsvorstell_");
                        string sSTP = myReader.GetString("Staplerschein");
                        string sAV = myReader.GetString("Arb_im_Ausmass");
                        string sL = myReader.GetString("M_Leiarbeiter");
                        string sF = myReader.GetString("Fuhrerschein");
                        string sPV = myReader.GetString("PKW_zu_Verfugung");
                        string sFK = myReader.GetString("M_Fahrkosten");
                        string sSA = myReader.GetString("Anmerkugen");
                        string sL_a_Tatigkeit = myReader.GetString("L_a_Tatigkeit");
                        string sReise = myReader.GetString("Reisebereitschaft");
                        string sSchicht = myReader.GetString("Schichtbereitschaft");
                        string sMonStd = myReader.GetString("M_RegStunden");

                        lblAkGrad.Text = sAG;
                        lblFam.Text = sFamilienname;
                        lblStr.Text = sST;
                        lblTel.Text = sTel;
                        lblSV.Text = sSV;
                        lblArbErl.Text = sA;
                        lblStaat.Text = sS;
                        lblGesch.Text = sGeschlecht;
                        lblVorname.Text = sVorname;
                        lblPLZ.Text = sPLZ;
                        lblEmail.Text = sEM;
                        lblGeb.Text = sGDatum;
                        lblFamilienstand.Text = sFS;
                        lblFru.Text = sEintrit;
                        lblTatigkeit.Text = sL_a_Tatigkeit;
                        lblGehalt.Text = sGehaltsvorstell;
                        lblStaplerschein.Text = sSTP;
                        lblAusmass.Text = sAV;
                        lblFuhrerschein.Text = sF;
                        lblPKW.Text = sPV;
                        lblReise.Text = sReise;
                        lblSchicht.Text = sSchicht;
                        txtAnmerkungen.Text = sSA;
                        lblMonStd.Text = sMonStd;
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

            void get_image()
            {
                try
                {
                    string Query = "select * from um_db.mitarbeiter where MITID='" + this.lblID.Text + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Open Connection
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    if (myReader.HasRows == true) //Abvoid Reader error
                    {
                        while (myReader.Read())
                        {
                            //Getting Image from database
                            byte[] imgg = (byte[])(myReader["bild"]);
                            if (imgg == null)
                            {
                                pictureBox2.Image = null;
                            }
                            else
                            {
                                MemoryStream mstream = new MemoryStream(imgg);
                                pictureBox2.Image = System.Drawing.Image.FromStream(mstream);
                            }
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

            private void Bewerber_Profile_Load(object sender, EventArgs e)
            {
                get_profile_data_from_db();

                get_image();
            }

            private void button2_Click(object sender, EventArgs e)
            {
                string MITID = this.lblID.Text;

                if (MessageBox.Show("Sind Sie sicher?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string Query = "delete from um_db.mitarbeiter where MITID='" + MITID + "' ;";
                        MySqlConnection conDataBase = new MySqlConnection(constring);
                        MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                        MySqlDataReader myReader;

                        //Open Connection
                        conDataBase.Open();

                        myReader = cmdDataBase.ExecuteReader();
                        MessageBox.Show("Bewerber wurde erfolgreich gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        while (myReader.Read()) { }

                        //Refresh dataGridView1 on bewerber form
                        obj_bewerber.dataGridView1.DataSource = null;
                        obj_bewerber.load_table();
                        obj_bewerber.dataGridView1.Update();
                        obj_bewerber.dataGridView1.Refresh();

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

            private void btnPrint_Click(object sender, EventArgs e)
            {
                Bewerber_Profile_Report bew_Profile_rep = new Bewerber_Profile_Report();

                bew_Profile_rep.lblID.Text = this.lblID.Text;

                bew_Profile_rep.ShowDialog();
            }

            private void Bewerber_Profile_FormClosing(object sender, FormClosingEventArgs e)
            {
                Bewerber bew = new Bewerber();

                this.Hide();

                bew.ShowDialog();
            }

    }
}
