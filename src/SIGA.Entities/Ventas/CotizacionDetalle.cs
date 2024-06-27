namespace SIGA.Entities.Ventas
{
    public class CotizacionDetalle
    {
        public int CotCodigo { get; set; }
        public int CodGeneral { get; set; }
        public int Item { get; set; }
        public int CodUnidadMedida { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public int UsuCreCodigo { get; set; }
    }

}
