using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SIGA.Business.Administrador;
using SIGA.Entities.Administrador;

namespace SIGA.Windows.Administrador
{
    public partial class FrmRegistroModulo : Form
    {
        public Int16 CodigoEdicion;

        public FrmRegistroModulo()
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

        private void Registrar()
        {
            try
            {
                int Codigo = 0;
                ModuloBusiness objDocumentoBussiness = new ModuloBusiness();
                Modulo objEntidad = new Modulo();               
                objEntidad.DescripcionModulo = TxtDescripcion.Text;               
                objEntidad.UsuCreacion  = 1;  // por definir, dato de prueba
                Codigo = objDocumentoBussiness.RegistrarModulo(objEntidad);

                if (Codigo > 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    FrmMantenimientoModulo objManteniento = new FrmMantenimientoModulo();
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
                ModuloBusiness objDocumentoBussiness = new ModuloBusiness();
                Modulo objEntidad  = new Modulo();
                objEntidad.CodigoModulo = CodigoEdicion;
                objEntidad.DescripcionModulo = TxtDescripcion.Text;
                objEntidad.EstadoModulo = Convert.ToString(cboEstado.SelectedValue);
                objEntidad.UsuModifica = 1;  // por definir, dato de prueba
                Codigo = objDocumentoBussiness.ActualizarModulo(objEntidad);

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

        
        private void FrmRegistroModulo_Load(object sender, EventArgs e)
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

        private void ObtenerDatos()
        {
            ModuloBusiness objModuloBusiness = new ModuloBusiness();

            Modulo objProveedor = new Modulo();
            objProveedor.CodigoModulo = CodigoEdicion;

            var consulta = objModuloBusiness.ObtenerModuloPorCodigo(objProveedor);

            TxtCodigo.Text = Convert.ToString(consulta.CodigoModulo);
            TxtDescripcion.Text = consulta.DescripcionModulo ;
            cboEstado.SelectedValue=  consulta.EstadoModulo;  
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
