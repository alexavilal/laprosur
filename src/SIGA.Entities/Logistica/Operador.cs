using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class Operador
    {
        public Int16 CodOperador { get; set; }
        public string DesOperador { get; set; }
        public string EstCodigo { get; set; }

        public DateTime FecCre { get; set; }
        public Int16 UsuCre { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuMod { get; set; }        
    }
}
