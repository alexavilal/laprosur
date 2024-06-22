using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SIGA.Business.Administrador;
using SIGA.Entities.Administrador;

namespace SIGA.Windows.Administrador
{
    public partial class FrmRegistroOpciones : Form
    {
        public Int16 CodigoEdicion;

        public FrmRegistroOpciones()
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void Registrar()
        {
            try
            {
                int Codigo = 0;
                OpcionBusiness objDocumentoBussiness = new OpcionBusiness();
                Opcion objEntidad = new Opcion();
                objEntidad.CodModulo = Convert.ToInt16(CboModulo.SelectedValue); 
                objEntidad.DesOpcion = TxtDescripcion.Text;
                objEntidad.RutOpcion = TxtRuta.Text; 
                objEntidad.UsuCre = UsuarioLogeo.Codigo;  // por definir, dato de prueba 

                Codigo = objDocumentoBussiness.RegistrarOpcion(objEntidad);

                if (Codigo > 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    //FrmMantenimientoUsuario objManteniento = new FrmMantenimientoUsuario();
                    //objManteniento.Buscar();
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
                OpcionBusiness objDocumentoBussiness = new OpcionBusiness();
                Opcion objEntidad = new Opcion();

                objEntidad.CodModulo = Convert.ToInt16(CboModulo.SelectedValue);  
                objEntidad.CodOpcion = CodigoEdicion;
                objEntidad.DesOpcion = TxtDescripcion.Text;
                objEntidad.RutOpcion = TxtRuta.Text; 
                objEntidad.UsuMod = UsuarioLogeo.Codigo;  // por definir, dato de prueba
                objEntidad.EstCodigo = Convert.ToString(CboEstado.SelectedValue);


                Codigo = objDocumentoBussiness.ActualizarOpcion(objEntidad);

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
            OpcionBusiness objDocumentoBussiness = new OpcionBusiness();
            Opcion objEntidad = new Opcion();
            objEntidad.CodOpcion = CodigoEdicion;

            var consulta = objDocumentoBussiness.ObtenerOpcionPorCodigo(objEntidad);

            TxtCodigo.Text = Convert.ToString(consulta.CodOpcion);
            CboModulo.SelectedValue = consulta.CodModulo;
            TxtDescripcion.Text = consulta.DesOpcion;
            TxtRuta.Text = consulta.RutOpcion;          
            CboEstado.SelectedValue = consulta.EstCodigo;
        }

        void ListarModulos()
        {
            ModuloBusiness objBusiness = new ModuloBusiness();
            Modulo objModulo = new Modulo();
            objModulo.DescripcionModulo = string.Empty;
            objModulo.EstadoModulo = "A";

            CboModulo.DataSource = objBusiness.ObtenerModulos(objModulo);
            CboModulo.ValueMember = "CodigoModulo";
            CboModulo.DisplayMember = "DescripcionModulo"; 

        }

        private void FrmRegistroOpciones_Load(object sender, EventArgs e)
        {
            CargarEstado();
            ListarModulos();

            if (CodigoEdicion.Equals(0))
            {
                CboEstado.Enabled = false;
            }
            else
            {
                CboEstado.Enabled = true;
                ObtenerDatos();
            }            
        }

        

    }
}
