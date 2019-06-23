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
    public partial class Dokumente : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public string userSelectedFilePath
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

        //First step for original windows icons
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        }

        public Dokumente()
        {
            InitializeComponent();

            fill_listbox();
        }

        //Second Step FOR original windows icons
        private int nIndex = 0;

        public void listView1_ItemActivate(object sender, EventArgs e)
        {
            string listViewName = listView1.SelectedItems[0].Text;

            //MessageBox.Show(TextBoxFolderPath.Text + "\\" + listViewName);

            System.Diagnostics.Process.Start(ListBoxFolderPath.Text + "\\" + listViewName);
        }

        public void rdoLargeIcon_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
                this.listView1.View = View.LargeIcon;
        }

        public void rdoListIcon_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
                this.listView1.View = View.List;
        }

        private void rdoDetailIcon_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
                this.listView1.View = View.Details;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //add new path
        private void button1_Click(object sender, EventArgs e)
        {
            var dokumente_add_path = new Dokumente_Add_Path();
            dokumente_add_path.ShowDialog();
        }
        public void fill_listbox()
        {
            try
            {
                string Query = "select * from um_db.dokumente;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                //Connection Open
                conDataBase.Open();

                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sDok_Path = myReader.GetString("Dok_Path");

                    if (Directory.Exists(sDok_Path)) 
                    {
                        ListBoxFolderPath.Items.Add(sDok_Path);
                    }
                    else if (!(Directory.Exists(sDok_Path))) 
                    {
                        ListBoxFolderPath.Items.Add(sDok_Path);
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

        public void Fill_listView1()
        {
            if (ListBoxFolderPath.SelectedIndex != -1)
            {
                //Enable buttons
                button3.Enabled = true;
                btnLoad.Enabled = true;
                btnOpenFolder.Enabled = true;


                //Folder path from database
                //string DbFolderPath = ListBoxFolderPath.SelectedItem.ToString();
                tbFilePath.Text = ListBoxFolderPath.SelectedItem.ToString();

                //Third Step FOR original windows icons
                IntPtr hImgSmall; //the handle to the system image list
                SHFILEINFO shinfo = new SHFILEINFO();

                listView1.SmallImageList = imageList1;
                listView1.LargeImageList = imageList1;

                listView1.Items.Clear();

                if (Directory.Exists(tbFilePath.Text))
                {
                    string[]  dirs = Directory.GetDirectories(tbFilePath.Text);
                    string[]  files = Directory.GetFiles(tbFilePath.Text);

                    foreach (string file in files)
                    {
                        hImgSmall = Win32.SHGetFileInfo(file, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);

                        //The icon is returned in the hIcon member of the shinfo struct
                        System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);

                        imageList1.Images.Add(myIcon);

                        //Add file name and icon to listview
                        listView1.Items.Add(Path.GetFileName(file), nIndex++);
                    }
                    foreach (string dir in dirs)
                    {
                        hImgSmall = Win32.SHGetFileInfo(dir, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);

                        //The icon is returned in the hIcon member of the shinfo struct
                        System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);

                        imageList1.Images.Add(myIcon);

                        //Add file name and icon to listview
                        listView1.Items.Add(Path.GetFileName(dir), nIndex++);

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Selected_Path_Name = ListBoxFolderPath.SelectedItem.ToString();

            try
            {
                //Delete paths from mysql with Parameters.AddWithValue
                string Query_Delete = "delete from um_db.dokumente where Dok_Path=@Selected_Path_Name;";
                MySqlConnection conDataBase_Delete = new MySqlConnection(constring);
                MySqlCommand cmdDataBase_Delete = new MySqlCommand(Query_Delete, conDataBase_Delete);
                cmdDataBase_Delete.Parameters.AddWithValue("@Selected_Path_Name", Selected_Path_Name);
                MySqlDataReader myReader_Delete;

                //Connection Open
                conDataBase_Delete.Open();

                myReader_Delete = cmdDataBase_Delete.ExecuteReader();
                MessageBox.Show("Pfad erfolgreich gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListBoxFolderPath.Items.Clear();
                listView1.Items.Clear();

                fill_listbox();

                //Select one item of listTextBox on Form load
                if (ListBoxFolderPath.Items.Count > 0)
                {
                    //Select listbox first item
                    ListBoxFolderPath.SelectedIndex = 0;
                }

                //Disable delete button again
                button3.Enabled = false;
                btnLoad.Enabled = false;
                btnOpenFolder.Enabled = false;

                //Close Connection
                conDataBase_Delete.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string Selected_Path_Name = ListBoxFolderPath.SelectedItem.ToString();

            OpenFileDialog ofd = new OpenFileDialog();

            string PictureFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofd.InitialDirectory = PictureFolder;
            ofd.Title = "Wählen Sie einen Dokument";
            ofd.CustomPlaces.Add(@"C:\");
            ofd.CustomPlaces.Add(@"C:\Program Files\");
            ofd.CustomPlaces.Add(@"K:\Documents\");

            ofd.Multiselect = true;

            ofd.Filter = "*.pdf; *.docx; *.jpg; *.bmp; *.png|*.txt; *.log|All|*.*";

            System.Windows.Forms.DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                //MessageBox.Show(Selected_Path_Name);

                //userSelectedFilePath = ofd.FileName;
                int count = 0;
                string[] FName;
                foreach (string fileName in ofd.FileNames)
                {
                    userSelectedFilePath += fileName + Environment.NewLine;

                    // Copy one file to a location
                    FName = fileName.Split('\\');
                    if (File.Exists(Selected_Path_Name + "\\" + FName[FName.Length - 1]))
                    {
                        MessageBox.Show("Dieses Dokument existiert!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        File.Copy(fileName, Selected_Path_Name + "\\" + FName[FName.Length - 1]);
                        count++;

                        listView1.Items.Clear();

                        Fill_listView1();

                        MessageBox.Show(Convert.ToString(count) + " Datei(n) hochgeladen.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            //Open folder
            string Selected_Path_Name = ListBoxFolderPath.SelectedItem.ToString() + "\\";

            System.Diagnostics.Process.Start(Selected_Path_Name);
        }

        private void ListBoxFolderPath_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!(Directory.Exists(ListBoxFolderPath.SelectedItem.ToString()))) 
            {
                //string DbFolderPath = ListBoxFolderPath.SelectedItem.ToString();
                tbFilePath.Text = ListBoxFolderPath.SelectedItem.ToString();

                listView1.Items.Clear();
                listView1.Enabled = false;
                //MessageBox.Show("Pfad existiert nicht mehr!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Directory.Exists(ListBoxFolderPath.SelectedItem.ToString()))
            {
                Fill_listView1();
                listView1.Enabled = true;
            }
        }

        private void Dokumente_Load(object sender, EventArgs e)
        {            
            //Select one item of listTextBox on Form load
            if (ListBoxFolderPath.Items.Count > 0) 
            {
                //Select listbox first item
                ListBoxFolderPath.SelectedIndex = 0;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Dokumente_Add_Folder dokumente_add_folder = new Dokumente_Add_Folder();
            dokumente_add_folder.ShowDialog();
        }

    }
}
