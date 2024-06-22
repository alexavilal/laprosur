using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.Entities.Logistica;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using SIGA.DAO.Comunes;

namespace SIGA.DAO.Logistica
{
    public class AlmacenDao
    {
        private Conexion Conection = new Conexion();

        public List<Almacen> Listar()
        {

            var listResult = new List<Almacen>();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_AlmacenListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new Almacen();
                            ItemResult.CodAlmacen = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesAlmacen = dr.GetValue(1).ToString();
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }


        public List<Almacen> ListarPorSede(Int16 CodigoSede)
        {

            var listResult = new List<Almacen>();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_AlmacenPorSede", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodSede", SqlDbType.TinyInt).Value = CodigoSede;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new Almacen();
                            ItemResult.CodAlmacen = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesAlmacen = dr.GetValue(1).ToString();
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }


        public List<Almacen> ObtenerAlmacens(Almacen objAlmacen)
        {
            var listResult = new List<Almacen>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarAlmacen", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodAlmacen", SqlDbType.TinyInt).Value = objAlmacen.CodAlmacen;
                    cmd.Parameters.Add("@CodSede", SqlDbType.TinyInt).Value = objAlmacen.CodSede;
                    cmd.Parameters.Add("@DesAlmacen", SqlDbType.VarChar).Value = objAlmacen.DesAlmacen;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objAlmacen.Estado;
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Almacen();
                            ItemResult.CodAlmacen = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesAlmacen = Convert.ToString(dr.GetValue(1));
                            ItemResult.DesSede = Convert.ToString(dr.GetValue(2));
                            ItemResult.Estado = Convert.ToString(dr.GetValue(3));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }




        public int RegistrarAlmacen(Almacen objAlmacen)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objAlmacen != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_AlmacenInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@DesAlmacen", SqlDbType.VarChar).Value = objAlmacen.DesAlmacen;
                            cmd.Parameters.Add("@CodSede", SqlDbType.TinyInt).Value = objAlmacen.CodSede;
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = objAlmacen.UsuCre;
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


        public int ActualizarAlmacen(Almacen objAlmacen)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objAlmacen != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_AlmacenActualiza", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodAlmacen", SqlDbType.TinyInt).Value = objAlmacen.CodAlmacen;
                            cmd.Parameters.Add("@DesAlmacen", SqlDbType.VarChar).Value = objAlmacen.DesAlmacen;
                            cmd.Parameters.Add("@CodSede", SqlDbType.TinyInt).Value = objAlmacen.CodSede;
                            cmd.Parameters.Add("@UsuMod", SqlDbType.SmallInt).Value = objAlmacen.UsuMod;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objAlmacen.Estado;
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


        public Almacen ObtenerAlmacenPorCodigo(Almacen objAlmacen)
        {
            var ItemResult = new Almacen();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_AlmacenPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodAlmacen", SqlDbType.TinyInt).Value = objAlmacen.CodAlmacen;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodAlmacen = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.CodSede = Convert.ToInt16(dr.GetValue(1));
                            ItemResult.DesAlmacen = Convert.ToString(dr.GetValue(2));
                            ItemResult.Estado = Convert.ToString(dr.GetValue(3));
                            ItemResult.DesSede = Convert.ToString(dr.GetValue(4));
                        }
                    }
                }
            }

            return ItemResult;
        }


        public DataTable ConsultarAlmacenes(Int16 CodigoSede)
        {

            DataTable dt = new DataTable();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_AlmacenPorSede", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodSede", SqlDbType.Int).Value = CodigoSede;


                    con.Open();

                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;
        }
    }

}
