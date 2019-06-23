using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Universal_Management
{
    public partial class Dokumente_Add_Folder : Form
    {
        //Refresh Form Dokumente
        Dokumente obj_Dokumente = (Dokumente)Application.OpenForms["Dokumente"];

        public Dokumente_Add_Folder()
        {
            InitializeComponent();
        }

        private void btnDNrSpeichern_Click(object sender, EventArgs e)
        {
            //Validating textBox
            if (TextBoxFolderPath.Text == "")
            {
                TextBoxFolderPath.BackColor = Color.Tomato;
                MessageBox.Show("Feld darf nicht leer sein!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if ((Directory.Exists(obj_Dokumente.tbFilePath.Text + "\\" + TextBoxFolderPath.Text)))
                {
                    MessageBox.Show("Ordner Existiert!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Directory.CreateDirectory(obj_Dokumente.tbFilePath.Text + "\\" + TextBoxFolderPath.Text);

                    // Create an already-existing directory (does nothing).
                    Directory.CreateDirectory(obj_Dokumente.@tbFilePath.Text + "\\" + TextBoxFolderPath.Text);

                    MessageBox.Show("Ordner erstellt.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    obj_Dokumente.listView1.Items.Clear();

                    obj_Dokumente.Fill_listView1();

                    //Select new inserted Folder on listbox
                    obj_Dokumente.listView1.Items[1].Selected = true;

                    this.Close();
                }
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dokumente_Add_Folder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }
    }
}
