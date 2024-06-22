using SIGA.DAO.Comunes;
using SIGA.Entities.Administrador;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace SIGA.DAO.Administrador
{
    public class ModuloDao
    {
        private Conexion Conection = new Conexion();


        public List<Modulo> ObtenerModulos(Modulo objModulo)
        {
            var listResult = new List<Modulo>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarModulos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodModulo", SqlDbType.SmallInt).Value = objModulo.CodigoModulo;
                    cmd.Parameters.Add("@DesModulo", SqlDbType.VarChar).Value = objModulo.DescripcionModulo;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objModulo.EstadoModulo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Modulo();
                            ItemResult.CodigoModulo = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DescripcionModulo = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstadoModulo = Convert.ToString(dr.GetValue(2));

                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }


        public int RegistrarModulo(Modulo objModulo)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objModulo != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_ModuloInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@DesModulo", SqlDbType.VarChar).Value = objModulo.DescripcionModulo;
                            cmd.Parameters.Add("@UsuCre", SqlDbType.SmallInt).Value = objModulo.UsuCreacion;
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


        public int ActualizarModulo(Modulo objModulo)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objModulo != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_ModuloActualiza", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodModulo", SqlDbType.SmallInt).Value = objModulo.CodigoModulo;
                            cmd.Parameters.Add("@DesModulo", SqlDbType.VarChar).Value = objModulo.DescripcionModulo;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objModulo.EstadoModulo;
                            cmd.Parameters.Add("@UsuMod", SqlDbType.SmallInt).Value = objModulo.UsuModifica;
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

        public Modulo ObtenerModuloPorCodigo(Modulo objModulo)
        {
            var ItemResult = new Modulo();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ModulosPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodModulo", SqlDbType.SmallInt).Value = objModulo.CodigoModulo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodigoModulo = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DescripcionModulo = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstadoModulo = Convert.ToString(dr.GetValue(2));
                        }
                    }
                }
            }

            return ItemResult;
        }
    }
}
