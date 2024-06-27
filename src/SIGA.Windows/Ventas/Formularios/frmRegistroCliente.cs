//using SIGA.Entities.Seguridad;
using SIGA.Business.Administrador;
//using SIGA.Business.Seguridad;
using SIGA.Business.Logistica;
using SIGA.Business.Ventas;
using SIGA.Entities.Logistica;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmRegistroCliente : Form
    {
        public string CodigoEdicion;
        //List<ClienteContacto> ListaContactoGrid = new List<ClienteContacto>();

        public frmRegistroCliente()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(173, 216, 230);
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



        void CargarEstado()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("A", "Activo"));
            data.Add(new KeyValuePair<string, string>("I", "Inactivo"));

            cboEstado.DataSource = null;
            cboEstado.Items.Clear();

            cboEstado.DataSource = new BindingSource(data, null);
            cboEstado.DisplayMember = "Value";
            cboEstado.ValueMember = "Key";
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CodigoEdicion))
            {
                ActualizarCliente();
                btnGuardar.Enabled = false;

            }
            else
            {
                if (tbCliente.SelectedIndex == 1)
                {
                    //RegistrarContactoCliente();
                }
                else
                {
                    RegistrarCliente();
                }
            }
        }


        private bool ValidarDatos()
        {
            bool esValido = true;

            if (Convert.ToInt32(cboTipoDocumento.SelectedValue).Equals(0))
            {
                MessageBox.Show("Debe seleccionar un tipo de documento", "SIGA");
                return esValido = false;
            }

            if (Convert.ToInt32(cboPolitica.SelectedValue).Equals(0))
            {
                MessageBox.Show("Debe seleccionar una Politica de Precios", "SIGA");
                return esValido = false;
            }

            if (Convert.ToInt32(cboVendedor.SelectedValue).Equals(0))
            {
                MessageBox.Show("Debe asignar un vendedor", "SIGA");
                return esValido = false;
            }


            return esValido;
        }


        private void ActualizarCliente()
        {
            Int16 CodigoCategoria = 0;
            try
            {
                if (!ValidarDatos()) return;

                int Codigo = 0;

                var lstPlacas = Lista();

                ClienteContactoBusiness objDocumentoBussiness = new ClienteContactoBusiness();
                ClienteResponse objClienteResponse = new ClienteResponse();
                objClienteResponse.CodCliente = TxtCodigoGenerado.Text;
                objClienteResponse.CodTipoDocumento = Convert.ToInt16(cboTipoDocumento.SelectedValue);
                objClienteResponse.NumDocumentoCliente = txtNumero.Text;
                objClienteResponse.CodTipoCliente = Convert.ToInt16(cboTipoCliente.SelectedValue);
                objClienteResponse.CodSubTipo = Convert.ToInt16(cboSubTipoCliente.SelectedValue);
                objClienteResponse.RazSocCliente = txtRazonSocial.Text;
                objClienteResponse.ApePatCliente = txtRazonSocial.Text;
                objClienteResponse.ApeMatCliente = txtNombreComercial.Text;
                objClienteResponse.NomCliente = txtNombre.Text;
                objClienteResponse.NomComCliente = txtNombreComercial.Text;
                objClienteResponse.DirCliente = txtDireccion.Text;
                objClienteResponse.Correo = txtCorreoElectronico.Text;
                objClienteResponse.Sexo = rbM.Checked == true ? "M" : "F";
                objClienteResponse.FechaAniveCliente = dtpFecha.Value;
                objClienteResponse.CodFormaPago = Convert.ToInt16(cboFormaPago.SelectedValue);
                objClienteResponse.PaginaWeb = txtWeb.Text;
                objClienteResponse.LineaCreditoCliente_1 = Convert.ToDecimal(txtLineaCredito.Text);
                objClienteResponse.SaldoCreditoCliente_1 = Convert.ToDecimal(txtSaldoCredito.Text);
                objClienteResponse.UsuVendedorInicio = Convert.ToInt16(cboContactoInicial.SelectedValue);
                objClienteResponse.UsuRepresentante = Convert.ToInt16(cboRepresentante.SelectedValue);
                objClienteResponse.Est_Codigo = Convert.ToString(cboEstado.SelectedValue);
                objClienteResponse.CodPolitica = Convert.ToInt32(cboPolitica.SelectedValue);
                objClienteResponse.CodUsuarioVendedor = Convert.ToInt32(cboVendedor.SelectedValue);
                objClienteResponse.UsuMod = UsuarioLogeo.Codigo;
                objClienteResponse.PlacaVehiculo = string.Empty;

                switch (cboCategoria.Text)
                {
                    case "Categoria A": CodigoCategoria = 1; break;
                    case "Categoria B": CodigoCategoria = 2; break;
                    case "Categoria C": CodigoCategoria = 3; break;

                }

                objClienteResponse.CodigoCategoria = CodigoCategoria;

                Codigo = objDocumentoBussiness.ActualizarCliente(objClienteResponse, lstPlacas);

                if (Codigo > 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");

                }
                else
                {
                    MessageBox.Show("No se pudo realizar la operación", "SIGA");
                }
            }
            catch (Exception)
            {
                throw new Exception("Error, Consulte con el administrador");
            }
        }


        private void RegistrarCliente()
        {

            ClienteBusiness objDocumentoBussiness = new ClienteBusiness();
            ClienteResponse objClienteResponse = new ClienteResponse();


            Int16 CodigoCategoria = 0;
            string Codigo;



            try
            {
                if (!ValidarDatos()) return;

                var lstPlacas = Lista();

                objClienteResponse.CodTipoDocumento = Convert.ToInt16(cboTipoDocumento.SelectedValue);
                objClienteResponse.NumDocumentoCliente = txtNumero.Text;
                objClienteResponse.CodTipoCliente = Convert.ToInt16(cboTipoCliente.SelectedValue);
                objClienteResponse.CodSubTipo = Convert.ToInt16(cboSubTipoCliente.SelectedValue);
                objClienteResponse.RazSocCliente = txtRazonSocial.Text;
                objClienteResponse.ApePatCliente = txtRazonSocial.Text;
                objClienteResponse.ApeMatCliente = txtNombreComercial.Text;
                objClienteResponse.NomCliente = txtNombre.Text;
                objClienteResponse.NomComCliente = txtNombreComercial.Text;
                objClienteResponse.DirCliente = txtDireccion.Text;
                objClienteResponse.Correo = txtCorreoElectronico.Text;
                objClienteResponse.Sexo = rbM.Checked == true ? "M" : "F";
                objClienteResponse.FechaAniveCliente = dtpFecha.Value;
                objClienteResponse.CodFormaPago = Convert.ToInt16(cboFormaPago.SelectedValue);
                objClienteResponse.PaginaWeb = txtWeb.Text;
                objClienteResponse.LineaCreditoCliente_1 = Convert.ToDecimal(txtLineaCredito.Text);
                objClienteResponse.SaldoCreditoCliente_1 = Convert.ToDecimal(txtSaldoCredito.Text);
                objClienteResponse.UsuVendedorInicio = Convert.ToInt16(cboContactoInicial.SelectedValue);
                objClienteResponse.UsuRepresentante = Convert.ToInt16(cboRepresentante.SelectedValue);
                objClienteResponse.UsuCreCodigo = UsuarioLogeo.Codigo;
                objClienteResponse.CodPolitica = Convert.ToInt32(cboPolitica.SelectedValue);
                objClienteResponse.CodUsuarioVendedor = Convert.ToInt32(cboVendedor.SelectedValue);
                objClienteResponse.PlacaVehiculo = string.Empty; /*txtPlaca.TextLength.Equals(0) ? "" : txtPlaca.Text;*/


                switch (cboCategoria.Text)
                {
                    case "Categoria A": CodigoCategoria = 1; break;
                    case "Cliente B": CodigoCategoria = 2; break;
                    case "Cliente C": CodigoCategoria = 3; break;

                }

                objClienteResponse.CodigoCategoria = CodigoCategoria;

                Codigo = objDocumentoBussiness.RegistrarCliente(objClienteResponse, lstPlacas);

                if (Codigo != "0")
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    TxtCodigoGenerado.Text = Codigo;
                    tbCliente.SelectTab(1);
                    btnGuardar.Enabled = false;

                }
                else
                {
                    MessageBox.Show("No se pudo realizar la operación", "SIGA");
                }
            }
            catch (Exception)
            {
                throw new Exception("Error, Consulte con el administrador");
            }
        }

        void ValidarTipoDocumento()
        {
            //if (cboTipoDocumento.Text == Constantes.TipoDocumento.RUC)
            //{
            //    txtNombre.Enabled = false;
            //    rbF.Enabled = false;
            //    rbM.Enabled = false;
            //    txtNombre.Text = "";
            //    rbF.Checked = false;
            //    rbM.Checked = false;
            //}
            //else
            //{
            //    txtNombre.Enabled = true;
            //    rbF.Enabled = true;
            //    rbM.Enabled = true;
            //}
        }

        public List<ClientePlaca> Lista()
        {
            List<ClientePlaca> ListaDocumento = new List<ClientePlaca>();


            foreach (DataGridViewRow row in this.dgvPlaca.Rows)
            {
                // Verificar si la fila no es la fila de encabezado

                ClientePlaca Item = new ClientePlaca();
                Item.CodigoRegistro = Convert.ToInt32(row.Cells[0].Value);
                Item.PlacaVehiculo = Convert.ToString(row.Cells[1].Value);

                ListaDocumento.Add(Item);
            }


            return ListaDocumento;

        }


        private void frmRegistroCliente_Load(object sender, EventArgs e)
        {
            CargarEstado();
            CargarPolitica();
            CargarTipoDocIdentidad();
            CargarUsuarios();
            ColumnasGrillaContacto();

            if (string.IsNullOrEmpty(CodigoEdicion))
            {
                cboEstado.Enabled = false;
            }
            else
            {
                cboEstado.Enabled = true;
                ObtenerDatosCliente();
            }
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
        private void CargarPolitica()
        {
            PoliticaPrecioBusiness objPolitica = new PoliticaPrecioBusiness();
            PoliticaPrecio entPolitica = new PoliticaPrecio()
            {
                DesPolitica = String.Empty,
                EstCodigo = "A"
            };

            try
            {
                var result = objPolitica.ObtenerPolitica(entPolitica);
                cboPolitica.DataSource = result;
                cboPolitica.DisplayMember = "DesPolitica";
                cboPolitica.ValueMember = "CodPolitica";


            }
            catch (Exception ex)
            {


            }
        }

        public void ObtenerDatosCliente()
        {
            ClienteBusiness objClienteBusiness = new ClienteBusiness();

            ClienteResponse objEntidad = new ClienteResponse();
            objEntidad.CodCliente = CodigoEdicion;

            var consulta = objClienteBusiness.ObtenerClientePorCodigo(objEntidad);

            if (consulta != null)
            {
                TxtCodigoGenerado.Text = CodigoEdicion;
                cboTipoDocumento.SelectedValue = consulta.CodTipoDocumento;
                txtNumero.Text = consulta.NumDocumentoCliente;
                cboTipoCliente.SelectedValue = consulta.CodTipoCliente;
                cboSubTipoCliente.SelectedValue = consulta.CodSubTipo;
                txtRazonSocial.Text = consulta.RazSocCliente;
                txtNombreComercial.Text = consulta.NomComCliente;
                txtNombre.Text = consulta.NomCliente;
                txtDireccion.Text = consulta.DirCliente;
                txtCorreoElectronico.Text = consulta.Correo;
                rbM.Checked = consulta.Sexo == "M" ? true : false;
                rbF.Checked = consulta.Sexo == "F" ? true : false;
                dtpFecha.Value = consulta.FechaAniveCliente;
                cboFormaPago.SelectedValue = consulta.CodFormaPago;
                txtWeb.Text = consulta.PaginaWeb;
                txtLineaCredito.Text = consulta.LineaCreditoCliente_1.ToString();
                txtSaldoCredito.Text = consulta.SaldoCreditoCliente_1.ToString();
                cboContactoInicial.SelectedValue = Convert.ToInt32(consulta.UsuVendedorInicio);
                cboRepresentante.SelectedValue = Convert.ToInt32(consulta.UsuRepresentante);
                cboEstado.SelectedValue = consulta.Est_Codigo;
                cboPolitica.SelectedValue = Convert.ToInt32(consulta.CodPolitica);
                cboVendedor.SelectedValue = Convert.ToInt32(consulta.CodUsuarioVendedor);
                //txtPlaca.Text = consulta.PlacaVehiculo.ToString();


                cargaBdListaPlacas();
            }

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            var codigoOperador = Convert.ToInt16(cboOperador.SelectedValue);

            if (codigoOperador.Equals(0))
            {
                MessageBox.Show("Seleccione un operador valido", "SIGA");
                return;
            }


            cargarListaContactos();
        }

        void cargarListaContactos()
        {
            //dgvContactos.DataSource = null;
            //dgvContactos.DataSource = ListaContactoGrid;
        }

        private void btnQuitarContacto_Click(object sender, EventArgs e)
        {
            if (dgvContactos.RowCount > 0)
            {

            }
        }


        private void cargaBdListaPlacas()
        {
            //ClienteContactoBusiness objBLProveedor = new ClienteContactoBusiness();
            //ClienteContacto objProveedorContacto = new ClienteContacto();
            //objProveedorContacto.CodCliente = string.IsNullOrEmpty(CodigoEdicion) ? TxtCodigoGenerado.Text : CodigoEdicion;

            //var ObtenerListaContactos = objBLProveedor.ObtenerClienteContacto(objProveedorContacto);

            //ListaContactoGrid = ObtenerListaContactos;

            //dgvContactos.DataSource = ListaContactoGrid;

            ClienteBusiness clienteBusiness = new ClienteBusiness();
            try
            {
                var result = clienteBusiness.ListarPlacas(CodigoEdicion);

                dgvPlaca.Rows.Clear();

                foreach (var item in result)
                {

                    dgvPlaca.Rows.Insert(dgvPlaca.Rows.Count, item.CodigoRegistro, item.PlacaVehiculo);

                }

            }
            catch (Exception ex)
            {

            }


        }


        void ColumnasGrillaContacto()
        {
            dgvContactos.ReadOnly = true;

            dgvContactos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContactos.MultiSelect = false;

            dgvContactos.AutoGenerateColumns = false;
            dgvContactos.ColumnCount = 13;

            dgvContactos.Columns[0].Name = "CodClienteContacto";
            dgvContactos.Columns[0].HeaderText = "CodClienteContacto";
            dgvContactos.Columns[0].DataPropertyName = "CodClienteContacto";
            dgvContactos.Columns[0].Width = 150;
            dgvContactos.Columns[0].Visible = false;

            dgvContactos.Columns[1].Name = "CodCliente";
            dgvContactos.Columns[1].HeaderText = "CodCliente";
            dgvContactos.Columns[1].DataPropertyName = "CodCliente";
            dgvContactos.Columns[1].Width = 150;
            dgvContactos.Columns[1].Visible = false;

            dgvContactos.Columns[2].HeaderText = "Nombre";
            dgvContactos.Columns[2].Name = "NomConCliente";
            dgvContactos.Columns[2].DataPropertyName = "NomConCliente";
            dgvContactos.Columns[2].Width = 150;

            dgvContactos.Columns[3].HeaderText = "Apellido";
            dgvContactos.Columns[3].Name = "ApellidoConCliente";
            dgvContactos.Columns[3].DataPropertyName = "ApellidoConCliente";
            dgvContactos.Columns[3].Width = 150;

            dgvContactos.Columns[4].HeaderText = "Cargo";
            dgvContactos.Columns[4].Name = "CargoConCliente";
            dgvContactos.Columns[4].DataPropertyName = "CargoConCliente";
            dgvContactos.Columns[4].Width = 150;

            dgvContactos.Columns[5].HeaderText = "Area";
            dgvContactos.Columns[5].Name = "AreaConCliente";
            dgvContactos.Columns[5].DataPropertyName = "AreaConCliente";
            dgvContactos.Columns[5].Width = 150;

            dgvContactos.Columns[6].HeaderText = "CodOperador";
            dgvContactos.Columns[6].Name = "CodOperador";
            dgvContactos.Columns[6].DataPropertyName = "CodOperador";
            dgvContactos.Columns[6].Width = 100;
            dgvContactos.Columns[6].Visible = false;

            dgvContactos.Columns[7].HeaderText = "CodOperador2";
            dgvContactos.Columns[7].Name = "CodOperador2";
            dgvContactos.Columns[7].DataPropertyName = "CodOperador2";
            dgvContactos.Columns[7].Visible = false;

            dgvContactos.Columns[8].HeaderText = "Operador 1";
            dgvContactos.Columns[8].Name = "operador1";
            dgvContactos.Columns[8].DataPropertyName = "operador1";

            dgvContactos.Columns[9].HeaderText = "Numero";
            dgvContactos.Columns[9].Name = "CelConCliente1";
            dgvContactos.Columns[9].DataPropertyName = "CelConCliente1";


            dgvContactos.Columns[10].HeaderText = "Operador 2";
            dgvContactos.Columns[10].Name = "operador2";
            dgvContactos.Columns[10].DataPropertyName = "operador2";

            dgvContactos.Columns[11].HeaderText = "Numero";
            dgvContactos.Columns[11].Name = "CelConCliente2";
            dgvContactos.Columns[11].DataPropertyName = "CelConCliente2";

            dgvContactos.Columns[12].HeaderText = "Correo";
            dgvContactos.Columns[12].Name = "CorConCliente";
            dgvContactos.Columns[12].DataPropertyName = "CorConCliente";
        }

        private void tbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbCliente.SelectedIndex == 1)
            {
                if (TxtCodigoGenerado.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Debe Ingresar los datos del cliente", "SIGA");
                    tbCliente.SelectTab(0);
                }
            }
        }

        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarTipoDocumento();
        }

        private void cboTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoDocumento_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cboTipoDocumento.Text == "DNI")
            {
                if (Convert.ToInt32(txtNumero.Text.Length) != 8)
                {
                    MessageBox.Show("Debe ingresar 8 digitos para busqueda con DNI");
                    return;
                }
                else
                {
                    Buscar(2);
                }
            }
            else
            {
                if (Convert.ToInt32(txtNumero.Text.Length) != 11)
                {

                    MessageBox.Show("Debe ingresar 11 digitos para busqueda con RUC");
                    return;
                }
                else
                {
                    Buscar(1);
                }
            }
        }
        private void Buscar(int TipoDocumento)
        {

            SIGA.Business.Ventas.ClienteBusiness objCliente = new SIGA.Business.Ventas.ClienteBusiness();
            Nissi.nFact.Entidades.EmpresaBusqueda objEmpresa = new Nissi.nFact.Entidades.EmpresaBusqueda();


            try
            {
                var consulta = objCliente.BuscarPorTipoDocumento(TipoDocumento, txtNumero.Text).SingleOrDefault();

                if (consulta != null)
                {
                    CodigoEdicion = consulta.CodCliente.ToString();
                    TxtCodigoGenerado.Text = consulta.CodCliente.ToString();
                    cboTipoDocumento.SelectedValue = consulta.CodTipoDocumento;
                    txtNumero.Text = consulta.NumDocumentoCliente;
                    cboTipoCliente.SelectedValue = consulta.CodTipoCliente;
                    cboSubTipoCliente.SelectedValue = consulta.CodSubTipo;
                    txtRazonSocial.Text = consulta.RazSocCliente;
                    txtNombreComercial.Text = consulta.NomComCliente;
                    txtNombre.Text = consulta.NomCliente;
                    txtDireccion.Text = consulta.DirCliente;
                    txtCorreoElectronico.Text = consulta.Correo;
                    rbM.Checked = consulta.Sexo == "M" ? true : false;
                    rbF.Checked = consulta.Sexo == "F" ? true : false;
                    dtpFecha.Value = consulta.FechaAniveCliente;
                    cboFormaPago.SelectedValue = consulta.CodFormaPago;
                    txtWeb.Text = consulta.PaginaWeb;
                    txtLineaCredito.Text = consulta.LineaCreditoCliente_1.ToString();
                    txtSaldoCredito.Text = consulta.SaldoCreditoCliente_1.ToString();
                    cboContactoInicial.SelectedValue = Convert.ToInt32(consulta.UsuVendedorInicio);
                    cboRepresentante.SelectedValue = Convert.ToInt32(consulta.UsuRepresentante);
                    cboEstado.SelectedValue = consulta.Est_Codigo;
                    cboPolitica.SelectedValue = Convert.ToInt32(consulta.CodPolitica);
                    cboVendedor.SelectedValue = Convert.ToInt32(consulta.CodUsuarioVendedor);
                    cargaBdListaPlacas();

                }
                else
                {
                    objEmpresa = Nissi.nFact.Servicios.BusquedaRucDni(TipoDocumento, txtNumero.Text);

                    if (objEmpresa.Exito.Equals(-1))
                    {
                        MessageBox.Show("No se encontro informacion..!");
                        txtRazonSocial.Text = string.Empty;
                        txtDireccion.Text = string.Empty;
                        txtNumero.Focus();

                    }
                    else
                    {
                        if (TipoDocumento.Equals(1))  //RUC
                        {
                            txtRazonSocial.Text = objEmpresa.razonSocial;
                            txtDireccion.Text = objEmpresa.direccion;
                        }

                        if (TipoDocumento.Equals(2))  //DNI
                        {
                            txtRazonSocial.Text = objEmpresa.nombres + " " + objEmpresa.apellidopaterno + " " + objEmpresa.apellidomaterno;
                            txtDireccion.Text = objEmpresa.direccion;
                        }

                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarFila();
        }


        private void AgregarFila()
        {
            dgvPlaca.ClearSelection();
            dgvPlaca.Rows.Insert(dgvPlaca.Rows.Count, 0, "");
            dgvPlaca.Focus();
            dgvPlaca.CurrentCell = dgvPlaca.Rows[dgvPlaca.Rows.Count - 1].Cells[1];
            dgvPlaca.Rows[dgvPlaca.Rows.Count - 1].Cells[1].Selected = true;
            dgvPlaca.BeginEdit(true);


        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int CodigoRegistro = 0;
            ClienteBusiness clienteBusiness = new ClienteBusiness();


            try
            {
                if (dgvPlaca.Rows.Count > 0)
                {

                    CodigoRegistro = Convert.ToInt32(dgvPlaca[0, dgvPlaca.CurrentRow.Index].Value);


                    int index = dgvPlaca.CurrentCell.RowIndex;


                    if (CodigoRegistro > 0)
                    {
                        dgvPlaca.Rows.RemoveAt(index);
                        var result = clienteBusiness.ClienteEliminarPlaca(CodigoRegistro);

                    }
                    else
                    {

                        dgvPlaca.Rows.RemoveAt(index);

                    }

                }
                else
                {
                    MessageBox.Show("No existen items por eliminar");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }
    }
}
