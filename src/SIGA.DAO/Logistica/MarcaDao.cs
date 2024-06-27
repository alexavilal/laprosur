using SIGA.DAO.Comunes;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Logistica
{
    public class MarcaDao
    {
        private Conexion Conection = new Conexion();

        public List<Marca> Listar(string Estado)
        {
            var listResult = new List<Marca>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_MarcaConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = Estado;
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new Marca();
                            ItemResult.CodMarca = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesMarca = dr.GetValue(1).ToString();
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }


        public List<Marca> ListarMarcas()
        {
            var listResult = new List<Marca>();
            /*
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_LISTAR_MARCAS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Marca();
                            ItemResult.CodMarca = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesMarca = dr.GetValue(1).ToString();
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }*/

            return listResult;
        }


        public DataTable ListarMarcaCriterio(Int16? CodMarca, string Descripcion, string Estado)
        {
            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";


            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarMarcaCriterio", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodMarca", SqlDbType.SmallInt).Value = CodMarca;
                    cmd.Parameters.Add("@DesMarca", SqlDbType.VarChar).Value = Descripcion;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = Estado;

                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;


        }


        public int RegistrarMarca(Marca objPerfil)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objPerfil != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_MarcarInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@DesMarca", SqlDbType.VarChar).Value = objPerfil.DesMarca;
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = objPerfil.UsuCreCodigo;
                            SqlParameter parm2 = new SqlParameter("@CodMarca", SqlDbType.SmallInt);
                            parm2.Size = 7;
                            parm2.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(parm2);
                            cmd.ExecuteNonQuery();

                            DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@CodMarca"].Value);
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


        public int ActualizarMarca(Marca objPerfil)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();



                try
                {
                    if (objPerfil != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_MarcarActualizar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodMarca", SqlDbType.SmallInt).Value = objPerfil.CodMarca;
                            cmd.Parameters.Add("@DesMarca", SqlDbType.VarChar).Value = objPerfil.DesMarca;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objPerfil.Estado;
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = objPerfil.UsuCreCodigo;


                            cmd.ExecuteNonQuery();


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


        public DataTable ConsultarMarcaPorCodigo(Int16 CodigoMarca)
        {
            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";


            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_MarcaPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodMarca", SqlDbType.SmallInt).Value = CodigoMarca;


                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;


        }

        public DataTable ConsultarMarcas()
        {
            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";


            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ConsultarMarcas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;



                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;


        }
    }
}
