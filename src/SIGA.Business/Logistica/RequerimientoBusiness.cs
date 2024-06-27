using SIGA.Entities.Logistica;
using System.Collections.Generic;
using System.Data;

namespace SIGA.Business.Logistica
{
    public class RequerimientoBusiness
    {
        public Requerimiento Insertar(Requerimiento entRequerimiento, List<RequerimientoDetalle> Detalle)
        {
            SIGA.DAO.Logistica.RequerimientoDao objCotizacion = new DAO.Logistica.RequerimientoDao();
            var result = objCotizacion.InsertarRequerimiento(entRequerimiento, Detalle);
            return result;
        }

        public DataTable Consultar()
        {
            SIGA.DAO.Logistica.RequerimientoDao objCotizacion = new DAO.Logistica.RequerimientoDao();
            var result = objCotizacion.Consultar();
            return result;

        }
    }
}
