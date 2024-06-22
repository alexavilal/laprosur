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
    public partial class frmMantenimientoRequerimiento : Form
    {
        public frmMantenimientoRequerimiento()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Logistica.Formularios.frmRequerimiento obj = new SIGA.Windows.Logistica.Formularios.frmRequerimiento();
            obj.ShowDialog();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            SIGA.Business.Logistica.RequerimientoBusiness objReq = new SIGA.Business.Logistica.RequerimientoBusiness();
            var result = objReq.Consultar();
            dgvProveedor.DataSource = result;


        }
    }
}
