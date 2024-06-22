using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios.Busquedas
{
    public partial class frmBuscaProveedor : Form
    {
        public int CodigoProveedor = 0;
        public string RazonSocial = string.Empty;
        public string Ruc = string.Empty;

        public frmBuscaProveedor()
        {
            InitializeComponent();
        }

        private void BuscarProveedor(string strRazonSocial,string strNombreComercial,Int16 TipoDocumento,string strNumeroDocumento,string Comercial)
        {
            SIGA.Business.Logistica.ProveedorBusiness objProveedorBusiness = new SIGA.Business.Logistica.ProveedorBusiness();

            var result = objProveedorBusiness.BuscarPorCriteriosDT(strRazonSocial, strNombreComercial, TipoDocumento, strNumeroDocumento,Comercial);

            dgvProveedor.DataSource = result;
            dgvProveedor.Columns[0].Visible = false;

        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtNombreComercial_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
           
        }

      

        private void dgvProveedor_CellDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            int Codigo = 0;

            if (dgvProveedor.RowCount > 0)
            {
                Codigo = Convert.ToInt32(dgvProveedor[0, dgvProveedor.CurrentRow.Index].Value);

                if (Codigo > 0)
                {

                    CodigoProveedor = Codigo;
                    RazonSocial = dgvProveedor[1, dgvProveedor.CurrentRow.Index].Value.ToString();
                    Ruc = dgvProveedor[4, dgvProveedor.CurrentRow.Index].Value.ToString();
                    this.Close();
                }

            }

          
        }


        void CargarTipoDocIdentidad()
        {
            SIGA.Business.Logistica.TipoDocumentoIdentidadBusiness objDocumentoBussiness = new SIGA.Business.Logistica.TipoDocumentoIdentidadBusiness();
            List<SIGA.Entities.Logistica.TipoDocumentoIdentificacion> Lista = new List<SIGA.Entities.Logistica.TipoDocumentoIdentificacion>();

            Lista.Add(new SIGA.Entities.Logistica.TipoDocumentoIdentificacion { CodTipoDocumento = 0, DesDocumento = "Seleccione" });

            var resutlMarca = objDocumentoBussiness.ListarTipoDocumentoIdentidad();

            

            foreach (var item in resutlMarca)
            {
                Lista.Add(item);
            }



            cboTipoDocumento.DataSource = Lista;
            cboTipoDocumento.ValueMember = "CodTipoDocumento";
            cboTipoDocumento.DisplayMember = "DesDocumento";
        }


         

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOkey_Click(object sender, EventArgs e)
        {
            BuscarProveedor(txtRazonSocial.Text,txtNombreComercial.Text, Convert.ToInt16(cboTipoDocumento.SelectedValue), txtNumero.Text,txtMarca.Text);
        }

        private void frmBuscaProveedor_Load(object sender, EventArgs e)
        {
            CargarTipoDocIdentidad();
        }
    }
}
