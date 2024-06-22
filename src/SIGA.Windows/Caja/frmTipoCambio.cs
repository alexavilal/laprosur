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
    public partial class frmTipoCambio : Form
    {
        public string Fecha { get; set; }
        public int Modo { get; set; }
        public int TipoLogistico { get; set; }
        public int TipoVenta { get; set; }
        public frmTipoCambio()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            decimal TipoCambioVentas = 0;
            decimal TipoCambioLogistica = 0;
            SIGA.Business.Caja.TipoCambioBusiness obj = new SIGA.Business.Caja.TipoCambioBusiness();

            var resultRegistro = obj.TipoCambioConsultarPorFecha(dateTimePicker1.Value.ToString("yyyyMMdd"));

            if (resultRegistro.Rows.Count > 0)
            {
                TipoCambioVentas = txtVentas.Text == string.Empty ? 0 : Convert.ToDecimal(txtVentas.Text);
                TipoCambioLogistica = txtImporte.Text == string.Empty ? 0 : Convert.ToDecimal(txtImporte.Text);

                TipoLogistico = 1;
                TipoVenta = 1;

                var result = obj.Actualizar(Convert.ToDecimal(TipoCambioLogistica), dateTimePicker1.Value.ToString("yyyyMMdd"), UsuarioLogeo.Codigo, Convert.ToDecimal(TipoCambioVentas), TipoLogistico, TipoVenta);

                if (result >= 0)
                {
                    this.Close();
                }


            }
            else
            {
                if (txtImporte.Text != string.Empty)
                {
                    var result = obj.Insertar(Convert.ToDecimal(txtImporte.Text), dateTimePicker1.Value.ToString("yyyyMMdd"), UsuarioLogeo.Codigo, Convert.ToDecimal(txtVentas.Text), TipoLogistico, TipoVenta);

                    if (result >= 0)
                    {
                        this.Close();
                    }
                }

            }

        }

        private void frmTipoCambio_Load(object sender, EventArgs e)
        {
            DateTime FechaConsulta;

            txtImporte.Visible = true;
            txtVentas.Visible = true;
            label1.Visible = true;
            label3.Visible = true;



            if (Fecha != null)
            {

                FechaConsulta = Convert.ToDateTime(Fecha);

                SIGA.Business.Caja.TipoCambioBusiness obj = new SIGA.Business.Caja.TipoCambioBusiness();
                var result = obj.TipoCambioConsultarPorFecha(FechaConsulta.ToString("yyyyMMdd"));

                if (result.Rows.Count > 0)
                {

                    dateTimePicker1.Enabled = false;
                    dateTimePicker1.Value = FechaConsulta;
                    label1.Visible = false;
                    label3.Visible = false;

                    txtImporte.Text = result.Rows[0][1].ToString();
                    txtVentas.Text = result.Rows[0][7].ToString();

                    if (TipoLogistico == 1)
                    {
                        label1.Visible = true;
                        txtImporte.Visible = true;

                    }
                    if (TipoVenta == 1)
                    {
                        txtVentas.Visible = true;
                        label3.Visible = true;


                    }


                }


            }
            else
            {

                DateTime Hoy = DateTime.Today;

                FechaConsulta = Convert.ToDateTime(Hoy);


                SIGA.Business.Caja.TipoCambioBusiness obj = new SIGA.Business.Caja.TipoCambioBusiness();
                var result = obj.TipoCambioConsultarPorFecha(FechaConsulta.ToString("yyyyMMdd"));

                if (result.Rows.Count > 0)
                {

                    dateTimePicker1.Enabled = false;
                    dateTimePicker1.Value = FechaConsulta;
                    label1.Visible = true;
                    label3.Visible = true;
                    txtImporte.Text = result.Rows[0][1].ToString();
                    txtVentas.Text = result.Rows[0][7].ToString();


                }
                else
                {
                    dateTimePicker1.Enabled = false;
                    dateTimePicker1.Value = FechaConsulta;

                    txtImporte.Visible = true;
                    txtVentas.Visible = true;
                    label1.Visible = true;
                    label3.Visible = true;

                }





            }
        }
    }
}
