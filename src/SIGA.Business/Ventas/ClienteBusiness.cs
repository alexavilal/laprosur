using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
using SIGA.Entities.Logistica;
using SIGA.DAO.Logistica;
using SIGA.Entities.Comunes;

namespace SIGA.Business.Ventas
{
    public class ClienteBusiness : IDisposable
    {
        bool disposed = false;

   
        public ClienteResponse BuscarPorCodigo(string pCodigo)
        {
            ClienteDao _ClienteRepository = new ClienteDao();
            var lstResult = _ClienteRepository.BuscarPorCodigo(pCodigo);
            return lstResult;
        }

        public List<ClienteResponse> BuscarPorNombre(string pCodigo)
        {
            ClienteDao _ClienteRepository = new ClienteDao();
            var lstResult = _ClienteRepository.BuscarPorNombre(pCodigo);
            return lstResult;
       
        }

        public List<ClienteResponse> BuscarPorTipoDocumento(int pTipoDocumento,string pNumeroDocumento)
        {
            ClienteDao _ClienteRepository = new ClienteDao();
            var lstResult = _ClienteRepository.BuscarPorTipoDocumento(pTipoDocumento,pNumeroDocumento);
            return lstResult;

        }

        public string IngresarCliente(ClienteRequest request)
        {

            ClienteDao _ClienteRepository = new ClienteDao();
            var lstResult = _ClienteRepository.IngresarCliente(request);
            return lstResult;
        }

        public string IngresarClienteSubTipo(ClienteResponse request)
        {

            ClienteDao _ClienteRepository = new ClienteDao();
            var lstResult = _ClienteRepository.IngresarClienteSubTipo(request);
            return lstResult;
        }


        //public List<ClienteResponse> ListarCliente(Proveedor objProveedor)
        //{
        //    ClienteDao _GeneralRepository = new ClienteDao();
        //    return _GeneralRepository.ListarCliente(objProveedor);
        //}


        public List<Base> ListarTipoCliente()
        {
            ClienteDao _GeneralRepository = new ClienteDao();
            return _GeneralRepository.ListarTipoCliente();
        }

        public List<ClienteResponse> ObtenerClientesRegistrados(ClienteResponse objEntidad)
        {
            ClienteDao _ClienteRepository = new ClienteDao();
            return _ClienteRepository.ObtenerClientesRegistrados(objEntidad);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
        }

        public string RegistrarCliente(ClienteResponse objClienteResponse,List<ClientePlaca> lstPlacas)
        {
            string Codigo = "0";
            ClienteDao _ClienteRepository = new ClienteDao();
            Codigo = _ClienteRepository.RegistrarCliente(objClienteResponse,lstPlacas);
            return Codigo;
        }
        public ClienteResponse ObtenerClientePorCodigo(ClienteResponse objEntidad)
        {
            ClienteDao _ClienteRepository = new ClienteDao();
            return _ClienteRepository.ObtenerClientePorCodigo(objEntidad);

        }
        public List<ClientePlaca> ListarPlacas(string CodigoCliente)
        {
            ClienteDao clienteDao = new ClienteDao();
            var result = clienteDao.ListarPlacas(CodigoCliente);
            return result;

        }

        public int ClienteEliminarPlaca(int CodigoRegistro)
        {
            ClienteDao clienteDao = new ClienteDao();
            var result = clienteDao.ClienteEliminarPlaca(CodigoRegistro);
            return result;
        }



    }
}
