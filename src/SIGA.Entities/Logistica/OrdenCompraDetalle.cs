using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
   public class OrdenCompraDetalle
   {

     
         
           public int CodGeneral { get; set; } 
           public string CodigoExterno { get; set; }
           public string Descripcion { get; set; }
           public decimal CantSugerida { get; set; }
           public decimal PrecioDetalleDocumento { get; set; }

           public decimal SubTotal { get; set; }

           public string UnidadMedida { get; set; }
           public decimal Paquetes { get; set;}
           public decimal CantPedir { get; set; }
           public decimal PorDcto { get; set; }
           public string Com { get; set; }
           public Int16 CodigoEmpresa { get; set; }
           public string RazonSocial { get; set; }
           public Int16 CodTipoItem { get; set; }
           public decimal Dcto { get; set; }
           public Int16 CodAlmacen { get; set; }
           public int CodigoProveeedor { get; set; }
           public string Ruc { get; set; }
           public Int16 CodigoColor { get; set; }
   }
}
