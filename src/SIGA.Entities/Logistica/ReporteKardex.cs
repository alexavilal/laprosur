using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class ReporteKardex
    {
         public int CodKardex {get;set;}
         public int CodGeneral {get;set;}
         public string  DesLarGeneral {get;set;}
         public Int16 CodALmacen {get;set;}
         public Int16 CodEmpresa {get;set;}
         public string DesTipoDocumento {get;set;}
         public string NumDocumento {get;set;}
         public DateTime Fecha {get;set;}
         public string RazonSocial {get;set;}
         public string DesTipoMovimiento  {get;set;}
         public string DesMarca {get;set;}
         public decimal CanEntKardex {get;set;}
         public decimal PreEntKardex {get;set;}
         public decimal TotEntKardex {get;set;}
         public decimal CanSalKardex {get;set;}
         public decimal PreSalKardex {get;set;}
         public decimal TotSalKardex {get;set;}
         public decimal CanSaAKardex {get;set;}
         public decimal PreSaAKardex {get;set;}
         public decimal TotSaAKardex {get;set;}

    
    }


}
