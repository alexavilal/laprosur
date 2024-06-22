using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class DetallePedidoResponse
    {
        public string CodigoBarra { get; set; }
        public int ItemDetallePedido { get; set; }
        public int CodigoGeneral { get; set; }
        public string CodigoArticulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Stock { get; set; }
        public string Color { get; set; }
        public decimal ItemPrecioPedido { get; set; }
        public decimal ItemCantidadPedido { get; set; }
        public decimal ItemTotalPedido { get; set; }
        public int CodDocumento { get; set; }
        public byte CodEmpresa { get; set; }
        public string DescripcionAdicional { get; set; }
        public string Observacion { get; set; }
        public string UnidadMedida {get;set;}
        public string Ruta {get;set;}
        public Int16 CodigoUnidadMedida { get; set; }
        public Int32 CodigoPedido { get; set; }
        public decimal PorDcto { get; set; }
        public decimal MontoDcto { get; set; }
        public bool Flag { get; set; }
     
    }
}
