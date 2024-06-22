using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class CajaRequest
    {
      public int CodCaja {get;set;}
      public Int16 CodSede {get;set;}
      public DateTime FecCaja {get;set;}      
      public Int16 CodEstadoCaja {get;set;}
 	  public Int16 CodMonedaSoles {get;set;}
      public decimal MontoSoles {get;set;}
      public Int16 CodMonedaDolares {get;set;}
      public decimal MontoDolares {get;set;}
	  public Int16 UsuCodigo {get;set;}
      public string EstCodigo {get;set;}
	  public Int16 UsuCreCodigo {get;set;}
      public Int16 CodTipoCaja { get; set; }
    
    }
}
