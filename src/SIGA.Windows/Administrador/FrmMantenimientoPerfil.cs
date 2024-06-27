using SIGA.Business.Administrador;
using SIGA.Entities.Administrador;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SIGA.Windows.Administrador
{
    public partial class FrmMantenimientoPerfil : Form
    {
        public FrmMantenimientoPerfil()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(173, 216, 230);
        }

        private void FrmMantenimientoPerfil_Load(object sender, EventArgs e)
        {
            ColumnasGrilla();
            CargarEstado();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        public void Buscar()
        {
            PerfilBusiness objBusiness = new PerfilBusiness();
            Perfil objModulo = new Perfil();
            objModulo.CodPerfil = string.IsNullOrEmpty(TxtCodigo.Text) ? Convert.ToInt16(0) : Convert.ToInt16(TxtCodigo.Text);
            objModulo.DesPerfil = TxtDescripcion.Text;
            objModulo.EstadoPerfil = Convert.ToString(cboEstado.SelectedValue);
            this.dgvModulo.DataSource = objBusiness.ObtenerPerfiles(objModulo);
            this.dgvModulo.Refresh();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmRegistroPerfil objForm = new FrmRegistroPerfil();
            objForm.FormClosed += new FormClosedEventHandler(FrmRegistroPerfil_FormClosed);
            objForm.ShowDialog();
        }

        private void FrmRegistroPerfil_FormClosed(object sender, FormClosedEventArgs e)
        {
            Buscar();
        }

        void CargarEstado()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", "--Todos--"));
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

            dgvModulo.ReadOnly = true;

            dgvModulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvModulo.MultiSelect = false;

            dgvModulo.AutoGenerateColumns = false;
            dgvModulo.ColumnCount = 3;

            dgvModulo.Columns[0].Name = "Codigo";
            dgvModulo.Columns[0].HeaderText = "Codigo";
            dgvModulo.Columns[0].DataPropertyName = "CodPerfil";
            dgvModulo.Columns[0].Width = 100;

            dgvModulo.Columns[1].HeaderText = "Descripcion";
            dgvModulo.Columns[1].Name = "DesPerfil";
            dgvModulo.Columns[1].DataPropertyName = "DesPerfil";
            dgvModulo.Columns[1].Width = 350;

            dgvModulo.Columns[2].HeaderText = "Estado";
            dgvModulo.Columns[2].Name = "EstadoPerfil";
            dgvModulo.Columns[2].DataPropertyName = "EstadoPerfil";
            dgvModulo.Columns[2].Width = 100;

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvModulo.RowCount >= 1)
            {
                Int16 codigo = Convert.ToInt16(dgvModulo[0, dgvModulo.CurrentRow.Index].Value);

                FrmRegistroPerfil objForm = new FrmRegistroPerfil();
                objForm.CodigoEdicion = codigo;
                objForm.FormClosed += new FormClosedEventHandler(FrmRegistroPerfil_FormClosed);
                objForm.ShowDialog(this);
            }
        }






    }
}
