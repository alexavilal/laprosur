using SIGA.DAO.Comunes;
using SIGA.Entities.Logistica;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Logistica
{
    public class OrdenCompraDao
    {
        private Conexion Conection = new Conexion();

        //public List<OrdenCompraResponse> Consultar(OrdenCompraRequest request)
        //{
        //    var listResult = new List<OrdenCompraResponse>();

        //    using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("USP_OrdenCompraConsultar", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar,10).Value = request.FechaInicio;
        //            cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = request.FechaFin;
        //            cmd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = request.CodProveedor;

        //            con.Open();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    var ItemResult = new OrdenCompraResponse();
        //                    ItemResult.OrdNumero = dr.GetValue(0).ToString();
        //                    ItemResult.OrdFechaEmision = Convert.ToDateTime(dr.GetValue(1).ToString());
        //                    ItemResult.DesProveedor = dr.GetValue(2).ToString();
        //                    ItemResult.DesMoneda = dr.GetValue(3).ToString();

        //                    listResult.Add(ItemResult);
        //                }
        //            }
        //        }
        //    }

        //    return listResult;
        //}

        public DataTable Consultar(OrdenCompraRequest request)
        {

            DataTable dtGuia = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_OrdenCompraConsultar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaInicio", request.FechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", request.FechaFin);
                        cmd.Parameters.AddWithValue("@CodProveedor", request.CodProveedor);

                        con.Open();
                        dtGuia.Load(cmd.ExecuteReader());

                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return dtGuia;

        }

        public OrdenCompra InsertarOrdenCompra(OrdenCompra OC, List<OrdenCompraDetalle> OCDetalle)
        {
            OrdenCompra OCResponse = new OrdenCompra();
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {

                        using (SqlCommand command = new SqlCommand("USP_InsertarOrdenCompra", con))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Agregar parámetros al procedimiento almacenado
                            command.Parameters.AddWithValue("@OrdFechaEmision", OC.OrdFechaEmision);
                            command.Parameters.AddWithValue("@OrdFechaEntrega", OC.OrdFechaEntrega);
                            command.Parameters.AddWithValue("@CodProveedor", OC.CodProveedor);
                            command.Parameters.AddWithValue("@CodMoneda", OC.CodMoneda);
                            command.Parameters.AddWithValue("@OrdDireccion", OC.OrdDireccion);
                            command.Parameters.AddWithValue("@OrdNroRuc", OC.OrdNroRuc);
                            command.Parameters.AddWithValue("@OrdContacto", OC.OrdContacto);
                            command.Parameters.AddWithValue("@OrdTelefono", OC.OrdTelefono);
                            command.Parameters.AddWithValue("@CodFormaPago", OC.CodFormaPago);
                            command.Parameters.AddWithValue("@OrdReferencia", OC.OrdReferencia);
                            command.Parameters.AddWithValue("@OrdNroCuentaCorriente", OC.OrdNroCuentaCorriente);
                            command.Parameters.AddWithValue("@OrdSolicitatoPor", OC.OrdSolicitatoPor);
                            command.Parameters.AddWithValue("@OrdNroCotizacion", OC.OrdNroCotizacion);                            
                            command.Parameters.AddWithValue("@OrdObservacion", OC.OrdObservacion);
                            command.Parameters.AddWithValue("@OrdEstado", OC.OrdEstado);                            
                            command.Parameters.AddWithValue("@UsuCodigo", OC.UsuCodigo);
                            command.Parameters.AddWithValue("@UsuCreCodigo", OC.UsuCreCodigo);                            

                            SqlParameter parm2 = new SqlParameter("@OrdNumero", SqlDbType.VarChar);
                            parm2.Size = 15;
                            parm2.Direction = ParameterDirection.Output;
                            command.Parameters.Add(parm2);


                            SqlParameter parm3 = new SqlParameter("@OrdCodigo", SqlDbType.Int);
                            parm3.Size = 7;
                            parm3.Direction = ParameterDirection.Output;
                            command.Parameters.Add(parm3);


                            // Abrir conexión y ejecutar el procedimiento almacenado
                            command.Transaction = tran as SqlTransaction;

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Si se insertaron filas, asignar valores de salida
                                OCResponse.OrdNumero = Convert.ToString(command.Parameters["@OrdNumero"].Value);
                                // Suponiendo que el procedimiento almacenado devuelve el código
                                OCResponse.OrdCodigo = Convert.ToInt32(command.Parameters["@OrdCodigo"].Value);
                            }

                            foreach (var item in OCDetalle)
                            {

                                using (SqlCommand cmdDetalle = new SqlCommand("USP_InsertarDetalleOrdenCompra", con))
                                {
                                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                                    cmdDetalle.Parameters.AddWithValue("@OrdCodigo", OCResponse.OrdCodigo);
                                    cmdDetalle.Parameters.AddWithValue("@OrdItem", item.OrdItem);
                                    cmdDetalle.Parameters.AddWithValue("@OrdCodigoGeneral", item.OrdCodigoGeneral);
                                    cmdDetalle.Parameters.AddWithValue("@CodUnidadMedida", item.CodUnidadMedida);
                                    cmdDetalle.Parameters.AddWithValue("@OrdDescripcion", item.OrdDescripcion);
                                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                                    cmdDetalle.Parameters.AddWithValue("@Precio", item.Precio);                                    
                                    cmdDetalle.Parameters.AddWithValue("@Total", item.Total);                                    
                                    cmdDetalle.Parameters.AddWithValue("@UsuCreCodigo", OCResponse.UsuCreCodigo);
                                    cmdDetalle.Transaction = tran as SqlTransaction;
                                    cmdDetalle.ExecuteNonQuery();
                                }
                            }

                        }

                        tran.Commit();
                    }

                    catch (Exception ex)
                    {
                        //Exito = -1;
                        tran.Rollback();

                    }
                }
            }

            return OCResponse;
        }

    }
}
