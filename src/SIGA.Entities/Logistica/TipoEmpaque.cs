using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class TipoEmpaque
    {
        public Int16 CodTipEmpaque { get; set; }
        public string DesTipEmpaque { get; set; }
        public string EstCodigo { get; set; }

        public DateTime FecCre { get; set; }
        public Int16 UsuCre { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuMod { get; set; }         

    }
}
