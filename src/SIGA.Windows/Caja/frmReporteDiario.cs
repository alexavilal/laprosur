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
    public partial class frmReporteDiario : Form
    {
        public frmReporteDiario()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            SIGA.Business.Caja.CajeroBusiness objCajero = new SIGA.Business.Caja.CajeroBusiness();

            var result = objCajero.ReporteCajero(dtFecha.Value.ToShortDateString(), dtFecha.Value.ToString("yyyyMMdd"));

            dgvReporteDiario.DataSource = result;

            dgvReporteDiario.Columns[0].ReadOnly = true;

            dgvReporteDiario.Columns[0].Width = 70;

            dgvReporteDiario.Columns[1].ReadOnly = true;

            dgvReporteDiario.Columns[1].Width = 70;

            dgvReporteDiario.Columns[2].ReadOnly = true;
            dgvReporteDiario.Columns[3].ReadOnly = true;
            dgvReporteDiario.Columns[4].ReadOnly = true;


            dgvReporteDiario.Columns[5].ReadOnly = true;
            dgvReporteDiario.Columns[6].ReadOnly = true;
            dgvReporteDiario.Columns[7].ReadOnly = true;


        }
    }
}
