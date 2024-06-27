using SIGA.Business.Logistica;
using SIGA.Business.Ventas;
using SIGA.Entities.Logistica;
using SIGA.Entities.Ventas;
using SIGA.Windows.Ventas.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios
{
    public partial class frmRegistroOC : Form
    {
        public int CodigoOC { get; set; }
        public int CodigoProveedor { get; set; }
        public frmRegistroOC()
        {
            InitializeComponent();
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
        private void frmRegistroOC_Load(object sender, EventArgs e)
        {
            CargarFormaPago();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Comunes.frmProveedorBuscar objfrmProveedorBuscar = new SIGA.Windows.Comunes.frmProveedorBuscar();
            objfrmProveedorBuscar.ShowDialog();
            CodigoProveedor = Convert.ToInt32(objfrmProveedorBuscar.CodigoProveedor);
            txtRazonSocial.Text = objfrmProveedorBuscar.NombreProveedor;
            txtDireccion.Text = objfrmProveedorBuscar.Direccion;
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarFila();
            Importes();
        }

        private void AgregarFila()
        {
            dgvItems.ClearSelection();

            dgvItems.Rows.Insert(dgvItems.Rows.Count, 0, "", "", "", "", Convert.ToDecimal(0), Convert.ToDecimal(0));
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
                    Total += Convert.ToDecimal(row.Cells[6].Value);
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
                if ((e.ColumnIndex == 1) || (e.ColumnIndex == 5) || (e.ColumnIndex == 6))
                {

                    if (dgvItems.CurrentRow != null)
                    {
                        cantidad = Convert.ToDecimal(dgvItems[1, dgvItems.CurrentRow.Index].Value);
                        precio = Convert.ToDecimal(dgvItems[5, dgvItems.CurrentRow.Index].Value);
                        total = precio * cantidad;
                        //dgvItems[6, dgvItems.CurrentRow.Index].Value = Total.ToString();

                        dgvItems[6, dgvItems.CurrentRow.Index].Value = total.ToString();


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
                    this.dgvItems[5, this.dgvItems.CurrentRow.Index].Value = 0;
                    this.dgvItems[6, this.dgvItems.CurrentRow.Index].Value = Convert.ToDecimal(this.dgvItems[5, this.dgvItems.CurrentRow.Index].Value) * Convert.ToDecimal(this.dgvItems[1, this.dgvItems.CurrentRow.Index].Value);
                    this.dgvItems.CurrentCell = dgvItems[1, this.dgvItems.CurrentRow.Index];
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitarItem();
            Importes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvItems.RowCount > 0)
            {
                Guardar();
            }
            else
            {
                MessageBox.Show("Debe ingresar un item para registrar la orden de compra..!");
                return;
            }
        }

        public List<OrdenCompraDetalle> Lista()
        {
            List<OrdenCompraDetalle> ListaDocumento = new List<OrdenCompraDetalle>();

            foreach (DataGridViewRow row in this.dgvItems.Rows)
            {                
                OrdenCompraDetalle Item = new OrdenCompraDetalle();

                Item.OrdItem = row.Index + 1;
                Item.OrdCodigoGeneral = Convert.ToInt32(row.Cells[0].Value);
                Item.Cantidad = Convert.ToInt32(row.Cells[1].Value);
                Item.CodUnidadMedida = 2;                
                Item.OrdDescripcion = Convert.ToString(row.Cells[3].Value);                
                Item.Precio = Convert.ToDecimal(row.Cells[5].Value);
                Item.Total = Convert.ToDecimal(row.Cells[6].Value);
                ListaDocumento.Add(Item);
            }

            return ListaDocumento;
        }

        private void Guardar()
        {
            OrdenCompraBusiness ordenCompraBusiness = new OrdenCompraBusiness();
            OrdenCompra entOC = new OrdenCompra();

            try
            {

                entOC.OrdFechaEmision = dtFechaEmision.Value;
                entOC.OrdFechaEntrega = dtFechaEntrega.Value;
                entOC.CodProveedor = CodigoProveedor;
                entOC.CodMoneda = 1;
                entOC.OrdDireccion = txtDireccion.Text;
                entOC.OrdNroRuc = string.Empty;
                entOC.OrdContacto = string.Empty;
                entOC.OrdTelefono = string.Empty;
                entOC.CodFormaPago = Convert.ToInt32(cboFormaPago.SelectedValue);
                entOC.OrdReferencia = txtReferencia.Text;
                entOC.OrdNroCuentaCorriente = txtCTACTE.Text;
                entOC.OrdSolicitatoPor = txtSolicitado.Text;
                entOC.OrdNroCotizacion = txtCotNro.Text;
                entOC.OrdObservacion = txtObservacion.Text;
                entOC.OrdEstado = 1;                
                entOC.UsuCodigo = UsuarioLogeo.Codigo;
                entOC.UsuCreCodigo = UsuarioLogeo.Codigo;
                
                var resultDetalle = Lista();

                var result = ordenCompraBusiness.InsertarOC(entOC, resultDetalle);

                if (result != null)
                {
                    CodigoOC = Convert.ToInt32(result.OrdNumero);
                    MessageBox.Show("Se ha generado la orden de compra " + result.OrdNumero);
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
    }
}