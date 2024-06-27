using System;

namespace SIGA.Entities.Logistica
{
    public class ProveedorMarca
    {
        public int ProCodigo { get; set; }
        public int CodProveedorMarca { get; set; }
        public Int16 CodMarca { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuModCodigo { get; set; }
        public DateTime FecMod { get; set; }
        public string Marca { get; set; }
    }
}
