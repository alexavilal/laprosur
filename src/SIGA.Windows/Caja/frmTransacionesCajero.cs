using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIGA.Windows.Caja
{
    public partial class frmTransacionesCajero : Form
    {
        public DataTable dt { get; set; }
        public frmTransacionesCajero()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIGA.Business.Ventas.ReporteBusiness obj = new SIGA.Business.Ventas.ReporteBusiness();

            dt = obj.TransaccionesCajero(dtpDel.Value.ToString("yyyyMMdd"), dtpDel.Value.ToString("yyyyMMdd"));
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].ReadOnly = true;

            dataGridView1.Columns[1].Width = 350;

            dataGridView1.Columns[2].ReadOnly = true;

            dataGridView1.Columns[2].Width = 75;

           


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Comunes.frmImpresion objfrmReporte = new SIGA.Windows.Comunes.frmImpresion();
            string ruta = string.Empty;


            try
            {
                ruta = @"C:\Trabajo\SIGA-CODE\SIGA\SIGA.Windows\Reportes\rptAcumuladoCajero.rdlc";

                objfrmReporte.Archivo = "rptAcumuladoCajero.rpt";
                objfrmReporte.Entidad = "USP_GeneralPreciosReposicionConsultar";
                objfrmReporte.DataSource = dt;
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
