using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios
{
    public partial class frmRequerimiento : Form
    {
        public frmRequerimiento()
        {
            InitializeComponent();
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
            RequerimientoBusiness objCotizacion = new RequerimientoBusiness();
            Requerimiento entCotizacion = new Requerimiento();

            try
            {
                entCotizacion.CodEmpresa = 1;
                entCotizacion.CodOficina = 2;
                entCotizacion.ReqFecha = "20240621";
                entCotizacion.ReqHora = "08:55";
                entCotizacion.ReqPrioridad = cboPrioridad.Text;
                entCotizacion.Req_ProductoFabricar = txtProducto.Text;
                entCotizacion.Req_Cantidad = txtCantidad.Text;
                entCotizacion.UsuCodigoSolicitante = Convert.ToInt32(cboVendedor.SelectedValue);
                entCotizacion.Req_Area = txtArea.Text;
                entCotizacion.ReqFechaInicio = "20240621";
                entCotizacion.ReqFechaFinal = "20240621";
                entCotizacion.Req_EquipoMaquina = txtMaquinaria.Text;
                entCotizacion.Req_CentroCosto = txtCentroCosto.Text;
                entCotizacion.Req_Codigo = txtCodigo.Text;
                entCotizacion.UsuCreCodigo = Convert.ToInt32(1);
                entCotizacion.FecCre = dtFecha.Value;
                entCotizacion.Req_Observacion = "";
                
                var Detalles = Lista();

                var result = objCotizacion.Insertar(entCotizacion, Detalles);

                if (result != null)
                {
                    MessageBox.Show("Se ha registrado el requerimiento");
                   
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
        public List<RequerimientoDetalle> Lista()
        {
            List<RequerimientoDetalle> ListaDocumento = new List<RequerimientoDetalle>();


            foreach (DataGridViewRow row in this.dgvItems.Rows)
            {
                // Verificar si la fila no es la fila de encabezado

                RequerimientoDetalle Item = new RequerimientoDetalle();

                //Item.CodigoGeneral = Convert.ToInt32(row.Cells[0].Value);
                //Item.CodPolitica = Convert.ToInt32(cboPolitica.SelectedValue);
                //Item.CodMoneda = 1;
                //Item.CodZona = Convert.ToInt32(cboZona.SelectedValue);
                //Item.PrecioProducto = Convert.ToDecimal(row.Cells[5].Value);
                //Item.PrecioFlete = Convert.ToDecimal(row.Cells[6].Value);
                //Item.Usuario = 1;
                Item.CodGeneral = Convert.ToInt32(row.Cells[0].Value);
                Item.CodUnidadMedida = 2;
                Item.Cantidad = Convert.ToInt32(row.Cells[3].Value);
                Item.Marca = Convert.ToString(row.Cells[5].Value);
                Item.SalidaAlmacen = Convert.ToString(row.Cells[6].Value);
                ListaDocumento.Add(Item);
            }


            return ListaDocumento;

        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
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
                this.dgvItems[3, this.dgvItems.CurrentRow.Index].Value = 1;
                this.dgvItems[4, this.dgvItems.CurrentRow.Index].Value = "MILLAR";
                this.dgvItems[5, this.dgvItems.CurrentRow.Index].Value = string.Empty;
                this.dgvItems[6, this.dgvItems.CurrentRow.Index].Value = string.Empty;


                // this.dgvItems[5, this.dgvItems.CurrentRow.Index].Value = DevuelvePrecioPorItem(Convert.ToInt32(obj.CodigoGeneral), Convert.ToInt32(cboPolitica.SelectedValue), Convert.ToInt32(cboZona.SelectedValue));

                this.dgvItems.CurrentCell = dgvItems[4, this.dgvItems.CurrentRow.Index];


            }
            catch (Exception ex)
            {

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarFila();
        }
        private void AgregarFila()
        {
            dgvItems.ClearSelection();
            dgvItems.Rows.Insert(dgvItems.Rows.Count, 0, "", "", "", Convert.ToDecimal(0), string.Empty, String.Empty);
            dgvItems.Focus();
            dgvItems.CurrentCell = dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[1];
            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[1].Selected = true;
            dgvItems.BeginEdit(true);


        }

        private void dgvItems_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                QuitarItem();
               
            }
            catch (Exception ex)
            {

            }
        }

        private void QuitarItem()
        {
            if (dgvItems.RowCount > 0)
            {
                int index = dgvItems.CurrentCell.RowIndex;
                dgvItems.Rows.RemoveAt(index);

            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmRequerimiento_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {

            SIGA.Business.Administrador.UsuarioBusiness objBusiness = new SIGA.Business.Administrador.UsuarioBusiness();
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
    }
}
