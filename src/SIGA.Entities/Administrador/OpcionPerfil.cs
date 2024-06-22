using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Administrador
{
    public class OpcionPerfil
    {
        public Int16 CodPerfil { get; set; }
        public Int16 CodOpcion { get; set; }
        public Int16 CodModulo { get; set; }
        public string DesOpcion { get; set; } 
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Int16 UsuCreacion { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
        public Int16 UsuModifica { get; set; } 
    }
}
