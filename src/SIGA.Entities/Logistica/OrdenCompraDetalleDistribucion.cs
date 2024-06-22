using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class OrdenCompraDetalleDistribucion
    {
        public Int16 CodigoSede { get; set; }
        public string DescripcionSede { get; set; }
        public int CodigoGeneral { get; set; }
        public Int16 CodAlmacen { get; set; }
        public string DesAlmacen { get; set; }
        public Decimal Cantidad { get; set; }
        public Int16 CodigoColor { get; set; }
        public string DescripcionColor { get; set; }
    }
}
