using System;

namespace SIGA.Entities.Seguridad
{
    public class Perfil
    {
        public Int16 CodPerfil { get; set; }
        public string DesPerfil { get; set; }
        public string EstadoPerfil { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Int16 UsuCreacion { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
        public Int16 UsuModifica { get; set; }



    }
}
