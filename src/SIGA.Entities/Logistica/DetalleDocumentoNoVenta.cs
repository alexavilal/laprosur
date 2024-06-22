using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class DetalleDocumentoNoVenta
    {
        public int CodDocNoVenta {get;set;}
        public int ItemDocNoVenta  {get;set;}
        public int CodGeneral {get;set;}
        public decimal CanDetalleDocumento {get;set;}
        public decimal PrecioDetalleDocumento {get;set;}
        public decimal TotaDetalleDocumento {get;set;}
        public Int16 CodALmacen { get; set; }

    }
}
