using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Universal_Management
{
    public partial class Login : Form
    {
        //ConnString
        string connstring = "datasource=localhost;port=3306;username=root;password=123456";

        public Login()
        {
            InitializeComponent();

            CheckDbConnection();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Set user settings for LoginSave (in Project-Properties-Settings)
            if (Properties.Settings.Default.rememLoginCheck == "yes")
            {
                checkBoxSaveLogin.Checked = true;
                username_txt.Text = Properties.Settings.Default.rememLoginUsername;
                password_txt.Text = Properties.Settings.Default.rememLoginPassword;
            }
            else
            {
                checkBoxSaveLogin.Checked = false;
                username_txt.Text = null;
                password_txt.Text = null;
            }
      
            //Getting Application number of runs from AppSettings
            calc_app_number_of_runs();
            lblCount.Text = Properties.Settings.Default.AppNumberOfRuns.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(connstring);
                MySqlCommand SelectCommand = new MySqlCommand("select * from um_db.users where username='" + this.username_txt.Text + "' and password='" + this.password_txt.Text + "' ;", myConn);
                MySqlDataReader myReader;

                //Connection Open
                myConn.Open();

                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    //Copy to App Settings if loginsave checkbox checked (in Project-Properties-Settings)
                    if (checkBoxSaveLogin.Checked == true)
                    {
                        Properties.Settings.Default.rememLoginCheck = "yes";
                        Properties.Settings.Default.rememLoginUsername = username_txt.Text;
                        Properties.Settings.Default.rememLoginPassword = password_txt.Text;
                        // Save settings
                        Properties.Settings.Default.Save();
                    }
                    else if (checkBoxSaveLogin.Checked == false)
                    {
                        Properties.Settings.Default.rememLoginCheck = null;
                        Properties.Settings.Default.rememLoginUsername = null;
                        Properties.Settings.Default.rememLoginPassword = null;
                        // Save settings
                        Properties.Settings.Default.Save();
                    }

                    //Go to Main Menu
                    this.Hide();
                    //Post username to other Forms...
                    Home main_form = new Home(username_txt.Text);
                    main_form.ShowDialog();
                    this.Close();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Doppelte Benutzername und Passwort. Zugriff verweigert!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Benutzernamen oder Passwort ist nicht korrekt. Bitte versuchen Sie es erneut.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //Connection Close
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private bool CheckDbConnection() //Check the database connection START
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(connstring);

                myConn.Open();
               
                myConn.Close();

                username_txt.Enabled = true;
                password_txt.Enabled = true;
                //login button
                btnLogin.Enabled = true;

                return true;
            }
            catch (Exception)
            {
                //login textboxes
                username_txt.Enabled = false;
                password_txt.Enabled = false;
                //login button
                btnLogin.Enabled = false;
                //Change "Datenbank erstellen" button
                lblInfo.Enabled = true;
                lblInfo.Text = "Keine Verbindung zu MySQL Datenbank";
                lblInfo.ForeColor = Color.DarkRed;

                MessageBox.Show("Es konnte keine Verbindung zur Datenbank hergestellt werden!", "Achtung", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
        } //Check the database connection END

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
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
                Application.ExitThread();
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        protected void calc_app_number_of_runs()
        {
            int count = Properties.Settings.Default.AppNumberOfRuns;

            //Increase count everytime app runs
            count = count + 1;

            //Copy to App Settings app number of runs (in Project-Properties-Settings)
            Properties.Settings.Default.AppNumberOfRuns = count;
            //Save Settings
            Properties.Settings.Default.Save();
        }

    }
}
