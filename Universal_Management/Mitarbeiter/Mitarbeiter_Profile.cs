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
using Microsoft.Reporting.WinForms;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;

namespace Universal_Management
{
    public partial class Mitarbeiter_Profile : Form
    {
        //ConnString
        public string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Now we are going to add this public property for Getting Filepath in Files Tab box
        public string UserSelectedFilePath
        {
            get
            {
                return tbFilePath.Text;
            }
            set
            {
                tbFilePath.Text = value;
            }
        }

        public Mitarbeiter_Profile()
        {
            InitializeComponent();
        }

        //Load Urlaube Table for This Mitarbeiter
        DataTable Urlaube_dbdataset;

        public void Load_table_Urlaube()
        {
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select URLID, DN_Nr as DNr, CONCAT(Arbeitstage_von, ' bis ', Arbeitstage_bis) Datum, Anzahl_Tage as Anzah_Tage, Type as Typ, Konsumiert from um_db.urlaube where DN_Nr='" + this.textBoxDNr.Text + "' order by Arbeitstage_von ASC;", conDataBase);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                Urlaube_dbdataset = new DataTable();
                sda.Fill(Urlaube_dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = Urlaube_dbdataset;
                Urlaube_dataGridView.DataSource = bSource;
                sda.Update(Urlaube_dbdataset);

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Count datagridView rows
            if (Urlaube_dataGridView.Rows.Count == 0)
            {
                lblCheckRowsUrlaube.Visible = true;
            }
        }

        //Load Kranken.Table for This Mitarbeiter
        DataTable Krankendstand_dbdataset;
        public void load_table_Krankenstand()
        {
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select KID, M_DNr as DNr, K_von as Von, K_bis as Bis, K_anzahl_tage as AnzahTage from um_db.krankenstand where M_DNr='" + this.textBoxDNr.Text + "' order by K_von ASC;", conDataBase);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                Krankendstand_dbdataset = new DataTable();
                sda.Fill(Krankendstand_dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = Krankendstand_dbdataset;
                dataGridView_Krank.DataSource = bSource;
                sda.Update(Krankendstand_dbdataset);

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Count datagridView rows
            if (dataGridView_Krank.Rows.Count == 0)
            {
                lblCheckRows.Visible = true;
            }
            //Count datagridView rows
            else if (dataGridView_Krank.Rows.Count > 0)
            {
                lblCheckRows.Visible = false;
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            string PictureFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofd.InitialDirectory = PictureFolder;
            ofd.Title = "Pick a picture; any picture";
            ofd.CustomPlaces.Add(@"C:\");
            ofd.CustomPlaces.Add(@"C:\Program Files\");
            ofd.CustomPlaces.Add(@"K:\Documents\Pictures\");

            ofd.Multiselect = true;

            ofd.Filter = "Dokumente|*.pdf; *.docx; *.jpg; *.bmp; *.png|Documents|*.txt; *.log|All|*.*";

            System.Windows.Forms.DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                //userSelectedFilePath = ofd.FileName;
                int count = 0;
                string[] FName;
                foreach (string fileName in ofd.FileNames)
                {
                    UserSelectedFilePath += fileName + Environment.NewLine;

                    // Copy one file to a location
                    FName = fileName.Split('\\');
                    if (File.Exists(@"MDoku" + "\\" + textBoxDNr.Text + "\\" + FName[FName.Length - 1]))
                    {
                        MessageBox.Show("Dieses Dokument existiert!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        File.Copy(fileName, @"MDoku" + "\\" + textBoxDNr.Text + "\\" + FName[FName.Length - 1]);
                        count++;
                    }
                }
                MessageBox.Show(Convert.ToString(count) + " File(s) kopiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Refresh fileList
                listView2.Items.Clear();

                ExtractAssociatedIconEx();
            }
        }

        void FolderExists() //If folder Exists
        {
            txtMitarbeiter.Text = textBoxDNr.Text;

            string path = @"MDoku" + "\\" + textBoxDNr.Text + "\\";
            if (Directory.Exists(path))
            {
                btnCreate.Enabled = false;
                btnCreate.Text = "   Ordner erstellt";

                btnOpenFolder.Enabled = true;
                btnLoad.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void get_image()
        {
            try
            {
                string Query = "select * from um_db.mitarbeiter where MITID='" + this.lblMID.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    //Getting Image from database
                    byte[] imgg = (byte[])(myReader["bild"]);
                    if (imgg == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
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

        //Listing Files from Selected Directory
        public void ExtractAssociatedIconEx()
        {
            // Get the c:\ directory.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"MDoku" + "\\" + textBoxDNr.Text);

            ListViewItem item;
            listView2.BeginUpdate();

            // For each file in the c:\ directory, create a ListViewItem 
            // and set the icon to the icon extracted from the file. 
            foreach (System.IO.FileInfo file in dir.GetFiles())
            {
                // Set a default icon for the file.
                Icon iconForFile = SystemIcons.WinLogo;

                item = new ListViewItem(file.Name, 1);
                iconForFile = Icon.ExtractAssociatedIcon(file.FullName);

                // Check to see if the image collection contains an image 
                // for this extension, using the extension as a key. 
                if (!imageList2.Images.ContainsKey(file.Extension))
                {
                    // If not, add the image to the image list.
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName);
                    imageList2.Images.Add(file.Extension, iconForFile);
                }
                item.ImageKey = file.Extension;
                listView2.Items.Add(item);
            }
            listView2.EndUpdate();
        }

        private void Mitarbeiter_Profile_Load(object sender, EventArgs e)
        {
            //If folder Existst Function
            FolderExists();

            //fill comboBox_lei
            fill_combobox_lei();

            try
            {
                //Get Mitarbeiter Data from Database
                string Query = "select * from um_db.mitarbeiter where MITID='" + this.lblMID.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sM_DNr = myReader.GetString("M_DNr");
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
                    string sE = myReader.GetString("M_Eintritt");
                    string sB = myReader.GetString("M_Besch_als");
                    string sBG = myReader.GetString("M_Gehalt");
                    string sSTP = myReader.GetString("Staplerschein");
                    string sAV = myReader.GetString("Arb_im_Ausmass");
                    string sMS = myReader.GetString("M_RegStunden");
                    string sL = myReader.GetString("M_Leiarbeiter");
                    string sF = myReader.GetString("Fuhrerschein");
                    string sPV = myReader.GetString("PKW_zu_Verfugung");
                    string sFK = myReader.GetString("M_Fahrkosten");
                    string sSA = myReader.GetString("Anmerkugen");

                    textBoxDNr.Text = sM_DNr;
                    txtMS.Text = sMS;
                    lblAG.Text = sAG;
                    lblFM.Text = sFamilienname;
                    lblVV.Text = sVorname;
                    lblGE.Text = sGeschlecht;
                    lblGD.Text = sGDatum;
                    lblTN.Text = sTel;
                    lblPLZ.Text = sPLZ;
                    lblFS.Text = sFS;
                    lblST.Text = sST;
                    lblEM.Text = sEM;
                    lblSV.Text = sSV;
                    lblA.Text = sA;
                    lblS.Text = sS;
                    //lblE.Text = sE;
                    if (sE == "leer")
                    {
                        string nowDateSE = DateTime.Now.ToString("yyyy-MM-dd");
                        lblEintritt.Text = nowDateSE;
                    }
                    if (!(sE == "leer"))
                    {
                        lblEintritt.Text = sE;
                    }

                    lblB.Text = sB;
                    lblBG.Text = sBG;
                    lblSTP.Text = sSTP;
                    lblAV.Text = sAV;
                    //leiarbeiter
                    lblL.Text = sL;
                    comboBox_lei.SelectedItem = lblL.Text;

                    lblF.Text = sF;
                    lblPV.Text = sPV;
                    lblFK.Text = sFK;
                    lblSA.Text = sSA;

                    txtTitel.Text = lblAG.Text;
                    txtFamilienname.Text = lblFM.Text;
                    txtVorname.Text = lblVV.Text;
                    txtGeschlecht.Text = lblGE.Text;
                    txtGebDatum.Text = lblGD.Text;
                    txtTel.Text = lblTN.Text;
                    txtPLZ.Text = lblPLZ.Text;
                    txtFamStand.Text = lblFS.Text;
                    txtStrasse.Text = lblST.Text;
                    txtEmail.Text = lblEM.Text;
                    txtSV.Text = lblSV.Text;
                    txtArbErlaubnis.Text = lblA.Text;
                    txtStaatBurg.Text = lblS.Text;
                    txtEintritt.Text = lblEintritt.Text;
                    txtBeschaftigt.Text = lblB.Text;
                    txtBrutto.Text = lblBG.Text;
                    txtStapler.Text = lblSTP.Text;
                    txtArbeitsverhaltnis.Text = lblAV.Text;
                    comboBox_lei.SelectedItem = lblL.Text;
                    txtFuhrerschein.Text = lblF.Text;
                    txtPKW.Text = lblPV.Text;
                    txtFahrkosten.Text = lblFK.Text;
                    //textBox23.Text = textBox23.Text;
                    txtRichTextBox_Sonstige.Text = lblSA.Text;
                    lblSA.Visible = false;
                }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
            //Get Image from function get_image()
            get_image();

            //Load Urlaube Table
            Load_table_Urlaube();
            //Load Krank. Table
            load_table_Krankenstand();

            //
            //*************Eintritt Calculator START*****************************
            //
            try
            {
                txtEintritt_for_Calc.Text = lblEintritt.Text;
                //String date for txtGBDatum
                string nowDate = DateTime.Now.ToString("yyyy-MM-dd");
                txtHeute.Text = nowDate;

                //date diference
                DateTime dt1 = Convert.ToDateTime(txtEintritt_for_Calc.Text);

                DateTime dt2 = Convert.ToDateTime(txtHeute.Text);

                //Initializing object and then calling constructor

                CalculateDateDifference dateDiff = new CalculateDateDifference(dt1, dt2);

                int totalMonths = dateDiff.Months;

                int totalDays = dateDiff.Days;

                int totalYears = dateDiff.Years;

                lblResult1.Text = totalYears.ToString() + " Jahre";
                lblResult2.Text = totalMonths.ToString() + " Monate";
                lblResult3.Text = totalDays.ToString() + " Tage";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //
            //*************Eintritt Calculator END*****************************
            //
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

        private void btnBearbeiten_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnBearbeiten.Visible = false;
            btnDelete.Visible = false;
            btnPrint.Visible = false;

            txtTitel.Enabled = true;
            txtFamilienname.Enabled = true;
            txtVorname.Enabled = true;
            txtGeschlecht.Enabled = true;
            txtGebDatum.Enabled = true;
            txtTel.Enabled = true;
            txtPLZ.Enabled = true;
            txtFamStand.Enabled = true;
            txtStrasse.Enabled = true;
            txtEmail.Enabled = true;
            txtSV.Enabled = true;
            txtArbErlaubnis.Enabled = true;
            txtStaatBurg.Enabled = true;
            txtEintritt.Enabled = true;
            txtBeschaftigt.Enabled = true;
            txtBrutto.Enabled = true;
            txtStapler.Enabled = true;
            txtArbeitsverhaltnis.Enabled = true;
            comboBox_lei.Enabled = true;
            txtFuhrerschein.Enabled = true;
            txtPKW.Enabled = true;
            txtFahrkosten.Enabled = true;
            txtMS.Enabled = true;
            txtEintritt.Enabled = true;
            txtRichTextBox_Sonstige.Enabled = true;
            txtRichTextBox_Sonstige.ReadOnly = false;
            lblL.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e) //Delete Mitarbeiter
        {
            if (MessageBox.Show("Sind Sie sicher?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string Query = "delete from um_db.mitarbeiter where M_DNr='" + textBoxDNr.Text + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Mitarbeiter wurde erfolgreich gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Close Connection
                    conDataBase.Close();

                    //Delete the Mitarbeiter Dokument Folder
                    //Application Path
                    string address_MDoku = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "MDoku");
                    string path = address_MDoku + "\\" + textBoxDNr.Text;
                    DeleteDirectory(path);

                //Delete Urlaube START
                try
                {
                    string Query_url = "delete from um_db.urlaube where DN_Nr='" + textBoxDNr.Text + "' ;";
                    MySqlConnection conDataBase_url = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase_url = new MySqlCommand(Query_url, conDataBase_url);
                    MySqlDataReader myReader_url;

                    conDataBase_url.Open();
                    myReader_url = cmdDataBase_url.ExecuteReader();
                    while (myReader_url.Read()) { }
                    conDataBase_url.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //Delete Urlaube END

                //Delete Krankenstand START
                try
                {
                    string Query_krk = "delete from um_db.krankenstand where M_DNr='" + textBoxDNr.Text + "' ;";
                    MySqlConnection conDataBase_krk = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase_krk = new MySqlCommand(Query_krk, conDataBase_krk);
                    MySqlDataReader myReader_krk;

                    conDataBase_krk.Open();
                    myReader_krk = cmdDataBase_krk.ExecuteReader();
                    while (myReader_krk.Read()) { }
                    conDataBase_krk.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //Delete Krankenstand END

                //Delete Stundenliste_monat START
                try
                {
                    string Query_stdm = "delete from um_db.stundenliste_monat where DNr='" + textBoxDNr.Text + "' ;";
                    MySqlConnection conDataBase_stdm = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase_stdm = new MySqlCommand(Query_stdm, conDataBase_stdm);
                    MySqlDataReader myReader_stdm;

                    conDataBase_stdm.Open();
                    myReader_stdm = cmdDataBase_stdm.ExecuteReader();
                    while (myReader_stdm.Read()) { }
                    conDataBase_stdm.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //Delete Stundenliste_monat END

                //Delete Stundenliste_konto START
                try
                {
                    string Query_stdk = "delete from um_db.stundenliste_konto where DNr='" + textBoxDNr.Text + "' ;";
                    MySqlConnection conDataBase_stdk = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase_stdk = new MySqlCommand(Query_stdk, conDataBase_stdk);
                    MySqlDataReader myReader_stdk;

                    conDataBase_stdk.Open();
                    myReader_stdk = cmdDataBase_stdk.ExecuteReader();
                    while (myReader_stdk.Read()) { }
                    conDataBase_stdk.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //Delete Stundenliste_konto END

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

        private void button2_Click(object sender, EventArgs e) //Button to load Image
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|GIF Files(*.gif)|*.gif";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                txtImagePath.Text = picPath;
                //Bildauswahl Tab
                pictureBox1.ImageLocation = picPath;

                lblBildAndern.Visible = false;
                lblBildSpeichern.Visible = true;

                pictureBox1.BorderStyle = BorderStyle.Fixed3D;

                lblBildSpeichern.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Save in MySQL
            //Getting Image content and ImagePath to store in database
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.txtImagePath.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            try
            {
                string Query = "update um_db.mitarbeiter set bild = @IMG where M_DNr='" + this.textBoxDNr.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Die Daten wurden aktualisiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBox1.BorderStyle = BorderStyle.None;

                while (myReader.Read()) { }

                //Close Connection
                conDataBase.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bild zu groß oder falsche Format ausgewählt,.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                lblBildSpeichern.Visible = false;
                lblBildAndern.Visible = true;
            }
        }

        private void btnUrlaube_Click(object sender, EventArgs e) //Open Urlaube Form
        {
            var M_Urlaube = new Urlaube();

            this.Hide();

            M_Urlaube.ShowDialog();
        }

        //Button to create folder if not exists
        private void btnCreate_Click(object sender, EventArgs e) //Create Folder
        {
            //Create Mitarbeiter folder after DNr is created start
            try
            {
                // Create new folder in "C:\ volume or in this case our app Debug folder.
                Directory.CreateDirectory("MDoku" + "\\" + this.textBoxDNr.Value);
                // Create an already-existing directory (does nothing).
                Directory.CreateDirectory(@"MDoku" + "\\" + this.textBoxDNr.Value);
                MessageBox.Show("Ordner erstellt.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Release buttons and disable this button
                btnLoad.Enabled = true;
                btnOpenFolder.Enabled = true;
                btnDeleteFolder.Enabled = true;
                btnCreate.Enabled = false;
            }
            //Create Mitarbeiter folder after DNr is created end
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            //Open folder
            System.Diagnostics.Process.Start(@"MDoku" + "\\" + txtMitarbeiter.Text);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) //List files when tabPage is selected
        {
            //If tabPage3 Selected or Ende tab clicked
            if (tabControl1.SelectedTab == tabPage3)
            {
                //Refresh fileList
                listView2.Items.Clear();

                //This DNr
                txtMitarbeiter.Text = textBoxDNr.Text;

                //If directory exists then list files if not Enable button Create Folder
                string path = @"MDoku" + "\\" + textBoxDNr.Text + "\\";
                if (Directory.Exists(path))
                {
                    btnCreate.Enabled = false;
                    btnCreate.Text = "   Ordner erstellt";

                    btnOpenFolder.Enabled = true;
                    btnLoad.Enabled = true;
                    btnDeleteFolder.Enabled = true;

                    ExtractAssociatedIconEx();
                }
                if (!(Directory.Exists(path)))
                {
                    btnCreate.Enabled = true;
                    btnCreate.Text = "   Ordner erstellen";

                    btnOpenFolder.Enabled = false;
                    btnLoad.Enabled = false;
                    btnDeleteFolder.Enabled = false;
                }
                if (textBoxDNr.Text == "")
                {
                    btnCreate.Enabled = true;
                    btnCreate.Text = "   Ordner erstellen";

                    btnOpenFolder.Enabled = false;
                    btnLoad.Enabled = false;
                    btnDeleteFolder.Enabled = false;
                }

            }

            //If tabPage4 Selected or Ende tab clicked //Mitarbeiter check status
            if (tabControl1.SelectedTab == tabPage4)
            {
                try
                {
                    string Query = "select status from um_db.mitarbeiter where MITID='" + this.lblMID.Text + "' ;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();

                    while (myReader.Read())
                    {
                        string sMStatus = myReader.GetString("status");

                        if (sMStatus == "aktiv")
                        {
                            btnKrank.Enabled = false;
                            btnUrlaub.Enabled = false;
                        }
                        if (sMStatus == "urlaub")
                        {
                            btnAktiv.Enabled = false;
                            btnKrank.Enabled = false;
                        }
                        if (sMStatus == "krank")
                        {
                            btnAktiv.Enabled = false;
                            btnUrlaub.Enabled = false;
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
        }

        //open file with doubleclick
        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 1)
            {
                DirectoryInfo dir = new DirectoryInfo(@"MDoku" + "\\" + textBoxDNr.Text);

                //MessageBox.Show(listView2.SelectedItems[0].Text);
                System.Diagnostics.Process.Start(dir + "\\" + listView2.SelectedItems[0].Text);
            } 
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 1)
            {
                DirectoryInfo dir = new DirectoryInfo(@"MDoku" + "\\" + textBoxDNr.Text);

                //MessageBox.Show(listView2.SelectedItems[0].Text);
                System.Diagnostics.Process.Start(dir + "\\" + listView2.SelectedItems[0].Text);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Sind Sie sicher (" + listView2.SelectedItems[0].Text + ") zu Löschen?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DirectoryInfo dir = new DirectoryInfo(@"MDoku" + "\\" + textBoxDNr.Text);

                    //MessageBox.Show(listView2.SelectedItems[0].Text);
                    File.Delete(dir + "\\" + listView2.SelectedItems[0].Text);

                    //Refresh fileList
                    listView2.Items.Clear();

                    ExtractAssociatedIconEx();
                }
            }
        }

        //Update Mitarbeiter
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if masked textbox is not completed
            if (!(txtEintritt.MaskCompleted))
            {
                this.txtEintritt.Focus();
                MessageBox.Show("Bitte Eintrittsdatum eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if datetime is not corect
            //DateTime value;
            DateTime value;
            if (!DateTime.TryParse(txtEintritt.Text, out value))
            {
                //txtEintritt.Text = DateTime.Today.ToShortDateString();
                this.txtEintritt.Focus();
                MessageBox.Show("Bitte Eintrittsdatum korrekt eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if masked textbox is not completed
            if (!(txtGebDatum.MaskCompleted))
            {
                this.txtGebDatum.Focus();
                MessageBox.Show("Bitte Geburtsdatum eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if datetime is not corect
            //DateTime value;
            DateTime value2;
            if (!DateTime.TryParse(txtGebDatum.Text, out value2))
            {
                //txtEintritt.Text = DateTime.Today.ToShortDateString();
                this.txtGebDatum.Focus();
                MessageBox.Show("Bitte Geburtsdatum korrekt eingeben!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else //Save changes to db
            {
                //to string to avoid errors
                string comboBox_lei_to_string;
                if (comboBox_lei.SelectedIndex == -1)
                {
                    comboBox_lei_to_string = null;
                }
                else
                {
                    comboBox_lei_to_string = comboBox_lei.SelectedItem.ToString();
                }

                try
                {
                    string Query = "update um_db.mitarbeiter set Titel='" + this.txtTitel.Text + "', Familienname='" + this.txtFamilienname.Text + "', Vorname='" + this.txtVorname.Text + "', Geschlecht='" + this.txtGeschlecht.Text + "', G_Datum='" + this.txtGebDatum.Text + "', Tel='" + this.txtTel.Text + "', Plz_Ort='" + this.txtPLZ.Text + "', Familienstand='" + this.txtFamStand.Text + "', Strasse='" + this.txtStrasse.Text + "', Email='" + this.txtEmail.Text + "', SV_Nummer='" + this.txtSV.Text + "', Erlaubnis='" + this.txtArbErlaubnis.Text + "', StaatBurg_='" + this.txtStaatBurg.Text + "', M_Eintritt='" + this.txtEintritt.Text + "', M_Besch_als='" + this.txtBeschaftigt.Text + "', M_Gehalt='" + this.txtBrutto.Text + "', Staplerschein='" + this.txtStapler.Text + "', Arb_im_Ausmass='" + this.txtArbeitsverhaltnis.Text + "', M_RegStunden='" + this.txtMS.Text + "', M_Leiarbeiter='" + comboBox_lei_to_string + "', Fuhrerschein='" + this.txtFuhrerschein.Text + "', PKW_zu_Verfugung='" + this.txtPKW.Text + "', M_Fahrkosten='" + this.txtFahrkosten.Text + "', Anmerkugen='" + this.txtRichTextBox_Sonstige.Text + "' where MITID='" + this.lblMID.Text + "';";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Die Daten wurden Aktualisiert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read()) { }

                    //Connection Close
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //Return Form in Previous State
                    btnSave.Visible = false;
                    btnBearbeiten.Visible = true;
                    btnDelete.Visible = true;
                    btnPrint.Visible = true;

                    txtTitel.Enabled = false;
                    txtFamilienname.Enabled = false;
                    txtVorname.Enabled = false;
                    txtGeschlecht.Enabled = false;
                    txtGebDatum.Enabled = false;
                    txtTel.Enabled = false;
                    txtPLZ.Enabled = false;
                    txtFamStand.Enabled = false;
                    txtStrasse.Enabled = false;
                    txtEmail.Enabled = false;
                    txtSV.Enabled = false;
                    txtArbErlaubnis.Enabled = false;
                    txtStaatBurg.Enabled = false;
                    txtEintritt.Enabled = false;
                    txtBeschaftigt.Enabled = false;
                    txtBrutto.Enabled = false;
                    txtStapler.Enabled = false;
                    txtArbeitsverhaltnis.Enabled = false;
                    comboBox_lei.Enabled = false;
                    txtFuhrerschein.Enabled = false;
                    txtPKW.Enabled = false;
                    txtFahrkosten.Enabled = false;
                    textBoxDNr.Enabled = false;
                    txtMS.Enabled = false;
                    txtRichTextBox_Sonstige.Enabled = false;
                    txtRichTextBox_Sonstige.ReadOnly = false;

                    //
                    //*************Eintritt Calculator START*****************************
                    //
                    try
                    {
                        //for date calculation
                        txtEintritt_for_Calc.Text = txtEintritt.Text;
                        //String date for txtGBDatum
                        string nowDate = DateTime.Now.ToString("yyyy-MM-dd");
                        txtHeute.Text = nowDate;

                        //date diference
                        DateTime dt1 = Convert.ToDateTime(txtEintritt_for_Calc.Text);

                        DateTime dt2 = Convert.ToDateTime(txtHeute.Text);

                        //Initializing object and then calling constructor

                        CalculateDateDifference dateDiff = new CalculateDateDifference(dt1, dt2);

                        int totalMonths = dateDiff.Months;

                        int totalDays = dateDiff.Days;

                        int totalYears = dateDiff.Years;

                        lblResult1.Text = totalYears.ToString() + " Jahre";
                        lblResult2.Text = totalMonths.ToString() + " Monate";
                        lblResult3.Text = totalDays.ToString() + " Tage";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //
                    //*************Eintritt Calculator END*****************************
                    //

                    //Insert into nachrichten START **************************************************************
                    //Get date and time Now
                    DateTime DateTimeNow = DateTime.Now;
                    //Message String
                    string NeueMitMsg = "Mitarbeiter mit DNr (" + textBoxDNr.Value + ") wurde Aktualisiert.";
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
                        MessageBox.Show("Termine Speichern Fehler: in Nachrichten eingeben!");
                    }
                    //Insert into nachrichten END ******************************************************************
                }
            }
        }

        //Delete Folder and Files Function
        private void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                //Delete all files from the Directory
                foreach (string file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }
                //Delete all child Directories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    DeleteDirectory(directory);
                }
                //Delete a Directory
                Directory.Delete(path);

                //MessageBox.Show("Ordner und Dateien gelöscht");

                tbFilePath.Clear();
                listView2.Items.Clear();

                btnCreate.Enabled = true;
                btnCreate.Text = "   Ordner erstellen";
                btnOpenFolder.Enabled = false;
                btnLoad.Enabled = false;
                btnDeleteFolder.Enabled = false;
            }
        }

        //Delete all files in mitarbeiter folder
        private void ClearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.IsReadOnly = false;
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                di.Delete();
            }
        }

        //Delete Folder and Files Button
        private void btnDeleteFolder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sind Sie sicher Dateien und Ordner von DNR (" + lblM_DNr.Text + ") zu Löschen?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ////Delete the Mitarbeiter Dokument Folder
                //string path = @"MDoku" + "\\" + textBoxDNr.Text;
                //DeleteDirectory(path);

                ClearFolder(@"MDoku" + "\\" + textBoxDNr.Text);

                //Refresh fileList
                listView2.Items.Clear();

                ExtractAssociatedIconEx();
            }
        }

        private void btnUpdateDNr_Click(object sender, EventArgs e)
        {
            //var Mit_DNr_Update = new Mitarbeiter_DNr_Update();

            //Mit_DNr_Update.numeric_DNr.Value = textBoxDNr.Value;
            //Mit_DNr_Update.lblMITID.Text = lblMID.Text;

            //Mit_DNr_Update.ShowDialog();
        }

        //click image button for edit Krankendstand
        private void dataGridView_Krank_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //code here
        }

        //SV Nummer Validation
        private void textBox11_Validating(object sender, CancelEventArgs e)
        {
            //Validation
            if (txtSV.Text == "")
            {
                e.Cancel = true;

                txtSV.BackColor = Color.Tomato;
            }
        }
        //SV Nummer Validation
        private void textBox11_Validated(object sender, EventArgs e)
        {
            //Changing validation textboxes background
            txtSV.BackColor = SystemColors.Menu;
        }
        //SV Nummer Validation
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txtSV.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }     
        }
        //Email Validation
        private void textBox10_Validating(object sender, CancelEventArgs e)
        {
            //Email validation with Regex
            Regex RX = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (!RX.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Falsche Email Adresse.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Cancel = true;

                txtEmail.BackColor = Color.Tomato;
            }
        }
        //Email Validation
        private void textBox10_Validated(object sender, EventArgs e)
        {
            //Changing validation textboxes background
            txtEmail.BackColor = SystemColors.Menu;
        }
        //Tel Validation
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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
        //Tel Validation
        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            //Validation
            if (txtTel.Text == "")
            {
                e.Cancel = true;

                txtTel.BackColor = Color.Tomato;
            }
        }
        //Tel Validation
        private void textBox6_Validated(object sender, EventArgs e)
        {
            //Changing validation textboxes background
            txtTel.BackColor = SystemColors.Menu;
        }
        //Geburtsdatum Validation
        //String date for txtGBDatum
        string nowDate = DateTime.Now.ToString("yyyy-MM-dd");    
        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (txtGebDatum.Text == nowDate)
            {
                MessageBox.Show("Geburtsdatum ändern!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //txtGDatum.BackColor = Color.Tomato;

                e.Cancel = true;
            }

            //Validation
            if (txtGebDatum.Text == "")
            {
                e.Cancel = true;

                txtGebDatum.BackColor = Color.Tomato;
            }
        }
        //Geburtsdatum Validation
        private void textBox5_Validated(object sender, EventArgs e)
        {
            //Changing validation textboxes background
            txtGebDatum.BackColor = SystemColors.Menu;
        }

        //Familienname, Vorname, Geschlecht, PLZ, Strasse, Familienstand Validation
        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).BackColor = Color.Tomato;
                e.Cancel = true;
            }
        }
        //Familienname, Vorname, Geschlecht, PLZ, Strasse, Familienstand Validated
        private void textBox2_Validated(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = SystemColors.Menu;
        }

        //Brutto Gehalt Validation
        private void textBox16_Validating(object sender, CancelEventArgs e)
        {
            if (txtBrutto.Text == "")
            {
                e.Cancel = true;

                txtBrutto.BackColor = Color.Tomato;
            }
        }
        //BruttoGehalt Validation
        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txtBrutto.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtMS.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Mitarbeiter_Profile_Report mit_report = new Mitarbeiter_Profile_Report();

            mit_report.lblDNr.Text = this.textBoxDNr.Value.ToString();

            mit_report.ShowDialog();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtEintritt_TextChanged_1(object sender, EventArgs e)
        {
            //for date calculation
            txtEintritt_for_Calc.Text = txtEintritt.Text;
        }

        private void Mitarbeiter_Profile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Mitarbeiter mit = new Mitarbeiter();

            this.Hide();

            mit.ShowDialog();
        }

        //Open krankendstand Update
        private void dataGridView_Krank_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView_Krank.SelectedRows.Count > 0)
            {
                Mitarbeiter_Krankenstand_Update M_Krank_Update = new Mitarbeiter_Krankenstand_Update();

                //Post data to Datagridview on Form MitarbeiterKrankendstand_Update
                M_Krank_Update.lblMITID.Text = this.dataGridView_Krank.CurrentRow.Cells[0].Value.ToString();
                M_Krank_Update.txtDNNr.Text = this.dataGridView_Krank.CurrentRow.Cells[1].Value.ToString();
                //M_Krank_Update.dateTimePicker_von.Text = this.dataGridView_Krank.CurrentRow.Cells[4].Value.ToString();
                //M_Krank_Update.dateTimePicker_bis.Text = this.dataGridView_Krank.CurrentRow.Cells[5].Value.ToString();
                //M_Krank_Update.txtAnzahlTage.Text = this.dataGridView_Krank.CurrentRow.Cells[6].Value.ToString();

                M_Krank_Update.ShowDialog();
            }
        }

    }
}