using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
using SIGA.Comun.Dto;
using System.Data;

namespace SIGA.Business.Logistica
{
    public class DocumentoProveedorBusiness
    {
        public int InsertarDocumento(DocumentoProveedor Documento, List<DetalleDocumentoProveedor> Lista,Int16 CodigoAlmacen,int CodigoNota,ref string Numero)
        {
            DocumentoProveedorDao _DocumentoRepository = new DocumentoProveedorDao();
            return _DocumentoRepository.InsertarDocumento(Documento, Lista,CodigoAlmacen,CodigoNota,ref Numero);
        }

        public int InsertarDocumentoNew(DocumentoProveedor Documento, List<DetalleDocumentoProveedor> Lista, Int16 CodigoAlmacen, int CodigoNota, ref string Numero)
        {
            DocumentoProveedorDao _DocumentoRepository = new DocumentoProveedorDao();
            return _DocumentoRepository.InsertarDocumentoNew(Documento, Lista, CodigoAlmacen, CodigoNota, ref Numero);
        }

        public List<IngresoDto> Listar(string FechaInicio, string FechaFinal, Int16 CodigoEstado, Int16 CodigoTipo)
        {
            DocumentoNoVentaDao _DocumentoRepository = new DocumentoNoVentaDao();
            return _DocumentoRepository.Listar(FechaInicio, FechaFinal, CodigoEstado, CodigoTipo);

        }

        public DataTable ConsultarPorDocumento(string FechaInicio,string FechaFinal,int CodigoProveedor,Int16 CodigoEmpresa)
        {
            DocumentoProveedorDao _DocumentoRepository = new DocumentoProveedorDao();
            return _DocumentoRepository.ConsultarPorDocumento(FechaInicio, FechaFinal, CodigoProveedor, CodigoEmpresa);

        }


        public DataTable ConsultarPorDocumentoIngresado(int CodigoDocumento,string NumeroDocumento,int CodigoProveedor)
        {
            DocumentoProveedorDao _DocumentoRepository = new DocumentoProveedorDao();
            return _DocumentoRepository.ConsultarDocumentoIngresado(CodigoDocumento,NumeroDocumento,CodigoProveedor);

        }


        public int AnularDocumento(int CodigoDocumento, Int16 CodigoUsuario)
        {
            DocumentoProveedorDao _DocumentoRepository = new DocumentoProveedorDao();
            return _DocumentoRepository.AnularDocumento(CodigoDocumento, CodigoUsuario);
        }


        public DataTable DocumentoCompraPorCodigo(int CodigoDocumento)
        {
            DocumentoProveedorDao _DocumentoRepository = new DocumentoProveedorDao();
            return _DocumentoRepository.DocumentoCompraPorCodigo(CodigoDocumento);

        }

    }
}
