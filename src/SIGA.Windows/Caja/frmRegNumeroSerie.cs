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
    public partial class frmRegNumeroSerie : Form
    {
        public int CodigoMaquina = 0;
        public int CodigoEmpresa = 0;
        public frmRegNumeroSerie()
        {
            InitializeComponent();
        }

        private void CargaSede()
        {
            SIGA.Business.Logistica.SedeBusiness objSede = new SIGA.Business.Logistica.SedeBusiness();
            List<SIGA.Entities.Logistica.Sede> objEntSede = new List<SIGA.Entities.Logistica.Sede>();

            objEntSede = objSede.Listar();
            objEntSede.Add(new SIGA.Entities.Logistica.Sede() { CodSede = 0, DesSede = "--Todos--" });
            cboSede.DataSource = objEntSede;

            cboSede.ValueMember = "CodSede";
            cboSede.DisplayMember = "DesSede";

            cboSede.SelectedIndex = -1;
        }

        private void CargaEmpresa()
        {
            //SIGA.Business.Logistica.EmpresaBusiness objMarcaBusiness = new SIGA.Business.Logistica.EmpresaBusiness();

            //List<SIGA.Entities.Logistica.Empresa> resultMarca = new List<Entities.Logistica.Empresa>();
            //resultMarca = objMarcaBusiness.Listar();
            //cboEmpresa.DataSource = resultMarca;
            //cboEmpresa.DisplayMember = "DesEmpresa";
            //cboEmpresa.ValueMember = "CodEmpresa";
            //cboEmpresa.SelectedIndex = -1;
        }

        private void CargaTipoDocumento()
        {
            SIGA.Business.Logistica.TipoDocumentoBusiness objMarcaBusiness = new SIGA.Business.Logistica.TipoDocumentoBusiness();

            List<SIGA.Entities.Logistica.TipoDocumento> resultMarca = new List<Entities.Logistica.TipoDocumento>();
            resultMarca = objMarcaBusiness.Listar();
            cboDocumento.DataSource = resultMarca;
            cboDocumento.DisplayMember = "DesDocumento";
            cboDocumento.ValueMember = "CodTipoDocumento";
            cboDocumento.SelectedIndex = -1;


        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        public void Grabar()
        {
            SIGA.Business.Caja.NumeroSerieBusiness objNumero = new SIGA.Business.Caja.NumeroSerieBusiness();



            var Result = objNumero.Insertar(Convert.ToInt16(1),
                                            Convert.ToInt16(CodigoEmpresa),
                                            cboDocumento.SelectedValue.ToString(), txtNumSerie.Text, Convert.ToInt32(txtInicio.Text), Convert.ToInt32(txtFin.Text), Convert.ToInt32(txtActual.Text), "A", UsuarioLogeo.Codigo,CodigoMaquina);


            if (Result >= 0)
            {
                MessageBox.Show("Se ha registrado la numeracion....");
                this.Close();
                
            }

        }

        private void frmRegNumeroSerie_Load(object sender, EventArgs e)
        {
            CargaEmpresa();
            CargaSede();
            CargaTipoDocumento();
            CboEstado.Text = "ACTIVO";
            CboEstado.Enabled = false;
            CargaMaquina();
            CargaDatos();
        }

        private void CargaMaquina()
        {
            SIGA.Business.Caja.TicketeraBusiness obj = new SIGA.Business.Caja.TicketeraBusiness();
            var result = obj.ConsultarTicketera(0, 0, "");
            cboMaquina.DataSource = result;
            cboMaquina.ValueMember = "Codigo";
            cboMaquina.DisplayMember = "Maquina";
            

        }

        private void CargaDatos()
        {
            SIGA.Business.Caja.TicketeraBusiness obj = new SIGA.Business.Caja.TicketeraBusiness();
            var result = obj.ConsultarTicketera(Convert.ToInt16(CodigoMaquina),0,"");

            if (result.Rows.Count > 0)
            {
                cboMaquina.SelectedValue = result.Rows[0]["Codigo"];
                txtEmpresa.Text = result.Rows[0]["Empresa"].ToString();
                CodigoEmpresa = Convert.ToInt32(result.Rows[0]["CodigoEmpresa"]);

            }

        }
    }
}
