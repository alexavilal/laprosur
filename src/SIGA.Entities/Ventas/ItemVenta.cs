using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class ItemVenta
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string CodigoArticulo { get; set; }
        public byte CodigoEmpresa { get; set; }
        public Decimal Cantidad { get; set; }
        public Decimal Stock { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Total { get; set; }
        public string Observacion { get; set; }
    }

}
