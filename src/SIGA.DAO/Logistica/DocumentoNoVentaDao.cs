using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.Entities.Logistica;
using SIGA.Comun.Dto;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using SIGA.DAO.Comunes;

namespace SIGA.DAO.Logistica
{
    public class DocumentoNoVentaDao
    {
        private Conexion Conection = new Conexion();

        public int InsertarDocumento(DocumentoNoVenta Documento, List<DetalleDocumentoIngreso> Detalle, Int16 CodigoAlmacen, ref string Numero)
        {
            int DocumentoGenerado = 0;
            int CodigoKardex = 0;
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_DocumentoNoVentaInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodDocNoVenta", SqlDbType.Int).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.VarChar).Value = Documento.CodTipoDocumento;
                            cmd.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 15).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("@ProCodigo", SqlDbType.VarChar).Value = Documento.ProCodigo;
                            cmd.Parameters.Add("@FecDocumento", SqlDbType.DateTime).Value = Documento.FecDocumento;
                            cmd.Parameters.Add("@CodMoneda", SqlDbType.TinyInt).Value = Documento.CodMoneda;
                            cmd.Parameters.Add("@CodTipoMovimiento", SqlDbType.TinyInt).Value = Documento.CodTipoMovimiento;
                            cmd.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = Documento.CodEmpresa;
                            cmd.Parameters.Add("@CodTipoEntidad", SqlDbType.TinyInt).Value = Documento.CodTipoEntidad;
                            cmd.Parameters.Add("@CodTipoDocumentoDos", SqlDbType.Char, 2).Value = Documento.CodTipoDocumentoDos;
                            cmd.Parameters.Add("@NumeroDocumentoDos", SqlDbType.VarChar).Value = Documento.NumeroDocumentoDos;
                            cmd.Parameters.Add("@OrdenCompra", SqlDbType.VarChar).Value = Documento.OrdenCompra;
                            cmd.Parameters.Add("@Gui_Numero", SqlDbType.VarChar).Value = Documento.Gui_Numero;
                            cmd.Parameters.Add("@CodSede", SqlDbType.Int).Value = Convert.ToInt32(Documento.CodSede);
                            cmd.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = Convert.ToInt32(Documento.CodAlmacen);
                            cmd.Parameters.Add("@EstSalida", SqlDbType.Int).Value = Convert.ToInt32(Documento.CodEstSalida);
                            cmd.Parameters.Add("@UsuCodigo", SqlDbType.SmallInt).Value = Convert.ToInt16(Documento.CodigoUsuario);
                            cmd.Parameters.Add("@CodSalida", SqlDbType.SmallInt).Value = Convert.ToInt16(Documento.CodigoSalida);

                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();
                            DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@CodDocNoVenta"].Value);
                            Numero = Convert.ToString(cmd.Parameters["@NumDocumento"].Value);

                        }




                        foreach (var item in Detalle)
                        {

                            using (SqlCommand cmdDetalle = new SqlCommand("USP_DetalleDocumentoNoVentaInsertar", con))
                            {
                                cmdDetalle.CommandType = CommandType.StoredProcedure;
                                cmdDetalle.Parameters.Add("@CodDocNoVenta", SqlDbType.Int).Value = DocumentoGenerado;
                                cmdDetalle.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = item.CodGeneral;
                                cmdDetalle.Parameters.Add("@TotOrdDocNoVenta", SqlDbType.Decimal).Value = item.TotOrdenCompra;
                                cmdDetalle.Parameters.Add("@Alm1", SqlDbType.Decimal).Value = item.Alm1;
                                cmdDetalle.Parameters.Add("@Alm2", SqlDbType.Decimal).Value = item.Alm2;
                                cmdDetalle.Parameters.Add("@Alm3", SqlDbType.Decimal).Value = item.Alm3;
                                cmdDetalle.Parameters.Add("@Alm4", SqlDbType.Decimal).Value = item.Alm4;
                                cmdDetalle.Parameters.Add("@Alm5", SqlDbType.Decimal).Value = item.Alm5;
                                cmdDetalle.Parameters.Add("@Alm6", SqlDbType.Decimal).Value = item.Alm6;
                                cmdDetalle.Parameters.Add("@Alm7", SqlDbType.Decimal).Value = item.Alm7;
                                cmdDetalle.Parameters.Add("@Alm8", SqlDbType.Decimal).Value = item.Alm8;
                                cmdDetalle.Parameters.Add("@Alm9", SqlDbType.Decimal).Value = item.Alm9;
                                cmdDetalle.Parameters.Add("@Alm10", SqlDbType.Decimal).Value = item.Alm10;
                                cmdDetalle.Parameters.Add("@TotDocNoVenta", SqlDbType.Decimal).Value = item.TotalIngresado;
                                cmdDetalle.Transaction = tran as SqlTransaction;
                                cmdDetalle.ExecuteNonQuery();
                            }

                        }


                        if (Documento.CodTipoMovimiento == 14)
                        {
                            tran.Commit();
                            return DocumentoGenerado;
                        }

                        foreach (var itemAlmacen in Detalle)  //Ingreso por Almacen
                        {

                            SIGA.DAO.Logistica.AlmacenDao objAlmacenes = new SIGA.DAO.Logistica.AlmacenDao();


                            if (Documento.CodTipoMovimiento == 3 || Documento.CodTipoMovimiento == 5 || Documento.CodTipoMovimiento == 9)
                            {
                                decimal Cantidad = 0;

                                Cantidad = itemAlmacen.TotalIngresado;

                                using (SqlCommand cmdDetalle = new SqlCommand("USP_KardexInsertar", con))
                                {
                                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                                    cmdDetalle.Parameters.Add("@CodKardex", SqlDbType.Int).Direction = ParameterDirection.Output;

                                    cmdDetalle.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = itemAlmacen.CodGeneral;
                                    cmdDetalle.Parameters.Add("@CodAlmacen", SqlDbType.TinyInt).Value = Documento.CodAlmacen;
                                    cmdDetalle.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = itemAlmacen.CodigoEmpresa;

                                    cmdDetalle.Parameters.Add("@CodTipoDocumento", SqlDbType.VarChar).Value = Documento.CodTipoDocumento;
                                    cmdDetalle.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = Numero;
                                    cmdDetalle.Parameters.Add("@CodTipoEntidad", SqlDbType.TinyInt).Value = Documento.CodTipoEntidad;
                                    cmdDetalle.Parameters.Add("@Codigo", SqlDbType.Int).Value = Documento.ProCodigo;
                                    cmdDetalle.Parameters.Add("@CodigoTipoMovimiento", SqlDbType.TinyInt).Value = Documento.CodTipoMovimiento;
                                    cmdDetalle.Parameters.Add("@FechaKardex", SqlDbType.DateTime).Value = Documento.FecDocumento;


                                    cmdDetalle.Parameters.Add("@CanEntKardex", SqlDbType.Decimal).Value = Cantidad;

                                    if (Documento.CodTipoMovimiento == 3) //Traslado
                                    {
                                        cmdDetalle.Parameters.Add("@PreEntKardex", SqlDbType.Decimal).Value = itemAlmacen.Precio;
                                        cmdDetalle.Parameters.Add("@TotEntKardex ", SqlDbType.Decimal).Value = Cantidad * itemAlmacen.Precio;
                                    }
                                    else
                                    {
                                        cmdDetalle.Parameters.Add("@PreEntKardex", SqlDbType.Decimal).Value = 0;
                                        cmdDetalle.Parameters.Add("@TotEntKardex ", SqlDbType.Decimal).Value = 0;

                                    }


                                    cmdDetalle.Parameters.Add("@CanSalKardex", SqlDbType.Decimal).Value = 0;
                                    cmdDetalle.Parameters.Add("@PreSalKardex", SqlDbType.Decimal).Value = 0;
                                    cmdDetalle.Parameters.Add("@TotSalKardex ", SqlDbType.Decimal).Value = 0;
                                    cmdDetalle.Parameters.Add("@CanSaAKardex", SqlDbType.Decimal).Value = 0;
                                    cmdDetalle.Parameters.Add("@PreSaAKardex", SqlDbType.Decimal).Value = 0;
                                    cmdDetalle.Parameters.Add("@TotSaAKardex", SqlDbType.Decimal).Value = 0;

                                    cmdDetalle.Parameters.Add("@GuiaNumero", SqlDbType.VarChar, 50).Value = Documento.Gui_Numero;

                                    cmdDetalle.Parameters.Add("@CodTipoDocumentoDos", SqlDbType.Char, 2).Value = Documento.CodTipoDocumentoDos.ToString();

                                    cmdDetalle.Parameters.Add("@NumeroDocumentoDos", SqlDbType.VarChar, 50).Value = Documento.NumeroDocumentoDos;

                                    cmdDetalle.Parameters.Add("@OrdenCompra", SqlDbType.VarChar, 50).Value = Documento.OrdenCompra;

                                    cmdDetalle.Parameters.Add("@CodigoDocumento", SqlDbType.Int).Value = DocumentoGenerado;


                                    cmdDetalle.Transaction = tran as SqlTransaction;
                                    cmdDetalle.ExecuteNonQuery();

                                    CodigoKardex = Convert.ToInt32(cmdDetalle.Parameters["@CodKardex"].Value);

                                    if (CodigoKardex <= 0)
                                    {
                                        tran.Rollback();
                                    }

                                }


                            }

                            else
                            {

                                var resultAmacen = objAlmacenes.ConsultarAlmacenes(Documento.CodSede);

                                if (resultAmacen.Rows.Count > 0)
                                {

                                    Int16 CodAlmacen = Convert.ToInt16(CodigoAlmacen);
                                    decimal Cant = 0;

                                    //decimal Cant = Convert.ToDecimal(result.Rows[0][i]);
                                    switch (CodigoAlmacen)
                                    {
                                        case 1: Cant = itemAlmacen.Alm1; break;
                                        case 2: Cant = itemAlmacen.Alm2; break;
                                        case 3: Cant = itemAlmacen.Alm3; break;
                                        case 4: Cant = itemAlmacen.Alm4; break;
                                        case 5: Cant = itemAlmacen.Alm5; break;
                                        case 6: Cant = itemAlmacen.Alm6; break;
                                        case 7: Cant = itemAlmacen.Alm7; break;
                                        case 8: Cant = itemAlmacen.Alm8; break;
                                        case 9: Cant = itemAlmacen.Alm9; break;
                                        case 10: Cant = itemAlmacen.Alm10; break;
                                    }

                                    if (Cant > 0)
                                    {
                                        using (SqlCommand cmdDetalle = new SqlCommand("USP_KardexInsertar", con))
                                        {
                                            cmdDetalle.CommandType = CommandType.StoredProcedure;

                                            cmdDetalle.Parameters.Add("@CodKardex", SqlDbType.Int).Direction = ParameterDirection.Output;

                                            cmdDetalle.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = itemAlmacen.CodGeneral;
                                            cmdDetalle.Parameters.Add("@CodAlmacen", SqlDbType.TinyInt).Value = CodigoAlmacen;
                                            cmdDetalle.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = itemAlmacen.CodigoEmpresa;

                                            cmdDetalle.Parameters.Add("@CodTipoDocumento", SqlDbType.VarChar).Value = Documento.CodTipoDocumento;
                                            cmdDetalle.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = Numero;
                                            cmdDetalle.Parameters.Add("@CodTipoEntidad", SqlDbType.TinyInt).Value = Documento.CodTipoEntidad;
                                            cmdDetalle.Parameters.Add("@Codigo", SqlDbType.Int).Value = Documento.ProCodigo;
                                            cmdDetalle.Parameters.Add("@CodigoTipoMovimiento", SqlDbType.TinyInt).Value = Documento.CodTipoMovimiento;
                                            cmdDetalle.Parameters.Add("@FechaKardex", SqlDbType.DateTime).Value = Documento.FecDocumento;
                                            cmdDetalle.Parameters.Add("@CanEntKardex", SqlDbType.Decimal).Value = Cant;
                                            cmdDetalle.Parameters.Add("@PreEntKardex", SqlDbType.Decimal).Value = 0;
                                            cmdDetalle.Parameters.Add("@TotEntKardex ", SqlDbType.Decimal).Value = 0;
                                            cmdDetalle.Parameters.Add("@CanSalKardex", SqlDbType.Decimal).Value = 0;
                                            cmdDetalle.Parameters.Add("@PreSalKardex", SqlDbType.Decimal).Value = 0;
                                            cmdDetalle.Parameters.Add("@TotSalKardex ", SqlDbType.Decimal).Value = 0;
                                            cmdDetalle.Parameters.Add("@CanSaAKardex", SqlDbType.Decimal).Value = 0;
                                            cmdDetalle.Parameters.Add("@PreSaAKardex", SqlDbType.Decimal).Value = 0;
                                            cmdDetalle.Parameters.Add("@TotSaAKardex", SqlDbType.Decimal).Value = 0;

                                            cmdDetalle.Parameters.Add("@GuiaNumero", SqlDbType.VarChar, 50).Value = Documento.Gui_Numero;

                                            cmdDetalle.Parameters.Add("@CodTipoDocumentoDos", SqlDbType.Char, 2).Value = Documento.CodTipoDocumentoDos.ToString();

                                            cmdDetalle.Parameters.Add("@NumeroDocumentoDos", SqlDbType.VarChar, 50).Value = Documento.NumeroDocumentoDos;

                                            cmdDetalle.Parameters.Add("@OrdenCompra", SqlDbType.VarChar, 50).Value = Documento.OrdenCompra;

                                            cmdDetalle.Parameters.Add("@CodigoDocumento", SqlDbType.Int).Value = DocumentoGenerado;

                                            cmdDetalle.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = Documento.CodigoUsuario;


                                            cmdDetalle.Transaction = tran as SqlTransaction;
                                            cmdDetalle.ExecuteNonQuery();

                                            CodigoKardex = Convert.ToInt32(cmdDetalle.Parameters["@CodKardex"].Value);

                                            if (CodigoKardex <= 0)
                                            {
                                                tran.Rollback();
                                            }

                                        }



                                    }




                                }









                            }

                        }

                        tran.Commit();



                    }

                    catch (Exception ex)
                    {
                        tran.Rollback();

                    }



                }
            }

            return DocumentoGenerado;
        }


        public List<IngresoDto> Listar(string FechaInicio, string FechaFinal, Int16 CodigoEstado, Int16 CodigoTipo)
        {

            var listResult = new List<IngresoDto>();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_NotaIngresoConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Inicio", SqlDbType.VarChar).Value = FechaInicio;
                    cmd.Parameters.Add("@Fin", SqlDbType.VarChar).Value = FechaFinal;
                    cmd.Parameters.Add("@CodigoEstado", SqlDbType.SmallInt).Value = CodigoEstado;
                    cmd.Parameters.Add("@CodigoTipoMovimiento", SqlDbType.SmallInt).Value = CodigoTipo;


                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new IngresoDto();
                            ItemResult.CodIngreso = Convert.ToInt32(dr.GetValue(0));
                            ItemResult.Numero = Convert.ToString(dr.GetValue(1));
                            ItemResult.Fecha = Convert.ToString(dr.GetValue(2));
                            ItemResult.Origen = Convert.ToString(dr.GetValue(3));
                            ItemResult.Movimiento = Convert.ToString(dr.GetValue(5));
                            ItemResult.Estado = Convert.ToString(dr.GetValue(9));
                            ItemResult.Destino = Convert.ToString(dr.GetValue(13));

                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }




        public DataTable ListarIngresos(string FechaInicio, string FechaFinal, int CodigoSede, int CodigoAlmacen, int CodigoMotivo, string NumeroOrden)
        {



            var listResult = new DataTable();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_DocumentoIngresoConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar).Value = FechaInicio;
                    cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar).Value = FechaFinal;
                    cmd.Parameters.Add("@CodSede", SqlDbType.Int).Value = CodigoSede;
                    cmd.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = CodigoAlmacen;
                    cmd.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = CodigoMotivo;
                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.VarChar).Value = NumeroOrden;
                    con.Open();

                    listResult.Load(cmd.ExecuteReader());

                }
            }

            return listResult;

        }

        public List<DetalleDocumentoProveedor> ListarPorCodigo(int Codigo)
        {

            var listResult = new List<DetalleDocumentoProveedor>();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_DetalleDocumentoNoVentaConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;



                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new DetalleDocumentoProveedor();

                            ItemResult.Codigo = Convert.ToInt32(dr.GetValue(0));
                            ItemResult.CodigoGeneral = Convert.ToInt32(dr.GetValue(1));

                            ItemResult.CodigoExterno = Convert.ToString(dr.GetValue(2));


                            ItemResult.CodigoEmpresa = Convert.ToInt16(dr.GetValue(3));

                            ItemResult.DescripcionLarga = Convert.ToString(dr.GetValue(4));

                            ItemResult.Cantidad = Convert.ToDecimal(dr.GetValue(5));

                            ItemResult.Precio = Convert.ToDecimal(dr.GetValue(6));


                            ItemResult.Total = Convert.ToDecimal(dr.GetValue(7));

                            ItemResult.NumeroGuia = Convert.ToString(dr.GetValue(8));

                            ItemResult.NumeroOrden = Convert.ToString(dr.GetValue(9));

                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }


        public DataTable ListarItems(int CodigoNota)
        {
            var listResult = new DataTable();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_DetalleIngresoConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = CodigoNota;

                    con.Open();

                    listResult.Load(cmd.ExecuteReader());

                }
            }

            return listResult;

        }


        public DataTable NotaImpresion(int CodigoNota)
        {
            var listResult = new DataTable();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_DocumentoNoVentaConsulta", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("CodDocNoVenta", SqlDbType.Int).Value = CodigoNota;

                    con.Open();

                    listResult.Load(cmd.ExecuteReader());

                }
            }

            return listResult;

        }


    }
}
