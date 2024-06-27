using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
using System.Collections.Generic;

namespace SIGA.Business.Ventas
{
    public class FormaPagoBusiness
    {
        public List<FormaPago> ObtenerFormaPago(int Tipo)
        {
            FormaPagoDao _DocumentoRepository = new FormaPagoDao();
            return _DocumentoRepository.ObtenerFormaPago(Tipo);
        }

        public int RegistrarFormaPago(FormaPago objFormaPago, int Tipo)
        {
            int Codigo = 0;
            FormaPagoDao _GeneralRepository = new FormaPagoDao();
            Codigo = _GeneralRepository.RegistrarFormaPago(objFormaPago, Tipo);
            return Codigo;
        }

        public int ActualizarFormaPago(FormaPago objFormaPago, int Tipo)
        {
            int Codigo = 0;
            FormaPagoDao _GeneralRepository = new FormaPagoDao();
            Codigo = _GeneralRepository.ActualizarFormaPago(objFormaPago, Tipo);
            return Codigo;
        }

        public List<FormaPago> ObtenerListaPago(FormaPago objFormaPago)
        {
            FormaPagoDao _GeneralRepository = new FormaPagoDao();
            return _GeneralRepository.ObtenerListaPago(objFormaPago);
        }

        public FormaPago ObtenerFormaPagoPorCodigo(FormaPago objFormaPago, int Tipo)
        {
            FormaPagoDao _GeneralRepository = new FormaPagoDao();
            return _GeneralRepository.ObtenerFormaPagoPorCodigo(objFormaPago, Tipo);
        }

    }
}
