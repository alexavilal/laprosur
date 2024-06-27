using System;
using System.Windows.Forms;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmMantenimientoTransportista : Form
    {
        public frmMantenimientoTransportista()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistroTransportista frm = new frmRegistroTransportista();
            frm.ShowDialog();

        }
    }
}
