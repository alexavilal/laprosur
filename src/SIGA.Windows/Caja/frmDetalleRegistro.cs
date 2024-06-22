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
    public partial class frmDetalleRegistro : Form
    {
        public int CodigoTicketera { get; set; }
        public frmDetalleRegistro()
        {
            InitializeComponent();
        }

        private void Buscar()
        {
            SIGA.Business.Caja.NumeroSerieBusiness objNumero = new SIGA.Business.Caja.NumeroSerieBusiness();
            var result = objNumero.ConsultarNumeroPorTicketera(Convert.ToInt16(CodigoTicketera));
            dgvNumeros.DataSource = result;
            dgvNumeros.Columns[0].Visible = false;
            dgvNumeros.Columns[1].Visible = false;

        }

        private void frmDetalleRegistro_Load(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
