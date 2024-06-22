using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Entities.Ventas
{
    public class Transportista
    {
        public int CodTransportista { get; set; } 
        public byte? CodTipoDocumento { get; set; } // Nullable tinyint
        public string NumDocumentoTransportista { get; set; } // varchar(15)
        public string RazSocTransportista { get; set; } // varchar(100)
        public string DirTransportista { get; set; } // varchar(200)
        public char? EstCodigo { get; set; } // Nullable char(1)
        
        public short? UsuCreCodigo { get; set; } // Nullable smallint
      


    }
}
