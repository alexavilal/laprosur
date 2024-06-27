using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;
using SIGA.Windows.Logistica.Formularios.Mantenimientos;
using System;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos
{
    public partial class frmMantenimientoProveedor : Form
    {
        public frmMantenimientoProveedor()
        {
            InitializeComponent();

            ColumnasGrillaProveedor();
            CargarTipoDocIdentidad();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmRegProveedor objMantenimientoProveedor = new frmRegProveedor();
            objMantenimientoProveedor.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string codigo = Convert.ToString(dgvProveedor[0, dgvProveedor.CurrentRow.Index].Value);

            frmRegProveedor objMantenimientoProveedor = new frmRegProveedor();

            objMantenimientoProveedor.CodigoProveedor = Convert.ToInt32(codigo);
            objMantenimientoProveedor.ShowDialog();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            BuscarProveedor();
        }


        void BuscarProveedor()
        {

            ProveedorBusiness objBusiness = new ProveedorBusiness();

            Proveedor proveedores = new Proveedor();
            proveedores.NumDocumento = txtNumero.Text;
            proveedores.ProNombreComercial = txtNombreComercial.Text;
            proveedores.ProRazonSocial = txtRazonSocial.Text;
            proveedores.CodTipoDocumento = Convert.ToInt16(cboTipoDocumento.SelectedValue);
            proveedores.Estado = Convert.ToString(cboEstado.SelectedValue);
            var resultado = objBusiness.ListarProveedores(proveedores);

            dgvProveedor.DataSource = resultado;

        }

        void CargarTipoDocIdentidad()
        {
            TipoDocumentoIdentidadBusiness objDocumentoBussiness = new TipoDocumentoIdentidadBusiness();
            cboTipoDocumento.DataSource = objDocumentoBussiness.ListarTipoDocumentoIdentidad();
            cboTipoDocumento.ValueMember = "CodTipoDocumento";
            cboTipoDocumento.DisplayMember = "DesDocumento";
        }

        private void dgvProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > 0)
            //{

            //    DataGridViewRow row = this.dgvProveedor.Rows[e.RowIndex];

            //    string codigo = row.Cells["Codigo"].Value.ToString();

            //    frmRegProveedor objMantenimientoProveedor = new frmRegProveedor();

            //    objMantenimientoProveedor.CodigoProveedor = Convert.ToInt32(codigo);
            //    objMantenimientoProveedor.ShowDialog();
            //}
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //solo una col y row
            //MessageBox.Show(dgvProveedor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()); 
        }


        void ColumnasGrillaProveedor()
        {

            dgvProveedor.ReadOnly = true;

            dgvProveedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedor.MultiSelect = false;

            dgvProveedor.AutoGenerateColumns = false;
            dgvProveedor.ColumnCount = 6;

            dgvProveedor.Columns[0].Name = "ProCodigo";
            dgvProveedor.Columns[0].HeaderText = "Codigo";
            dgvProveedor.Columns[0].DataPropertyName = "ProCodigo";
            dgvProveedor.Columns[0].Width = 70;

            dgvProveedor.Columns[1].HeaderText = "ProRazon Social";
            dgvProveedor.Columns[1].Name = "ProRazonSocial";
            dgvProveedor.Columns[1].DataPropertyName = "ProRazonSocial";
            dgvProveedor.Columns[1].Width = 300;

            dgvProveedor.Columns[2].Name = "ProNombreComercial";
            dgvProveedor.Columns[2].HeaderText = "Nombre Comercial";
            dgvProveedor.Columns[2].DataPropertyName = "ProNombreComercial";
            dgvProveedor.Columns[2].Width = 300;

            dgvProveedor.Columns[3].Name = "TipoDocumento";
            dgvProveedor.Columns[3].HeaderText = "Tipo Documento";
            dgvProveedor.Columns[3].DataPropertyName = "TipoDocumento";
            dgvProveedor.Columns[3].Width = 130;

            dgvProveedor.Columns[4].Name = "NumDocumento";
            dgvProveedor.Columns[4].HeaderText = "Num Documento";
            dgvProveedor.Columns[4].DataPropertyName = "NumDocumento";
            dgvProveedor.Columns[4].Width = 130;

            dgvProveedor.Columns[5].Name = "Estado";
            dgvProveedor.Columns[5].HeaderText = "Estado";
            dgvProveedor.Columns[5].DataPropertyName = "Estado";
            dgvProveedor.Columns[5].Width = 130;

        }

        private void frmMantenimientoProveedor_Load(object sender, EventArgs e)
        {
            BuscarProveedor();
        }
    }
}
