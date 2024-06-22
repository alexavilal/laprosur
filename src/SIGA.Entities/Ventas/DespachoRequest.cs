using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class DespachoRequest
    {
        public int CodDespacho { get; set; }
        public byte CodSede {get;set;}
        public Int16 CodEmpleado {get;set;}
        public Int16 CodAgencia {get;set;}
        public Int16 CodDistrito {get;set;}
        public int CodPedido { get; set; }
        public DateTime FecDespacho {get;set;}
        public string HoraDespacho {get;set;}
        public string TelefonoAgencia {get;set;}
        public Int16 UsuCreCodigo { get; set; }
    }
}
