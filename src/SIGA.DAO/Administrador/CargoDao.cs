using SIGA.DAO.Comunes;
using SIGA.Entities.Administrador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.DAO.Administrador
{
    public class CargoDao
    {
        private Conexion Conection = new Conexion();

        public List<Cargo> ObtenerCargo()
        {
            var listResult = new List<Cargo>();

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListaCargo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ItemResult = new Cargo();
                            ItemResult.Codigo = Convert.ToInt16(dr.GetValue(0));
                            ItemResult.Descripcion = Convert.ToString(dr.GetValue(1));
                            ItemResult.Estado = Convert.ToString(dr.GetValue(2));

                            listResult.Add(ItemResult);
                        }
                    }
                }
            }
            return listResult;
        }



    }
}
