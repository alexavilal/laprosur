using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Comunes;
using SIGA.Entities.Logistica;
using System.Data.SqlClient;
using System.Data;

namespace SIGA.DAO.Logistica
{
    public class OperadorDao
    {

        private Conexion Conection = new Conexion();

        public List<Operador> ListarOperador()
        {
            var listResult = new List<Operador>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_LISTAR_OPERADORES", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Operador();
                            ItemResult.CodOperador = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesOperador = dr.GetValue(1).ToString();
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }

       


        public List<Operador> ObtenerOperadores(Operador objOperador)
        {
            var listResult = new List<Operador>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarOperador", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodOperador", SqlDbType.Int).Value = objOperador.CodOperador;
                    cmd.Parameters.Add("@DesOperador", SqlDbType.VarChar).Value = objOperador.DesOperador;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objOperador.EstCodigo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Operador();
                            ItemResult.CodOperador = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesOperador = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(2));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }




        public int RegistrarOperador(Operador objOperador)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objOperador != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_OperadorInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@DesOperador", SqlDbType.VarChar).Value = objOperador.DesOperador;
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = objOperador.UsuCre;
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


        public int ActualizarOperador(Operador objOperador)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objOperador != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_OperadorActualiza", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodOperador", SqlDbType.Int).Value = objOperador.CodOperador;
                            cmd.Parameters.Add("@DesOperador", SqlDbType.VarChar).Value = objOperador.DesOperador;
                            cmd.Parameters.Add("@UsuMod", SqlDbType.SmallInt).Value = objOperador.UsuMod;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objOperador.EstCodigo;
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


        public Operador ObtenerOperadorPorCodigo(Operador objOperador)
        {
            var ItemResult = new Operador();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_OperadorPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodOperador", SqlDbType.Int).Value = objOperador.CodOperador;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodOperador = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesOperador = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(2));
                        }
                    }
                }
            }

            return ItemResult;
        }






    }
}
