using SIGA.Business.Administrador;
using SIGA.Business.Logistica;
using SIGA.Business.Ventas;
using SIGA.Entities.Logistica;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmGuia : Form
    {
        public int CodigoGuia { get; set; }
        public frmGuia()
        {
            InitializeComponent();
        }


        #region "Carga Combos"

        private void CargarUsuarios()
        {

            UsuarioBusiness objBusiness = new UsuarioBusiness();
            SIGA.Entities.Administrador.Usuario objUsuario = new SIGA.Entities.Administrador.Usuario()
            {
                ApellidoPaterno = String.Empty,
                ApellidoMaterno = String.Empty,
                Nombre = String.Empty,
                IdentificadorUsuario = String.Empty,
                CorreoElectronico = String.Empty,
                CodigoEstadoUsuario = "A"
            };

            try
            {
                var result = objBusiness.ObtenerUsuarios(objUsuario);
                cboVendedor.DataSource = result;
                cboVendedor.ValueMember = "CodigoUsuario";
                cboVendedor.DisplayMember = "NombreBusqueda";


            }
            catch (Exception ex)
            {
            }
        }
        void CargarTipoDocIdentidad()
        {
            TipoDocumentoIdentidadBusiness objDocumentoBussiness = new TipoDocumentoIdentidadBusiness();

            List<TipoDocumentoIdentificacion> Lista = new List<TipoDocumentoIdentificacion>();


            var consulta = objDocumentoBussiness.ListarTipoDocumentoIdentidad();

            foreach (var item in consulta)
            {
                Lista.Add(item);
            }

            cboTipoDocumento.DataSource = Lista;
            cboTipoDocumento.ValueMember = "CodTipoDocumento";
            cboTipoDocumento.DisplayMember = "DesDocumento";
        }

        private void CargarPolitica()
        {
            PoliticaPrecioBusiness objPolitica = new PoliticaPrecioBusiness();
            PoliticaPrecio entPolitica = new PoliticaPrecio()
            {
                DesPolitica = String.Empty,
                EstCodigo = "A"
            };

            try
            {
                var result = objPolitica.ObtenerPolitica(entPolitica);
                cboPolitica.DataSource = result;
                cboPolitica.DisplayMember = "DesPolitica";
                cboPolitica.ValueMember = "CodPolitica";


            }
            catch (Exception ex)
            {


            }
        }

        public void CargarZona()
        {
            ZonaBusiness objZona = new ZonaBusiness();
            Zona EntZona = new Zona();
            EntZona.IdZona = 0;
            EntZona.Descripcion = String.Empty;
            EntZona.Estado = "A";

            cboZona.DataSource = objZona.ObtenerZonas(EntZona);
            cboZona.ValueMember = "idZona";
            cboZona.DisplayMember = "Descripcion";
        }

        #endregion
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Comunes.frmClienteBuscar objfrmClienteBuscar = new SIGA.Windows.Comunes.frmClienteBuscar();
            objfrmClienteBuscar.ShowDialog();
            txtCodigoCliente.Text = objfrmClienteBuscar.CodigoCliente;
            txtRazonSocial.Text = objfrmClienteBuscar.NombreCliente;
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            SIGA.Business.Ventas.ClienteBusiness obj = new SIGA.Business.Ventas.ClienteBusiness();
            SIGA.Entities.Ventas.ClienteResponse objCliente = new SIGA.Entities.Ventas.ClienteResponse()
            {
                CodCliente = txtCodigoCliente.Text
            };

            try
            {
                if (txtCodigoCliente.TextLength >= 6)
                {

                    var result = obj.ObtenerClientePorCodigo(objCliente);
                    cboTipoDocumento.SelectedValue = Convert.ToInt16(result.CodTipoDocumento);
                    cboPolitica.SelectedValue = Convert.ToInt32(result.CodPolitica);
                    txtNumero.Text = result.NumDocumentoCliente.ToString();
                    txtDireccion.Text = result.DirCliente.ToString();
                    cargaBdListaPlacas(txtCodigoCliente.Text);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void frmGuia_Load(object sender, EventArgs e)
        {
            CargarPolitica();
            CargarZona();
            CargarTipoDocIdentidad();
            CargarUsuarios();
            CargarFormaPago();
            btnGuardar.Enabled = true;
            btnImprimir.Enabled = false;
            btnSalir.Enabled = true;

            txtCodigoTransporte.Text = "0";
            lblPlaca.Visible = true;
            cboPlacaAuto.Visible = true;
            lblPlacaTercero.Visible = false;
            txtEmpresa.Visible = false;
            btnBuscarTranportista.Visible = false;
            txtPlaca.Visible = false;
            txtEmpresa.Text = string.Empty;
            txtPlaca.Text = string.Empty;

        }
        private void CargarFormaPago()
        {
            FormaPagoBusiness objFormaPagoBusiness = new FormaPagoBusiness();
            FormaPago formaPago = new FormaPago()
            {
                DesFormaPago = "",
                EstCodigo = ""
            };


            try
            {
                var result = objFormaPagoBusiness.ObtenerListaPago(formaPago);
                cboFormaPago.DataSource = result;
                cboFormaPago.ValueMember = "CodFormaPago";
                cboFormaPago.DisplayMember = "DesFormaPago";

            }
            catch (Exception ex)
            {

            }
        }

        private void cargaBdListaPlacas(string CodigoCliente)
        {


            ClienteBusiness clienteBusiness = new ClienteBusiness();
            try
            {
                var result = clienteBusiness.ListarPlacas(CodigoCliente);


                cboPlacaAuto.DataSource = result;
                cboPlacaAuto.ValueMember = "CodigoRegistro";
                cboPlacaAuto.DisplayMember = "PlacaVehiculo";


            }
            catch (Exception ex)
            {

            }

        }
        private List<ImportesDocumento> TotalDocumento()
        {
            Decimal Total = 0;
            Decimal Inafecto = 0;
            Decimal Gravado = 0;

            List<ImportesDocumento> objImporte = new List<ImportesDocumento>();
            ImportesDocumento itemDocumento = new ImportesDocumento();

            try
            {

                foreach (DataGridViewRow row in this.dgvItems.Rows)
                {


                    Total = Total + Convert.ToDecimal(row.Cells[8].Value);
                }


                itemDocumento.TotalDocumento = Total;
                itemDocumento.Afecto = Gravado;
                itemDocumento.Inafecto = Inafecto;

                objImporte.Add(itemDocumento);
            }
            catch (Exception ex)
            {

            }

            return objImporte;

        }


        private void Importes()
        {
            Decimal Neto = Convert.ToDecimal(0.0);
            Decimal NoGravado = Convert.ToDecimal(0.0);
            Decimal Gravado = Convert.ToDecimal(0.0);


            var listaImportes = TotalDocumento().SingleOrDefault(); /*Cargando la lista de importes*/

            try
            {
                if (listaImportes != null)
                {
                    NoGravado = Convert.ToDecimal(0);
                    Gravado = Convert.ToDecimal(0) / Convert.ToDecimal(1.18);
                    /* Neto = NoGravado + Gravado + Impuesto;*/
                    Neto = Convert.ToDecimal(listaImportes.TotalDocumento);

                }

                txtTotal.Text = Neto.ToString("#######.000");


            }
            catch (Exception ex)
            {

            }



        }
        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Decimal cantidad, precio, total;

            try
            {
                if ((e.ColumnIndex == 1) || (e.ColumnIndex == 7) || (e.ColumnIndex == 8))
                {

                    if (dgvItems.CurrentRow != null)
                    {
                        cantidad = Convert.ToDecimal(dgvItems[1, dgvItems.CurrentRow.Index].Value);
                        precio = Convert.ToDecimal(dgvItems[7, dgvItems.CurrentRow.Index].Value);
                        total = precio * cantidad;
                        //dgvItems[6, dgvItems.CurrentRow.Index].Value = Total.ToString();

                        dgvItems[8, dgvItems.CurrentRow.Index].Value = total.ToString();


                    }
                }
                Importes();

            }
            catch (Exception ex)
            {

            }
        }
        private void dgvItems_CellDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            int CodigoGeneral = 0;

            try
            {
                SIGA.Windows.Comunes.frmProductoBuscar obj = new Comunes.frmProductoBuscar();
                obj.ShowDialog();

                if (obj.CodigoGeneral != 0)
                {

                    CodigoGeneral = obj.CodigoGeneral;
                    this.dgvItems[0, this.dgvItems.CurrentRow.Index].Value = obj.CodigoGeneral;
                    this.dgvItems[1, this.dgvItems.CurrentRow.Index].Value = 1;
                    this.dgvItems[2, this.dgvItems.CurrentRow.Index].Value = obj.CodigoExterno.ToString();
                    this.dgvItems[3, this.dgvItems.CurrentRow.Index].Value = obj.Descripcion.ToString();
                    this.dgvItems[4, this.dgvItems.CurrentRow.Index].Value = "MILLAR";
                    this.dgvItems[5, this.dgvItems.CurrentRow.Index].Value = string.Empty;
                    this.dgvItems[6, this.dgvItems.CurrentRow.Index].Value = string.Empty;
                    this.dgvItems[7, this.dgvItems.CurrentRow.Index].Value = DevuelvePrecioPorItem(Convert.ToInt32(obj.CodigoGeneral), Convert.ToInt32(cboPolitica.SelectedValue), Convert.ToInt32(cboZona.SelectedValue));
                    this.dgvItems.CurrentCell = dgvItems[1, this.dgvItems.CurrentRow.Index];
                }


            }
            catch (Exception ex)
            {

            }
        }
        public decimal DevuelvePrecioPorItem(int CodGeneral, int CodPolitica, int CodZona)
        {
            PrecioBusiness objPrecio = new PrecioBusiness();
            decimal precio = 0;

            try
            {
                var result = objPrecio.DevuelvePrecioPorItem(CodGeneral, CodPolitica, CodZona);
                if (result.Rows.Count > 0)
                {
                    precio = Convert.ToDecimal(result.Rows[0][0]);
                }

            }
            catch (Exception ex)
            {

            }
            return precio;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarFila();
            Importes();
        }


        private void AgregarFila()
        {
            dgvItems.ClearSelection();


            dgvItems.Rows.Insert(dgvItems.Rows.Count, 0, "", "", "", "", "", "", Convert.ToDecimal(0), Convert.ToDecimal(0));
            dgvItems.Focus();
            dgvItems.CurrentCell = dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[2];


            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[2].Selected = true;
            dgvItems.BeginEdit(true);


        }

        private void QuitarItem()
        {
            if (dgvItems.RowCount > 0)
            {
                int index = dgvItems.CurrentCell.RowIndex;
                dgvItems.Rows.RemoveAt(index);

            }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitarItem();
            Importes();
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvItems.RowCount > 0)
            {
                GuardarGuia();
            }
            else
            {
                MessageBox.Show("Debe ingresar un item para registrar la proforma..!");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public List<GuiaDetalle> Lista()
        {
            List<GuiaDetalle> ListaDocumento = new List<GuiaDetalle>();


            foreach (DataGridViewRow row in this.dgvItems.Rows)
            {
                // Verificar si la fila no es la fila de encabezado

                GuiaDetalle Item = new GuiaDetalle();

                //Item.CodigoGeneral = Convert.ToInt32(row.Cells[0].Value);
                //Item.CodPolitica = Convert.ToInt32(cboPolitica.SelectedValue);
                //Item.CodMoneda = 1;
                //Item.CodZona = Convert.ToInt32(cboZona.SelectedValue);
                //Item.PrecioProducto = Convert.ToDecimal(row.Cells[5].Value);
                //Item.PrecioFlete = Convert.ToDecimal(row.Cells[6].Value);
                //Item.Usuario = 1;
                Item.CodGeneral = Convert.ToInt32(row.Cells[0].Value);
                Item.CodUnidadMedida = 2;
                Item.Cantidad = Convert.ToInt32(row.Cells[1].Value);
                Item.Pampa = Convert.ToString(row.Cells[5].Value);
                Item.Quema = Convert.ToString(row.Cells[6].Value);
                Item.Precio = Convert.ToDecimal(row.Cells[7].Value);
                Item.Total = Convert.ToDecimal(row.Cells[8].Value);
                ListaDocumento.Add(Item);
            }


            return ListaDocumento;

        }

        private void GuardarGuia()
        {
            GuiaBusiness objGuia = new GuiaBusiness();
            Guia entGuia = new Guia();

            int CodigoTransportista = 0;
            string PlacaVehciulo = string.Empty;

            CodigoTransportista = txtCodigoTransporte.Text.Equals("") ? Convert.ToInt32(0) : Convert.ToInt32(txtCodigoTransporte.Text);

            PlacaVehciulo = optPropio.Checked.Equals(true) ? cboPlacaAuto.Text : txtPlaca.Text;



            try

            {


                entGuia.CodEmpresa = 1;
                entGuia.CodOficina = 2;
                entGuia.CodPolitica = Convert.ToInt32(cboPolitica.SelectedValue);
                entGuia.CodZona = Convert.ToInt32(cboZona.SelectedValue);
                entGuia.GuiFecha = dtFecha.Value;
                entGuia.CodCliente = txtCodigoCliente.Text;
                entGuia.CodMoneda = 1;
                entGuia.GuiImporte = Convert.ToDecimal(txtTotal.Text);
                entGuia.GuiEstado = 1;
                entGuia.GuiVale = txtVale.Text;
                entGuia.GuiPlaca = PlacaVehciulo;
                entGuia.UsuCodigo = UsuarioLogeo.Codigo;
                entGuia.UsuCreCodigo = UsuarioLogeo.Codigo;
                entGuia.CodFormaPago = Convert.ToInt32(cboFormaPago.SelectedValue);
                entGuia.CodTransportista = CodigoTransportista;

                var resultDetalle = Lista();

                var result = objGuia.InsertarGuia(entGuia, resultDetalle);

                if (result != null)
                {
                    CodigoGuia = Convert.ToInt32(result.GuiNumero);
                    MessageBox.Show("Se ha generado la guia " + result.GuiNumero);
                    btnGuardar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnSalir.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirGuia(CodigoGuia);
        }

        private void ImprimirGuia(int Codigo)
        {
            SIGA.Windows.Comunes.frmImpresion objfrmReporte = new SIGA.Windows.Comunes.frmImpresion();
            string ruta = string.Empty;

            try
            {
                ruta = @"D:\Info_Pc\Ejemplos\Personal\Laprosur\03-Desarrollo\LaProSur\Fuentes\SIGA\SIGA.Windows\Reportes\rptControlInterno.rdlc";
                objfrmReporte.Archivo = "rptOrdenCompraZurece.rpt";
                objfrmReporte.Entidad = "USP_OrdenCompraImpresion";
                objfrmReporte.DataSource = DatosGuia(Codigo);
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

        private DataTable DatosGuia(int Codigo)
        {
            GuiaBusiness objGuia = new GuiaBusiness();
            return objGuia.DatosGuia(Codigo);
        }

        private void optPropio_CheckedChanged(object sender, EventArgs e)
        {
            if (optPropio.Checked == true)
            {
                txtCodigoTransporte.Text = "0";
                lblPlaca.Visible = true;
                cboPlacaAuto.Visible = true;
                lblPlacaTercero.Visible = false;
                txtEmpresa.Visible = false;
                btnBuscarTranportista.Visible = false;
                txtPlaca.Visible = false;
                txtEmpresa.Text = string.Empty;
                txtPlaca.Text = string.Empty;


            }

        }

        private void otpExterno_CheckedChanged(object sender, EventArgs e)
        {
            if (otpExterno.Checked == true)
            {
                txtCodigoTransporte.Text = "";
                lblPlaca.Visible = false;
                cboPlacaAuto.Visible = false;
                lblPlacaTercero.Visible = true;
                txtEmpresa.Visible = true;
                btnBuscarTranportista.Visible = true;
                txtPlaca.Visible = true;
                txtEmpresa.Text = string.Empty;
                txtPlaca.Text = string.Empty;


            }
        }

        private void btnBuscarTranportista_Click(object sender, EventArgs e)
        {
            frmBuscarVehiculo frmBuscarVehiculo = new frmBuscarVehiculo();
            frmBuscarVehiculo.ShowDialog();

            if (frmBuscarVehiculo.NumeroPlaca != null)
            {
                txtCodigoTransporte.Text = frmBuscarVehiculo.codigoTransportista.ToString();
                txtPlaca.Text = frmBuscarVehiculo.NumeroPlaca.ToString();
                txtEmpresa.Text = frmBuscarVehiculo.Transportista.ToString();

            }

        }
    }


}
