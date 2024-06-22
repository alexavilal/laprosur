using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIGA.Windows.Caja
{
    public partial class frmOperacionCaja : Form
    {
        public int CodigoCaja { get; set; }
        public Int16 CodigoTipo { get; set; }
        public Int16 CodigoTipoEntidad { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public frmOperacionCaja()
        {
            InitializeComponent();
        }

        private void cboMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboMotivo.Text)
            {
                case "Depositos en Cuenta": CodigoTipo = 10; break;
                case "Pago Letras": CodigoTipo = 11; break;
                case "Gastos Finacieros": CodigoTipo = 12; break;
                case "Compras de Mercaderia": CodigoTipo = 13; break;
                case "Compras / Otras": CodigoTipo = 14; break;
                case "Movilidad": CodigoTipo = 15; break;
                case "Servicio de Baño": CodigoTipo = 16; break;

            }

        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {


            if (cboMotivo.Text != "--Seleccione--" && txtImporte.Text != string.Empty)
            {
                if (Convert.ToDecimal(txtSaldoSoles.Text) > Convert.ToDecimal(txtImporte.Text))
                {
                    Registrar();

                }
                else
                {
                    MessageBox.Show("El saldo es menor..", "");
                }

            }

        }

        private void Registrar()
        {

            int Registrar = 0;
            Int16 CodigoUsuario = 1;
            Int16 TipoDocumentoCaja = 0;
            string Glosa = string.Empty;
            decimal Importe = 0;

            SIGA.Business.Caja.CajeroBusiness objCaja = new SIGA.Business.Caja.CajeroBusiness();

            Glosa = txtMotivo.Text;
            Importe = Convert.ToDecimal(txtImporte.Text);

            if (optIngreso.Checked == true)
            {

                TipoDocumentoCaja = 1;
            }
            else
            {
                TipoDocumentoCaja = 2;
            }


            Registrar = objCaja.InsertarDocumentoCaja(CodigoCaja, TipoDocumentoCaja, CodigoTipo, CodigoTipoEntidad, Codigo, Glosa, dateTimePicker1.Value.ToString("yyyyMMdd"), Importe, CodigoUsuario);

            if (Registrar > 0)
            {
                MessageBox.Show("Se genero el Documento....!", "");

                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnImprimir.Enabled = true;
                btnSalir.Enabled = true;

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmBuscarEntidad objEntidad = new frmBuscarEntidad();
            objEntidad.ShowDialog();

            CodigoTipoEntidad = objEntidad.CodigoTipo;
            Codigo = objEntidad.Codigo;
            txtOrigenDestino.Text = objEntidad.Descripcion;
            txtCodigoEntidad.Text = objEntidad.Codigo.ToString();
        }

        private void frmOperacionCaja_Load(object sender, EventArgs e)
        {

            Cargar();
            CargarSaldos();
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnImprimir.Enabled = false;
            btnSalir.Enabled = true;

        }
        private void Cargar()
        {
            SIGA.Business.Caja.CajeroBusiness objCajero = new SIGA.Business.Caja.CajeroBusiness();

            string Fecha = string.Empty;

            Fecha = dateTimePicker1.Value.ToString("yyyyMMdd");
            CodigoCaja = Convert.ToInt32(objCajero.CodigoCajaAdministrativaPorSede(Fecha, 1).Rows[0][0]);

        }


        private void CargarSaldos()
        {
            SIGA.Business.Ventas.CajaBusiness objCaja = new SIGA.Business.Ventas.CajaBusiness();
            var result = objCaja.ConsultarSaldo(CodigoCaja);

            if (result.Rows.Count > 0)
            {

                txtSaldoDolares.Text = result.Rows[0][2].ToString();
                txtSaldoSoles.Text = result.Rows[0][1].ToString();

            }

        }
    }
}
