using SIGA.DAO.Comunes;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.DAO.Ventas
{
    public class CotizacionDao
    {

        private Conexion Conection = new Conexion();

        public Cotizacion InsertarCotizacion(Cotizacion entCotizacion, List<CotizacionDetalle> Detalle)
        {
            Cotizacion CotizacionResponse = new Cotizacion();
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {

                        using (SqlCommand command = new SqlCommand("USP_InsertarCotizacion", con))
                        {
                            command.CommandType = CommandType.StoredProcedure;


                            // Agregar parámetros al procedimiento almacenado
                            command.Parameters.AddWithValue("@CodEmpresa", entCotizacion.CodEmpresa);
                            command.Parameters.AddWithValue("@CodOficina", entCotizacion.CodOficina);
                            command.Parameters.AddWithValue("@CodPolitica", entCotizacion.CodPolitica);
                            command.Parameters.AddWithValue("@CodZona", entCotizacion.CodZona);
                            command.Parameters.AddWithValue("@CotFecha", entCotizacion.CotFecha);
                            command.Parameters.AddWithValue("@CodCliente", entCotizacion.CodCliente);
                            command.Parameters.AddWithValue("@CodMoneda", entCotizacion.CodMoneda);
                            command.Parameters.AddWithValue("@CotImporte", entCotizacion.CotImporte);
                            command.Parameters.AddWithValue("@CotEstado", entCotizacion.CotEstado);
                            command.Parameters.AddWithValue("@UsuCodigo", entCotizacion.UsuCodigo);
                            command.Parameters.AddWithValue("@UsuCreCodigo", entCotizacion.UsuCreCodigo);
                            command.Parameters.AddWithValue("@FecCre", entCotizacion.FecCre);
                            command.Parameters.AddWithValue("@UsuModCodigo", entCotizacion.UsuModCodigo);
                            command.Parameters.AddWithValue("@FecMod", entCotizacion.FecMod);


                            SqlParameter parm2 = new SqlParameter("@Numero", SqlDbType.VarChar);
                            parm2.Size = 15;
                            parm2.Direction = ParameterDirection.Output;
                            command.Parameters.Add(parm2);


                            SqlParameter parm3 = new SqlParameter("@Cot_Codigo", SqlDbType.Int);
                            parm3.Size = 7;
                            parm3.Direction = ParameterDirection.Output;
                            command.Parameters.Add(parm3);


                            // Abrir conexión y ejecutar el procedimiento almacenado
                            command.Transaction = tran as SqlTransaction;

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Si se insertaron filas, asignar valores de salida
                                CotizacionResponse.CotNumero = Convert.ToString(command.Parameters["@Numero"].Value);
                                // Suponiendo que el procedimiento almacenado devuelve el código de cotización
                                CotizacionResponse.CotCodigo = Convert.ToInt32(command.Parameters["@Cot_Codigo"].Value);
                            }

                            foreach (var item in Detalle)
                            {

                                using (SqlCommand cmdDetalle = new SqlCommand("USP_InsertarCotizacionDetalle", con))
                                {
                                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                                    cmdDetalle.Parameters.AddWithValue("@CotCodigo", CotizacionResponse.CotCodigo);
                                    cmdDetalle.Parameters.AddWithValue("@CodGeneral", item.CodGeneral);
                                    cmdDetalle.Parameters.AddWithValue("@Item", item.Item);
                                    cmdDetalle.Parameters.AddWithValue("@CodUnidadMedida", item.CodUnidadMedida);
                                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                                    cmdDetalle.Parameters.AddWithValue("@Precio", item.Precio);
                                    cmdDetalle.Parameters.AddWithValue("@Descuento", item.Descuento);
                                    cmdDetalle.Parameters.AddWithValue("@Total", item.Total);
                                    cmdDetalle.Parameters.AddWithValue("@UsuCreCodigo", item.UsuCreCodigo);
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

            return CotizacionResponse;
        }

        public DataTable DevuelveCotizaciones(string FechaInicio , string FechaFin , string CodigoCliente , int CodigoVendedor)
        {

            DataTable dtCotizaciones = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_CotizacionConsultar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                        cmd.Parameters.AddWithValue("@CodCliente", CodigoCliente);
                        cmd.Parameters.AddWithValue("@CodVendedor", CodigoVendedor);
                        con.Open();
                        dtCotizaciones.Load(cmd.ExecuteReader());

                    }
                }
            }


            catch (Exception ex)
            {

                throw ex;

            }

            return dtCotizaciones;

        }

    }
}
