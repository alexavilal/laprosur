using MaterialSkin;
using MaterialSkin.Controls;
using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace SIGA.Windows.Logistica.Formularios
{
    public partial class frmMantenimientoProducto : MaterialForm
    {
        public frmMantenimientoProducto()
        {
            InitializeComponent();
            //this.BackColor = Color.FromArgb(173, 216, 230);

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmRegProducto objSugerido = new frmRegProducto();
            objSugerido.ShowDialog();
            Buscar();
        }

        //private void CargaClasificacion()
        //{
        //    SIGA.Business.Logistica.ClasificacionBusiness objMarcaBusiness = new SIGA.Business.Logistica.ClasificacionBusiness();
        //    var Lista = objMarcaBusiness.ConsultarClasificacion();

        //    DataRow dr = Lista.NewRow();
        //    dr["CodGeneralClasificacion"] = 0;
        //    dr["DesGeneralClasificacion"] = "--Todos--";

        //    Lista.Rows.InsertAt(dr, 0);

        //    cboClasificacion.DataSource = Lista;
        //    cboClasificacion.DisplayMember = "DesGeneralClasificacion";
        //    cboClasificacion.ValueMember = "CodGeneralClasificacion";
        //    cboClasificacion.SelectedValue = 0;
        //}
        private void Cargar()
        {
            SIGA.Business.Logistica.GeneralBusiness objBusiness = new SIGA.Business.Logistica.GeneralBusiness();

            var result = objBusiness.ConsultarPorDescripcionGeneral("1", 1, 1, "");

            dataGridView1.DataSource = result;

            dataGridView1.Columns["Codigo"].Visible = false;

            dataGridView1.Columns["Empresa"].Width = 200;

            dataGridView1.Columns["CodigoExterno"].Width = 100;

            dataGridView1.Columns["CodigoBarra"].Width = 100;

            dataGridView1.Columns["Marca"].Width = 100;

            dataGridView1.Columns["Descripcion"].Width = 250;

            dataGridView1.Columns["Estado"].Width = 100;




        }

        private void frmMantenimientoProducto_Load(object sender, EventArgs e)
        {
            //CargaMarca();
            //CargaMaterial();
            CargaFamilia();
            //CargaColor();
            //CargaEmpresa();
            CargaUnidadMedida();
            //CargaEmpaque();
            //CargaCapacidad();
            CargarEstado();
            //CargaForma();
            //CargaClasificacion();
            //CargaSeccion();
            CargarDisponibilidadVentas();
        }


        //private void CargaSeccion()
        //{
        //    SeccionBusiness seccionBusiness = new SeccionBusiness();
        //    List<Seccion> seccionList = new List<Seccion>();
        //    seccionList.Add(new Seccion()
        //    {
        //        CodigoSeccion = 0,
        //        DescripcionSeccion = "--Todos"
        //    });
        //    foreach (Seccion seccion in seccionBusiness.ListarSeccion())
        //        seccionList.Add(seccion);
        //    this.cboSeccion.DataSource = (object)seccionList;
        //    this.cboSeccion.DisplayMember = "DescripcionSeccion";
        //    this.cboSeccion.ValueMember = "CodigoSeccion";
        //    this.cboSeccion.SelectedValue = (object)0;
        //}
        #region "Carga Combos"
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

        void CargarDisponibilidadVentas()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", "Sin distincion"));
            data.Add(new KeyValuePair<string, string>("1", "Si"));
            data.Add(new KeyValuePair<string, string>("0", "No"));

            cboVentas.DataSource = null;
            cboVentas.Items.Clear();

            cboVentas.DataSource = new BindingSource(data, null);
            cboVentas.DisplayMember = "Value";
            cboVentas.ValueMember = "Key";
        }


        //private void CargaMarca()
        //{
        //    SIGA.Business.Logistica.MarcaBusiness objMarcaBusiness = new SIGA.Business.Logistica.MarcaBusiness();
        //    List<SIGA.Entities.Logistica.Marca> Lista = new List<SIGA.Entities.Logistica.Marca>();
        //    Lista.Add(new SIGA.Entities.Logistica.Marca { CodMarca = 0, DesMarca = "Seleccione" });

        //    var consulta = objMarcaBusiness.Listar("");

        //    foreach (var item in consulta)
        //    {
        //        Lista.Add(item);
        //    }

        //    cboMarca.DataSource = Lista;
        //    cboMarca.DisplayMember = "DesMarca";
        //    cboMarca.ValueMember = "CodMarca";



        //}


        //private void CargaEmpresa()
        //{
        //    SIGA.Business.Logistica.EmpresaBusiness objMarcaBusiness = new SIGA.Business.Logistica.EmpresaBusiness();
        //    List<SIGA.Entities.Logistica.Empresa> Lista = new List<SIGA.Entities.Logistica.Empresa>();
        //    Lista.Add(new SIGA.Entities.Logistica.Empresa { CodEmpresa = 0, DesEmpresa = "Seleccione" });

        //    var resutlMarca = objMarcaBusiness.Listar();

        //    foreach (var item in resutlMarca)
        //    {
        //        Lista.Add(item);
        //    }

        //    cboEmpresa.DataSource = Lista;
        //    cboEmpresa.DisplayMember = "DesEmpresa";
        //    cboEmpresa.ValueMember = "CodEmpresa";


        //}





        //private void CargaColor()
        //{
        //    SIGA.Business.Logistica.ColorBusiness objMarcaBusiness = new SIGA.Business.Logistica.ColorBusiness();
        //    List<SIGA.Entities.Logistica.Color> Lista = new List<SIGA.Entities.Logistica.Color>();
        //    Lista.Add(new SIGA.Entities.Logistica.Color { CodColor = 0, DesColor = "Seleccione" });


        //    var resutlMarca = objMarcaBusiness.Listar();

        //    foreach (var item in resutlMarca)
        //    {
        //        Lista.Add(item);
        //    }

        //    cboColor.DataSource = Lista;
        //    cboColor.DisplayMember = "DesColor";
        //    cboColor.ValueMember = "CodColor";

        //}




        //private void CargaMaterial()
        //{
        //    SIGA.Business.Logistica.MaterialBusiness objMarcaBusiness = new SIGA.Business.Logistica.MaterialBusiness();
        //    List<SIGA.Entities.Logistica.Material> Lista = new List<Entities.Logistica.Material>();
        //    Lista.Add(new SIGA.Entities.Logistica.Material { CodMaterial = 0, DesMaterial = "Seleccione" });


        //    var resutlMarca = objMarcaBusiness.Listar(0,"","A");

        //    foreach (var item in resutlMarca)
        //    {
        //        Lista.Add(item);
        //    }

        //    cboMaterial.DataSource = Lista;
        //    cboMaterial.DisplayMember = "DesMaterial";
        //    cboMaterial.ValueMember = "CodMaterial";

        //}


        private void CargaFamilia()
        {
            SIGA.Business.Logistica.FamiliaBusiness objMarcaBusiness = new SIGA.Business.Logistica.FamiliaBusiness();
            List<SIGA.Entities.Logistica.Familia> Lista = new List<SIGA.Entities.Logistica.Familia>();

            Lista.Add(new SIGA.Entities.Logistica.Familia { CodFamilia = 0, DesFamilia = "Todos" });

            Familia objFamilia = new Familia()
            {
                CodFamilia = 0,
                CodIntFamilia = string.Empty,
                CodCuenta = string.Empty,
                DesFamilia = string.Empty,
                EstCodigo = String.Empty
            };



            var resutlMarca = objMarcaBusiness.ObtenerFamilias(objFamilia);

            foreach (var item in resutlMarca)
            {
                Lista.Add(item);
            }

            cboFamilia.DataSource = Lista;
            cboFamilia.DisplayMember = "DesFamilia";
            cboFamilia.ValueMember = "CodFamilia";

        }



        private void CargaUnidadMedida()
        {
            SIGA.Business.Logistica.UnidadMedidaBusiness objMarcaBusiness = new SIGA.Business.Logistica.UnidadMedidaBusiness();
            List<SIGA.Entities.Logistica.UnidadMedida> Lista = new List<SIGA.Entities.Logistica.UnidadMedida>();

            Lista.Add(new SIGA.Entities.Logistica.UnidadMedida { CodUnidadMedida = 0, DesUnidadMedida = "Seleccione" });

            var resutlMarca = objMarcaBusiness.Listar();


            foreach (var item in resutlMarca)
            {
                Lista.Add(item);
            }

            cboUnidadMedida.DataSource = Lista;

            cboUnidadMedida.ValueMember = "CodUnidadMedida";
            cboUnidadMedida.DisplayMember = "DesUnidadMedida";



        }



        //private void CargaEmpaque()
        //{
        //    SIGA.Business.Logistica.EmpaqueBusiness objMarcaBusiness = new SIGA.Business.Logistica.EmpaqueBusiness();
        //    List<SIGA.Entities.Logistica.Empaque> Lista = new List<Entities.Logistica.Empaque>();

        //    Lista.Add(new SIGA.Entities.Logistica.Empaque { CodEmpaque = 0, DesEmpaque = "Seleccione" });


        //    var resutlMarca = objMarcaBusiness.Listar();

        //    foreach (var item in resutlMarca)
        //    {
        //        Lista.Add(item);
        //    }

        //    cboEmpaque.DataSource = Lista;
        //    cboEmpaque.DisplayMember = "DesEmpaque";
        //    cboEmpaque.ValueMember = "CodEmpaque";

        //}

        //private void CargaCapacidad()
        //{
        //    SIGA.Business.Logistica.CapacidadBusiness objMarcaBusiness = new SIGA.Business.Logistica.CapacidadBusiness();
        //    List<SIGA.Entities.Logistica.Capacidad> Lista = new List<SIGA.Entities.Logistica.Capacidad>();

        //    Lista.Add(new SIGA.Entities.Logistica.Capacidad { CodCapacidad = 0,DesCapacidad = "Seleccione" });


        //    var resutlMarca = objMarcaBusiness.Listar();


        //    foreach (var item in resutlMarca)
        //    {
        //        Lista.Add(item);
        //    }
        //    Capacidad.DataSource = Lista;
        //    Capacidad.DisplayMember = "DesCapacidad";
        //    Capacidad.ValueMember = "CodCapacidad";

        //}









        #endregion


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount >= 0)
                {
                    int Codigo = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
                    SIGA.Windows.Logistica.Formularios.frmRegProducto objSugerido = new SIGA.Windows.Logistica.Formularios.frmRegProducto();
                    objSugerido.CodigoGeneral = Codigo;
                    objSugerido.ShowDialog();
                    Buscar();

                }
                else
                {
                    MessageBox.Show("No existen items para modificar...!", "SIGA");
                }

            }
            catch (Exception ex)
            {

            }


        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {



        }

        private void cboFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                CargaSubFamilia(Convert.ToInt16(cboFamilia.SelectedValue));
            }
            catch (Exception ex)
            {

            }
        }
        private void CargaSubFamilia(Int16 CodigoFamilia)
        {
            //SIGA.Business.Logistica.SubFamiliaBusiness objMarcaBusiness = new SIGA.Business.Logistica.SubFamiliaBusiness();
            //List<SIGA.Entities.Logistica.SubFamilia>  Lista =  new List<SIGA.Entities.Logistica.SubFamilia>();
            //Lista.Add(new SIGA.Entities.Logistica.SubFamilia { CodFamilia = 0, DesSubFamilia = "Seleccione" });


            //var resutlMarca = objMarcaBusiness.Listar(CodigoFamilia);

            //foreach (var item in resutlMarca)
            //{
            //    Lista.Add(item);
            //}
            //cboSubFamilia.DataSource = Lista;
            //cboSubFamilia.DisplayMember = "DesFamilia";
            //cboSubFamilia.ValueMember = "CodSubFamilia";
        }

        //private void CargaForma()
        //{
        //    SIGA.Business.Logistica.FormaBusiness objMarcaBusiness = new SIGA.Business.Logistica.FormaBusiness();

        //    List<SIGA.Entities.Logistica.Forma> Lista = new List<SIGA.Entities.Logistica.Forma>();
        //    Lista.Add(new SIGA.Entities.Logistica.Forma { CodForma = 0, DesForma = "Seleccione" });


        //    var resutlMarca = objMarcaBusiness.Listar();

        //    foreach (var item in resutlMarca)
        //    {
        //        Lista.Add(item);
        //    }

        //    cboForma.DataSource = Lista;
        //    cboForma.DisplayMember = "DesForma";
        //    cboForma.ValueMember = "CodForma";

        //}

        private void button1_Click(object sender, EventArgs e)
        {

            Buscar();
        }

        private void Buscar()
        {
            string Descripcion = this.txtDescripcion.Text + "%";
            string str1 = this.txtCodigoBarra.Text + "%";
            string str2 = this.txtCodigoGeneral.Text + "%";

            this.dataGridView1.DataSource = (object)new GeneralBusiness().ConsultarMantenimiento(Convert.ToInt32(this.cboSeccion.SelectedValue), Convert.ToInt16(this.cboEmpresa.SelectedValue), Convert.ToInt16(this.cboMarca.SelectedValue), Convert.ToInt16(this.cboMaterial.SelectedValue), Convert.ToInt16(this.cboFamilia.SelectedValue), Convert.ToInt16(this.cboSubFamilia.SelectedValue), Convert.ToInt16(this.cboColor.SelectedValue), Convert.ToInt16(this.cboCapacidad.SelectedValue), Convert.ToInt16(this.cboForma.SelectedValue), Convert.ToInt16(this.cboUnidadMedida.SelectedValue), Convert.ToInt16(this.cboEmpaque.SelectedValue), Descripcion, Convert.ToString(this.cboEstado.SelectedValue), Convert.ToInt16(this.cboClasificacion.SelectedValue), "%" + this.txtCodigoGeneral.Text + "%", "");
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Width = 80;
            this.dataGridView1.Columns[2].Width = 180;
            this.dataGridView1.Columns[3].Width = 200;
            this.dataGridView1.Columns[4].Width = 120;
            this.dataGridView1.Columns[5].Width = 80;
        }
    }
}
