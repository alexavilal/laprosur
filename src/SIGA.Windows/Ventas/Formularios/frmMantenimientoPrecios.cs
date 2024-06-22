using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGA.Business.Ventas;
using SIGA.Entities.Ventas;

namespace SIGA.Windows.Ventas.Formularios
{
    public partial class frmMantenimientoPrecios : Form
    {
        public frmMantenimientoPrecios()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(173, 216, 230);
        }


        public void ColumnasGrilla()
        {






        }

        private void frmMantenimientoPrecios_Load(object sender, EventArgs e)
        {
            CargarPolitica();
            CargarZona();

            //CargaPrecio();
            //ColumnasGrilla();


        }
        private void CargarPolitica()
        {
            PoliticaPrecioBusiness objPolitica = new PoliticaPrecioBusiness();
            PoliticaPrecio entPolitica = new PoliticaPrecio()
            {
                DesPolitica = String.Empty,
                EstCodigo = "A"
            };

            List<PoliticaPrecio> lista = new List<PoliticaPrecio>();

            lista.Add(new PoliticaPrecio { CodPolitica = 0, DesPolitica = "--Seleccione--" });
            
  
            try
            {
                var result = objPolitica.ObtenerPolitica(entPolitica);

                foreach (var item in result)
                {
                    lista.Add(item);
                }

                cboPolitica.DataSource = lista;
                cboPolitica.DisplayMember = "DesPolitica";
                cboPolitica.ValueMember = "CodPolitica";


            }
            catch (Exception ex)
            {


            }
        }

        public void CargarZona()
        {
            ZonaBusiness objZona = new ZonaBusiness();
            Zona EntZona = new Zona()
            {
                IdZona = 0,
                Descripcion = String.Empty,
                Estado = "A"
            };

            List<Zona> lista = new List<Zona>();

            lista.Add(new Zona {  IdZona = 0, Descripcion = "--Seleccione--" });

            var result = objZona.ObtenerZonas(EntZona);
            foreach (var item in result)
            {
                lista.Add(item);
            }

            cboZona.DataSource = lista;
            cboZona.ValueMember = "idZona";
            cboZona.DisplayMember = "Descripcion";

        }

        
       


        private void CargaPrecio()
        {
            PrecioBusiness objPrecioBusiness = new PrecioBusiness();

            try
            {
                var resultDetalle = objPrecioBusiness.DevuelvePrecio(Convert.ToInt32(cboPolitica.SelectedValue), Convert.ToInt32(cboZona.SelectedValue));

                dgvPrecio.Rows.Clear();

                if (resultDetalle.Rows.Count > 0)
                {

                   


                    for (int i = 0; i < resultDetalle.Rows.Count; i++)
                    {

                        dgvPrecio.Rows.Insert(dgvPrecio.Rows.Count, resultDetalle.Rows[i][0].ToString(),
                                              resultDetalle.Rows[i][1].ToString(),
                                              resultDetalle.Rows[i][2].ToString(),
                                              resultDetalle.Rows[i][3].ToString(),
                                              resultDetalle.Rows[i][4].ToString(),
                                               Convert.ToDecimal(resultDetalle.Rows[i][5]), Convert.ToDecimal(resultDetalle.Rows[i][6]));




                        dgvPrecio.CurrentCell = dgvPrecio.Rows[dgvPrecio.Rows.Count - 1].Cells[2];
                    }



                }
                dgvPrecio.Columns[0].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if  (Convert.ToInt32(cboPolitica.SelectedValue).Equals(0))
            {
                MessageBox.Show("Debe ingresar la politica..");
                return;
            }

            if (Convert.ToInt32(cboZona.SelectedValue).Equals(0))
            {
                MessageBox.Show("Debe ingresar la zona..");
                return;
            }


            CargaPrecio();
            //ColumnasGrilla();
        }


        public List<Precio> Lista()
        {
            List<Precio> ListaDocumento = new List<Precio>();


            foreach (DataGridViewRow row in this.dgvPrecio.Rows)
            {
                // Verificar si la fila no es la fila de encabezado

                Precio Item = new Precio();

                Item.CodigoGeneral = Convert.ToInt32(row.Cells[0].Value);
                Item.CodPolitica = Convert.ToInt32(cboPolitica.SelectedValue);
                Item.CodMoneda = 1;
                Item.CodZona = Convert.ToInt32(cboZona.SelectedValue);
                Item.PrecioProducto = Convert.ToDecimal(row.Cells[5].Value);
                Item.PrecioFlete = Convert.ToDecimal(row.Cells[6].Value);
                Item.Usuario = 1;
                ListaDocumento.Add(Item);
            }


            return ListaDocumento;

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PrecioBusiness objPrecio = new PrecioBusiness();
            int exito = 0;

            try
            {
                if (dgvPrecio.Rows.Count > 0)
                {


                    DialogResult result = MessageBox.Show("¿Está seguro de guardar los cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {

                        var lista = Lista();

                        exito = objPrecio.InsertarPrecio(lista);

                        if (exito.Equals(1))
                        {
                            MessageBox.Show("Se guardó de manera exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("No existem items a guardar");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cboPolitica_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
