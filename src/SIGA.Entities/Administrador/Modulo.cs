using System;


namespace SIGA.Entities.Administrador
{
    public class Modulo
    {
        public int CodigoModulo { get; set; }
        public string DescripcionModulo { get; set; }
        public string EstadoModulo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Int16 UsuCreacion { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
        public Int16 UsuModifica { get; set; }
    }
}
