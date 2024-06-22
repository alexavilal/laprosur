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
    public partial class frmStandBy : Form
    {
        public int CodigoCaja { get; set; }
        public frmStandBy()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtMotivo.Text.Length > 0 && cboMotivo.Text != "--Seleccione--")
            {
                Registrar();

            }
            else
            {
                MessageBox.Show("Debe Ingresar el motivo..");
            }

       
        }

        private void Registrar()
        {

            SIGA.Business.Caja.MovimientoCajaBusiness objMovimiento = new SIGA.Business.Caja.MovimientoCajaBusiness();

            Int16 CodigoMotivo = 0;

            switch(cboMotivo.Text)
            {
                 case "Baño" :CodigoMotivo = 6;break;
                 case "Compras": CodigoMotivo = 17; break;
                 case "Otros": CodigoMotivo = 18; break;
            }
               

            var result = objMovimiento.Insertar(CodigoCaja,CodigoMotivo, 0, 0, 0, 0, 0, "", "", txtMotivo.Text);
            if (result >= 0)
            {
                MessageBox.Show("Se registro el Cierre Temporal");
                
            }
            else
            {
                MessageBox.Show("No se puedo registrar.!!");
            }
        }

        private void frmStandBy_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
        }
    }
}
