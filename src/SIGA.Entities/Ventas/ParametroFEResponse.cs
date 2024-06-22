using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class ParametroFEResponse
    {
        public int CodParametroFE { get; set; }
        public string DesParametroFE { get; set; }
        public string ValParametroFE { get; set; }
        public int CodEmpresa { get; set; }
        public DateTime FecCre { get; set; }
        public int UsuCreCodigo { get; set; }
        public string DesEmpresa { get; set; }
        public string Usuario { get; set; }
    }
}
