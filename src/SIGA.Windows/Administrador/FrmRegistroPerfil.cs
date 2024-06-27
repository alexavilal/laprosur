using SIGA.Business.Administrador;
using SIGA.Entities.Administrador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SIGA.Windows.Administrador
{
    public partial class FrmRegistroPerfil : Form
    {
        public Int16 CodigoEdicion;
        List<OpcionPerfil> ListaOpciones;
        List<Modulo> ListaModulosChk;
        List<OpcionPerfil> ListaOpcionesPerfilChk;
        List<OpcionPerfil> ListaOpcionesPerfilEditChk;

        public FrmRegistroPerfil()
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

        private void FrmRegistroPerfil_Load(object sender, EventArgs e)
        {
            CargarEstado();
            ListarModulos();
            BuscarOpciones(0, 0, "N");

            if (CodigoEdicion.Equals(0))
            {
                cboEstado.Enabled = false;
            }
            else
            {
                cboEstado.Enabled = true;
                BuscarOpciones(CodigoEdicion, 0, "E");
                ObtenerDatos();
            }

            BuscarModulosTreeView();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registrar()
        {
            try
            {
                int Codigo = 0;
                PerfilBusiness objDocumentoBussiness = new PerfilBusiness();
                Perfil objEntidad = new Perfil();
                objEntidad.DesPerfil = TxtDescripcion.Text;
                objEntidad.UsuCreacion = 1;  // por definir, dato de prueba

                ObtenerListaPerfilesCheck();

                Codigo = objDocumentoBussiness.RegistrarPerfil(objEntidad, ListaOpciones);

                if (Codigo > 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    FrmMantenimientoPerfil objManteniento = new FrmMantenimientoPerfil();
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

        private void Actualizar()
        {
            try
            {
                int Codigo = 0;
                PerfilBusiness objDocumentoBussiness = new PerfilBusiness();
                Perfil objEntidad = new Perfil();
                objEntidad.CodPerfil = CodigoEdicion;
                objEntidad.DesPerfil = TxtDescripcion.Text;
                objEntidad.EstadoPerfil = Convert.ToString(cboEstado.SelectedValue);
                objEntidad.UsuModifica = 1;  // por definir, dato de prueba

                ObtenerListaPerfilesCheck();
                OpcionPerfil objPerfilUsuario = new OpcionPerfil();
                objPerfilUsuario.CodPerfil = Convert.ToInt16(TxtCodigo.Text);

                Codigo = objDocumentoBussiness.ActualizarPerfil(objEntidad, ListaOpciones, objPerfilUsuario);

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
            PerfilBusiness objModuloBusiness = new PerfilBusiness();

            Perfil objProveedor = new Perfil();
            objProveedor.CodPerfil = CodigoEdicion;

            var consulta = objModuloBusiness.ObtenerModuloPorCodigo(objProveedor);

            TxtCodigo.Text = Convert.ToString(consulta.CodPerfil);
            TxtDescripcion.Text = consulta.DesPerfil;
            cboEstado.SelectedValue = consulta.EstadoPerfil;
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

        void ObtenerListaPerfilesCheck()
        {
            ListaOpciones = new List<OpcionPerfil>();

            foreach (TreeNode Nodes in TvPerfil.Nodes)
            {
                foreach (TreeNode childNode in Nodes.Nodes)
                {
                    if (childNode.Checked)
                    {
                        OpcionPerfil objPerfilUsuario = new OpcionPerfil();
                        objPerfilUsuario.CodPerfil = string.IsNullOrEmpty(TxtCodigo.Text) ? Convert.ToInt16(0) : Convert.ToInt16(TxtCodigo.Text);
                        objPerfilUsuario.CodOpcion = Convert.ToInt16(childNode.Tag);
                        objPerfilUsuario.UsuCreacion = 1;  // por definir, dato de prueba     
                        ListaOpciones.Add(objPerfilUsuario);
                    }
                }
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void TvPerfil_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }

        public void ListarModulos()
        {
            ModuloBusiness objBusiness = new ModuloBusiness();
            Modulo objModulo = new Modulo();
            objModulo.DescripcionModulo = string.Empty;
            objModulo.EstadoModulo = "A";
            ListaModulosChk = new List<Modulo>();
            ListaModulosChk = objBusiness.ObtenerModulos(objModulo);
        }

        public void BuscarOpciones(Int16 CodPerfil, Int16 CodModulo, string flag)
        {
            PerfilBusiness objBusiness = new PerfilBusiness();
            OpcionPerfil objOpcionPerfil = new OpcionPerfil();

            objOpcionPerfil.CodPerfil = CodPerfil;
            objOpcionPerfil.CodModulo = CodModulo;

            if (flag.Equals("N"))
            {
                ListaOpcionesPerfilChk = objBusiness.ObtenerOpcionesPerfil(objOpcionPerfil);
            }
            else
            {
                ListaOpcionesPerfilEditChk = objBusiness.ObtenerOpcionesPerfil(objOpcionPerfil);
            }
        }

        public void BuscarModulosTreeView()
        {
            PerfilBusiness objBusinessPerfil = new PerfilBusiness();

            TvPerfil.CheckBoxes = true;

            TreeNode parentNode = null;
            TreeNode childNode = null;

            foreach (var item in ListaModulosChk)
            {
                parentNode = TvPerfil.Nodes.Add(item.DescripcionModulo.ToString());

                var opcionesPerfiles = ListaOpcionesPerfilChk.Where(x => x.CodModulo == item.CodigoModulo && x.CodPerfil == 0);

                if (opcionesPerfiles == null) continue;

                if (CodigoEdicion.Equals(0))
                {
                    foreach (var opciones in opcionesPerfiles)
                    {
                        childNode = new TreeNode(opciones.DesOpcion.ToString());
                        childNode.Tag = opciones.CodOpcion.ToString();
                        parentNode.Nodes.Add(childNode);
                    }
                }
                else
                {
                    foreach (var opciones in opcionesPerfiles)
                    {
                        var editOpcionesPerfil = ListaOpcionesPerfilEditChk.Where(x => x.CodModulo == item.CodigoModulo && x.CodOpcion == opciones.CodOpcion).FirstOrDefault(); ;

                        childNode = new TreeNode(opciones.DesOpcion.ToString());
                        childNode.Tag = opciones.CodOpcion.ToString();

                        if (editOpcionesPerfil != null)
                        {
                            childNode.Checked = Convert.ToInt16(editOpcionesPerfil.CodOpcion) > 0 ? true : false;
                        }
                        parentNode.Nodes.Add(childNode);
                    }
                }

            }

            TvPerfil.ExpandAll();
        }

    }
}
