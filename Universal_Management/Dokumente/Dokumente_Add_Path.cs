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
using System.Runtime.InteropServices;

namespace Universal_Management
{
    public partial class Dokumente_Add_Path : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //Refresh listbox on Form Dokuemente
        Dokumente obj_dokumente = (Dokumente)Application.OpenForms["Dokumente"];

        public Dokumente_Add_Path()
        {
            InitializeComponent();
        }

        private void ButtonFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                TextBoxFolderPath.Text = FBD.SelectedPath;
            }
        }

        //Folder path save
        private void btnDNrSpeichern_Click(object sender, EventArgs e)
        {
            //Validating textBox
            if (TextBoxFolderPath.TextLength == 0)
            {
                MessageBox.Show("Dieser Pfad ist ungültig!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.TextBoxFolderPath.Focus();
                TextBoxFolderPath.BackColor = Color.Tomato;
                return;
            }
            else
            {
                try
                {
                    string Query6 = "insert into um_db.dokumente (Dok_Path) values(@TextBoxFolderPath) ;";
                    MySqlConnection conDataBase6 = new MySqlConnection(constring);
                    //Adding Path to mysql for ex. TextBoxFolderPath with slashes*****
                    MySqlCommand cmdDataBase6 = new MySqlCommand(Query6, conDataBase6);
                    cmdDataBase6.Parameters.AddWithValue("@TextBoxFolderPath", TextBoxFolderPath.Text);
                    MySqlDataReader myReader6;

                    //Connection Open
                    conDataBase6.Open();

                    myReader6 = cmdDataBase6.ExecuteReader();
                    MessageBox.Show("Ordner Pfad gespeichert.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Refresh ListBox on Dokumente form
                    obj_dokumente.ListBoxFolderPath.Items.Clear();
                    obj_dokumente.fill_listbox();
                    //Refresh listView1 on Dokumente form
                    obj_dokumente.listView1.Items.Clear();

                    //Select new inserted Path on listbox
                    obj_dokumente.ListBoxFolderPath.SelectedItem = TextBoxFolderPath.Text;

                    //Connection Close
                    conDataBase6.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
