using System;

namespace SIGA.Entities.Ventas
{
    public class FormaPago
    {
        public short CodFormaPago { get; set; }
        public string DesFormaPago { get; set; }
        public string EstCodigo { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCre { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuMod { get; set; }
    }
}
