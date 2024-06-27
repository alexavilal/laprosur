using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos
{
    public partial class frmRegistroAlmacen : Form
    {
        public Int16 CodigoEdicion;

        public frmRegistroAlmacen()
        {
            InitializeComponent();
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

        private void frmRegistroAlmacen_Load(object sender, EventArgs e)
        {
            CargarEstado();
            ListarSedes();

            if (CodigoEdicion.Equals(0))
            {
                cboEstado.Enabled = false;
            }
            else
            {
                cboEstado.Enabled = true;
                ObtenerDatos();
            }
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
                AlmacenBusiness objDocumentoBussiness = new AlmacenBusiness();
                Almacen objEntidad = new Almacen();
                objEntidad.DesAlmacen = TxtDescripcion.Text;
                objEntidad.CodSede = Convert.ToInt16(cboSede.SelectedValue);
                objEntidad.UsuCre = 1;  // por definir, dato de prueba
                Codigo = objDocumentoBussiness.RegistrarAlmacen(objEntidad);

                if (Codigo > 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    frmMantenimientoAlmacen objManteniento = new frmMantenimientoAlmacen();
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
                AlmacenBusiness objDocumentoBussiness = new AlmacenBusiness();
                Almacen objEntidad = new Almacen();
                objEntidad.CodAlmacen = CodigoEdicion;
                objEntidad.DesAlmacen = TxtDescripcion.Text;
                objEntidad.CodSede = Convert.ToInt16(cboSede.SelectedValue);
                objEntidad.Estado = Convert.ToString(cboEstado.SelectedValue);
                objEntidad.UsuMod = 1;  // por definir, dato de prueba
                Codigo = objDocumentoBussiness.ActualizarAlmacen(objEntidad);

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
            AlmacenBusiness objAlmacenBusiness = new AlmacenBusiness();

            Almacen objProveedor = new Almacen();
            objProveedor.CodAlmacen = CodigoEdicion;

            var consulta = objAlmacenBusiness.ObtenerAlmacenPorCodigo(objProveedor);

            TxtCodigo.Text = Convert.ToString(consulta.CodAlmacen);
            TxtDescripcion.Text = consulta.DesAlmacen;
            cboEstado.SelectedValue = consulta.Estado;
            cboSede.SelectedValue = consulta.CodSede;
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

        void ListarSedes()
        {
            SedeBusiness objBusiness = new SedeBusiness();
            Sede objSede = new Sede();
            objSede.CodSede = 0;
            objSede.DesSede = string.Empty;
            objSede.DirSede = string.Empty;
            objSede.EstCodigo = "A";

            cboSede.DataSource = objBusiness.ObtenerSedes(objSede); ;
            cboSede.ValueMember = "CodSede";
            cboSede.DisplayMember = "DesSede";
        }






    }
}
