using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Comunes;
using SIGA.Entities.Seguridad;
using System.Data.SqlClient;
using System.Data;
using SIGA.Entities.Ventas;

namespace SIGA.DAO.Seguridad
{
    public class ParametroDao
    {
        private Conexion Conection = new Conexion();

        public DataTable ConsultarParametros(int CodigoParametro, string Descripcion)
        {
            DataTable dtUsuario = new DataTable();
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ParametrosGeneralesConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodParametro", SqlDbType.Int).Value = CodigoParametro;
                    cmd.Parameters.Add("@DesParametro", SqlDbType.VarChar).Value = Descripcion;
                    con.Open();
                    dtUsuario.Load(cmd.ExecuteReader());
                }
            }

            return dtUsuario;
        }

        //public ParametroResponse BuscarPorCodigo(Int16 pCodigo)
        //{
        //    var ItemResult = new ParametroResponse();
        //    using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("USP_PametroConsultar", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@CodParametro", SqlDbType.VarChar).Value = pCodigo;

        //            con.Open();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {


        //                    ItemResult.CodParametro = Convert.ToInt16(dr.GetValue(0));
        //                    ItemResult.DesParametro = Convert.ToString(dr.GetValue(1));
        //                    ItemResult.ValParametro1 = Convert.ToString(dr.GetValue(2));
        //                    ItemResult.ValParametro2 = Convert.ToString(dr.GetValue(3));
        //                    ItemResult.ValParametro3 = Convert.ToString(dr.GetValue(4));


        //                }
        //            }
        //        }
        //    }

        //    return ItemResult;
        //}


        public int Registrar(string Descripcion, string Valor, int Usuario)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {

                    using (SqlCommand cmd = new SqlCommand("USP_ParametrosGeneralInsertar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DesParametro", SqlDbType.VarChar).Value = Descripcion;
                        cmd.Parameters.Add("@DesValor", SqlDbType.VarChar).Value = Valor;
                        cmd.Parameters.Add("@UsuCre", SqlDbType.Int).Value = Usuario;
                        cmd.ExecuteNonQuery();

                    }

                }

                catch (Exception ex)
                {
                    DocumentoGenerado = -1;
                }
            }

            return DocumentoGenerado;
        }


        public int Actualizar(int Codigo, string Descripcion, string Valor, int Usuario)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {

                    using (SqlCommand cmd = new SqlCommand("USP_ParametrosActualizar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@CodParametro", SqlDbType.Int).Value = Codigo;
                        cmd.Parameters.Add("@DesParametro", SqlDbType.VarChar).Value = Descripcion;
                        cmd.Parameters.Add("@DesValor", SqlDbType.VarChar).Value = Valor;
                        cmd.Parameters.Add("@UsuCre", SqlDbType.Int).Value = Usuario;
                        cmd.ExecuteNonQuery();

                    }

                }

                catch (Exception ex)
                {
                    DocumentoGenerado = -1;
                }
            }

            return DocumentoGenerado;
        }

    }
}
