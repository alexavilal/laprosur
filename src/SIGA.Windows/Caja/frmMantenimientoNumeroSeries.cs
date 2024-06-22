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
    public partial class frmMantenimientoNumeroSeries : Form
    {
        public frmMantenimientoNumeroSeries()
        {
            InitializeComponent();
        }

        private void CargaSede()
        {
            SIGA.Business.Logistica.SedeBusiness objSede = new SIGA.Business.Logistica.SedeBusiness();
            List<SIGA.Entities.Logistica.Sede> objEntSede = new List<SIGA.Entities.Logistica.Sede>();

            objEntSede = objSede.Listar();
            objEntSede.Add(new SIGA.Entities.Logistica.Sede() { CodSede = 0, DesSede = "--Todos--" });
            cboSede.DataSource = objEntSede;

            cboSede.ValueMember = "CodSede";
            cboSede.DisplayMember = "DesSede";

            cboSede.Text = "--Todos--";
        }

        private void CargaEmpresa()
        {
            SIGA.Business.Logistica.EmpresaBusiness objMarcaBusiness = new SIGA.Business.Logistica.EmpresaBusiness();

            List<SIGA.Entities.Logistica.Empresa> resultMarca = new List<Entities.Logistica.Empresa>();
            resultMarca = objMarcaBusiness.Listar();
            resultMarca.Add(new SIGA.Entities.Logistica.Empresa() { CodEmpresa = 0, DesEmpresa = "--Todos--" });
           
            cboEmpresa.DataSource = resultMarca;
            cboEmpresa.DisplayMember = "DesEmpresa";
            cboEmpresa.ValueMember = "CodEmpresa";
            cboEmpresa.Text = "--Todos--";
        }

        private void CargaTipoDocumento()
        {
            SIGA.Business.Logistica.TipoDocumentoBusiness objMarcaBusiness = new SIGA.Business.Logistica.TipoDocumentoBusiness();

            List<SIGA.Entities.Logistica.TipoDocumento> resultMarca = new List<Entities.Logistica.TipoDocumento>();
            resultMarca = objMarcaBusiness.Listar();
            resultMarca.Add(new SIGA.Entities.Logistica.TipoDocumento() { CodTipoDocumento = 0, DesDocumento = "--Todos--" });
            cboDocumento.DataSource = resultMarca;
            cboDocumento.DisplayMember = "DesDocumento";
            cboDocumento.ValueMember = "CodTipoDocumento";
            cboDocumento.Text = "--Todos--";
        
        }

        private void frmMantenimientoNumeroSeries_Load(object sender, EventArgs e)
        {
            CargaTipoDocumento();
            CargaEmpresa();
            CargaSede();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Caja.frmRegNumeroSerie objNumero = new SIGA.Windows.Caja.frmRegNumeroSerie();
            objNumero.ShowDialog();
            Buscar();

        }

        private void Buscar()
        {
            SIGA.Business.Caja.NumeroSerieBusiness objNumero = new SIGA.Business.Caja.NumeroSerieBusiness();
            var result = objNumero.ConsultarNumero(Convert.ToInt16(cboEmpresa.SelectedValue), Convert.ToInt16(cboSede.SelectedValue), Convert.ToInt16(cboDocumento.SelectedValue),1);
            dgvNumeros.DataSource = result;
            dgvNumeros.Columns[0].Visible = false;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvNumeros.RowCount == 0)
            {
                MessageBox.Show("No hay itemes para modificar..!");
            }
        }
    
    }

}
