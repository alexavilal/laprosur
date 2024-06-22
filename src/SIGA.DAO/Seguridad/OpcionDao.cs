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
    public  class OpcionDao
    {
        private Conexion Conection = new Conexion();

        public DataTable ObtenerUsuariosPorOpcion(int CodigoOpcion)
        {
            DataTable dt = new DataTable();
           

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_UsuariosPorOpcion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodOpcion", SqlDbType.SmallInt).Value = CodigoOpcion;
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            return dt;
        }

        public List<Opcion> ObtenerOpciones(Opcion objOpcion)
        {
            var listResult = new List<Opcion>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarOpciones", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodOpcion", SqlDbType.SmallInt).Value = objOpcion.CodOpcion;
                    cmd.Parameters.Add("@CodModulo", SqlDbType.SmallInt).Value = objOpcion.CodModulo;
                    cmd.Parameters.Add("@DesOpcion", SqlDbType.VarChar).Value = objOpcion.DesOpcion;                    
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objOpcion.EstCodigo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Opcion();
                            ItemResult.CodOpcion = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesOpcion = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(2));
                            ItemResult.DesModulo = Convert.ToString(dr.GetValue(3));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }


        public int RegistrarOpcion(Opcion objOpcion)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objOpcion != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_OpcionInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodOpcion", SqlDbType.SmallInt).Value = objOpcion.CodOpcion;
                            cmd.Parameters.Add("@CodModulo", SqlDbType.SmallInt).Value = objOpcion.CodModulo;
                            cmd.Parameters.Add("@DesOpcion", SqlDbType.VarChar).Value = objOpcion.DesOpcion;
                            cmd.Parameters.Add("@RutOpcion", SqlDbType.VarChar).Value = objOpcion.RutOpcion;
                            cmd.Parameters.Add("@UsuCre", SqlDbType.SmallInt).Value = objOpcion.UsuCre;
                          

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


        public int ActualizarOpcion(Opcion objOpcion)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objOpcion != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_OpcionActualiza", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodOpcion", SqlDbType.SmallInt).Value = objOpcion.CodOpcion;
                            cmd.Parameters.Add("@CodModulo", SqlDbType.SmallInt).Value = objOpcion.CodModulo;
                            cmd.Parameters.Add("@DesOpcion", SqlDbType.VarChar).Value = objOpcion.DesOpcion;
                            cmd.Parameters.Add("@RutOpcion", SqlDbType.VarChar).Value = objOpcion.RutOpcion;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objOpcion.EstCodigo;
                            cmd.Parameters.Add("@UsuMod", SqlDbType.SmallInt).Value = objOpcion.UsuMod;
                             
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


        public Opcion ObtenerOpcionPorCodigo(Opcion objOpcion)
        {
            var ItemResult = new Opcion();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_OpcionPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodOpcion", SqlDbType.SmallInt).Value = objOpcion.CodOpcion;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodOpcion = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.CodModulo = Convert.ToInt16(dr.GetValue(1));
                            ItemResult.DesOpcion = Convert.ToString(dr.GetValue(2));
                            ItemResult.RutOpcion = Convert.ToString(dr.GetValue(3));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(4));                        
                        }
                    }
                }
            }

            return ItemResult;
        }





    }
}
