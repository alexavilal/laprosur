
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class CotizacionResponse
    {
        public string Numero { get; set; }
        public string Fecha { get; set; }
        public int Codigo { get; set; }
        public string Empresa { get; set; }
        public string CodigoCliente { get; set; }
        public string RazonSocial { get; set; }
        public Int16 CodigoEstado { get; set; }
        public string DesTipo {get;set;}
        public string CodTipo { get; set; }
        public string Vendedor { get; set; }

    }
}
