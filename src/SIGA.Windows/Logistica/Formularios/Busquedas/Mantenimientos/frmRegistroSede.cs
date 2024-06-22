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

namespace SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos
{
    public partial class frmRegistroSede : Form
    {

        public Int16 CodigoEdicion;
        public frmRegistroSede()
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistroSede_Load(object sender, EventArgs e)
        {
            CargarEstado();

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

        private void Registrar()
        {
            try
            {
                int Codigo = 0;
                SedeBusiness objDocumentoBussiness = new SedeBusiness();
                Sede objEntidad = new Sede();
                objEntidad.DesSede = TxtDescripcion.Text;
                objEntidad.DirSede = TxtDireccion.Text;
                objEntidad.UsuCre = 1;  // por definir, dato de prueba
                Codigo = objDocumentoBussiness.RegistrarSede(objEntidad);

                if (Codigo > 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    frmMantenimientoSede objManteniento = new frmMantenimientoSede();
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
                SedeBusiness objDocumentoBussiness = new SedeBusiness();
                Sede objEntidad = new Sede();
                objEntidad.CodSede = CodigoEdicion;
                objEntidad.DesSede = TxtDescripcion.Text;
                objEntidad.DirSede =  TxtDireccion.Text ;
                objEntidad.EstCodigo = Convert.ToString(cboEstado.SelectedValue);
                objEntidad.UsuMod = 1;  // por definir, dato de prueba
                Codigo = objDocumentoBussiness.ActualizarSede(objEntidad);

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
            SedeBusiness objSedeBusiness = new SedeBusiness();

            Sede objProveedor = new Sede();
            objProveedor.CodSede = CodigoEdicion;

            var consulta = objSedeBusiness.ObtenerSedePorCodigo(objProveedor);

            TxtCodigo.Text = Convert.ToString(consulta.CodSede);
            TxtDescripcion.Text = consulta.DesSede;
            cboEstado.SelectedValue = consulta.EstCodigo;
            TxtDireccion.Text = Convert.ToString(consulta.DirSede);
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


    }
}
