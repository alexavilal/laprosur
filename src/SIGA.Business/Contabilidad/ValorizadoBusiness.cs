using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Contabilidad;
using SIGA.Entities.Logistica;
using System.Data;


namespace SIGA.Business.Contabilidad
{
    public class ValorizadoBusiness
    {
        public DataTable ProcesarCostoPorCodigoGeneral(string Inicio, string Fin, int Codigo)
        {
            ValorizadoDao _GeneralRepository = new ValorizadoDao();
            var lstResult = _GeneralRepository.ProcesarCostoPorCodigoGeneral(Inicio, Fin, Codigo);
            return lstResult;
        }

        public int Actualizar(int Codigo, int CantidadSaldo, Decimal PrecioSaldo, Decimal TotalSaldo)
        {

            ValorizadoDao _GeneralRepository = new ValorizadoDao();
            var lstResult = _GeneralRepository.Actualizar(Codigo, CantidadSaldo, PrecioSaldo, TotalSaldo);
            return lstResult;
        }

        public int ActualizarInicioFin(int CodigoGeneral, int Tipo)
        {

            ValorizadoDao _GeneralRepository = new ValorizadoDao();
            var lstResult = _GeneralRepository.ActualizarInicioFin(CodigoGeneral,Tipo);
            return lstResult;
        }

        public DataTable Listado(int CodigoEmpresa, int MarcaInicio, int MarcaFin)
        {
            ValorizadoDao _GeneralRepository = new ValorizadoDao();
            var lstResult = _GeneralRepository.Listado(CodigoEmpresa, MarcaInicio, MarcaFin);
            return lstResult;

        }

        public DataTable ProcesoReporte(int Anio, int Mes, int CodigoGeneral)
        {
            ValorizadoDao _GeneralRepository = new ValorizadoDao();
            var lstResult = _GeneralRepository.ProcesoReporte(Anio,Mes,CodigoGeneral);
            return lstResult;
        }

        public DataTable SaldoValorizado(int CodigoEmpresa,int CodigoMarca, string Fecha)
        {
            ValorizadoDao _GeneralRepository = new ValorizadoDao();
            var lstResult = _GeneralRepository.SaldoValorizado(CodigoEmpresa,CodigoMarca, Fecha);
            return lstResult;
        }
    }
}
