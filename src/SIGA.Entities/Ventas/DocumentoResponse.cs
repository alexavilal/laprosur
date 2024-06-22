using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class DocumentoResponse
    {
        public int CodigoDocumento { get; set; }
        public string DesEmpresa { get; set; }
        public string Documento { get; set; }
        public string NumDocumentoVenta { get; set; }
        public string Fecha { get; set; }
        public string NombreCliente { get; set; }
        public string Moneda { get; set; }
        public Decimal ImporteBruto { get; set; }
        public Decimal Impuesto { get; set; }
        public Decimal Neto { get; set; }
        public string Estado { get; set; }

    }
}
