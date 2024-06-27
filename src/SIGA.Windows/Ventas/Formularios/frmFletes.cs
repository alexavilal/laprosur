using SIGA.Business.Ventas;
using System;
using System.Data;
using System.Windows.Forms;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmFletes : Form
    {
        public frmFletes()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirGuia(dtInicio.Value.ToString("yyyyMMdd"), dtFin.Value.ToString("yyyyMMdd"), string.Empty);
        }

        private DataTable DatosFlete(string FechaInicial, string FechaFinal, string CodigoTrans)
        {
            FleteBusiness objGuia = new FleteBusiness();
            return objGuia.ReporteFlete(FechaInicial, FechaFinal, CodigoTrans);
        }

        private void ImprimirGuia(string FechaInicial, string FechaFinal, string CodigoTrans)
        {
            SIGA.Windows.Comunes.frmImpresion objfrmReporte = new SIGA.Windows.Comunes.frmImpresion();
            string ruta = string.Empty;

            try
            {
                ruta = @"D:\Info_Pc\Ejemplos\Personal\Laprosur\03-Desarrollo\LaProSur\Fuentes\SIGA\SIGA.Windows\Reportes\rptFlete.rdlc";
                objfrmReporte.Archivo = "rptOrdenCompraZurece.rpt";
                objfrmReporte.Entidad = "USP_OrdenCompraImpresion";
                objfrmReporte.DataSource = DatosFlete(FechaInicial, FechaFinal, CodigoTrans);
                objfrmReporte.WindowState = FormWindowState.Normal;
                objfrmReporte.sbImprimir(ruta);
                objfrmReporte.ShowDialog();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                objfrmReporte = null;

            }
        }
    }
}
