using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGA.Entities.Logistica;
using SIGA.Business.Logistica;

namespace SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos
{
    public partial class frmRegistroFamilia : Form
    {
        public int CodigoEdicion;

        public frmRegistroFamilia()
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

        private void frmRegistroFamilia_Load(object sender, EventArgs e)
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

            int Codigo = 0;
            FamiliaBusiness objDocumentoBussiness = new FamiliaBusiness();

            try
            {

                if (txtCodInterno.Text.Length.Equals(0))
                {
                    MessageBox.Show("Debe ingresar el codigo interno de la familia");
                    return;
                }

                if (txtCuenta.Text.Length.Equals(0))
                {
                    MessageBox.Show("Debe ingresar la cuenta");
                    return;
                }

                if (TxtDescripcion.Text.Length.Equals(0))
                {
                    MessageBox.Show("Debe ingresar la descripción");
                    return;
                }


                Familia objEntidad = new Familia();
                objEntidad.CodIntFamilia = txtCodInterno.Text;
                objEntidad.CodCuenta = txtCuenta.Text;
                objEntidad.DesFamilia = TxtDescripcion.Text;
                objEntidad.UsuCre = UsuarioLogeo.Codigo;  // por definir, dato de prueba
                //objEntidad.Porcentaje = 0;
                Codigo = objDocumentoBussiness.RegistrarFamilia(objEntidad);

                if (Codigo > 0)
                {
                    MessageBox.Show("Se grabaron los datos correctamente", "SIGA");
                    frmMantenimientoFamilia objManteniento = new frmMantenimientoFamilia();
                    objManteniento.Buscar("");
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
                FamiliaBusiness objDocumentoBussiness = new FamiliaBusiness();
                Familia objEntidad = new Familia();
                objEntidad.CodFamilia = CodigoEdicion;
                objEntidad.CodIntFamilia = txtCodInterno.Text;
                objEntidad.DesFamilia  = TxtDescripcion.Text;
                objEntidad.CodCuenta = txtCuenta.Text;
                objEntidad.EstCodigo = Convert.ToString(cboEstado.SelectedValue);
                objEntidad.UsuMod = UsuarioLogeo.Codigo;
                //objEntidad.Porcentaje = 0;
                Codigo = objDocumentoBussiness.ActualizarFamilia(objEntidad);

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
            FamiliaBusiness objFamiliaBusiness = new FamiliaBusiness();

            Familia objProveedor = new Familia();
            objProveedor.CodFamilia = CodigoEdicion;

            var consulta = objFamiliaBusiness.ObtenerFamiliaPorCodigo(objProveedor);

            TxtCodigo.Text = Convert.ToString(consulta.CodFamilia);
            txtCodInterno.Text = consulta.CodIntFamilia;
            TxtDescripcion.Text = consulta.DesFamilia;
            txtCuenta.Text = consulta.CodCuenta;
            cboEstado.SelectedValue = consulta.EstCodigo;
            txtPorcentaje.Text = "0";

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
