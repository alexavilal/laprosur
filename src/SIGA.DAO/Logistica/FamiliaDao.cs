using SIGA.DAO.Comunes;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Logistica
{
    public class FamiliaDao
    {
        private Conexion Conection = new Conexion();
        public List<Familia> Listar(Familia EntFamilia)
        {

            var listResult = new List<Familia>();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_FamiliaConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodIntFamilia", EntFamilia.CodIntFamilia);
                    cmd.Parameters.AddWithValue("@CodCuenta", EntFamilia.CodCuenta);
                    cmd.Parameters.AddWithValue("@DesFamilia", EntFamilia.DesFamilia);
                    cmd.Parameters.AddWithValue("@EstCodigo", EntFamilia.EstCodigo);


                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new Familia();
                            ItemResult.CodFamilia = Convert.ToInt32(dr.GetValue(0));
                            ItemResult.CodIntFamilia = Convert.ToString(dr.GetValue(1));
                            ItemResult.DesFamilia = dr.GetValue(2).ToString();
                            ItemResult.DesFamilia = dr.GetValue(3).ToString();
                            ItemResult.EstCodigo = dr.GetValue(4).ToString();



                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }

        public List<Familia> ObtenerFamilias(Familia objFamilia)
        {
            var listResult = new List<Familia>();


            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_FamiliaConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodFamilia", objFamilia.CodFamilia);
                    cmd.Parameters.AddWithValue("@CodIntFamilia", objFamilia.CodIntFamilia);
                    cmd.Parameters.AddWithValue("@DesFamilia", objFamilia.DesFamilia);
                    cmd.Parameters.AddWithValue("@CodCuenta", objFamilia.CodCuenta);
                    cmd.Parameters.AddWithValue("@EstCodigo", objFamilia.EstCodigo);
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new Familia();
                            ItemResult.CodFamilia = Convert.ToInt32(dr.GetValue(0));
                            ItemResult.CodIntFamilia = Convert.ToString(dr.GetValue(1));
                            ItemResult.DesFamilia = dr.GetValue(2).ToString();
                            ItemResult.CodCuenta = dr.GetValue(3).ToString();
                            ItemResult.EstCodigo = dr.GetValue(4).ToString();
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }

        public int RegistrarFamilia(Familia objFamilia)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objFamilia != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_FamiliaInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@CodIntFamilia", objFamilia.CodIntFamilia);
                            cmd.Parameters.AddWithValue("@CodCuenta", objFamilia.CodCuenta);
                            cmd.Parameters.AddWithValue("@DesFamilia", objFamilia.DesFamilia);
                            cmd.Parameters.AddWithValue("@UsuCreCodigo", objFamilia.UsuCre);
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


        public int ActualizarFamilia(Familia objFamilia)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objFamilia != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_FamiliaActualiza", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@CodFamilia", objFamilia.CodFamilia);
                            cmd.Parameters.AddWithValue("@CodIntFamilia", objFamilia.CodIntFamilia);
                            cmd.Parameters.AddWithValue("@DesFamilia", objFamilia.DesFamilia);
                            cmd.Parameters.AddWithValue("@CodCuenta", objFamilia.CodCuenta);
                            cmd.Parameters.AddWithValue("@UsuMod", objFamilia.UsuMod);
                            cmd.Parameters.AddWithValue("@EstCodigo", objFamilia.EstCodigo);

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


        public Familia ObtenerFamiliaPorCodigo(Familia objFamilia)
        {
            var ItemResult = new Familia();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_FamiliaPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodFamilia", SqlDbType.Int).Value = objFamilia.CodFamilia;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodFamilia = Convert.ToInt32(dr.GetValue(0));
                            ItemResult.CodIntFamilia = Convert.ToString(dr.GetValue(1));
                            ItemResult.DesFamilia = Convert.ToString(dr.GetValue(2));
                            ItemResult.CodCuenta = Convert.ToString(dr.GetValue(3));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(4));

                        }
                    }
                }
            }

            return ItemResult;
        }




    }
}
