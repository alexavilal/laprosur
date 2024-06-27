using System;
using System.Data;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos
{
    public partial class frmConsultarDocumentos : Form
    {
        public int TipoDocumento { get; set; }
        public int CodigoDocumento { get; set; }
        public int TipoVista { get; set; }

        public frmConsultarDocumentos()
        {
            InitializeComponent();
        }

        private void frmConsultarDocumentos_Load(object sender, EventArgs e)
        {


            if (TipoVista.Equals(0))
            {
                //*SIGA.Business.Logistica.ReporteKardexBusiness obj = new SIGA.Business.Logistica.ReporteKardexBusiness();

                /*var result = obj.ListarDocumento(TipoDocumento, CodigoDocumento);*/

                DataTable result = new DataTable();


                if (result.Rows.Count > 0)
                {
                    txtTipoDocumento.Text = result.Rows[0][3].ToString();
                    txtNumero.Text = result.Rows[0][4].ToString();

                }

                dataGridView1.DataSource = result;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;

                dataGridView1.Columns[8].Visible = true;
                dataGridView1.Columns[9].Visible = true;

                dataGridView1.Columns[10].Visible = true;
                dataGridView1.Columns[11].Visible = true;
                dataGridView1.Columns[12].Visible = true;

                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;

            }

            else
            {
                SIGA.Business.Logistica.DocumentoProveedorBusiness obj = new SIGA.Business.Logistica.DocumentoProveedorBusiness();

                var result = obj.DocumentoCompraPorCodigo(CodigoDocumento);

                if (result.Rows.Count > 0)
                {
                    txtTipoDocumento.Text = result.Rows[0][3].ToString();
                    txtNumero.Text = result.Rows[0][4].ToString();

                }

                dataGridView1.DataSource = result;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;

                dataGridView1.Columns[8].Visible = true;
                dataGridView1.Columns[9].Visible = true;

                dataGridView1.Columns[10].Visible = true;
                dataGridView1.Columns[11].Visible = true;
                dataGridView1.Columns[12].Visible = true;

                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
            }

        }
    }
}
