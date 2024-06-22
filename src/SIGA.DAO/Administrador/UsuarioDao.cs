using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SIGA.Entities.Administrador;
using SIGA.DAO.Comunes;
using System.Data;

namespace SIGA.DAO.Administrador
{
    public class UsuarioDao
    {

        private Conexion Conection = new Conexion();

        public List<Usuario> ObtenerUsuarios(Usuario objUsuario)
        {
            var listResult = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UsuApellidoPaterno", SqlDbType.VarChar).Value = objUsuario.ApellidoPaterno;
                    cmd.Parameters.Add("@UsuApellidoMaterno", SqlDbType.VarChar).Value = objUsuario.ApellidoMaterno;
                    cmd.Parameters.Add("@UsuNombres", SqlDbType.VarChar).Value = objUsuario.Nombre;
                    cmd.Parameters.Add("@UsuLogin", SqlDbType.VarChar).Value = objUsuario.IdentificadorUsuario;
                    cmd.Parameters.Add("@UsuCorreo", SqlDbType.VarChar).Value = objUsuario.CorreoElectronico;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objUsuario.CodigoEstadoUsuario;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Usuario();
                            ItemResult.CodigoUsuario = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.ApellidoPaterno = Convert.ToString(dr.GetValue(1));
                            ItemResult.ApellidoMaterno = Convert.ToString(dr.GetValue(2));
                            ItemResult.Nombre = Convert.ToString(dr.GetValue(3));
                            ItemResult.IdentificadorUsuario = Convert.ToString(dr.GetValue(4));
                            ItemResult.CorreoElectronico = Convert.ToString(dr.GetValue(5));
                            ItemResult.CodigoEstadoUsuario = Convert.ToString(dr.GetValue(6));
                            ItemResult.Clave = Convert.ToString(dr.GetValue(7));
                            ItemResult.NombreBusqueda = Convert.ToString(dr.GetValue(3)) + " " + Convert.ToString(dr.GetValue(1)) + " " +  Convert.ToString(dr.GetValue(2));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }


        public int RegistrarUsuario(SIGA.Entities.Administrador.Usuario objUsuario, List<PerfilUsuario> ListaPerfilUsuario)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        if (objUsuario != null)
                        {
                            using (SqlCommand cmd = new SqlCommand("USP_UsuarioInsertar", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@UsuApellidoPaterno", SqlDbType.VarChar).Value = objUsuario.ApellidoPaterno;
                                cmd.Parameters.Add("@UsuApellidoMaterno", SqlDbType.VarChar).Value = objUsuario.ApellidoMaterno;
                                cmd.Parameters.Add("@UsuNombres", SqlDbType.VarChar).Value = objUsuario.Nombre;
                                cmd.Parameters.Add("@UsuLogin", SqlDbType.VarChar).Value = objUsuario.IdentificadorUsuario;
                                cmd.Parameters.Add("@UsuCorreo", SqlDbType.VarChar).Value = objUsuario.CorreoElectronico;
                                cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = objUsuario.Clave;
                                cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = objUsuario.UsuarioRegistro;
                                cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objUsuario.CodTipoDocumento;
                                cmd.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = objUsuario.NumeroDocumento;
                                cmd.Parameters.Add("@CodCargo ", SqlDbType.Int).Value = objUsuario.CodCargo;


                                SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.Int);
                                parm2.Size = 7;
                                parm2.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(parm2);
                                cmd.Transaction = tran as SqlTransaction;
                                cmd.ExecuteNonQuery();

                                DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                            }
                        }

                        if (ListaPerfilUsuario != null)
                        {
                            foreach (var item in ListaPerfilUsuario)
                            {
                                PerfilUsuario objPerfilUsuario = new PerfilUsuario();
                                objPerfilUsuario.UsuCodigo = Convert.ToInt16 ( DocumentoGenerado);
                                objPerfilUsuario.CodPerfil = item.CodPerfil;
                                objPerfilUsuario.UsuCreacion = item.UsuCreacion;
                                RegistrarPerfilUsuario(objPerfilUsuario);
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


        public int RegistrarPerfilUsuario(PerfilUsuario objPerfilUsuario)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objPerfilUsuario != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_PerfilUsuarioInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@UsuCodigo", SqlDbType.SmallInt).Value = objPerfilUsuario.UsuCodigo;
                            cmd.Parameters.Add("@CodPerfil", SqlDbType.SmallInt).Value = objPerfilUsuario.CodPerfil;
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = objPerfilUsuario.UsuCreacion ;
                            SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.Int);
                            parm2.Size = 7;
                            parm2.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(parm2);
                            cmd.ExecuteNonQuery();

                            DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                        }
                    }
                }

                catch (Exception ex)
                {
                    DocumentoGenerado = 0;
                }
            }

            return DocumentoGenerado;
        }




        public int ActualizarUsuario(SIGA.Entities.Administrador.Usuario objUsuario, List<PerfilUsuario> ListaPerfilUsuario)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        if (objUsuario != null)
                        {
                            using (SqlCommand cmd = new SqlCommand("USP_UsuarioActualiza", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@UsuCodigo", SqlDbType.SmallInt).Value = objUsuario.CodigoUsuario;
                                cmd.Parameters.Add("@UsuApellidoPaterno", SqlDbType.VarChar).Value = objUsuario.ApellidoPaterno;
                                cmd.Parameters.Add("@UsuApellidoMaterno", SqlDbType.VarChar).Value = objUsuario.ApellidoMaterno;
                                cmd.Parameters.Add("@UsuNombres", SqlDbType.VarChar).Value = objUsuario.Nombre;
                                cmd.Parameters.Add("@UsuLogin", SqlDbType.VarChar).Value = objUsuario.IdentificadorUsuario;
                                cmd.Parameters.Add("@UsuCorreo", SqlDbType.VarChar).Value = objUsuario.CorreoElectronico;
                                cmd.Parameters.Add("@EstCodigo", SqlDbType.VarChar).Value = objUsuario.CodigoEstadoUsuario;
                                cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = objUsuario.Clave;
                                cmd.Parameters.Add("@UsuModCodigo", SqlDbType.SmallInt).Value = objUsuario.UsuarioUltimaModificacion;
                                cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objUsuario.CodTipoDocumento;
                                cmd.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = objUsuario.NumeroDocumento;
                                cmd.Parameters.Add("@CodCargo ", SqlDbType.Int).Value = objUsuario.CodCargo;

                                SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.Int);
                                parm2.Size = 7;
                                parm2.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(parm2);
                                cmd.Transaction = tran as SqlTransaction;
                                cmd.ExecuteNonQuery();

                                DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                            }
                        }

                        if (ListaPerfilUsuario != null)
                        {
                            if (ListaPerfilUsuario.Count>0)
                            {
                                EliminarPerfilUsuario(objUsuario.CodigoUsuario);

                                foreach (var item in ListaPerfilUsuario)
                                {
                                    PerfilUsuario objPerfilUsuario = new PerfilUsuario();
                                    objPerfilUsuario.UsuCodigo = Convert.ToInt16(objUsuario.CodigoUsuario);
                                    objPerfilUsuario.CodPerfil = item.CodPerfil;
                                    objPerfilUsuario.UsuCreacion = item.UsuCreacion;
                                    RegistrarPerfilUsuario(objPerfilUsuario);
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


        public int EliminarPerfilUsuario(int codUsuario)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    
                    using (SqlCommand cmd = new SqlCommand("USP_PerfilUsuarioEliminar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UsuCodigo", SqlDbType.SmallInt).Value = codUsuario;
                        SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.Int);
                        parm2.Size = 7;
                        parm2.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(parm2);
                        cmd.ExecuteNonQuery();

                        DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                    }
                     
                }

                catch (Exception ex)
                {
                    DocumentoGenerado = 0;
                }
            }

            return DocumentoGenerado;
        }



        public Usuario ObtenerUsuarioPorCodigo(Usuario objUsuario)
        {
            var ItemResult = new Usuario();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_UsuarioPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UsuCodigo", SqlDbType.SmallInt).Value = objUsuario.CodigoUsuario;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodigoUsuario = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.ApellidoPaterno = Convert.ToString(dr.GetValue(1));
                            ItemResult.ApellidoMaterno = Convert.ToString(dr.GetValue(2));
                            ItemResult.Nombre = Convert.ToString(dr.GetValue(3));
                            ItemResult.IdentificadorUsuario = Convert.ToString(dr.GetValue(4));
                            ItemResult.CorreoElectronico = Convert.ToString(dr.GetValue(5));
                            ItemResult.CodigoEstadoUsuario = Convert.ToString(dr.GetValue(6));
                            ItemResult.Clave = Convert.ToString(dr.GetValue(7));
                            ItemResult.CodTipoDocumento = Convert.ToInt32(dr.GetValue(8));
                            ItemResult.NumeroDocumento = Convert.ToString(dr.GetValue(9));
                            ItemResult.CodCargo = Convert.ToInt32(dr.GetValue(10));
                        }
                    }
                }
            }

            return ItemResult;
        }



        public int ValidarUsuario(Usuario objUsuario)
        {
            int NumRegistros = 0;
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ValidarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UsuLogin", SqlDbType.VarChar).Value = objUsuario.IdentificadorUsuario;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            NumRegistros = Convert.ToInt16(dr.GetValue(0));                         
                        }
                    }
                }
            }

            return NumRegistros;
        }


        public int ValidarClave(Usuario objUsuario)
        {
            int NumRegistros = 0;
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ValidarClave", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UsuClave", SqlDbType.VarChar).Value = objUsuario.Clave;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            NumRegistros = Convert.ToInt16(dr.GetValue(0));
                        }
                    }
                }
            }

            return NumRegistros;
        }



        public int ValidarCuentaUsuario(Usuario objUsuario)
        {
            int NumRegistros = 0;
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ValidarCuentaUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UsuCodigo", SqlDbType.SmallInt).Value = objUsuario.CodigoUsuario;
                    cmd.Parameters.Add("@UsuLogin", SqlDbType.VarChar).Value = objUsuario.IdentificadorUsuario;
                   
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            NumRegistros = Convert.ToInt16(dr.GetValue(0));
                        }
                    }
                }
            }

            return NumRegistros;
        }


        public DataTable ValidarIngresoUsuario(string Login, string Clave)
        {
            DataTable dtUsuario = new DataTable();
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_UsuarioValidarIngreso", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UsuLogin", SqlDbType.VarChar).Value = Login;
                    cmd.Parameters.Add("@UsuClave", SqlDbType.VarChar).Value = Clave;

                    con.Open();
                    dtUsuario.Load(cmd.ExecuteReader());
                }   
            }

            string conexion = Conection.cadenaConexion();

            return dtUsuario;
        }


        public DataTable ObtenerPerfilesPorUsuario(Int16 Usuario,Int16 Perfil)
        {
            DataTable dtUsuario = new DataTable();
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_PerfilesPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UsuCodigo", SqlDbType.SmallInt).Value = Usuario;
                    cmd.Parameters.Add("@CodPerfil", SqlDbType.SmallInt).Value = Perfil;

                    con.Open();
                    dtUsuario.Load(cmd.ExecuteReader());
                }
            }

            return dtUsuario;
        }

        public List<Usuario> ObtenerContactoRepresentante()
        {
            var listResult = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_Listar_ContactoRepresentante", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Usuario();
                            ItemResult.CodigoUsuario = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.Nombre = Convert.ToString(dr.GetValue(1));

                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }


        public DataTable ObtenerOpcionesPorUsuario(int CodigoUsuario)
        {
            DataTable dtUsuario = new DataTable();
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarOpcionesPorUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodigoUsuario", SqlDbType.SmallInt).Value = CodigoUsuario;
                    con.Open();
                    dtUsuario.Load(cmd.ExecuteReader());
                }
            }

            return dtUsuario;

        }

        public DataTable BuscarUsuarioPorClave(string Clave)
        {
            DataTable dtUsuario = new DataTable();
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_BuscarPorUsuarioPorClave", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UsuClave", SqlDbType.VarChar).Value = Clave;
                    con.Open();
                    dtUsuario.Load(cmd.ExecuteReader());
                }
            }

            return dtUsuario;

        }


    }
}
