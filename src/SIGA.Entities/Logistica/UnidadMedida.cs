using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class UnidadMedida
    {
        public Int16 CodUnidadMedida { get; set; }
        public string DesUnidadMedida { get; set; }
        public decimal CantUnidadMedida { get; set; }
        public string Estado { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCre { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuMod { get; set; }     
    
    
    }
}
