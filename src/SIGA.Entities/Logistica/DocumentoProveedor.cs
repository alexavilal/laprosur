using System;

namespace SIGA.Entities.Logistica
{
    public class DocumentoProveedor
    {

        public int Codigo { get; set; }
        public string CodTipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public DateTime FecDocumento { get; set; }
        public DateTime FecRecepcion { get; set; }
        public int ProCodigo { get; set; }
        public Int16 CodEmpresa { get; set; }
        public Int16 CodMoneda { get; set; }
        public Decimal TipoCambio { get; set; }
        public Int16 CodigoEstado { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal Impuesto { get; set; }
        public Decimal Total { get; set; }
        public bool IncluyeIGV { get; set; }
        public Int16 UsuarioCreacion { get; set; }
        public bool Compra { get; set; }
        public Int16 CodigoAlmacen { get; set; }



    }
}
