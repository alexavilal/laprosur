using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class SolicitudCotizacionRequest
    {

       public int CodSol {get;set;}
       public DateTime  FecSol {get;set;}
       public string   CodCliente {get;set;}
       public byte  CodTipoSol {get;set;}
       public string   ContSol  {get;set;}
       public string  AreSol {get;set;}
       public string EstSol {get;set;}
       public string EstCodigo {get;set;}
       public string FecCre {get;set;}
       public Int16 UsuCreCodigo {get;set;}
       public string FecMod {get;set;}
       public Int16 UsuModCodigo {get;set;}
       public string Glosa { get; set; }

    }
}
