using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGA.Business.Ventas;
using SIGA.Business.Comunes;
using SIGA.Entities.Ventas;
using SIGA.Comun;

namespace SIGA.Windows.Caja
{
    public partial class frmVentaMinorista : Form
    {
        public int CantidadDocumento = 0;
        public int CodigoCaja = 0;
        public int TipoPago = 0;
        public int DescripcionPago = 0;
        public frmVentaMinorista()
        {
            InitializeComponent();
        }

        private void BuscarCliente(string pCodigo)
        {
            ClienteBusiness objCliente = new ClienteBusiness();

            var resultCliente = objCliente.BuscarPorCodigo(pCodigo);

            txtDireccion.Text = "";
            txtRazonSocial.Text = "";



            if (resultCliente != null)
            {


                txtRazonSocial.Text = resultCliente.NomComCliente;
                txtDireccion.Text = resultCliente.DirCliente;
                cboDocumentoCliente.Text = resultCliente.CodTipoDocumento == 1 ? "RUC" : "DNI";
                txtNumero.Text = resultCliente.NumDocumentoCliente;

            }
            else
            {
                cboDocumento.Text = "DNI";
                txtNumero.Text = string.Empty;

            }

        }

        private void Botones(bool Nuevo, bool Registrar, bool Imprimir, bool Limpiar, bool Salir)
        {
            btnNuevo.Enabled = Nuevo;
            btnLimpiar.Enabled = Limpiar;
            btnGuardar.Enabled = Registrar;
            btnImprimir.Enabled = Imprimir;
            btnSalir.Enabled = Salir;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            string strCodigo = txtCodigo.Text;

            if (strCodigo.Length == 7)
            {
                BuscarCliente(txtCodigo.Text);

            }

        }

        //private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //    frmStockAlmacen form = new frmStockAlmacen();
        //    form.CargarStock(Convert.ToInt16(dgvItems[1, dgvItems.CurrentRow.Index].Value));
        //    form.ShowDialog();

        //}



        private void dgvItems_CellDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            int Codigo = 0;

            Codigo = Convert.ToInt32(dgvItems[1, dgvItems.CurrentRow.Index].Value);

            if (Codigo > 0)
            {
                SIGA.Windows.Ventas.Formularios.frmStockAlmacen form = new SIGA.Windows.Ventas.Formularios.frmStockAlmacen();
                form.CargarStock(Codigo);
                form.ShowDialog();

            }
        }



        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int Cantidad = 0;
            string Stock = string.Empty;
            decimal Precio = 0;
            decimal totalFila = 0;
            string pCodigoBarra = string.Empty;

            try
            {


                if (e.ColumnIndex == 0)
                {

                    BuscarDatos(dgvItems[0, dgvItems.CurrentRow.Index].Value.ToString());
                    
                }


                if (e.ColumnIndex == 5)
                {

                    Cantidad = Convert.ToInt32(dgvItems[5, dgvItems.CurrentRow.Index].Value);
                    Stock = dgvItems[6, dgvItems.CurrentRow.Index].Value.ToString();

                    if (Cantidad > Convert.ToDouble(Stock))
                    {
                        MessageBox.Show("La Cantidad es mayor al stock....!");

                        SIGA.Windows.Ventas.Formularios.frmQuitar form = new SIGA.Windows.Ventas.Formularios.frmQuitar();
                        form.Carga = 1;
                        form.Muestra();
                        form.ShowDialog();

                        if (form.Validado == true)
                        {
                            dgvItems.CurrentCell = dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[5];
                        }

                    }
                    else
                    {

                        SIGA.Business.Ventas.GeneralBusiness objBusiness = new SIGA.Business.Ventas.GeneralBusiness();

                        int CodigoProducto = Convert.ToInt32(dgvItems[1, dgvItems.CurrentRow.Index].Value);
                        int CantidadProducto = Convert.ToInt32(dgvItems[5, dgvItems.CurrentRow.Index].Value);

                        var result = objBusiness.ConsultarPrecio(CodigoProducto, CantidadProducto, 1, 3);

                        dgvItems[7, dgvItems.CurrentRow.Index].Value = result.Rows[0][1];

                        decimal TotalProducto = 0;

                        TotalProducto = Convert.ToDecimal(CantidadProducto) * Convert.ToDecimal(result.Rows[0][1]);

                        dgvItems[8, dgvItems.CurrentRow.Index].Value = TotalProducto;

                        Importes();

                    }



                }



                //Total = CalculaTotal(Convert.ToDecimal(txtCantidad.Text == "" ? 0 : Convert.ToDecimal(txtCantidad.Text)), Convert.ToDecimal(txtPrecio.Text == "" ? 0 : Convert.ToDecimal(txtPrecio.Text)));
                //textBox2.Text = Total.ToString();

                Importes();

            }



            catch (Exception ex)
            {
            }


        }


        //Try

        //    dgvEmpleado.Item(4, dgvEmpleado.CurrentRow.Index).Value = dgvEmpleado.Item(2, dgvEmpleado.CurrentRow.Index).Value * dgvEmpleado.Item(3, dgvEmpleado.CurrentRow.Index).Value
        //    sbCalcular()

        //Catch ex As Exception

        //End Try



        private void dgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //replace ColumnIndex == 1 in the following code with column index of your check box column
            if (dgvItems.CurrentCell.ColumnIndex == 1 && dgvItems.IsCurrentCellDirty)
            {
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvItems_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Hola");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //frmArticuloVenta form = new frmArticuloVenta();
            //form.ShowDialog();

            //txtCodigoBarra.Focus();

            //InsertarItem();

            dgvItems.Rows.Insert(dgvItems.Rows.Count, "", 0, "", "", 0, 0, 0, Convert.ToDecimal(0), "", true, "");
            dgvItems.Focus();
            dgvItems.CurrentCell = dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[0];

        }

        private void InsertarItem(int Origen ,string CodigoBarra,int Codigo,int CodigoEmpresa,string CodigoZurece,string Descripcion,string Cantidad,string Stock)
        {

            // dgvItems.Rows.Insert(dgvItems.Rows.Count, textBox1.Text, txtEmpresa.Text, txtCodigoExterno.Text, txtDescripcion.Text, txtCantidad.Text, 20, txtPrecio.Text, Convert.ToDecimal(textBox2.Text));

            if (Origen == 1)
            {
                dgvItems[0, dgvItems.CurrentRow.Index].Value = CodigoBarra;
            }

            GeneralBusiness objBusiness = new GeneralBusiness();
        
            //var result = objBusiness.BuscarPrecio(1);

            
           
          
            dgvItems[1, dgvItems.CurrentRow.Index].Value = Codigo;

            dgvItems[2, dgvItems.CurrentRow.Index].Value = CodigoEmpresa;

            dgvItems[3, dgvItems.CurrentRow.Index].Value = CodigoZurece;

            dgvItems[4, dgvItems.CurrentRow.Index].Value = Descripcion;

            dgvItems[6, dgvItems.CurrentRow.Index].Value = Stock;

            dgvItems[5, dgvItems.CurrentRow.Index].Value = Cantidad;

            var result = objBusiness.ConsultarPrecio(Codigo, 1, 1, 3);

            dgvItems[7, dgvItems.CurrentRow.Index].Value = result.Rows[0][1];

            decimal Total = 0;

            Total = Convert.ToDecimal(Cantidad) * Convert.ToDecimal(result.Rows[0][1]);

            dgvItems[8, dgvItems.CurrentRow.Index].Value = Total;

            Importes();
        }

        private decimal StockArticulo(int Codigo,int Empresa)
        {
            SaldoBusiness objSaldo = new SaldoBusiness();
            return objSaldo.Stock(Convert.ToInt32(Codigo), Convert.ToByte(Empresa));


        }

        private void Importes()
        {
            Decimal SubTotal = 0;
            Decimal Impuesto = 0;
            Decimal Neto = 0;

            //txtTotal.Text = TotalDocumento().ToString();


            if (cboDocumento.Text == "Factura" || cboDocumento.Text  == "Boleta")
            {

                SubTotal = Convert.ToDecimal(TotalDocumento()) / Convert.ToDecimal(1.18);
                txtTotal.Text = SubTotal.ToString("#######.000");
                Impuesto = Convert.ToDecimal(TotalDocumento()) - Convert.ToDecimal(SubTotal);


                txtImpuesto.Visible = true;
                lblImpuesto.Visible = true;
                txtImpuesto.Text = Impuesto.ToString("#######.000");
                txtDescuento.Text = "0";

                Neto = SubTotal + Impuesto;

                txtNeto.Text = Neto.ToString("#######.000");


            }

            //if (cboDocumento.Text == "Boleta")
            //{
            //    txtImpuesto.Visible = false;
            //    lblImpuesto.Visible = false;


            //    SubTotal = Convert.ToDecimal(TotalDocumento());
            //    txtTotal.Text = SubTotal.ToString("####,###.000");
            //    Impuesto = 0;


            //    txtImpuesto.Visible = true;
            //    lblImpuesto.Visible = true;
            //    txtImpuesto.Text = Impuesto.ToString("####,###.000");
            //    txtDescuento.Text = "0";

            //    Neto = SubTotal + Impuesto;

            //    txtNeto.Text = Neto.ToString("####,###.000");

            //}



        }





        private Decimal TotalDocumento()
        {
            Decimal Total = 0;
            string Valor = "";

            for (int i = 0; i < dgvItems.Rows.Count; i++)
            {

                //Valor = (string)dgvItems[7, i].Value;
                Total = Total + (decimal)dgvItems[8, i].Value;

                //Valor = (string)dgvItems[0, i].Value;
                //Valor = (string)dgvItems[1, i].Value;
                //Valor = (string)dgvItems[2, i].Value;
                //Valor = (string)dgvItems[3, i].Value;
                //Valor = (string)dgvItems[4, i].Value.ToString();
                //Valor = (string)dgvItems[5, i].Value.ToString();
                //Valor = (string)dgvItems[6, i].Value.ToString();

            }

            return Total;

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (dgvItems.RowCount > 0 )
            {
                try
                {
                    SIGA.Windows.Ventas.Formularios.frmQuitar form = new SIGA.Windows.Ventas.Formularios.frmQuitar();
                    form.Carga = 0;
                    form.Muestra();
                    form.ShowDialog();

                    if (form.Validado == true)
                    {
                        int index = dgvItems.CurrentCell.RowIndex;

                        // Deletes the Row from the Datagridview
                        //dataGridView.Rows.RemoveAt(index);
                        dgvItems.Rows.RemoveAt(index);
                        Importes();


                    }
                }

                catch (Exception ex)
                {

                }
               


            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {


            SIGA.Windows.Ventas.Formularios.frmPagar form = new SIGA.Windows.Ventas.Formularios.frmPagar();
            form.MontoPagar = Convert.ToDecimal(txtNeto.Text);
            form.ShowDialog();
            TipoPago = form.TipoPago;
            DescripcionPago = form.DescripcionPago;

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {

            SIGA.Windows.Ventas.Formularios.frmBuscarCliente form = new SIGA.Windows.Ventas.Formularios.frmBuscarCliente();
            form.ShowDialog();

            if (form.codigo != string.Empty)
            {
                txtCodigo.Text = form.codigo;

            }


        }

        private void chkRegistrado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegistrado.Checked == true)
            {
                txtCodigo.Enabled = true;
                btnBuscarCliente.Enabled = true;
                cboDocumentoCliente.Enabled = false;
                txtDireccion.Enabled = false;
                txtRazonSocial.Enabled = false;
                txtNumero.Enabled = false;
                cboDocumentoCliente.Text = "";
                txtDireccion.Text = "";
                txtRazonSocial.Text = "";
                txtNumero.Text = string.Empty;
                txtCodigo.Focus();

            }
            else
            {
                txtCodigo.Enabled = false;
                btnBuscarCliente.Enabled = false;
                cboDocumentoCliente.Enabled = true;
                txtDireccion.Enabled = true;
                txtRazonSocial.Enabled = true;
                txtNumero.Enabled = true;


                txtCodigo.Text = string.Empty;
                txtRazonSocial.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtNumero.Text = string.Empty;
            }

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            decimal total = 0;

            total = TotalNeto(Convert.ToDecimal(txtTotal.Text), Convert.ToDecimal(txtDescuento.Text));
            txtNeto.Text = total.ToString();


        }

        private string InsertarCliente()
        {
            ClienteBusiness objCliente = new ClienteBusiness();

            ClienteRequest request = new ClienteRequest();

            request.CodTipoDocumento = Convert.ToInt16(cboDocumentoCliente.Text == "RUC" ? 1 : 2);
            request.NumDocumentoCliente = txtNumero.Text;
            request.RazSocCliente = txtRazonSocial.Text;
            request.DirCliente = txtDireccion.Text;

            string pCodigo = string.Empty;
            if (chkRegistrado.Checked == false)
            {
                if (cboDocumento.Text == "Factura")
                {
                    if (txtRazonSocial.Text == string.Empty)
                    {
                        pCodigo = objCliente.IngresarCliente(request);
                    }

                }

                if (cboDocumento.Text == "Boleta")
                {

                    if (txtRazonSocial.Text == string.Empty && Convert.ToDecimal(txtNeto.Text) < 50)
                    {
                        pCodigo = "0000004";
                    }

                    else
                    {
                        pCodigo = objCliente.IngresarCliente(request);
                    }

                }
            }
            else
            {
                pCodigo = txtCodigo.Text;
            }

            return pCodigo;
        }



        private decimal TotalNeto(decimal total, decimal descuento)
        {
            decimal totalNeto = 0;
            totalNeto = total - descuento;
            return totalNeto;
        }

        private void frmVentaMinorista_Load(object sender, EventArgs e)
        {
            Botones(false, true, false, false, true);

            txtImpuesto.Visible = true;
            lblImpuesto.Visible = true;

            txtTotal.Text = "0";
            txtDescuento.Text = "0";
            txtImpuesto.Text = "0";
            txtNeto.Text = "0";
            cboDocumento.Text = "Boleta";

            //EnvioCorreo oEnvioCorreo = new EnvioCorreo();

            //oEnvioCorreo.sbEnviar("jcinfantas@gmail.com", "HOLA", "Mensaje");
            timer1.Start();

            lblCajero.Text = "";
        }


        protected void Insertar()
        {
            DocumentoVentaBusiness objbl_tbDocumentoVenta = new DocumentoVentaBusiness();
            DocumentoVentaResponse obje_tbDocumentoVenta = new DocumentoVentaResponse();

            int Codigo = 0;

            obje_tbDocumentoVenta.CodDocumento = 0;
            obje_tbDocumentoVenta.CodEmpresa = 1;
            obje_tbDocumentoVenta.CodTipoDocumento = 1;
            obje_tbDocumentoVenta.NumDocumentoVenta = "";
            obje_tbDocumentoVenta.CodCliente = "0000001";
            obje_tbDocumentoVenta.FecEmiDocumento = Convert.ToDateTime(DateTime.Now);
            obje_tbDocumentoVenta.DirDocumentoVenta = "Mi casa";
            obje_tbDocumentoVenta.MonBruDocumento = 0;
            obje_tbDocumentoVenta.MonImpDocumento = 0;
            obje_tbDocumentoVenta.DesDocumento = 0;
            obje_tbDocumentoVenta.MonNetDocumento = 0;
            obje_tbDocumentoVenta.GlosaDocumento = "";
            obje_tbDocumentoVenta.NumLetDocumento = "";
            obje_tbDocumentoVenta.CodMoneda = 1;
            obje_tbDocumentoVenta.EstCodigo = "A";
            obje_tbDocumentoVenta.FecCre = Convert.ToDateTime(DateTime.Now);
            obje_tbDocumentoVenta.UsuCreCodigo = Convert.ToInt16(1);
            obje_tbDocumentoVenta.FecMod = Convert.ToDateTime(DateTime.Now);
            obje_tbDocumentoVenta.UsuModCodigo = 1;


            //Codigo = objbl_tbDocumentoVenta.Insert(obje_tbDocumentoVenta);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (TipoPago == 0)
            {
                MessageBox.Show("Debe ingresar la forma de pago");
                return;

            }
            else
            {
                if (TipoPago == 2)
                {
                    if (DescripcionPago == 0)
                    {
                        MessageBox.Show("Debe ingresar el tipo de tarjeta");
                        return;
                    }
                }

            }
            

            CantidadDocumento = 0;

            if (cboDocumento.Text == "Factura")
            {

                if (txtCodigo.Text == string.Empty)
                {
                    MessageBox.Show("Debe ingresar un cliente en caso de registro de facturas");
                    return;
                }
                else
                {
                    if (cboDocumentoCliente.Text == "DNI")
                    {
                        MessageBox.Show("Debe Ingresar un cliente con ruc en caso de facturas");
                        return;
                    }
                }
            }

            if (cboDocumento.Text == "Boleta")
            {
                var Valida = ValidaIngreso();

                if (Valida == false)
                {
                    MessageBox.Show("Debe Ingresar un Cliente...");
                    return;
                }
            }


            if (dgvItems.RowCount == 0)
            {
                MessageBox.Show("Debe Ingresar un Item para generar el documento");
                return;
            }

            DocumentoVentaBusiness objDocumentoVenta = new DocumentoVentaBusiness();


            int Codigo = 0;



            var result = Lista();



            decimal doTotalBrutoEmpresa = 0;
            decimal doIgv = 0;
            decimal doTotal = 0;

            for (int i = 1; i <= 3; i++)
            {
                var items = result.Where(x => x.CodEmpresa == Convert.ToByte(i)).ToList();

                if (items.Count > 0)
                {
                    doTotal = items.Sum(x => x.TotDetalleDocumento);
                    doTotalBrutoEmpresa = Convert.ToDecimal(doTotal) / Convert.ToDecimal(1.19);
                    doIgv = doTotal - doTotalBrutoEmpresa;

                    DocumentoVentaResponse obje_tbDocumentoVenta = new DocumentoVentaResponse();

                    obje_tbDocumentoVenta.CodEmpresa = 1;
                    obje_tbDocumentoVenta.CodTipoDocumento = Convert.ToInt16(cboDocumento.Text == "Factura" ? 1 : 2);
                    obje_tbDocumentoVenta.NumDocumentoVenta = "001-0002";
                    obje_tbDocumentoVenta.CodCliente = InsertarCliente();
                    obje_tbDocumentoVenta.FecEmiDocumento = Convert.ToDateTime(DateTime.Now);
                    obje_tbDocumentoVenta.DirDocumentoVenta = txtDireccion.Text;
                    obje_tbDocumentoVenta.MonBruDocumento = doTotalBrutoEmpresa;
                    obje_tbDocumentoVenta.MonImpDocumento = doIgv;
                    obje_tbDocumentoVenta.DesDocumento = 0;
                    obje_tbDocumentoVenta.MonNetDocumento = doTotal;
                    obje_tbDocumentoVenta.GlosaDocumento = "";
                    obje_tbDocumentoVenta.NumLetDocumento = "";
                    obje_tbDocumentoVenta.CodMoneda = 1;
                    obje_tbDocumentoVenta.EstCodigo = "A";
                    obje_tbDocumentoVenta.FecCre = Convert.ToDateTime(DateTime.Now);
                    obje_tbDocumentoVenta.UsuCreCodigo = Convert.ToInt16(1);
                    obje_tbDocumentoVenta.CodOrigen = 1;

                    Codigo = objDocumentoVenta.InsertarDocumento(Convert.ToByte(i), obje_tbDocumentoVenta, items.ToList(),Convert.ToInt16(TipoPago),Convert.ToInt16(DescripcionPago),CodigoCaja,txtRazonSocial.Text,1);

                    if (Codigo > 0)
                    {
                        CantidadDocumento = CantidadDocumento + 1;

                    }

                }

            }

            MessageBox.Show("Se han generado " + CantidadDocumento.ToString() + "Documento(s)", "Venta");

            Botones(true, false, true, true, true);

            dgvItems.Enabled = false;
            btnAgregar.Enabled = false;
            button1.Enabled = false;
            groupBox1.Enabled = false;
            TipoPago = 0;
            DescripcionPago = 0;



        }



        public bool ValidaIngreso()
        {
            bool Validado = true;
            decimal Importe50 = 0;
            decimal Importe500 = 0;

            ParametroBusiness objGeneral = new ParametroBusiness();
            Importe50 = Convert.ToDecimal(objGeneral.BuscarPorCodigo(Comun.Constantes.IdMontoMinimo).ValParametro1);

            Importe500 = Convert.ToDecimal(objGeneral.BuscarPorCodigo(Comun.Constantes.IdMonto500).ValParametro1);

            if (cboDocumento.Text == "Boleta")
            {

                if (Convert.ToDecimal(txtNeto.Text) > (Importe50) && Convert.ToDecimal(txtNeto.Text) < (Importe500))
                {
                    if (txtRazonSocial.Text == string.Empty)
                    {
                        Validado = false;
                    }

                }
                else
                {
                    if (Convert.ToDecimal(txtNeto.Text) < (Importe50))
                    {
                        Validado = true;
                        return Validado;
                    }

                    if (txtRazonSocial.Text == string.Empty)
                    {
                        Validado = false;
                        return Validado;
                    }

                    if (txtNumero.Text == string.Empty)
                    {
                        Validado = false;
                        return Validado;
                    }

                    if (txtDireccion.Text == string.Empty)
                    {
                        Validado = false;
                        return Validado;
                    }

                }
            }

            return Validado;
        }


        public List<DocumentoDetalleRequest> Lista()
        {
            List<DocumentoDetalleRequest> ListaDocumento = new List<DocumentoDetalleRequest>();


            foreach (DataGridViewRow row in this.dgvItems.Rows)
            {

                DocumentoDetalleRequest Item = new DocumentoDetalleRequest();

                Item.CodGeneral = Convert.ToInt32(row.Cells[1].Value);
                Item.CanDetalleDocumento = Convert.ToDecimal(row.Cells[5].Value);
                Item.ItemDetalleDocumento = 1;
                Item.PreDetalleDocumento = Convert.ToDecimal(row.Cells[7].Value);
                Item.TotDetalleDocumento = Convert.ToDecimal(row.Cells[8].Value);
                Item.CodEmpresa = Convert.ToByte(row.Cells[2].Value);
                ListaDocumento.Add(Item);



            }
            return ListaDocumento;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Botones(false, true, false, false, true);


            cboDocumento.Text = "Boleta";
            cboDocumentoCliente.Text = "";
            txtCodigo.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtDireccion.Text = string.Empty;

            txtTotal.Text = "0";
            txtDescuento.Text = "0";
            txtImpuesto.Text = "0";
            txtNeto.Text = "0";
            dgvItems.Rows.Clear();
            chkRegistrado.Checked = false;

            txtCodigoBarra.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            textBox2.Text = string.Empty;

            dgvItems.Enabled = true;
            btnAgregar.Enabled = true;
            button1.Enabled = true;
            groupBox1.Enabled = true;
            cboDocumento.Focus();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnGenerados_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Ventas.Formularios.frmDocumento form = new SIGA.Windows.Ventas.Formularios.frmDocumento();
            form.ShowDialog();
        }

        private void cboDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDocumento.Text == "Factura")
            {
                txtImpuesto.Visible = true;
                lblImpuesto.Visible = true;

                txtTotal.Text = "0";
                txtDescuento.Text = "0";
                txtImpuesto.Text = "0";
                txtNeto.Text = "0";


            }

            if (cboDocumento.Text == "Boleta")
            {
                txtImpuesto.Visible = false;
                lblImpuesto.Visible = false;
                txtTotal.Text = "0";
                txtDescuento.Text = "0";
                txtImpuesto.Text = "0";
                txtNeto.Text = "0";


            }

            Importes();
        }



        public decimal CalculaTotal(decimal precio, decimal cantidad)
        {
            return precio * cantidad;
        }

        public void BuscarProducto(string codigoBarra)
        {



        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }



        //private void btnAgregar_Click(object sender, EventArgs e)
        //{
        //    ItemVenta objVenta = new ItemVenta();

        //    objVenta.Codigo = Convert.ToInt32(txtCodigo.Text);
        //    objVenta.CodigoArticulo = txtCodigoExterno.Text;
        //    objVenta.Descripcion = txtDescripcion.Text;
        //    objVenta.Cantidad = Convert.ToDecimal(txtCantidad.Text);
        //    objVenta.Precio = Convert.ToDecimal(txtPrecio.Text);
        //    objVenta.Stock = Convert.ToDecimal(12);
        //    objVenta.Total = Convert.ToDecimal(txtTotal.Text);
        //    objVenta.CodigoEmpresa = Convert.ToByte(txtEmpresa.Text);

        //    Venta = objVenta;

        //    this.Close();
        //}

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {



        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {

        }

        public string BuscarPorCodigoZurece(string CodigoArticulo)
        {
            int Tamano = 0;
            string pCodigoBarra = string.Empty;
            GeneralBusiness objGeneral = new GeneralBusiness();

            try
            {
                Tamano = CodigoArticulo.Length;

                //001002va

                if (Tamano == 6)
                {
                    var generalResult = objGeneral.BuscarPorCodigoZurece(CodigoArticulo);

                    if (generalResult != null)
                    {
                        pCodigoBarra = generalResult.CodBarra;


                    }
                }
            }

            catch (Exception ex)
            {

            }



            return pCodigoBarra;

        }


        public void BuscarDatos(string CodigoBarra)
        {
            int Tamano = 0;
            GeneralBusiness objGeneral = new GeneralBusiness();

            try
            {
                Tamano = CodigoBarra.Length;

                if (Tamano > 0)
                {
                    var generalResult = objGeneral.BuscarPorCodigoBarra(CodigoBarra);

                    if (generalResult != null)
                    {

                        InsertarItem(0,generalResult.CodBarra, generalResult.CodGeneral, generalResult.CodEmpresa, generalResult.CodExtGeneral, generalResult.DesLarGeneral,"1",generalResult.stock.ToString());

                    }
                }
            }

            catch (Exception ex)
            {

            }

        }



        private void txtPrecio_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                decimal Total = 0;
                Total = CalculaTotal(Convert.ToDecimal(txtCantidad.Text == "" ? 0 : Convert.ToDecimal(txtCantidad.Text)), Convert.ToDecimal(txtPrecio.Text == "" ? 0 : Convert.ToDecimal(txtPrecio.Text)));
                txtTotal.Text = Total.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmVentaMinorista_KeyUp(object sender, KeyEventArgs e)
        {
            //switch (e.KeyValue)
            //{
            //    case 16:

            //        dgvItems.Rows.Insert(dgvItems.Rows.Count, "", 0, "", "", 0, 0, 0, Convert.ToDecimal(0), "", true);
            //        dgvItems.Focus();
            //        dgvItems.CurrentCell = dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[0];
            //        break;
            //    case (char)Keys.W:
            //        label3.Text = "Tecla W en el formulario (KeyUp)";
            //        //textBox3.Text += "\r\nTecla W en el formulario (KeyUp)";
            //        break;
            //}

        }

        private void frmVentaMinorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            //switch (e.KeyChar)
            //{
            //    case (char)Keys.W: // mayúsculas
            //    case (char)(Keys.W + 32): // minúsculas
            //        label3.Text += "\nTecla W en el formulario";
            //        //  textBox3.Text += "\r\nTecla W en el formulario (KeyPress)";
            //        break;
            //    case (char)Keys.S:
            //    case (char)(Keys.S + 32): // minúsculas
            //        label3.Text += "\nTecla S en el formulario";
            //        break;
            //}

        }


        private void txtCantidad_TextChanged_1(object sender, EventArgs e)
        {
            GeneralBusiness objBusiness = new GeneralBusiness();

            try
            {
                var result = objBusiness.BuscarPrecio(Convert.ToInt32(textBox1.Text));

                if (result != null)
                {
                    if (Convert.ToInt32(txtCantidad.Text) >= 0 && Convert.ToInt32(txtCantidad.Text) <= 2)
                    {
                        txtPrecio.Text = result.PrecioUno.ToString();

                    }

                    if (Convert.ToInt32(txtCantidad.Text) >= 3 && Convert.ToInt32(txtCantidad.Text) <= 6)
                    {
                        txtPrecio.Text = result.PrecioDos.ToString();

                    }

                    if (Convert.ToInt32(txtCantidad.Text) >= 7 && Convert.ToInt32(txtCantidad.Text) <= 10)
                    {
                        txtPrecio.Text = result.PrecioTres.ToString();

                    }

                    if (Convert.ToInt32(txtCantidad.Text) >= 11)
                    {
                        txtPrecio.Text = result.PrecioCuatro.ToString();

                    }

                }

                decimal Total = 0;
                Total = CalculaTotal(Convert.ToDecimal(txtCantidad.Text == "" ? 0 : Convert.ToDecimal(txtCantidad.Text)), Convert.ToDecimal(txtPrecio.Text == "" ? 0 : Convert.ToDecimal(txtPrecio.Text)));
                textBox2.Text = Total.ToString();

            }
            catch
            {

            }

        }

       

       

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

      
        private void timer1_Tick(object sender, EventArgs e)
        {

            SIGA.Business.Caja.CajeroBusiness objCajero = new SIGA.Business.Caja.CajeroBusiness();
            var result = objCajero.CajaPeticion(CodigoCaja);

            if (result == true)
            {
                label14.Text = "Se le solicita un pase de dinero...!";
                timer1.Enabled = false;
                timer1.Stop();
            }
            else
            {
                label14.Text = string.Empty;
            }
            

        }

        private void label14_Click(object sender, EventArgs e)
        {
           
            SIGA.Business.Caja.CajeroBusiness objCajero = new SIGA.Business.Caja.CajeroBusiness();
           

            var resultado = objCajero.ActualizarPeticion(CodigoCaja, "I");

            if (resultado >= 0)
            {
              
                timer1.Start();
            }

        }
        }

     

        

      





    }






