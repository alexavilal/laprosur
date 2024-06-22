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
    public partial class frmMantenimientoTicketera : Form
    {
        public frmMantenimientoTicketera()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Caja.frmRegistroTicketera obj = new SIGA.Windows.Caja.frmRegistroTicketera();
            obj.ShowDialog();

            SIGA.Business.Caja.TicketeraBusiness objTicket = new SIGA.Business.Caja.TicketeraBusiness();
            var result = objTicket.ConsultarTicketera(0, Convert.ToInt16(cboEmpresa.SelectedValue), txtDescripcion.Text);
            dgvMaquina.DataSource = result;
            dgvMaquina.Columns[0].Visible = false;
            dgvMaquina.Columns[1].Width = 150;
            dgvMaquina.Columns[2].Visible = false;
            dgvMaquina.Columns[8].Visible = false;
        }

        private void frmMantenimientoTicketera_Load(object sender, EventArgs e)
        {
            ConsultarMaquina();
            CargaEmpresa();
        }

        private void CargaEmpresa()
        {
            SIGA.Business.Logistica.EmpresaBusiness objMarcaBusiness = new SIGA.Business.Logistica.EmpresaBusiness();

            List<SIGA.Entities.Logistica.Empresa> resultMarca = new List<Entities.Logistica.Empresa>();
            resultMarca = objMarcaBusiness.Listar();
            cboEmpresa.DataSource = resultMarca;
            cboEmpresa.DisplayMember = "DesEmpresa";
            cboEmpresa.ValueMember = "CodEmpresa";
            cboEmpresa.SelectedIndex = -1;

        }

        private void ConsultarMaquina()
        {
            SIGA.Business.Caja.TicketeraBusiness objTicket = new SIGA.Business.Caja.TicketeraBusiness();
            var result = objTicket.ConsultarTicketera(0, 0, "");
            dgvMaquina.DataSource = result;
            dgvMaquina.Columns[0].Visible = false;
            dgvMaquina.Columns[1].Width = 150;
            dgvMaquina.Columns[2].Visible = false;
            dgvMaquina.Columns[8].Visible = false;

        }

        private void btnNumeroSerie_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMaquina.RowCount > 0)
                {
                    SIGA.Windows.Caja.frmRegNumeroSerie obj = new SIGA.Windows.Caja.frmRegNumeroSerie();
                    obj.CodigoMaquina = Convert.ToInt32(dgvMaquina[0, dgvMaquina.CurrentRow.Index].Value);
                    obj.ShowDialog();

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIGA.Business.Caja.TicketeraBusiness objTicket = new SIGA.Business.Caja.TicketeraBusiness();
            var result = objTicket.ConsultarTicketera(0,Convert.ToInt16(cboEmpresa.SelectedValue),txtDescripcion.Text);
            dgvMaquina.DataSource = result;
            dgvMaquina.Columns[0].Visible = false;
            dgvMaquina.Columns[1].Width = 150;
            dgvMaquina.Columns[2].Visible = false;
            dgvMaquina.Columns[8].Visible = false;





        }

        private void btnConsultarSeries_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMaquina.RowCount > 0)
                {
                    SIGA.Windows.Caja.frmDetalleRegistro obj = new SIGA.Windows.Caja.frmDetalleRegistro();
                    obj.CodigoTicketera = Convert.ToInt32(dgvMaquina[0, dgvMaquina.CurrentRow.Index].Value);
                    obj.ShowDialog();

                }
            }
            catch (Exception ex)
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {


            try
            {
                if (dgvMaquina.RowCount > 0)
                {
                    SIGA.Windows.Caja.frmRegistroTicketera obj = new SIGA.Windows.Caja.frmRegistroTicketera();
                    obj.CodigoTicketera = Convert.ToInt32(dgvMaquina[0, dgvMaquina.CurrentRow.Index].Value);
                    obj.ShowDialog();

                    SIGA.Business.Caja.TicketeraBusiness objTicket = new SIGA.Business.Caja.TicketeraBusiness();
                    var result = objTicket.ConsultarTicketera(0, Convert.ToInt16(cboEmpresa.SelectedValue), txtDescripcion.Text);
                    dgvMaquina.DataSource = result;
                    dgvMaquina.Columns[0].Visible = false;
                    dgvMaquina.Columns[1].Width = 150;
                    dgvMaquina.Columns[2].Visible = false;
                    dgvMaquina.Columns[8].Visible = false;
                }
            }
            catch (Exception ex)
            {
            
            }

            
        }
    }
}
