using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Administrador
{
    public class Opcion
    {
        public Int16 CodOpcion { get; set; }
        public Int16 CodModulo { get; set; }
        public string DesOpcion	 { get; set; }
        public string DesModulo { get; set; }
        public string RutOpcion	 { get; set; }
        public string EstCodigo	 { get; set; }
        public Nullable<System.DateTime> FecCre	 { get; set; }
        public Int16 UsuCre	 { get; set; }
        public Nullable<System.DateTime> FecMod	 { get; set; }
        public Int16 UsuMod { get; set; }
    }
}
