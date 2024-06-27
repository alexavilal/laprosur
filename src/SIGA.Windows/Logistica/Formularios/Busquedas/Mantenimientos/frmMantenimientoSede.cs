using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos
{
    public partial class frmMantenimientoSede : Form
    {
        public frmMantenimientoSede()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvSede.RowCount > 0)
            {
                Int16 codigo = Convert.ToInt16(dgvSede[0, dgvSede.CurrentRow.Index].Value);

                frmRegistroSede objForm = new frmRegistroSede();
                objForm.CodigoEdicion = codigo;
                objForm.FormClosed += new FormClosedEventHandler(FrmRegistro_FormClosed);
                objForm.ShowDialog(this);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistroSede objForm = new frmRegistroSede();
            objForm.FormClosed += new FormClosedEventHandler(FrmRegistro_FormClosed);
            objForm.ShowDialog();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void frmMantenimientoSede_Load(object sender, EventArgs e)
        {
            ColumnasGrilla();
            CargarEstado();
        }

        public void Buscar()
        {
            SedeBusiness objBusiness = new SedeBusiness();
            Sede objSede = new Sede();
            objSede.CodSede = string.IsNullOrEmpty(TxtCodigo.Text) ? Convert.ToInt16(0) : Convert.ToInt16(TxtCodigo.Text);
            objSede.DesSede = TxtDescripcion.Text;
            objSede.DirSede = TxtDireccion.Text;
            objSede.EstCodigo = Convert.ToString(cboEstado.SelectedValue);
            this.dgvSede.DataSource = objBusiness.ObtenerSedes(objSede);
            this.dgvSede.Refresh();
        }

        private void FrmRegistro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Buscar();
        }

        void CargarEstado()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", "Seleccionar"));
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

            dgvSede.ReadOnly = true;

            dgvSede.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSede.AllowUserToAddRows = false;
            dgvSede.MultiSelect = false;

            dgvSede.AutoGenerateColumns = false;
            dgvSede.ColumnCount = 4;

            dgvSede.Columns[0].HeaderText = "Codigo";
            dgvSede.Columns[0].Name = "CodSede";
            dgvSede.Columns[0].DataPropertyName = "CodSede";
            dgvSede.Columns[0].Width = 100;

            dgvSede.Columns[1].HeaderText = "Descripción";
            dgvSede.Columns[1].Name = "DesSede";
            dgvSede.Columns[1].DataPropertyName = "DesSede";
            dgvSede.Columns[1].Width = 350;

            dgvSede.Columns[2].HeaderText = "Dirección";
            dgvSede.Columns[2].Name = "DirSede";
            dgvSede.Columns[2].DataPropertyName = "DirSede";
            dgvSede.Columns[2].Width = 150;

            dgvSede.Columns[3].HeaderText = "Estado";
            dgvSede.Columns[3].Name = "EstCodigo";
            dgvSede.Columns[3].DataPropertyName = "EstCodigo";
            dgvSede.Columns[3].Width = 100;
        }

        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }



    }
}
