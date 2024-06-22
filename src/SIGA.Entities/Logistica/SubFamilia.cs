using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class SubFamilia : Familia
    {


        public Int16 CodSubFamilia { get; set; }
        public string DesSubFamilia { get; set; }
        public string DesFamilia { get; set; }
        public Decimal DesPorcentaje { get; set; }
        public Decimal DesPorMayor { get; set; }
        public Int16 CodFamilia { get; set; }
        public string EstCodigo { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCre { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuMod { get; set; }       


    }
}
