using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class DetalleAjuste
    {
        public int CodAjuste { get; set; }
        public int CodGeneral { get; set; }
        public decimal StockAnterior { get; set; }
        public decimal CanDetalle { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public string CodigoExterno { get; set; }
        public string Descripcion { get; set; }

    }
}
