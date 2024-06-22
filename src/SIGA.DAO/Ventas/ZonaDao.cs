using SIGA.DAO.Comunes;
using SIGA.Entities.Administrador;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGA.Entities.Ventas;

namespace SIGA.DAO.Ventas
{
    public  class ZonaDao
    {

        private Conexion Conection = new Conexion();


        public List<Zona> ObtenerZona(Zona objZona)
        {
            var listResult = new List<Zona>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarZonas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodZona", SqlDbType.Int).Value = objZona.IdZona;
                    cmd.Parameters.Add("@DesZona", SqlDbType.VarChar).Value = objZona.Descripcion;
                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objZona.Estado;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Zona();
                            ItemResult.IdZona = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.Descripcion = Convert.ToString(dr.GetValue(1));
                            ItemResult.Estado = Convert.ToString(dr.GetValue(2));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }


        public int RegistrarZona(Zona objZona)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objZona != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_ZonaInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                           
                            cmd.Parameters.Add("@DesZona", SqlDbType.VarChar).Value = objZona.Descripcion;
                            cmd.Parameters.Add("@UsuCre", SqlDbType.Int).Value = objZona.Usuario;
                           
                            SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.Int);
                            parm2.Size = 7;
                            parm2.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(parm2);
                            cmd.ExecuteNonQuery();

                            
                        }
                    }
                }

                catch (Exception ex)
                {
                    DocumentoGenerado = -1;
                }
            }

            return DocumentoGenerado;
        }


        public int ActualizarModulo(Modulo objModulo)
        {
            int DocumentoGenerado = 0;

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                try
                {
                    if (objModulo != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_ZonaActualizar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CodZona", SqlDbType.SmallInt).Value = objModulo.CodigoModulo;
                            cmd.Parameters.Add("@DesZona", SqlDbType.VarChar).Value = objModulo.DescripcionModulo;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = objModulo.EstadoModulo;
                            cmd.Parameters.Add("@UsuCre", SqlDbType.SmallInt).Value = objModulo.UsuModifica;
                          
                            cmd.ExecuteNonQuery();

                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    DocumentoGenerado = -1;
                }
            }

            return DocumentoGenerado;
        }

        public Modulo ObtenerModuloPorCodigo(Modulo objModulo)
        {
            var ItemResult = new Modulo();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ModulosPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodModulo", SqlDbType.SmallInt).Value = objModulo.CodigoModulo;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemResult.CodigoModulo = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DescripcionModulo = Convert.ToString(dr.GetValue(1));
                            ItemResult.EstadoModulo = Convert.ToString(dr.GetValue(2));
                        }
                    }
                }
            }

            return ItemResult;
        }
    }




}
