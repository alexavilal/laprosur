using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class OrdenCompraHistorial
    {

        public int CodOCH{get;set;}
        public int  CodOrdenCompra {get;set;}
        public Int16 CodOrdenEstadoAnterior {get;set;}
        public Int16 CodOrdenEstado {get;set;}
        public string  FechaOCH {get;set;}
        public string ObservacionOCH {get;set;}
        public string EstCodigo {get;set;}
        public Int16 UsuCodigo { get; set; }
        public Int16 CodigoFormaPago { get; set; }
        public string FechaDespacho { get; set; }

    }
}
