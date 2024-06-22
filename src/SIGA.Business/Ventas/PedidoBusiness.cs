using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
using System.Data;


namespace SIGA.Business.Ventas
{
    public class PedidoBusiness
    {

        public int InsertarPedido(Pedido Documento, List<DetallePedidoResponse> Lista,Int16 pCodigoPerfil)
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            return _PedidoRepository.InsertarDocumento(Documento.CodEmpresa, Documento, Lista,pCodigoPerfil);

        }


        public int ActualizarPedido(Pedido Documento, List<DetallePedidoResponse> Lista, Int16 pCodigoPerfil)
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            return _PedidoRepository.ActualizarDocumento(Documento.CodEmpresa, Documento, Lista, pCodigoPerfil);

        }


        public int InsertarPedidoInstitucion(Pedido Documento, List<DetallePedidoResponse> Lista)
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            return _PedidoRepository.InsertarDocumentoInstitucion(1, Documento, Lista);

        }

        public Pedido ConsultarPorCodigo(int pCodigo)
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            var lstResult = _PedidoRepository.ConsultarPorCodigo(pCodigo);
            return lstResult;
        }

        public IEnumerable<Pedido> ConsultarPorParametros(string pFechaInicio, string pFechaFin, byte pCodigoSede, string pRazonSocial,string pTipo)
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            var result = _PedidoRepository.ConsultarPorParametros("20140101", "20141231", 1,"",pTipo);
            return result;
        }

        public DataTable ConsultarPedidos(string FechaInicio, string FechaFinal, int CodigoTipo, int CodigoSede, int TipoCliente, string RazonSocial, int Usuario)
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            var result = _PedidoRepository.ConsultarPedidos(FechaInicio, FechaFinal, CodigoTipo, CodigoSede, TipoCliente, RazonSocial, Usuario);
            return result;
        }
        public DataTable ConsultarPedidosCaja(string FechaInicio, string FechaFinal, string CodCLiente, string RazonSocial, string TipoDocumnto,
            Int16 CodigoEstado,int TipoPedido,string Vendedor)
        {

            PedidoDao _PedidoRepository = new PedidoDao();
            var result = _PedidoRepository.ConsultarPedidosCaja(FechaInicio, FechaFinal, CodCLiente, RazonSocial, TipoDocumnto, CodigoEstado, TipoPedido, Vendedor);
            return result;
        }

        public DataTable ConsultarCabecera(int CodigoPedido)
        {

            PedidoDao _PedidoRepository = new PedidoDao();
            var result = _PedidoRepository.ConsultarCabecera(CodigoPedido);
            return result;
        }

        public DataTable ConsultarDetallePedido(int CodigoPedido)
        {

            PedidoDao _PedidoRepository = new PedidoDao();
            var result = _PedidoRepository.ConsultarDetallePedido(CodigoPedido);
            return result;
        }

        public DataTable ConsultarCabeceraPedidoNew(int CodigoPedido)
        {

            PedidoDao _PedidoRepository = new PedidoDao();
            var result = _PedidoRepository.ConsultarCabeceraPedidoNew(CodigoPedido);
            return result;
        }

        public List<DetallePedidoResponse> ConsultarDetallePedidoModificacion(int pCodigoPedido)
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            var result = _PedidoRepository.ConsultarDetallePedidoModificacion(pCodigoPedido);
            return result;
        }

        public DataTable ConsultarDocumentosSinDespachar()
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            var lstResult = _PedidoRepository.ConsultarDocumentosSinDespachar();
            return lstResult;
        }

        public DataTable ConsultarDocumentosSinDespacharAntiguo()
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            var lstResult = _PedidoRepository.ConsultarDocumentosSinDespacharAntiguo();
            return lstResult;
        }


        public int ActualizarImpresionDocumento(int CodigoDocumento)
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            return _PedidoRepository.ActualizarImpresionDocumento(CodigoDocumento);
        }


        public int EliminarImpresiones()
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            return _PedidoRepository.EliminarImpresiones();
        }

        public int ActualizarSaldosFechas()
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            return _PedidoRepository.ActualizarSaldosFechas();
        }


        public DataTable ImpresionDocumentoDespacho(int CodigoDocumento)
        {
            PedidoDao _PedidoRepository = new PedidoDao();
            var lstResult = _PedidoRepository.ImpresionDocumentoDespacho(CodigoDocumento);
            return lstResult;
        }
    }

}
