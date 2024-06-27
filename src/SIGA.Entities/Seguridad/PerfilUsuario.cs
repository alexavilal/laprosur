using System;

namespace SIGA.Entities.Seguridad
{
    public class PerfilUsuario
    {
        public Int16 CodPerfil { get; set; }
        public string DesPerfil { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Int16 UsuCreacion { get; set; }
        public Int16 UsuModifica { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
        public Int16 UsuCodigo { get; set; }
        public Int16 CodPerfilUsuario { get; set; }
    }
}
