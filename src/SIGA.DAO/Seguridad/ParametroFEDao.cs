using SIGA.DAO.Comunes;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Seguridad
{
    public class ParametroFEDao
    {
        private Conexion Conection = new Conexion();

        public DataTable ConsultarParametros(int CodigoParametro, string Descripcion, Int16 CodEmpresa)
        {
            DataTable dtParametro = new DataTable();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ParametrosFEConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodParametroFE", SqlDbType.Int).Value = CodigoParametro;
                    cmd.Parameters.Add("@DesParametroFE", SqlDbType.VarChar).Value = Descripcion;
                    cmd.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = CodEmpresa;
                    con.Open();

                    dtParametro.Load(cmd.ExecuteReader());
                }
            }

            return dtParametro;
        }

        //public ParametroFEResponse BuscarPorCodigo(Int16 pCodigo)
        //{
        //    var ItemResult = new ParametroFEResponse();

        //    using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("USP_ParametrosFEConsultarPorCodigo", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@CodParametroFE", SqlDbType.VarChar).Value = pCodigo;

        //            con.Open();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    ItemResult.CodParametroFE = Convert.ToInt16(dr.GetValue(0));
        //                    ItemResult.DesParametroFE = Convert.ToString(dr.GetValue(1));
        //                    ItemResult.ValParametroFE = Convert.ToString(dr.GetValue(2));                            
        //                    ItemResult.CodEmpresa = Convert.ToInt16(dr.GetValue(3));
        //                }
        //            }
        //        }
        //    }

        //    return ItemResult;
        //}


        public int Registrar(string Descripcion, string Valor, int Usuario, Int16 CodEmpresa)
        {
            int ParametroGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {

                    using (SqlCommand cmd = new SqlCommand("USP_ParametrosFEInsertar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DesParametroFE", SqlDbType.VarChar).Value = Descripcion;
                        cmd.Parameters.Add("@ValParametroFE", SqlDbType.VarChar).Value = Valor;
                        cmd.Parameters.Add("@UsuCre", SqlDbType.Int).Value = Usuario;
                        cmd.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = CodEmpresa;
                        cmd.ExecuteNonQuery();

                    }

                }

                catch (Exception ex)
                {
                    ParametroGenerado = -1;
                }
            }

            return ParametroGenerado;
        }


        public int Actualizar(int Codigo, string Descripcion, string Valor, int Usuario, Int16 CodEmpresa)
        {
            int ParametroGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {

                    using (SqlCommand cmd = new SqlCommand("USP_ParametrosFEActualizar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@CodParametroFe", SqlDbType.Int).Value = Codigo;
                        cmd.Parameters.Add("@DesParametroFE", SqlDbType.VarChar).Value = Descripcion;
                        cmd.Parameters.Add("@ValParametroFE", SqlDbType.VarChar).Value = Valor;
                        cmd.Parameters.Add("@UsuCre", SqlDbType.Int).Value = Usuario;
                        cmd.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = CodEmpresa;
                        cmd.ExecuteNonQuery();

                    }

                }

                catch (Exception ex)
                {
                    ParametroGenerado = -1;
                }
            }

            return ParametroGenerado;
        }

    }
}