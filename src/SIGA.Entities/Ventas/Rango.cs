using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class Rango
    {
        public int CodRango {get;set;}
        public decimal IniRango {get;set;}
        public decimal FinRango { get; set; }
        public string Estado { get; set; }
        public Int16 UsuCre { get; set; }
 
    }
}
