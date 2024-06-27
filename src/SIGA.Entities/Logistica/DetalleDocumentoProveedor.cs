using System;

namespace SIGA.Entities.Logistica
{
    public class DetalleDocumentoProveedor
    {

        public int Codigo { get; set; }
        public int CodigoItem { get; set; }
        public string NumeroGuia { get; set; }
        public int CodigoGeneral { get; set; }
        public string CodigoExterno { get; set; }
        public string DescripcionLarga { get; set; }
        public string UnidadMedida { get; set; }
        public Int16 CodigoEmpresa { get; set; }
        public Int16 CodigoAlmacen { get; set; }
        public Decimal Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Total { get; set; }
        public string NumeroOrden { get; set; }

    }
}
