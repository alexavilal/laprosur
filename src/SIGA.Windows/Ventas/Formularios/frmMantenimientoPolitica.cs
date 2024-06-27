using SIGA.Business.Ventas;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmMantenimientoPolitica : Form
    {
        public frmMantenimientoPolitica()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(173, 216, 230);
        }

        private void frmMantenimientoPolitica_Load(object sender, EventArgs e)
        {
            ColumnasGrilla();
            CargarEstado();
            Buscar();
        }

        public void Buscar()
        {
            PoliticaPrecioBusiness objBusiness = new PoliticaPrecioBusiness();
            PoliticaPrecio objPolitica = new PoliticaPrecio();
            objPolitica.CodPolitica = string.IsNullOrEmpty(TxtCodigo.Text) ? Convert.ToInt16(0) : Convert.ToInt16(TxtCodigo.Text);
            objPolitica.DesPolitica = TxtDescripcion.Text;
            objPolitica.EstCodigo = Convert.ToString(cboEstado.SelectedValue);
            this.dgvModulo.DataSource = objBusiness.ObtenerPolitica(objPolitica);
            this.dgvModulo.Refresh();
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

            dgvModulo.ReadOnly = true;

            dgvModulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvModulo.MultiSelect = false;

            dgvModulo.AutoGenerateColumns = false;
            dgvModulo.ColumnCount = 3;

            dgvModulo.Columns[0].Name = "CodigoPolitica";
            dgvModulo.Columns[0].HeaderText = "Codigo";
            dgvModulo.Columns[0].DataPropertyName = "CodPolitica";
            dgvModulo.Columns[0].Width = 100;

            dgvModulo.Columns[1].HeaderText = "Descripcion";
            dgvModulo.Columns[1].Name = "DesPolitica";
            dgvModulo.Columns[1].DataPropertyName = "DesPolitica";
            dgvModulo.Columns[1].Width = 350;

            dgvModulo.Columns[2].Name = "EstCodigo";
            dgvModulo.Columns[2].HeaderText = "Estado";
            dgvModulo.Columns[2].DataPropertyName = "EstCodigo";
            dgvModulo.Columns[2].Width = 100;

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistroPolitica objForm = new frmRegistroPolitica();
            //objForm.FormClosed += new FormClosedEventHandler(frmRegistroPolitica_FormClosed);
            objForm.ShowDialog();
            Buscar();

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void frmMantenimientoPolitica_FormClosed(object sender, FormClosedEventArgs e)
        {
            Buscar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            int Codigo = 0;


            if (dgvModulo.RowCount > 0)
            {
                Codigo = Convert.ToInt32(dgvModulo[0, dgvModulo.CurrentRow.Index].Value);

                frmRegistroPolitica objfrmRegistroPolitica = new frmRegistroPolitica();
                //objfrmRegistroCliente.FormClosed += new FormClosedEventHandler(frmMantenimientoUsuario_FormClosed);
                objfrmRegistroPolitica.CodigoEdicion = Codigo;
                objfrmRegistroPolitica.ShowDialog();
                Buscar();

            }
        }
    }
}
