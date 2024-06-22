using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class CotizacionHistoriaRequest
    {
        public int CodigoPedido { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }
        public string Usuario { get; set; }
        public string Comentario { get; set; }
    
    }
}
