using SIGA.Entities.Ventas;
using System.Collections.Generic;
using System.Data;

namespace SIGA.Business.Ventas
{
    public class GuiaBusiness
    {

        public Guia InsertarGuia(Guia entGuia, List<GuiaDetalle> Detalle)
        {
            SIGA.DAO.Ventas.GuiaDao objGuia = new DAO.Ventas.GuiaDao();
            var result = objGuia.InsertarGuia(entGuia, Detalle);
            return result;
        }

        public DataTable DatosGuia(int Guia)
        {
            SIGA.DAO.Ventas.GuiaDao objGuia = new DAO.Ventas.GuiaDao();
            var result = objGuia.DatosGuia(Guia);
            return result;

        }
        public DataTable ConsultarGuias()
        {
            SIGA.DAO.Ventas.GuiaDao objGuia = new DAO.Ventas.GuiaDao();
            var result = objGuia.ConsultarGuias();
            return result;

        }
        public int AnularGuia(Guia entGuia)
        {
            SIGA.DAO.Ventas.GuiaDao objGuia = new DAO.Ventas.GuiaDao();
            var result = objGuia.AnularGuia(entGuia);
            return result;
        }
        public DataTable VentarPorFecha(string FechaInicio, string FechaFin, string CodigoCliente)
        {
            SIGA.DAO.Ventas.GuiaDao objGuia = new DAO.Ventas.GuiaDao();
            var result = objGuia.VentarPorFecha(FechaInicio, FechaFin, CodigoCliente);
            return result;
        }

    }
}
