using SIGA.DAO.Comunes;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace SIGA.DAO.Logistica
{
    public class SedeDao
    {
        private Conexion Conection = new Conexion();

        public List<Sede> Listar()
        {

            var listResult = new List<Sede>();

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_SedeConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new Sede();
                            ItemResult.CodSede = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesSede = dr.GetValue(1).ToString();
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }


        public List<Sede> ObtenerSedes(Sede objSede)
        {
            var listResult = new List<Sede>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarSede", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodSede", SqlDbType.TinyInt).Value = objSede.CodSede;
                    cmd.Parameters.Add("@DesSede", SqlDbType.VarChar).Value = objSede.DesSede;
                    cmd.Parameters.Add("@DirSede", SqlDbType.VarChar).Value = objSede.DirSede;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objSede.EstCodigo;
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Sede();
                            ItemResult.CodSede = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesSede = Convert.ToString(dr.GetValue(1));
                            ItemResult.DirSede = Convert.ToString(dr.GetValue(2));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(3));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }




        public int RegistrarSede(Sede objSede)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objSede != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_SedeInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@DesSede", SqlDbType.VarChar).Value = objSede.DesSede;
                            cmd.Parameters.Add("@DirSede", SqlDbType.VarChar).Value = objSede.DirSede;
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = objSede.UsuCre;
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


        public int ActualizarSede(Sede objSede)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objSede != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_SedeActualiza", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodSede", SqlDbType.TinyInt).Value = objSede.CodSede;
                            cmd.Parameters.Add("@DesSede", SqlDbType.VarChar).Value = objSede.DesSede;
                            cmd.Parameters.Add("@DirSede", SqlDbType.VarChar).Value = objSede.DirSede;
                            cmd.Parameters.Add("@UsuMod", SqlDbType.SmallInt).Value = objSede.UsuMod;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objSede.EstCodigo;
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


        public Sede ObtenerSedePorCodigo(Sede objSede)
        {
            var ItemResult = new Sede();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_SedePorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodSede", SqlDbType.TinyInt).Value = objSede.CodSede;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodSede = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesSede = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(2));
                            ItemResult.DirSede = Convert.ToString(dr.GetValue(3));

                        }
                    }
                }
            }

            return ItemResult;
        }




    }
}
