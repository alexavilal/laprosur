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
    public class DocumentoProveedorDao
    {

        private Conexion Conection = new Conexion();


        public int AnularDocumento(int CodigoDocumento,Int16 UsuarioModificacion)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                   
                        using (SqlCommand cmd = new SqlCommand("USP_AnularDocumentoProveedor", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodDocumento ", SqlDbType.Int).Value = CodigoDocumento;
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.Int).Value = UsuarioModificacion;
                           
                            cmd.ExecuteNonQuery();

                            
                        }
                    
                }

                catch (Exception ex)
                {
                    DocumentoGenerado = -1;
                }
            }

            return DocumentoGenerado;
        }


        public int InsertarDocumentoNew(DocumentoProveedor Documento, List<DetalleDocumentoProveedor> Detalle, Int16 CodigoAlmacen, int CodigoNota, ref string Numero)
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
                        using (SqlCommand cmd = new SqlCommand("USP_DocumentoProveedorIngresarNew", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodDocumentoProveedor", SqlDbType.Int).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.VarChar).Value = Documento.CodTipoDocumento;
                            cmd.Parameters.Add("@NumDocProveedor", SqlDbType.VarChar, 15).Value = Documento.NumDocumento;
                            cmd.Parameters.Add("@FecDocProveEdor", SqlDbType.DateTime).Value = Documento.FecDocumento;
                            cmd.Parameters.Add("@FecRecDocProveedor", SqlDbType.DateTime).Value = Documento.FecRecepcion;
                            cmd.Parameters.Add("@ProCodigo", SqlDbType.Int).Value = Documento.ProCodigo;
                            cmd.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = Documento.CodEmpresa;
                            cmd.Parameters.Add("@CodMoneda", SqlDbType.TinyInt).Value = Documento.CodMoneda;
                            cmd.Parameters.Add("@TicDocProveedor", SqlDbType.Decimal).Value = Documento.TipoCambio;
                            cmd.Parameters.Add("@CodEstDocPro", SqlDbType.TinyInt).Value = Documento.CodigoEstado;
                            cmd.Parameters.Add("@BruDocProveedor", SqlDbType.Decimal).Value = Documento.SubTotal;
                            cmd.Parameters.Add("@ImpDocProveedor", SqlDbType.Decimal).Value = Documento.Impuesto;
                            cmd.Parameters.Add("@NetDocProveedor ", SqlDbType.Decimal).Value = Documento.Total;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = "A";
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = Documento.UsuarioCreacion;
                            cmd.Parameters.Add("@incIGVDocProveedor", SqlDbType.Bit).Value = Documento.IncluyeIGV;

                            cmd.Parameters.Add("@CodAlmacen", SqlDbType.TinyInt).Value = Documento.CodigoAlmacen;
                            cmd.Parameters.Add("@FlagCompra", SqlDbType.Bit).Value = true; ;

                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();
                            DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@CodDocumentoProveedor"].Value);


                        }


                        foreach (var item in Detalle)
                        {

                            using (SqlCommand cmdDetalle = new SqlCommand("USP_DetalleDOcumentoProveedorIngresar", con))
                            {
                                cmdDetalle.CommandType = CommandType.StoredProcedure;
                                cmdDetalle.Parameters.Add("@CodDocProveedor", SqlDbType.Int).Value = DocumentoGenerado;
                                cmdDetalle.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = item.CodigoGeneral;
                                cmdDetalle.Parameters.Add("@PreDDP", SqlDbType.Decimal).Value = item.Precio;
                                cmdDetalle.Parameters.Add("@TotDPP", SqlDbType.Decimal).Value = item.Total;
                                cmdDetalle.Parameters.Add("@GuiaDDP", SqlDbType.VarChar, 50).Value = item.NumeroGuia;
                                cmdDetalle.Parameters.Add("@CanDDP", SqlDbType.Decimal).Value = item.Cantidad;
                                cmdDetalle.Parameters.Add("@OrCDDP", SqlDbType.VarChar, 50).Value = item.NumeroOrden;
                                cmdDetalle.Parameters.Add("@ActualizarPrecios", SqlDbType.Char, 1).Value = "S";

                                cmdDetalle.Transaction = tran as SqlTransaction;
                                cmdDetalle.ExecuteNonQuery();
                            }

                            if (item.Cantidad > 0)
                            {
                                using (SqlCommand cmdDetalle = new SqlCommand("USP_KardexInsertar", con))
                                {
                                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                                    cmdDetalle.Parameters.Add("@CodKardex", SqlDbType.Int).Direction = ParameterDirection.Output;

                                    cmdDetalle.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = item.CodigoGeneral;
                                    cmdDetalle.Parameters.Add("@CodAlmacen", SqlDbType.TinyInt).Value = item.CodigoAlmacen;
                                    cmdDetalle.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = item.CodigoEmpresa;
                                    cmdDetalle.Parameters.Add("@CodTipoDocumento", SqlDbType.VarChar).Value = Documento.CodTipoDocumento;
                                    cmdDetalle.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = Documento.NumDocumento;
                                    cmdDetalle.Parameters.Add("@CodTipoEntidad", SqlDbType.TinyInt).Value = 2;
                                    cmdDetalle.Parameters.Add("@Codigo", SqlDbType.Int).Value = Documento.ProCodigo;
                                    cmdDetalle.Parameters.Add("@CodigoTipoMovimiento", SqlDbType.TinyInt).Value = 2;
                                    cmdDetalle.Parameters.Add("@FechaKardex", SqlDbType.DateTime).Value = Documento.FecDocumento;


                                    cmdDetalle.Parameters.Add("@CanEntKardex", SqlDbType.Decimal).Value = item.Cantidad;

                                    if (Documento.CodMoneda == 1) //Soles
                                    {
                                        cmdDetalle.Parameters.Add("@PreEntKardex", SqlDbType.Decimal).Value = item.Precio;
                                        cmdDetalle.Parameters.Add("@TotEntKardex ", SqlDbType.Decimal).Value = item.Total;
                                    }
                                    else                       // Dolares
                                    {
                                        decimal PrecioConvertido = 0;
                                        decimal PrecioTotalConvertido = 0;

                                        PrecioConvertido = Math.Round(item.Precio  * Documento.TipoCambio,2);
                                        PrecioTotalConvertido = Math.Round(PrecioConvertido * item.Cantidad,2);

                                        cmdDetalle.Parameters.Add("@PreEntKardex", SqlDbType.Decimal).Value = PrecioConvertido;
                                        cmdDetalle.Parameters.Add("@TotEntKardex ", SqlDbType.Decimal).Value = PrecioTotalConvertido;
                                    }
                                    
                                    
                                    cmdDetalle.Parameters.Add("@CanSalKardex", SqlDbType.Decimal).Value = 0;
                                    cmdDetalle.Parameters.Add("@PreSalKardex", SqlDbType.Decimal).Value = 0;
                                    cmdDetalle.Parameters.Add("@TotSalKardex ", SqlDbType.Decimal).Value = 0;
                                    cmdDetalle.Parameters.Add("@CanSaAKardex", SqlDbType.Decimal).Value = 0;
                                    cmdDetalle.Parameters.Add("@PreSaAKardex", SqlDbType.Decimal).Value = 0;
                                    cmdDetalle.Parameters.Add("@TotSaAKardex", SqlDbType.Decimal).Value = 0;

                                    cmdDetalle.Parameters.Add("@GuiaNumero", SqlDbType.VarChar, 50).Value = "";

                                    cmdDetalle.Parameters.Add("@CodTipoDocumentoDos", SqlDbType.Char, 2).Value = "";

                                    cmdDetalle.Parameters.Add("@NumeroDocumentoDos", SqlDbType.VarChar, 50).Value = "";

                                    //cmdDetalle.Parameters.Add("@OrdenCompra", SqlDbType.VarChar, 50).Value = "";

                                    cmdDetalle.Parameters.Add("@CodigoDocumento", SqlDbType.Money).Value = DocumentoGenerado;


                                    cmdDetalle.Transaction = tran as SqlTransaction;
                                    cmdDetalle.ExecuteNonQuery();

                                    CodigoKardex = Convert.ToInt32(cmdDetalle.Parameters["@CodKardex"].Value);

                                    if (CodigoKardex <= 0)
                                    {
                                        tran.Rollback();
                                    }



                                }

                            }

                            //  if (Cant > 0)
                            //            {

                            //                using (SqlCommand cmdDetalle = new SqlCommand("USP_KardexInsertar", con))
                            //                {
                            //                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                            //                    cmdDetalle.Parameters.Add("@CodKardex", SqlDbType.Int).Direction = ParameterDirection.Output;

                            //                    cmdDetalle.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = item.CodigoGeneral;
                            //                    cmdDetalle.Parameters.Add("@CodAlmacen", SqlDbType.TinyInt).Value = CodAlmacen;
                            //                    cmdDetalle.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = item.CodigoEmpresa;
                            //                    cmdDetalle.Parameters.Add("@CodTipoDocumento", SqlDbType.VarChar).Value = Documento.CodTipoDocumento;
                            //                    cmdDetalle.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = Documento.NumDocumento;
                            //                    cmdDetalle.Parameters.Add("@CodTipoEntidad", SqlDbType.TinyInt).Value = 2;
                            //                    cmdDetalle.Parameters.Add("@Codigo", SqlDbType.Int).Value = Documento.ProCodigo;
                            //                    cmdDetalle.Parameters.Add("@CodigoTipoMovimiento", SqlDbType.TinyInt).Value = 2;
                            //                    cmdDetalle.Parameters.Add("@FechaKardex", SqlDbType.DateTime).Value = Documento.FecDocumento;
                            //                    cmdDetalle.Parameters.Add("@CanEntKardex", SqlDbType.Decimal).Value = Cant;
                            //                    cmdDetalle.Parameters.Add("@PreEntKardex", SqlDbType.Decimal).Value = item.Precio;
                            //                    cmdDetalle.Parameters.Add("@TotEntKardex ", SqlDbType.Decimal).Value = item.Total;
                            //                    cmdDetalle.Parameters.Add("@CanSalKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@PreSalKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@TotSalKardex ", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@CanSaAKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@PreSaAKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@TotSaAKardex", SqlDbType.Decimal).Value = 0;

                            //                    cmdDetalle.Parameters.Add("@GuiaNumero", SqlDbType.VarChar, 50).Value = item.NumeroGuia;

                            //                    cmdDetalle.Parameters.Add("@CodTipoDocumentoDos", SqlDbType.Char, 2).Value = "01";

                            //                    cmdDetalle.Parameters.Add("@NumeroDocumentoDos", SqlDbType.VarChar, 50).Value = "";

                            //                    cmdDetalle.Parameters.Add("@OrdenCompra", SqlDbType.VarChar, 50).Value = item.NumeroOrden;


                            //                    cmdDetalle.Transaction = tran as SqlTransaction;
                            //                    cmdDetalle.ExecuteNonQuery();

                            //                    CodigoKardex = Convert.ToInt32(cmdDetalle.Parameters["@CodKardex"].Value);

                            //                    if (CodigoKardex <= 0)
                            //                    {
                            //                        tran.Rollback();
                            //                    }



                            //                }


                            //var result = ListarDistribucionNota(CodigoNota, item.CodigoGeneral);

                            //if (result.Rows.Count > 0)
                            //{
                            //    SIGA.DAO.Logistica.AlmacenDao objAlmacenes = new SIGA.DAO.Logistica.AlmacenDao();

                            //    var resultAmacen = objAlmacenes.ConsultarAlmacenes(1);

                            //    if (resultAmacen.Rows.Count > 0)
                            //    {
                            //        for (int i = 0; i < resultAmacen.Rows.Count; i++)
                            //        {
                            //            Int16 CodAlmacen = Convert.ToInt16(resultAmacen.Rows[i][0]);
                            //            decimal Cant = Convert.ToDecimal(result.Rows[0][i]);

                            //            if (Cant > 0)
                            //            {

                            //                using (SqlCommand cmdDetalle = new SqlCommand("USP_KardexInsertar", con))
                            //                {
                            //                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                            //                    cmdDetalle.Parameters.Add("@CodKardex", SqlDbType.Int).Direction = ParameterDirection.Output;

                            //                    cmdDetalle.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = item.CodigoGeneral;
                            //                    cmdDetalle.Parameters.Add("@CodAlmacen", SqlDbType.TinyInt).Value = CodAlmacen;
                            //                    cmdDetalle.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = item.CodigoEmpresa;
                            //                    cmdDetalle.Parameters.Add("@CodTipoDocumento", SqlDbType.VarChar).Value = Documento.CodTipoDocumento;
                            //                    cmdDetalle.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = Documento.NumDocumento;
                            //                    cmdDetalle.Parameters.Add("@CodTipoEntidad", SqlDbType.TinyInt).Value = 2;
                            //                    cmdDetalle.Parameters.Add("@Codigo", SqlDbType.Int).Value = Documento.ProCodigo;
                            //                    cmdDetalle.Parameters.Add("@CodigoTipoMovimiento", SqlDbType.TinyInt).Value = 2;
                            //                    cmdDetalle.Parameters.Add("@FechaKardex", SqlDbType.DateTime).Value = Documento.FecDocumento;
                            //                    cmdDetalle.Parameters.Add("@CanEntKardex", SqlDbType.Decimal).Value = Cant;
                            //                    cmdDetalle.Parameters.Add("@PreEntKardex", SqlDbType.Decimal).Value = item.Precio;
                            //                    cmdDetalle.Parameters.Add("@TotEntKardex ", SqlDbType.Decimal).Value = item.Total;
                            //                    cmdDetalle.Parameters.Add("@CanSalKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@PreSalKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@TotSalKardex ", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@CanSaAKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@PreSaAKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@TotSaAKardex", SqlDbType.Decimal).Value = 0;

                            //                    cmdDetalle.Parameters.Add("@GuiaNumero", SqlDbType.VarChar, 50).Value = item.NumeroGuia;

                            //                    cmdDetalle.Parameters.Add("@CodTipoDocumentoDos", SqlDbType.Char, 2).Value = "01";

                            //                    cmdDetalle.Parameters.Add("@NumeroDocumentoDos", SqlDbType.VarChar, 50).Value = "";

                            //                    cmdDetalle.Parameters.Add("@OrdenCompra", SqlDbType.VarChar, 50).Value = item.NumeroOrden;


                            //                    cmdDetalle.Transaction = tran as SqlTransaction;
                            //                    cmdDetalle.ExecuteNonQuery();

                            //                    CodigoKardex = Convert.ToInt32(cmdDetalle.Parameters["@CodKardex"].Value);

                            //                    if (CodigoKardex <= 0)
                            //                    {
                            //                        tran.Rollback();
                            //                    }



                            //                }

                            //            }



                            //        }

                            //    }


                            //}

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

        public int InsertarDocumento(DocumentoProveedor Documento, List<DetalleDocumentoProveedor> Detalle, Int16 CodigoAlmacen, int CodigoNota, ref string Numero)
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
                        using (SqlCommand cmd = new SqlCommand("USP_DocumentoProveedorIngresar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodDocumentoProveedor", SqlDbType.Int).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.VarChar).Value = Documento.CodTipoDocumento;
                            cmd.Parameters.Add("@NumDocProveedor", SqlDbType.VarChar, 15).Value = Documento.NumDocumento;
                            cmd.Parameters.Add("@FecDocProveEdor", SqlDbType.DateTime).Value = Documento.FecDocumento;
                            cmd.Parameters.Add("@FecRecDocProveedor", SqlDbType.DateTime).Value = Documento.FecRecepcion;
                            cmd.Parameters.Add("@ProCodigo", SqlDbType.Int).Value = Documento.ProCodigo;
                            cmd.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = Documento.CodEmpresa;
                            cmd.Parameters.Add("@CodMoneda", SqlDbType.TinyInt).Value = Documento.CodMoneda;
                            cmd.Parameters.Add("@TicDocProveedor", SqlDbType.Decimal).Value = Documento.TipoCambio;
                            cmd.Parameters.Add("@CodEstDocPro", SqlDbType.TinyInt).Value = Documento.CodigoEstado;
                            cmd.Parameters.Add("@BruDocProveedor", SqlDbType.Decimal).Value = Documento.SubTotal;
                            cmd.Parameters.Add("@ImpDocProveedor", SqlDbType.Decimal).Value = Documento.Impuesto;
                            cmd.Parameters.Add("@NetDocProveedor ", SqlDbType.Decimal).Value = Documento.Total;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = "A";
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = Documento.UsuarioCreacion;
                            cmd.Parameters.Add("@incIGVDocProveedor", SqlDbType.Bit).Value = Documento.IncluyeIGV;
                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();
                            DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@CodDocumentoProveedor"].Value);


                        }


                        foreach (var item in Detalle)
                        {

                            using (SqlCommand cmdDetalle = new SqlCommand("USP_DetalleDOcumentoProveedorIngresar", con))
                            {
                                cmdDetalle.CommandType = CommandType.StoredProcedure;
                                cmdDetalle.Parameters.Add("@CodDocProveedor", SqlDbType.Int).Value = DocumentoGenerado;
                                cmdDetalle.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = item.CodigoGeneral;
                                cmdDetalle.Parameters.Add("@PreDDP", SqlDbType.Decimal).Value = item.Precio;
                                cmdDetalle.Parameters.Add("@TotDPP", SqlDbType.Decimal).Value = item.Total;
                                cmdDetalle.Parameters.Add("@GuiaDDP", SqlDbType.VarChar, 50).Value = item.NumeroGuia;
                                cmdDetalle.Parameters.Add("@CanDDP", SqlDbType.Decimal).Value = item.Cantidad;
                                cmdDetalle.Parameters.Add("@OrCDDP", SqlDbType.VarChar, 50).Value = item.NumeroOrden;
                                cmdDetalle.Transaction = tran as SqlTransaction;
                                cmdDetalle.ExecuteNonQuery();
                            }



                            //var result = ListarDistribucionNota(CodigoNota, item.CodigoGeneral);

                            //if (result.Rows.Count > 0)
                            //{
                            //    SIGA.DAO.Logistica.AlmacenDao objAlmacenes = new SIGA.DAO.Logistica.AlmacenDao();

                            //    var resultAmacen = objAlmacenes.ConsultarAlmacenes(1);

                            //    if (resultAmacen.Rows.Count > 0)
                            //    {
                            //        for (int i = 0; i < resultAmacen.Rows.Count; i++)
                            //        {
                            //            Int16 CodAlmacen = Convert.ToInt16(resultAmacen.Rows[i][0]);
                            //            decimal Cant = Convert.ToDecimal(result.Rows[0][i]);

                            //            if (Cant > 0)
                            //            {

                            //                using (SqlCommand cmdDetalle = new SqlCommand("USP_KardexInsertar", con))
                            //                {
                            //                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                            //                    cmdDetalle.Parameters.Add("@CodKardex", SqlDbType.Int).Direction = ParameterDirection.Output;

                            //                    cmdDetalle.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = item.CodigoGeneral;
                            //                    cmdDetalle.Parameters.Add("@CodAlmacen", SqlDbType.TinyInt).Value = CodAlmacen;
                            //                    cmdDetalle.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = item.CodigoEmpresa;
                            //                    cmdDetalle.Parameters.Add("@CodTipoDocumento", SqlDbType.VarChar).Value = Documento.CodTipoDocumento;
                            //                    cmdDetalle.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = Documento.NumDocumento;
                            //                    cmdDetalle.Parameters.Add("@CodTipoEntidad", SqlDbType.TinyInt).Value = 2;
                            //                    cmdDetalle.Parameters.Add("@Codigo", SqlDbType.Int).Value = Documento.ProCodigo;
                            //                    cmdDetalle.Parameters.Add("@CodigoTipoMovimiento", SqlDbType.TinyInt).Value = 2;
                            //                    cmdDetalle.Parameters.Add("@FechaKardex", SqlDbType.DateTime).Value = Documento.FecDocumento;
                            //                    cmdDetalle.Parameters.Add("@CanEntKardex", SqlDbType.Decimal).Value = Cant;
                            //                    cmdDetalle.Parameters.Add("@PreEntKardex", SqlDbType.Decimal).Value = item.Precio;
                            //                    cmdDetalle.Parameters.Add("@TotEntKardex ", SqlDbType.Decimal).Value = item.Total;
                            //                    cmdDetalle.Parameters.Add("@CanSalKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@PreSalKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@TotSalKardex ", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@CanSaAKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@PreSaAKardex", SqlDbType.Decimal).Value = 0;
                            //                    cmdDetalle.Parameters.Add("@TotSaAKardex", SqlDbType.Decimal).Value = 0;

                            //                    cmdDetalle.Parameters.Add("@GuiaNumero", SqlDbType.VarChar, 50).Value = item.NumeroGuia;

                            //                    cmdDetalle.Parameters.Add("@CodTipoDocumentoDos", SqlDbType.Char, 2).Value = "01";

                            //                    cmdDetalle.Parameters.Add("@NumeroDocumentoDos", SqlDbType.VarChar, 50).Value = "";

                            //                    cmdDetalle.Parameters.Add("@OrdenCompra", SqlDbType.VarChar, 50).Value = item.NumeroOrden;


                            //                    cmdDetalle.Transaction = tran as SqlTransaction;
                            //                    cmdDetalle.ExecuteNonQuery();

                            //                    CodigoKardex = Convert.ToInt32(cmdDetalle.Parameters["@CodKardex"].Value);

                            //                    if (CodigoKardex <= 0)
                            //                    {
                            //                        tran.Rollback();
                            //                    }



                            //                }

                            //            }



                            //        }

                            //    }


                            //}

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




        public DataTable ListarDistribucionNota(int CodigoNota, int CodigoGeneral)
        {
            var listResult = new DataTable();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_DetalleConsultarAlmacen", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CodNota", SqlDbType.Int).Value = CodigoNota;
                    cmd.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = CodigoGeneral;

                    con.Open();

                    listResult.Load(cmd.ExecuteReader());

                }
            }

            return listResult;

        }


        public DataTable ConsultarPorDocumento(string FechaInicio, string FechaFin, int CodigoProveedor, Int16 CodigoEmpresa)
        {
            var listResult = new DataTable();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_DocumentoProveedorConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar).Value = FechaInicio;
                    cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar).Value = FechaFin;
                    cmd.Parameters.Add("@CodigoProveedor", SqlDbType.Int).Value = CodigoProveedor;
                    cmd.Parameters.Add("@CodigoEmpresa", SqlDbType.SmallInt).Value = CodigoEmpresa;
                    con.Open();

                    listResult.Load(cmd.ExecuteReader());

                }
            }

            return listResult;

        }


        public DataTable ConsultarDocumentoIngresado(int CodigoDocumento, string NumeroDocumento, int CodigoProveedor)
        {
            var listResult = new DataTable();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ValidarDocumentoProveedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = CodigoDocumento;
                    cmd.Parameters.Add("@Numero", SqlDbType.VarChar).Value = NumeroDocumento;
                    cmd.Parameters.Add("@Proveedor", SqlDbType.Int).Value = CodigoProveedor;
                    con.Open();
                    listResult.Load(cmd.ExecuteReader());

                }
            }

            return listResult;

        }


        public DataTable DocumentoCompraPorCodigo(int CodigoDocumento)
        {
            var listResult = new DataTable();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_DocumentoCompraPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodDocumento", SqlDbType.Int).Value = CodigoDocumento;
                  
                    con.Open();
                    listResult.Load(cmd.ExecuteReader());

                }
            }

            return listResult;

        }


    }
}
