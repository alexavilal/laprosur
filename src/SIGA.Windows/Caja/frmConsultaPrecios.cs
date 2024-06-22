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
    public partial class frmConsultaPrecios : Form
    {
        public Int32 CodigoGeneral { get; set; }
        public string CodigoZurece { get; set; }
        public frmConsultaPrecios()
        {
            InitializeComponent();
        }


        private void CargaMarca()
        {
            SIGA.Business.Logistica.MarcaBusiness objMarcaBusiness = new SIGA.Business.Logistica.MarcaBusiness();
            List<SIGA.Entities.Logistica.Marca> objEntMarca = new List<SIGA.Entities.Logistica.Marca>();

            objEntMarca.Add(new SIGA.Entities.Logistica.Marca { CodMarca = 0, DesMarca = "--Todas--" });

            var result = objMarcaBusiness.Listar("A");

            foreach (var item in result)
            {
                objEntMarca.Add(item);
            }

            cboMarca.DataSource = objEntMarca;
            cboMarca.DisplayMember = "DesMarca";
            cboMarca.ValueMember = "CodMarca";

        }

        private void frmConsultaPrecios_Load(object sender, EventArgs e)
        {
            CargaMarca();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            int intCOlumnas = 0;
            SIGA.Business.Ventas.GeneralBusiness objGeneral = new SIGA.Business.Ventas.GeneralBusiness();
            DataTable dt = new DataTable();

            try
            {
                dt = objGeneral.ConsultarPrecioNewBarra(0, 0, Convert.ToInt32(cboMarca.SelectedValue), 0, txtCodigo.Text, txtDescripcion.Text, txtCodigoBarra.Text);
                dataGridView1.DataSource = dt;

                for (intCOlumnas = 0; intCOlumnas < dataGridView1.ColumnCount - 1; intCOlumnas++)
                {
                    dataGridView1.Columns[intCOlumnas].ReadOnly = true;
                    dataGridView1.Columns[intCOlumnas].Visible = false;

                }

                dataGridView1.Columns[1].Visible = true;

                dataGridView1.Columns[1].Width = 75;


                dataGridView1.Columns[2].Visible = true;
                dataGridView1.Columns[2].Width = 100;


                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Columns[3].Width = 100;


                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[4].Width = 100;


                dataGridView1.Columns[10].Visible = true;

                dataGridView1.Columns[10].HeaderText = "Menor";
                dataGridView1.Columns[10].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[4].Width = 80;


                dataGridView1.Columns[15].Visible = true;

                dataGridView1.Columns[15].HeaderText = "Mayor";
                dataGridView1.Columns[15].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[15].Width = 80;


                dataGridView1.Columns[20].Visible = true;

                dataGridView1.Columns[20].DefaultCellStyle.Format = "N2";

                dataGridView1.Columns[20].HeaderText = "Ciento";
                dataGridView1.Columns[20].Width = 80;


                dataGridView1.Columns[24].Visible = true;
                dataGridView1.Columns[24].Width = 80;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            int Codigo = 0;

            try
            {
                CodigoGeneral = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
                CodigoZurece = Convert.ToString(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);

                this.Close();

            }
            catch (Exception ex)
            {

            }


           
        }



    }
}
