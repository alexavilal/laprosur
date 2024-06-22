using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class GeneralResponse
    {  public int CodGeneral {get;set;}
       public string CodExtGeneral {get;set;}
       public string DesLarGeneral {get;set;}
       public string DesCorGeneral {get;set;}
       public string DesDocumentoGeneral { get; set; }
       public Int16 CodMarca {get;set;}
       public string EstCodigo {get;set;}
       public string CodBarra {get;set;}
       public byte CodEmpresa { get; set; }
       public decimal? PrecioUno { get; set; }
       public decimal? PrecioDos { get; set; }
       public decimal? PrecioTres { get; set; }
       public decimal? PrecioCuatro { get; set; }
       public decimal? stock { get; set; }
       public string Ruta { get; set; }
       public Int16 CodigoUnidadMedidad { get; set; }
       public Int16 CodigoProveedor { get; set; }
       public decimal PrecioEmpresa { get; set; }
       public decimal PrecioCosto { get; set; }
       public int Inafecto { get; set; }
    }
}
