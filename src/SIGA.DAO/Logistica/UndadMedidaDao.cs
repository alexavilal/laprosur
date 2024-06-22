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
    public class UndadMedidaDao
    {
        private Conexion Conection = new Conexion();

        public List<UnidadMedida> Listar()
        {

            var listResult = new List<UnidadMedida>();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_UnidadMedidaConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new UnidadMedida();
                            ItemResult.CodUnidadMedida = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesUnidadMedida = dr.GetValue(1).ToString();
                            ItemResult.CantUnidadMedida = Convert.ToDecimal(dr.GetValue(0));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }


        public List<UnidadMedida> ObtenerUnidadMedidas(UnidadMedida objUnidadMedida)
        {
            var listResult = new List<UnidadMedida>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarUnidadMedida", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodUnidadMedida", SqlDbType.TinyInt).Value = objUnidadMedida.CodUnidadMedida;
                    cmd.Parameters.Add("@DesUnidadMedida", SqlDbType.VarChar).Value = objUnidadMedida.DesUnidadMedida;
                    cmd.Parameters.Add("@CantUnidadMedida", SqlDbType.Decimal).Value = objUnidadMedida.CantUnidadMedida;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objUnidadMedida.Estado;
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new UnidadMedida();
                            ItemResult.CodUnidadMedida = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesUnidadMedida = Convert.ToString(dr.GetValue(1));
                            ItemResult.CantUnidadMedida = Convert.ToDecimal(dr.GetValue(2));
                            ItemResult.Estado = Convert.ToString(dr.GetValue(3));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }




        public int RegistrarUnidadMedida(UnidadMedida objUnidadMedida)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objUnidadMedida != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_UnidadMedidaInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@DesUnidadMedida", SqlDbType.VarChar).Value = objUnidadMedida.DesUnidadMedida;
                            cmd.Parameters.Add("@CantUnidadMedida", SqlDbType.Decimal).Value = objUnidadMedida.CantUnidadMedida;
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = objUnidadMedida.UsuCre;
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


        public int ActualizarUnidadMedida(UnidadMedida objUnidadMedida)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objUnidadMedida != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_UnidadMedidaActualiza", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodUnidadMedida", SqlDbType.TinyInt).Value = objUnidadMedida.CodUnidadMedida;
                            cmd.Parameters.Add("@DesUnidadMedida", SqlDbType.VarChar).Value = objUnidadMedida.DesUnidadMedida;
                            cmd.Parameters.Add("@CantUnidadMedida", SqlDbType.Decimal).Value = objUnidadMedida.CantUnidadMedida;
                            cmd.Parameters.Add("@UsuMod", SqlDbType.SmallInt).Value = objUnidadMedida.UsuMod;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objUnidadMedida.Estado;
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


        public UnidadMedida ObtenerUnidadMedidaPorCodigo(UnidadMedida objUnidadMedida)
        {
            var ItemResult = new UnidadMedida();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_UnidadMedidaPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodUnidadMedida", SqlDbType.TinyInt).Value = objUnidadMedida.CodUnidadMedida;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodUnidadMedida = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesUnidadMedida = Convert.ToString(dr.GetValue(1));
                            ItemResult.CantUnidadMedida = Convert.ToDecimal(dr.GetValue(2));
                            ItemResult.Estado = Convert.ToString(dr.GetValue(3));

                        }
                    }
                }
            }

            return ItemResult;
        }

        

    }
}
