using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos
{
    public partial class frmMantenimientoOtrosIngresos : Form
    {
        public DataTable dt { get; set; }
        public frmMantenimientoOtrosIngresos()
        {
            InitializeComponent();
        }


        private void frmMantenimientoOtrosIngresos_Load(object sender, EventArgs e)
        {

            txtRazonSocial.Enabled = false;
            chkTodos.Checked = true;
            button3.Enabled = false;
            txtCodigoProveedor.Text = "0";
            //CargaSede();
            //CargaTipoDocumento();
            CargaAlmacenIngreso(1);

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

        //private void CargaSede()
        //{


        //}


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (chkTodos.Checked == false)
            {
                if (Convert.ToInt32(txtCodigoProveedor.Text) == 0)
                {
                    MessageBox.Show("Debe seleccionar un proveedor...!");
                }
            }

            SIGA.Business.Logistica.DocumentoProveedorBusiness objProveedor = new SIGA.Business.Logistica.DocumentoProveedorBusiness();
            dt = objProveedor.ConsultarPorDocumento(dtpDel.Value.ToString("yyyyMMdd"), dtpAl.Value.ToString("yyyyMMdd"), Convert.ToInt32(txtCodigoProveedor.Text), 1);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Logistica.Formularios.Operaciones.frmRegistrarIngresoOtros objFrmRegProducto = new SIGA.Windows.Logistica.Formularios.Operaciones.frmRegistrarIngresoOtros();
            objFrmRegProducto.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            SIGA.Windows.Comunes.frmProveedorBuscar objfrmProveedorBuscar = new SIGA.Windows.Comunes.frmProveedorBuscar();
            objfrmProveedorBuscar.ShowDialog();
            txtCodigoProveedor.Text = objfrmProveedorBuscar.CodigoProveedor;
            txtRazonSocial.Text = objfrmProveedorBuscar.NombreProveedor;
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTodos.Checked == true)
                {
                    txtCodigoProveedor.Text = "0";
                    txtRazonSocial.Enabled = false;
                    button3.Enabled = false;
                }
                else
                {
                    txtRazonSocial.Enabled = true;
                    button3.Enabled = true;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount > 0)
                {
                    int Codigo = 0;

                    Codigo = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);

                    if (Codigo > 0)
                    {
                        SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos.frmConsultarDocumentos obj = new SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos.frmConsultarDocumentos();
                        obj.TipoVista = 1;
                        obj.CodigoDocumento = Codigo;
                        obj.ShowDialog();
                        obj = null;


                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Comunes.frmImpresion objfrmReporte = new SIGA.Windows.Comunes.frmImpresion();
            string ruta = string.Empty;


            try
            {
                ruta = @"C:\Trabajo\SIGA-CODE\SIGA\SIGA.Windows\Reportes\rptIngresosSINO.rdlc";

                objfrmReporte.Archivo = "rptOrdenCompraZurece.rpt";
                objfrmReporte.Entidad = "USP_MovimientosCaja";
                objfrmReporte.DataSource = dt;
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


    }
}
