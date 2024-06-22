using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class PaseDinero
    {   

        public int CodPase {get;set;}
        
        public int CodCaja {get;set;}

        public Int16 CodMoneda {get;set;}

        public decimal ImpPase {get;set;}
 
        public string EstCodigo {get;set;}

        public DateTime FecReg {get;set;}

        public Int16 UsuCre {get;set;}


    }
}
