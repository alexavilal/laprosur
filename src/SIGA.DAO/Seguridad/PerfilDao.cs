using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Comunes;
using SIGA.Entities.Administrador;
using System.Data.SqlClient;
using System.Data;

namespace SIGA.DAO.Seguridad
{
    public class PerfilDao
    {
        private Conexion Conection = new Conexion();

        public List<Perfil> ObtenerPerfiles(Perfil objPerfil)
        {
            var listResult = new List<Perfil>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarPerfiles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodPerfil", SqlDbType.SmallInt).Value = objPerfil.CodPerfil;
                    cmd.Parameters.Add("@DesPerfil", SqlDbType.VarChar).Value = objPerfil.DesPerfil;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objPerfil.EstadoPerfil;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Perfil();
                            ItemResult.CodPerfil = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesPerfil = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstadoPerfil = Convert.ToString(dr.GetValue(2));

                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }

        public List<PerfilUsuario> ObtenerPerfilesUsuarioPorCodigo(PerfilUsuario objPerfil)
        {
            var listResult = new List<PerfilUsuario>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarPerfilesUsuarioPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UsuCodigo", SqlDbType.SmallInt).Value = objPerfil.UsuCodigo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new PerfilUsuario();
                            ItemResult.CodPerfil = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesPerfil = Convert.ToString(dr.GetValue(1));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }



        public int RegistrarPerfil(Perfil objPerfil, List<OpcionPerfil> ListaOpcionPerfilUsuario)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        if (objPerfil != null)
                        {
                            using (SqlCommand cmd = new SqlCommand("USP_PerfilInsertar", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@DesPerfil", SqlDbType.VarChar).Value = objPerfil.DesPerfil;
                                cmd.Parameters.Add("@UsuCre", SqlDbType.SmallInt).Value = objPerfil.UsuCreacion;
                                SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.Int);
                                parm2.Size = 7;
                                parm2.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(parm2);
                                cmd.Transaction = tran as SqlTransaction;
                                cmd.ExecuteNonQuery();

                                DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                            }
                        }
                        if (ListaOpcionPerfilUsuario != null)
                        {
                            foreach (var item in ListaOpcionPerfilUsuario)
                            {
                                OpcionPerfil objPerfilUsuario = new OpcionPerfil();
                                objPerfilUsuario.CodOpcion = item.CodOpcion;
                                objPerfilUsuario.CodPerfil = Convert.ToInt16(DocumentoGenerado);
                                objPerfilUsuario.UsuCreacion = item.UsuCreacion;
                                RegistrarOpcionesPerfil(objPerfilUsuario);
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

        public int RegistrarOpcionesPerfil(OpcionPerfil objOpcionPerfil)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objOpcionPerfil != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_OpcionPerfilInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodPerfil", SqlDbType.SmallInt).Value = objOpcionPerfil.CodPerfil;
                            cmd.Parameters.Add("@CodOpcion", SqlDbType.SmallInt).Value = objOpcionPerfil.CodOpcion;
                            cmd.Parameters.Add("@UsuCre", SqlDbType.SmallInt).Value = objOpcionPerfil.UsuCreacion;
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


        public int ActualizarPerfil(Perfil objPerfil, List<OpcionPerfil> ListaOpcionPerfil, OpcionPerfil objOpcionPerfil)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        if (objPerfil != null)
                        {
                            using (SqlCommand cmd = new SqlCommand("USP_PerfilActualiza", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@CodPerfil", SqlDbType.SmallInt).Value = objPerfil.CodPerfil;
                                cmd.Parameters.Add("@DesPerfil", SqlDbType.VarChar).Value = objPerfil.DesPerfil;
                                cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objPerfil.EstadoPerfil;
                                cmd.Parameters.Add("@UsuMod", SqlDbType.SmallInt).Value = objPerfil.UsuModifica;
                                SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.Int);
                                parm2.Size = 7;
                                parm2.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(parm2);
                                cmd.Transaction = tran as SqlTransaction;
                                cmd.ExecuteNonQuery();

                                DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                            }
                        }

                        EliminarOpcionPerfil(objOpcionPerfil);

                        if (ListaOpcionPerfil != null)
                        {
                            if (ListaOpcionPerfil.Count > 0)
                            {
                                foreach (var item in ListaOpcionPerfil)
                                {
                                    OpcionPerfil objPerfilUsuario = new OpcionPerfil();
                                    objPerfilUsuario.CodOpcion = item.CodOpcion; //Convert.ToInt16(objOpcionPerfil.CodOpcion);
                                    objPerfilUsuario.CodPerfil = item.CodPerfil;
                                    objPerfilUsuario.UsuCreacion = item.UsuCreacion;
                                    RegistrarOpcionesPerfil(objPerfilUsuario);
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

        public int EliminarOpcionPerfil(OpcionPerfil OpcionPerfil)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("USP_OpcionPerfilEliminar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CodPerfil", SqlDbType.SmallInt).Value = OpcionPerfil.CodPerfil;
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

        public List<OpcionPerfil> ObtenerOpcionesPerfil(OpcionPerfil objOpcion)
        {
            var listResult = new List<OpcionPerfil>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarOpcionPerfil", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodPerfil", SqlDbType.SmallInt).Value = objOpcion.CodPerfil;
                    cmd.Parameters.Add("@CodModulo", SqlDbType.SmallInt).Value = objOpcion.CodModulo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new OpcionPerfil();
                            ItemResult.CodOpcion = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesOpcion = Convert.ToString(dr.GetValue(1));
                            ItemResult.CodModulo = Convert.ToInt16(dr.GetValue(2));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }


        public Perfil ObtenerPerfilPorCodigo(Perfil objPerfil)
        {
            var ItemResult = new Perfil();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_PerfilPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodPerfil", SqlDbType.SmallInt).Value = objPerfil.CodPerfil;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodPerfil = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesPerfil = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstadoPerfil = Convert.ToString(dr.GetValue(2));
                        }
                    }
                }
            }

            return ItemResult;
        }


        public List<PerfilUsuario> ListarPerfilesUsuario(Usuario objUsuario)
        {
            var listResult = new List<PerfilUsuario>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarPerfilesUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UsuLogin", SqlDbType.VarChar).Value = objUsuario.Nombre;
                    cmd.Parameters.Add("@UsuClave", SqlDbType.VarChar).Value = objUsuario.Clave;
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new PerfilUsuario();
                            ItemResult.CodPerfil = Convert.ToInt16(dr.GetValue(0));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }


    }
}
