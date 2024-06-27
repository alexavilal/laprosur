using SIGA.Business.Administrador;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SIGA.Windows.Administrador
{
    public partial class FrmMantenimientoUsuario : Form
    {
        public FrmMantenimientoUsuario()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(173, 216, 230);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistroUsuario objForm = new frmRegistroUsuario();
            objForm.FormClosed += new FormClosedEventHandler(frmMantenimientoUsuario_FormClosed);
            objForm.ShowDialog();
        }

        private void frmMantenimientoUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Buscar();
        }

        void CargarEstado()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", "--Todos--"));
            data.Add(new KeyValuePair<string, string>("A", "Activo"));
            data.Add(new KeyValuePair<string, string>("I", "Inactivo"));

            CboEstado.DataSource = null;
            CboEstado.Items.Clear();

            CboEstado.DataSource = new BindingSource(data, null);
            CboEstado.DisplayMember = "Value";
            CboEstado.ValueMember = "Key";
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        public void Buscar()
        {
            UsuarioBusiness objBusiness = new UsuarioBusiness();
            SIGA.Entities.Administrador.Usuario objUsuario = new SIGA.Entities.Administrador.Usuario();
            objUsuario.ApellidoPaterno = TxtAp.Text;
            objUsuario.ApellidoMaterno = TxtAm.Text;
            objUsuario.Nombre = TxtNombre.Text;
            objUsuario.IdentificadorUsuario = TxtUsuario.Text;
            objUsuario.CorreoElectronico = TxtCorreo.Text;
            objUsuario.CodigoEstadoUsuario = Convert.ToString(CboEstado.SelectedValue);

            this.dgvUsuario.DataSource = objBusiness.ObtenerUsuarios(objUsuario);
            this.dgvUsuario.Refresh();
        }

        public void ColumnasGrilla()
        {

            dgvUsuario.ReadOnly = true;

            dgvUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuario.MultiSelect = false;
            dgvUsuario.AllowUserToAddRows = false;

            dgvUsuario.AutoGenerateColumns = false;
            dgvUsuario.ColumnCount = 7;

            dgvUsuario.Columns[0].Name = "CodigoUsuario";
            dgvUsuario.Columns[0].HeaderText = "Codigo";
            dgvUsuario.Columns[0].DataPropertyName = "CodigoUsuario";
            dgvUsuario.Columns[0].Width = 50;

            dgvUsuario.Columns[1].HeaderText = "Ap. Paterno";
            dgvUsuario.Columns[1].Name = "ApellidoPaterno";
            dgvUsuario.Columns[1].DataPropertyName = "ApellidoPaterno";
            dgvUsuario.Columns[1].Width = 150;

            dgvUsuario.Columns[2].HeaderText = "Ap. Materno";
            dgvUsuario.Columns[2].Name = "ApellidoMaterno";
            dgvUsuario.Columns[2].DataPropertyName = "ApellidoMaterno";
            dgvUsuario.Columns[2].Width = 150;

            dgvUsuario.Columns[3].HeaderText = "Nombres";
            dgvUsuario.Columns[3].Name = "Nombre";
            dgvUsuario.Columns[3].DataPropertyName = "Nombre";
            dgvUsuario.Columns[3].Width = 150;

            dgvUsuario.Columns[4].HeaderText = "Usuario";
            dgvUsuario.Columns[4].Name = "IdentificadorUsuario";
            dgvUsuario.Columns[4].DataPropertyName = "IdentificadorUsuario";
            dgvUsuario.Columns[4].Width = 120;

            dgvUsuario.Columns[5].HeaderText = "Correo";
            dgvUsuario.Columns[5].Name = "CorreoElectronico";
            dgvUsuario.Columns[5].DataPropertyName = "CorreoElectronico";
            dgvUsuario.Columns[5].Width = 180;

            dgvUsuario.Columns[6].HeaderText = "Estado";
            dgvUsuario.Columns[6].Name = "CodigoEstadoUsuario";
            dgvUsuario.Columns[6].DataPropertyName = "CodigoEstadoUsuario";
            dgvUsuario.Columns[6].Width = 60;

        }

        private void frmMantenimientoUsuario_Load(object sender, EventArgs e)
        {
            ColumnasGrilla();
            CargarEstado();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.RowCount >= 1)
            {
                Int16 codigo = Convert.ToInt16(dgvUsuario[0, dgvUsuario.CurrentRow.Index].Value);

                if (codigo > 0)
                {
                    frmRegistroUsuario objForm = new frmRegistroUsuario();
                    objForm.CodigoEdicion = codigo;
                    objForm.FormClosed += new FormClosedEventHandler(frmMantenimientoUsuario_FormClosed);
                    objForm.ShowDialog(this);
                }

            }
        }

    }
}
