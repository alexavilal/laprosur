using SIGA.Business.Logistica;
using SIGA.Business.Ventas;
using SIGA.Entities.Logistica;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SIGA.Windows.Comunes
{
    public partial class frmClienteBuscar : Form
    {

        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }




        public frmClienteBuscar()
        {
            InitializeComponent();
        }

        private void frmClienteBuscar_Load(object sender, EventArgs e)
        {
            CargarTipoDocIdentidad();
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
            BuscarCliente();
        }

        void BuscarCliente()
        {
            ClienteBusiness objBusiness = new ClienteBusiness();

            ClienteResponse objEntidad = new ClienteResponse();

            objEntidad.CodCliente = string.Empty;
            objEntidad.CodTipoDocumento = Convert.ToInt16(cboTipoDocumento.SelectedValue);
            objEntidad.NumDocumentoCliente = txtNumero.Text;
            objEntidad.CodTipoCliente = Convert.ToInt16(cboTipoCliente.SelectedValue);
            objEntidad.CodSubTipo = Convert.ToInt16(cboSubTipoCliente.SelectedValue);
            objEntidad.RazSocCliente = txtRazonSocial.Text;
            objEntidad.NomComCliente = txtNombreComercial.Text;
            objEntidad.NomCliente = txtNombre.Text;
            objEntidad.Sexo = Convert.ToString(cboSexo.SelectedValue);
            objEntidad.DirCliente = txtDirecion.Text;
            objEntidad.CodFormaPago = Convert.ToInt16(cboFormaPago.SelectedValue);
            objEntidad.LineaCreditoCliente_1 = string.IsNullOrEmpty(txtLineaCreditoDel.Text) ? Convert.ToDecimal(0) : Convert.ToDecimal(txtLineaCreditoDel.Text);
            objEntidad.LineaCreditoCliente_2 = string.IsNullOrEmpty(txtLineaCreditoAl.Text) ? Convert.ToDecimal(0) : Convert.ToDecimal(txtLineaCreditoAl.Text);
            objEntidad.SaldoCreditoCliente_1 = string.IsNullOrEmpty(txtSaldoDel.Text) ? Convert.ToDecimal(0) : Convert.ToDecimal(txtSaldoDel.Text);
            objEntidad.SaldoCreditoCliente_2 = string.IsNullOrEmpty(txtSaldoAl.Text) ? Convert.ToDecimal(0) : Convert.ToDecimal(txtSaldoAl.Text);
            objEntidad.UsuVendedorInicio = Convert.ToInt16(cboContactoInicial.SelectedValue);
            objEntidad.UsuRepresentante = Convert.ToInt16(cboRepresentante.SelectedValue);
            objEntidad.Est_Codigo = "A";

            dgvCliente.DataSource = objBusiness.ObtenerClientesRegistrados(objEntidad);

            foreach (DataGridViewColumn column in dgvCliente.Columns)
            {
                column.Visible = false; // Hace que la columna no sea visible
            }

            // Define el orden y visibilidad de las columnas
            dgvCliente.Columns["CodCliente"].DisplayIndex = 0; // Orden 0
            dgvCliente.Columns["CodCliente"].Visible = true;  // Hace la columna visible
            dgvCliente.Columns["CodCliente"].HeaderText = "Codigo";
            dgvCliente.Columns["CodCliente"].Width = 75;
            dgvCliente.Columns["CodCliente"].ReadOnly = false;

            dgvCliente.Columns["DesTipoDocumento"].DisplayIndex = 1; // Orden 0
            dgvCliente.Columns["DesTipoDocumento"].Visible = true;  // Hace la columna visible
            dgvCliente.Columns["DesTipoDocumento"].HeaderText = "Tipo";
            dgvCliente.Columns["DesTipoDocumento"].Width = 120;
            dgvCliente.Columns["DesTipoDocumento"].ReadOnly = false;

            dgvCliente.Columns["NumDocumentoCliente"].DisplayIndex = 2; // Orden 0
            dgvCliente.Columns["NumDocumentoCliente"].Visible = true;  // Hace la columna visible
            dgvCliente.Columns["NumDocumentoCliente"].HeaderText = "Numero";
            dgvCliente.Columns["NumDocumentoCliente"].Width = 100;
            dgvCliente.Columns["NumDocumentoCliente"].ReadOnly = false;


            dgvCliente.Columns["RazSocCliente"].DisplayIndex = 3; // Orden 0
            dgvCliente.Columns["RazSocCliente"].Visible = true;  // Hace la columna visible
            dgvCliente.Columns["RazSocCliente"].HeaderText = "Razon social";
            dgvCliente.Columns["RazSocCliente"].Width = 350;
            dgvCliente.Columns["RazSocCliente"].ReadOnly = false;

            dgvCliente.Columns["Est_Codigo"].DisplayIndex = 4; // Orden 0
            dgvCliente.Columns["Est_Codigo"].Visible = true;  // Hace la columna visible
            dgvCliente.Columns["Est_Codigo"].HeaderText = "Estado";
            dgvCliente.Columns["Est_Codigo"].Width = 50;
            dgvCliente.Columns["Est_Codigo"].ReadOnly = false;

            //dgvCliente.Columns["DirCliente"].DisplayIndex = 5; // Orden 0
            //dgvCliente.Columns["DirCliente"].Visible = true; // Orden 0




            //dgvCliente.Columns["CodPolitica"].DisplayIndex = 6; // Orden 0
            //dgvCliente.Columns["CodPolitica"].Visible = true; // Orden 0









        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCliente_CellDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {



            try
            {
                CodigoCliente = Convert.ToString(dgvCliente[0, dgvCliente.CurrentRow.Index].Value);
                NombreCliente = Convert.ToString(dgvCliente[3, dgvCliente.CurrentRow.Index].Value);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
