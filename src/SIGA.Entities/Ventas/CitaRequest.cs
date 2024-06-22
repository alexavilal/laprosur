using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class CitaRequest
    {
        public int CodCita { get; set; }
        public string DesCita { get; set; }
        public DateTime FecCita { get; set; }
        public DateTime HorCita { get; set; }
        public string CodCliente { get; set; }
        public string NomComCliente { get; set; }
        public string LugCita { get; set; }
        public string DirCita { get; set; }
        public string RecCita { get; set; }
        public Int16 CodInvitado1 { get; set; }
        public Int16 CodInvitado2 { get; set; }
        public Int16 CodInvitado3 { get; set; }
        public string EstCodigo { get; set; }
        public Int16 UsuCreCodigo { get; set; }

    }
}
