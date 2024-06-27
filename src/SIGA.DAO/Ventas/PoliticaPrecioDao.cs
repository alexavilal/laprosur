using SIGA.DAO.Comunes;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Ventas
{
    public class PoliticaPrecioDao
    {

        private Conexion Conection = new Conexion();

        public int IngresarPolitica(PoliticaPrecio request)
        {
            int Codigo = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_PoliticaPrecioInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            cmd.Parameters.Add("@DesPolitica", SqlDbType.VarChar).Value = request.DesPolitica;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.VarChar).Value = request.EstCodigo;
                            cmd.Parameters.Add("@UsuCre", SqlDbType.VarChar).Value = request.UsuCreCodigo;
                            SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.Int);
                            parm2.Size = 7;
                            parm2.Direction = ParameterDirection.Output; // This is important!
                            cmd.Parameters.Add(parm2);
                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();
                            Codigo = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);

                        }

                        tran.Commit();
                    }

                    catch (Exception ex)
                    {
                        tran.Rollback();

                    }

                }
            }

            return Codigo;

        }

        public int ActualizarPolitica(PoliticaPrecio objPolitica)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objPolitica != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_PoliticaPrecioActualizar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodPolitica", SqlDbType.SmallInt).Value = objPolitica.CodPolitica;
                            cmd.Parameters.Add("@DesPolitica", SqlDbType.VarChar).Value = objPolitica.DesPolitica;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objPolitica.EstCodigo;
                            cmd.Parameters.Add("@UsuCre ", SqlDbType.SmallInt).Value = objPolitica.UsuCreCodigo;

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    DocumentoGenerado = -1;
                    throw ex;
                }
            }

            return DocumentoGenerado;
        }
        public List<PoliticaPrecio> ObtenerPolitica(PoliticaPrecio objPolitica)
        {
            var listResult = new List<PoliticaPrecio>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarPolitica", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodPolitica", SqlDbType.Int).Value = objPolitica.CodPolitica;
                    cmd.Parameters.Add("@DesPolitica", SqlDbType.VarChar).Value = objPolitica.DesPolitica;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objPolitica.EstCodigo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new PoliticaPrecio();
                            ItemResult.CodPolitica = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesPolitica = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(2));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }

    }
}
