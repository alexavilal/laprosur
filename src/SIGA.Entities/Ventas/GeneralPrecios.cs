using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class GeneralPrecios
    {   

        public int CodGeneral	{get;set;}
        public decimal PrecioReposicion	{get;set;}
        public bool DctoTCUno {get;set;}
        public bool  DctoCCUno {get;set;}
        public bool DctoPEUno {get;set;}
        public decimal PrecioRangoUno {get;set;}
        public bool DctoTCDos {get;set;}
        public bool   DctoCCDos {get;set;}
        public bool  DctoPEDos {get;set;}
        public decimal PrecioRangoDos {get;set;}
        public bool DctoTCTres {get;set;}
        public bool   DctoCCTres {get;set;}
        public bool  DctoPETres {get;set;}
        public decimal PrecioRangoTres {get;set;}
        public Int16 CodigoUsuario { get; set; }

  
    }
}
