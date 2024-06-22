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
    public partial class frmRegistroTicketera : Form
    {
        public int CodigoTicketera { get; set; }
        public frmRegistroTicketera()
        {
            InitializeComponent();
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

        private void CargaTipoFacturacion()
        {
            SIGA.Business.Caja.TipoFacturacionBusiness obj = new SIGA.Business.Caja.TipoFacturacionBusiness();
            var result = obj.TipoFacturacionConsultar();
            cboTipoFacturacion.DataSource = result;
            cboTipoFacturacion.ValueMember = "CODTIPOFACTURACION";
            cboTipoFacturacion.DisplayMember = "DESTIPOFACTURACION";

           

        }

        private void frmRegistroTicketera_Load(object sender, EventArgs e)
        {
            CargaEmpresa();
            CargaTipoFacturacion();

            if (CodigoTicketera > 0)
            {
                SIGA.Business.Caja.TicketeraBusiness objTicket = new SIGA.Business.Caja.TicketeraBusiness();
               var result = objTicket.ConsultarTicketera(Convert.ToInt16(CodigoTicketera),0,"");

               if (result.Rows.Count > 0)
               {    

                
                   cboEmpresa.SelectedValue = Convert.ToInt16(result.Rows[0][2]);
                   txtDescripcion.Text = Convert.ToString(result.Rows[0][1]);
                   txtRuta.Text = Convert.ToString(result.Rows[0][4]);
                   txtObservacion.Text = Convert.ToString(result.Rows[0][5]);
                   CboEstado.Enabled = false;
                   CboEstado.Text = "Activo";
                   cboTipoFacturacion.SelectedValue = Convert.ToInt32(result.Rows[0][8]);

               }        
            }

            
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Equals(string.Empty) || txtRuta.Text.Equals(string.Empty))
            {
                MessageBox.Show("Faltan datos");
                return;
            }


           if (CodigoTicketera.Equals(0))
           {
               Guardar();
           }
           else
           {
               Actualizar();
           }


        }


        private void Guardar()
        {
            SIGA.Business.Caja.TicketeraBusiness obj = new SIGA.Business.Caja.TicketeraBusiness();

        
            var result = obj.Registrar(Convert.ToInt16(cboEmpresa.SelectedValue), txtDescripcion.Text, txtRuta.Text, txtObservacion.Text, "A", UsuarioLogeo.Codigo,Convert.ToInt32(cboTipoFacturacion.SelectedValue));

            if (result >= 0)
            {
                MessageBox.Show("Ha registado la maquina ticketera...!");
                this.Close();

            }

        }

        private void Actualizar()
        {
            SIGA.Business.Caja.TicketeraBusiness obj = new SIGA.Business.Caja.TicketeraBusiness();


            var result = obj.Actualizar(CodigoTicketera, Convert.ToInt16(cboEmpresa.SelectedValue), txtDescripcion.Text, txtRuta.Text, txtObservacion.Text, UsuarioLogeo.Codigo, Convert.ToInt32(cboTipoFacturacion.SelectedValue));

            if (result >= 0)
            {
                MessageBox.Show("Ha actualizado la maquina ticketera...!");
                this.Close();

            }

        }
    }
}
