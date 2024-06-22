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
    public partial class frmMantenimientoDocumentoCajaAdministrativa : Form
    {
        public frmMantenimientoDocumentoCajaAdministrativa()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            int CodigoDocumento = 0;
            if (dgvDocumentos.RowCount == 0)
            {
                MessageBox.Show("No existen items para anular..!", "SIGA");
            }
            else
            {
                CodigoDocumento = Convert.ToInt32(dgvDocumentos[0, dgvDocumentos.CurrentRow.Index].Value);
                Anular("I", CodigoDocumento, 1);
            }
        }

        private void Anular(string Estado,int CodigoDocumento,Int16 CodigoUsuario)
        {
            int Anular = 0;
            SIGA.Business.Ventas.DocumentoVentaBusiness objDocumento = new SIGA.Business.Ventas.DocumentoVentaBusiness();
            Anular = objDocumento.ActualizarDocumento(Estado, CodigoDocumento, CodigoUsuario);

            if (Anular >= 0)
            {
                MessageBox.Show("Se Anulo el Documento..", "SIGA");
                Consultar();
            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {   SIGA.Business.Ventas.DocumentoVentaBusiness objDocumento = new SIGA.Business.Ventas.DocumentoVentaBusiness();
            var result = objDocumento.ConsultarDocumentos();
            dgvDocumentos.DataSource = result;

            dgvDocumentos.Columns[0].Visible = false;
            dgvDocumentos.Columns[1].Visible = false;

            dgvDocumentos.Columns[2].Width = 500;


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           

          
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

      
    }
}
