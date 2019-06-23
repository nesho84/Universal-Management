using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Universal_Management
{
    public partial class Urlaube_Report_New : Form
    {
        //take DNr from Urlaube_Add Form
        Urlaube_Add obj_Urlaube_Add = (Urlaube_Add)Application.OpenForms["Urlaube_Add"];

        public Urlaube_Report_New()
        {
            InitializeComponent();
        }

        private void Urlaube_Report_New_Load(object sender, EventArgs e)
        {
            //Get von bis from Urlaube_Add form
            string txtVon = obj_Urlaube_Add.dateTimePicker_von.Text;
            string txtBis = obj_Urlaube_Add.dateTimePicker_bis.Text;
            string txtAnzahlTage = obj_Urlaube_Add.txtAnzahlTage.Text;
            string txtUrlaubTyp = this.lblUrlaubTyp.Text;
            string txtDNr = obj_Urlaube_Add.comboDNr.SelectedItem.ToString();
            string Vor_Nachname = obj_Urlaube_Add.txtVorname.Text + " " + obj_Urlaube_Add.txtNachname.Text;

            //Convert DNr combo to integer
            int intDNr;
            intDNr = Convert.ToInt32(txtDNr);
            intDNr = int.Parse(txtDNr);

            // TODO: This line of code loads data into the 'um_db_DataSet.urlaube' table. You can move, or remove it, as needed.
            this.urlaubeTableAdapter.FillBy_DNr(this.um_db_DataSet.urlaube, intDNr);
            // TODO: This line of code loads data into the 'um_db_DataSet.einstellungen_firma' table. You can move, or remove it, as needed.
            this.einstellungen_firmaTableAdapter.Fill(this.um_db_DataSet.einstellungen_firma);

            //
            // Se pari krijo parametrat ne reportviewer.rdlc psh. ReportParameterVon, etc.
            //
            ReportParameter ReportParameterVon = new ReportParameter("ReportParameterVon", txtVon);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ReportParameterVon });

            ReportParameter ReportParameterBis = new ReportParameter("ReportParameterBis", txtBis);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ReportParameterBis });

            ReportParameter ReportParameterAnzahl = new ReportParameter("ReportParameterAnzahl", txtAnzahlTage);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ReportParameterAnzahl });

            ReportParameter ReportParameterTyp = new ReportParameter("ReportParameterTyp", txtUrlaubTyp);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ReportParameterTyp });

            ReportParameter ReportParameterDNr = new ReportParameter("ReportParameterDNr", txtDNr);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ReportParameterDNr });

            ReportParameter ReportParameterVor_Nachname = new ReportParameter("ReportParameterVor_Nachname", Vor_Nachname);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ReportParameterVor_Nachname });

            this.reportViewer1.RefreshReport();
        }
    }
}
