using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
using System.Collections.Generic;
using System.Data;

namespace SIGA.Business.Logistica
{
    public  class OrdenCompraBusiness
    {
        public DataTable Consultar(OrdenCompraRequest request)
        {
            OrdenCompraDao _ordenCompraDao = new OrdenCompraDao();
            var lstResult = _ordenCompraDao.Consultar(request);
            return lstResult;
        }

        public OrdenCompra InsertarOC(OrdenCompra OC, List<OrdenCompraDetalle> OCDetalle)
        {
            OrdenCompraDao _ordenCompraDao = new OrdenCompraDao();
            var result = _ordenCompraDao.InsertarOrdenCompra(OC, OCDetalle);
            return result;
        }
    }
}
