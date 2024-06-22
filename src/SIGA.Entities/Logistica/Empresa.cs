using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class Empresa
    {
        public Int16 CodEmpresa { get; set; }
        public string DesEmpresa { get; set; }
        public string CorEmpresa { get; set; }
        public string RucEmpresa { get; set; }
        public string DirEmpresa { get; set; }
        public string TelEmpresa { get; set; }
        public string EstCodigo { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuModCodigo { get; set; }
    
    }
}
