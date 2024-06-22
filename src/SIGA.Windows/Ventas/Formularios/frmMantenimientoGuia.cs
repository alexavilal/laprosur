using SIGA.Business.Ventas;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmMantenimientoGuia : Form
    {
        public frmMantenimientoGuia()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmGuia objGuia = new frmGuia();
            objGuia.ShowDialog();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            GuiaBusiness objGuia = new GuiaBusiness();

            if (dgvGuia.RowCount > 0)
            {

                int Guia = Convert.ToInt32(dgvGuia[0, dgvGuia.CurrentRow.Index].Value);
                ImprimirGuia(Guia);
                

            }
            else
            {
                MessageBox.Show("No existem items a consultar");

            }
        }

        private DataTable DatosGuia(int Codigo)
        {
            GuiaBusiness objGuia = new GuiaBusiness();
            return objGuia.DatosGuia(Codigo);
        }

        private void ImprimirGuia(int Codigo)
        {
            SIGA.Windows.Comunes.frmImpresion objfrmReporte = new SIGA.Windows.Comunes.frmImpresion();
            string ruta = string.Empty;

            try
            {
                ruta = @"D:\Info_Pc\Ejemplos\Personal\Laprosur\03-Desarrollo\LaProSur\Fuentes\SIGA\SIGA.Windows\Reportes\rptControlInterno.rdlc";
                objfrmReporte.Archivo = "rptOrdenCompraZurece.rpt";
                objfrmReporte.Entidad = "USP_OrdenCompraImpresion";
                objfrmReporte.DataSource = DatosGuia(Codigo);
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

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarGuia();
        }

        private void BuscarGuia()
        {
            GuiaBusiness objGuia = new GuiaBusiness();
            var result = objGuia.ConsultarGuias();
            dgvGuia.DataSource = result;
            dgvGuia.Columns[0].Visible = false;
            dgvGuia.Columns[4].Visible = false;
            dgvGuia.Columns[8].Visible = false;
            dgvGuia.Columns[9].Visible = false;
            dgvGuia.Columns[10].Visible = false;
            dgvGuia.Columns[11].Visible = false;

        }

        private void btnAnula_Click(object sender, EventArgs e)
        {
            int Guia = 0;
            string strEstado = string.Empty; 

            if ((dgvGuia.RowCount > 0))
            {


                strEstado = Convert.ToString(dgvGuia[13, dgvGuia.CurrentRow.Index].Value);

                if (strEstado.Equals("Activo"))
                {
                    Guia = Convert.ToInt32(dgvGuia[0, dgvGuia.CurrentRow.Index].Value);
                    frmAnularGuia objfrmGuia = new frmAnularGuia();
                    objfrmGuia.CodigoGuia = Guia;
                    objfrmGuia.ShowDialog();
                    BuscarGuia();

                }
                else
                {
                    MessageBox.Show("La guia se encuentra inactiva..");
                }
            }
            else
            {
                MessageBox.Show("No existem items a consultar");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
