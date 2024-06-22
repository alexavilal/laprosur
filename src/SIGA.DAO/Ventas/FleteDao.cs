using SIGA.DAO.Comunes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.DAO.Ventas
{
    public class FleteDao
    {
        private Conexion Conection = new Conexion();


        public DataTable ReporteFlete(string FechaInicio, string FechaFin, string CodigoCliente)
        {

            DataTable dtGuia = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_ReporteFlete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                        cmd.Parameters.AddWithValue("@CodigoTranp", CodigoCliente);

                        con.Open();
                        dtGuia.Load(cmd.ExecuteReader());

                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return dtGuia;

        }

    }
}
