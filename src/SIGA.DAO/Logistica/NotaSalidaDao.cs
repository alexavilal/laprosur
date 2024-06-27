using SIGA.DAO.Comunes;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Logistica
{
    public  class NotaSalidaDao
    {
        private Conexion Conection = new Conexion();

        public DataTable Consultar(NotaSalidaRequest request)
        {

            DataTable dtGuia = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_NotaSalidaConsultar", con))
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

        public NotaSalida InsertarNotaSalida(NotaSalida OC, List<NotaSalidaDetalle> OCDetalle)
        {
            NotaSalida OCResponse = new NotaSalida();
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {

                        using (SqlCommand command = new SqlCommand("USP_InsertarNotaSalida", con))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Agregar parámetros al procedimiento almacenado
                            command.Parameters.AddWithValue("@CodAlmacen", OC.CodAlmacen);
                            command.Parameters.AddWithValue("@NtsTransaccion", OC.NtsTransaccion);
                            command.Parameters.AddWithValue("@NtsFechaEmision", OC.NtsFechaEmision);
                            command.Parameters.AddWithValue("@NtsFechaDocumento", OC.NtsFechaDocumento);
                            command.Parameters.AddWithValue("@CodProveedor", OC.CodProveedor);
                            command.Parameters.AddWithValue("@NtsCliente", OC.NtsCliente);
                            command.Parameters.AddWithValue("@NtsNroDocReferencia", OC.NtsNroDocReferencia);
                            command.Parameters.AddWithValue("@NtsAutorizado", OC.NtsAutorizado);
                            command.Parameters.AddWithValue("@NtsCentroCosto", OC.NtsCentroCosto);
                            command.Parameters.AddWithValue("@CodMoneda", OC.CodMoneda);
                            command.Parameters.AddWithValue("@NtsComentario", OC.NtsComentario);                            
                            command.Parameters.AddWithValue("@NtsEstado", OC.NtsEstado);
                            command.Parameters.AddWithValue("@UsuCodigo", OC.UsuCodigo);
                            command.Parameters.AddWithValue("@UsuCreCodigo", OC.UsuCreCodigo);

                            SqlParameter parm2 = new SqlParameter("@NtsNumero", SqlDbType.VarChar);
                            parm2.Size = 15;
                            parm2.Direction = ParameterDirection.Output;
                            command.Parameters.Add(parm2);


                            SqlParameter parm3 = new SqlParameter("@NtsCodigo", SqlDbType.Int);
                            parm3.Size = 7;
                            parm3.Direction = ParameterDirection.Output;
                            command.Parameters.Add(parm3);


                            // Abrir conexión y ejecutar el procedimiento almacenado
                            command.Transaction = tran as SqlTransaction;

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Si se insertaron filas, asignar valores de salida
                                OCResponse.NtsNumero = Convert.ToString(command.Parameters["@NtsNumero"].Value);
                                // Suponiendo que el procedimiento almacenado devuelve el código
                                OCResponse.NtsCodigo = Convert.ToInt32(command.Parameters["@NtsCodigo"].Value);
                            }

                            foreach (var item in OCDetalle)
                            {

                                using (SqlCommand cmdDetalle = new SqlCommand("USP_InsertarDetalleNotaSalida", con))
                                {
                                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                                    cmdDetalle.Parameters.AddWithValue("@NtsCodigo", OCResponse.NtsCodigo);
                                    cmdDetalle.Parameters.AddWithValue("@NtsItem", item.NtsItem);
                                    cmdDetalle.Parameters.AddWithValue("@CodigoGeneral", item.CodigoGeneral);
                                    cmdDetalle.Parameters.AddWithValue("@CodUnidadMedida", item.CodUnidadMedida);
                                    cmdDetalle.Parameters.AddWithValue("@NtsDescripcion", item.NtsDescripcion);
                                    cmdDetalle.Parameters.AddWithValue("@NtsOrdFabricacion", item.NtsOrdFabricacion);
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