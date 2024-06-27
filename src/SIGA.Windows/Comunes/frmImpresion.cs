using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace SIGA.Windows.Comunes
{
    public partial class frmImpresion : Form
    {
        public string Archivo { get; set; }
        public string Entidad { get; set; }
        public Object DataSource { get; set; }

        public frmImpresion()
        {
            InitializeComponent();
        }

        private void frmImpresion_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            try
            {
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {

            }

        }

        public void sbImprimirConParametro(string Ruta)
        {
            try
            {
                reportViewer1.LocalReport.ReportPath = Ruta;
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSource));

                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }

        }
        public void sbImprimir(string Ruta)
        {
            try
            {
                reportViewer1.LocalReport.ReportPath = Ruta;
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSource));
                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }

        }

        public void sbImprimirReport(string Ruta)
        {
            try
            {
                reportViewer1.LocalReport.ReportPath = Ruta;
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(Entidad, DataSource));
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }

        }



    }
}
