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
    public partial class Urlaube_Report : Form
    {
        //ConnString
        string constring = "datasource=localhost;port=3306;username=root;password=123456";

        public Urlaube_Report()
        {
            InitializeComponent();

            FillcomboDNr();
        }

        private void Urlaube_Report_Load(object sender, EventArgs e)
        {
            //Convert Kontostand textbox to integer
            int intDNr;
            intDNr = Convert.ToInt32(comboDNr.SelectedItem.ToString());
            intDNr = int.Parse(comboDNr.SelectedItem.ToString());

            // TODO: This line of code loads data into the 'um_db_DataSet.urlaube' table. You can move, or remove it, as needed.
            this.urlaubeTableAdapter.FillBy_DNr(this.um_db_DataSet.urlaube, intDNr);
            // TODO: This line of code loads data into the 'um_db_DataSet.einstellungen_firma' table. You can move, or remove it, as needed.
            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);

            this.reportViewer1.RefreshReport();
        }

        //Fill combobox with db rows
        void FillcomboDNr()
        {
            string Query = "select * from um_db.mitarbeiter where status<>'" + "passiv" + "' and M_DNr<>'" + "0" + "' ORDER BY M_DNr ASC;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sDNr = myReader.GetString("M_DNr");
                    //string sAdress = myReader.GetString("Adress");
                    //comboBox1.Items.Add(sName+" "+sAdress);
                    comboDNr.Items.Add(sDNr);

                    comboDNr.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboDNr_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Convert Kontostand textbox to integer
            int intDNr;
            intDNr = Convert.ToInt32(comboDNr.SelectedItem.ToString());
            intDNr = int.Parse(comboDNr.SelectedItem.ToString());

            // TODO: This line of code loads data into the 'um_db_DataSet.urlaube' table. You can move, or remove it, as needed.
            this.urlaubeTableAdapter.FillBy_DNr(this.um_db_DataSet.urlaube, intDNr);
            // TODO: This line of code loads data into the 'um_db_DataSet.einstellungen_firma' table. You can move, or remove it, as needed.
            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);

            this.reportViewer1.RefreshReport();
        }
    }
}
