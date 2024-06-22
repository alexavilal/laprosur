using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class Kardex
    {
        public int CodKardex {get;set;}
        public int CodGeneral {get;set;}
        public Int16 CodALmacen {get;set;}
        public Int16 CodEmpresa  {get;set;}
        public string CodTipoDocumento {get;set;}
        public string NumDocumento {get;set;}
        public Int16 CodTipoEntidad {get;set;}
        public int Codigo {get;set;}
        public Int16 CodigoTipoMovimiento {get;set;}
        public DateTime FechaKardex {get;set;}
        public Decimal CanEntKardex {get;set;}
        public Decimal PreEntKardex {get;set;}
        public Decimal TotEntKardex {get;set;}
        public Decimal CanSalKardex {get;set;}
        public Decimal PreSalKardex {get;set;}
        public Decimal TotSalKardex {get;set;}
        public Decimal CanSaAKardex {get;set;}
        public Decimal PreSaAKardex {get;set;}
        public Decimal TotSaAKardex {get;set;}

    }
}
