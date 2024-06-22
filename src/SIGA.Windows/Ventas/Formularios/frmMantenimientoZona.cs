using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SIGA.Business.Administrador;
using SIGA.Entities.Administrador;
using SIGA.Business.Ventas;
using SIGA.Entities.Ventas;
using SIGA.Windows.Administrador;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmMantenimientoZona : MaterialForm
    {
        public frmMantenimientoZona()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void frmMantenimientoZona_Load(object sender, EventArgs e)
        {
            ColumnasGrilla();
            CargarEstado();
            Buscar();
        }

        public void Buscar()
        {
            ZonaBusiness objZona = new ZonaBusiness();
            Zona EntZona = new Zona();
            EntZona.IdZona = string.IsNullOrEmpty(TxtCodigo.Text) ? Convert.ToInt16(0) : Convert.ToInt16(TxtCodigo.Text);
            EntZona.Descripcion = TxtDescripcion.Text;
            EntZona.Estado = Convert.ToString(cboEstado.SelectedValue);
            this.dgvModulo.DataSource = objZona.ObtenerZonas(EntZona);
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

            dgvModulo.Columns[0].Name = "Codigo";
            dgvModulo.Columns[0].HeaderText = "Codigo";
            dgvModulo.Columns[0].DataPropertyName = "idZona";
            dgvModulo.Columns[0].Width = 100;

            dgvModulo.Columns[1].HeaderText = "Descripcion";
            dgvModulo.Columns[1].Name = "Descripcion";
            dgvModulo.Columns[1].DataPropertyName = "Descripcion";
            dgvModulo.Columns[1].Width = 350;

            dgvModulo.Columns[2].Name = "Estado";
            dgvModulo.Columns[2].HeaderText = "Estado";
            dgvModulo.Columns[2].DataPropertyName = "Estado";
            dgvModulo.Columns[2].Width = 100;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistroZona objForm = new frmRegistroZona();
            //objForm.FormClosed += new FormClosedEventHandler(frmRegistroZona_FormClosed);
            objForm.ShowDialog();
            Buscar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            


            int Codigo = 0;


            if (dgvModulo.RowCount > 0)
            {
                Codigo = Convert.ToInt32(dgvModulo[0, dgvModulo.CurrentRow.Index].Value);
                frmRegistroZona objForm = new frmRegistroZona();
                //objForm.FormClosed += new FormClosedEventHandler(frmRegistroZona_FormClosed);
                objForm.CodigoEdicion = Codigo;
                objForm.ShowDialog();
                


                Buscar();

            }
        }
    }
}
