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
    public partial class Notizen_Report : Form
    {
        public Notizen_Report()
        {
            InitializeComponent();
        }

        private void Notizen_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'um_db_DataSet.notizen' table. You can move, or remove it, as needed.
            this.notizenTableAdapter.Fill(this.um_db_DataSet.notizen);
            // TODO: This line of code loads data into the 'um_db_DataSet.einstellungen_firma' table. You can move, or remove it, as needed.
            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);
            // TODO: This line of code loads data into the 'Notizen_DataSet.notizen' table. You can move, or remove it, as needed.
            this.reportViewer1.RefreshReport();
        }
    }
}
