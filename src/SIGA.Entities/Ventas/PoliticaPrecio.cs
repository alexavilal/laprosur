using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Entities.Ventas
{
    public class PoliticaPrecio
    {

        public int CodPolitica { get; set; }
        public string DesPolitica { get; set; }

        public string EstCodigo { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuModCodigo { get; set; }


    }
}
