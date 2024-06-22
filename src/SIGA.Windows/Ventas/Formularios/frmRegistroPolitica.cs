using SIGA.Business.Ventas;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmRegistroPolitica : Form
    {
        public int CodigoEdicion;
        public frmRegistroPolitica()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(173, 216, 230);
        }

        private void frmRegistroPolitica_Load(object sender, EventArgs e)
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
            PoliticaPrecioBusiness objPoliticaPrecioBussiness = new PoliticaPrecioBusiness();
            try
            {
                int Codigo = 0;
               
                PoliticaPrecio objEntidad = new PoliticaPrecio();
                objEntidad.DesPolitica = TxtDescripcion.Text;
                objEntidad.EstCodigo = cboEstado.Text.Substring(0, 1);
                objEntidad.UsuCreCodigo = UsuarioLogeo.Codigo;  // por definir, dato de prueba
                Codigo = objPoliticaPrecioBussiness.Ingresa(objEntidad);

                if (Codigo > 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    frmMantenimientoPolitica objManteniento = new frmMantenimientoPolitica();
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
            PoliticaPrecioBusiness objPoliticaPrecioBussiness = new PoliticaPrecioBusiness();
            try
            {
                PoliticaPrecio objEntidad = new PoliticaPrecio()
                { CodPolitica = CodigoEdicion,
                    DesPolitica = TxtDescripcion.Text,
                    EstCodigo = cboEstado.Text.Substring(0, 1),
                    UsuCreCodigo = UsuarioLogeo.Codigo
                };

                var result = objPoliticaPrecioBussiness.ActualizarPolitica(objEntidad);
                if (result.Equals(0)){
                    MessageBox.Show("Se actualizo la politica", "SIGA");
                    this.Close();
                }

            }
            catch(Exception ex) 
            { 
            }

            //try
            //{
            //    int Codigo = 0;
            //    ModuloBusiness objDocumentoBussiness = new ModuloBusiness();
            //    Modulo objEntidad = new Modulo();
            //    objEntidad.CodigoModulo = CodigoEdicion;
            //    objEntidad.DescripcionModulo = TxtDescripcion.Text;
            //    objEntidad.EstadoModulo = Convert.ToString(cboEstado.SelectedValue);
            //    objEntidad.UsuModifica = 1;  // por definir, dato de prueba
            //    Codigo = objDocumentoBussiness.ActualizarModulo(objEntidad);

            //    if (Codigo > 0)
            //    {
            //        MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se pudo realizar la operación", "SIGA");
            //    }
            //}
            //catch (Exception)
            //{
            //    throw new Exception("Error, Consulte con el administrador");
            //}

           

            this.Close();
        }

        private void ObtenerDatos()
        {
            PoliticaPrecioBusiness objPoliticaBusiness = new PoliticaPrecioBusiness();

            PoliticaPrecio objPoliticaEntidad = new PoliticaPrecio()
            {
                CodPolitica = CodigoEdicion,
                DesPolitica = string.Empty,
                EstCodigo = string.Empty
            };

            try
            {

                var consulta = objPoliticaBusiness.ObtenerPolitica(objPoliticaEntidad).SingleOrDefault();

                if (consulta != null)
                {
                    TxtCodigo.Text = Convert.ToString(consulta.CodPolitica);
                    TxtDescripcion.Text = consulta.DesPolitica;
                    cboEstado.SelectedValue = consulta.EstCodigo.Substring(0, 1);
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
