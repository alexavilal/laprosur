using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;
using SIGA.Windows.Ventas.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios
{
    public partial class frmRegistroNS : Form
    {
        public int CodigoOC { get; set; }
        public int CodigoProveedor { get; set; }
        public frmRegistroNS()
        {
            InitializeComponent();
        }

        private void CargaAlmacenIngreso(Int16 CodigoSede)
        {
            cboAlmacen.DataSource = null;

            AlmacenBusiness objAlmacenBusiness = new AlmacenBusiness();
            List<Almacen> Lista = new List<Almacen>();
            Lista.Add(new Almacen { CodAlmacen = 0, DesAlmacen = "Seleccione" });

            var resutlMarca = objAlmacenBusiness.ListarPorSede(CodigoSede);

            foreach (var item in resutlMarca)
            {
                Lista.Add(item);
            }



            cboAlmacen.DataSource = Lista;
            cboAlmacen.ValueMember = "CodAlmacen";
            cboAlmacen.DisplayMember = "DesAlmacen";
        }

        private void frmRegistroNS_Load(object sender, EventArgs e)
        {
            CargaAlmacenIngreso(1);
            cboMoneda.Text = "Soles";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Comunes.frmProveedorBuscar objfrmProveedorBuscar = new Comunes.frmProveedorBuscar();
            objfrmProveedorBuscar.ShowDialog();
            CodigoProveedor = Convert.ToInt32(objfrmProveedorBuscar.CodigoProveedor);
            txtRazonSocial.Text = objfrmProveedorBuscar.NombreProveedor;
            //txtCliente.Text = objfrmProveedorBuscar.Direccion;
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarFila();
            Importes();
        }

        private void AgregarFila()
        {
            dgvItems.ClearSelection();

            dgvItems.Rows.Insert(dgvItems.Rows.Count, 0, "", "", "", "", "", Convert.ToDecimal(0), Convert.ToDecimal(0));
            dgvItems.Focus();
            dgvItems.CurrentCell = dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[2];


            //dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[2].Selected = true;
            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[1].Selected = true;
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
                    Total += Convert.ToDecimal(row.Cells[7].Value);
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
                if ((e.ColumnIndex == 1) || (e.ColumnIndex == 6) || (e.ColumnIndex == 7))
                {

                    if (dgvItems.CurrentRow != null)
                    {
                        cantidad = Convert.ToDecimal(dgvItems[1, dgvItems.CurrentRow.Index].Value);
                        precio = Convert.ToDecimal(dgvItems[6, dgvItems.CurrentRow.Index].Value);
                        total = precio * cantidad;
                        //dgvItems[6, dgvItems.CurrentRow.Index].Value = Total.ToString();

                        dgvItems[7, dgvItems.CurrentRow.Index].Value = total.ToString();


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
                    this.dgvItems[5, this.dgvItems.CurrentRow.Index].Value = "Nts. 41100";
                    this.dgvItems[6, this.dgvItems.CurrentRow.Index].Value = 0;
                    this.dgvItems[7, this.dgvItems.CurrentRow.Index].Value = Convert.ToDecimal(this.dgvItems[5, this.dgvItems.CurrentRow.Index].Value) * Convert.ToDecimal(this.dgvItems[1, this.dgvItems.CurrentRow.Index].Value);
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
                MessageBox.Show("Debe ingresar un item para registrar la nota de salida..!");
                return;
            }
        }

        public List<NotaSalidaDetalle> Lista()
        {
            List<NotaSalidaDetalle> ListaDocumento = new List<NotaSalidaDetalle>();

            foreach (DataGridViewRow row in this.dgvItems.Rows)
            {                
                NotaSalidaDetalle Item = new NotaSalidaDetalle();

                Item.NtsItem = row.Index + 1;
                Item.CodigoGeneral = Convert.ToInt32(row.Cells[0].Value);
                Item.Cantidad = Convert.ToInt32(row.Cells[1].Value);
                Item.CodUnidadMedida = 2;                
                Item.NtsDescripcion = Convert.ToString(row.Cells[3].Value);
                Item.NtsOrdFabricacion = Convert.ToString(row.Cells[5].Value);
                Item.Precio = Convert.ToDecimal(row.Cells[6].Value);
                Item.Total = Convert.ToDecimal(row.Cells[7].Value);
                ListaDocumento.Add(Item);
            }

            return ListaDocumento;
        }

        private void Guardar()
        {
            NotaSalidaBusiness NotaSalidaBusiness = new NotaSalidaBusiness();
            NotaSalida entNS = new NotaSalida();

            try
            {
                entNS.CodAlmacen = Convert.ToInt16(cboAlmacen.SelectedValue);
                entNS.NtsTransaccion = txtTransaccion.Text;
                entNS.NtsFechaEmision = dtFechaEmision.Value;
                entNS.NtsFechaDocumento = dtFechaDocumento.Value;
                entNS.CodProveedor = CodigoProveedor;                
                entNS.NtsCliente = txtCliente.Text;
                entNS.NtsNroDocReferencia = txtNroDocRef.Text;
                entNS.NtsAutorizado = txtAutorizado.Text;
                entNS.NtsCentroCosto = txtCentroCosto.Text;
                entNS.CodMoneda = 1;
                entNS.NtsComentario = txtComentario.Text;                
                entNS.NtsEstado = 1;                
                entNS.UsuCodigo = UsuarioLogeo.Codigo;
                entNS.UsuCreCodigo = UsuarioLogeo.Codigo;
                
                var resultDetalle = Lista();

                var result = NotaSalidaBusiness.InsertarNS(entNS, resultDetalle);

                if (result != null)
                {
                    CodigoOC = Convert.ToInt32(result.NtsNumero);
                    MessageBox.Show("Se ha generado la nota de salida " + result.NtsNumero);
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

    public class ImportesDocumento
    {
        public decimal TotalDocumento { get; set; }
        public decimal Afecto { get; set; }
        public decimal Inafecto { get; set; }
    }
}