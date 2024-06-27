using SIGA.DAO.Comunes;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Ventas
{
    public class FormaPagoDao
    {
        private Conexion Conection = new Conexion();

        public List<FormaPago> ObtenerFormaPago(int Tipo)
        {
            var listResult = new List<FormaPago>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_Listar_FormaPago", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new FormaPago();
                            ItemResult.CodFormaPago = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesFormaPago = Convert.ToString(dr.GetValue(1));

                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }


        public List<FormaPago> ObtenerListaPago(FormaPago objFormaPago)
        {
            var listResult = new List<FormaPago>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarFormaPago", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DesFormaPago", SqlDbType.VarChar).Value = objFormaPago.DesFormaPago;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objFormaPago.EstCodigo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new FormaPago();
                            ItemResult.CodFormaPago = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesFormaPago = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(2));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }




        public int RegistrarFormaPago(FormaPago objFormaPago, int Tipo)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objFormaPago != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_FormaPagoInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@DesFormaPago", SqlDbType.VarChar).Value = objFormaPago.DesFormaPago;
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = objFormaPago.UsuCre;
                            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;

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


        public int ActualizarFormaPago(FormaPago objFormaPago, int Tipo)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objFormaPago != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_FormaPagoActualiza", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objFormaPago.CodFormaPago;
                            cmd.Parameters.Add("@DesFormaPago", SqlDbType.VarChar).Value = objFormaPago.DesFormaPago;
                            cmd.Parameters.Add("@UsuMod", SqlDbType.SmallInt).Value = objFormaPago.UsuMod;
                            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;

                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objFormaPago.EstCodigo;
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


        public FormaPago ObtenerFormaPagoPorCodigo(FormaPago objFormaPago, int Tipo)
        {
            var ItemResult = new FormaPago();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_FormaPagoPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objFormaPago.CodFormaPago;
                    cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;


                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodFormaPago = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesFormaPago = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(2));
                        }
                    }
                }
            }

            return ItemResult;
        }



    }
}
