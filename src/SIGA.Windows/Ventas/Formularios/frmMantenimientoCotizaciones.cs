using SIGA.Business.Ventas;
using System;
using System.Windows.Forms;
using SIGA.Business.Administrador;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmMantenimientoCotizaciones : Form
    {
        public frmMantenimientoCotizaciones()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmProforma objProforma = new frmProforma();
            objProforma.ShowDialog(this);
            Buscar(dtInicio.Value.ToString("yyyyMMdd"), dtFin.Value.ToString("yyyyMMdd"), txtCodigoCliente.Text, Convert.ToInt32(cboVendedor.SelectedValue));
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar(dtInicio.Value.ToString("yyyyMMdd"), dtFin.Value.ToString("yyyyMMdd"), txtCodigoCliente.Text, Convert.ToInt32(cboVendedor.SelectedValue));
        }

        public void Buscar(string FechaInicio , string FechaFin, string CodigoCliente,int CodigoVendedor)
        {
            CotizacionBusiness objCotizacion = new CotizacionBusiness();

            try
            {
                var result = objCotizacion.DevuelveCotizaciones(FechaInicio, FechaFin, CodigoCliente, CodigoVendedor);
                dgvPrecio.DataSource = result;

                dgvPrecio.Columns[0].Visible = false;
                dgvPrecio.Columns[1].Width = 150;
                dgvPrecio.Columns[2].Width = 100;
                dgvPrecio.Columns[3].Width = 350;
                dgvPrecio.Columns[4].Width = 100;
                dgvPrecio.Columns[5].Width = 100;

            }
            catch (Exception ex)
            {

            }

        }

        private void frmMantenimientoCotizaciones_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            Buscar(dtInicio.Value.ToString("yyyyMMdd"), dtFin.Value.ToString("yyyyMMdd"), txtCodigoCliente.Text, Convert.ToInt32(cboVendedor.SelectedValue));

        }

        private void CargarUsuarios()
        {

            UsuarioBusiness objBusiness = new UsuarioBusiness();
            SIGA.Entities.Administrador.Usuario objUsuario = new SIGA.Entities.Administrador.Usuario()
            {
                ApellidoPaterno = String.Empty,
                ApellidoMaterno = String.Empty,
                Nombre = String.Empty,
                IdentificadorUsuario = String.Empty,
                CorreoElectronico = String.Empty,
                CodigoEstadoUsuario = "A"
            };

            try
            {
                var result = objBusiness.ObtenerUsuarios(objUsuario);
                cboVendedor.DataSource = result;
                cboVendedor.ValueMember = "CodigoUsuario";
                cboVendedor.DisplayMember = "NombreBusqueda";
            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Comunes.frmClienteBuscar objfrmClienteBuscar = new SIGA.Windows.Comunes.frmClienteBuscar();
            objfrmClienteBuscar.ShowDialog();
            txtCodigoCliente.Text = objfrmClienteBuscar.CodigoCliente;
            txtRazonSocial.Text = objfrmClienteBuscar.NombreCliente;
        }
    }
}
