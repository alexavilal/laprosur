using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class Tarjeta
    {
        public Int16 CodTarjeta { get; set; }
        public string DesTarjeta { get; set; }
        public string EstCodigo { get; set; }
        public decimal Porcentaje { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCre { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuMod { get; set; }         
    }
}
