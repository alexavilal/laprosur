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
    public partial class frmAnularDocumento : Form
    {
        public int TipoVista { get; set; }
        public frmAnularDocumento()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();

        }


        private void ImprimirOrden(int Codigo, int Empresa, int TipoDocumento, string TipoFormato)
        {
            SIGA.Windows.Comunes.frmImpresion objfrmReporte = new SIGA.Windows.Comunes.frmImpresion();
            string ruta = string.Empty;


            try
            {

                if (TipoFormato == "E") //Electronico
                {
                    if (TipoDocumento == 1)
                    {
                        switch (Empresa)
                        {
                            case 1: ruta = @"C:\Trabajo\SIGA-CODE\SIGA\SIGA.Windows\Reportes\rptFacturaElectronicaZurece.rdlc"; break;
                            case 2: ruta = @"C:\Trabajo\SIGA-CODE\SIGA\SIGA.Windows\Reportes\rptFacturaElectronicaCR.rdlc"; break;

                        }

                    }
                    else
                    {
                        switch (Empresa)
                        {
                            case 1: ruta = @"C:\Trabajo\SIGA-CODE\SIGA\SIGA.Windows\Reportes\rptBoletaElectronicaZurece.rdlc"; break;
                            case 2: ruta = @"C:\Trabajo\SIGA-CODE\SIGA\SIGA.Windows\Reportes\rptBoletaElectronicaCR.rdlc"; break;


                        }
                    }
                }

                else
                {
                    if (TipoDocumento == 1)
                    {

                        ruta = @"C:\Trabajo\SIGA-CODE\SIGA\SIGA.Windows\Reportes\rptFacturaManual.rdlc";
                    }
                    else
                    {
                        ruta = @"C:\Trabajo\SIGA-CODE\SIGA\SIGA.Windows\Reportes\rptBoletaManual.rdlc";

                    }
                }


                

                objfrmReporte.Archivo = "rptOrdenCompraZurece.rpt";
                objfrmReporte.Entidad = "USP_VentasImpresion";

                objfrmReporte.DataSource = DatosOrden(Codigo);
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


        private void CargaEmpresa()
        {
            SIGA.Business.Logistica.EmpresaBusiness objMarcaBusiness = new SIGA.Business.Logistica.EmpresaBusiness();
            List<SIGA.Entities.Logistica.Empresa> Lista = new List<SIGA.Entities.Logistica.Empresa>();

            Lista.Add(new SIGA.Entities.Logistica.Empresa { CodEmpresa = 0, DesEmpresa = "Seleccione" });

            var resutlMarca = objMarcaBusiness.Listar();

            foreach (var item in resutlMarca)
            {
                Lista.Add(item);
            }

            cboEmpresa.DataSource = Lista;
            cboEmpresa.ValueMember = "CodEmpresa";
            cboEmpresa.DisplayMember = "DesEmpresa";

        }
        private void Consultar()
        {
            int TipoDocumento = 0;

            switch (cboTipoDocumento.Text)
            {
                case "Factura": TipoDocumento = 1; break;
                case "Boleta": TipoDocumento = 2; break;
                case "Ticket": TipoDocumento = 77; break;
            }

            Cursor.Current = Cursors.WaitCursor;
            SIGA.Business.Ventas.DocumentoVentaBusiness obj = new SIGA.Business.Ventas.DocumentoVentaBusiness();
            var result = obj.ConsultarDocumentosVentas(Convert.ToInt32(cboEmpresa.SelectedValue), TipoDocumento, txtNumero.Text, txtRazonSocial.Text, dtpDel.Value.ToString("yyyyMMdd"), dtpAl.Value.ToString("yyyyMMdd"));
            dataGridView1.DataSource = result;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[9].Visible = false;

            dataGridView1.Columns[10].Visible = false;

            dataGridView1.Columns[11].Visible = false; //Tipo Formato

            dataGridView1.Columns[12].Visible = false; //Ruta NFact

            Cursor.Current = Cursors.Default;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIGA.Business.Ventas.DocumentoVentaBusiness objDocumento = new SIGA.Business.Ventas.DocumentoVentaBusiness();
            string Estado = string.Empty;
            try
            {
                if (this.dataGridView1.RowCount == 0)
                    return;
                int Codigo = Convert.ToInt32(this.dataGridView1[0, this.dataGridView1.CurrentRow.Index].Value);
                string str = Convert.ToString(this.dataGridView1[8, this.dataGridView1.CurrentRow.Index].Value);
                int TipoDocumento = Convert.ToInt32(dataGridView1[10, dataGridView1.CurrentRow.Index].Value);


                SIGA.Windows.Ventas.Formularios.frmMotivoAnulacion frmMotivoAnulacion = new SIGA.Windows.Ventas.Formularios.frmMotivoAnulacion();
                frmMotivoAnulacion.CodigoDocumento = Codigo;
                frmMotivoAnulacion.TipoDocumento = TipoDocumento;
                frmMotivoAnulacion.Estado = str;
                frmMotivoAnulacion.ShowDialog();
                if (frmMotivoAnulacion.CargarBusqueda)
                    this.dataGridView1[8, this.dataGridView1.CurrentRow.Index].Value = "Anulado";
            }
            catch (Exception ex)
            {
            }
           
        }

        private void frmAnularDocumento_Load(object sender, EventArgs e)
        {
            CargaEmpresa();
        }

        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                int Codigo = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
                int CodigoEmpresa = Convert.ToInt32(dataGridView1[9, dataGridView1.CurrentRow.Index].Value);
                int TipoDocumento = Convert.ToInt32(dataGridView1[10, dataGridView1.CurrentRow.Index].Value);
                string TipoFormato = Convert.ToString(dataGridView1[11, dataGridView1.CurrentRow.Index].Value);
                string RutaNFact = Convert.ToString(dataGridView1[12, dataGridView1.CurrentRow.Index].Value);

                if (RutaNFact.Length > 0)  /* El documento viene de FE*/
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = RutaNFact;
                    proc.Start();
                    proc.Close();
                }
                else
                {
                    ImprimirOrden(Codigo, CodigoEmpresa, TipoDocumento, TipoFormato);
                }

              
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }


        private DataTable DatosOrden(int Codigo)
        {
            SIGA.Business.Ventas.DocumentoVentaBusiness Orden = new SIGA.Business.Ventas.DocumentoVentaBusiness();

            return Orden.ConsultarDocumentosVentas(Codigo);
        }

    }
}
