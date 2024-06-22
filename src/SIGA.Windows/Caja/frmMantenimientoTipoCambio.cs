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
    public partial class frmMantenimientoTipoCambio : Form
    {
        public frmMantenimientoTipoCambio()
        {
            InitializeComponent();
        }

        private void frmMantenimientoTipoCambio_Load(object sender, EventArgs e)
        {
            SIGA.Business.Caja.TipoCambioBusiness OBJ = new SIGA.Business.Caja.TipoCambioBusiness();
            var result = OBJ.TipoCambioConsultar();
            dgvTarjeta.DataSource = result;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            string FechaInicio = string.Empty;
            string FechaFin = string.Empty;


            FechaInicio = dtpInicio.Value.ToString("yyyyMMdd");
            FechaFin =  dtpFinal.Value.ToString("yyyyMMdd");

            SIGA.Business.Caja.TipoCambioBusiness objCambio = new SIGA.Business.Caja.TipoCambioBusiness();

            var Result= objCambio.TipoCambioConsultarPorIntervalo(FechaInicio,FechaFin);

            dgvTarjeta.DataSource = Result;



        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Caja.frmTipoCambio obj = new SIGA.Windows.Caja.frmTipoCambio();
            obj.ShowDialog();

            SIGA.Business.Caja.TipoCambioBusiness OBJ = new SIGA.Business.Caja.TipoCambioBusiness();
            var result = OBJ.TipoCambioConsultar();
            dgvTarjeta.DataSource = result;

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvTarjeta.RowCount > 0)
            {

                SIGA.Windows.Caja.frmTipoCambio obj = new SIGA.Windows.Caja.frmTipoCambio();
                obj.Fecha = Convert.ToString(dgvTarjeta[0, dgvTarjeta.CurrentRow.Index].Value);
                obj.ShowDialog();


                SIGA.Business.Caja.TipoCambioBusiness OBJ = new SIGA.Business.Caja.TipoCambioBusiness();
                var result = OBJ.TipoCambioConsultar();
                dgvTarjeta.DataSource = result;
            }


        }
    }
}
