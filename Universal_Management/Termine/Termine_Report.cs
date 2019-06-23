using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universal_Management
{
    public partial class Termine_Report : Form
    {
        public Termine_Report()
        {
            InitializeComponent();
        }

        private void Termine_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'um_db_DataSet.einstellungen_firma' table. You can move, or remove it, as needed.
            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);
            // TODO: This line of code loads data into the 'um_db_DataSet.events' table. You can move, or remove it, as needed.
            this.eventsTableAdapter.Fill(this.um_db_DataSet.events);
            // TODO: This line of code loads data into the 'um_db_DataSet.events' table. You can move, or remove it, as needed.
            this.reportViewer1.RefreshReport();
        }

        private void comboJahr_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'um_db_DataSet.einstellungen_firma' table. You can move, or remove it, as needed.
            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);
            // TODO: This line of code loads data into the 'um_db_DataSet.events' table. You can move, or remove it, as needed.
            this.eventsTableAdapter.FillBy_Status(this.um_db_DataSet.events, this.comboStatus.SelectedItem.ToString());
            // TODO: This line of code loads data into the 'um_db_DataSet.events' table. You can move, or remove it, as needed.
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'um_db_DataSet.einstellungen_firma' table. You can move, or remove it, as needed.
            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);
            // TODO: This line of code loads data into the 'um_db_DataSet.events' table. You can move, or remove it, as needed.
            this.eventsTableAdapter.Fill(this.um_db_DataSet.events);
            // TODO: This line of code loads data into the 'um_db_DataSet.events' table. You can move, or remove it, as needed.
            this.reportViewer1.RefreshReport();
        }
    }
}
