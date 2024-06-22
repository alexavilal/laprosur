using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGA.Business.Caja;
using SIGA.Entities.Caja;

namespace SIGA.Windows.Caja
{



    public partial class frmCierreCaja : Form
    {
        public int CodigoCaja { get; set; }
        public int ModoAdministritivo { get; set; }
        public int Cerrado { get; set; }
        private List<DetalleDistribucionCaja> ListaDistribucion;

        public frmCierreCaja()
        {
            InitializeComponent();
        }
        #region "Carga"

        private void CargarSaldos()
        {
            SIGA.Business.Ventas.CajaBusiness objCaja = new SIGA.Business.Ventas.CajaBusiness();
            var result = objCaja.ConsultarSaldo(CodigoCaja);

            if (result.Rows.Count > 0)
            {
                txtSaldoEfectivo.Text = result.Rows[0][1].ToString();
            }
        }

        private void CargarDenominaciones()
        {
            DenominacionBusiness objDenominacion = new DenominacionBusiness();
            DataTable dtBillete = new DataTable();
            DataTable dtMoneda = new DataTable();

            dtBillete = objDenominacion.ConsultarPorTipo(2);

            dtMoneda = objDenominacion.ConsultarPorTipo(1);


            cboBillete.DataSource = dtBillete;
            cboBillete.ValueMember = "CodDenMon";
            cboBillete.DisplayMember = "ValDenMon";

            cboMoneda.DataSource = dtMoneda;
            cboMoneda.ValueMember = "CodDenMon";
            cboMoneda.DisplayMember = "ValDenMon";

            cboBillete.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;

        }
        #endregion

        private void frmCierreCaja_Load(object sender, EventArgs e)
        {
            
            txtFecha.Text = DateTime.Now.ToShortDateString();
            if (ModoAdministritivo == 1)
            {
                Cargar();
            }

            SIGA.Business.Ventas.CajaBusiness obj = new SIGA.Business.Ventas.CajaBusiness();

            var result = obj.ConsultarPorCodigo(CodigoCaja);

            if (result.Rows.Count > 0)
            {
                txtUsuario.Text = result.Rows[0][3].ToString();
            }



            CargarDenominaciones();
            CargarSaldos();
            ListaDistribucion = new List<DetalleDistribucionCaja>();
            CargaPagosTarjetas();
            btnGuardar.Enabled = true;
            btnImprimir.Enabled = false;
            btnSalir.Enabled = true;
        }

        private void CargaPagosTarjetas()
        {
            SIGA.Business.Caja.CajeroBusiness objCajero = new SIGA.Business.Caja.CajeroBusiness();
            var result = objCajero.TipoPagoPorCaja(CodigoCaja, "Tarjeta");
            dgvTarjetas.DataSource = result;

            if (result.Rows.Count > 0)
            {
                object sumObject;
                sumObject = result.Compute("Sum(Total)", "");

                txtSaldoTarjeta.Text = sumObject.ToString();

            }
            else
            {
                txtSaldoTarjeta.Text = "0";
            }



            var resultCheque = objCajero.TipoPagoPorCaja(CodigoCaja, "Cheque");

            if (resultCheque.Rows.Count > 0)
            {
                object sumObject;
                sumObject = resultCheque.Compute("Sum(Total)", "");
                txtSaldoCheques.Text = sumObject.ToString();
            }
            else
            {
                txtSaldoCheques.Text = "0";
            }

            Importes();
        }


        private void Cargar()
        {
            SIGA.Business.Caja.CajeroBusiness objCajero = new SIGA.Business.Caja.CajeroBusiness();

            string Fecha = string.Empty;

            Fecha = DateTime.Now.ToString("yyyyMMdd");

            CodigoCaja = Convert.ToInt32(objCajero.CodigoCajaAdministrativaPorSede(Fecha, 1).Rows[0][0]);

        }


        private void btnQuitarBillete_Click(object sender, EventArgs e)
        {
            if (dgvBillete.RowCount > 0)
            {
                int index = dgvBillete.CurrentCell.RowIndex;
                dgvBillete.Rows.RemoveAt(index);
                Importes();
            }
            else
            {
                MessageBox.Show("No existen items a eliminar");
            }

        }

        private void btnQuitarMoneda_Click(object sender, EventArgs e)
        {
            if (dgvMoneda.RowCount > 0)
            {
                int index = dgvMoneda.CurrentCell.RowIndex;
                dgvMoneda.Rows.RemoveAt(index);
                Importes();
            }
            else
            {
                MessageBox.Show("No existen items a eliminar");
            }

        }

        private void btnAgregarBillte_Click(object sender, EventArgs e)
        {
            decimal doTotal = 0;

            try
            {

                if ((Convert.ToInt32(cboBillete.SelectedIndex) != -1) && (txtCantidadBillete.Text.Length == 0))
                {
                    MessageBox.Show("Debe ingresar valores");
                    return;
                }
                doTotal = Convert.ToDecimal(cboBillete.Text) * Convert.ToDecimal(txtCantidadBillete.Text);
                dgvBillete.Rows.Insert(dgvBillete.Rows.Count, cboBillete.SelectedValue.ToString(), cboBillete.Text, txtCantidadBillete.Text, doTotal.ToString());
                dgvBillete.Focus();
                dgvBillete.CurrentCell = dgvBillete.Rows[dgvBillete.Rows.Count - 1].Cells[1];
                Importes();

                cboBillete.SelectedIndex = -1;
                txtCantidadBillete.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnAgregarMoneda_Click(object sender, EventArgs e)
        {
            decimal doTotal = 0;

            try
            {
                if (cboMoneda.SelectedIndex != -1 && txtCantidadMoneda.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar valores");
                    return;
                }

                doTotal = Convert.ToDecimal(cboMoneda.Text) * Convert.ToDecimal(txtCantidadMoneda.Text);

                dgvMoneda.Rows.Insert(dgvMoneda.Rows.Count, cboMoneda.SelectedValue.ToString(), cboMoneda.Text, txtCantidadMoneda.Text, doTotal.ToString());
                dgvMoneda.Focus();
                dgvMoneda.CurrentCell = dgvMoneda.Rows[dgvMoneda.Rows.Count - 1].Cells[1];
                Importes();
                cboMoneda.SelectedIndex = -1;
                txtCantidadMoneda.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }


        private void Importes()
        {
            decimal doTotalBilletes = 0;
            decimal doTotalMonedas = 0;

            for (int i = 0; i < dgvBillete.Rows.Count; i++)
            {


                doTotalBilletes = doTotalBilletes + Convert.ToDecimal(dgvBillete[3, i].Value.ToString());


            }


            for (int i = 0; i < dgvMoneda.Rows.Count; i++)
            {

                doTotalMonedas = doTotalMonedas + Convert.ToDecimal(dgvMoneda[3, i].Value.ToString());



            }

            txtTotalBilletes.Text = doTotalBilletes.ToString();
            txtTotalMoneda.Text = doTotalMonedas.ToString();


            decimal doTotalTarjetas = 0;
            decimal doTotalCheques = 0;

            //doTotalRecaudado = doTotalBilletes + doTotalMonedas + doTotalTarjetas + doTotalCheques;

            //txtTotalRecaudado.Text = doTotalRecaudado.ToString();
            doTotalTarjetas = Convert.ToDecimal(txtSaldoTarjeta.Text);
            doTotalCheques = Convert.ToDecimal(txtSaldoCheques.Text);


            TotalGeneral(doTotalBilletes, doTotalMonedas, doTotalTarjetas, doTotalCheques);


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtSaldoEfectivo.Text) == Convert.ToDecimal(txtTotalRecaudado.Text))
            {
                Registrar();
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("El saldo no coindice con el total recauadado ,desea registrar de todas maneras el cierre","", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Registrar();
                }


            }



        }

        private void Registrar()
        {
            CajeroBusiness objCajero = new CajeroBusiness();
            decimal TotalBilletes = 0, TotalMonedas = 0, TotalTarjetas = 0, TotalCheque = 0, TotalRecaudado = 0;
            Int16 Usuario = UsuarioLogeo.Codigo;

            TotalBilletes = Convert.ToDecimal(txtTotalBilletes.Text);

            TotalMonedas = Convert.ToDecimal(txtTotalMoneda.Text);

            TotalTarjetas = Convert.ToDecimal(txtSaldoTarjeta.Text);

            TotalCheque = Convert.ToDecimal(txtSaldoCheques.Text);

            TotalRecaudado = Convert.ToDecimal(txtTotalRecaudado.Text);

            //Generar Lista





            foreach (DataGridViewRow row in this.dgvBillete.Rows)
            {
                var item = new DetalleDistribucionCaja();
                item.Tipo = "Billetes";
                item.Valor = Convert.ToString(row.Cells[1].Value);
                item.Cantidad = Convert.ToInt32(row.Cells[2].Value);
                item.Total = Convert.ToDecimal(row.Cells[3].Value);
                ListaDistribucion.Add(item);
            }


            foreach (DataGridViewRow row in this.dgvMoneda.Rows)
            {
                var item = new DetalleDistribucionCaja();
                item.Tipo = "Monedas";
                item.Valor = Convert.ToString(row.Cells[1].Value);
                item.Cantidad = Convert.ToInt32(row.Cells[2].Value);
                item.Total = Convert.ToDecimal(row.Cells[3].Value);
                ListaDistribucion.Add(item);

            }


            foreach (DataGridViewRow row in this.dgvTarjetas.Rows)  //Pago Tarjetas
            {
                var item = new DetalleDistribucionCaja();
                item.Tipo = Convert.ToString(row.Cells[0].Value);
                item.Valor = Convert.ToString(row.Cells[1].Value);
                item.Cantidad = 1;
                item.Total = Convert.ToDecimal(row.Cells[1].Value);


                string TipoTarjeta = string.Empty;

                ListaDistribucion.Add(item);

            }



            var result = objCajero.Registrar(CodigoCaja, TotalBilletes, TotalMonedas, TotalTarjetas, TotalCheque, TotalRecaudado, Usuario, ListaDistribucion);


            if (result > 0)
            {
                MessageBox.Show("Se registro el cierre de caja,se cerrara el formulario de caja..!", "SIGA");
                Cerrado = 1;
                btnImprimir.Enabled = true;
                btnGuardar.Enabled = false;
                btnSalir.Enabled = true;

            }


        }

        private void txtTotalRecaudado_TextChanged(object sender, EventArgs e)
        {

        }

        private void TotalGeneral(decimal Billetes, decimal Moneda, decimal Tarjetas, decimal Cheques)
        {
            decimal TotalGeneral = 0;

            TotalGeneral = Billetes + Moneda + Tarjetas + Cheques;

            txtTotalRecaudado.Text = TotalGeneral.ToString();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            SIGA.Windows.Comunes.frmImpresion objfrmReporte = new SIGA.Windows.Comunes.frmImpresion();
            string ruta = string.Empty;


            try
            {
                ruta = @"C:\Trabajo\SIGA-CODE\SIGA\SIGA.Windows\Reportes\rptCierreCaja.rdlc";



                objfrmReporte.Archivo = "rptCierreCaja.rpt";
                objfrmReporte.Entidad = "USP_CierreConsultar";
                objfrmReporte.DataSource = MovimientoCaja();
                objfrmReporte.WindowState = FormWindowState.Normal;
                objfrmReporte.sbImprimir(ruta);
                objfrmReporte.ShowDialog();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                objfrmReporte = null;

            }


        }

        private DataTable MovimientoCaja()
        {
            SIGA.Business.Caja.CajeroBusiness obj = new SIGA.Business.Caja.CajeroBusiness();
            var result = obj.ConsultarCierre(CodigoCaja);
            return result;

        }

    }
}
