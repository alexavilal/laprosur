using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;


namespace SIGA.Business.Ventas
{
    public class DespachoBusiness
    {

        public int InsertarDespacho(DespachoRequest request)
        {
            DespachoDao _PedidoRepository = new DespachoDao();
            string Fecha = "";

                Fecha = request.FecDespacho.ToString("yyyyMMdd");
            return _PedidoRepository.InsertarDespacho(request);

        }

        public List<DespachoResponse> BuscarPorDespachador(Int16 pCodigoDespachador)
        {
            DespachoDao _DocumentoRepository = new DespachoDao();
            return _DocumentoRepository.ConsultarPorDespachador(pCodigoDespachador);

        }
    }
}
