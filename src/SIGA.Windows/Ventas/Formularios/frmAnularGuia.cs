using SIGA.Business.Ventas;
using SIGA.Entities.Ventas;
using System;
using System.Data;
using System.Windows.Forms;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmAnularGuia : Form
    {
        public int CodigoGuia { get; set; }

        public frmAnularGuia()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtComentario.TextLength > 0)
            {
                Anular(CodigoGuia);
            }
            else
            {
                MessageBox.Show("Debe ingresar un comentario!");
                return;
            }


        }

        private DataTable DatosGuia(int Codigo)
        {
            GuiaBusiness objGuia = new GuiaBusiness();
            return objGuia.DatosGuia(Codigo);
        }
        private void Anular(int CodigoGuia)
        {
            SIGA.Business.Ventas.GuiaBusiness objGuia = new SIGA.Business.Ventas.GuiaBusiness();

            try
            {
                Guia entGuia = new Guia()
                {
                    GuiCodigo = CodigoGuia,
                    GuiComentarioAnulacion = txtComentario.Text
                };

                var result = objGuia.AnularGuia(entGuia);

                if (result > 0)
                {
                    MessageBox.Show("Se ha anulado la guia..!");
                    this.Close();
                }

            }
            catch (Exception ex)
            {


            }
        }

        private void frmAnularGuia_Load(object sender, EventArgs e)
        {
            var result = DatosGuia(CodigoGuia);

            if (result.Rows.Count > 0)
            {

                txtProforma.Text = result.Rows[0][1].ToString();
                dtFecha.Value = Convert.ToDateTime(result.Rows[0][0]);
                txtCodigoCliente.Text = result.Rows[0][3].ToString();
                txtRazonSocial.Text = result.Rows[0][4].ToString();
                txtDireccion.Text = result.Rows[0][5].ToString();
                CodigoGuia = Convert.ToInt32(result.Rows[0][19]);
                txtVale.Text = result.Rows[0][2].ToString();

            }

        }
    }
}
