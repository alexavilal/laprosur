using System.Data;

namespace SIGA.Business.Ventas
{
    public class FleteBusiness
    {

        public DataTable ReporteFlete(string FechaInicio, string FechaFin, string CodigoCliente)
        {
            SIGA.DAO.Ventas.FleteDao objFlete = new SIGA.DAO.Ventas.FleteDao();
            var result = objFlete.ReporteFlete(FechaInicio, FechaFin, CodigoCliente);
            return result;
        }


    }
}
