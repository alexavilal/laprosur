using SIGA.Business.Administrador;
using SIGA.Entities.Administrador;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SIGA.Windows.Administrador
{
    public partial class FrmMantenimientoOpciones : Form
    {
        public FrmMantenimientoOpciones()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(173, 216, 230);
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvOpciones.RowCount >= 1)
            {
                Int16 codigo = Convert.ToInt16(DgvOpciones[0, DgvOpciones.CurrentRow.Index].Value);

                if (codigo > 0)
                {
                    FrmRegistroOpciones objForm = new FrmRegistroOpciones();
                    objForm.CodigoEdicion = codigo;
                    objForm.FormClosed += new FormClosedEventHandler(FrmRegistroOpciones_FormClosed);
                    objForm.ShowDialog(this);
                }
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmRegistroOpciones objForm = new FrmRegistroOpciones();
            objForm.FormClosed += new FormClosedEventHandler(FrmRegistroOpciones_FormClosed);
            objForm.ShowDialog();
        }

        private void FrmRegistroOpciones_FormClosed(object sender, FormClosedEventArgs e)
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


        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        void ListarModulos()
        {
            ModuloBusiness objBusiness = new ModuloBusiness();
            Modulo objModulo = new Modulo();
            objModulo.DescripcionModulo = string.Empty;
            objModulo.EstadoModulo = "A";


            List<Modulo> Lista = new List<Modulo>();
            Lista.Add(new Modulo { CodigoModulo = 0, DescripcionModulo = "Seleccione" });

            var consulta = objBusiness.ObtenerModulos(objModulo);

            foreach (var item in consulta)
            {
                Lista.Add(item);
            }

            CboModulo.DataSource = Lista;
            CboModulo.ValueMember = "CodigoModulo";
            CboModulo.DisplayMember = "DescripcionModulo";
        }

        public void Buscar()
        {
            OpcionBusiness objBusiness = new OpcionBusiness();
            Opcion objUsuario = new Opcion();
            objUsuario.CodModulo = Convert.ToInt16(CboModulo.SelectedValue);
            objUsuario.DesOpcion = TxtDescripcion.Text;
            objUsuario.CodOpcion = string.IsNullOrEmpty(TxtCodigo.Text) ? Convert.ToInt16(0) : Convert.ToInt16(TxtCodigo.Text);
            objUsuario.EstCodigo = Convert.ToString(CboEstado.SelectedValue);

            this.DgvOpciones.DataSource = objBusiness.ObtenerOpciones(objUsuario);
            this.DgvOpciones.Refresh();
        }

        public void ColumnasGrilla()
        {

            DgvOpciones.ReadOnly = true;

            DgvOpciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvOpciones.MultiSelect = false;

            DgvOpciones.AutoGenerateColumns = false;
            DgvOpciones.ColumnCount = 4;

            DgvOpciones.Columns[0].HeaderText = "Codigo";
            DgvOpciones.Columns[0].Name = "CodOpcion";
            DgvOpciones.Columns[0].DataPropertyName = "CodOpcion";
            DgvOpciones.Columns[0].Width = 100;

            DgvOpciones.Columns[1].HeaderText = "Modulo";
            DgvOpciones.Columns[1].Name = "DesModulo";
            DgvOpciones.Columns[1].DataPropertyName = "DesModulo";
            DgvOpciones.Columns[1].Width = 180;

            DgvOpciones.Columns[2].HeaderText = "Descripción";
            DgvOpciones.Columns[2].Name = "DesOpcion";
            DgvOpciones.Columns[2].DataPropertyName = "DesOpcion";
            DgvOpciones.Columns[2].Width = 180;

            DgvOpciones.Columns[3].HeaderText = "Estado";
            DgvOpciones.Columns[3].Name = "EstCodigo";
            DgvOpciones.Columns[3].DataPropertyName = "EstCodigo";
            DgvOpciones.Columns[3].Width = 60;
        }

        private void FrmMantenimientoOpciones_Load(object sender, EventArgs e)
        {
            ColumnasGrilla();
            CargarEstado();
            ListarModulos();
        }



    }
}
