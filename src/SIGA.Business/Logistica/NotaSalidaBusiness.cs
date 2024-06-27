using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
using System.Collections.Generic;
using System.Data;

namespace SIGA.Business.Logistica
{
    public  class NotaSalidaBusiness
    {
        public DataTable Consultar(NotaSalidaRequest request)
        {
            NotaSalidaDao _NotaSalidaDao = new NotaSalidaDao();
            var lstResult = _NotaSalidaDao.Consultar(request);
            return lstResult;
        }

        public NotaSalida InsertarNS(NotaSalida OC, List<NotaSalidaDetalle> OCDetalle)
        {
            NotaSalidaDao _NotaSalidaDao = new NotaSalidaDao();
            var result = _NotaSalidaDao.InsertarNotaSalida(OC, OCDetalle);
            return result;
        }
    }
}
