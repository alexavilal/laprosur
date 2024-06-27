using System;
using System.Data;
using System.Windows.Forms;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmVentasporFecha : Form
    {
        public frmVentasporFecha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIGA.Business.Ventas.GuiaBusiness objGuia = new SIGA.Business.Ventas.GuiaBusiness();
            var result = objGuia.VentarPorFecha(dtInicio.Value.ToString("yyyyMMdd"), dtFin.Value.ToString("yyyyMMdd"), txtCodigoCliente.Text);
            dgvGuia.DataSource = result;


            DataRow[] activeRows = result.Select("Estado = 'activo'");


            decimal totalImporte = 0;
            foreach (DataRow row in activeRows)
            {
                totalImporte += (decimal)row["importe"];
            }


            txtTotal.Text = totalImporte.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Comunes.frmClienteBuscar objfrmClienteBuscar = new SIGA.Windows.Comunes.frmClienteBuscar();
            objfrmClienteBuscar.ShowDialog();
            txtCodigoCliente.Text = objfrmClienteBuscar.CodigoCliente;
            txtRazonSocial.Text = objfrmClienteBuscar.NombreCliente;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
