using SIGA.DAO.Comunes;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Ventas
{
    public class TransportistaDao
    {

        private Conexion Conection = new Conexion();


        public DataTable DevuelveVehiculo(string Transportista, string PlacaVehiculo)
        {
            DataTable dtPrecio = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_BuscarVehiculo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@Transportista", Transportista);
                        cmd.Parameters.AddWithValue("@PlacaVehiculo", PlacaVehiculo);

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
        public int RegistrarTransportista(Transportista objTransportistaResponse, List<TransportistaPlaca> lstPlaca)
        {
            int CodTransportista = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        if (objTransportistaResponse != null)
                        {
                            using (SqlCommand cmd = new SqlCommand("USP_InsertarTransportista", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@CodTipoDocumento", objTransportistaResponse.CodTipoDocumento);
                                cmd.Parameters.AddWithValue("@NumDocumentoTransportista", objTransportistaResponse.NumDocumentoTransportista);
                                cmd.Parameters.AddWithValue("@RazSocTransportista", objTransportistaResponse.RazSocTransportista);
                                cmd.Parameters.AddWithValue("@DirTransportista", objTransportistaResponse.DirTransportista);
                                cmd.Parameters.AddWithValue("@EstCodigo", "A");
                                cmd.Parameters.AddWithValue("@UsuCreCodigo", 1);
                                cmd.Parameters.Add("@CodTransportista", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                                cmd.Transaction = tran as SqlTransaction;
                                cmd.ExecuteNonQuery();
                                CodTransportista = Convert.ToInt32(cmd.Parameters["@CodTransportista"].Value);
                            }

                            foreach (var item in lstPlaca)
                            {

                                using (SqlCommand cmdDetalle = new SqlCommand("USP_InsertarTransportistaPlaca", con))
                                {
                                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                                    cmdDetalle.Parameters.AddWithValue("@IdRegistro", item.CodigoRegistro);
                                    cmdDetalle.Parameters.AddWithValue("@CodTransportista", CodTransportista);
                                    cmdDetalle.Parameters.AddWithValue("@Placa", item.PlacaAuto);
                                    cmdDetalle.Transaction = tran as SqlTransaction;
                                    cmdDetalle.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();
                        }
                    }

                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }
                }

            }
            return CodTransportista;
        }



        public List<Transportista> BuscarPorTipoDocumento(int pCodigoTipoDocumento, string pNumeroDocumento)
        {

            var listResult = new List<Transportista>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_TransportistaBuscarPorTipoDocumento", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = pCodigoTipoDocumento;
                    cmd.Parameters.Add("@NumDocumentoTransportista", SqlDbType.VarChar).Value = pNumeroDocumento;
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new Transportista();

                            ItemResult.CodTransportista = Convert.ToInt32(dr.GetValue(0));
                            ItemResult.CodTipoDocumento = Convert.ToByte(dr.GetValue(1));
                            ItemResult.NumDocumentoTransportista = Convert.ToString(dr.GetValue(2));
                            ItemResult.RazSocTransportista = Convert.ToString(dr.GetValue(3));
                            ItemResult.DirTransportista = Convert.ToString(dr.GetValue(4));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }
    }
}
