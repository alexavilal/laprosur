using SIGA.Business.Administrador;
using SIGA.Entities.Administrador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SIGA.Windows.Administrador
{
    public partial class frmRegistroUsuario : Form
    {
        public Int16 CodigoEdicion;
        List<PerfilUsuario> ListaPerfilUsuario;
        List<PerfilUsuario> ListaPerfilUsuarioCheck;

        public frmRegistroUsuario()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(173, 216, 230);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (CodigoEdicion.Equals(0))
            {
                Registrar();
            }
            else
            {
                Actualizar();
            }
        }

        void CargarEstado()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

            data.Add(new KeyValuePair<string, string>("A", "Activo"));
            data.Add(new KeyValuePair<string, string>("I", "Inactivo"));

            CboEstado.DataSource = null;
            CboEstado.Items.Clear();

            CboEstado.DataSource = new BindingSource(data, null);
            CboEstado.DisplayMember = "Value";
            CboEstado.ValueMember = "Key";
        }


        void CargarTipoDocumento()
        {
            List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();

            data.Add(new KeyValuePair<int, string>(1, "DNI"));
            data.Add(new KeyValuePair<int, string>(2, "C.E"));
            data.Add(new KeyValuePair<int, string>(3, "Pasaporte"));


            cboTipoDocumento.DataSource = null;
            cboTipoDocumento.Items.Clear();

            cboTipoDocumento.DataSource = new BindingSource(data, null);
            cboTipoDocumento.DisplayMember = "Value";
            cboTipoDocumento.ValueMember = "Key";
        }

        void CargaCargo()
        {
            SIGA.Business.Administrador.CargoBusiness objCargo = new SIGA.Business.Administrador.CargoBusiness();

            var result = objCargo.ObtenerCargo();

            cboCargo.DataSource = result;
            cboCargo.ValueMember = "Codigo";
            cboCargo.DisplayMember = "Descripcion";

        }

        private void frmRegistroUsuario_Load(object sender, EventArgs e)
        {
            CargarEstado();
            CargarTipoDocumento();
            CargaCargo();
            ColumnasGrilla();
            lblClave.Visible = false;

            if (CodigoEdicion.Equals(0))
            {
                CboEstado.Enabled = false;
            }
            else
            {
                CboEstado.Enabled = true;
                BuscarPerfilesPorCodigo(CodigoEdicion);
                ObtenerDatos();
            }

            BuscarPerfiles();
            TxtAp.Focus();

        }

        private void Registrar()
        {
            try
            {
                int Codigo = 0;
                UsuarioBusiness objDocumentoBussiness = new UsuarioBusiness();
                SIGA.Entities.Administrador.Usuario objEntidad = new SIGA.Entities.Administrador.Usuario();
                objEntidad.ApellidoPaterno = TxtAp.Text;
                objEntidad.ApellidoMaterno = TxtAm.Text;
                objEntidad.Nombre = TxtNombre.Text;
                objEntidad.IdentificadorUsuario = TxtUsuario.Text;
                objEntidad.CorreoElectronico = TxtCorreo.Text;
                objEntidad.Clave = TxtClave.Text;
                objEntidad.UsuarioRegistro = UsuarioLogeo.Codigo;  // por definir, dato de prueba
                objEntidad.CodTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                objEntidad.NumeroDocumento = txtNumero.Text;
                objEntidad.CodCargo = Convert.ToInt32(cboCargo.SelectedValue);



                //if (objDocumentoBussiness.ValidarClave(objEntidad) >= 1)
                //{
                //    MessageBox.Show("Esta contraseña ya esta registrada", "SIGA");
                //    return;
                //}


                if (objDocumentoBussiness.ValidarUsuario(objEntidad) >= 1)
                {
                    MessageBox.Show("Ya existe esta cuenta de usuario", "SIGA");
                    return;
                }



                if (!validarEmail(TxtCorreo.Text.Trim()))
                {
                    MessageBox.Show("El correo ingresado no es valido", "SIGA");
                    return;
                }

                if (ValidarCheckPerfilesUsusario() == 0)
                {
                    MessageBox.Show("Debe seleccionar un perfil", "SIGA");
                    return;
                }

                ObtenerListaPerfilesCheck();

                Codigo = objDocumentoBussiness.RegistrarUsuario(objEntidad, ListaPerfilUsuario);

                if (Codigo > 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    FrmMantenimientoUsuario objManteniento = new FrmMantenimientoUsuario();
                    objManteniento.Buscar();
                    this.Close();
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

        public int ValidarCheckPerfilesUsusario()
        {
            int ChekList = 0;

            foreach (DataGridViewRow row in DgvPerfiles.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chkSel"].Value) == true)
                {
                    ChekList++;
                }
            }

            return ChekList;
        }

        void ObtenerListaPerfilesCheck()
        {
            ListaPerfilUsuario = new List<PerfilUsuario>();

            foreach (DataGridViewRow row in DgvPerfiles.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[2];
                if (Convert.ToBoolean(chk.Value))
                {
                    PerfilUsuario objPerfilUsuario = new PerfilUsuario();
                    objPerfilUsuario.CodPerfil = (Int16)row.Cells["CodPerfil"].Value;
                    objPerfilUsuario.UsuCreacion = UsuarioLogeo.Codigo;  // por definir, dato de prueba                   
                    ListaPerfilUsuario.Add(objPerfilUsuario);
                }
            }
        }

        private void Actualizar()
        {
            try
            {
                int Codigo = 0;
                UsuarioBusiness objDocumentoBussiness = new UsuarioBusiness();
                SIGA.Entities.Administrador.Usuario objEntidad = new SIGA.Entities.Administrador.Usuario();

                objEntidad.CodigoUsuario = CodigoEdicion;
                objEntidad.ApellidoPaterno = TxtAp.Text;
                objEntidad.ApellidoMaterno = TxtAm.Text;
                objEntidad.Nombre = TxtNombre.Text;
                objEntidad.IdentificadorUsuario = TxtUsuario.Text.Trim();
                objEntidad.CorreoElectronico = TxtCorreo.Text;
                objEntidad.Clave = TxtClave.Text;
                objEntidad.UsuarioUltimaModificacion = UsuarioLogeo.Codigo;  // por definir, dato de prueba
                objEntidad.CodigoEstadoUsuario = Convert.ToString(CboEstado.SelectedValue);
                objEntidad.CodTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                objEntidad.NumeroDocumento = txtNumero.Text;
                objEntidad.CodCargo = Convert.ToInt32(cboCargo.SelectedValue);

                if (TxtClave.Text != lblClave.Text)
                {
                    if (objDocumentoBussiness.ValidarClave(objEntidad) >= 1)
                    {
                        MessageBox.Show("Ya existe esta contraseña", "SIGA");
                        return;
                    }

                }

                if (!validarEmail(TxtCorreo.Text.Trim()))
                {
                    MessageBox.Show("El correo ingresado no es valido", "SIGA");
                    return;
                }

                if (ValidarCheckPerfilesUsusario() == 0)
                {
                    MessageBox.Show("Debe seleccionar un perfil", "SIGA");
                    return;
                }

                ObtenerListaPerfilesCheck();

                Codigo = objDocumentoBussiness.ActualizarUsuario(objEntidad, ListaPerfilUsuario);

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

            this.Close();
        }

        private void ObtenerDatos()
        {
            UsuarioBusiness objModuloBusiness = new UsuarioBusiness();

            SIGA.Entities.Administrador.Usuario objUsuario = new SIGA.Entities.Administrador.Usuario();
            objUsuario.CodigoUsuario = CodigoEdicion;

            var consulta = objModuloBusiness.ObtenerUsuarioPorCodigo(objUsuario);

            TxtCodigo.Text = Convert.ToString(consulta.CodigoUsuario);
            TxtAp.Text = consulta.ApellidoPaterno;
            TxtAm.Text = consulta.ApellidoMaterno;
            TxtNombre.Text = consulta.Nombre;
            TxtUsuario.Text = consulta.IdentificadorUsuario;
            TxtClave.Text = consulta.Clave;
            TxtCorreo.Text = consulta.CorreoElectronico;
            CboEstado.SelectedValue = consulta.CodigoEstadoUsuario;
            lblClave.Text = consulta.Clave;
            cboTipoDocumento.SelectedValue = consulta.CodTipoDocumento;
            txtNumero.Text = consulta.NumeroDocumento;
            cboCargo.SelectedValue = consulta.CodCargo;

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private Boolean validarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public void ColumnasGrilla()
        {
            DgvPerfiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvPerfiles.MultiSelect = false;

            DgvPerfiles.AutoGenerateColumns = false;
            DgvPerfiles.ColumnCount = 2;

            DgvPerfiles.Columns[0].Name = "Perfil";
            DgvPerfiles.Columns[0].HeaderText = "DesPerfil";
            DgvPerfiles.Columns[0].DataPropertyName = "DesPerfil";
            DgvPerfiles.Columns[0].Width = 300;
            DgvPerfiles.Columns[0].ReadOnly = true;

            DgvPerfiles.Columns[1].Name = "CodPerfil";
            DgvPerfiles.Columns[1].HeaderText = "CodPerfil";
            DgvPerfiles.Columns[1].DataPropertyName = "CodPerfil";
            DgvPerfiles.Columns[1].Width = 100;
            DgvPerfiles.Columns[1].Visible = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            DgvPerfiles.Columns.Add(chk);
            chk.HeaderText = "Seleccionar";
            chk.Name = "chkSel";
            chk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        public void BuscarPerfiles()
        {
            PerfilBusiness objBusiness = new PerfilBusiness();
            PerfilUsuario objModulo = new PerfilUsuario();
            objModulo.UsuCodigo = Convert.ToInt16(0);
            this.DgvPerfiles.DataSource = objBusiness.ObtenerPerfilesUsuarioPorCodigo(objModulo);
        }

        public void BuscarPerfilesPorCodigo(int UsuCodigo)
        {
            PerfilBusiness objBusiness = new PerfilBusiness();
            PerfilUsuario objModulo = new PerfilUsuario();
            objModulo.UsuCodigo = Convert.ToInt16(UsuCodigo);
            ListaPerfilUsuarioCheck = new List<PerfilUsuario>();
            ListaPerfilUsuarioCheck = objBusiness.ObtenerPerfilesUsuarioPorCodigo(objModulo);
        }

        private void DgvPerfiles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (ListaPerfilUsuarioCheck != null)
            {
                foreach (DataGridViewRow row in DgvPerfiles.Rows)
                {
                    Int16 CodPerfil = (Int16)row.Cells["CodPerfil"].Value;

                    var ResBusqueda = ListaPerfilUsuarioCheck.Where(x => x.CodPerfil.Equals(CodPerfil)).FirstOrDefault();

                    if (ResBusqueda != null)
                    {
                        if (Convert.ToInt16(ResBusqueda.CodPerfil) > 0)
                        {
                            row.Cells[2].Value = true;
                        }
                        else
                        {
                            row.Cells[2].Value = false;
                        }
                    }
                }
            }
        }

    }
}
