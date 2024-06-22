using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
using System.Collections.Generic;

namespace SIGA.Business.Ventas
{
    public class PoliticaPrecioBusiness
    {
        public int Ingresa(PoliticaPrecio request)
        {
            PoliticaPrecioDao _PoliticaRepository = new PoliticaPrecioDao();
            var lstResult = _PoliticaRepository.IngresarPolitica(request);
            return lstResult;
        }

        public List<PoliticaPrecio> ObtenerPolitica(PoliticaPrecio objPolitica)
        { 
            PoliticaPrecioDao _PoliticaRepository = new PoliticaPrecioDao();
            var lstResult = _PoliticaRepository.ObtenerPolitica(objPolitica);
            return lstResult;
        }
        public int ActualizarPolitica(PoliticaPrecio objPolitica)
        {
            PoliticaPrecioDao _PoliticaRepository = new PoliticaPrecioDao();
            var lstResult = _PoliticaRepository.ActualizarPolitica(objPolitica);
            return lstResult;

        }
    }
}
