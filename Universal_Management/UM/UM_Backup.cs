using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using MySql.Data;
using System.IO;

namespace Universal_Management
{
    public partial class UM_Backup : Form
    {
        public UM_Backup()
        {
            InitializeComponent();
        }

        private void BackupDatabase()
        {
            //dateandtime now
            string time = DateTime.Now.ToString("dd-MM-yyyy");

            //sql save path
            string savePath = @txtPath.Text + @"\" + time + "_" + txtFilename.Text + @".sql";
            //zip save path
            string savePath_zip = @txtPath_Zip.Text + @"\" + txtFileZip.Text + @".zip";
            //Mitarbeiter folder save path
            string address_MDoku = (Application.StartupPath) + "\\" + "MDoku";

            //Backup MySQL database
            try
            {
                using (System.Diagnostics.Process mySqlDump = new System.Diagnostics.Process())
                {
                    mySqlDump.StartInfo.FileName = @txtmySqlPath.Text + @"\" + @"mysqldump.exe";
                    mySqlDump.StartInfo.UseShellExecute = false;
                    mySqlDump.StartInfo.Arguments = @"-u" + "root" + " -p" + "123456" + " -h" + "localhost" + " " + "um_db" + " -r \"" + savePath + "\"";
                    mySqlDump.StartInfo.RedirectStandardInput = false;
                    mySqlDump.StartInfo.RedirectStandardOutput = false;
                    mySqlDump.StartInfo.CreateNoWindow = true;
                    mySqlDump.Start();
                    mySqlDump.WaitForExit();
                    mySqlDump.Close();
                }
                //Compress to ZIP file
                if (File.Exists(savePath))
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        if (txtZipPass.TextLength > 0)
                        {
                            zip.Password = txtZipPass.Text;
                        }
                        zip.AddFile(savePath);
                        zip.AddDirectory(address_MDoku);
                        //zip.AddFile("C:\test2.txt");
                        zip.Save(savePath_zip);

                        //Delete file after zipped
                        try
                        {
                            File.Delete(savePath);
                            //MessageBox.Show("File Deleted, Go to " + savePath_zip + " for ziped File!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Datei existiert nicht!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Fehler! \n\n" + ex);
            }

            MessageBox.Show("Fertig. Daten geschpeichert.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnPathBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = FBD.SelectedPath;
            }
        }

        private void btnMysqlPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                @txtmySqlPath.Text = FBD.SelectedPath;
            }
        }

        private void btnPath_Zip_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                @txtPath_Zip.Text = FBD.SelectedPath;
            }
        }

        private void btnStartBackup_Click(object sender, EventArgs e)
        {
            //Validation
            if (txtPath.TextLength == 0)
            {
                this.txtPath.Focus();
                txtPath.BackColor = Color.Tomato;
                return;
            }
            else if (txtFilename.TextLength == 0)
            {
                this.txtFilename.Focus();
                txtFilename.BackColor = Color.Tomato;
                return;
            }
            else if (txtPath_Zip.TextLength == 0)
            {
                this.txtPath_Zip.Focus();
                txtPath_Zip.BackColor = Color.Tomato;
                return;
            }
            else if (txtFileZip.TextLength == 0)
            {
                this.txtFileZip.Focus();
                txtFileZip.BackColor = Color.Tomato;
                return;
            }
            else
            {
                BackupDatabase();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
