using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class DocumentoDetalleRequest
    {
        public int CodDocumento { get; set; }
        public Int16 ItemDetalleDocumento { get; set; }
        public int CodGeneral { get; set; }
        public decimal CanDetalleDocumento { get; set; }
        public decimal PreDetalleDocumento { get; set; }
        public decimal TotDetalleDocumento { get; set; }
        public byte CodEmpresa { get; set; }
        public string Descripcion { get; set; }
        public decimal TotalCantidad { get; set; }
        public string Colores { get; set; }
        public string CodExtGeneral { get; set; }
        public decimal Stock { get; set; }
        public bool Caja { get; set; }
        public string CodigoBarra { get; set; }
        public int FlagDespacho { get; set; }
       
        public int FlagInafecto { get; set; }
        public decimal Inafecto { get; set; }
        public decimal Gravado { get; set; }



    }
}
