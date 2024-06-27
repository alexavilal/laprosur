using SIGA.Business.Administrador;
using SIGA.Business.Logistica;
using SIGA.Business.Ventas;
using SIGA.Entities.Logistica;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SIGA.Windows.Ventas.Formularios
{

    public partial class frmProforma : Form
    {
        public frmProforma()
        {
            InitializeComponent();
        }

        private void frmProforma_Load(object sender, EventArgs e)
        {
            CargarPolitica();
            CargarZona();
            CargarTipoDocIdentidad();
            CargarUsuarios();
        }

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarFila();
            Importes();

        }

        private void AgregarFila()
        {
            dgvItems.ClearSelection();
            dgvItems.Rows.Insert(dgvItems.Rows.Count, 0, "", "", "", Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0));
            dgvItems.Focus();
            dgvItems.CurrentCell = dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[1];
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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                QuitarItem();
                Importes();
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvItems_CellDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            int CodigoGeneral = 0;

            try
            {
                SIGA.Windows.Comunes.frmProductoBuscar obj = new Comunes.frmProductoBuscar();
                obj.ShowDialog();
                CodigoGeneral = obj.CodigoGeneral;

                this.dgvItems[0, this.dgvItems.CurrentRow.Index].Value = obj.CodigoGeneral;
                this.dgvItems[1, this.dgvItems.CurrentRow.Index].Value = obj.CodigoExterno.ToString();
                this.dgvItems[2, this.dgvItems.CurrentRow.Index].Value = obj.Descripcion.ToString();
                this.dgvItems[3, this.dgvItems.CurrentRow.Index].Value = "MILLAR";
                this.dgvItems[4, this.dgvItems.CurrentRow.Index].Value = 1;
                this.dgvItems[5, this.dgvItems.CurrentRow.Index].Value = DevuelvePrecioPorItem(Convert.ToInt32(obj.CodigoGeneral), Convert.ToInt32(cboPolitica.SelectedValue), Convert.ToInt32(cboZona.SelectedValue));

                this.dgvItems.CurrentCell = dgvItems[4, this.dgvItems.CurrentRow.Index];


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
        public void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != System.Windows.Forms.Keys.F2)
                return;
            try
            {
                MessageBox.Show("hola");
                //SIGA.Windows.Caja.frmConsultaPrecios objPrecios = new SIGA.Windows.Caja.frmConsultaPrecios();
                //objPrecios.ShowDialog();
                //if (objPrecios.CodigoZurece != null)
                //{
                //    this.dgvItems[3, this.dgvItems.CurrentRow.Index].Value = objPrecios.CodigoZurece;
                //    this.dgvItems.Focus();
                //    this.dgvItems.CurrentCell = this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[5];
                //    this.dgvItems.Rows[this.dgvItems.Rows.Count - 1].Cells[5].Selected = true;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Decimal cantidad, precio, total;

            try
            {
                if ((e.ColumnIndex == 4) || (e.ColumnIndex == 5) || (e.ColumnIndex == 6))
                {

                    if (dgvItems.CurrentRow != null)
                    {
                        cantidad = Convert.ToDecimal(dgvItems[4, dgvItems.CurrentRow.Index].Value);
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
                    NoGravado = Convert.ToDecimal(listaImportes.Inafecto);
                    Gravado = Convert.ToDecimal(listaImportes.Afecto) / Convert.ToDecimal(1.18);
                    /* Neto = NoGravado + Gravado + Impuesto;*/
                    Neto = Convert.ToDecimal(listaImportes.TotalDocumento);

                }

                txtTotal.Text = Neto.ToString("#######.000");


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
                //for (int i = 0; i < dgvItems.Rows.Count; i++)
                //{
                //    Total = Total + (decimal)dgvItems[6, i].Value; // Monto Total del Documento
                //}

                foreach (DataGridViewRow row in this.dgvItems.Rows)
                {


                    Total = Total + Convert.ToDecimal(row.Cells[6].Value);
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
                }

            }
            catch (Exception ex)
            {

            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvItems.RowCount > 0)
            {

                GuardarCotizacion();
            }
            else
            {
                MessageBox.Show("Debe ingresar un item para registrar la proforma..!");
                return;

            }




        }

        private void GuardarCotizacion()
        {
            CotizacionBusiness objCotizacion = new CotizacionBusiness();
            Cotizacion entCotizacion = new Cotizacion();

            try
            {
                entCotizacion.CodEmpresa = 1;
                entCotizacion.CodOficina = 2;
                entCotizacion.CodPolitica = Convert.ToInt32(cboPolitica.SelectedValue);
                entCotizacion.CodZona = Convert.ToInt32(cboZona.SelectedValue);
                entCotizacion.CotFecha = dtFecha.Value;
                entCotizacion.CodCliente = txtCodigoCliente.Text;
                entCotizacion.CodMoneda = 1;
                entCotizacion.CotImporte = Convert.ToDecimal(txtTotal.Text);
                entCotizacion.CotEstado = 1;
                entCotizacion.UsuCodigo = UsuarioLogeo.Codigo;
                entCotizacion.UsuCreCodigo = UsuarioLogeo.Codigo;
                entCotizacion.FecCre = dtFecha.Value;
                entCotizacion.UsuModCodigo = UsuarioLogeo.Codigo;
                entCotizacion.FecMod = dtFecha.Value;

                var Detalles = Lista();

                var result = objCotizacion.InsertarCotizacion(entCotizacion, Detalles);

                if (result != null)
                {
                    MessageBox.Show("Se ha registrado la cotizacion");
                    txtProforma.Text = result.CotNumero.ToString();
                    btnGuardar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }



        public List<CotizacionDetalle> Lista()
        {
            List<CotizacionDetalle> ListaDocumento = new List<CotizacionDetalle>();


            foreach (DataGridViewRow row in this.dgvItems.Rows)
            {
                // Verificar si la fila no es la fila de encabezado

                CotizacionDetalle Item = new CotizacionDetalle();

                //Item.CodigoGeneral = Convert.ToInt32(row.Cells[0].Value);
                //Item.CodPolitica = Convert.ToInt32(cboPolitica.SelectedValue);
                //Item.CodMoneda = 1;
                //Item.CodZona = Convert.ToInt32(cboZona.SelectedValue);
                //Item.PrecioProducto = Convert.ToDecimal(row.Cells[5].Value);
                //Item.PrecioFlete = Convert.ToDecimal(row.Cells[6].Value);
                //Item.Usuario = 1;
                Item.CodGeneral = Convert.ToInt32(row.Cells[0].Value);
                Item.CodUnidadMedida = 2;
                Item.Cantidad = Convert.ToInt32(row.Cells[4].Value);
                Item.Precio = Convert.ToDecimal(row.Cells[5].Value);
                Item.Total = Convert.ToDecimal(row.Cells[6].Value);
                ListaDocumento.Add(Item);
            }


            return ListaDocumento;

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void cboPolitica_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class ImportesDocumento
    {
        public decimal TotalDocumento { get; set; }
        public decimal Afecto { get; set; }
        public decimal Inafecto { get; set; }
    }

}
