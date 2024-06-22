using SIGA.Business.Logistica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGA.Windows.Comunes
{
    public partial class frmProductoBuscar : Form
    {
        public int CodigoGeneral { get; set; }
        public string CodigoExterno { get; set; }
        public string Descripcion { get; set; }

        public frmProductoBuscar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Descripcion = this.txtDescripcion.Text + "%";
            string str1 = string.Empty + "%";
            string str2 = this.txtCodigoGeneral.Text + "%";
            this.dgvProducto.DataSource = (object)new GeneralBusiness().ConsultarMantenimiento(Convert.ToInt32(0), Convert.ToInt16(1), Convert.ToInt16(0), Convert.ToInt16(0), Convert.ToInt16(0), Convert.ToInt16(0), Convert.ToInt16(0), Convert.ToInt16(0), Convert.ToInt16(0), Convert.ToInt16(0), Convert.ToInt16(0), Descripcion, Convert.ToString("A"), Convert.ToInt16(0), "%" + this.txtCodigoGeneral.Text + "%","");
            this.dgvProducto.Columns[0].Visible = false;
            this.dgvProducto.Columns[1].Width = 80;
            this.dgvProducto.Columns[2].Width = 180;
            this.dgvProducto.Columns[3].Width = 200;
            this.dgvProducto.Columns[4].Width = 120;
            this.dgvProducto.Columns[5].Width = 80;
        }
        private void dgvProducto_CellDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            //CodigoZurece = Convert.ToString(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);

            try
            {
                CodigoGeneral = Convert.ToInt32(dgvProducto[0, dgvProducto.CurrentRow.Index].Value);
                CodigoExterno = Convert.ToString(dgvProducto[1, dgvProducto.CurrentRow.Index].Value);
                Descripcion = Convert.ToString(dgvProducto[3, dgvProducto.CurrentRow.Index].Value);

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void frmProductoBuscar_Load(object sender, EventArgs e)
        {

        }

        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
