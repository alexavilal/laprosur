using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Entities.Ventas
{
     public class GuiaDetalle
    {
        public int GuiCodigo { get; set; }
        public decimal Cantidad {  get; set; }  
        public int CodGeneral { get; set; }
        public string Descripcion { get; set; }
        public int CodUnidadMedida { get; set; }
        public string Pampa { get; set; }
        public string Quema { get; set; }
        public decimal Precio {  get; set; }
        public decimal Descuento { get; set; }

        public decimal Total { get; set; }
    }
        
}

