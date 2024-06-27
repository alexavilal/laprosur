using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SIGA.Windows.Comunes
{
    public partial class frmProveedorBuscar : Form
    {
        public string CodigoProveedor{ get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }

        public frmProveedorBuscar()
        {
            InitializeComponent();
        }

        private void frmProveedorBuscar_Load(object sender, EventArgs e)
        {
            this.CargarTipoDocIdentidad();
        }

        void CargarTipoDocIdentidad()
        {
            TipoDocumentoIdentidadBusiness objDocumentoBussiness = new TipoDocumentoIdentidadBusiness();

            List<TipoDocumentoIdentificacion> Lista = new List<TipoDocumentoIdentificacion>();
            Lista.Add(new TipoDocumentoIdentificacion { CodTipoDocumento = 0, DesDocumento = "Seleccione" });

            var consulta = objDocumentoBussiness.ListarTipoDocumentoIdentidad();

            foreach (var item in consulta)
            {
                Lista.Add(item);
            }

            cboTipoDocumento.DataSource = Lista;
            cboTipoDocumento.ValueMember = "CodTipoDocumento";
            cboTipoDocumento.DisplayMember = "DesDocumento";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProveedor();
        }

        void BuscarProveedor()
        {
            ProveedorBusiness proveedorBusiness = new ProveedorBusiness();

            ProveedorRequest proveedorRequest = new ProveedorRequest();

            proveedorRequest.ProRazonSocial = txtRazonSocial.Text;
            proveedorRequest.ProNombreComercial = string.Empty;
            proveedorRequest.CodTipoDocumento = Convert.ToInt16(cboTipoDocumento.SelectedValue);
            proveedorRequest.NumDocumento = txtNumero.Text;
            proveedorRequest.Estado = "A";

            dgvProveedor.DataSource = proveedorBusiness.ListarProveedores(proveedorRequest);

            foreach (DataGridViewColumn column in dgvProveedor.Columns)
            {
                column.Visible = false; // Hace que la columna no sea visible
            }

            // Define el orden y visibilidad de las columnas
            dgvProveedor.Columns["ProCodigo"].DisplayIndex = 0; // Orden 0
            dgvProveedor.Columns["ProCodigo"].Visible = true;  // Hace la columna visible
            dgvProveedor.Columns["ProCodigo"].HeaderText = "Código";
            dgvProveedor.Columns["ProCodigo"].Width = 75;
            dgvProveedor.Columns["ProCodigo"].ReadOnly = false;

            dgvProveedor.Columns["TipoDocumento"].DisplayIndex = 1; // Orden 0
            dgvProveedor.Columns["TipoDocumento"].Visible = true;  // Hace la columna visible
            dgvProveedor.Columns["TipoDocumento"].HeaderText = "Tipo";
            dgvProveedor.Columns["TipoDocumento"].Width = 120;
            dgvProveedor.Columns["TipoDocumento"].ReadOnly = false;

            dgvProveedor.Columns["NumDocumento"].DisplayIndex = 2; // Orden 0
            dgvProveedor.Columns["NumDocumento"].Visible = true;  // Hace la columna visible
            dgvProveedor.Columns["NumDocumento"].HeaderText = "Numero";
            dgvProveedor.Columns["NumDocumento"].Width = 100;
            dgvProveedor.Columns["NumDocumento"].ReadOnly = false;

            dgvProveedor.Columns["ProRazonSocial"].DisplayIndex = 3; // Orden 0
            dgvProveedor.Columns["ProRazonSocial"].Visible = true;  // Hace la columna visible
            dgvProveedor.Columns["ProRazonSocial"].HeaderText = "Razon social";
            dgvProveedor.Columns["ProRazonSocial"].Width = 350;
            dgvProveedor.Columns["ProRazonSocial"].ReadOnly = false;

            dgvProveedor.Columns["Estado"].DisplayIndex = 4; // Orden 0
            dgvProveedor.Columns["Estado"].Visible = true;  // Hace la columna visible
            dgvProveedor.Columns["Estado"].HeaderText = "Estado";
            dgvProveedor.Columns["Estado"].Width = 50;
            dgvProveedor.Columns["Estado"].ReadOnly = false;

            dgvProveedor.Columns["Direccion"].DisplayIndex = 5; // Orden 0
            dgvProveedor.Columns["Direccion"].Visible = false;  // Hace la columna visible
            dgvProveedor.Columns["Direccion"].HeaderText = "Direccion";
            dgvProveedor.Columns["Direccion"].Width = 50;
            dgvProveedor.Columns["Direccion"].ReadOnly = false;
        }


        private void dgvProveedor_CellDoubleClick(System.Object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CodigoProveedor = Convert.ToString(dgvProveedor[0, dgvProveedor.CurrentRow.Index].Value);
                NombreProveedor = Convert.ToString(dgvProveedor[1, dgvProveedor.CurrentRow.Index].Value);
                Direccion = Convert.ToString(dgvProveedor[13, dgvProveedor.CurrentRow.Index].Value);
                Ruc = Convert.ToString(dgvProveedor[4, dgvProveedor.CurrentRow.Index].Value);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
