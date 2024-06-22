using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;

namespace SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos
{
    public partial class frmMantenimientoFamilia : Form
    {
        public frmMantenimientoFamilia()
        {
            InitializeComponent();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistroFamilia objForm = new frmRegistroFamilia();
            objForm.FormClosed += new FormClosedEventHandler(FrmRegistro_FormClosed);
            objForm.ShowDialog();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvFamilia.RowCount > 0)
            {
                Int16 codigo = Convert.ToInt16(dgvFamilia[0, dgvFamilia.CurrentRow.Index].Value);

                frmRegistroFamilia objForm = new frmRegistroFamilia();
                objForm.CodigoEdicion = codigo;
                objForm.FormClosed += new FormClosedEventHandler(FrmRegistro_FormClosed);
                objForm.ShowDialog(this);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string strEstado = string.Empty;

            strEstado = cboEstado.SelectedValue.ToString().Equals("") ? String.Empty : cboEstado.SelectedValue.ToString().Substring(0, 1);

            Buscar(strEstado);
        }

        private void frmMantenimientoFamilia_Load(object sender, EventArgs e)
        {
            CargarEstado();
            ColumnasGrilla();
            Buscar("");

        }

        public void Buscar(string strESTADO)
        {
            FamiliaBusiness objBusiness = new FamiliaBusiness();
            Familia objFamilia = new Familia();
            objFamilia.CodFamilia = 0;
            objFamilia.CodIntFamilia = string.IsNullOrEmpty(TxtCodigo.Text) ? string.Empty : Convert.ToString(TxtCodigo.Text);
            objFamilia.CodCuenta = string.IsNullOrEmpty(txtCuenta.Text) ? string.Empty : Convert.ToString(txtCuenta.Text);
            objFamilia.DesFamilia = TxtDescripcion.Text;
            objFamilia.EstCodigo = strESTADO;
            this.dgvFamilia.DataSource = objBusiness.ObtenerFamilias(objFamilia);
            this.dgvFamilia.Refresh();

            dgvFamilia.Columns[0].Visible = false;
            //dgvFamilia.Columns[1].HeaderText = "Codigo";
            //dgvFamilia.Columns[2].HeaderText = "Descripcion";
            //dgvFamilia.Columns[3].HeaderText = "Cuenta";
            //dgvFamilia.Columns[4].HeaderText = "Estado";

            //ItemResult.CodFamilia = Convert.ToInt32(dr.GetValue(0));
            //ItemResult.CodIntFamilia = Convert.ToString(dr.GetValue(1));
            //ItemResult.DesFamilia = dr.GetValue(2).ToString();
            //ItemResult.CodCuenta = dr.GetValue(3).ToString();
            //ItemResult.EstCodigo = dr.GetValue(4).ToString();

        }

        private void FrmRegistro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Buscar("");
        }

        void CargarEstado()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", "Todos"));
            data.Add(new KeyValuePair<string, string>("A", "Activo"));
            data.Add(new KeyValuePair<string, string>("I", "Inactivo"));

            cboEstado.DataSource = null;
            cboEstado.Items.Clear();

            cboEstado.DataSource = new BindingSource(data, null);
            cboEstado.DisplayMember = "Value";
            cboEstado.ValueMember = "Key";
        }

        public void ColumnasGrilla()
        {

            dgvFamilia.ReadOnly = true;

            dgvFamilia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFamilia.AllowUserToAddRows = false;
            dgvFamilia.MultiSelect = false;

            dgvFamilia.AutoGenerateColumns = false;
            dgvFamilia.ColumnCount = 5;

            dgvFamilia.Columns[0].HeaderText = "Codigo";
            dgvFamilia.Columns[0].Name = "CodFamilia";
            dgvFamilia.Columns[0].DataPropertyName = "CodFamilia";
            dgvFamilia.Columns[0].Width = 100;

            dgvFamilia.Columns[1].HeaderText = "Codigo Interno";
            dgvFamilia.Columns[1].Name = "CodIntFamilia";
            dgvFamilia.Columns[1].DataPropertyName = "CodIntFamilia";
            dgvFamilia.Columns[1].Width = 75;

            dgvFamilia.Columns[2].HeaderText = "Descripción";
            dgvFamilia.Columns[2].Name = "DesFamilia";
            dgvFamilia.Columns[2].DataPropertyName = "DesFamilia";
            dgvFamilia.Columns[2].Width = 350;

            dgvFamilia.Columns[3].HeaderText = "Cuenta";
            dgvFamilia.Columns[3].Name = "CodCuenta";
            dgvFamilia.Columns[3].DataPropertyName = "CodCuenta";
            dgvFamilia.Columns[3].Width = 85;


            dgvFamilia.Columns[4].HeaderText = "Estado";
            dgvFamilia.Columns[4].Name = "EstCodigo";
            dgvFamilia.Columns[4].DataPropertyName = "EstCodigo";
            dgvFamilia.Columns[4].Width = 100;
        }


    }
}
