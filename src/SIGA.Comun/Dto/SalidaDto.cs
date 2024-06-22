using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Comun.Dto
{
    public class SalidaDto
    {
        public Int32 CodSalida { get; set; }
        public string Numero { get; set; }
        public string Fecha { get; set; }
        public string Sede { get; set; }
        public string Origen { get; set; }
        public string Movimiento { get; set; }
        public Int16 CodigoMovimiento { get; set; }
        public string Destino { get; set; }
        public Int16 CodigoEstadoSalida { get; set; }
        public string Estado { get; set; }
        public Int16 CodigoAlmacenDestino { get; set; }
        public string EstadoTraslado { get; set; }
       
    }
}
