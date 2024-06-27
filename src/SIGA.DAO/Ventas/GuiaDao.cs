using SIGA.DAO.Comunes;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Ventas
{
    public class GuiaDao
    {
        private Conexion Conection = new Conexion();
        public Guia InsertarGuia(Guia entGuia, List<GuiaDetalle> Detalle)
        {
            Guia GuiaResponse = new Guia();
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {

                        using (SqlCommand command = new SqlCommand("USP_InsertarGuia", con))
                        {
                            command.CommandType = CommandType.StoredProcedure;


                            // Agregar parámetros al procedimiento almacenado
                            command.Parameters.AddWithValue("@CodEmpresa", entGuia.CodEmpresa);
                            command.Parameters.AddWithValue("@CodOficina", entGuia.CodOficina);
                            command.Parameters.AddWithValue("@GuiVale", entGuia.GuiVale);
                            command.Parameters.AddWithValue("@CodPolitica", entGuia.CodPolitica);
                            command.Parameters.AddWithValue("@CodZona", entGuia.CodZona);
                            command.Parameters.AddWithValue("@GuiFecha", entGuia.GuiFecha);
                            command.Parameters.AddWithValue("@CodCliente", entGuia.CodCliente);
                            command.Parameters.AddWithValue("@CodMoneda", entGuia.CodMoneda);
                            command.Parameters.AddWithValue("@GuiImporte", entGuia.GuiImporte);
                            command.Parameters.AddWithValue("@GuiPlaca", entGuia.GuiPlaca);
                            command.Parameters.AddWithValue("@CodFormaPago", entGuia.CodFormaPago);
                            command.Parameters.AddWithValue("@GuiEstado", entGuia.GuiEstado);
                            command.Parameters.AddWithValue("@UsuCodigo", entGuia.UsuCodigo);
                            command.Parameters.AddWithValue("@UsuCreCodigo", entGuia.UsuCreCodigo);
                            command.Parameters.AddWithValue("@CodTransportista", entGuia.CodTransportista);



                            SqlParameter parm2 = new SqlParameter("@GuiNumero", SqlDbType.VarChar);
                            parm2.Size = 15;
                            parm2.Direction = ParameterDirection.Output;
                            command.Parameters.Add(parm2);


                            SqlParameter parm3 = new SqlParameter("@GuiCodigo", SqlDbType.Int);
                            parm3.Size = 7;
                            parm3.Direction = ParameterDirection.Output;
                            command.Parameters.Add(parm3);


                            // Abrir conexión y ejecutar el procedimiento almacenado
                            command.Transaction = tran as SqlTransaction;

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Si se insertaron filas, asignar valores de salida
                                GuiaResponse.GuiNumero = Convert.ToString(command.Parameters["@GuiNumero"].Value);
                                // Suponiendo que el procedimiento almacenado devuelve el código de cotización
                                GuiaResponse.GuiCodigo = Convert.ToInt32(command.Parameters["@GuiCodigo"].Value);
                            }

                            foreach (var item in Detalle)
                            {

                                using (SqlCommand cmdDetalle = new SqlCommand("USP_InsertarDetalleGuia", con))
                                {
                                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                                    cmdDetalle.Parameters.AddWithValue("@GuiCodigo", GuiaResponse.GuiCodigo);
                                    cmdDetalle.Parameters.AddWithValue("@CodGeneral", item.CodGeneral);
                                    cmdDetalle.Parameters.AddWithValue("@CodUnidadMedida", item.CodUnidadMedida);
                                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                                    cmdDetalle.Parameters.AddWithValue("@Precio", item.Precio);
                                    cmdDetalle.Parameters.AddWithValue("@Descuento", item.Descuento);
                                    cmdDetalle.Parameters.AddWithValue("@Total", item.Total);
                                    cmdDetalle.Parameters.AddWithValue("@Pampa", item.Pampa);
                                    cmdDetalle.Parameters.AddWithValue("@Quema", item.Quema);
                                    cmdDetalle.Parameters.AddWithValue("@UsuCreCodigo", GuiaResponse.UsuCreCodigo);
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

            return GuiaResponse;
        }

        public DataTable DatosGuia(int Guia)
        {

            DataTable dtGuia = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_GuiaImpresion", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GuiCodigo", Guia);
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

        public DataTable ConsultarGuias()
        {

            DataTable dtGuia = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_ConsultarGuias", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable VentarPorFecha(string FechaInicio, string FechaFin, string CodigoCliente)
        {

            DataTable dtGuia = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_VentasPorFecha", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                        cmd.Parameters.AddWithValue("@CodCliente", CodigoCliente);

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
        public int AnularGuia(Guia entGuia)
        {
            int Exito = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (entGuia != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_GuiaAnular", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@GuiCodigo", entGuia.GuiCodigo);
                            cmd.Parameters.AddWithValue("@ComentarioAnulacion", entGuia.GuiComentarioAnulacion);
                            cmd.ExecuteNonQuery();
                            Exito = 1;

                        }
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return Exito;
        }


    }
}
