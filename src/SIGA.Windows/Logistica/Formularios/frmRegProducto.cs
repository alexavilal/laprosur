using SIGA.Business.Logistica;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SIGA.Windows.Logistica.Formularios
{
    public partial class frmRegProducto : Form
    {
        string strDestino = string.Empty;

        public int CodigoGeneral = 0;
        public frmRegProducto()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(173, 216, 230);
        }

        private void frmRegProducto_Load(object sender, EventArgs e)
        {
            this.CargaSeccion();
            this.CargaMarca();
            this.CargaMaterial();
            this.CargaFamilia();
            this.CargaColor();
            this.CargaCapacidad();
            this.CargaForma();
            this.CargaEmpaque();
            this.CargaEmpresa();
            //this.CargaTipo();
            this.CargaUnidadMedida();
            this.CargarEstado();
            this.CargaClasificacion();
            if (this.CodigoGeneral == 0)
            {
                this.txtFechaCreacion.Text = DateTime.Now.ToShortDateString();
                this.cboEstado.Enabled = false;
                this.cboEstado.SelectedValue = (object)"A";
                this.txtUsuario.Text = UsuarioLogeo.UsuarioSession;
            }
            else
            {
                this.CargarDatos(this.CodigoGeneral);
                this.cboEstado.Enabled = true;
                this.cboEmpresa.Enabled = true;
                this.cboMarca.Enabled = false;
            }
            this.BotonesHabilitar(false, true, false, true);


        }


        #region "Carga Combos"







        //private void CargaTipo()
        //{
        //    TipoArchivoBusiness objMarcaBusiness = new TipoArchivoBusiness();
        //    List<TipoArchivo> objEntMarca = new List<TipoArchivo>();

        //    objEntMarca = objMarcaBusiness.Listar();

        //    //objEntMarca.Add(new Marca() { CodMarca = 0, DesMarca = "--SELECCIONE--" });

        //    cboTipo.DataSource = objEntMarca;
        //    cboTipo.DisplayMember = "DescripcionTipo";
        //    cboTipo.ValueMember = "CodigoTipo";
        //    cboTipo.SelectedValue = 0;

        //}

        //private string ObtenerCorreosEnvio()
        //{
        //    StringBuilder correos = new StringBuilder();
        //    SIGA.Business.Seguridad.OpcionBusiness objOpcion = new SIGA.Business.Seguridad.OpcionBusiness();
        //    var result = objOpcion.OpcionPorUsuario(9);


        //    Int16 Ingresados = 0;

        //    DataRow[] resultTable = result.Select();


        //    foreach (DataRow row in resultTable)
        //    {
        //        if (Ingresados > 0)
        //        {
        //            correos.Append(",");
        //        }

        //        correos.Append(row[1]);

        //        Ingresados = 1;

        //    }

        //    return correos.ToString();
        //}



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

        #endregion

        # region "Operaciones"

        private void RegistrarGeneral()
        {
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            //string strPara = this.ObtenerCorreosEnvio();
            StringBuilder stringBuilder1 = new StringBuilder();
            //EnvioCorreo envioCorreo = new EnvioCorreo();
            SIGA.Business.Logistica.GeneralBusiness generalBusiness = new SIGA.Business.Logistica.GeneralBusiness();
            General request = new General();
            try
            {
                request.CodTipoCodigo = Convert.ToInt16(this.optNormal.Checked ? 1 : 2);
                request.IndCodigoBarra = Convert.ToBoolean(this.optConCodigo.Checked ? 1 : 0);
                request.CodBarra = this.txtCodigoBarra.Text == string.Empty ? (string)null : this.txtCodigoBarra.Text;
                request.CodMarca = Convert.ToInt16(this.cboMarca.SelectedValue);
                //request.CodMaterial = Convert.ToInt16(this.cboMaterial.SelectedValue);
                request.CodFamilia = Convert.ToInt32(this.cboFamilia.SelectedValue);
                request.CodSubFamilia = Convert.ToInt32(this.cboSubFamilia.SelectedValue);
                request.CodExtGeneral = this.txtCodigoProducto.Text;
                request.DesLarGeneral = this.txtDescripcionLarga.Text;
                request.DesCorGeneral = this.txtDescripcionLarga.Text;
                request.CodColor = Convert.ToInt16(this.cboColor.SelectedValue);
                request.CodCapacidad = Convert.ToInt16(this.cboCapacidad.SelectedValue);
                //request.CodForma = Convert.ToInt16(this.cboForma.SelectedValue);
                request.AltoGeneral = this.txtAlto.Text == string.Empty ? (string)null : this.txtAlto.Text;
                request.AnchoGeneral = this.txtAncho.Text == string.Empty ? (string)null : this.txtAncho.Text;
                request.LargoGeneral = this.txtLargo.Text == string.Empty ? (string)null : this.txtLargo.Text;
                request.Codigo1 = this.txtCodigo1.Text;
                request.Codigo2 = this.txtCodigo2.Text;
                request.Codigo3 = this.txtCodigo3.Text;
                request.Codigo4 = this.txtCodigo4.Text;
                request.Codigo5 = this.txtCodigo5.Text;
                request.Codigo6 = this.txtCodigo6.Text;
                request.Codigo7 = this.txtCodigo7.Text;
                request.Codigo8 = this.txtCodigo8.Text;
                request.Codigo9 = this.txtCodigo9.Text;
                request.Codigo10 = this.txtCodigo10.Text;
                request.CodigoZurece = this.txtCodigoAnterior.Text;
                request.Cicuferenciageneral = this.txtCircuferencia.Text == string.Empty ? (string)null : this.txtCircuferencia.Text;
                //request.Empaque = Convert.ToDecimal(this.txtEmpaque.Text.Length == 0 ? new Decimal(0) : Convert.ToDecimal(this.txtEmpaque.Text));
                request.CodUnidadMedida = Convert.ToInt16(this.cboUnidadMedida.SelectedValue);
                //request.CodEmpaque = Convert.ToInt16(this.cboEmpaque.SelectedValue);
                //request.CodEmpresa = Convert.ToInt16(this.cboEmpresa.Text == "IMPORTADORA Y DISTRIBUIDORA ZURECE S.A.C" ? 1 : 2);
                //request.AltoEmpaque = this.txtAltoEmpaque.Text == string.Empty ? (string)null : this.txtAltoEmpaque.Text;
                //request.AnchoEmpaque = this.txtAnchoEmpaque.Text == string.Empty ? (string)null : this.txtAnchoEmpaque.Text;
                //request.LargoEmpaque = this.txtLargoEmpaque.Text == string.Empty ? (string)null : this.txtLargoEmpaque.Text;
                //request.StockMinimo = Convert.ToDecimal(this.txtStockMinimo.Text);
                //request.LeadTime = Convert.ToDecimal(this.txtLeadTime.Text);
                //request.Reposicion = Convert.ToDecimal(this.txtReposicion.Text);

                request.CodEmpresa = 2;
                request.Temporal = Convert.ToInt16(this.optNormal.Checked ? 1 : 2);
                request.EstCodigo = this.cboEstado.SelectedValue.ToString();
                request.CodGeneralClasificacion = Convert.ToInt16(this.cboClasificacion.SelectedValue);
                request.UsuCreCodigo = (int)UsuarioLogeo.Codigo;
                request.CodSeccion = Convert.ToInt32(this.cboSeccion.SelectedValue);
                request.FlagVenta = Convert.ToBoolean(this.chkVenta.Checked ? 1 : 0);
                this.CodigoGeneral = generalBusiness.Registrar(request, ref empty1);


                if (this.CodigoGeneral > 0)
                {
                    int num = (int)MessageBox.Show("Se creo correctamente el producto..!", "SIGA");
                    this.lblCodigoGeneral.Text = this.CodigoGeneral.ToString();
                    this.txtCodigoExterno.Text = empty1;
                    this.BotonesHabilitar(true, false, false, true);
                    this.groupBox1.Enabled = false;
                    this.XT.Enabled = false;
                    //DataTable dataTable = new SIGA.Business.Logistica.GeneralBusiness().ConsultaGeneral(this.CodigoGeneral);
                    //if (dataTable.Rows.Count <= 0)
                    //    return;
                    //stringBuilder1.Clear();
                    //stringBuilder1.Append("Estimado sr(a) le informamos que se ha registrado un articulo nuevo en el sistema ");
                    //stringBuilder1.AppendLine();
                    //stringBuilder1.Append("Codigo: ");
                    //stringBuilder1.Append(dataTable.Rows[0][9]);
                    //stringBuilder1.AppendLine();
                    //stringBuilder1.Append("Descripcion: ");
                    //stringBuilder1.Append(dataTable.Rows[0][10]);
                    //stringBuilder1.AppendLine();
                    //stringBuilder1.Append("Marca: ");
                    //stringBuilder1.Append(dataTable.Rows[0][46]);
                    //stringBuilder1.AppendLine();
                    //stringBuilder1.Append("Empresa: ");
                    //stringBuilder1.Append(dataTable.Rows[0][45]);
                    //stringBuilder1.AppendLine();
                    //stringBuilder1.AppendLine();
                    //stringBuilder1.Append(" El dia:");
                    //StringBuilder stringBuilder2 = stringBuilder1;
                    //DateTime dateTime = DateTime.Now;
                    //dateTime = dateTime.Date;
                    //string shortDateString = dateTime.ToShortDateString();
                    //stringBuilder2.Append(shortDateString);
                    //stringBuilder1.AppendLine();
                    //stringBuilder1.Append("Agradeceremos tomar las previsiones del caso para la configuracion de su precio de venta");
                    //stringBuilder1.AppendLine();
                    //stringBuilder1.Append("Att - SIGA-Logistica");
                    ////envioCorreo.sbEnviar(strPara, "SIGA-CREACION DE PRODUCTO", stringBuilder1.ToString(), (string)null, (string)null);
                }
                else
                {
                    int num1 = (int)MessageBox.Show("No se puedo generar el producto..!", "SIGA");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargaSeccion()
        {
            //SeccionBusiness seccionBusiness = new SeccionBusiness();
            //List<Seccion> seccionList = new List<Seccion>();
            //seccionList.Add(new Seccion()
            //{
            //    CodigoSeccion = 0,
            //    DescripcionSeccion = "--Seleccione"
            //});
            //foreach (Seccion seccion in seccionBusiness.ListarSeccion())
            //    seccionList.Add(seccion);
            //this.cboSeccion.DataSource = (object)seccionList;
            //this.cboSeccion.DisplayMember = "DescripcionSeccion";
            //this.cboSeccion.ValueMember = "CodigoSeccion";
            //this.cboSeccion.SelectedValue = (object)0;
        }

        private void ActualizarGeneral()
        {
            string empty = string.Empty;
            SIGA.Business.Logistica.GeneralBusiness generalBusiness = new SIGA.Business.Logistica.GeneralBusiness();
            General request = new General();
            try
            {
                request.CodGeneral = this.CodigoGeneral;
                request.CodEmpaque = Convert.ToInt16(this.cboEmpresa.SelectedValue);
                request.CodTipoCodigo = Convert.ToInt16(this.optNormal.Checked ? 1 : 2);
                request.IndCodigoBarra = Convert.ToBoolean(this.optConCodigo.Checked ? 1 : 0);
                request.CodBarra = this.txtCodigoBarra.Text == string.Empty ? (string)null : this.txtCodigoBarra.Text;
                request.CodMarca = Convert.ToInt16(this.cboMarca.SelectedValue);
                //request.CodMaterial = Convert.ToInt16(this.cboMaterial.SelectedValue);
                request.CodFamilia = Convert.ToInt32(this.cboFamilia.SelectedValue);
                request.CodSubFamilia = Convert.ToInt32(this.cboSubFamilia.SelectedValue);
                request.CodExtGeneral = this.txtCodigoProducto.Text;
                request.DesLarGeneral = this.txtDescripcionLarga.Text;
                request.DesCorGeneral = this.txtDescripcionCorta.Text;
                request.CodColor = Convert.ToInt16(this.cboColor.SelectedValue);
                request.CodCapacidad = Convert.ToInt16(this.cboCapacidad.SelectedValue);
                //request.CodForma = Convert.ToInt16(this.cboForma.SelectedValue);
                request.AltoGeneral = this.txtAlto.Text == string.Empty ? (string)null : this.txtAlto.Text;
                request.AnchoGeneral = this.txtAncho.Text == string.Empty ? (string)null : this.txtAncho.Text;
                request.LargoGeneral = this.txtLargo.Text == string.Empty ? (string)null : this.txtLargo.Text;
                request.Codigo1 = this.txtCodigo1.Text;
                request.Codigo2 = this.txtCodigo2.Text;
                request.Codigo3 = this.txtCodigo3.Text;
                request.Codigo4 = this.txtCodigo4.Text;
                request.Codigo5 = this.txtCodigo5.Text;
                request.Codigo6 = this.txtCodigo6.Text;
                request.Codigo7 = this.txtCodigo7.Text;
                request.Codigo8 = this.txtCodigo8.Text;
                request.Codigo9 = this.txtCodigo9.Text;
                request.Codigo10 = this.txtCodigo10.Text;
                request.CodigoZurece = this.txtCodigoAnterior.Text;
                request.Cicuferenciageneral = this.txtCircuferencia.Text == string.Empty ? (string)null : this.txtCircuferencia.Text;
                //request.Empaque = Convert.ToDecimal(this.txtEmpaque.Text.Length == 0 ? new Decimal(0) : Convert.ToDecimal(this.txtEmpaque.Text));
                request.CodUnidadMedida = Convert.ToInt16(this.cboUnidadMedida.SelectedValue);
                //request.CodEmpaque = Convert.ToInt16(this.cboEmpaque.SelectedValue);
                request.CodEmpresa = Convert.ToInt16(this.cboEmpresa.Text == "IMPORTADORA Y DISTRIBUIDORA ZURECE S.A.C" ? 1 : 2);
                //request.AltoEmpaque = this.txtAltoEmpaque.Text == string.Empty ? (string)null : this.txtAltoEmpaque.Text;
                //request.AnchoEmpaque = this.txtAnchoEmpaque.Text == string.Empty ? (string)null : this.txtAnchoEmpaque.Text;
                //request.LargoEmpaque = this.txtLargoEmpaque.Text == string.Empty ? (string)null : this.txtLargoEmpaque.Text;
                //request.StockMinimo = Convert.ToDecimal(this.txtStockMinimo.Text);
                //request.LeadTime = Convert.ToDecimal(this.txtLeadTime.Text);
                //request.Reposicion = Convert.ToDecimal(this.txtReposicion.Text);
                request.Temporal = Convert.ToInt16(this.optNormal.Checked ? 1 : 2);
                request.CodGeneralClasificacion = Convert.ToInt16(this.cboClasificacion.SelectedValue);
                request.EstCodigo = this.cboEstado.SelectedValue.ToString();
                request.UsuCreCodigo = (int)UsuarioLogeo.Codigo;
                request.CodSeccion = Convert.ToInt32(this.cboSeccion.SelectedValue);
                request.FlagVenta = Convert.ToBoolean(this.chkVenta.Checked ? 1 : 0);
                this.CodigoGeneral = generalBusiness.Actualizar(request);
                if (this.CodigoGeneral >= 0)
                {
                    int num = (int)MessageBox.Show("Se Actualizo correctamente el producto..!", "SIGA");
                    this.lblCodigoGeneral.Text = this.CodigoGeneral.ToString();
                    this.txtCodigoExterno.Text = empty;
                    this.BotonesHabilitar(true, false, false, true);
                    this.groupBox1.Enabled = false;
                    this.XT.Enabled = false;
                    this.Close();
                }
                else
                {
                    int num1 = (int)MessageBox.Show("No se puedo generar el producto..!", "SIGA");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region "Carga Combos Dos"

        private void CargaForma()
        {
            //SIGA.Business.Logistica.FormaBusiness objMarcaBusiness = new SIGA.Business.Logistica.FormaBusiness();

            //List<SIGA.Entities.Logistica.Forma> Lista = new List<SIGA.Entities.Logistica.Forma>();
            //Lista.Add(new SIGA.Entities.Logistica.Forma { CodForma = 0, DesForma = "Seleccione" });


            //var resutlMarca = objMarcaBusiness.Listar();

            //foreach (var item in resutlMarca)
            //{
            //    Lista.Add(item);
            //}

            //cboForma.DataSource = Lista;
            //cboForma.DisplayMember = "DesForma";
            //cboForma.ValueMember = "CodForma";

        }




        private void CargaMarca()
        {
            //SIGA.Business.Logistica.MarcaBusiness objMarcaBusiness = new SIGA.Business.Logistica.MarcaBusiness();
            //List<SIGA.Entities.Logistica.Marca> Lista = new List<SIGA.Entities.Logistica.Marca>();
            //Lista.Add(new SIGA.Entities.Logistica.Marca { CodMarca = 0, DesMarca = "Seleccione" });

            //var consulta = objMarcaBusiness.Listar("");

            //foreach (var item in consulta)
            //{
            //    Lista.Add(item);
            //}

            //cboMarca.DataSource = Lista;
            //cboMarca.DisplayMember = "DesMarca";
            //cboMarca.ValueMember = "CodMarca";
        }

        private void CargaClasificacion()
        {
            //SIGA.Business.Logistica.ClasificacionBusiness objMarcaBusiness = new SIGA.Business.Logistica.ClasificacionBusiness();
            //var Lista = objMarcaBusiness.ConsultarClasificacion();

            //DataRow dr = Lista.NewRow();
            //dr["CodGeneralClasificacion"] = 0;
            //dr["DesGeneralClasificacion"] = "Seleccion";

            //Lista.Rows.InsertAt(dr, 0);

            //cboClasificacion.DataSource = Lista;
            //cboClasificacion.DisplayMember = "DesGeneralClasificacion";
            //cboClasificacion.ValueMember = "CodGeneralClasificacion";
            //cboClasificacion.SelectedValue = 3;


        }
        private void CargaEmpresa()
        {
            //SIGA.Business.Logistica.EmpresaBusiness objMarcaBusiness = new SIGA.Business.Logistica.EmpresaBusiness();
            //List<SIGA.Entities.Logistica.Empresa> Lista = new List<SIGA.Entities.Logistica.Empresa>();
            //Lista.Add(new SIGA.Entities.Logistica.Empresa { CodEmpresa = 0, DesEmpresa = "Seleccione" });

            //var resutlMarca = objMarcaBusiness.Listar();

            //foreach (var item in resutlMarca)
            //{
            //    Lista.Add(item);
            //}

            //cboEmpresa.DataSource = Lista;
            //cboEmpresa.DisplayMember = "DesEmpresa";
            //cboEmpresa.ValueMember = "CodEmpresa";



        }





        private void CargaColor()
        {
            //SIGA.Business.Logistica.ColorBusiness objMarcaBusiness = new SIGA.Business.Logistica.ColorBusiness();
            //List<SIGA.Entities.Logistica.Color> Lista = new List<SIGA.Entities.Logistica.Color>();
            //Lista.Add(new SIGA.Entities.Logistica.Color { CodColor = 0, DesColor = "Seleccione" });


            //var resutlMarca = objMarcaBusiness.Listar();

            //foreach (var item in resutlMarca)
            //{
            //    Lista.Add(item);
            //}

            //cboColor.DataSource = Lista;
            //cboColor.DisplayMember = "DesColor";
            //cboColor.ValueMember = "CodColor";

        }




        private void CargaMaterial()
        {
            //SIGA.Business.Logistica.MaterialBusiness objMarcaBusiness = new SIGA.Business.Logistica.MaterialBusiness();
            //List<SIGA.Entities.Logistica.Material> Lista = new List<Entities.Logistica.Material>();
            //Lista.Add(new SIGA.Entities.Logistica.Material { CodMaterial = 0, DesMaterial = "Seleccione" });


            //var resutlMarca = objMarcaBusiness.Listar(0, "", "A");

            //foreach (var item in resutlMarca)
            //{
            //    Lista.Add(item);
            //}

            //cboMaterial.DataSource = Lista;
            //cboMaterial.DisplayMember = "DesMaterial";
            //cboMaterial.ValueMember = "CodMaterial";

        }


        private void CargaFamilia()
        {
            SIGA.Business.Logistica.FamiliaBusiness objMarcaBusiness = new SIGA.Business.Logistica.FamiliaBusiness();
            List<SIGA.Entities.Logistica.Familia> Lista = new List<SIGA.Entities.Logistica.Familia>();

            Lista.Add(new SIGA.Entities.Logistica.Familia { CodFamilia = 0, DesFamilia = "Seleccion" });

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



        private void CargaEmpaque()
        {
            //SIGA.Business.Logistica.EmpaqueBusiness objMarcaBusiness = new SIGA.Business.Logistica.EmpaqueBusiness();
            //List<SIGA.Entities.Logistica.Empaque> Lista = new List<Entities.Logistica.Empaque>();

            //Lista.Add(new SIGA.Entities.Logistica.Empaque { CodEmpaque = 0, DesEmpaque = "Seleccione" });


            //var resutlMarca = objMarcaBusiness.Listar();

            //foreach (var item in resutlMarca)
            //{
            //    Lista.Add(item);
            //}

            //cboEmpaque.DataSource = Lista;
            //cboEmpaque.DisplayMember = "DesEmpaque";
            //cboEmpaque.ValueMember = "CodEmpaque";

        }

        private void CargaCapacidad()
        {
            //SIGA.Business.Logistica.CapacidadBusiness objMarcaBusiness = new SIGA.Business.Logistica.CapacidadBusiness();
            //List<SIGA.Entities.Logistica.Capacidad> Lista = new List<SIGA.Entities.Logistica.Capacidad>();

            //Lista.Add(new SIGA.Entities.Logistica.Capacidad { CodCapacidad = 0, DesCapacidad = "Seleccione" });


            //var resutlMarca = objMarcaBusiness.Listar();


            //foreach (var item in resutlMarca)
            //{
            //    Lista.Add(item);
            //}
            //cboCapacidad.DataSource = Lista;
            //cboCapacidad.DisplayMember = "DesCapacidad";
            //cboCapacidad.ValueMember = "CodCapacidad";

        }









        #endregion

        private void CargaSubFamilia(Int16 CodigoFamilia)
        {
            //SIGA.Business.Logistica.SubFamiliaBusiness objMarcaBusiness = new SIGA.Business.Logistica.SubFamiliaBusiness();
            //List<SIGA.Entities.Logistica.SubFamilia> Lista = new List<SIGA.Entities.Logistica.SubFamilia>();
            //Lista.Add(new SIGA.Entities.Logistica.SubFamilia { CodFamilia = 0, DesSubFamilia = "Seleccione" });


            //var resutlMarca = objMarcaBusiness.Listar(CodigoFamilia);

            //foreach (var item in resutlMarca)
            //{
            //    Lista.Add(item);
            //}
            //cboSubFamilia.DataSource = null;
            //cboSubFamilia.DataSource = Lista;
            //cboSubFamilia.DisplayMember = "DesFamilia";
            //cboSubFamilia.ValueMember = "CodSubFamilia";
        }

        private void CargarDatos(int CodigoGeneral)
        {
            DataTable dataTable1 = new SIGA.Business.Logistica.GeneralBusiness().ConsultaGeneral(CodigoGeneral);
            if (dataTable1.Rows.Count <= 0)
                return;
            this.txtCodigo.Text = dataTable1.Rows[0]["CodGeneral"].ToString();
            this.txtCodigoEmpresaAnterior.Text = Convert.ToString(dataTable1.Rows[0]["CodEmpresa"]);
            int int32 = Convert.ToInt32(dataTable1.Rows[0]["CodEmpresa"]);
            this.cboEmpresa.SelectedValue = (object)Convert.ToInt16(dataTable1.Rows[0]["CodEmpresa"]);
            this.txtCodigoProducto.Text = Convert.ToString(dataTable1.Rows[0]["CodExtGeneral"]);
            //this.txtCodigo1.Text = Convert.ToString(dataTable1.Rows[0]["CodBarra1"]);
            //this.txtCodigo2.Text = Convert.ToString(dataTable1.Rows[0]["CodBarra2"]);
            //this.txtCodigo3.Text = Convert.ToString(dataTable1.Rows[0]["CodBarra3"]);
            //this.txtCodigo4.Text = Convert.ToString(dataTable1.Rows[0]["CodBarra4"]);
            //this.txtCodigo5.Text = Convert.ToString(dataTable1.Rows[0]["CodBarra5"]);
            //this.txtCodigo6.Text = Convert.ToString(dataTable1.Rows[0]["CodBarra6"]);
            //this.txtCodigo7.Text = Convert.ToString(dataTable1.Rows[0]["CodBarra7"]);
            //this.txtCodigo8.Text = Convert.ToString(dataTable1.Rows[0]["CodBarra8"]);
            //this.txtCodigo9.Text = Convert.ToString(dataTable1.Rows[0]["CodBarra9"]);
            //this.txtCodigo10.Text = Convert.ToString(dataTable1.Rows[0]["CodBarra10"]);
            this.cboFamilia.SelectedValue = (object)Convert.ToInt32(dataTable1.Rows[0]["CodFamilia"]);
            //this.CargaSubFamilia(Convert.ToInt16(dataTable1.Rows[0]["CodFamilia"]));
            //this.cboSubFamilia.SelectedValue = (object)Convert.ToInt16(dataTable1.Rows[0]["CodSubFamilia"]);
            //this.cboMaterial.SelectedValue = (object)Convert.ToInt16(dataTable1.Rows[0]["CodMaterial"]);
            //this.cboForma.SelectedValue = (object)Convert.ToInt16(dataTable1.Rows[0]["CodForma"]);
            //this.cboColor.SelectedValue = (object)Convert.ToInt16(dataTable1.Rows[0]["CodColor"]);
            //this.cboMarca.SelectedValue = (object)Convert.ToInt16(dataTable1.Rows[0]["CodMarca"]);
            //this.cboCapacidad.SelectedValue = (object)Convert.ToInt16(dataTable1.Rows[0]["CodCapacidad"]);
            this.txtDescripcionLarga.Text = dataTable1.Rows[0]["DesLarGeneral"].ToString();
            //this.txtDescripcionCorta.Text = dataTable1.Rows[0]["DesCorGeneral"].ToString();
            //this.txtCodigoAnterior.Text = dataTable1.Rows[0]["CodZurece"].ToString();
            //this.txtAlto.Text = dataTable1.Rows[0]["AltoGeneral"].ToString() == null ? string.Empty : dataTable1.Rows[0]["AltoGeneral"].ToString();
            //this.txtLargo.Text = dataTable1.Rows[0]["Largoeneral"].ToString() == null ? string.Empty : dataTable1.Rows[0]["Largoeneral"].ToString();
            //this.txtAncho.Text = dataTable1.Rows[0]["AnchoGeneral"].ToString() == null ? string.Empty : dataTable1.Rows[0]["AnchoGeneral"].ToString();
            //this.txtCircuferencia.Text = dataTable1.Rows[0]["CicuferenciaGeneral"].ToString();
            this.cboUnidadMedida.SelectedValue = (object)Convert.ToInt16(dataTable1.Rows[0]["CodUnidadMedidad"]);
            //this.cboEmpaque.SelectedValue = (object)Convert.ToInt16(dataTable1.Rows[0]["CodEmpaque"]);
            //this.txtEmpaque.Text = dataTable1.Rows[0]["EmpGeneral"].ToString();
            //this.txtStockMinimo.Text = dataTable1.Rows[0]["StockMininoGeneral"].ToString();
            //this.txtLeadTime.Text = dataTable1.Rows[0]["LeadTimeGeneral"].ToString();
            //this.txtReposicion.Text = dataTable1.Rows[0]["ReposicionGeneral"].ToString();
            ////this.txtUsuario.Text = dataTable1.Rows[0]["UsuLogin"].ToString();
            //this.txtFechaCreacion.Text = Convert.ToDateTime(dataTable1.Rows[0]["FecCre"]).ToShortDateString();
            this.cboEstado.SelectedValue = (object)dataTable1.Rows[0]["EstCodigo"].ToString();
            //this.cboClasificacion.SelectedValue = (object)Convert.ToInt16(dataTable1.Rows[0]["CodGeneralClasificacion"]);
            //this.cboSeccion.SelectedValue = (object)Convert.ToInt32(dataTable1.Rows[0]["CodigoSeccion"]);
            //GeneralArchivoBusiness generalArchivoBusiness = new GeneralArchivoBusiness();
            //DataTable dataTable2 = generalArchivoBusiness.ConsultarArchivoTecnico(int32);
            //DataTable dataTable3 = generalArchivoBusiness.Consultar(CodigoGeneral, (short)1);
            //if (dataTable2.Rows.Count <= 0)

            //    if (dataTable3.Rows.Count > 0)
            //    {
            //        this.dgvImagenes.DataSource = (object)dataTable3;
            //        this.dgvImagenes.Columns[0].Visible = false;
            //        this.dgvImagenes.Columns[1].HeaderText = "Tipo";
            //        this.dgvImagenes.Columns[1].Width = 150;
            //        this.dgvImagenes.Columns[2].HeaderText = "Ruta";
            //        this.dgvImagenes.Columns[2].Width = 350;
            //        this.dgvImagenes.Columns[3].Visible = false;
            //    }
            chkVenta.Checked = Convert.ToBoolean(dataTable1.Rows[0]["FlagVenta"]);
        }

        # region"Eventos"



        private void btnCargarDocumento_Click(object sender, EventArgs e)
        {
            CargaDocumento("1");
        }

        #endregion


        # region "FuncionesProcedimientos"


        public void CargaDocumento(string Tipo)
        {


            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    if (Tipo == "1")  //Normal
                    {
                        //txtFicha.Text = openFileDialog1.FileName.ToString();
                    }
                    else
                    {
                        //txtFoto.Text = openFileDialog1.FileName.ToString();
                    }
                    // if ((myStream = openFileDialog1.OpenFile()) != null)
                    //{
                    //using (myStream)
                    //{
                    //    // Insert code to read the stream here.

                    //    string strRuta;
                    //    string strDestino;


                    //    strRuta = openFileDialog1.FileName.ToString();

                    //    strDestino = @"C:\Trabajo\" + System.IO.Path.GetFileName(strRuta);

                    //    File.Copy(openFileDialog1.FileName,strDestino);

                    //}
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
        }



        #endregion

        //private void btnAgregarFicha_Click(object sender, EventArgs e)
        //{
        //    CopiaArchivo(txtFicha.Text,"1", Convert.ToInt32(lblCodigoGeneral.Text));

        //}


        private void CopiaArchivo(string Ruta, string Tipo, int CodigoGeneral)
        {



            //GeneralArchivoBusiness objArchivoGeneral = new GeneralArchivoBusiness();
            //GeneralArchivo objGeneralArchivo = new GeneralArchivo();
            //int Codigo = 0;


            //strDestino = @"C:\Trabajo\" + System.IO.Path.GetFileName(Ruta);

            //if (File.Exists(strDestino) == true)
            //{
            //    File.Delete(strDestino);
            //}

            //File.Copy(Ruta, strDestino);

            //try
            //{

            //    Int16 CodigoTipo = 0;


            //    switch (cboTipo.Text)
            //    {
            //        case "Imagen Principal": CodigoTipo = 5; break;
            //        case "Imagenes Secundarias": CodigoTipo = 6; break;
            //        case "Ficha Tecnica": CodigoTipo = 4; break;
            //    }



            //    objGeneralArchivo.CodGeneral = CodigoGeneral;
            //    objGeneralArchivo.CodTipoArchivo = Convert.ToInt16(CodigoTipo);
            //    objGeneralArchivo.RutaArchivoGeneral = strDestino;


            //    Codigo = objArchivoGeneral.Registrar(objGeneralArchivo);

            //    if (Codigo > 0)
            //    {


            //    }


            //}

            //catch (Exception Ex)
            //{

            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargaDocumento("2");
        }

        private void btnAgregarFoto_Click(object sender, EventArgs e)
        {

            //if (txtFoto.Text == string.Empty || cboTipo.Text == string.Empty)
            //{
            //    MessageBox.Show("Debe ingresa los datos...");
            //    return;
            //}

            //CopiaArchivo(txtFoto.Text, "2", Convert.ToInt32(lblCodigoGeneral.Text));
            //ConsultarFotos();

            //txtFoto.Text = string.Empty;
            //cboTipo.Text = string.Empty;

        }

        private void lblVer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start(lblVer.Text);
        }

        private void cboFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                CargaSubFamilia(Convert.ToInt16(cboFamilia.SelectedValue));
                //txtDescripcionLarga.Text = DevuelveNombre(cboFamilia.Text, cboSubFamilia.Text, cboCapacidad.Text, cboForma.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToInt16(cboFamilia.SelectedValue) == 0 ||

               Convert.ToInt16(cboUnidadMedida.SelectedValue) == 0 ||
               txtDescripcionLarga.Text == string.Empty || cboEstado.SelectedValue.ToString() == string.Empty)
                {
                    MessageBox.Show("Debe ingresar los datos adecuadamente...!", "SIGA");
                    return;

                }

                if (CodigoGeneral == 0)
                {
                    RegistrarGeneral();
                }
                else
                {

                    ActualizarGeneral();

                    //if (Convert.ToInt32(txtCodigoEmpresaAnterior.Text) != Convert.ToInt32(cboEmpresa.SelectedValue))
                    //{
                    //    SIGA.Business.Ventas.GeneralBusiness objGeneral = new SIGA.Business.Ventas.GeneralBusiness();
                    //    var result = objGeneral.BuscarPorCodigoArticuloDos(txtCodigoExterno.Text);

                    //    if (result != null)
                    //    {
                    //        if (result.stock.Equals(0))
                    //        {
                    //            ActualizarGeneral();
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("No se puede cambiar de empresa al articulo si el stock es mayor de cero....!");
                    //        }
                    //    }

                    //}
                    //else
                    //{
                    //    ActualizarGeneral();
                    //}


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un erro consultar con el administrador del sistema " + ex.Message, "SIGA");
            }

        }

        private void optConCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigoBarra.Enabled = optConCodigo.Checked;
            txtCodigoBarra.Focus();

        }

        private void optSinCodigoBarra_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigoBarra.Enabled = false;
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string GenerarCodigo()
        {

            GeneralBusiness objGeneralBusiness = new GeneralBusiness();
            General objEntGeneral = new General();
            string Codigo = string.Empty;

            try
            {
                objEntGeneral.CodMarca = Convert.ToInt16(cboMarca.SelectedValue);
                //objEntGeneral.CodMaterial = Convert.ToInt16(cboMaterial.SelectedValue);
                objEntGeneral.CodTipoCodigo = Convert.ToInt16(optNormal.Checked == true ? 1 : 2);
                Codigo = objGeneralBusiness.Codigo(objEntGeneral);

            }

            catch (Exception ex)
            {


            }

            return Codigo;

        }

        private void optNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (optNormal.Checked == true)
            {

            }
        }

        private void optTemporal_CheckedChanged(object sender, EventArgs e)
        {
            if (optTemporal.Checked == true)
            {



            }
        }

        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtCodigo.Text = GenerarCodigo();
        }

        private void optSinCodigoBarra_CheckedChanged_1(object sender, EventArgs e)
        {
            txtCodigoBarra.Enabled = false;
            txtCodigo1.Enabled = false;
            txtCodigo2.Enabled = false;

            txtCodigo3.Enabled = false;
            txtCodigo4.Enabled = false;
            txtCodigo5.Enabled = false;

            txtCodigo6.Enabled = false;
            txtCodigo7.Enabled = false;

            txtCodigo8.Enabled = false;
            txtCodigo9.Enabled = false;
            txtCodigo10.Enabled = false;



        }

        private void optConCodigo_CheckedChanged_1(object sender, EventArgs e)
        {
            txtCodigoBarra.Enabled = true;
            txtCodigo1.Enabled = true;
            txtCodigo2.Enabled = true;
            txtCodigo3.Enabled = true;
            txtCodigo4.Enabled = true;
            txtCodigo5.Enabled = true;
            txtCodigo6.Enabled = true;
            txtCodigo7.Enabled = true;
            txtCodigo8.Enabled = true;
            txtCodigo9.Enabled = true;
            txtCodigo10.Enabled = true;

        }

        private void ConsultarFotos()
        {
            //GeneralArchivoBusiness objGeneralArchivoBusiness = new GeneralArchivoBusiness();

            //var result = objGeneralArchivoBusiness.Consultar(Convert.ToInt32(lblCodigoGeneral.Text), Convert.ToInt16(2));

            //dgvImagenes.DataSource = result;

            //dgvImagenes.Columns[0].Visible = false;

            //dgvImagenes.Columns[1].HeaderText = "Tipo";
            //dgvImagenes.Columns[1].Width = 150;


            //dgvImagenes.Columns[2].HeaderText = "Ruta";
            //dgvImagenes.Columns[2].Width = 350;

            //dgvImagenes.Columns[3].Visible = false;



        }



        private void BotonesHabilitar(bool Nuevo, bool Guardar, bool Imprimir, bool Salir)
        {
            btnNuevo.Enabled = Nuevo;
            btnRegistrar.Enabled = Guardar;
            btnImprimir.Enabled = Imprimir;
            btnSalir.Enabled = Salir;

        }

        private void cboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cboEmpresa.SelectedValue = 2;
            //txtCodigoExterno.Text = string.Empty;
            //BotonesHabilitar(false, true, false, true);
            //groupBox1.Enabled = true;
            //XT.Enabled = true;
            //cboMarca.SelectedIndex = -1;
            //cboMaterial.SelectedIndex = -1;
            //cboFamilia.SelectedIndex = -1;
            //cboSubFamilia.SelectedIndex = -1;
            //cboColor.SelectedIndex = -1;
            //cboEmpaque.SelectedIndex = -1;
            //cboEmpresa.SelectedIndex = -1;
            //cboCapacidad.SelectedIndex = -1;
            //cboTipo.SelectedIndex = -1;
            //cboUnidadMedida.SelectedIndex = -1;
            //optNormal.Checked = true;
            //optConCodigo.Checked = true;
            //txtAlto.Text = string.Empty;
            //txtAltoEmpaque.Text = string.Empty;
            //txtDescripcionCorta.Text = string.Empty;
            //txtDescripcionLarga.Text = string.Empty;
            //txtCircuferencia.Text = string.Empty;
            //txtAnchoEmpaque.Text = string.Empty;
            //txtStockMinimo.Text = Convert.ToString(0);
            //txtLeadTime.Text = Convert.ToString(0);
            //txtReposicion.Text = Convert.ToString(0);
            //txtCodigo1.Text = string.Empty;
            //txtCodigo2.Text = string.Empty;
            //txtCodigo3.Text = string.Empty;
            //txtCodigo4.Text = string.Empty;
            //txtCodigo5.Text = string.Empty;
            //txtCodigo6.Text = string.Empty;
            //txtCodigo7.Text = string.Empty;
            //txtCodigo8.Text = string.Empty;
            //txtCodigo9.Text = string.Empty;
            //txtCodigoAnterior.Text = string.Empty;



        }

        public string DevuelveNombre(string Familia, string SubFamilia, string Capacidad, string Forma)
        {
            StringBuilder strNombre = new StringBuilder();


            // strNombre.Append(Familia + string.Empty);
            strNombre.Append(SubFamilia);
            strNombre.Append("");

            if (Capacidad != "No Definido" && Capacidad != "Seleccione")
            {
                strNombre.Append(Capacidad);
                strNombre.Append("");

            }


            if (Forma != "No Definido" && Forma != "Seleccione")
            {
                strNombre.Append("");
                strNombre.Append(Forma);
            }



            return strNombre.ToString();
        }

        private void cboSubFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //txtDescripcionLarga.Text = DevuelveNombre(cboFamilia.Text, cboSubFamilia.Text, cboCapacidad.Text, cboForma.Text);
            }
            catch (Exception ex)
            {

            }

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            //if (txtFicha.Text != string.Empty)
            //{

            //    System.Diagnostics.Process.Start(strDestino);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (dgvImagenes.RowCount > 0)
            //{
            //    SIGA.Business.Logistica.GeneralArchivoBusiness obj = new SIGA.Business.Logistica.GeneralArchivoBusiness();

            //    int Codigo = Convert.ToInt32(dgvImagenes[0, dgvImagenes.CurrentRow.Index].Value);

            //    obj.Eliminar(Codigo);

            //    ConsultarFotos();


            //}
            //else
            //{
            //    MessageBox.Show("No hay items para eliminar...!");
            //}



        }

        private void dgvImagenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dgvImagenes_CellDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            string strRuta = string.Empty;

            //strRuta = dgvImagenes[2, dgvImagenes.CurrentRow.Index].Value.ToString();


            System.Diagnostics.Process.Start(strRuta);
            //int Codigo = 0;

            //Codigo = Convert.ToInt32(dgvItems[0, dgvItems.CurrentRow.Index].Value);

            //if (Codigo > 0)
            //{
            //    frmDetalleDistribucion form = new frmDetalleDistribucion();
            //    form.CodigoSede = Convert.ToInt16(cboSede.SelectedValue);
            //    form.DetalleDistribucionOperacion = DetalleDistribucion;
            //    form.Stock = Convert.ToDecimal(dgvItems[7, dgvItems.CurrentRow.Index].Value);
            //    form.Codigo = Codigo;
            //    //form.CargarStock(Codigo);
            //    form.ShowDialog();
            //    DetalleDistribucion = form.DetalleDistribucionOperacion;

            //}
        }

        private void cboForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                //txtDescripcionLarga.Text = DevuelveNombre(cboFamilia.Text, cboSubFamilia.Text, cboCapacidad.Text, cboForma.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cboCapacidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                //txtDescripcionLarga.Text = DevuelveNombre(cboFamilia.Text, cboSubFamilia.Text, cboCapacidad.Text, cboForma.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
