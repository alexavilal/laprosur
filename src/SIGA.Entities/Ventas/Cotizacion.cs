using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Entities.Ventas
{
    public class Cotizacion
    {
        public int CotCodigo { get; set; }
        public int? CodEmpresa { get; set; }
        public int? CodOficina { get; set; }
        public string CotNumero { get; set; }
        public int? CodPolitica { get; set; }
        public int? CodZona { get; set; }
        public DateTime? CotFecha { get; set; }
        public string CodCliente { get; set; }
        public int? CodMoneda { get; set; }
        public decimal? CotImporte { get; set; }
        public int? CotEstado { get; set; }
        public int? UsuCodigo { get; set; }
        public int? UsuCreCodigo { get; set; }
        public DateTime? FecCre { get; set; }
        public int? UsuModCodigo { get; set; }
        public DateTime? FecMod { get; set; }
    }

}
