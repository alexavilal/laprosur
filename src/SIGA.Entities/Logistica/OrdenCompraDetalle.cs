using System;

namespace SIGA.Entities.Logistica
{
    public class OrdenCompraDetalle
    {
        public int OrdCodigo { get; set; }
        public int OrdItem { get; set; }
        public int OrdCodigoGeneral { get; set; }
        public decimal Cantidad { get; set; }
        public int CodUnidadMedida { get; set; }
        public string OrdDescripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCre { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuMod { get; set; }
    }
}