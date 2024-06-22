using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SIGA.DAO.Comunes;
using SIGA.Entities.Administrador;
using SIGA.Entities.Ventas;

namespace SIGA.DAO.Ventas
{
    public class PrecioDao
    {
        private Conexion Conection = new Conexion();

        public int InsertarPrecio(List<Precio> EntPrecio)
        {
            int Exito = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {

                        foreach (var item in EntPrecio)
                        {

                            using (SqlCommand command = new SqlCommand("USP_GeneralPrecioInsertar", con))
                            {
                                command.CommandType = CommandType.StoredProcedure;


                                command.Parameters.AddWithValue("@CodGeneral", item.CodigoGeneral);
                                command.Parameters.AddWithValue("@CodPolitica", item.CodPolitica);
                                command.Parameters.AddWithValue("@CodZona", item.CodZona);
                                command.Parameters.AddWithValue("@CodMoneda", item.CodMoneda);
                                command.Parameters.AddWithValue("@PrecioProducto", item.PrecioProducto);
                                command.Parameters.AddWithValue("@PrecioFlete", item.PrecioFlete);
                                command.Parameters.AddWithValue("@UsuCreCodigo", item.Usuario);

                                command.Transaction = tran as SqlTransaction;
                                command.ExecuteNonQuery();
                            }


                        }

                        tran.Commit();
                        Exito = 1;
                    }

                    catch (Exception ex)
                    {
                        Exito = -1;
                        tran.Rollback();

                    }
                }
            }

            return Exito;
        }

        public DataTable DevuelvePrecioPorItem(int CodGeneral,int CodPolitica, int CodZona)
        {
            DataTable dtPrecio = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_DevuelvePrecio", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodGeneral", CodGeneral);
                        cmd.Parameters.AddWithValue("@CodPolitica", CodPolitica);
                        cmd.Parameters.AddWithValue("@CodZona", CodZona);
                        con.Open();
                        dtPrecio.Load(cmd.ExecuteReader());

                    }
                }
            }


            catch (Exception ex)
            {

                throw ex;

            }

            return dtPrecio;

        }


        public DataTable DevuelvePrecio(int CodPolitica , int CodZona)
        {
            DataTable dtPrecio = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_ObtenerPrecio", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                     
                        cmd.Parameters.AddWithValue("@CodPolitica", CodPolitica);
                        cmd.Parameters.AddWithValue("@CodZona", CodZona);


                        con.Open();


                        dtPrecio.Load(cmd.ExecuteReader());

                    }
                }
            }


            catch (Exception ex)
            {

                throw ex;

            }

            return dtPrecio;

        }

        public DataTable listadoPrecio()
        {
            DataTable dtListadoPrecio = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_ProductoPrecioListar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        dtListadoPrecio.Load(cmd.ExecuteReader());

                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;

            }
            return dtListadoPrecio;
        }

    }
}
