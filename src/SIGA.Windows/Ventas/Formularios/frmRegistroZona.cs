using SIGA.Business.Administrador;
using SIGA.Business.Ventas;
using SIGA.Entities.Administrador;
using SIGA.Entities.Ventas;
using SIGA.Windows.Administrador;
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
    public partial class frmRegistroZona : Form
    {
        public int CodigoEdicion;
        public frmRegistroZona()
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

        private void Registrar()
        {
            int Codigo = 0;
            ZonaBusiness objZonaBussiness = new ZonaBusiness();
            Zona objEntidad = new Zona();


            try
            {
                
                
                objEntidad.Descripcion = TxtDescripcion.Text;
                objEntidad.Usuario = 1;  // por definir, dato de prueba
                objEntidad.Estado = Convert.ToString(cboEstado.SelectedValue).Substring(0, 1);
                Codigo = objZonaBussiness.RegistrarZona(objEntidad);

                if (Codigo >= 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    frmMantenimientoZona objManteniento = new frmMantenimientoZona();
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
                ZonaBusiness objDocumentoBussiness = new ZonaBusiness();
                Modulo objEntidad = new Modulo();
                objEntidad.CodigoModulo = CodigoEdicion;
                objEntidad.DescripcionModulo = TxtDescripcion.Text;
                objEntidad.EstadoModulo = Convert.ToString(cboEstado.SelectedValue).Substring(0,1);
                objEntidad.UsuModifica = UsuarioLogeo.Codigo;  // por definir, dato de prueba
                Codigo = objDocumentoBussiness.ActualizarModulo(objEntidad);

                if (Codigo >= 0)
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

        private void frmRegistroZona_Load(object sender, EventArgs e)
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
            ZonaBusiness objPoliticaBusiness = new ZonaBusiness();

            Zona objZona = new Zona()
            {
                IdZona = CodigoEdicion,
                Descripcion = string.Empty,
                Estado = string.Empty
            };

            try
            {

                var consulta = objPoliticaBusiness.ObtenerZonas(objZona).SingleOrDefault();

                if (consulta != null)
                {
                    TxtCodigo.Text = Convert.ToString(consulta.IdZona);
                    TxtDescripcion.Text = consulta.Descripcion;
                    cboEstado.SelectedValue = consulta.Estado.Substring(0, 1);
                }

            }
            catch (Exception ex)
            {

            }
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
