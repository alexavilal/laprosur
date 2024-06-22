using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
using System.Windows.Forms;

namespace SIGA.Business.Ventas
{
    public class PreciosBusiness
    {

        public DataTable ConfigurarPrecios(int CodigoMarca, int Perfil, int TipoCliente)
        {

            SIGA.Business.Ventas.RangoBusiness objRango = new SIGA.Business.Ventas.RangoBusiness();

            DataTable workTable = new DataTable();

            workTable.Columns.Add("CodigoGeneral", typeof(int));
            workTable.Columns.Add("Codigo", typeof(String));
            workTable.Columns.Add("Descripcion", typeof(String));
            workTable.Columns.Add("Costo", typeof(double));


            var result = objRango.Listado();

            foreach (var x in result)
            {

                string rango = string.Empty;
                rango = x.IniRango.ToString() + "-" + x.FinRango.ToString();

                workTable.Columns.Add("IN" + x.CodRango, typeof(string));

                workTable.Columns.Add(rango + "Ganancia", typeof(double));
                workTable.Columns.Add(rango + "Dcto", typeof(double));


            }

            //workTable.Columns.Add("P, typeof(Double));


            return workTable;

        }

        public DataTable LlenarPrecios(int CodigoMarca, int Perfil, int TipoCliente,string Codigo, string Descripcion)
        {
            SIGA.Business.Logistica.GeneralBusiness objGeneral = new SIGA.Business.Logistica.GeneralBusiness();
            SIGA.Business.Ventas.RangoBusiness objRango = new SIGA.Business.Ventas.RangoBusiness();
            SIGA.DAO.Logistica.GeneralDao objGeneralDao = new SIGA.DAO.Logistica.GeneralDao();


            var dtGrilla = ConfigurarPrecios(CodigoMarca, Perfil, TipoCliente);


            var listaProductos = objGeneral.ConsultarPorDescripcionPrecio(Descripcion, Codigo, CodigoMarca);

            foreach (var item in listaProductos)
            {
                DataRow row;
                row = dtGrilla.NewRow();



                row[0] = item.CodGeneral;


                row[1] = item.CodExtGeneral.ToString();
                row[2] = item.DesLarGeneral.ToString();
                row[3] = objGeneralDao.PrecioConsultaPorCodigo(item.CodGeneral).Rows[0][2];

                var result = objRango.Listado();
                int Indice = 4;
                foreach (var x in result)
                {


                    row[Indice] = "IN" + x.CodRango.ToString();
                    var datatable = Precios(item.CodGeneral, x.CodRango, Perfil, TipoCliente);
                    Indice++;
                    row[Indice] = datatable.Rows.Count > 0 ? datatable.Rows[0][0] : 0;
                    Indice++;
                    row[Indice] = datatable.Rows.Count > 0 ? datatable.Rows[0][1] : 0;
                    Indice++;

                }

                dtGrilla.Rows.Add(row);
                row = null;

            }

            return dtGrilla;


        }



        public bool RegistrasPrecios(DataGridView MiGrilla,int Perfil,int TipoCliente,Int16 CodigoUsuario)
        {


            int CantidadColumnas = MiGrilla.Columns.Count;
            int CodigoGeneral = 0;
            int CodigoRango = 0;
            decimal Ganancia = 0;
            decimal Dcto = 0;
            //CodigoGeneral ,CodigoArticulo, Descripcion ,PrecioCosto , 4, 5, 6
            //
            //

            bool Validado = false;
            bool Ejecuto = false;

            string Valor = string.Empty;
            string Codigo = string.Empty;
            int CantidadRecorridas = 0;
            int CantidadTres = 0;
            SIGA.DAO.Logistica.GeneralDao objGeneral = new SIGA.DAO.Logistica.GeneralDao();

            foreach (DataGridViewRow row in MiGrilla.Rows)
            {

                CodigoGeneral = Convert.ToInt32(row.Cells[0].Value);

                CantidadRecorridas = 4;
                //currQty += row.Cells["qty"].Value;

              

                for (CantidadRecorridas = 4; CantidadRecorridas < CantidadColumnas; CantidadRecorridas++)
                {
                    Valor = Convert.ToString(row.Cells[CantidadRecorridas].Value);

                    int Encontro = 0;
                    Encontro = Valor.IndexOf("IN");


                    if (Valor.IndexOf("IN") == 0)
                    {
                        Codigo = Valor.Substring(2,1);
                        CantidadTres = 0;
                        CantidadTres++;
                    }
                    else
                    {
                        Valor = Convert.ToString(row.Cells[CantidadRecorridas].Value);
                        if (CantidadTres == 1)
                        {
                            Ganancia = Convert.ToDecimal(Valor);
                            CantidadTres++;
                        }
                        else
                        {
                            if (Valor.Length > 0)
                            {
                                Dcto = Convert.ToDecimal(Valor);
                            }
                            else
                            {

                            }
                          
                            CantidadTres++;
                        }

                    }

                    if (CantidadTres == 3)
                    {
                        SIGA.Entities.Ventas.Precio objPrecio = new SIGA.Entities.Ventas.Precio()
                        {
                            CodigoGeneral = CodigoGeneral,
                            CodigoRango = Convert.ToInt32(Codigo),
                            TipoPerfil = Perfil,
                            PorPrecio = Ganancia,
                            PorDcto = Dcto,
                            TipoCliente = TipoCliente,
                            Estado = "A",
                            UsuarioCreacion =  CodigoUsuario

                        };

                      
                        var result = objGeneral.RegistroPrecio(objPrecio);

                        if (result == true)
                        {
                            Validado = true;
                        }
                        else
                        {
                            Validado = false;
                            return Validado;
                        }

                    }


                }

                //if (CantidadRecorridas < CantidadColumnas)
                //{
                //    CantidadTres = CantidadTres++;
                //    CodigoRango = Convert.ToInt32(row.Cells[CantidadRecorridas].Value);
                //    CantidadRecorridas++;
                //}

                //if (CantidadRecorridas < CantidadColumnas)
                //{
                //    Ganancia = Convert.ToDecimal(row.Cells[CantidadRecorridas].Value);
                //    CantidadRecorridas++;
                //    CantidadTres = CantidadTres++;

                //}
                //if (CantidadRecorridas < CantidadColumnas)
                //{
                //    Dcto = Convert.ToDecimal(row.Cells[CantidadRecorridas].Value);
                //    CantidadRecorridas++;
                //    CantidadTres = CantidadTres++;

                //}

                //if (CantidadTres = 3)
                //{

                //}





                //More code here
            }

            return Validado;

        }


        public DataTable Precios(int CodigoGeneral,int CodigoRango,int Perfil,int TipoCLiente)
        {
            SIGA.DAO.Ventas.GeneralDao objPrecio = new SIGA.DAO.Ventas.GeneralDao();
            var result = objPrecio.Precios(CodigoGeneral, CodigoRango, Perfil, TipoCLiente);
            return result;
        }
    }




}
