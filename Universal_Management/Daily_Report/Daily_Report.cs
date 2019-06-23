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
    public partial class Daily_Report : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Daily_Report()
        {
            InitializeComponent();
        }

        private void Daily_Report_Load(object sender, EventArgs e)
        {
            check_Bewerber();
            check_Mitarbeiter();
            check_Kunden();
            check_Notizen();
            check_Feiertage();
            check_Termine();
            check_Kunden();
            check_Allgemein();
        }

        //Function to check Feiertage Messages
        public void check_Feiertage()
        {
            try
            {
                string Query_feiertage = "select count(*) from um_db.nachrichten where menu='" + "Feiertage" + "' and seen='" + "no" + "';";
                MySqlConnection conDataBase_feiertage = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_feiertage = new MySqlCommand(Query_feiertage, conDataBase_feiertage);
                MySqlDataReader myReader_feiertage;
                //Open Connection
                conDataBase_feiertage.Open();

                int CountSeen = 0;
                CountSeen = int.Parse(cmdDataBase_feiertage.ExecuteScalar().ToString());

                myReader_feiertage = cmdDataBase_feiertage.ExecuteReader();

                if (CountSeen > 0)
                {
                    //label
                    lblMsgFeier.ForeColor = Color.YellowGreen;
                    lblMsgFeier.Text = "Sie haben (" + CountSeen + ") Nachricht(en).";
                    //button
                    btnFei.Enabled = true;
                    btnFei.ForeColor = Color.YellowGreen;
                    //groupbox text
                    BoxFei.ForeColor = Color.YellowGreen;
                }

                //Close Connection
                conDataBase_feiertage.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Feiertage Fehler: in Form Daily_report!");
                MessageBox.Show(ex.Message);
            }
        }

        //Function to check Mitarbeiter Messages
        public void check_Bewerber()
        {
            try
            {
                string Query_Bewerber = "select count(*) from um_db.nachrichten where menu='" + "Bewerber" + "' and seen='" + "no" + "';";
                MySqlConnection conDataBase_Bewerber = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_Bewerber = new MySqlCommand(Query_Bewerber, conDataBase_Bewerber);
                MySqlDataReader myReader_Bewerber;
                //Open Connection
                conDataBase_Bewerber.Open();

                int CountSeen = 0;
                CountSeen = int.Parse(cmdDataBase_Bewerber.ExecuteScalar().ToString());

                myReader_Bewerber = cmdDataBase_Bewerber.ExecuteReader();

                if (CountSeen > 0)
                {
                    //label
                    lblMsgBew.ForeColor = Color.YellowGreen;
                    lblMsgBew.Text = "Sie haben (" + CountSeen + ") Nachricht(en).";
                    //button
                    btnBew.Enabled = true;
                    btnBew.ForeColor = Color.YellowGreen;
                    //groupbox text
                    Box_Bew.ForeColor = Color.YellowGreen;
                }

                //Close Connection
                conDataBase_Bewerber.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bewerber Fehler: in Form Daily_report!");
                MessageBox.Show(ex.Message);
            }
        }

        //Function to check Mitarbeiter Messages
        public void check_Mitarbeiter()
        {
            try
            {
                string Query_Mitarbeiter = "select count(*) from um_db.nachrichten where menu='" + "Mitarbeiter" + "' and seen='" + "no" + "';";
                MySqlConnection conDataBase_Mitarbeiter = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_Mitarbeiter = new MySqlCommand(Query_Mitarbeiter, conDataBase_Mitarbeiter);
                MySqlDataReader myReader_Mitarbeiter;
                //Open Connection
                conDataBase_Mitarbeiter.Open();

                int CountSeen = 0;
                CountSeen = int.Parse(cmdDataBase_Mitarbeiter.ExecuteScalar().ToString());

                myReader_Mitarbeiter = cmdDataBase_Mitarbeiter.ExecuteReader();

                if (CountSeen > 0)
                {
                    //label
                    lblMsgMit.ForeColor = Color.YellowGreen;
                    lblMsgMit.Text = "Sie haben (" + CountSeen + ") Nachricht(en).";
                    //button
                    btnMit.Enabled = true;
                    btnMit.ForeColor = Color.YellowGreen;
                    //groupbox text
                    BoxMit.ForeColor = Color.YellowGreen;
                }

                //Close Connection
                conDataBase_Mitarbeiter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mitarbeiter Fehler: in Form Daily_report!");
                MessageBox.Show(ex.Message);
            }
        }

        //Function to check Kunden Messages
        public void check_Kunden()
        {
            try
            {
                string Query_kunden = "select count(*) from um_db.nachrichten where menu='" + "Kunden" + "' and seen='" + "no" + "';";
                MySqlConnection conDataBase_kunden = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_kunden = new MySqlCommand(Query_kunden, conDataBase_kunden);
                MySqlDataReader myReader_kunden;
                //Open Connection
                conDataBase_kunden.Open();

                int CountSeen = 0;
                CountSeen = int.Parse(cmdDataBase_kunden.ExecuteScalar().ToString());

                myReader_kunden = cmdDataBase_kunden.ExecuteReader();

                if (CountSeen > 0)
                {
                    //label
                    lblMsgKunden.ForeColor = Color.YellowGreen;
                    lblMsgKunden.Text = "Sie haben (" + CountSeen + ") Nachricht(en).";
                    //button
                    btnKun.Enabled = true;
                    btnKun.ForeColor = Color.YellowGreen;
                    //groupbox text
                    boxKun.ForeColor = Color.YellowGreen;
                }
                //Close Connection
                conDataBase_kunden.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Notizen Fehler: in Form Daily_report!");
                MessageBox.Show(ex.Message);
            }
        }

        //Function to check Feiertage Messages
        public void check_Termine()
        {
            try
            {
                string Query_termine = "select count(*) from um_db.nachrichten where menu='" + "Termine" + "' and seen='" + "no" + "';";
                MySqlConnection conDataBase_termine = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_termine = new MySqlCommand(Query_termine, conDataBase_termine);
                MySqlDataReader myReader_termine;
                //Open Connection
                conDataBase_termine.Open();

                int CountSeen = 0;
                CountSeen = int.Parse(cmdDataBase_termine.ExecuteScalar().ToString());

                myReader_termine = cmdDataBase_termine.ExecuteReader();

                if (CountSeen > 0)
                {
                    //label
                    lblMsgTerm.ForeColor = Color.YellowGreen;
                    lblMsgTerm.Text = "Sie haben (" + CountSeen + ") Nachricht(en).";
                    //button
                    btnTerm.Enabled = true;
                    btnTerm.ForeColor = Color.YellowGreen;
                    //groupbox text
                    BoxTerm.ForeColor = Color.YellowGreen;
                }
                //Close Connection
                conDataBase_termine.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Termine Fehler: in Form Daily_report!");
                MessageBox.Show(ex.Message);
            }
        }

        //Function to check Notizen Messages
        public void check_Notizen()
        {
            try
            {
                string Query_notizen = "select count(*) from um_db.nachrichten where menu='" + "Notizen" + "' and seen='" + "no" + "';";
                MySqlConnection conDataBase_notizen = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_notizen = new MySqlCommand(Query_notizen, conDataBase_notizen);
                MySqlDataReader myReader_notizen;
                //Open Connection
                conDataBase_notizen.Open();

                int CountSeen = 0;
                CountSeen = int.Parse(cmdDataBase_notizen.ExecuteScalar().ToString());

                myReader_notizen = cmdDataBase_notizen.ExecuteReader();

                if (CountSeen > 0)
                {
                    //label
                    lblMsgNot.ForeColor = Color.YellowGreen;
                    lblMsgNot.Text = "Sie haben (" + CountSeen + ") Nachricht(en).";
                    //button
                    btnNot.Enabled = true;
                    btnNot.ForeColor = Color.YellowGreen;
                    //groupbox text
                    BoxNot.ForeColor = Color.YellowGreen;
                }
                //Close Connection
                conDataBase_notizen.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Notizen Fehler: in Form Daily_report!");
                MessageBox.Show(ex.Message);
            }
        }

        //Function to check Allgemein Messages
        public void check_Allgemein()
        {
            try
            {
                string Query_allgemein = "select count(*) from um_db.nachrichten where menu='" + "Einstellungen" + "' and seen='" + "no" + "';";
                MySqlConnection conDataBase_allgemein = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_allgemein = new MySqlCommand(Query_allgemein, conDataBase_allgemein);
                MySqlDataReader myReader_allgemein;
                //Open Connection
                conDataBase_allgemein.Open();

                int CountSeen = 0;
                CountSeen = int.Parse(cmdDataBase_allgemein.ExecuteScalar().ToString());

                myReader_allgemein = cmdDataBase_allgemein.ExecuteReader();

                if (CountSeen > 0)
                {
                    //label
                    lblMsgAll.ForeColor = Color.YellowGreen;
                    lblMsgAll.Text = "Sie haben (" + CountSeen + ") Nachricht(en).";
                    //button
                    btnAll.Enabled = true;
                    btnAll.ForeColor = Color.YellowGreen;
                    //groupbox text
                    BoxAll.ForeColor = Color.YellowGreen;
                }
                //Close Connection
                conDataBase_allgemein.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Allgemein Fehler: in Form Daily_report!");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFei_Click_1(object sender, EventArgs e)
        {
            Daily_Report_View d_view = new Daily_Report_View();
            d_view.Text = "Feiertage";
            d_view.dataGridView1.Dock = DockStyle.Fill;
            d_view.panelHistory.Visible = false;
            this.Hide();
            d_view.ShowDialog();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Daily_Report_View d_view = new Daily_Report_View();
            d_view.Text = "Einstellungen";
            d_view.dataGridView1.Dock = DockStyle.Fill;
            d_view.panelHistory.Visible = false;
            this.Hide();
            d_view.ShowDialog();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            Daily_Report_View d_view = new Daily_Report_View();
            d_view.Text = "History";
            d_view.panelHistory.Visible = true;
            this.Hide();
            d_view.ShowDialog();
        }

        private void Daily_Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Remove all refetences of the form
            this.Dispose();
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            Daily_Report_View d_view = new Daily_Report_View();
            d_view.Text = "Notizen";
            d_view.dataGridView1.Dock = DockStyle.Fill;
            d_view.panelHistory.Visible = false;
            this.Hide();
            d_view.ShowDialog();
        }

        private void btnTerm_Click(object sender, EventArgs e)
        {
            Daily_Report_View d_view = new Daily_Report_View();
            d_view.Text = "Termine";
            d_view.dataGridView1.Dock = DockStyle.Fill;
            d_view.panelHistory.Visible = false;
            this.Hide();
            d_view.ShowDialog();
        }

        private void Daily_Report_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void btnMit_Click(object sender, EventArgs e)
        {
            Daily_Report_View d_view = new Daily_Report_View();
            d_view.Text = "Mitarbeiter";
            d_view.dataGridView1.Dock = DockStyle.Fill;
            d_view.panelHistory.Visible = false;
            this.Hide();
            d_view.ShowDialog();
        }

        private void btnBew_Click(object sender, EventArgs e)
        {
            Daily_Report_View d_view = new Daily_Report_View();
            d_view.Text = "Bewerber";
            d_view.dataGridView1.Dock = DockStyle.Fill;
            d_view.panelHistory.Visible = false;
            this.Hide();
            d_view.ShowDialog();
        }

        private void btnKun_Click(object sender, EventArgs e)
        {
            Daily_Report_View d_view = new Daily_Report_View();
            d_view.Text = "Kunden";
            d_view.dataGridView1.Dock = DockStyle.Fill;
            d_view.panelHistory.Visible = false;
            this.Hide();
            d_view.ShowDialog();
        }
    }
}
