using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class DetalleGuiaRemision
    { 
        public int CodGuia {get;set;}
        public int CodGeneral {get;set;}
        public decimal CanDGR {get;set;}
        public string UnidadDGR { get; set; }
        public string  DesDGR{get;set;}
        public string EstCodigo { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public string unidad_de_medida { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }

    }
}
