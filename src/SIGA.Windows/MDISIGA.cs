using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SIGA.Windows.Administrador;
using SIGA.Windows.Logistica.Formularios;
using SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos;
using SIGA.Windows.Ventas.Formularios;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Runtime.InteropServices;


namespace SIGA.Windows
{

    public partial class MDISIGA : MaterialForm
    {
        private DataTable Opciones = new DataTable();
        private int childFormNumber = 0;

        public MDISIGA()
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

        private void ShowNewForm(object sender, EventArgs e)
        {

            //frmVentaMinorista objFrmVentaMinorista = new frmVentaMinorista();
            //objFrmVentaMinorista.MdiParent = this;
            //objFrmVentaMinorista.Text = "SIGA - Venta Minorista";
            //objFrmVentaMinorista.Show();
        }

        private void mantenimientoDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void sugeridoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generacionDeOCToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void materialToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void kardesToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void registroDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trasladoDeAlmacenesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registroDeDocumentosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //SIGA.Windows.Logistica.Formularios.Operaciones.frmRegistroDocumento objFrmRegProducto = new SIGA.Windows.Logistica.Formularios.Operaciones.frmRegistroDocumento();


        }

        private void preciosDeCostosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void MDISIGA_Load(object sender, EventArgs e)
        {


            frmLogin objFrmLogin = new frmLogin();
            objFrmLogin.ShowDialog();

            SIGA.Business.Seguridad.UsuarioBusiness objUsuario = new SIGA.Business.Seguridad.UsuarioBusiness();

            try
            {
                Opciones = objUsuario.ObtenerOpcionesPorUsuario(UsuarioLogeo.Codigo);
                Seguridad();
                toolStripStatusLabel.Text = "Bienvenido :" + UsuarioLogeo.Nombre.ToString();
            }
            catch (Exception ex)
            {

            }

        }

        private void Seguridad()
        {

            //Administrador

            mnuModulos.Visible = this.ValidarOpcion(1); //Modulo 
            mnuOpciones.Visible = this.ValidarOpcion(2);//Opciones
            mnuPerfil.Visible = this.ValidarOpcion(3);  //Perfil
            mnuEmpleados.Visible = this.ValidarOpcion(4);//Empleado

            //Ventas

            mnuPolitica.Visible = this.ValidarOpcion(5);  //Politicas de Precios
            zonaToolStripMenuItem.Visible = this.ValidarOpcion(5); // Zona
            mnuFamilia.Visible = this.ValidarOpcion(7); // Familia
            itemsToolStripMenuItem.Visible = this.ValidarOpcion(8); //Items
            configuraciónDePreciosToolStripMenuItem.Visible = this.ValidarOpcion(9); //Configuracion de Precios
            mnuClientes.Visible = this.ValidarOpcion(10); //Clientes
            generacionDeProformasToolStripMenuItem.Visible = this.ValidarOpcion(11); //Proformas
            gebToolStripMenuItem.Visible = this.ValidarOpcion(12); //Guia de Control Interno
            mnuVentasPorFecha.Visible = this.ValidarOpcion(13); //Reporte ventas por fecha
            //ventasPorProductoToolStripMenuItem.Visible = this.ValidarOpcion(14); //Reporte ventas por producto
            //ventasPorVendedorToolStripMenuItem.Visible = this.ValidarOpcion(15);  //Reporte ventas por vendedor
            //ventasPorDocumentosToolStripMenuItem.Visible = this.ValidarOpcion(16); //Reporte ventas por documento

        }
        private bool ValidarOpcion(int CodigoOpcion)
        {
            bool Visible = true;
            string Cadena = "CodOpcion =" + CodigoOpcion;

            DataRow[] result = Opciones.Select(Cadena);
            if (result.Length == 0)
            {
                Visible = false;
            }
            return Visible;
        }

        private void rangoDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void preciosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void administracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cajasToolStripMenuItem_Click(object sender, EventArgs e)
        {




        }

        private void ingresosEgresosDeDineroToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void reporteDiarioDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void cajasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void aperturaDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMantenimientoUsuario objFrmMantenimientoUsuario = new FrmMantenimientoUsuario();
            objFrmMantenimientoUsuario.MdiParent = this;
            objFrmMantenimientoUsuario.Show();
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void porCajeroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void cierreDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SIGA.Windows.Caja.frmCierreCaja objFormulario = new SIGA.Windows.Caja.frmCierreCaja();
        //    objFormulario.ModoAdministritivo = 1;
        //    objFormulario.ShowDialog();

        //}

        private void generacionDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {





        }



        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void numeroDeSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void opcionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {


        }

        private void tarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void subFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void almacenesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void operadoresTelefonicoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void empaquesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tarjetasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void unidadMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void capacidadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tipoDeCambioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productosTopToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void ordenesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tiposDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void subTiposDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SIGA.Windows.Ventas.Formularios.frmMantenimientoSubTipo OBJ = new SIGA.Windows.Ventas.Formularios.frmMantenimientoSubTipo();
            //OBJ.MdiParent = this;
            //OBJ.Show();
        }

        private void clientesTopToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void formasDePagoVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void condiccionesDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ventasPorTipoDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void tipoDeCambioToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void preciosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ajusteDeInventariosToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void tipoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void preciosDeReposicionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void configuracionDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void valorizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ventasPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void parametrosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void anulacionDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guiasDeRemisionToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void ingresoAAlmacenesSinOCToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void maquinasTicketerasToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void materialesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ordenesDeCompraPorEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ingresoDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transaccionesDeCajeroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void precioDeReposicionVsCostoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vendedorTopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mediosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void documentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tipoDePedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void marcasPorProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void normalesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void normalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void especialesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void tipoDeCambioToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void registroDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void guiaDeRemisionVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //SIGA.Windows.Caja.frmAnularDocumento obj = new SIGA.Windows.Caja.frmAnularDocumento();
            //obj.MdiParent = this;
            //obj.Show();
        }

        private void pedidosToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void mantenimientoDeKardexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void parámetroFacElectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeDocumentosAnuladosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reenvioDocumentosNubefactToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void notasDeCreditoDebitoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kardexValorizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarKardexValorizadoSunatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void detalladoPorArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ventasPorRazonSociakToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ventasResumenPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saldoValorizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pruebaTLSV12ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ventasPorMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuModulos_Click(object sender, EventArgs e)
        {
            FrmMantenimientoModulo objFrmMantenimientoModulo = new FrmMantenimientoModulo();
            objFrmMantenimientoModulo.MdiParent = this;
            objFrmMantenimientoModulo.Show();

        }

        private void mnuOpciones_Click(object sender, EventArgs e)
        {
            FrmMantenimientoOpciones objFrmMantenimientoOpciones = new FrmMantenimientoOpciones();
            objFrmMantenimientoOpciones.MdiParent = this;
            objFrmMantenimientoOpciones.Show();
        }

        private void mnuPerfil_Click(object sender, EventArgs e)
        {
            FrmMantenimientoPerfil objFrmMantenimientoPerfil = new FrmMantenimientoPerfil();
            objFrmMantenimientoPerfil.MdiParent = this;
            objFrmMantenimientoPerfil.Show();
        }

        private void gebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoGuia objfrmMantenimientoGuia = new frmMantenimientoGuia();
            objfrmMantenimientoGuia.MdiParent = this;
            objfrmMantenimientoGuia.Show();


        }


        private void mnuFamilia_Click(object sender, EventArgs e)
        {
            frmMantenimientoFamilia objfrmMantenimientoFamilia = new frmMantenimientoFamilia();
            objfrmMantenimientoFamilia.MdiParent = this;
            objfrmMantenimientoFamilia.Show();


        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            

        }

        private void mnuPolitica_Click(object sender, EventArgs e)
        {
            frmMantenimientoPolitica objfrmMantenimientoPolitica = new frmMantenimientoPolitica();
            objfrmMantenimientoPolitica.MdiParent = this;
            objfrmMantenimientoPolitica.Show();

        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmRegProducto objFrmRegProducto = new frmRegProducto();
            //objFrmRegProducto.MdiParent = this;
            //objFrmRegProducto.Show();

            frmMantenimientoProducto frmMantenimientoProducto = new frmMantenimientoProducto();
            frmMantenimientoProducto.MdiParent = this;
            frmMantenimientoProducto.Show();

        }

        private void preciosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmMantenimientoPrecios objfrmMantenimientoPrecios = new frmMantenimientoPrecios();
            objfrmMantenimientoPrecios.MdiParent = this;
            objfrmMantenimientoPrecios.Show();
        }

        private void zonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoZona objZona = new frmMantenimientoZona();
            objZona.MdiParent = this;
            objZona.Show();

        }

        private void generacionDeProformasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoCotizaciones objfrmMantenimientoCotizaciones = new frmMantenimientoCotizaciones();
            objfrmMantenimientoCotizaciones.MdiParent = this;
            objfrmMantenimientoCotizaciones.Show();


        }

        private void configuraciónDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoPrecios objfrmMantenimientoPrecios = new frmMantenimientoPrecios();
            objfrmMantenimientoPrecios.MdiParent = this;
            objfrmMantenimientoPrecios.Show();
        }

        private void clientesToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
           
        }

        private void mnuClientes_Click(object sender, EventArgs e)
        {
            frmMantenimientoCliente objfrmMantenimientoCliente = new frmMantenimientoCliente();
            objfrmMantenimientoCliente.MdiParent = this;
            objfrmMantenimientoCliente.Show();
        }

        private void ventasPorFechaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void ventasPorProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En desarrollo");
        }

        private void ventasPorVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En desarrollo");
        }

        private void ventasPorDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En desarrollo");
        }

        private void mnuEmpleados_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Administrador.FrmMantenimientoUsuario objUsuario = new SIGA.Windows.Administrador.FrmMantenimientoUsuario();
            objUsuario.MdiParent = this;
            objUsuario.Show();
        }

        private void mnuVentasPorFecha_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Ventas.Formularios.frmVentasporFecha objVentasPorFecha = new SIGA.Windows.Ventas.Formularios.frmVentasporFecha();
            objVentasPorFecha.MdiParent = this;
            objVentasPorFecha.Show();

        }

        private void fletesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Ventas.Formularios.frmFletes objfrmFletes = new SIGA.Windows.Ventas.Formularios.frmFletes();
            objfrmFletes.MdiParent = this;
            objfrmFletes.Show();

        }

        private void transportistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Ventas.Formularios.frmMantenimientoTransportista objfrmTransportista = new SIGA.Windows.Ventas.Formularios.frmMantenimientoTransportista();
            objfrmTransportista.MdiParent = this;
            objfrmTransportista.Show();

        }

        private void almacenesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos.frmMantenimientoAlmacen objFrmMantenimientoAlmacen = new SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos.frmMantenimientoAlmacen();
            objFrmMantenimientoAlmacen.MdiParent = this;
            objFrmMantenimientoAlmacen.Show();

        }

        private void proveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos.frmMantenimientoProveedor objFrmMantenmientoProveedor = new SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos.frmMantenimientoProveedor();
            objFrmMantenmientoProveedor.MdiParent = this;
            objFrmMantenmientoProveedor.Show();

        }

        private void sedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoSede frmMantenimientoSede = new frmMantenimientoSede();
            frmMantenimientoSede.MdiParent = this;
            frmMantenimientoSede.Show();

        }

        private void requerimientoDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Logistica.Formularios.frmMantenimientoRequerimiento objRequerimiento = new frmMantenimientoRequerimiento();
            objRequerimiento.MdiParent = this;
            objRequerimiento.Show();

        }

        private void ordenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Logistica.Formularios.frmMantenimientoOrdenCompra obj = new SIGA.Windows.Logistica.Formularios.frmMantenimientoOrdenCompra();
            obj.MdiParent = this;
            obj.Show();

        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos.frmMantenimientoOtrosIngresos obj = new SIGA.Windows.Logistica.Formularios.Busquedas.Mantenimientos.frmMantenimientoOtrosIngresos();
            obj.MdiParent = this;
            obj.Show();

        }
    }



}
