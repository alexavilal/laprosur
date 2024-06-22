using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class Precio
    {
        public int CodigoGeneral { get; set; }
        public int CodPolitica { get; set; }
      
        public int CodZona { get; set; }

        public int CodMoneda { get; set; }

        public Decimal PrecioProducto { get; set; }

        public Decimal PrecioFlete { get; set; }

        public int Usuario { get; set; }

    }
}
