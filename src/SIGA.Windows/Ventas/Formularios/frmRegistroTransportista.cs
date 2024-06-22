using SIGA.Business.Logistica;
using SIGA.Business.Ventas;
using SIGA.Entities.Logistica;
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
    public partial class frmRegistroTransportista : Form
    {
        public int CodigoEdicion { get; set; }
        public frmRegistroTransportista()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistroTransportista_Load(object sender, EventArgs e)
        {
            CargarEstado();
            CargarTipoDocIdentidad();
            // ColumnasGrillaContacto();

            if (CodigoEdicion>0)
            {
                cboEstado.Enabled = false;
            }
            else
            {
                cboEstado.Enabled = true;
                ObtenerDatosCliente();
            }
        }

        public void ObtenerDatosCliente()
        {
            //ClienteBusiness objClienteBusiness = new ClienteBusiness();

            //ClienteResponse objEntidad = new ClienteResponse();
            //objEntidad.CodCliente = CodigoEdicion;

            //var consulta = objClienteBusiness.ObtenerClientePorCodigo(objEntidad);

            //if (consulta != null)
            //{
            //    TxtCodigoGenerado.Text = CodigoEdicion;
            //    cboTipoDocumento.SelectedValue = consulta.CodTipoDocumento;
            //    txtNumero.Text = consulta.NumDocumentoCliente;
            //    cboTipoCliente.SelectedValue = consulta.CodTipoCliente;
            //    cboSubTipoCliente.SelectedValue = consulta.CodSubTipo;
            //    txtRazonSocial.Text = consulta.RazSocCliente;
            //    txtNombreComercial.Text = consulta.NomComCliente;
            //    txtNombre.Text = consulta.NomCliente;
            //    txtDireccion.Text = consulta.DirCliente;
            //    txtCorreoElectronico.Text = consulta.Correo;
            //    rbM.Checked = consulta.Sexo == "M" ? true : false;
            //    rbF.Checked = consulta.Sexo == "F" ? true : false;
            //    dtpFecha.Value = consulta.FechaAniveCliente;
            //    cboFormaPago.SelectedValue = consulta.CodFormaPago;
            //    txtWeb.Text = consulta.PaginaWeb;
            //    txtLineaCredito.Text = consulta.LineaCreditoCliente_1.ToString();
            //    txtSaldoCredito.Text = consulta.SaldoCreditoCliente_1.ToString();
            //    cboContactoInicial.SelectedValue = Convert.ToInt32(consulta.UsuVendedorInicio);
            //    cboRepresentante.SelectedValue = Convert.ToInt32(consulta.UsuRepresentante);
            //    cboEstado.SelectedValue = consulta.Est_Codigo;
            //    cboPolitica.SelectedValue = Convert.ToInt32(consulta.CodPolitica);
            //    cboVendedor.SelectedValue = Convert.ToInt32(consulta.CodUsuarioVendedor);
            //    //txtPlaca.Text = consulta.PlacaVehiculo.ToString();


            //    cargaBdListaPlacas();
            //}

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CodigoEdicion > 0)
            {
                // ActualizarCliente();
                btnGuardar.Enabled = false;

            }
            else
            {


                Registrar();

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

            //if (Convert.ToInt32(cboPolitica.SelectedValue).Equals(0))
            //{
            //    MessageBox.Show("Debe seleccionar una Politica de Precios", "SIGA");
            //    return esValido = false;
            //}

            //if (Convert.ToInt32(cboVendedor.SelectedValue).Equals(0))
            //{
            //    MessageBox.Show("Debe asignar un vendedor", "SIGA");
            //    return esValido = false;
            //}


            return esValido;
        }

        public List<TransportistaPlaca> Lista()
        {
            List<TransportistaPlaca> ListaDocumento = new List<TransportistaPlaca>();

            foreach (DataGridViewRow row in this.dgvPlaca.Rows)
            {
                // Verificar si la fila no es la fila de encabezado

                TransportistaPlaca Item = new TransportistaPlaca();
                Item.CodigoRegistro = Convert.ToInt32(row.Cells[0].Value);
                Item.PlacaAuto = Convert.ToString(row.Cells[1].Value);

                ListaDocumento.Add(Item);
            }
            return ListaDocumento;
        }
        private void Registrar()
        {

            int Codigo = 0;
            TransportistaBusiness objDocumentoBussiness = new TransportistaBusiness();

            try
            {
                if (!ValidarDatos()) return;

                var lstPlacas = Lista();
                Transportista objtransportista = new Transportista()
                {
                    CodTipoDocumento = Convert.ToByte(cboTipoDocumento.SelectedValue),
                    NumDocumentoTransportista = txtNumero.Text,
                    RazSocTransportista = txtRazonSocial.Text,
                    DirTransportista = txtDireccion.Text
                };

                Codigo = objDocumentoBussiness.RegistrarTransportista(objtransportista, lstPlacas);

                if (Codigo> 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    TxtCodigoGenerado.Text = Codigo.ToString();
                    //tbCliente.SelectTab(1);
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

            TransportistaBusiness objCliente = new TransportistaBusiness();
            Nissi.nFact.Entidades.EmpresaBusqueda objEmpresa = new Nissi.nFact.Entidades.EmpresaBusqueda();


            try
            {
                var consulta = objCliente.BuscarPorTipoDocumento(TipoDocumento, txtNumero.Text).SingleOrDefault();

                if (consulta != null)
                {
                    CodigoEdicion = consulta.CodTransportista;
                    TxtCodigoGenerado.Text = consulta.CodTransportista.ToString();
                    cboTipoDocumento.SelectedValue = consulta.CodTipoDocumento;
                    txtNumero.Text = consulta.NumDocumentoTransportista;

                    txtNombre.Text = consulta.RazSocTransportista.ToString();
                    txtDireccion.Text = consulta.DirTransportista.ToString();
                    cboEstado.SelectedValue = "A";
                    
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
