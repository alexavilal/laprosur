using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class SaldoResponse
    {
        public int CodGeneral { get; set; }
        public Int16 CodAlmacen { get; set; }
        public byte CodEmpresa { get; set; }
        public decimal StoSaldoActual { get; set; }
    }
}
