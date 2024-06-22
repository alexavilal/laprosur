using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmBuscarVehiculo : Form
    {
        public int codigoTransportista { get; set; }
        public string NumeroPlaca { get; set; }
        public string Transportista { get; set; }

        public frmBuscarVehiculo()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPlaca(txtTransportista.Text, txtPlaca.Text);
        }

        public void BuscarPlaca(string Transportista, string PlacaVehiculo)
        {
            SIGA.Business.Ventas.TransportistaBusiness objTransportista = new Business.Ventas.TransportistaBusiness();
            Transportista = "%" + Transportista + "%";
            PlacaVehiculo = "%" + PlacaVehiculo + "%";
            var result = objTransportista.DevuelveVehiculo(Transportista, PlacaVehiculo);
            dgvModulo.DataSource = result;
            dgvModulo.Columns[0].Visible = false;
            dgvModulo.Columns[1].Width = 200;
            dgvModulo.Columns[3].Visible = false;

        }

        private void dgvModulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                codigoTransportista = Convert.ToInt32(dgvModulo[0, dgvModulo.CurrentRow.Index].Value);
                NumeroPlaca = Convert.ToString(dgvModulo[4, dgvModulo.CurrentRow.Index].Value);
                Transportista = Convert.ToString(dgvModulo[1, dgvModulo.CurrentRow.Index].Value);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
