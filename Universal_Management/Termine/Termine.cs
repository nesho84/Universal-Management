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
using System.Globalization;

namespace Universal_Management
{
    public partial class Termine : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;user=root;password=123456";
        //string constring = "SERVER=localhost;" +
        //                    "DATABASE=um_db;" +
        //                    "UID=root;" +
        //                    "PASSWORD=1234;";

        public Termine()
        {
            InitializeComponent();
        }

        //datagridview dataset
        DataTable dbdataset;

        //Fill datagridview with database rows
        public void load_table_events()
        {
            try
            {
                //List databse Table to datagridview
                MySqlConnection conDataBase_load = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_load = new MySqlCommand("select * from um_db.events order by Start DESC;", conDataBase_load);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase_load;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

                //Close Connection
                conDataBase_load.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Start txtTime textbox Timer
            DateTime dateTime = DateTime.Now;
            DateTime nowTime = Convert.ToDateTime(dateTime);

            //textBox txtTime equal ti timeticker
            txtTime.Text = nowTime.ToString();

            //Check Termine Function call
            check_datagridview_rows();
        }

        //****************search datagridview for existing row START***********************
        public void check_datagridview_rows()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[2].Value.ToString().Equals(txtTime.Text))
                    {
                        timer1.Stop();
                        timer1.Enabled = false;

                        show_Termin();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        //****************search datagridview for existing row END***********************

        //Check Termine from Databse Function START***************************************************
        public void show_Termin()
        {
            try
            {
                //Get Stopped time from txtTime textbox
                string nowTime_Stopped = txtTime.Text;

                //Select "Start" rows in database.table "events"
                string Query = "select * from um_db.events where Start='" + nowTime_Stopped + "' ;";
                MySqlConnection Main_conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, Main_conDataBase);
                MySqlDataReader myReader;
                //Open Connection
                Main_conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                myReader.Read();

               //get Start row from Database
               string sEID = myReader.GetString("EID");
               string sTitel = myReader.GetString("Titel");
               string sStart2 = myReader.GetString("Start");
               string sEnde = myReader.GetString("Ende");
               string sOrt = myReader.GetString("Ort");
               string sText = myReader.GetString("Text");             

                    //Get Count Status Rows for this Termin ***** START ************************************
                    string Query4 = "select count(Status) from um_db.events where Status='" + "Laufend" + "';";
                    MySqlConnection conDataBase4 = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase4 = new MySqlCommand(Query4, conDataBase4);
                    conDataBase4.Open();

                    int GesehenRows = 0;
                    GesehenRows = int.Parse(cmdDataBase4.ExecuteScalar().ToString());
                    conDataBase4.Close();
                    //Get Count Status Rows for this Termin ***** END ***************************************
                    
                    //Show Termin Notification START**************
                    //Show Home Notifyicon1 in Taskbar
                    Home obj_Home = (Home)Application.OpenForms["Home"];
                    //NotifyIcon balloon
                    obj_Home.notifyIcon1.Visible = true;
                    obj_Home.notifyIcon1.BalloonTipText = "Sie haben eine neue Termin.";
                    obj_Home.notifyIcon1.ShowBalloonTip(500);
                    
                    //Show Termin MessageBox
                    var myMessageBox = new MyMessageBox();
                    myMessageBox.Text = "Termin Notifikation:";
                    myMessageBox.txtText.Text = sTitel + "\n\nPlus (" + GesehenRows + ") laufende Termnine";    

                    DialogResult result = myMessageBox.ShowDialog();
                    //Show Termin Notification END******************
                    
                    //If MessageBox "OK" Clicked
                    if (result == DialogResult.OK)
                    {
                        //Set string for "Status" = Yes row in the table events
                        string t_erledigt = "Termin erledigt";

                        try //Update edata Table, set Status row to Yes ***** START *****
                        {
                            string Query2 = "update um_db.events set Status='" + t_erledigt + "' where EID='" + sEID + "' ;";
                            MySqlConnection conDataBase2 = new MySqlConnection(constring);
                            MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2);
                            MySqlDataReader myReader2;

                            //Connection Open
                            conDataBase2.Open();

                            myReader2 = cmdDataBase2.ExecuteReader();

                            //Refresh datagridView
                            load_table_events();

                            //Open TerminView
                            Termine_View termine_view = new Termine_View();

                            //Load data from datagridview to form Feiertage_Update
                            termine_view.txtEID.Text = sEID;

                            termine_view.txtTitel.Text = sTitel;

                            termine_view.date1.Text = sStart2;

                            termine_view.date2.Text = sEnde;

                            termine_view.txtOrt.Text = sOrt;

                            termine_view.richTextBox1.Text = sText;

                            termine_view.lblStatus.Text = "Termin erledigt.";

                            //Disable buttons
                            if (termine_view.btnErledigt != null)
                            {
                                termine_view.btnErledigt.Enabled = false;
                            }
                            if (termine_view.btnVerpasst != null)
                            {
                                termine_view.btnVerpasst.Enabled = false;
                            }
                            if (termine_view.btnLaufend != null)
                            {
                                termine_view.btnLaufend.Enabled = false;
                            }
                            //SHow form
                            termine_view.ShowDialog();

                            //Close Connection
                            conDataBase2.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }//Update events Table, set Status row to Yes ***** END *****

                        //Start timer1 again for other Termine
                        timer1.Enabled = true;
                        timer1.Start();
                    }
                    //If MessageBox "Nein" Clicked
                    else if (result == DialogResult.Cancel)
                    {
                        //Set string for "Verpasst" = Status row in the table events
                        string Verpasst = "Termin verpasst";
                        try //Update events Table, set Verpasst row to Verpasst ***** START *****
                        {
                            string Query2 = "update um_db.events set Status='" + Verpasst + "' where EID='" + sEID + "' ;";
                            MySqlConnection conDataBase2 = new MySqlConnection(constring);
                            MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2);
                            MySqlDataReader myReader2;

                            //Connection Open
                            conDataBase2.Open();

                            myReader2 = cmdDataBase2.ExecuteReader();

                            //Refresh datagridView
                            load_table_events();

                            //Close Connection
                            conDataBase2.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        //Update events Table, set Status row to Verpasst ***** END *****

                        //Show messagebox that these event has been ignored and updated to "Verpasst"
                        DialogResult result2 = MessageBox.Show("Sie haben den Termin Ignoriert!", "Wichtige Information:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            this.Close();
                        }

                        //Start timer1 again for other Termine
                        timer1.Enabled = true;
                        timer1.Start();
                    }

                //Close Connection
                Main_conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//Check Termine from Database Function END*******************************

        //Clear textboxes after save
        private void ClearTextBoxes(Control.ControlCollection cc)
        {
            foreach (Control ctrl in cc)
            {
                TextBox tb = ctrl as TextBox;
                if (tb != null)
                    tb.Text = "";
                else
                    ClearTextBoxes(ctrl.Controls);
            }

            foreach (Control ctrl in cc)
            {
                RichTextBox tb = ctrl as RichTextBox;
                if (tb != null)
                    tb.Text = "";
                else
                    ClearTextBoxes(ctrl.Controls);
            }
        }

        //Save Termin
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Query6 = "insert into um_db.events (Titel,Start,Ende,Ort,Text)" +
                 "values('" + this.txtTitel.Text + "','" + this.dateTimePicker1.Text + "','" + this.dateTimePicker2.Text + "','" + this.txtOrt.Text + "','" + this.richTextBox1.Text + "') ;";
                MySqlConnection conDataBase6 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase6 = new MySqlCommand(Query6, conDataBase6);
                MySqlDataReader myReader6;

                //Connection Open
                conDataBase6.Open();

                myReader6 = cmdDataBase6.ExecuteReader();
                MessageBox.Show("Termin wurde gespeichert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader6.Read()) { }

                //Refresh datagridview
                load_table_events();

                //Close Connection
                conDataBase6.Close();
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
                //Message string
                string TermineMsg = this.txtTitel.Text + " am " + this.dateTimePicker1.Text + " in " + this.txtOrt.Text;

                try
                {
                    string Query = "insert into um_db.nachrichten (msg,menu,date_time,seen) values('" + TermineMsg + "','" + "Termine" + "','" + DateTimeNow + "','" + "no" + "');";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;
                    //Open Connection
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    while (myReader.Read()) { }
                    //Close Connection
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Termine Speichern Fehler: in Nachrichten eingeben! { ex.Message }");
                }
                //Insert into nachrichten END ******************************************************************

                //Clear textboxes
                ClearTextBoxes(this.Controls);
            }
        }

        //Load Form Termine
        private void Termine_Load(object sender, EventArgs e)
        {            
            //Start Timer
            timer1.Start();

            //Fill datagridview with db rows
            load_table_events();

            //Update Expired Dates function
            check_expired_dates();

            //Stop datagridview self selection at start
            dataGridView1.ClearSelection();

            //Design datagridview columns before starting form
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 40;
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 110;
            
            //Hide this for Termin activations
            if (lblVisible.Text == "Hide")
            {
                this.ShowInTaskbar = false;
                this.ShowIcon = false;
                this.Opacity = 0;
                this.Visible = false;
            }
            else if (lblVisible.Text == "")
            {
                this.ShowInTaskbar = true;
                this.ShowIcon = true;
                this.Opacity = 100;
                this.Visible = true;
            }
        }

        //Show Termine_View FOrm
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Termine_View termine_view = new Termine_View();

                //Load data from datagridview to form Feiertage_Update
                termine_view.txtEID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

                termine_view.txtTitel.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

                termine_view.date1.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();

                termine_view.date2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

                termine_view.txtOrt.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();

                termine_view.richTextBox1.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

                termine_view.lblStatus.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();

                termine_view.ShowDialog();
            }
        }

        //Check and change expired dates START*************************************
        public void check_expired_dates()
        {
            try
            {
                //Select "Seen" rows in database.table "events"
                string Query1 = "select Ende from um_db.events where Status='" + "Laufend" + "' ;";
                MySqlConnection conDataBase1 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase1 = new MySqlCommand(Query1, conDataBase1);
                MySqlDataReader myReader1;

                //Connection Open
                conDataBase1.Open();

                myReader1 = cmdDataBase1.ExecuteReader();

                //check if Old row exist and then update with "Expired"
                if (myReader1.HasRows)
                {
                    while (myReader1.Read())
                    {
                        string dateEnd = myReader1.GetString("Ende");

                        //All Rows named "No"and"Expired" from database events
                        DateTime DateEnd = Convert.ToDateTime(dateEnd); //Musst be standard Format (dd.MM.yyyy 00:00:00) everywhere

                        //Get date and time Now
                        DateTime DateTimeNow = DateTime.Now;
                        DateTime DateNow = Convert.ToDateTime(DateTimeNow); //Musst be standard Format (dd.MM.yyyy 00:00:00) everywhere

                        if (DateEnd < DateNow) //If founded rows "End" are smaller than Today Date
                        {
                            var boxMessage = "Sie haben am " + DateEnd.ToString() + " ein Termin verpasst!";
                            //Show missed events in messageBox
                            //DialogResult result = MessageBox.Show(boxMessage, "Termine verpasst", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            try //Update events Table, set Seen row to Expired ***** START *****
                            {
                                string Query2 = "update um_db.events set Status='" + "Termin verpasst" + "' where Ende='" + dateEnd + "' and Status='" + "Laufend" + "' ;";
                                MySqlConnection conDataBase2 = new MySqlConnection(constring);
                                MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2);
                                MySqlDataReader myReader2;
                                conDataBase2.Open();
                                myReader2 = cmdDataBase2.ExecuteReader();

                                //Refresh datagridview
                                load_table_events();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            } //Update events Table, set Seen row to Expired ***** END *****
                            finally
                            {
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
                                            string Query = "insert into um_db.nachrichten (msg,menu,datetime) values('" + boxMessage + "','" + "Termine" + "','" + DateNow + "');";
                                            MySqlConnection conDataBase = new MySqlConnection(constring);
                                            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                                            MySqlDataReader myReader;
                                            //Open Connection
                                            conDataBase.Open();
                                            myReader = cmdDataBase.ExecuteReader();
                                            while (myReader.Read()) { }
                                            //Close Connection
                                            conDataBase.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show($"Termine msg Verpasst Fehler: in Nachrichten eingeben! { ex.Message }");
                                        }
                                    }
                                    //Close Connection
                                    conDataBase_checkmsg.Close();
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Termine msg Verpasst Fehler: in Nachrichten check!");
                                } //check if msg exist to avoid duplicate end 
                                //Insert into nachrichten END ******************************************************************
                            }
                        }
                    }

                }

                //Close Connection
                conDataBase1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         //Check and change expired dates END*************************************

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.dataGridView1.ClientRectangle, SystemColors.ControlLight, ButtonBorderStyle.Solid);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Termine_Report term_report = new Termine_Report();
            term_report.ShowDialog();
        }

        private void Termine_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }
    }
}