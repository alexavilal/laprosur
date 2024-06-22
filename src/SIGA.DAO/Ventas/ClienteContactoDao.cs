using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.Entities.Ventas;
using System.Data.SqlClient;
using SIGA.DAO.Comunes;
using System.Data;

namespace SIGA.DAO.Ventas
{
    public class ClienteContactoDao
    {
        private Conexion Conection = new Conexion();

        public int EliminarClienteContacto(ClienteContacto objClienteContacto)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("USP_ClienteContactoEliminar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodClienteContacto", SqlDbType.Int).Value = objClienteContacto.CodClienteContacto;
                    
                    SqlParameter parm2 = new SqlParameter("@RESULTADO", SqlDbType.Int);
                    parm2.Size = 7;
                    parm2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm2);
                    
                    cmd.ExecuteNonQuery();

                    DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
                }
            }

            return DocumentoGenerado;
        }


        public List<ClienteContacto> ObtenerClienteContacto(ClienteContacto objClienteContacto)
        {
            var listResult = new List<ClienteContacto>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ObtenerClienteContacto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objClienteContacto.CodCliente;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new ClienteContacto();
                            ItemResult.CodClienteContacto = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.CodCliente = Convert.ToString(dr.GetValue(1));
                            ItemResult.NomConCliente = Convert.ToString(dr.GetValue(2));
                            ItemResult.CargoConCliente = Convert.ToString(dr.GetValue(3));
                            ItemResult.AreaConCliente = Convert.ToString(dr.GetValue(4));
                            ItemResult.CodOperador = Convert.ToInt16(dr.GetValue(5));
                            ItemResult.CodOperador2 = Convert.ToInt16(dr.GetValue(6));
                            ItemResult.operador1 = Convert.ToString(dr.GetValue(7));
                            ItemResult.operador2 = Convert.ToString(dr.GetValue(8));                       
                            ItemResult.TeleConCliente = Convert.ToString(dr.GetValue(9));
                            ItemResult.ApellidoConCliente = Convert.ToString(dr.GetValue(10));
                            ItemResult.CorConCliente = Convert.ToString(dr.GetValue(11));
                            ItemResult.CelConCliente1 = Convert.ToString(dr.GetValue(12));
                            ItemResult.CelConCliente2 = Convert.ToString(dr.GetValue(13));

                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }


        public int RegistrarClienteContacto(List<ClienteContacto> ListaClienteContacto)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        if (ListaClienteContacto != null)
                        {
                            foreach (var item in ListaClienteContacto)
                            {
                                ClienteContacto objClienteContacto = new ClienteContacto();
                                objClienteContacto.CodCliente = item.CodCliente;
                                objClienteContacto.NomConCliente = item.NomConCliente;
                                objClienteContacto.ApellidoConCliente = item.ApellidoConCliente;
                                objClienteContacto.FecNacConCliente = item.FecNacConCliente;
                                objClienteContacto.CargoConCliente = item.CargoConCliente;
                                objClienteContacto.AreaConCliente = item.AreaConCliente;
                                objClienteContacto.CorConCliente = item.CorConCliente;
                                objClienteContacto.TeleConCliente = item.TeleConCliente;
                                objClienteContacto.operador1 = item.operador1;
                                objClienteContacto.CelConCliente1 = item.CelConCliente1;
                                objClienteContacto.operador2 = item.operador2;
                                objClienteContacto.CelConCliente2 = item.CelConCliente2;
                                objClienteContacto.CodOperador = item.CodOperador;
                                objClienteContacto.CodOperador2 = item.CodOperador2;
                                
                                var consultarExiste = ObtenerClienteContactoPorCodigo(objClienteContacto);
                                if (consultarExiste.Equals(0))
                                {
                                    DocumentoGenerado = RegistrarClienteContactoUnico(objClienteContacto);
                                }
                            }
                        }

                        tran.Commit();
                    }

                    catch (Exception ex)
                    {
                        tran.Rollback();
                        DocumentoGenerado = 0;
                    }
                }
            }

            return DocumentoGenerado;
        }


        public int RegistrarClienteContactoUnico(ClienteContacto objClienteContacto)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        if (objClienteContacto != null)
                        {
                            using (SqlCommand cmd = new SqlCommand("USP_ClienteContactoInsertar", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@CodCliente", SqlDbType.VarChar).Value =    objClienteContacto.CodCliente;
                                cmd.Parameters.Add("@NomConCliente", SqlDbType.VarChar).Value = objClienteContacto.NomConCliente;
                                cmd.Parameters.Add("@ApellidoConCliente", SqlDbType.VarChar).Value = objClienteContacto.ApellidoConCliente;
                                cmd.Parameters.Add("@FecNacConCliente", SqlDbType.DateTime).Value = objClienteContacto.FecNacConCliente;
                                cmd.Parameters.Add("@CargoConCliente", SqlDbType.VarChar).Value = objClienteContacto.CargoConCliente;
                                cmd.Parameters.Add("@CorConCliente", SqlDbType.VarChar).Value = objClienteContacto.CorConCliente;
                                cmd.Parameters.Add("@AreaConCliente", SqlDbType.VarChar).Value = objClienteContacto.AreaConCliente;
                                cmd.Parameters.Add("@TeleConCliente", SqlDbType.VarChar).Value = objClienteContacto.TeleConCliente;
                                cmd.Parameters.Add("@CodOperador", SqlDbType.TinyInt).Value =   objClienteContacto.CodOperador;
                                cmd.Parameters.Add("@CelConCliente1", SqlDbType.VarChar).Value = objClienteContacto.CelConCliente1;
                                cmd.Parameters.Add("@CodOperador2", SqlDbType.TinyInt).Value = objClienteContacto.CodOperador2;
                                cmd.Parameters.Add("@CelConCliente2", SqlDbType.VarChar).Value = objClienteContacto.CelConCliente2;
                                cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = objClienteContacto.UsuCreCodigo;
                                SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.Int);
                                parm2.Size = 7;
                                parm2.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(parm2);

                                cmd.Transaction = tran as SqlTransaction;
                                cmd.ExecuteNonQuery();

                                DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                            }
                        }

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        DocumentoGenerado = 0;
                    }
                }
            }

            return DocumentoGenerado;
        }


        public int ActualizarCliente(ClienteResponse objClienteResponse, List<ClientePlaca> lstPlacas)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_ClienteActualizar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodCliente", SqlDbType.VarChar).Value = objClienteResponse.CodCliente;
                            cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.TinyInt).Value = objClienteResponse.CodTipoDocumento;
                            cmd.Parameters.Add("@NumDocumentoCliente", SqlDbType.VarChar).Value = objClienteResponse.NumDocumentoCliente;
                            cmd.Parameters.Add("@CodTipoCliente", SqlDbType.SmallInt).Value = objClienteResponse.CodTipoCliente;
                            cmd.Parameters.Add("@CodSubTipo", SqlDbType.SmallInt).Value = objClienteResponse.CodSubTipo;
                            cmd.Parameters.Add("@RazSocCliente", SqlDbType.VarChar).Value = objClienteResponse.RazSocCliente;
                            cmd.Parameters.Add("@ApePatCliente", SqlDbType.VarChar).Value = objClienteResponse.ApePatCliente;
                            cmd.Parameters.Add("@ApeMatCliente", SqlDbType.VarChar).Value = objClienteResponse.ApeMatCliente;
                            cmd.Parameters.Add("@NomCliente", SqlDbType.VarChar).Value = objClienteResponse.NomCliente;
                            cmd.Parameters.Add("@NomComCliente", SqlDbType.VarChar).Value = objClienteResponse.NomComCliente;
                            cmd.Parameters.Add("@DirCliente", SqlDbType.VarChar).Value = objClienteResponse.DirCliente;
                            cmd.Parameters.Add("@CorreoCliente", SqlDbType.VarChar).Value = objClienteResponse.Correo;
                            cmd.Parameters.Add("@SexCliente", SqlDbType.Char).Value = objClienteResponse.Sexo;
                            cmd.Parameters.Add("@FechaAniveCliente", SqlDbType.DateTime).Value = objClienteResponse.FechaAniveCliente;
                            cmd.Parameters.Add("@CodFormaPago", SqlDbType.TinyInt).Value = objClienteResponse.CodFormaPago;
                            cmd.Parameters.Add("@PaginaWebCLiente", SqlDbType.VarChar).Value = objClienteResponse.PaginaWeb;
                            cmd.Parameters.Add("@LineaCreditoCliente", SqlDbType.Decimal).Value = objClienteResponse.LineaCreditoCliente_1;
                            cmd.Parameters.Add("@SaldoCreditoCliente", SqlDbType.Decimal).Value = objClienteResponse.SaldoCreditoCliente_1;
                            cmd.Parameters.Add("@UsuVendedorInicio", SqlDbType.SmallInt).Value = objClienteResponse.UsuVendedorInicio;
                            cmd.Parameters.Add("@UsuRepresentante", SqlDbType.SmallInt).Value = objClienteResponse.UsuRepresentante;
                            cmd.Parameters.Add("@UsuModCodigo", SqlDbType.SmallInt).Value = objClienteResponse.UsuMod;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objClienteResponse.Est_Codigo;
                            cmd.Parameters.Add("@CodCate", SqlDbType.Int).Value = objClienteResponse.CodigoCategoria;
                            cmd.Parameters.Add("@CodPolitica", SqlDbType.Int).Value = objClienteResponse.CodPolitica;
                            cmd.Parameters.Add("@CodUsuarioVendedor", SqlDbType.Int).Value = objClienteResponse.CodUsuarioVendedor;
                            cmd.Parameters.Add("@Placa", SqlDbType.VarChar).Value = objClienteResponse.PlacaVehiculo;



                            SqlParameter parm2 = new SqlParameter("@RESULTADO", SqlDbType.Int);
                            parm2.Size = 7;
                            parm2.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(parm2);
                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();
                            DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
                        }


                        foreach (var item in lstPlacas)
                        {

                            using (SqlCommand cmdDetalle = new SqlCommand("USP_InsertarClientePlaca", con))
                            {
                                cmdDetalle.CommandType = CommandType.StoredProcedure;
                                cmdDetalle.Parameters.AddWithValue("@IdRegistro", item.CodigoRegistro);
                                cmdDetalle.Parameters.AddWithValue("@CodCliente", objClienteResponse.CodCliente);
                                cmdDetalle.Parameters.AddWithValue("@Placa", item.PlacaVehiculo);
                                cmdDetalle.Transaction = tran as SqlTransaction;
                                cmdDetalle.ExecuteNonQuery();
                            }
                        }



                        tran.Commit();
                    }

                    catch (Exception ex)
                    {
                        tran.Rollback();
                        DocumentoGenerado = 0;
                    }

                }
            }

            return DocumentoGenerado;
        }



        public int ObtenerClienteContactoPorCodigo(ClienteContacto objClienteContactor)
        {
            int ItemResult = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ClienteContactoPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodClienteContacto", SqlDbType.Int).Value = objClienteContactor.CodClienteContacto;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult = Convert.ToInt16(dr.GetValue(0));
                        }
                    }
                }
            }

            return ItemResult;
        }






    }
}
