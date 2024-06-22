using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Comunes;
using System.Data;
using SIGA.Entities.Logistica;
using System.Data.SqlClient;

namespace SIGA.DAO.Logistica
{
    public class TipoDocumentoIdentificacionDao
    {

        private Conexion Conection = new Conexion();

        public List<TipoDocumentoIdentificacion> ListarTipoDocumentoIdentidad()
        {
            var listResult = new List<TipoDocumentoIdentificacion>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_LISTAR_TIPODOCUMENTOIDENTIFICACION", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new TipoDocumentoIdentificacion();
                            ItemResult.CodTipoDocumento = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.DesDocumento = dr.GetValue(1).ToString();
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        } 
    }
}
