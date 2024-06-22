using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
using System.Data;

namespace SIGA.Business.Ventas
{
    public class RangoBusiness
    {

        public int Registrar(Rango entRango)
        {
          SIGA.DAO.Ventas.RangoDao objVentas = new SIGA.DAO.Ventas.RangoDao();
          var result = objVentas.Registrar(entRango);
          return result;
        }

        public List<Rango> Listado()
        {
            SIGA.DAO.Ventas.RangoDao objVentas = new SIGA.DAO.Ventas.RangoDao();
            var result = objVentas.Listado();
            return result;
        }

        public int Actualizar(Rango entRango)
        {
            SIGA.DAO.Ventas.RangoDao objVentas = new SIGA.DAO.Ventas.RangoDao();
            var result = objVentas.ActualizarRango(entRango);
            return result;
        }

        public DataTable ListaRangoTabla()
        {
            SIGA.DAO.Ventas.RangoDao objVentas = new SIGA.DAO.Ventas.RangoDao();
            var Result = objVentas.ListadoRangoTabla();
            return Result;

        }

        public DataTable ListadoRangoPorCodigo(int Codigo)
        {
            SIGA.DAO.Ventas.RangoDao objVentas = new SIGA.DAO.Ventas.RangoDao();
            var Result = objVentas.ListadoRangoPorCodigo(Codigo);
            return Result;

        }
    }
}
