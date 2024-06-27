using System;

namespace SIGA.Entities.Logistica
{
    public class RequerimientoDetalle
    {
        public int ReqCodigo { get; set; }
        public int CodGeneral { get; set; }
        public int Item { get; set; }
        public decimal Cantidad { get; set; }
        public int CodUnidadMedida { get; set; }
        public string Marca { get; set; }
        public string SalidaAlmacen { get; set; }
        public int? UsuCreCodigo { get; set; }
        public DateTime? FecCre { get; set; }
        public int? UsuModCodigo { get; set; }
        public DateTime? FecMod { get; set; }
    }
}
