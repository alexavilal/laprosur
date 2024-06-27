using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios.Mantenimientos
{
    public partial class frmRegProveedor : Form
    {

        List<ProveedorMarca> ListaMarcasGrid = new List<ProveedorMarca>();
        List<ProveedorContacto> ListaContactoGrid = new List<ProveedorContacto>();
        public int CodigoProveedor;

        public frmRegProveedor()
        {
            InitializeComponent();
            tabProveedor.Selected += new TabControlEventHandler(tabProveedor_SelectedIndexChanged);
            this.FormClosing += MyClosedHandler;
        }

        private void tabProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabProveedor.SelectedIndex == 1)
            {
                if (TxtCodigoGenerado.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Debe Ingresar los datos del proveedor", "SIGA");
                    tabProveedor.SelectTab(0);
                }
            }
        }

        private void frmRegProveedor_Load(object sender, EventArgs e)
        {
            CargaTipoDocumento();
            cargaComboMarcas();
            ColumnasGrillaMarca();
            CargarEstado();
            CargarOperador();
            ColumnasGrillaContacto();
            if (CodigoProveedor.Equals(0))
            {
                cboEstado.Enabled = false;
            }
            else
            {
                cboEstado.Enabled = true;
                ObtenerDatosProveedor();
            }
        }


        private void ObtenerDatosProveedor()
        {

            ProveedorBusiness objBLProveedor = new ProveedorBusiness();

            Proveedor objProveedor = new Proveedor();
            objProveedor.ProCodigo = CodigoProveedor;

            var consulta = objBLProveedor.ObtenerProveedor(objProveedor);

            TxtCodigoGenerado.Text = Convert.ToString(consulta.ProCodigo);
            txtRazonSocial.Text = Convert.ToString(consulta.ProRazonSocial);
            txtNombreComercial.Text = Convert.ToString(consulta.ProNombreComercial);
            txtPaginaWeb.Text = Convert.ToString(consulta.ProPaginaWeb);
            txtCorreoElectronico.Text = Convert.ToString(consulta.CorreoElectronico);
            txtDirecion.Text = consulta.Direccion;
            dtpFecha.Text = Convert.ToString(consulta.FecAniProveedor);

            if (consulta.ProConMarca.Equals(1))
            {
                optMarca.Checked = true;
                optSinMarca.Checked = false;
            }
            else
            {
                optMarca.Checked = false;
                optSinMarca.Checked = true;
            }

            cboTipoDocumento.SelectedValue = consulta.CodTipoDocumento;
            txtNumero.Text = Convert.ToString(consulta.NumDocumento);
            cboEstado.SelectedValue = consulta.Estado;

            cargaBdListaMarcas();
            cargaBdListaContactos();
        }

        private void cargaBdListaMarcas()
        {
            ProveedorBusiness objBLProveedor = new ProveedorBusiness();
            ProveedorMarca objProveedorMarca = new ProveedorMarca();
            objProveedorMarca.ProCodigo = CodigoProveedor;

            var ObtenerListaMarcas = objBLProveedor.ObtenerProveedorMarca(objProveedorMarca);

            ListaMarcasGrid = ObtenerListaMarcas;

            dgvMarcas.DataSource = ListaMarcasGrid;
        }

        private void cargaBdListaContactos()
        {
            ProveedorBusiness objBLProveedor = new ProveedorBusiness();
            ProveedorContacto objProveedorContacto = new ProveedorContacto();
            objProveedorContacto.ProCodigo = CodigoProveedor;

            var ObtenerListaContactos = objBLProveedor.ObtenerProveedorContacto(objProveedorContacto);

            ListaContactoGrid = ObtenerListaContactos;

            dgvContactos.DataSource = ListaContactoGrid;
        }

        # region "CargaCombos"

        private void CargaTipoDocumento()
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
        void cargaComboMarcas()
        {
            MarcaBusiness objMarcaBusiness = new MarcaBusiness();

            List<Marca> Lista = new List<Marca>();

            Lista.Add(new Marca { CodMarca = 0, DesMarca = "Seleccione" });

            var consulta = objMarcaBusiness.ListarMarcas();

            foreach (var item in consulta)
            {
                Lista.Add(item);
            }

            cboMarca.DataSource = Lista;
            cboMarca.ValueMember = "CodMarca";
            cboMarca.DisplayMember = "DesMarca";
        }
        void CargarOperador()
        {
            OperadorBusiness objOperador = new OperadorBusiness();

            List<Operador> Lista = new List<Operador>();

            Lista.Add(new Operador { CodOperador = 0, DesOperador = "Seleccione" });

            var consulta = objOperador.ListarOperador();

            foreach (var item in consulta)
            {
                Lista.Add(item);
            }

            cboOperador.DataSource = Lista;
            cboOperador.ValueMember = "CodOperador";
            cboOperador.DisplayMember = "DesOperador";
        }
        #endregion


        private void RegistrarProveedor()
        {
            try
            {
                int Codigo = 0;
                ProveedorBusiness objDocumentoBussiness = new ProveedorBusiness();
                Proveedor objEntidadProveedor = new Proveedor();

                objEntidadProveedor.ProRazonSocial = txtRazonSocial.Text;
                objEntidadProveedor.ProNombreComercial = txtNombreComercial.Text;
                objEntidadProveedor.CodTipoDocumento = Convert.ToByte(cboTipoDocumento.SelectedValue);
                objEntidadProveedor.NumDocumento = txtNumero.Text;
                objEntidadProveedor.ProPaginaWeb = txtPaginaWeb.Text;
                objEntidadProveedor.CorreoElectronico = txtCorreoElectronico.Text;
                objEntidadProveedor.FecAniProveedor = Convert.ToDateTime(dtpFecha.Value);
                objEntidadProveedor.UsuCreCodigo = UsuarioLogeo.Codigo;
                objEntidadProveedor.FecCreacion = DateTime.Now;
                objEntidadProveedor.ProConMarca = (optMarca.Checked) ? Convert.ToByte(1) : Convert.ToByte(0);
                objEntidadProveedor.Direccion = txtDirecion.Text;
                objEntidadProveedor.Estado = "A";

                Codigo = objDocumentoBussiness.RegistrarProveedor(objEntidadProveedor, ListaMarcasGrid);

                if (Codigo > 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    TxtCodigoGenerado.Text = Convert.ToString(Codigo);
                    tabProveedor.SelectTab(1);
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

        private void RegistrarContactoProveedor()
        {
            try
            {
                int Codigo = 0;
                ProveedorBusiness objDocumentoBussiness = new ProveedorBusiness();

                Codigo = objDocumentoBussiness.RegistrarProveedorContacto(ListaContactoGrid);

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

        private void ActualizarProveedor()
        {
            try
            {
                int Codigo = 0;
                ProveedorBusiness objDocumentoBussiness = new ProveedorBusiness();
                Proveedor objEntidadProveedor = new Proveedor();
                objEntidadProveedor.ProCodigo = CodigoProveedor;
                objEntidadProveedor.ProRazonSocial = txtRazonSocial.Text;
                objEntidadProveedor.ProNombreComercial = txtNombreComercial.Text;
                objEntidadProveedor.CodTipoDocumento = Convert.ToByte(cboTipoDocumento.SelectedValue);
                objEntidadProveedor.NumDocumento = txtNumero.Text;
                objEntidadProveedor.ProPaginaWeb = txtPaginaWeb.Text;
                objEntidadProveedor.CorreoElectronico = txtCorreoElectronico.Text;
                objEntidadProveedor.Direccion = txtDirecion.Text;
                objEntidadProveedor.FecAniProveedor = Convert.ToDateTime(dtpFecha.Value);
                objEntidadProveedor.UsuCreCodigo = UsuarioLogeo.Codigo;
                objEntidadProveedor.FecCreacion = DateTime.Now;
                objEntidadProveedor.ProConMarca = (optMarca.Checked) ? Convert.ToByte(1) : Convert.ToByte(0);
                objEntidadProveedor.Estado = Convert.ToString(cboEstado.SelectedValue);

                Codigo = objDocumentoBussiness.ActualizarProveedor(objEntidadProveedor, ListaMarcasGrid, ListaContactoGrid);

                if (Codigo > 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    cargaBdListaContactos();
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
        private void Buscar(int TipoDocumento)
        {

            SIGA.Business.Ventas.ClienteBusiness objCliente = new SIGA.Business.Ventas.ClienteBusiness();
            Nissi.nFact.Entidades.EmpresaBusqueda objEmpresa = new Nissi.nFact.Entidades.EmpresaBusqueda();


            try
            {


                objEmpresa = Nissi.nFact.Servicios.BusquedaRucDni(TipoDocumento, txtNumero.Text);

                if (objEmpresa.Exito.Equals(-1))
                {
                    MessageBox.Show("No se encontro informacion..!");
                    txtRazonSocial.Text = string.Empty;
                    txtDirecion.Text = string.Empty;
                    txtNumero.Focus();

                }
                else
                {
                    if (TipoDocumento.Equals(1))  //RUC
                    {
                        txtRazonSocial.Text = objEmpresa.razonSocial;
                        txtDirecion.Text = objEmpresa.direccion;
                    }

                    if (TipoDocumento.Equals(2))  //DNI
                    {
                        txtRazonSocial.Text = objEmpresa.nombres + " " + objEmpresa.apellidopaterno + " " + objEmpresa.apellidomaterno;
                        txtDirecion.Text = objEmpresa.direccion;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }
        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            SIGA.Business.Logistica.ProveedorBusiness objProveedor = new SIGA.Business.Logistica.ProveedorBusiness();


            if (txtNumero.Text == string.Empty || txtNombreComercial.Text == string.Empty || txtRazonSocial.Text == string.Empty || Convert.ToInt16(cboTipoDocumento.SelectedValue) == 0)
            {
                MessageBox.Show("Debe ingresar datos necesarios...!", "SIGA");
                return;

            }

            var Encontro = false;

            if (CodigoProveedor > 0)
            {
                ActualizarProveedor();
            }
            else
            {
                if (tabProveedor.SelectedIndex == 1)
                {
                    RegistrarContactoProveedor();
                }
                else
                {

                    Encontro = objProveedor.BuscarPorTipoDocumento(Convert.ToInt16(cboTipoDocumento.SelectedValue), txtNumero.Text);

                    if (Encontro == false)
                    {


                        RegistrarProveedor();
                    }
                    else
                    {
                        MessageBox.Show("Existe un proveedor registrado con este tipo de documento y numero", "SIGA");
                    }

                }
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            var codigoMarca = Convert.ToInt16(cboMarca.SelectedValue);
            if (codigoMarca.Equals(0))
            {
                MessageBox.Show("Seleccione una marca valida", "SIGA");
                return;
            }

            AgregarMarca(codigoMarca, cboMarca.Text.ToString());
            cargarListaMarcas();
        }

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            var codigoOperador = Convert.ToInt16(cboOperador.SelectedValue);

            if (codigoOperador.Equals(0))
            {
                MessageBox.Show("Seleccione un operador valido", "SIGA");
                return;
            }

            AgregarContacto(TxtContacto.Text, TxtCargo.Text, TxtArea.Text, cboOperador.Text, TxtNumeroTel.Text, txtCorreo.Text);
            cargarListaContactos();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optMarca_CheckedChanged(object sender, EventArgs e)
        {
            CambiarMarca();
        }

        void cargarListaMarcas()
        {
            dgvMarcas.DataSource = null;
            dgvMarcas.DataSource = ListaMarcasGrid;
        }

        void cargarListaContactos()
        {
            dgvContactos.DataSource = null;
            dgvContactos.DataSource = ListaContactoGrid;
        }

        void AgregarMarca(short codigo, string marca)
        {

            var buscar = ListaMarcasGrid.Where(x => x.CodMarca == Convert.ToInt16(cboMarca.SelectedValue));

            if (buscar.Count() > 0)
            {
                MessageBox.Show("La marca ya existe", "SIGA");
                return;
            }

            ListaMarcasGrid.Add(new ProveedorMarca { CodMarca = codigo, Marca = marca });
        }

        void AgregarContacto(string contacto, string cargo, string area, string operador, string numero, string Correo)
        {
            ListaContactoGrid.Add(new ProveedorContacto
            {
                ProCodigo = Convert.ToInt32(TxtCodigoGenerado.Text),
                CodOperador = Convert.ToInt16(cboOperador.SelectedValue),
                NomProveedorContacto = contacto,
                CarProveedorContacto = cargo,
                Operador = operador,
                AreProveedorContacto = area,
                NumTelProveedorContacto = numero,
                CorreoElectronico = Correo,
                UsuCreCodigo = UsuarioLogeo.Codigo
            });
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.RowCount > 0)
            {
                var codigo = Convert.ToString(dgvMarcas[0, dgvMarcas.CurrentRow.Index].Value);

                if (CodigoProveedor > 0)
                {
                    ProveedorBusiness objDocumentoBussiness = new ProveedorBusiness();
                    ProveedorMarca objEntidadProveedorMarca = new ProveedorMarca();
                    objEntidadProveedorMarca.CodMarca = Convert.ToInt16(codigo);
                    objEntidadProveedorMarca.ProCodigo = CodigoProveedor;

                    objDocumentoBussiness.EliminarProveedorMarca(objEntidadProveedorMarca);

                    cargaBdListaMarcas();
                }
                else
                {
                    ListaMarcasGrid.RemoveAll(s => s.CodMarca == Convert.ToInt16(codigo));
                }

                cargarListaMarcas();
            }
        }

        private void btnQuitarContacto_Click(object sender, EventArgs e)
        {
            if (dgvContactos.RowCount > 0)
            {
                var codigo = Convert.ToString(dgvContactos[0, dgvContactos.CurrentRow.Index].Value);
                var nombre = Convert.ToString(dgvContactos[1, dgvContactos.CurrentRow.Index].Value);
                var CodProveedorContacto = Convert.ToString(dgvContactos[6, dgvContactos.CurrentRow.Index].Value);

                if (CodigoProveedor > 0 && Convert.ToInt32(CodProveedorContacto) > 0)
                {
                    ProveedorBusiness objDocumentoBussiness = new ProveedorBusiness();
                    ProveedorContacto objEntidadProveedorContacto = new ProveedorContacto();
                    objEntidadProveedorContacto.ProCodigo = CodigoProveedor;
                    objEntidadProveedorContacto.CodProveedorContacto = Convert.ToInt32(CodProveedorContacto);
                    objDocumentoBussiness.EliminarProveedorContacto(objEntidadProveedorContacto);

                    cargaBdListaContactos();
                }
                else
                {
                    ListaContactoGrid.RemoveAll(s => s.CodOperador == Convert.ToInt16(codigo) && s.NomProveedorContacto == nombre);
                    cargarListaContactos();
                }
            }
        }

        void CambiarMarca()
        {
            if (optMarca.Checked)
            {
                cboMarca.Enabled = true;
            }
            else
            {
                cboMarca.Enabled = false;
                dgvMarcas.DataSource = null;
                ListaMarcasGrid = null;
                ListaMarcasGrid = new List<ProveedorMarca>();
            }
        }

        void ColumnasGrillaMarca()
        {
            dgvMarcas.ReadOnly = true;

            dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarcas.MultiSelect = false;

            dgvMarcas.AutoGenerateColumns = false;
            dgvMarcas.ColumnCount = 2;

            dgvMarcas.Columns[0].Name = "Codigo";
            dgvMarcas.Columns[0].HeaderText = "Codigo";
            dgvMarcas.Columns[0].DataPropertyName = "CodMarca";
            dgvMarcas.Columns[0].Width = 90;

            dgvMarcas.Columns[1].HeaderText = "Marca";
            dgvMarcas.Columns[1].Name = "Marca";
            dgvMarcas.Columns[1].DataPropertyName = "Marca";
            dgvMarcas.Columns[1].Width = 150;

        }

        void ColumnasGrillaContacto()
        {
            dgvContactos.ReadOnly = true;

            dgvContactos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContactos.MultiSelect = false;

            dgvContactos.AutoGenerateColumns = false;
            dgvContactos.ColumnCount = 8;

            dgvContactos.Columns[0].Name = "CodOperador";
            dgvContactos.Columns[0].HeaderText = "CodOperador";
            dgvContactos.Columns[0].DataPropertyName = "CodOperador";
            dgvContactos.Columns[0].Width = 150;
            dgvContactos.Columns[0].Visible = false;

            dgvContactos.Columns[1].Name = "Contacto";
            dgvContactos.Columns[1].HeaderText = "Contacto";
            dgvContactos.Columns[1].DataPropertyName = "NomProveedorContacto";
            dgvContactos.Columns[1].Width = 150;

            dgvContactos.Columns[2].HeaderText = "Cargo";
            dgvContactos.Columns[2].Name = "Cargo";
            dgvContactos.Columns[2].DataPropertyName = "CarProveedorContacto";
            dgvContactos.Columns[2].Width = 150;

            dgvContactos.Columns[3].HeaderText = "Area";
            dgvContactos.Columns[3].Name = "Area";
            dgvContactos.Columns[3].DataPropertyName = "AreProveedorContacto";
            dgvContactos.Columns[3].Width = 150;

            dgvContactos.Columns[4].HeaderText = "Operador";
            dgvContactos.Columns[4].Name = "Operador";
            dgvContactos.Columns[4].DataPropertyName = "Operador";
            dgvContactos.Columns[4].Width = 150;

            dgvContactos.Columns[5].HeaderText = "Numero";
            dgvContactos.Columns[5].Name = "Numero";
            dgvContactos.Columns[5].DataPropertyName = "NumTelProveedorContacto";
            dgvContactos.Columns[5].Width = 100;

            dgvContactos.Columns[6].HeaderText = "CodProveedorContacto";
            dgvContactos.Columns[6].Name = "CodProveedorContacto";
            dgvContactos.Columns[6].DataPropertyName = "CodProveedorContacto";
            dgvContactos.Columns[6].Visible = false;


            dgvContactos.Columns[7].HeaderText = "Correo";
            dgvContactos.Columns[7].Name = "CorreoElectronico";
            dgvContactos.Columns[7].DataPropertyName = "CorreoElectronico";
            dgvContactos.Columns[7].Visible = true;
        }

        private void optSinMarca_CheckedChanged(object sender, EventArgs e)
        {
            CambiarMarca();
        }


        public bool EvaluarlLlenadoGrilla()
        {
            bool Evaluar = false;

            if (dgvContactos.RowCount > 0)
            {
                Evaluar = true;

            }

            return Evaluar;

        }

        //private void frmRegProveedor_FormClosing(object sender, EventArgs e)
        //{

        //    bool Evaluado = EvaluarlLlenadoGrilla();

        //    if (Evaluado == false)
        //    {
        //        MessageBox.Show("La marca ya existe", "SIGA");
        //    }

        //}

        protected void MyClosedHandler(object sender, EventArgs e)
        {

            bool Evaluado = EvaluarlLlenadoGrilla();

            if (Evaluado == false)
            {
                MessageBox.Show("Debe ingresar un contacto..", "SIGA");
            }

        }

        private void frmRegProveedor_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text. 
            //if (textBox1.Text != strMyOriginalText)
            //{
            //    // Display a MsgBox asking the user to save changes or abort. 
            //    if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
            //       MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        // Cancel the Closing event from closing the form.
            //        e.Cancel = true;
            //        // Call method to save file...
            //    }
            //}
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
    }
}
