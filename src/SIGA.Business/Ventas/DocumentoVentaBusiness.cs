using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
using System.Data;

namespace SIGA.Business.Ventas
{


    public class DocumentoVentaBusiness
    {

        public int InsertarDocumento(byte CodigoEmpresa, DocumentoVentaResponse Documento, List<DocumentoDetalleRequest> Lista, Int16 TipoPago, Int16 DescripcionPago, int CodigoCaja, string Cliente, int TipoOrigen)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.InsertarDocumento(CodigoEmpresa, Documento, Lista, TipoPago, DescripcionPago, CodigoCaja, Cliente, TipoOrigen);

        }

        public int AnularDocumento(int CodigoDocumento, short Usuario, short CodigoMotivo, string DescripcionMotivo)
        {
            DocumentoVentaDao documentoVentaDao = new DocumentoVentaDao();
            DataTable Detalle = documentoVentaDao.DetalleDocumento(CodigoDocumento);
            object obj = this.ConsultarDocumentosVentas(CodigoDocumento).Rows[0][15];
            return documentoVentaDao.AnularDocumento(CodigoDocumento, Usuario, Detalle, Convert.ToInt32(obj), CodigoMotivo, DescripcionMotivo);
        }
        public List<DocumentoResponse> BuscarPorCaja(string pNombreComercial)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();

            return _DocumentoRepository.BuscarPorCaja(0, "", "");

        }

        public DataTable ConsultarDocumentos()
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarDocumentosVentas();

        }

        public int ActualizarDocumento(string Estado, int CodigoDocumento, Int16 CodigoUsuario)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ActualizarDocumento(Estado, CodigoDocumento, CodigoUsuario);
        }

        public int ActualizarDocumentoNfact(int CodDocumento, string RutaNfact)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ActualizarDocumentoNfact(CodDocumento, RutaNfact);
        }

        public DataTable ConsultarDocumentosVentas(int CodigoDocumento)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarImpresionVentas(CodigoDocumento);

        }
        public DataTable ConsultarDocumentosGuiasRemision(int CodigoEmpresa, int CodigoTipODocumento, string Numero,
                                                         string RazonSocial, string Guia, string FechaInicio, string FechaFin)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarDocumentosGuiasRemision(CodigoEmpresa, CodigoTipODocumento, Numero, RazonSocial, Guia, FechaInicio, FechaFin); ;
        }
        public DataTable ConsultarDocumentosVentas(int CodigoEmpresa, int CodigoTipODocumento, string Numero, string RazonSocial, string FechaInicio, string FechaFin)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarDocumentosVentas(CodigoEmpresa, CodigoTipODocumento, Numero, RazonSocial, FechaInicio, FechaFin);

        }


        public DataTable ConsultarRegistrosVentas(int CodigoEmpresa, int CodigoTipODocumento, string Numero, string RazonSocial, string FechaInicio, string FechaFin)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarRegistroVentas(CodigoEmpresa, CodigoTipODocumento, Numero, RazonSocial, FechaInicio, FechaFin);

        }


        public DataTable ConsultarReporteDocumentoVenta(int CodEmpresa, DateTime FecEmiDocumentoInicio, DateTime FecEmiDocumentoFin, int CodTipoDocumento)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarReporteDocumentoVenta(CodEmpresa, FecEmiDocumentoInicio, FecEmiDocumentoFin, CodTipoDocumento);
        }


        public DataTable ConsultarDocumentosVentasAnulados(int CodigoEmpresa, int CodigoTipODocumento, string Numero, string RazonSocial, string FechaInicio, string FechaFin, int CodigoAnulacion, string Vendedor)
        {
            return new DocumentoVentaDao().ConsultarDocumentosVentasAnulados(CodigoEmpresa, CodigoTipODocumento, Numero, RazonSocial, FechaInicio, FechaFin, CodigoAnulacion, Vendedor);
        }

        public int ConsultarDocumentosRepetidos(int CodigoEmpresa, short CodigoTipoDocumento, string Numero)
        {
            return new DocumentoVentaDao().ConsultarDocumentosRepetidos(CodigoEmpresa, CodigoTipoDocumento, Numero);
        }

        public DataTable ConsultarDocumentoVenta_NFACT(int CodDocumento)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarDocumentoVenta_NFACT(CodDocumento);
        }

        public DataTable ConsultarDocumentoVenta_NFACT_Anulacion(int CodDocumento)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarDocumentoVenta_NFACT_Anulacion(CodDocumento);
        }


        public DataTable ConsultarDocumentosNoEnviados_NFACT(int CodigoEmpresa, int CodigoTipODocumento, string Numero, string RazonSocial, string FechaInicio, string FechaFin)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarDocumentosNoEnviados_NFACT(CodigoEmpresa, CodigoTipODocumento, Numero, RazonSocial, FechaInicio, FechaFin);

        }

        public DataTable ConsultarMotivosPorNotas(string TipoDocumento)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarMotivosPorNotas(TipoDocumento);
        }

        public DataTable ConsultarDocumentoVenta_NFACTNCD(int CodDocumento)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarDocumentoVenta_NFACTNCD(CodDocumento);
        }

        public DataTable ConsultarRutaNFact(int CodigoDocumento)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarRutaNFact(CodigoDocumento);

        }

        public DataTable ConsultarDocumentosVentasNC(int CodigoEmpresa, int CodigoTipODocumento, string Numero, string RazonSocial, int CodigoMotivo, string FechaInicio, string FechaFin)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.ConsultarDocumentosVentasNC(CodigoEmpresa, CodigoTipODocumento, Numero, RazonSocial, CodigoMotivo, FechaInicio, FechaFin);

        }

        public int InsertarDocumentoNotasCredito(byte CodigoEmpresa, DocumentoVentaResponse Documento, List<DocumentoDetalleRequest> Lista, Int16 TipoPago, Int16 DescripcionPago, int CodigoCaja, string Cliente, int TipoOrigen, int CodigoMotivo, int DocumentoOrigen)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.InsertarDocumentoNotasCredito(CodigoEmpresa, Documento, Lista, TipoPago, DescripcionPago, CodigoCaja, Cliente, TipoOrigen, CodigoMotivo, DocumentoOrigen);

        }
        public DataTable DetalleDocumento(int CodigoDocumento)
        { 
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.DetalleDocumento(CodigoDocumento);
        }
        public DataTable DetalleDocumentoGuia(int CodigoDocumento)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.DetalleDocumentoGuia(CodigoDocumento);
        }

        public DataTable DetalleItemsGuia(int CodigoDocumento)
        {
            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.DetalleItemsGuia(CodigoDocumento);
        }

        public DataTable CargarDocumentoRelacionado(int CodigoDocumento)
        {

            DocumentoVentaDao _DocumentoRepository = new DocumentoVentaDao();
            return _DocumentoRepository.CargarDocumentoRelacionado(CodigoDocumento);
        }
    }

    //public void Update(e_tbDocumentoVenta obje_tbDocumentoVenta)
    //{
    //    dl_tbDocumentoVenta objdl_tbDocumentoVenta = new dl_tbDocumentoVenta();
    //    objdl_tbDocumentoVenta.Update(obje_tbDocumentoVenta);
    //}

    //public void Delete(int CodDocumento)
    //{
    //    dl_tbDocumentoVenta objdl_tbDocumentoVenta = new dl_tbDocumentoVenta();
    //    objdl_tbDocumentoVenta.Delete(CodDocumento);
    //}

}

