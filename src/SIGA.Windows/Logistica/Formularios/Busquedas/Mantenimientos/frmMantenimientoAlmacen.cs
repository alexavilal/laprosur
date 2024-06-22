using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;

namespace SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos
{
    public partial class frmMantenimientoAlmacen : Form
    {
        public frmMantenimientoAlmacen()
        {
            InitializeComponent();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistroAlmacen objForm = new frmRegistroAlmacen();
            objForm.FormClosed += new FormClosedEventHandler(FrmRegistro_FormClosed);
            objForm.ShowDialog();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvAlmacen.RowCount > 0)
            {
                Int16 codigo = Convert.ToInt16(dgvAlmacen[0, dgvAlmacen.CurrentRow.Index].Value);

                frmRegistroAlmacen objForm = new frmRegistroAlmacen();
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
            Buscar();
        }

        private void frmMantenimientoAlmacen_Load(object sender, EventArgs e)
        {
            ColumnasGrilla();
            CargarEstado();
            ListarSedes();
        }


        public void Buscar()
        {
            AlmacenBusiness objBusiness = new AlmacenBusiness();
            Almacen objAlmacen = new Almacen();
            objAlmacen.CodAlmacen = string.IsNullOrEmpty(TxtCodigo.Text) ? Convert.ToInt16(0) : Convert.ToInt16(TxtCodigo.Text);
            objAlmacen.DesAlmacen = TxtDescripcion.Text;
            objAlmacen.CodSede = Convert.ToInt16(cboSede.SelectedValue);
            objAlmacen.Estado = Convert.ToString(cboEstado.SelectedValue);
            this.dgvAlmacen.DataSource = objBusiness.ObtenerAlmacens(objAlmacen);
            this.dgvAlmacen.Refresh();
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

            dgvAlmacen.ReadOnly = true;

            dgvAlmacen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlmacen.AllowUserToAddRows = false;
            dgvAlmacen.MultiSelect = false;

            dgvAlmacen.AutoGenerateColumns = false;
            dgvAlmacen.ColumnCount = 4;

            dgvAlmacen.Columns[0].HeaderText = "Codigo";
            dgvAlmacen.Columns[0].Name = "CodAlmacen";
            dgvAlmacen.Columns[0].DataPropertyName = "CodAlmacen";
            dgvAlmacen.Columns[0].Width = 100;

            dgvAlmacen.Columns[1].HeaderText = "Descripción";
            dgvAlmacen.Columns[1].Name = "DesAlmacen";
            dgvAlmacen.Columns[1].DataPropertyName = "DesAlmacen";
            dgvAlmacen.Columns[1].Width = 350;


            dgvAlmacen.Columns[2].HeaderText = "Sede";
            dgvAlmacen.Columns[2].Name = "DesSede";
            dgvAlmacen.Columns[2].DataPropertyName = "DesSede";
            dgvAlmacen.Columns[2].Width = 100;


            dgvAlmacen.Columns[3].HeaderText = "Estado";
            dgvAlmacen.Columns[3].Name = "Estado";
            dgvAlmacen.Columns[3].DataPropertyName = "Estado";
            dgvAlmacen.Columns[3].Width = 100;
        }

        void ListarSedes()
        {
            SedeBusiness objBusiness = new SedeBusiness();
            Sede objSedes= new Sede();
            objSedes.CodSede = 0;
            objSedes.DesSede = string.Empty;
            objSedes.DirSede = string.Empty;
            objSedes.EstCodigo = "A";

            List<Sede> Lista = new List<Sede>();
            Lista.Add(new Sede { CodSede = 0, DesSede = "Seleccione" });

            var consulta = objBusiness.ObtenerSedes(objSedes);

            foreach (var item in consulta)
            {
                Lista.Add(item);
            }

            cboSede.DataSource = Lista;
            cboSede.ValueMember = "CodSede";
            cboSede.DisplayMember = "DesSede";
        }





    }
}
