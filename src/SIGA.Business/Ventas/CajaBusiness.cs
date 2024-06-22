using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
using System.Data;

namespace SIGA.Business.Ventas
{
    public class CajaBusiness
    {

        public int IngresarCaja(CajaRequest request)
        {
            CajaDao _CitaRepository = new CajaDao();
            var lstResult = _CitaRepository.RegistroCaja(request);
            return lstResult;
        }

        public DataTable ConsultarSaldo(int CodigoCaja)
        {
            CajaDao _CitaRepository = new CajaDao();
            var lstResult = _CitaRepository.ConsultarSaldo(CodigoCaja);
            return lstResult;
        }

        public DataTable MovimientoCaja(int CodigoCaja,string TipoDocumento,string Cliente,string Numero)
        {
            CajaDao _CitaRepository = new CajaDao();
            var lstResult = _CitaRepository.MovimientoCaja(CodigoCaja, TipoDocumento, Cliente, Numero);
            return lstResult;
        }

        public DataTable ConsultarCajas(DateTime del,DateTime al)
        {
            CajaDao _CitaRepository = new CajaDao();
            var lstResult = _CitaRepository.ConsultarCajas(del, al);
            return lstResult;
        }

        public DataTable ConsultarCierre(int CodigoCaja)
        {
            SIGA.DAO.Caja.Cajero _CitaRepository = new   SIGA.DAO.Caja.Cajero ();
            var lstResult = _CitaRepository.ConsultarCierre(CodigoCaja);
            return lstResult;
        }

        public DataTable ConsultarPorCodigo(int CodigoCaja)
        {
            SIGA.DAO.Ventas.CajaDao _CitaRepository = new SIGA.DAO.Ventas.CajaDao();
            var lstResult = _CitaRepository.ConsultarCajaPorCodigo(CodigoCaja);
            return lstResult;
        }


        public int CajasActivasPorUsuario(int CodigoUsuario,string Fecha,int TipoCaja)
        {
            SIGA.DAO.Ventas.CajaDao _CitaRepository = new SIGA.DAO.Ventas.CajaDao();
            var lstResult = _CitaRepository.ConsultarCajasActivas(CodigoUsuario, Fecha, TipoCaja);
            return Convert.ToInt32(lstResult.Rows[0][0]);
        }

        public int CajaAdministrativaActiva(int CodigoSede,string Fecha)
        {
            SIGA.DAO.Ventas.CajaDao _CitaRepository = new SIGA.DAO.Ventas.CajaDao();
            var lstResult = _CitaRepository.ConsultarCajasAdministrativaActiva(CodigoSede, Fecha);

            if (lstResult.Rows.Count == 0)
            {
                return 0;
            }

            else
            {
                return Convert.ToInt32(lstResult.Rows[0][0]);
            }
            
        }

    }
}
