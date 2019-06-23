using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Threading;//SplashScreen
using MySql.Data.MySqlClient;

using System.Globalization;

namespace Universal_Management
{
    public partial class Home : Form
    {
        //ConnString to MySQL string
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Termine form object
        Termine termine = new Termine();

        public Home(string UserName)
        {
            //de-De Format DateTime (24/11/1984 00:00:00)
            //Very Important***
            //Takes the Time from Application not from PC
            custom_dateTime();

            InitializeComponent();

            //textbox with username
            label_user.Text = UserName;

            //BackgroundImage Function
            showBgFormImage();

            //Start timer1 for date calculations
            timer1.Start();
        }

        //Application custom dateTime (24.11.1984 00:00:00)
        //Very Important***
        //Takes the Time from Application not from PC
        public void custom_dateTime()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
        }

        //*****************Changing background with data from database START***************************//
        //string to get values of clicked button 
        public string FrmBgColor;

        //Update MainMenu BackroundImage
        public void updateBgFormImage()
        {
            //Copy to App Settings background change (in Project-Properties-Settings)
            Properties.Settings.Default.FormBackground = FrmBgColor;
            // Save settings
            Properties.Settings.Default.Save();
        }

        //Load Background Image related to appSettings string
        public void showBgFormImage()
        {
            if (Properties.Settings.Default.FormBackground == "a1")
            {
                this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a1));
            }
            if (Properties.Settings.Default.FormBackground == "a2")
            {
                this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a2));
            }
            if (Properties.Settings.Default.FormBackground == "a3")
            {
                this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a3));
            }
            if (Properties.Settings.Default.FormBackground == "a4")
            {
                this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a4));
            }
            if (Properties.Settings.Default.FormBackground == "a5")
            {
                this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a5));
            }
            if (Properties.Settings.Default.FormBackground == "a6")
            {
                this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a6));
            }
            if (Properties.Settings.Default.FormBackground == "a7")
            {
                this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a7));
            }
            if (Properties.Settings.Default.FormBackground == null)
            {
                this.BackgroundImage = null;
            }
        }//*****************Changing background with data from database END***************************//

        //Check awailable Program Messages
        public void check_AwailableMessages()
        {
            try
            {
                string Query_CeckMsg = "select count(*) from um_db.nachrichten where seen='" + "no" + "';";
                MySqlConnection conDataBase_CeckMsg = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_CeckMsg = new MySqlCommand(Query_CeckMsg, conDataBase_CeckMsg);
                MySqlDataReader myReader_CeckMsg;
                //Open Connection
                conDataBase_CeckMsg.Open();

                int CountSeen = 0;
                CountSeen = int.Parse(cmdDataBase_CeckMsg.ExecuteScalar().ToString());

                myReader_CeckMsg = cmdDataBase_CeckMsg.ExecuteReader();

                if (CountSeen > 0)
                {
                    //If new messages awailable then show form
                    Daily_Report d_report = new Daily_Report();
                    d_report.ShowDialog();
                }

                //Close Connection
                conDataBase_CeckMsg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check_AwailableMessages Fehler: in Form Daily_report!");
                MessageBox.Show(ex.Message);
            }
        }

        private void Home_Shown(object sender, EventArgs e)
        {
            //code when Home form is shown
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //label for showing dateTime Now
            label_date.Text = DateTime.Now.ToString("dd/MM/yyyy"); //Format 30.5.2015
            //HomeMenu buttons in Panel Manipulation
            HomePage1.Visible = true;
            HomePage2.Visible = false;

            ////////Form Termine Action START///////
            Termine termine = new Termine();
            termine.Opacity = 0;
            termine.lblVisible.Text = "Hide";
            termine.ShowDialog();
            //Show notifyIcon1 in Home Form
            if (notifyIcon1 != null)
            {
                //NotifyIcon balloon
                notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(3000);
            }
            ////////Form Termine Action END///////

            ////////FeierTage Message START///////
            var feiertage = new FeierTage();
            feiertage.check_Holiday_dates();
            ////////FeierTage Message END///////

            ////////Urlaube Message START///////
            var urlaube = new Urlaube();
            urlaube.check_Urlaube_dates();
            ////////Urlaube Message END///////

            ////////Krankenstand Message START///////
            var krankendstand_update = new Mitarbeiter_Krankenstand_Update();
            krankendstand_update.check_Krankenstand_dates();
            ////////Krankendstand Message END///////

            ////////Firma Einstellungen START///////
            get_firma_settings();
            ////////Firma Einstellungen END///////

            //Check Mitarbeiter Expired Visum
            Mitarbeiter mit = new Mitarbeiter();
            mit.check_expired_visum();
            mit.check_Birthdays();

            ////////Daily_report(Tagesbericht) START///////
            check_AwailableMessages();
            ////////Daily_report END///////
        }

        //Exit application code
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Show Termin MessageBox
            var myMessageBox = new MyMessageBox();
            myMessageBox.btnJa.Text = "Ja";
            myMessageBox.btnNein.Text = "Nein";
            myMessageBox.Text = "Wichtige Information";
            myMessageBox.txtText.Text = "\nMöchten Sie das Programm wirklich verlassen?";    

            DialogResult result = myMessageBox.ShowDialog();

            //If MessageBox "OK" Clicked
            if (result == DialogResult.OK)
            {
                //Remove all notifyicons in systemtrays
                notifyIcon1.Visible = false;
                notifyIcon1.Icon = null;
                notifyIcon1.Dispose();

                Application.ExitThread();
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }

        }

        //logout
        private void btnAbmelden_Click(object sender, EventArgs e)
        {
            //Restart Application
            try
            {
                //run the program again and close this one
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                //or you can use Application.ExecutablePath

                //destroy any notifyicon
                notifyIcon1.Visible = false;
                notifyIcon1.Dispose();

                //close this one
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMitarbeiter_Click(object sender, EventArgs e)
        {
            var Mitarbeiter = new Mitarbeiter();
            Mitarbeiter.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //App dateTime
            label_time.Text = DateTime.Now.ToString("HH:mm:ss"); //Format 22:10:33
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var um_settings = new UM_Settings();
            um_settings.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Open form and post username for future use
            Notizen Notizen = new Notizen();

            Notizen.User.Text = this.label_user.Text; 

            Notizen.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Urlaube = new Urlaube();
            Urlaube.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var UM_Maps = new UM_Maps();
            UM_Maps.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var FeierTage = new FeierTage();
            FeierTage.ShowDialog();
        }

        //Changin Home Form Background from toolStripMenuItem2_Click
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmBgColor = "a1";

            this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a1));

            updateBgFormImage();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmBgColor = "a2";

            this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a2));

            updateBgFormImage();
        }

        private void a3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBgColor = "a3";

            this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a3));

            updateBgFormImage();
        }

        private void a4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBgColor = "a4";

            this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a4));

            updateBgFormImage();
        }

        private void a5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBgColor = "a5";

            this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a5));

            updateBgFormImage();
        }

        private void a7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBgColor = "a6";

            this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a6));

            updateBgFormImage();
        }

        private void a7ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBgColor = "a7";

            this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.a7));

            updateBgFormImage();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var Bewerber = new Bewerber();
            Bewerber.ShowDialog();
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBgColor = null;

            this.BackgroundImage = null;

            updateBgFormImage();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Firmenbuch = new Firmenbuch();
            Firmenbuch.ShowDialog();
        }

        private void aboutUniversalManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var About = new About();
            About.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var stundenliste = new Stundenliste();
            stundenliste.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UM_Backup um_back = new UM_Backup();
            um_back.ShowDialog();
        }

        private void Home_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HomePage1.Visible = false;
            HomePage2.Visible = true;

            btnBack.Enabled = true;
            btnMainMenu.Enabled = true;
            
            btnNext.Enabled = false;

            square1.Visible = true;
            square2.Visible = false;

            square11.Visible = false;
            square22.Visible = true;
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            HomePage1.Visible = true;
            HomePage2.Visible = false;

            btnBack.Enabled = false;
            btnMainMenu.Enabled = false;

            btnNext.Enabled = true;

            square1.Visible = false;
            square2.Visible = true;

            square11.Visible = true;
            square22.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HomePage1.Visible = true;
            HomePage2.Visible = false;

            btnBack.Enabled = false;
            btnMainMenu.Enabled = false;

            btnNext.Enabled = true;

            HomePage1.Visible = true;

            btnBack.Enabled = false;
            btnMainMenu.Enabled = false;

            btnNext.Enabled = true;

            square1.Visible = false;
            square2.Visible = true;

            square11.Visible = true;
            square22.Visible = false;
        }

        //Termine Button
        private void button12_Click(object sender, EventArgs e)
        {
            termine.lblVisible.Text = "";
            termine.Show();
        }

        public void get_firma_settings()
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
                if (!(myReader.HasRows))
                {
                    //Get date and time Now
                    DateTime dateTimeNow = DateTime.Now;
                    DateTime dateNow = Convert.ToDateTime(dateTimeNow);

                    var boxMessage = "Bitte Firma Einstellungen eingeben.";

                    //Insert into nachrichten START **************************************************************
                    try //check if msg exist to avoid duplicate start
                    {
                        string Query_checkmsg = "select * from um_db.nachrichten where msg='" + boxMessage + "' ;";
                        MySqlConnection conDataBase_checkmsg = new MySqlConnection(constring);
                        MySqlCommand cmdDataBase_checkmsg = new MySqlCommand(Query_checkmsg, conDataBase_checkmsg);
                        MySqlDataReader myReader_checkmsg;
                        //Open Connection
                        conDataBase_checkmsg.Open();
                        myReader_checkmsg = cmdDataBase_checkmsg.ExecuteReader();
                        if (!(myReader_checkmsg.HasRows))
                        {
                            try
                            {
                                string Query_msg = "insert into um_db.nachrichten (msg,menu,datetime) values('" + boxMessage + "','" + "Einstellungen" + "','" + dateNow + "');";
                                MySqlConnection conDataBase_msg = new MySqlConnection(constring);
                                MySqlCommand cmdDataBase_msg = new MySqlCommand(Query_msg, conDataBase_msg);
                                MySqlDataReader myReader_msg;
                                //Open Connection
                                conDataBase_msg.Open();
                                myReader_msg = cmdDataBase_msg.ExecuteReader();
                                while (myReader_msg.Read()) { }
                                //Close Connection
                                conDataBase_msg.Close();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Firma Einstellungen Fehler: in Nachrichten eingeben!");
                            }
                        }
                        //Close Connection
                        conDataBase_checkmsg.Close();
                    } //check if msg exist to avoid duplicate end
                    catch (Exception)
                    {
                        MessageBox.Show("Feiertage Fehler: in Nachrichten check!");
                    }
                    //Insert into nachrichten END ******************************************************************
                }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Dokumente Form
        private void button13_Click(object sender, EventArgs e)
        {
            var dokumente = new Dokumente();
            dokumente.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var rechnungen = new Rechnungen();
            rechnungen.ShowDialog();
        }

        private void einstellungenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var um_settings = new UM_Settings();
            um_settings.ShowDialog();
        }

        private void mitarbeiterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Mitarbeiter = new Mitarbeiter();
            Mitarbeiter.ShowDialog();
        }

        private void bewerberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var bewerber = new Bewerber();
            bewerber.ShowDialog();
        }

        private void studenlisteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stundenliste = new Stundenliste();
            stundenliste.ShowDialog();
        }

        private void urlaubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Urlaube = new Urlaube();
            Urlaube.ShowDialog();
        }

        private void rechnungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rechnungen = new Rechnungen();
            rechnungen.ShowDialog();
        }

        private void firmenbuchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Firmenbuch = new Firmenbuch();
            Firmenbuch.ShowDialog();
        }

        private void archiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UM_Backup um_back = new UM_Backup();
            um_back.ShowDialog();
        }

        private void notizenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open form and post username for future use
            Notizen Notizen = new Notizen();

            Notizen.User.Text = this.label_user.Text;

            Notizen.ShowDialog();
        }

        private void mapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var UM_Maps = new UM_Maps();
            UM_Maps.ShowDialog();
        }

        private void termineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (termine.Visible == false)
            {
                termine.lblVisible.Text = "Visible";
                termine.ShowDialog();
            }
        }

        private void feiertageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FeierTage = new FeierTage();
            FeierTage.ShowDialog();
        }

        private void dokumenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dokumente = new Dokumente();
            dokumente.ShowDialog();
        }

        private void abmeldenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show myMessageBox Form
            var myMessageBox = new MyMessageBox();
            myMessageBox.btnJa.Text = "Ja";
            myMessageBox.btnNein.Text = "Nein";
            myMessageBox.Text = "Wichtige Information";
            myMessageBox.txtText.Text = "\nMöchten Sie das Programm wirklich verlassen?";

            DialogResult result = myMessageBox.ShowDialog();

            //If MessageBox "Ja" Clicked
            if (result == DialogResult.OK)
            {
                this.notifyIcon1.Visible = false;
                this.notifyIcon1.Icon = null;
                this.notifyIcon1.Dispose();
                this.notifyIcon1 = null;

                Application.ExitThread();
            }
            //If MessageBox "Nein" Clicked
            else if (result == DialogResult.Cancel)
            {
                myMessageBox.Close();
            }
        }

        //notifyIcon1_MouseDoubleClick
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            termine.lblVisible.Text = "";
            termine.Show();
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinkLabel lbllink = new LinkLabel();
            lbllink.Text = "http://necom.at";

            MessageBox.Show("Für weitere Informationen besuchen Sie bitte unsere Website:\n" + lbllink.Text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tagesberichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Daily_Report d_report = new Daily_Report();
            d_report.ShowDialog();
        }

    }
}
