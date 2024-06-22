using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class ProveedorContacto
    {
        public int ProCodigo { get; set; }
        public int CodProveedorContacto { get; set; }
        public string  NomProveedorContacto { get; set; }
        public string CarProveedorContacto { get; set; }
        public string AreProveedorContacto { get; set; }
        public Int16 CodOperador { get; set; }
        public string NumTelProveedorContacto { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuModCodigo { get; set; }
        public DateTime FecMod { get; set; }
        public string Operador { get; set; }
        public string CorreoElectronico { get; set; }
        
    }
}
