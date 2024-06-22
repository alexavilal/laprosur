using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class CotizacionHistoria
    {
        public int CodPedido  {get;set;}
        public string MotHistoria { get; set; }
        public DateTime FecHistoria {get;set;}
        public Int16 CodPedidoEstado {get;set;}
        public Int16 CodigoUsuario { get; set; }


    }
}
