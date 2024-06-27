using System;

namespace SIGA.Entities.Logistica
{
    public  class NotaSalidaDetalle
    {
        public int NtsCodigo { get; set; }
        public int NtsItem { get; set; }
        public int CodigoGeneral { get; set; }        
        public int CodUnidadMedida { get; set; }
        public string NtsDescripcion { get; set; }
        public string NtsOrdFabricacion { get; set; }
        public decimal Cantidad { get; set; }        
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuModCodigo { get; set; }
        public Int16 UsuCodigo { get; set; }
    }
}
