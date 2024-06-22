using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class Salida
    {
       public int CodSalida {get;set;}
       public DateTime FecSalida {get;set;}
       public Int16 CodSede {get;set;}
       public Int16 CodAlmacen {get;set;}
       public string NumSalida {get;set;}
       public Int16 CodTipoMovimiento {get;set;}
       public Int16 CodEstSalida {get;set;}
       public Int16 CodAlmacenDestino {get;set;}
       public int? CodigoTipoDocumento { get; set; }
       public string NumeroDocumento { get; set; }
       public int TipoEntidad { get; set; }
       public int CodigoEntidad { get; set; }
       public string EstCodigo {get;set;}
       public Int16 UsuCreCodigo {get;set;}
       public Int16 UsuResponsable { get; set; }
       public string Estibadores { get; set; }
     public Int16 Recibido {get;set;}
    
    }
}
