using System;

namespace SIGA.Entities.Logistica
{
    public class Almacen
    {

        public Int16 CodAlmacen { get; set; }
        public Int16 CodSede { get; set; }
        public string DesAlmacen { get; set; }
        public string DesSede { get; set; }
        public string Estado { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCre { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuMod { get; set; }
    }
}
