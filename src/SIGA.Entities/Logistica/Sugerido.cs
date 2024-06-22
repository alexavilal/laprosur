using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.Entities.Comunes;

namespace SIGA.Entities.Logistica
{
    public class Sugerido : Sede 
    {
    
      public int CodSugerido {get;set;}
      public Int16 CodSede  {get;set;}
      public string NumeroSugeridoCompras {get;set;}
      public DateTime FechaSugeridoCompras{get;set;}
      public string DescripcionEstado { get; set; }
      public string DescripcionProveedor { get; set; }
      public int CodigoProveedor { get; set; }
      public string Estado {get;set;}
      public Int16 UsuarioCreacion {get;set;}
      public Int16 CodigoEstado { get; set; }
      public Int16 CodigoEmpresa { get; set; }

    }
}
