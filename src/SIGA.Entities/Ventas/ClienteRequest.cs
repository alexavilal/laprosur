using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class ClienteRequest
    {
        public string CodCliente { get; set; }
        public Int16 CodTipoDocumento { get; set; }
        public string NumDocumentoCliente { get; set; }
        public string RazSocCliente { get; set; }
        public string DirCliente { get; set; }
        public Int16 TipoCLiente { get; set; }
        public Int16 SubTipoCLiente { get; set; }
        public Int16 CodigoUsuario { get; set; }
        
    }
}
