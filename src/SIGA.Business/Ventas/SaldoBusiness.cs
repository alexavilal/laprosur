using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;

namespace SIGA.Business.Ventas
{
    public class SaldoBusiness 
    {
        public decimal Stock(int pCodigo,byte pCodigoEmpresa)
        {
            SaldoDao _SaldoRepository = new SaldoDao();
            return _SaldoRepository.Stock(pCodigo, pCodigoEmpresa);
        }


        public decimal StockPorAlmacen(int pCodigo, byte pCodigoEmpresa,Int16 pCodigoAlmacen)
        {
            SaldoDao _SaldoRepository = new SaldoDao();
            return _SaldoRepository.StockPorAlmacen(pCodigo, pCodigoEmpresa, pCodigoAlmacen);
        }
    }
}
