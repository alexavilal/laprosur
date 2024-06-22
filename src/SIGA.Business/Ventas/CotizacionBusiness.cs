using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SIGA.Business.Ventas
{
    public class CotizacionBusiness
    {

        public Cotizacion InsertarCotizacion(Cotizacion entCotizacion, List<CotizacionDetalle> Detalle)
        {
            SIGA.DAO.Ventas.CotizacionDao objCotizacion = new DAO.Ventas.CotizacionDao();
            var result = objCotizacion.InsertarCotizacion(entCotizacion,Detalle);
            return result;
        }

        public DataTable DevuelveCotizaciones(string FechaInicio, string FechaFin, string CodigoCliente, int CodigoVendedor)
        {
            SIGA.DAO.Ventas.CotizacionDao objCotizacion = new DAO.Ventas.CotizacionDao();
            var result = objCotizacion.DevuelveCotizaciones(FechaInicio,FechaFin,CodigoCliente,CodigoVendedor);
            return result;
        }
    }
}
