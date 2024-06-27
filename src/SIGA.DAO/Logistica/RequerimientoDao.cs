using SIGA.DAO.Comunes;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Logistica
{
    public class RequerimientoDao
    {
        private Conexion Conection = new Conexion();
        public DataTable Consultar()
        {
            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_consultarRequerimiento", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    con.Open();


                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;

        }
        public Requerimiento InsertarRequerimiento(Requerimiento entRequerimiento, List<RequerimientoDetalle> Detalle)
        {
            Requerimiento CotizacionResponse = new Requerimiento();
            int ReqCodigo = 0;
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {

                        using (SqlCommand command = new SqlCommand("USP_InsertarRequerimiento", con))
                        {
                            command.CommandType = CommandType.StoredProcedure;


                            // Agregar parámetros al procedimiento almacenado
                            command.Parameters.AddWithValue("@CodEmpresa", entRequerimiento.CodEmpresa);
                            command.Parameters.AddWithValue("@CodOficina", entRequerimiento.CodOficina);
                            command.Parameters.AddWithValue("@ReqFecha", entRequerimiento.ReqFecha);
                            command.Parameters.AddWithValue("@ReqHora", entRequerimiento.ReqHora);
                            command.Parameters.AddWithValue("@ReqPrioridad", entRequerimiento.ReqPrioridad);

                            command.Parameters.AddWithValue("@Req_ProductoFabricar", entRequerimiento.Req_ProductoFabricar);
                            command.Parameters.AddWithValue("@Req_Cantidad", entRequerimiento.Req_Cantidad);
                            command.Parameters.AddWithValue("@ReqFechaFinal", entRequerimiento.ReqFechaFinal);
                            command.Parameters.AddWithValue("@Req_CentroCosto", entRequerimiento.Req_CentroCosto);
                            command.Parameters.AddWithValue("@Req_EquipoMaquina", entRequerimiento.Req_EquipoMaquina);
                            command.Parameters.AddWithValue("@Req_Observacion", entRequerimiento.Req_Observacion);


                            command.Parameters.AddWithValue("@UsuCodigoSolicitante", entRequerimiento.UsuCodigoSolicitante);
                            command.Parameters.AddWithValue("@UsuCreCodigo", entRequerimiento.UsuCreCodigo);

                            SqlParameter parm2 = new SqlParameter("@Req_Codigo", SqlDbType.Int);
                            parm2.Size = 15;
                            parm2.Direction = ParameterDirection.Output;
                            command.Parameters.Add(parm2);




                            // Abrir conexión y ejecutar el procedimiento almacenado
                            command.Transaction = tran as SqlTransaction;

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Si se insertaron filas, asignar valores de salida
                                //   CotizacionResponse.ReqNumero = Convert.ToString(command.Parameters["@ReqNumero"].Value);
                                // Suponiendo que el procedimiento almacenado devuelve el código de cotización
                                ReqCodigo = Convert.ToInt32(command.Parameters["@Req_Codigo"].Value);
                            }

                            foreach (var item in Detalle)
                            {

                                using (SqlCommand cmdDetalle = new SqlCommand("USP_InsertarRequerimientoDetalle", con))
                                {
                                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                                    cmdDetalle.Parameters.AddWithValue("@ReqCodigo", ReqCodigo);
                                    cmdDetalle.Parameters.AddWithValue("@CodGeneral", item.CodGeneral);
                                    cmdDetalle.Parameters.AddWithValue("@Item", item.Item);
                                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                                    cmdDetalle.Parameters.AddWithValue("@CodUnidadMedida", item.CodUnidadMedida);
                                    cmdDetalle.Parameters.AddWithValue("@Marca", item.Marca);
                                    cmdDetalle.Parameters.AddWithValue("@SalidaAlmacen", item.SalidaAlmacen);
                                    cmdDetalle.Parameters.AddWithValue("@UsuCreCodigo", entRequerimiento.UsuCodigoSolicitante);
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
                        throw ex;

                    }
                }
            }

            return CotizacionResponse;
        }

    }
}
