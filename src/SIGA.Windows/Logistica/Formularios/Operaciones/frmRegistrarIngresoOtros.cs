using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios.Operaciones
{
    public partial class frmRegistrarIngresoOtros : Form
    {
        public frmRegistrarIngresoOtros()
        {
            InitializeComponent();
        }

        private void frmRegistrarIngresoOtros_Load(object sender, EventArgs e)
        {
            CargaTipoDocumento();
            CargaAlmacenIngreso(1);
            //CargaSede();
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnImprimir.Enabled = false;
            btnSalir.Enabled = true;
            Salir.Enabled = true;
            cboTipoDocumento.Text = "Factura";
            txtNumeroOrigen.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtRuc.Text = string.Empty;
            txtSubTotal.Text = "0";
            txtIgv.Text = "0";
            txtTotal.Text = "0";
            CargaTipoCambio();
            /*CargaEmpresa();*/
            cboMoneda.Text = "Soles";

        }

        /*private void CargaEmpresa()
        {
            SIGA.Business.Logistica.EmpresaBusiness objMarcaBusiness = new SIGA.Business.Logistica.EmpresaBusiness();
            List<SIGA.Entities.Logistica.Empresa> Lista = new List<SIGA.Entities.Logistica.Empresa>();

            Lista.Add(new SIGA.Entities.Logistica.Empresa { CodEmpresa = 0, DesEmpresa = "Seleccione" });

            var resutlMarca = objMarcaBusiness.Listar();

            foreach (var item in resutlMarca)
            {
                Lista.Add(item);
            }

            //cboEmpresa.DataSource = Lista;
            cboEmpresa.ValueMember = "CodEmpresa";
            cboEmpresa.DisplayMember = "DesEmpresa";

        }*/       

        private void CargaTipoCambio()
        {
            /* SIGA.Business.Caja.TipoCambioBusiness obj = new SIGA.Business.Caja.TipoCambioBusiness();
             var ResultHoy = obj.TipoCambioHoy();

             if (ResultHoy.Rows.Count > 0)
             {
                 txtTC.Text = ResultHoy.Rows[0][0].ToString();
             }*/


        }

        private void CargaTipoDocumento()
        {
            SIGA.Business.Logistica.TipoDocumentoBusiness ObjSede = new SIGA.Business.Logistica.TipoDocumentoBusiness();
            cboTipoDocumento.DataSource = ObjSede.Listar();
            cboTipoDocumento.ValueMember = "CodTipoDocumento";
            cboTipoDocumento.DisplayMember = "DesDocumento";
            cboTipoDocumento.SelectedValue = "01";

        }

        private void CargaSede()
        {
            /*SIGA.Business.Logistica.SedeBusiness objSede = new SIGA.Business.Logistica.SedeBusiness();
            List<SIGA.Entities.Logistica.Sede> Lista = new List<SIGA.Entities.Logistica.Sede>();

            Lista.Add(new SIGA.Entities.Logistica.Sede { CodSede = 0, DesSede = "Seleccione" });

            var resutlMarca = objSede.Listar();

            foreach (var item in resutlMarca)
            {
                Lista.Add(item);
            }

            cboSede.DataSource = Lista;
            cboSede.ValueMember = "CodSede";
            cboSede.DisplayMember = "DesSede";*/

        }


        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            //SIGA.Windows.Logistica.Formularios.Busquedas.frmBuscaProveedor objBusquedaProveedor = new SIGA.Windows.Logistica.Formularios.Busquedas.frmBuscaProveedor();
            //objBusquedaProveedor.ShowDialog();
            //txtCodigoProveedor.Text = objBusquedaProveedor.CodigoProveedor.ToString();
            //txtRazonSocial.Text = objBusquedaProveedor.RazonSocial.ToString();
            //txtRuc.Text = objBusquedaProveedor.Ruc.ToString();

            SIGA.Windows.Comunes.frmProveedorBuscar objfrmProveedorBuscar = new SIGA.Windows.Comunes.frmProveedorBuscar();
            objfrmProveedorBuscar.ShowDialog();
            txtCodigoProveedor.Text = objfrmProveedorBuscar.CodigoProveedor;
            txtRazonSocial.Text = objfrmProveedorBuscar.NombreProveedor.ToString();
            txtRuc.Text = objfrmProveedorBuscar.Ruc;
        }

        private bool Validar()
        {
            bool Validado = true;
            if (cboTipoDocumento.Text.Equals(string.Empty))
            {
                Validado = false;
                return Validado;
            }

            if (txtNumeroOrigen.Text.Equals(string.Empty))
            {
                Validado = false;
                return Validado;
            }

            if (txtCodigoProveedor.Text.Length.Equals(0))
            {
                Validado = false;
                return Validado;
            }


            if (txtTC.Text.Length.Equals(0))
            {
                Validado = false;
                return Validado;
            }

            return Validado;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SIGA.Business.Logistica.DocumentoProveedorBusiness objDocumento = new SIGA.Business.Logistica.DocumentoProveedorBusiness();

            if (dgvItems.RowCount.Equals(0))
            {
                MessageBox.Show("Debe ingresar datos necesarios...!");
                return;
            }
            if (cboTipoDocumento.Text == string.Empty || txtNumeroOrigen.Text == string.Empty || txtCodigoProveedor.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar datos necesarios...!");
                return;
            }

            if (objDocumento.ConsultarPorDocumentoIngresado(Convert.ToInt32(cboTipoDocumento.SelectedValue), txtNumeroOrigen.Text, Convert.ToInt32(txtCodigoProveedor.Text)).Rows.Count > 0)
            {
                MessageBox.Show("Ya esta ingresado un documento...!");
                return;
            }
            else
            {
                Insertar();
            }

        }

        private Decimal TotalDocumento()
        {
            Decimal Total = 0;
            string Valor = "";

            for (int i = 0; i < dgvItems.Rows.Count; i++)
            {


                Total = Total + (decimal)dgvItems[8, i].Value;

            }

            return Total;

        }

        private void IngresarItem(int CodigoDOcumento, int CodigoGeneral, string CodigoExterno, Int16 CodigoEmpresa, string Descripcion, Decimal Cantidad, decimal PrecioAnterior, Decimal Precio, Decimal Total, string NotaIngreso, string OC)
        {

            dgvItems.Rows.Insert(dgvItems.Rows.Count, CodigoDOcumento, CodigoGeneral, CodigoExterno, CodigoEmpresa, Descripcion, Cantidad, PrecioAnterior, Precio, Total, NotaIngreso, OC);
            dgvItems.Focus();
            //dgvItems.CurrentCell = dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[0];
        }
        private void ImportesCalculo()
        {
            var doTotal = TotalDocumento();


            Decimal totalconigv = 0;
            Decimal subTotal = 0;
            Decimal IGV = 0;

            if (chkIGV.Checked == true)
            {
                txtTotal.Text = doTotal.ToString("######.00");

                subTotal = Convert.ToDecimal(doTotal) / Convert.ToDecimal(1.18);

                IGV = doTotal - subTotal;

                txtIgv.Text = IGV.ToString("######.00");
                txtSubTotal.Text = subTotal.ToString("######.00");

            }

            else
            {
                subTotal = doTotal;
                IGV = subTotal * Convert.ToDecimal(0.18);
                totalconigv = subTotal + IGV;
                txtSubTotal.Text = subTotal.ToString("######.00");
                txtIgv.Text = IGV.ToString("######.00");
                txtTotal.Text = totalconigv.ToString("######.00");

            }

        }

        public List<SIGA.Entities.Logistica.DetalleDocumentoProveedor> Lista()
        {
            List<SIGA.Entities.Logistica.DetalleDocumentoProveedor> ListaDocumento = new List<SIGA.Entities.Logistica.DetalleDocumentoProveedor>();


            foreach (DataGridViewRow row in this.dgvItems.Rows)
            {

                SIGA.Entities.Logistica.DetalleDocumentoProveedor Item = new SIGA.Entities.Logistica.DetalleDocumentoProveedor();


                Item.Codigo = Convert.ToInt32(row.Cells[0].Value);
                Item.CodigoGeneral = Convert.ToInt32(row.Cells[0].Value);
                Item.CodigoExterno = Convert.ToString(row.Cells[2].Value);

                Item.CodigoEmpresa = Convert.ToInt16(cboEmpresa.SelectedValue);
                Item.CodigoAlmacen = Convert.ToInt16(cboAlmacen.SelectedValue);

                Item.DescripcionLarga = Convert.ToString(row.Cells[4].Value);


                Item.Cantidad = Convert.ToDecimal(row.Cells[5].Value);

                Item.Precio = Math.Round(Convert.ToDecimal(row.Cells[7].Value), 2);

                Item.Total = Math.Round(Convert.ToDecimal(row.Cells[8].Value), 2);

                Item.NumeroGuia = string.Empty;
                Item.NumeroOrden = string.Empty;

                ListaDocumento.Add(Item);

            }

            return ListaDocumento;

        }

        private string ObtenerCorreosEnvio()
        {
            StringBuilder correos = new StringBuilder();


            return correos.ToString();
        }

        protected void Insertar()
        {
            string Numero = string.Empty;
            SIGA.Comun.EnvioCorreo objEnvioCorreo = new SIGA.Comun.EnvioCorreo();

            SIGA.Business.Logistica.DocumentoProveedorBusiness objDocumento = new SIGA.Business.Logistica.DocumentoProveedorBusiness();
            SIGA.Entities.Logistica.DocumentoProveedor objDocumentoVenta = new SIGA.Entities.Logistica.DocumentoProveedor();
            string strCorreos = ObtenerCorreosEnvio();
            string NumeroOrdenGenerada = string.Empty;
            StringBuilder strMensaje = new StringBuilder();


            var Items = Lista();
            int Codigo = 0;


            objDocumentoVenta.CodTipoDocumento = cboTipoDocumento.SelectedValue.ToString();
            objDocumentoVenta.NumDocumento = txtNumeroOrigen.Text;
            objDocumentoVenta.ProCodigo = Convert.ToInt32(txtCodigoProveedor.Text);
            objDocumentoVenta.Compra = true;
            objDocumentoVenta.CodEmpresa = Convert.ToInt16(cboEmpresa.SelectedValue);
            objDocumentoVenta.CodigoAlmacen = Convert.ToInt16(cboAlmacen.SelectedValue);


            // objDocumentoVenta.ProCodigo = 0;

            objDocumentoVenta.FecDocumento = dtpFecha.Value;
            objDocumentoVenta.FecRecepcion = dtRecepcion.Value;
            objDocumentoVenta.CodMoneda = Convert.ToInt16(cboMoneda.Text == "Soles" ? 1 : 2);
            //objDocumentoVenta.CodEmpresa = Convert.ToInt16(cboEmpresa.SelectedValue);
            objDocumentoVenta.CodigoEstado = 1;
            objDocumentoVenta.SubTotal = Math.Round(Convert.ToDecimal(txtSubTotal.Text), 2);
            objDocumentoVenta.Impuesto = Math.Round(Convert.ToDecimal(txtIgv.Text), 2);

            objDocumentoVenta.Total = Math.Round(Convert.ToDecimal(txtTotal.Text), 2);

            objDocumentoVenta.TipoCambio = Math.Round(Convert.ToDecimal(txtTC.Text), 2);
            objDocumentoVenta.IncluyeIGV = Convert.ToBoolean(chkIGV.Checked);
            objDocumentoVenta.UsuarioCreacion = UsuarioLogeo.Codigo;

            Codigo = objDocumento.InsertarDocumentoNew(objDocumentoVenta, Items, Convert.ToInt16(cboAlmacen.SelectedValue), Convert.ToInt32(0), ref Numero);

            if (Codigo > 0)
            {

                MessageBox.Show("Se registro el ingreso...!", "Logistica");

                grpDatos.Enabled = false;
                btnAgregar.Enabled = false;
                button2.Enabled = false;
                dgvItems.Enabled = false;
                txtSubTotal.Enabled = false;
                txtIgv.Enabled = false;
                txtTotal.Enabled = false;
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;






                strMensaje.Append("Estimado sr(a) le informamos que se ha registrado un ingreso de mercaderia sin Orden de Compra ");


                strMensaje.Append("Para el proveedor :");
                strMensaje.AppendLine();
                strMensaje.Append(txtRazonSocial.Text);

                strMensaje.AppendLine();

                strMensaje.Append("Con el documento:");
                strMensaje.Append(cboTipoDocumento.Text);

                strMensaje.Append("");

                strMensaje.Append(txtNumeroOrigen.Text);

                strMensaje.AppendLine();

                strMensaje.Append("Con el Monto :");
                strMensaje.Append(cboMoneda.Text);
                strMensaje.Append("");

                strMensaje.Append(Math.Round(Convert.ToDecimal(txtTotal.Text), 2));




                strMensaje.Append(" El dia:");
                strMensaje.Append(DateTime.Now.Date.ToShortDateString());


                strMensaje.AppendLine();
                strMensaje.Append("Agradeceremos tomar las previsiones del caso");
                strMensaje.AppendLine();
                strMensaje.Append("Att - SIGA-Logistica");

                objEnvioCorreo.sbEnviar(strCorreos, "SIGA-DOCUMENTOS SIN ORDEN DE COMPRA", strMensaje.ToString(), null, null);


            }
            else
            {
                MessageBox.Show("No se registro el ingreso...!", "Logistica");
            }


        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            //dgvItems[4, dgvItems.CurrentRow.Index].Value = dgvEmpleado.Item(2, dgvEmpleado.CurrentRow.Index).Value * dgvEmpleado.Item(3, dgvEmpleado.CurrentRow.Index).Value;

            int Cantidad = 0;
            int Stock = 0;
            decimal Precio = 0;
            decimal totalFila = 0;
            string pCodigoBarra = string.Empty;

            try
            {




            }

            catch (Exception ex)
            {
            }


        }

        private void cboSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*try
            {
                CargaAlmacenIngreso(Convert.ToInt16(cboSede.SelectedValue));
            }
            catch (Exception ex)
            {

            }*/
        }

        private void CargaAlmacenIngreso(Int16 CodigoSede)
        {
            cboAlmacen.DataSource = null;

            SIGA.Business.Logistica.AlmacenBusiness objAlmacenBusiness = new SIGA.Business.Logistica.AlmacenBusiness();
            List<SIGA.Entities.Logistica.Almacen> Lista = new List<SIGA.Entities.Logistica.Almacen>();
            Lista.Add(new SIGA.Entities.Logistica.Almacen { CodAlmacen = 0, DesAlmacen = "Seleccione" });


            var resutlMarca = objAlmacenBusiness.ListarPorSede(CodigoSede);

            foreach (var item in resutlMarca)
            {
                Lista.Add(item);
            }



            cboAlmacen.DataSource = Lista;
            cboAlmacen.ValueMember = "CodAlmacen";
            cboAlmacen.DisplayMember = "DesAlmacen";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {   /*
            if ((Convert.ToInt32(cboSede.SelectedValue) > 0 && Convert.ToInt32(cboAlmacen.SelectedValue) > 0 && Convert.ToInt32(cboEmpresa.SelectedValue) > 0))
            {
                IngresarItem(0, 0, "", Convert.ToInt16(cboEmpresa.SelectedValue), "", 0, 0,0, 0, "", "");
                ImportesCalculo();
            }
            else
            {
                MessageBox.Show("Faltan seleccionar los datos adecuadamente...");
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Codigo = 0;

            try
            {
                if (dgvItems.Rows.Count == 0)
                {
                    MessageBox.Show("No hay items apra eliminar..");
                    return;
                }

                //Codigo = Convert.ToInt32(dgvItems[0, dgvItems.CurrentRow.Index].Value);


                if (dgvItems.RowCount > 0)
                {
                    int index = dgvItems.CurrentCell.RowIndex;
                    dgvItems.Rows.RemoveAt(index);
                    ImportesCalculo();
                }

            }

            catch (Exception ex)
            {

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            grpDatos.Enabled = true;
            btnAgregar.Enabled = true;
            button2.Enabled = true;
            dgvItems.Enabled = true;
            txtSubTotal.Enabled = true;
            txtIgv.Enabled = true;
            txtTotal.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            CargaTipoDocumento();
            CargaSede();

            cboTipoDocumento.SelectedIndex = -1;
            txtNumeroOrigen.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtRuc.Text = string.Empty;
            txtSubTotal.Text = "0";
            txtIgv.Text = "0";
            txtTotal.Text = "0";
            CargaTipoCambio();
            // CargaEmpresa();
            cboMoneda.Text = "Soles";
            dgvItems.Rows.Clear();
            txtCodigoProveedor.Text = "0";
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMoneda.Text.Equals("Soles"))
                {
                    lblTC.Visible = false;
                    txtTC.Visible = false;

                }
                else
                {
                    lblTC.Visible = true;
                    txtTC.Visible = true;

                }


            }
            catch (Exception ex)
            {

            }
        }

        private void dtRecepcion_ValueChanged(object sender, EventArgs e)
        {
            /*SIGA.Business.Caja.TipoCambioBusiness obj = new SIGA.Business.Caja.TipoCambioBusiness();

            try
            {
                var result = obj.TipoCambioConsultarPorFecha(dtRecepcion.Value.ToString("yyyyMMdd"));

                if (result.Rows.Count > 0)
                {
                    txtTC.Text = result.Rows[0][1].ToString();
                }
                else
                {
                    txtTC.Text = "0";
                }


            }
            catch
            {

            }*/

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {


        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
