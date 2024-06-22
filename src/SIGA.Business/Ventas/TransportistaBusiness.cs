using SIGA.Entities.Ventas;
using SIGA.DAO.Ventas;
using System.Collections.Generic;
using System.Data;


namespace SIGA.Business.Ventas
{
    public class TransportistaBusiness
    {

        public int RegistrarTransportista(Transportista objTransportistaResponse, List<TransportistaPlaca> lstPlaca)
        {
            TransportistaDao transportistaDao = new TransportistaDao();
            var result = transportistaDao.RegistrarTransportista(objTransportistaResponse, lstPlaca);
            return result;

        }
        public List<Transportista> BuscarPorTipoDocumento(int pCodigoTipoDocumento, string pNumeroDocumento)
        {
            TransportistaDao transportistaDao = new TransportistaDao();
            var result = transportistaDao.BuscarPorTipoDocumento(pCodigoTipoDocumento,pNumeroDocumento);
            return result;
        }
        public DataTable DevuelveVehiculo(string Transportista, string PlacaVehiculo)
        {
            TransportistaDao transportistaDao = new TransportistaDao();
            var result = transportistaDao.DevuelveVehiculo(Transportista, PlacaVehiculo);
            return result;

        }
    }
}
