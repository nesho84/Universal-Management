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
using System.Runtime.InteropServices;

namespace Universal_Management
{
    public partial class Rechnungen : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        //First step FOR original windows icons
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
        public Rechnungen()
        {
            InitializeComponent();

            Fill_DropDown_Rechnungen();
        }

        //Second Step FOR original windows icons
        private int nIndex = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Save Rechnungen in DB
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                //Make textbox equal to openfolderdialog path
                tbFilePath.Text = FBD.SelectedPath;

                //string FolderName = Path.GetFileName(tbFilePath.Text);
                var FolderName = new DirectoryInfo(tbFilePath.Text).Name;

                //Then save folder path to db
                //MessageBox.Show(tbFilePath.Text);
                
                try
                {
                    string Query6 = "insert into um_db.rechnungen (Rech_Folder_Path, Rech_Folder_Name) values(@tbFilePath, '" + FolderName + "') ;";
                    MySqlConnection conDataBase6 = new MySqlConnection(constring);
                    //Adding Path to mysql for ex. tbFilePath with slashes*****
                    MySqlCommand cmdDataBase6 = new MySqlCommand(Query6, conDataBase6);
                    cmdDataBase6.Parameters.AddWithValue("@tbFilePath", tbFilePath.Text);
                    MySqlDataReader myReader6;

                    //Connection Open
                    conDataBase6.Open();

                    myReader6 = cmdDataBase6.ExecuteReader();

                    MessageBox.Show("Ordner angelegt.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Refresh Listview2 and DropDown on Rechungen
                    DropDown_Rechnungen.Items.Clear();
                    Fill_DropDown_Rechnungen();
                    listView2.Items.Clear();

                    DropDown_Rechnungen.SelectedItem = FolderName;

                    //Connection Close
                    conDataBase6.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void Fill_DropDown_Rechnungen()
            {
                try
                {
                    string Query = "select * from um_db.rechnungen;";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase.Open();

                    myReader = cmdDataBase.ExecuteReader();
                    while (myReader.Read())
                    {
                        string sRech_Folder_Name = myReader.GetString("Rech_Folder_Name");
                        DropDown_Rechnungen.Items.Add(sRech_Folder_Name);
                    }

                    //Close Connection
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private void DropDown_Rechnungen_SelectedIndexChanged(object sender, EventArgs e)
            {
                //List Rech_Folder_Path from database START************
                try
                {
                    string Query2 = "select * from um_db.rechnungen where Rech_Folder_Name='" + DropDown_Rechnungen.SelectedItem.ToString() + "';";
                    MySqlConnection conDataBase2 = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase2.Open();

                    myReader = cmdDataBase2.ExecuteReader();
                    while (myReader.Read())
                    {
                        //get strings (folderpath from db)
                        string sRech_Folder_Path = myReader.GetString("Rech_Folder_Path");
                        //DropDown_Rechnungen.Text = sRech_Folder_Path;

                        //Folder path from database to public string
                        string DbFolderPath = sRech_Folder_Path;

                        //If directory path from db does not exists
                        if (!(Directory.Exists(DbFolderPath)))
                        {
                            listView2.Items.Clear();
                            listView2.Enabled = false;
                            //MessageBox.Show("Pfad existiert nicht mehr!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            listView2.Enabled = true;
                            if (DropDown_Rechnungen.SelectedIndex != -1)
                            {
                                //Make path textbox equal to db path         
                                tbFilePath.Text = DbFolderPath;

                                //Enable delete button
                                btnLoschen.Enabled = true;

                                //Third Step FOR original windows icons
                                IntPtr hImgSmall; //the handle to the system image list
                                SHFILEINFO shinfo = new SHFILEINFO();

                                listView2.SmallImageList = imageList1;
                                listView2.LargeImageList = imageList1;

                                listView2.Items.Clear();

                                string[] files = Directory.GetFiles(DbFolderPath);
                                string[] dirs = Directory.GetDirectories(DbFolderPath);

                                foreach (string file in files)
                                {
                                    hImgSmall = Win32.SHGetFileInfo(file, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);

                                    //The icon is returned in the hIcon member of the shinfo struct
                                    System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);

                                    imageList1.Images.Add(myIcon);

                                    //Add file name and icon to listview
                                    listView2.Items.Add(Path.GetFileName(file), nIndex++);
                                }
                                foreach (string dir in dirs)
                                {
                                    hImgSmall = Win32.SHGetFileInfo(dir, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);

                                    //The icon is returned in the hIcon member of the shinfo struct
                                    System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);

                                    imageList1.Images.Add(myIcon);

                                    //Add file name and icon to listview
                                    listView2.Items.Add(Path.GetFileName(dir), nIndex++);

                                }
                            }
                        }
                    }

                    //Close Connection
                    conDataBase2.Close();
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message);
                }
            }

            private void Rechnungen_Load(object sender, EventArgs e)
            {
                if (DropDown_Rechnungen.Items.Count > 0)
                {
                    DropDown_Rechnungen.SelectedIndex = 0;
                }
            }
            
            //Delete Folder From DB
            private void button2_Click(object sender, EventArgs e)
            {
                string Selected_Folder_Name = DropDown_Rechnungen.SelectedItem.ToString();

                if (DropDown_Rechnungen.SelectedIndex != -1)
                {
                    try
                    {
                        //Delete Folder from mysql
                        string Query_Delete = "delete from um_db.rechnungen where Rech_Folder_Name='" + Selected_Folder_Name + "'";
                        MySqlConnection conDataBase_Delete = new MySqlConnection(constring);
                        MySqlCommand cmdDataBase_Delete = new MySqlCommand(Query_Delete, conDataBase_Delete);
                        MySqlDataReader myReader_Delete;

                        //Connection Open
                        conDataBase_Delete.Open();

                        myReader_Delete = cmdDataBase_Delete.ExecuteReader();
                        MessageBox.Show("Ordner erfolgreich gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Refresh Listview and DropDown on Rechungen
                        listView2.Items.Clear();
                        DropDown_Rechnungen.Items.Clear();

                        Fill_DropDown_Rechnungen();
                        if (DropDown_Rechnungen.Items.Count > 0)
                        {
                            DropDown_Rechnungen.SelectedIndex = 0;
                        }
                        if (DropDown_Rechnungen.Items.Count == 0)
                        {
                            //Enable delete button
                            btnLoschen.Enabled = false;
                        }

                        //Connection Close
                        conDataBase_Delete.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            
            //Open File
            private void listView2_ItemActivate(object sender, EventArgs e)
            {
                //List Rech_Folder_Path from database START************
                try
                {
                    string Query2 = "select * from um_db.rechnungen where Rech_Folder_Name='" + DropDown_Rechnungen.SelectedItem.ToString() + "';";
                    MySqlConnection conDataBase2 = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2);
                    MySqlDataReader myReader;

                    //Connection Open
                    conDataBase2.Open();

                    myReader = cmdDataBase2.ExecuteReader();
                    while (myReader.Read())
                    {
                        //get strings
                        string sRech_Folder_Path = myReader.GetString("Rech_Folder_Path");
                        //DropDown_Rechnungen.Text = sRech_Folder_Path;

                        //Folder path from database
                        string DbFolderPath = sRech_Folder_Path;

                        if (DropDown_Rechnungen.SelectedIndex != -1)
                        {
                            string listViewName = listView2.SelectedItems[0].Text;

                            //MessageBox.Show(TextBoxFolderPath.Text + "\\" + listViewName);

                            System.Diagnostics.Process.Start(sRech_Folder_Path + "\\" + listViewName);
                        }
                    }

                    //Close Connection
                    conDataBase2.Close();
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message);
                }

            }

    }
}
