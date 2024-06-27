using SIGA.DAO.Comunes;
using SIGA.Entities.Comunes;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Ventas
{
    public class ClienteDao
    {
        private Conexion Conection = new Conexion();

        public ClienteResponse BuscarPorCodigo(string pCodigo)
        {
            var ItemResult = new ClienteResponse();



            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ClienteBuscarPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodCliente", SqlDbType.VarChar).Value = pCodigo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            ItemResult.CodCliente = dr.GetValue(0).ToString();
                            ItemResult.CodTipoDocumento = Convert.ToInt16(dr.GetValue(1));
                            ItemResult.NumDocumentoCliente = dr.GetValue(2).ToString();
                            ItemResult.RazSocCliente = dr.GetValue(3).ToString();
                            ItemResult.ApePatCliente = dr.GetValue(4).ToString();
                            ItemResult.ApeMatCliente = dr.GetValue(5).ToString();
                            ItemResult.NomCliente = dr.GetValue(6).ToString();
                            ItemResult.NomComCliente = dr.GetValue(3).ToString();
                            ItemResult.DirCliente = dr.GetValue(8).ToString();
                            ItemResult.Est_Codigo = dr.GetValue(9).ToString();

                        }
                    }
                }
            }

            return ItemResult;
        }
        public List<ClienteResponse> BuscarPorNombre(string pCodigo)
        {

            var listResult = new List<ClienteResponse>();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ClienteBuscarPorNombre", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NomComCliente", SqlDbType.VarChar).Value = pCodigo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new ClienteResponse();
                            ItemResult.CodCliente = dr.GetValue(0).ToString();
                            ItemResult.CodTipoDocumento = Convert.ToInt16(dr.GetValue(1));
                            ItemResult.NumDocumentoCliente = dr.GetValue(2).ToString();
                            ItemResult.RazSocCliente = dr.GetValue(3).ToString();
                            ItemResult.ApePatCliente = dr.GetValue(4).ToString();
                            ItemResult.ApeMatCliente = dr.GetValue(5).ToString();
                            ItemResult.NomCliente = dr.GetValue(6).ToString();
                            ItemResult.NomComCliente = dr.GetValue(7).ToString();
                            ItemResult.DirCliente = dr.GetValue(8).ToString();
                            ItemResult.Est_Codigo = dr.GetValue(9).ToString();
                            ItemResult.DesTipoDocumento = dr.GetValue(10).ToString();
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }
        public List<ClienteResponse> BuscarPorTipoDocumento(int pCodigoTipoDocumento, string pNumeroDocumento)
        {

            var listResult = new List<ClienteResponse>();
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ClienteBuscarPorTipoDocumento", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = pCodigoTipoDocumento;
                    cmd.Parameters.Add("@NumDocumentoCliente", SqlDbType.VarChar).Value = pNumeroDocumento;
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new ClienteResponse();
                            ItemResult.CodCliente = Convert.ToString(dr.GetValue(0));
                            ItemResult.CodTipoDocumento = Convert.ToInt16(dr.GetValue(1));
                            ItemResult.NumDocumentoCliente = Convert.ToString(dr.GetValue(2));
                            ItemResult.CodTipoCliente = Convert.ToInt16(dr.GetValue(3));
                            ItemResult.CodSubTipo = Convert.ToInt16(dr.GetValue(4));
                            ItemResult.RazSocCliente = Convert.ToString(dr.GetValue(5));
                            ItemResult.ApePatCliente = Convert.ToString(dr.GetValue(6));
                            ItemResult.ApeMatCliente = Convert.ToString(dr.GetValue(7));
                            ItemResult.NomCliente = Convert.ToString(dr.GetValue(8));
                            ItemResult.NomComCliente = Convert.ToString(dr.GetValue(9));
                            ItemResult.DirCliente = Convert.ToString(dr.GetValue(10));
                            ItemResult.Correo = Convert.ToString(dr.GetValue(11));
                            ItemResult.Sexo = Convert.ToString(dr.GetValue(12));
                            ItemResult.FechaAniveCliente = Convert.ToDateTime(dr.GetValue(13));
                            ItemResult.CodFormaPago = Convert.ToInt16(dr.GetValue(14));
                            ItemResult.Est_Codigo = Convert.ToString(dr.GetValue(20));
                            ItemResult.CodPolitica = Convert.ToInt32(dr.GetValue(22));
                            ItemResult.CodUsuarioVendedor = Convert.ToInt32(dr.GetValue(23));
                            ItemResult.PlacaVehiculo = Convert.ToString(dr.GetValue(24));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }

        public string IngresarCliente(ClienteRequest request)
        {
            string DocumentoGenerado = string.Empty;
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            string NumPedido = string.Empty;
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_ClienteInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.TinyInt).Value = request.CodTipoDocumento;
                            cmd.Parameters.Add("@NumDocumentoCliente", SqlDbType.VarChar).Value = request.NumDocumentoCliente;
                            cmd.Parameters.Add("@RazSocCliente", SqlDbType.VarChar).Value = request.RazSocCliente;
                            cmd.Parameters.Add("@DirCliente", SqlDbType.VarChar).Value = request.DirCliente;

                            cmd.Parameters.Add("@CodTipoCliente", SqlDbType.SmallInt).Value = request.TipoCLiente;
                            cmd.Parameters.Add("@CodSubTipo", SqlDbType.SmallInt).Value = request.SubTipoCLiente;


                            cmd.Parameters.Add("@UsuCodigo", SqlDbType.SmallInt).Value = request.CodigoUsuario;


                            SqlParameter parm2 = new SqlParameter("@CodCliente", SqlDbType.VarChar);
                            parm2.Size = 7;
                            parm2.Direction = ParameterDirection.Output; // This is important!
                            cmd.Parameters.Add(parm2);

                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();




                            DocumentoGenerado = Convert.ToString(cmd.Parameters["@CodCliente"].Value);

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


        public string IngresarClienteSubTipo(ClienteResponse request)
        {
            string DocumentoGenerado = string.Empty;
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            string NumPedido = string.Empty;
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_ClienteInsertarSubTipo", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.TinyInt).Value = request.CodTipoDocumento;
                            cmd.Parameters.Add("@NumDocumentoCliente", SqlDbType.VarChar).Value = request.NumDocumentoCliente;
                            cmd.Parameters.Add("@RazSocCliente", SqlDbType.VarChar).Value = request.RazSocCliente;
                            cmd.Parameters.Add("@DirCliente", SqlDbType.VarChar).Value = request.DirCliente == null ? string.Empty : request.DirCliente;
                            cmd.Parameters.Add("@CodSubTipo", SqlDbType.SmallInt).Value = request.CodSubTipo;
                            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = request.Correo == null ? string.Empty : request.Correo;
                            cmd.Parameters.Add("@Usuario", SqlDbType.SmallInt).Value = request.UsuCreCodigo;
                            cmd.Parameters.Add("@CodCate", SqlDbType.Int).Value = request.CodigoCategoria;

                            SqlParameter parm2 = new SqlParameter("@CodCliente", SqlDbType.VarChar);
                            parm2.Size = 7;
                            parm2.Direction = ParameterDirection.Output; // This is important!
                            cmd.Parameters.Add(parm2);
                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();
                            DocumentoGenerado = Convert.ToString(cmd.Parameters["@CodCliente"].Value);

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



        //public List<ClienteResponse> ListarCliente(Proveedor objProveedor)
        //{

        //    var listResult = new List<ClienteResponse>();

        //    using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("USP_LISTAR_CLIENTE", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@ProRazonSocial", SqlDbType.VarChar).Value = objProveedor.ProRazonSocial;
        //            cmd.Parameters.Add("@ProNombreComercial", SqlDbType.VarChar).Value = objProveedor.ProNombreComercial;
        //            cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.TinyInt).Value = objProveedor.CodTipoDocumento;
        //            cmd.Parameters.Add("@EstCodigo", SqlDbType.VarChar).Value = objProveedor.Estado;
        //            cmd.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = objProveedor.NumDocumento;

        //            con.Open();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {

        //                    var ItemResult = new ClienteResponse()
        //                    {
        //                        CodCliente = Convert.ToString(dr.GetValue(0)),
        //                        RazSocCliente = Convert.ToString(dr.GetValue(1)),
        //                        NomComCliente = Convert.ToString(dr.GetValue(2)),
        //                        DesTipoDocumento = Convert.ToString(dr.GetValue(3)),
        //                        NumDocumentoCliente = Convert.ToString(dr.GetValue(4)),
        //                        Est_Codigo = Convert.ToString(dr.GetValue(5))
        //                    };
        //                    //ItemResult.ProCodigo = Convert.ToInt32(dr.GetValue(0));
        //                    //ItemResult.ProRazonSocial = Convert.ToString(dr.GetValue(1));
        //                    //ItemResult.ProNombreComercial = Convert.ToString(dr.GetValue(2));
        //                    //ItemResult.TipoDocumento = Convert.ToString(dr.GetValue(3));
        //                    //ItemResult.NumDocumento = Convert.ToString(dr.GetValue(4));
        //                    //ItemResult.Estado = Convert.ToString(dr.GetValue(5));



        //                    listResult.Add(ItemResult);
        //                }
        //            }
        //        }
        //    }

        //    return listResult;
        //}


        public List<Base> ListarTipoCliente()
        {
            var listResult = new List<Base>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ClienteTipoConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new Base()
                            {

                                Codigo = Convert.ToInt16(dr.GetValue(0)),
                                Descripcion = Convert.ToString(dr.GetValue(1))
                            };

                            listResult.Add(ItemResult);
                        }
                    }
                }

            }
            return listResult;


        }

        public List<ClienteResponse> ObtenerClientesRegistrados(ClienteResponse objEntidad)
        {
            var listResult = new List<ClienteResponse>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_Listar_ClientesRegistrados", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodCliente", SqlDbType.VarChar).Value = objEntidad.CodCliente;
                    cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.TinyInt).Value = objEntidad.CodTipoDocumento;
                    cmd.Parameters.Add("@NumDocumentoCliente", SqlDbType.VarChar).Value = objEntidad.NumDocumentoCliente;
                    cmd.Parameters.Add("@CodTipoCliente", SqlDbType.SmallInt).Value = objEntidad.CodTipoCliente;
                    cmd.Parameters.Add("@CodSubTipo", SqlDbType.SmallInt).Value = objEntidad.CodSubTipo;
                    cmd.Parameters.Add("@RazSocCliente", SqlDbType.VarChar).Value = objEntidad.RazSocCliente;
                    cmd.Parameters.Add("@NomComCliente", SqlDbType.VarChar).Value = objEntidad.NomComCliente;
                    cmd.Parameters.Add("@NomCliente", SqlDbType.VarChar).Value = objEntidad.NomCliente;
                    cmd.Parameters.Add("@SexCliente", SqlDbType.Char).Value = objEntidad.Sexo;
                    cmd.Parameters.Add("@DirCliente", SqlDbType.VarChar).Value = objEntidad.DirCliente;
                    cmd.Parameters.Add("@CodFormaPago", SqlDbType.TinyInt).Value = objEntidad.CodFormaPago;
                    cmd.Parameters.Add("@LineaCreditoCliente_1", SqlDbType.Decimal).Value = objEntidad.LineaCreditoCliente_1;
                    cmd.Parameters.Add("@LineaCreditoCliente_2", SqlDbType.Decimal).Value = objEntidad.LineaCreditoCliente_2;
                    cmd.Parameters.Add("@SaldoCreditoCliente_1", SqlDbType.Decimal).Value = objEntidad.SaldoCreditoCliente_1;
                    cmd.Parameters.Add("@SaldoCreditoCliente_2", SqlDbType.Decimal).Value = objEntidad.SaldoCreditoCliente_2;
                    cmd.Parameters.Add("@UsuVendedorInicio", SqlDbType.SmallInt).Value = objEntidad.UsuVendedorInicio;
                    cmd.Parameters.Add("@UsuRepresentante", SqlDbType.SmallInt).Value = objEntidad.UsuRepresentante;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objEntidad.Est_Codigo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new ClienteResponse();
                            ItemResult.CodCliente = Convert.ToString(dr.GetValue(0));
                            ItemResult.DesTipoDocumento = Convert.ToString(dr.GetValue(1));
                            ItemResult.NumDocumentoCliente = Convert.ToString(dr.GetValue(2));
                            ItemResult.DesTipoCliente = Convert.ToString(dr.GetValue(3));
                            ItemResult.DesSubTipo = Convert.ToString(dr.GetValue(4));
                            ItemResult.RazSocCliente = Convert.ToString(dr.GetValue(5));
                            ItemResult.DirCliente = Convert.ToString(dr.GetValue(6));
                            ItemResult.Est_Codigo = Convert.ToString(dr.GetValue(7));
                            ItemResult.DesPolitica = Convert.ToString(dr.GetValue(8));
                            ItemResult.Vendedor = Convert.ToString(dr.GetValue(9));
                            ItemResult.CodPolitica = Convert.ToInt32(dr.GetValue(10));
                            ItemResult.CodUsuarioVendedor = Convert.ToInt32(dr.GetValue(11));
                            ItemResult.PlacaVehiculo = Convert.ToString(dr.GetValue(12));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }



        public string RegistrarCliente(ClienteResponse objClienteResponse, List<ClientePlaca> lstPlaca)
        {
            string DocumentoGenerado = "0";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {

                    try
                    {
                        if (objClienteResponse != null)
                        {
                            using (SqlCommand cmd = new SqlCommand("USP_RegistrarCliente", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
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
                                cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = objClienteResponse.UsuCreCodigo;
                                cmd.Parameters.Add("@CodCate", SqlDbType.Int).Value = objClienteResponse.CodigoCategoria;
                                cmd.Parameters.Add("@CodPolitica", SqlDbType.Int).Value = objClienteResponse.CodPolitica;
                                cmd.Parameters.Add("@CodUsuarioVendedor", SqlDbType.Int).Value = objClienteResponse.CodUsuarioVendedor;
                                cmd.Parameters.Add("@Placa", SqlDbType.VarChar).Value = objClienteResponse.PlacaVehiculo;
                                SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.VarChar);
                                parm2.Size = 7;
                                parm2.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(parm2);
                                cmd.Transaction = tran as SqlTransaction;


                                cmd.ExecuteNonQuery();
                                DocumentoGenerado = Convert.ToString(cmd.Parameters["@Resultado"].Value);
                            }



                            foreach (var item in lstPlaca)
                            {

                                using (SqlCommand cmdDetalle = new SqlCommand("USP_InsertarClientePlaca", con))
                                {
                                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                                    cmdDetalle.Parameters.AddWithValue("@IdRegistro", item.CodigoRegistro);
                                    cmdDetalle.Parameters.AddWithValue("@CodCliente", DocumentoGenerado);
                                    cmdDetalle.Parameters.AddWithValue("@Placa", item.PlacaVehiculo);
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

            return DocumentoGenerado;
        }



        public ClienteResponse ObtenerClientePorCodigo(ClienteResponse objEntidad)
        {
            var ItemResult = new ClienteResponse();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ObtenerClientePorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodCliente", SqlDbType.VarChar).Value = objEntidad.CodCliente;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodCliente = Convert.ToString(dr.GetValue(0));
                            ItemResult.CodTipoDocumento = Convert.ToInt16(dr.GetValue(1));
                            ItemResult.NumDocumentoCliente = Convert.ToString(dr.GetValue(2));
                            ItemResult.CodTipoCliente = Convert.ToInt16(dr.GetValue(3));
                            ItemResult.CodSubTipo = Convert.ToInt16(dr.GetValue(4));
                            ItemResult.RazSocCliente = Convert.ToString(dr.GetValue(5));
                            ItemResult.ApePatCliente = Convert.ToString(dr.GetValue(6));
                            ItemResult.ApeMatCliente = Convert.ToString(dr.GetValue(7));
                            ItemResult.NomCliente = Convert.ToString(dr.GetValue(8));
                            ItemResult.NomComCliente = Convert.ToString(dr.GetValue(9));
                            ItemResult.DirCliente = Convert.ToString(dr.GetValue(10));
                            ItemResult.Correo = Convert.ToString(dr.GetValue(11));
                            ItemResult.Sexo = Convert.ToString(dr.GetValue(12));
                            ItemResult.FechaAniveCliente = Convert.ToDateTime(dr.GetValue(13));
                            ItemResult.CodFormaPago = Convert.ToInt16(dr.GetValue(14));
                            ItemResult.Est_Codigo = Convert.ToString(dr.GetValue(20));
                            ItemResult.CodPolitica = Convert.ToInt32(dr.GetValue(22));
                            ItemResult.CodUsuarioVendedor = Convert.ToInt32(dr.GetValue(23));
                            ItemResult.PlacaVehiculo = Convert.ToString(dr.GetValue(24));


                        }
                    }
                }
            }

            return ItemResult;
        }


        public List<ClientePlaca> ListarPlacas(string CodigoCliente)
        {
            var listResult = new List<ClientePlaca>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ClienteCargaPlaca", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodCliente", CodigoCliente);


                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new ClientePlaca()
                            {
                                CodigoRegistro = Convert.ToInt16(dr.GetValue(0)),
                                PlacaVehiculo = Convert.ToString(dr.GetValue(1))
                            };

                            listResult.Add(ItemResult);
                        }
                    }
                }

            }
            return listResult;
        }


        public int ClienteEliminarPlaca(int CodigoRegistro)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("USP_ClientePlacaEliminar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdRegistro", CodigoRegistro);
                    cmd.ExecuteNonQuery();
                }
            }

            return DocumentoGenerado;
        }

    }

}