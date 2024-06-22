
using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;
using SIGA.Windows.Comunes;
using SIGA.Windows.Logistica.Formularios.Busquedas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Secciones
{
    public partial class frmConsultarSeccionStock : Form
    {
        private DataTable dt = new DataTable();
        public frmConsultarSeccionStock()
        {
            InitializeComponent();
        }

        private void frmConsultarSeccionStock_Load(object sender, EventArgs e)
        {
            this.CargaEmpresa();
            this.CargaSede();
            this.cboSede.SelectedValue = (object)Convert.ToInt16(1);
            this.CargaMarca();
            this.cboMarca.SelectedValue = (object)Convert.ToInt16(0);
        }

        private void CargaEmpresa()
        {
            EmpresaBusiness empresaBusiness = new EmpresaBusiness();
            List<Empresa> empresaList = new List<Empresa>();
            empresaList.Add(new Empresa()
            {
                CodEmpresa = (short)0,
                DesEmpresa = "Seleccione"
            });
            foreach (Empresa empresa in empresaBusiness.Listar())
                empresaList.Add(empresa);
            this.cboEmpresa.DataSource = (object)empresaList;
            this.cboEmpresa.DisplayMember = "DesEmpresa";
            this.cboEmpresa.ValueMember = "CodEmpresa";
            this.cboEmpresa.Enabled = false;
        }

        private void CargaMarca()
        {
            MarcaBusiness marcaBusiness = new MarcaBusiness();
            List<Marca> marcaList = new List<Marca>();
            marcaList.Add(new Marca()
            {
                CodMarca = (short)0,
                DesMarca = "--Todos--"
            });
            foreach (Marca marca in marcaBusiness.Listar(""))
                marcaList.Add(marca);
            this.cboMarca.DataSource = (object)marcaList;
            this.cboMarca.DisplayMember = "DesMarca";
            this.cboMarca.ValueMember = "CodMarca";
        }

        private void CargaAlmacen(short CodigoSede)
        {
            this.cboAlmacen.DataSource = (object)null;
            this.cboAlmacen.DataSource = (object)new AlmacenBusiness().ListarPorSede(CodigoSede);
            this.cboAlmacen.ValueMember = "CodAlmacen";
            this.cboAlmacen.DisplayMember = "DesAlmacen";
        }

        private void CargaSede()
        {
            SedeBusiness sedeBusiness = new SedeBusiness();
            List<Sede> sedeList = new List<Sede>();
            this.cboSede.DataSource = (object)sedeBusiness.Listar();
            this.cboSede.ValueMember = "CodSede";
            this.cboSede.DisplayMember = "DesSede";
            this.cboSede.SelectedIndex = -1;
        }

        private void cboSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strCodigo = cboSede.SelectedIndex.ToString();

            if (strCodigo != null)
            {
                if (strCodigo != "-1")
                {
                    CargaAlmacen(Convert.ToInt16(strCodigo));
                }

              
            }
            //if (cboSede.SelectedIndex !=1)
            //{
            //    this.CargaAlmacen(Convert.ToInt16(this.cboSede.SelectedValue));

            //}


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dt = new SeccionBusiness().ConsultarStock("%" + this.txtCodigoArticulo.Text + "%", "%" + this.txtDescripcion.Text + "%", Convert.ToInt32(this.cboAlmacen.SelectedValue), Convert.ToInt32(this.cboMarca.SelectedValue), Convert.ToInt32(this.cboSeccion.SelectedValue));
            this.dgvListado.DataSource = (object)this.dt;
            this.dgvListado.Columns[0].Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.dgvListado.RowCount == 0)
            {
                int num1 = (int)MessageBox.Show("No exiten item para exportar...!");
            }
            else
            {
                frmImpresion frmImpresion = new frmImpresion();
                string empty = string.Empty;
                try
                {
                    string Ruta = "C:\\Trabajo\\SIGA-CODE\\SIGA\\SIGA.Windows\\Reportes\\rptStockSeccion.rdlc";
                    frmImpresion.Archivo = "rptReposicion.rpt";
                    frmImpresion.Entidad = "USP_ConsultarPorSeccion";
                    frmImpresion.DataSource = (object)this.dt;
                    frmImpresion.WindowState = FormWindowState.Normal;
                    frmImpresion.sbImprimir(Ruta);
                    int num2 = (int)frmImpresion.ShowDialog();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                }
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
        //    frmBuscaGeneral.CodigoSeccion = Convert.ToInt32(this.cboSeccion.SelectedValue);
        //    int num = (int)frmBuscaGeneral.ShowDialog();
        //    if (!(frmBuscaGeneral.Codigo.ToString() != "0"))
        //        return;
        //    this.txtCodigoGeneral.Text = frmBuscaGeneral.Codigo.ToString();
        //    this.txtCodigoArticulo.Text = frmBuscaGeneral.CodigoExterno.ToString();
        //    this.txtDescripcion.Text = frmBuscaGeneral.Descripcion.ToString();
        //    DataTable dataTable = new GeneralBusiness().GeneralPorProducto(Convert.ToInt32(this.txtCodigoGeneral.Text));
        //    if (dataTable.Rows.Count > 1)
        //    {
        //        this.cboEmpresa.Enabled = true;
        //    }
        //    else
        //    {
        //        this.cboEmpresa.Enabled = false;
        //        this.cboEmpresa.SelectedValue = (object)Convert.ToInt16(dataTable.Rows[0][0]);
        //    }
        }
    }
}
