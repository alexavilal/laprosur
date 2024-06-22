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
    public class TipoDocumentoDao
    {
        private Conexion Conection = new Conexion();

        public List<TipoDocumento> Listar()
        {
            var listResult = new List<TipoDocumento>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_TipoDocumentoListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new TipoDocumento();
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
       