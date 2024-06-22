using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;
using SIGA.Business.Ventas;
//using SIGA.Business.Seguridad;
using SIGA.Entities.Ventas;
//using SIGA.Entities.Seguridad;
using SIGA.Business.Comunes;
using SIGA.Comun;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmMantenimientoCliente : Form
    {
        public frmMantenimientoCliente()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(173, 216, 230);
        }

        private void frmMantenimientoCliente_Load(object sender, EventArgs e)
        {
            ColumnasGrillaProveedor();
            CargarEstado();
            CargarTipoDocIdentidad();
            CargarSexo();
            //CargarTipoCliente();
            //CargarSubTipoCliente();
            //CargarContactoResponsable();
            //CargarFormaPago();
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

        void BuscarCliente()
        {
            ClienteBusiness objBusiness = new ClienteBusiness();

            ClienteResponse objEntidad = new ClienteResponse();

            objEntidad.CodCliente = TxtCodigoGenerado.Text;
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
            objEntidad.Est_Codigo = Convert.ToString(cboEstado.SelectedValue);

            dgvCliente.DataSource = objBusiness.ObtenerClientesRegistrados(objEntidad);
         



        }

        //void CargarFormaPago()
        //{
        //    SIGA.Business.Ventas.FormaPagoBusiness objDocumentoBussiness = new SIGA.Business.Ventas.FormaPagoBusiness();

        //    List<FormaPago> Lista = new List<FormaPago>();
        //    Lista.Add(new FormaPago { CodFormaPago = 0, DesFormaPago = "Todos" });

        //    var consulta = objDocumentoBussiness.ObtenerFormaPago(0);

        //    foreach (var item in consulta)
        //    {
        //        Lista.Add(item);
        //    }

        //    cboFormaPago.DataSource = Lista;
        //    cboFormaPago.ValueMember = "CodFormaPago";
        //    cboFormaPago.DisplayMember = "DesFormaPago";
        //}

        //void CargarTipoCliente()
        //{
        //    TipoClienteBusiness objDocumentoBussiness = new TipoClienteBusiness();

        //    List<TipoCliente> Lista = new List<TipoCliente>();
        //    Lista.Add(new TipoCliente { CodTipoCliente = 0, DesTipoCliente = "Todos" });

        //    var consulta = objDocumentoBussiness.ObtenerTipoCliente();

        //    foreach (var item in consulta)
        //    {
        //        Lista.Add(item);
        //    }

        //    cboTipoCliente.DataSource = Lista;
        //    cboTipoCliente.ValueMember = "CodTipoCliente";
        //    cboTipoCliente.DisplayMember = "DesTipoCliente";
        //}

        //void CargarSubTipoCliente()
        //{
        //    SubTipoClienteBusiness objDocumentoBussiness = new SubTipoClienteBusiness();

        //    List<SubTipoCliente> Lista = new List<SubTipoCliente>();
        //    Lista.Add(new SubTipoCliente { CodSubTipo = 0, DesSubTipo = "Todos" });

        //    var consulta = objDocumentoBussiness.ObtenerSubTipoCliente();

        //    foreach (var item in consulta)
        //    {
        //        Lista.Add(item);
        //    }

        //    cboSubTipoCliente.DataSource = Lista;
        //    cboSubTipoCliente.ValueMember = "CodSubTipo";
        //    cboSubTipoCliente.DisplayMember = "DesSubTipo";
        //}

        //void CargarTipoDocIdentidad()
        //{
        //    TipoDocumentoIdentidadBusiness objDocumentoBussiness = new TipoDocumentoIdentidadBusiness();

        //    List<TipoDocumentoIdentificacion> Lista = new List<TipoDocumentoIdentificacion>();
        //    Lista.Add(new TipoDocumentoIdentificacion { CodTipoDocumento = 0, DesDocumento = "Todos" });

        //    var consulta =  objDocumentoBussiness.ListarTipoDocumentoIdentidad();

        //    foreach (var item in consulta)
        //    {
        //        Lista.Add(item);
        //    }

        //    cboTipoDocumento.DataSource = Lista;
        //    cboTipoDocumento.ValueMember = "CodTipoDocumento";
        //    cboTipoDocumento.DisplayMember = "DesDocumento";
        //}

        //void CargarContactoResponsable()
        //{
        //    UsuarioBusiness objDocumentoBussiness = new UsuarioBusiness();

        //    List<Usuario> Lista = new List<Usuario>();
        //    List<Usuario> Lista2 = new List<Usuario>();

        //    Lista.Add(new Usuario { CodigoUsuario = 0, Nombre = "Todos" });
        //    Lista2.Add(new Usuario { CodigoUsuario = 0, Nombre = "Todos" });
        //    var consulta = objDocumentoBussiness.ObtenerContactoRepresentante(); 

        //    foreach (var item in consulta)
        //    {
        //        Lista.Add(item);
        //        Lista2.Add(item);
        //    }

        //    cboContactoInicial.DataSource = Lista; 
        //    cboContactoInicial.ValueMember = "CodigoUsuario";
        //    cboContactoInicial.DisplayMember = "Nombre";

        //    cboRepresentante.DataSource = Lista2;
        //    cboRepresentante.ValueMember = "CodigoUsuario";
        //    cboRepresentante.DisplayMember = "Nombre";
        //}

        void CargarEstado()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", "Todos"));
            data.Add(new KeyValuePair<string, string>("A", "Activo"));
            data.Add(new KeyValuePair<string, string>("I", "Inactivo"));

            cboEstado.DataSource = null;
            cboEstado.Items.Clear();

            cboEstado.DataSource = new BindingSource(data, null);
            cboEstado.DisplayMember = "Value";
            cboEstado.ValueMember = "Key";
        }

        void CargarSexo()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", "Todos"));
            data.Add(new KeyValuePair<string, string>("M", "Masculino"));
            data.Add(new KeyValuePair<string, string>("F", "Femenino"));

            cboSexo.DataSource = null;
            cboSexo.Items.Clear();

            cboSexo.DataSource = new BindingSource(data, null);
            cboSexo.DisplayMember = "Value";
            cboSexo.ValueMember = "Key";
        }

        void ColumnasGrillaProveedor()
        {

            dgvCliente.ReadOnly = true;

            dgvCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCliente.MultiSelect = false;

            dgvCliente.AutoGenerateColumns = false;
            dgvCliente.AllowUserToAddRows = false;
            dgvCliente.ColumnCount = 11;

            dgvCliente.Columns[0].Name = "CodCliente";
            dgvCliente.Columns[0].HeaderText = "Código";
            dgvCliente.Columns[0].DataPropertyName = "CodCliente";
            dgvCliente.Columns[0].Width = 65;

            dgvCliente.Columns[1].HeaderText = "Tipo Documento";
            dgvCliente.Columns[1].Name = "DesTipoDocumento";
            dgvCliente.Columns[1].DataPropertyName = "DesTipoDocumento";
            dgvCliente.Columns[1].Width = 110;

            dgvCliente.Columns[2].Name = "NumDocumentoCliente";
            dgvCliente.Columns[2].HeaderText = "Nro Documento";
            dgvCliente.Columns[2].DataPropertyName = "NumDocumentoCliente";
            dgvCliente.Columns[2].Width = 110;

            dgvCliente.Columns[3].Name = "DesTipoCliente";
            dgvCliente.Columns[3].HeaderText = "Tipo Cliente";
            dgvCliente.Columns[3].DataPropertyName = "DesTipoCliente";
            dgvCliente.Columns[3].Visible = false;

            dgvCliente.Columns[4].Name = "DesSubTipo";
            dgvCliente.Columns[4].HeaderText = "Sub Tipo";
            dgvCliente.Columns[4].DataPropertyName = "DesSubTipo";
            dgvCliente.Columns[4].Visible = false;

            dgvCliente.Columns[5].Name = "RazSocCliente";
            dgvCliente.Columns[5].HeaderText = "Razón Social";
            dgvCliente.Columns[5].DataPropertyName = "RazSocCliente";
            dgvCliente.Columns[5].Width = 150;

            dgvCliente.Columns[6].Name = "DirCliente";
            dgvCliente.Columns[6].HeaderText = "Dirección";
            dgvCliente.Columns[6].DataPropertyName = "DirCliente";
            dgvCliente.Columns[6].Width = 180;

            dgvCliente.Columns[7].Name = "DesPolitica";
            dgvCliente.Columns[7].HeaderText = "Politica de Ventas";
            dgvCliente.Columns[7].DataPropertyName = "DesPolitica";
            dgvCliente.Columns[7].Width = 180;

            dgvCliente.Columns[8].Name = "Vendedor";
            dgvCliente.Columns[8].HeaderText = "Vendedor";
            dgvCliente.Columns[8].DataPropertyName = "Vendedor";
            dgvCliente.Columns[8].Width = 180;

            dgvCliente.Columns[9].Name = "Placa";
            dgvCliente.Columns[9].HeaderText = "Placa";
            dgvCliente.Columns[9].DataPropertyName = "PlacaVehiculo";
            dgvCliente.Columns[9].Visible = false;
            

            dgvCliente.Columns[10].Name = "Est_Codigo";
            dgvCliente.Columns[10].HeaderText = "Estado";
            dgvCliente.Columns[10].DataPropertyName = "Est_Codigo";
            dgvCliente.Columns[10].Width = 60;



        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistroCliente objfrmRegistroCliente = new frmRegistroCliente();
            objfrmRegistroCliente.FormClosed += new FormClosedEventHandler(frmMantenimientoUsuario_FormClosed);
            objfrmRegistroCliente.ShowDialog();
        }

        private void frmMantenimientoUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            BuscarCliente();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCliente.RowCount > 0)
            {
                string codigo = Convert.ToString(dgvCliente[0, dgvCliente.CurrentRow.Index].Value);

                frmRegistroCliente objfrmRegistroCliente = new frmRegistroCliente();
                objfrmRegistroCliente.FormClosed += new FormClosedEventHandler(frmMantenimientoUsuario_FormClosed);
                objfrmRegistroCliente.CodigoEdicion = codigo;
                objfrmRegistroCliente.ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void ValidarTipoDocumento()
        {
            //if (cboTipoDocumento.Text == Constantes.TipoDocumento.RUC)
            //{
            //     txtNombre.Enabled = false;
            //    cboSexo.Enabled = false;                
            //    cboSexo.SelectedValue = "";          
            //}
            //else
            //{ 
            //    txtNombre.Enabled = true;
            //    cboSexo.Enabled = true;
            //}
        }

        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarTipoDocumento();
        }


        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            BuscarCliente();
        }

    }
}
