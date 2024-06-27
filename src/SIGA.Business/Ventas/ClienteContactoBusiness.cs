using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
using System.Collections.Generic;

namespace SIGA.Business.Ventas
{
    public class ClienteContactoBusiness
    {
        public int EliminarClienteContacto(ClienteContacto objClienteContacto)
        {
            ClienteContactoDao _DocumentoRepository = new ClienteContactoDao();
            return _DocumentoRepository.EliminarClienteContacto(objClienteContacto);
        }

        public List<ClienteContacto> ObtenerClienteContacto(ClienteContacto objClienteContacto)
        {
            ClienteContactoDao _DocumentoRepository = new ClienteContactoDao();
            return _DocumentoRepository.ObtenerClienteContacto(objClienteContacto);

        }
        public int RegistrarClienteContacto(List<ClienteContacto> ListaClienteContacto)
        {
            ClienteContactoDao _GeneralRepository = new ClienteContactoDao();
            return _GeneralRepository.RegistrarClienteContacto(ListaClienteContacto);
        }


        public int ActualizarCliente(ClienteResponse objClienteResponse, List<ClientePlaca> lstPlacas)
        {
            ClienteContactoDao _GeneralRepository = new ClienteContactoDao();
            return _GeneralRepository.ActualizarCliente(objClienteResponse, lstPlacas);
        }

    }
}
