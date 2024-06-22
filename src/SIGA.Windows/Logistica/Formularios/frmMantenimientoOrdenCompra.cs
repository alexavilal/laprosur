using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios
{
    public partial class frmMantenimientoOrdenCompra : Form
    {
        public frmMantenimientoOrdenCompra()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Logistica.Formularios.frmRegistroOC obj = new SIGA.Windows.Logistica.Formularios.frmRegistroOC();
            obj.ShowDialog();
        }
    }
}
