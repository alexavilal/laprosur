using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class SugeridoDetalle
    {

        public int CodigoGeneral { get; set; }
        public int CodigoSugerido { get; set; }
        public string CodigoExterno { get; set; }
        public string DescripcionLarga { get; set; }
        public string DescripcionMarca { get; set; }
        public Decimal Stock { get; set; }
        public string FechaUltimaReposicion { get; set; }
        public Decimal StockMinimo { get; set; }
        public Decimal Sugerido { get; set; }

        public Int16 CodigoEmpaque { get; set; }
        public string TipoEmpaque { get; set; }
        
        public Decimal Pedir { get; set; }

        public Decimal PaquetesSugerido { get; set; }
        public Decimal PaquetesPedir { get; set; }
      
        public Decimal TotalPaquetes { get; set; }

        public bool Aceptado { get; set; }

        public Decimal PrecioCosto { get; set; }
        public Decimal PrecioAnterior { get; set; }
    }
}
