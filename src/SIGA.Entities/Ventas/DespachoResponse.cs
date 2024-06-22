using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class DespachoResponse
    {

        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Pedido { get; set; }
        public string RazonSocial { get; set; }
        public string Distrito { get; set; }
        public decimal Importe { get; set; }

       
    
    }
}
