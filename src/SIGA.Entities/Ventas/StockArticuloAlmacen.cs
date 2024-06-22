using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class StockArticuloAlmacen
    {
        public byte CodAlmacen { get; set; }
        public string DesAlmacen { get; set; }
        public decimal Stock { get; set; }
        public string CodigoExterno { get; set; }
        public string Descripcion { get; set; }

    }
}
