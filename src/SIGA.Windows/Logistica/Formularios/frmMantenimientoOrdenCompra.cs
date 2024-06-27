using SIGA.Business.Logistica;
using SIGA.Business.Ventas;
using SIGA.Entities.Logistica;
using System;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios
{
    public partial class frmMantenimientoOrdenCompra : Form
    {
        public frmMantenimientoOrdenCompra()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Logistica.Formularios.frmRegistroOC obj = new SIGA.Windows.Logistica.Formularios.frmRegistroOC();
            obj.ShowDialog();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        public void Consultar()
        {
            try
            {
                OrdenCompraBusiness ordenCompraBusiness = new OrdenCompraBusiness();
                OrdenCompraRequest ordenCompraRequest = new OrdenCompraRequest();

                ordenCompraRequest.FechaInicio = dtInicio.Value.ToString("yyyyMMdd");
                ordenCompraRequest.FechaFin = dtFin.Value.ToString("yyyyMMdd");
                ordenCompraRequest.CodProveedor = txtCodigoProveedor.Text == string.Empty ? 0 : Convert.ToInt32(txtCodigoProveedor.Text);

                var result = ordenCompraBusiness.Consultar(ordenCompraRequest);
                dgvOC.DataSource = result;

                dgvOC.Columns[0].Width = 100;
                dgvOC.Columns[1].Width = 100;
                dgvOC.Columns[2].Visible = false;
                dgvOC.Columns[3].Width = 500;                
                dgvOC.Columns[4].Visible = false;
                dgvOC.Columns[5].Width = 100;
                dgvOC.Columns[6].Width = 100;
            }
            catch (Exception ex)
            {

            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnAnula_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Comunes.frmProveedorBuscar objfrmProveedorBuscar = new SIGA.Windows.Comunes.frmProveedorBuscar();
            objfrmProveedorBuscar.ShowDialog();
            txtCodigoProveedor.Text = objfrmProveedorBuscar.CodigoProveedor;
            txtProveedor.Text = objfrmProveedorBuscar.NombreProveedor;
        }
    }
}
