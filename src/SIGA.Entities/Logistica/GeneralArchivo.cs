using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class GeneralArchivo : TipoArchivo
    {
       public  int CodGeneral	 {get;set;}
       public int CodGeneralArchivo {get;set;}
       public string RutaArchivoGeneral {get;set;}
       public Int16 UsuCreCodigo {get;set;}
       public DateTime FecCre {get;set;}
       public Int16 UsuModCodigo {get;set;}
       public DateTime FecMod {get;set;}
       public Int16 CodTipoArchivo { get; set; }
  
    }
}
