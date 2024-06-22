using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
