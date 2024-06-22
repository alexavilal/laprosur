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
    public partial class frmBuscarEntidad : Form
    {
        public Int16 CodigoTipo;
        public int Codigo;
        public string Descripcion;
        public frmBuscarEntidad()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            SIGA.Business.Caja.CajeroBusiness objCajero = new SIGA.Business.Caja.CajeroBusiness();

            string Tipo = string.Empty;
            string RazonSocial = string.Empty;

            if (cboMotivo.Text == "--Seleccione--")
            {
                MessageBox.Show("Debe seleccionar el tipo ...!");
            }
          

            switch (cboMotivo.Text)
            {
                case "Proveedor": Tipo = "2"; break;
                case "Banco": Tipo = "4"; break;

            }

            RazonSocial = textBox1.Text;

            var result = objCajero.BuscarEntidad(Tipo, RazonSocial);

            dataGridView1.DataSource = result;

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].Width = 350;


            dataGridView1.Columns[2].Visible = false;


        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           

            CodigoTipo = Convert.ToInt16(dataGridView1[2, dataGridView1.CurrentRow.Index].Value);
            Codigo = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
            Descripcion = Convert.ToString(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);
            this.Close();
        }
    }
}
