using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Entities.Ventas
{
    public class ClientePlaca : ClienteResponse
    {
        public string PlacaAuto { get; set; }
        public int CodigoRegistro { get; set; }
    
    }
}
