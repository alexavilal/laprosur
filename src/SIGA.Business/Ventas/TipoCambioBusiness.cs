using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;


namespace SIGA.Business.Ventas
{
    public class TipoCambioBusiness
    {
        //private TipoCambioDao _TipoCambioRepository;
        
        //public TipoCambioBusiness(TipoCambioDao CambioDaoRepository)
        //{
        //    _TipoCambioRepository = CambioDaoRepository;
        //}

        public IEnumerable<TipoCambioResponse> TraerTipoCambio(string pFecha)
        {
            TipoCambioDao _TipoCambioRepository = new TipoCambioDao();


            var lstResult = _TipoCambioRepository.TraerTipoCambio(pFecha);
            return lstResult;
        }

    }
}
