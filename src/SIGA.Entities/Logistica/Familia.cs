using System;

namespace SIGA.Entities.Logistica
{

    public class Familia
    {

        public int CodFamilia { get; set; }
        public string CodIntFamilia { get; set; }
        public string DesFamilia { get; set; }
        public string CodCuenta { get; set; }
        public string EstCodigo { get; set; }

        public DateTime FecCre { get; set; }
        public Int16 UsuCre { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuMod { get; set; }

    }
}
