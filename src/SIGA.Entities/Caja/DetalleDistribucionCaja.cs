using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Caja
{
    public class DetalleDistribucionCaja
    {
        public int CodigoCierreCaja { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

    }
}
