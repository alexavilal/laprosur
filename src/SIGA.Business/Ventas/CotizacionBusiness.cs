using SIGA.Entities.Ventas;
using System.Collections.Generic;
using System.Data;

namespace SIGA.Business.Ventas
{
    public class CotizacionBusiness
    {

        public Cotizacion InsertarCotizacion(Cotizacion entCotizacion, List<CotizacionDetalle> Detalle)
        {
            SIGA.DAO.Ventas.CotizacionDao objCotizacion = new DAO.Ventas.CotizacionDao();
            var result = objCotizacion.InsertarCotizacion(entCotizacion, Detalle);
            return result;
        }

        public DataTable DevuelveCotizaciones(string FechaInicio, string FechaFin, string CodigoCliente, int CodigoVendedor)
        {
            SIGA.DAO.Ventas.CotizacionDao objCotizacion = new DAO.Ventas.CotizacionDao();
            var result = objCotizacion.DevuelveCotizaciones(FechaInicio, FechaFin, CodigoCliente, CodigoVendedor);
            return result;
        }
    }
}
