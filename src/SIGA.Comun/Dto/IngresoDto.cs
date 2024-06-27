using System;

namespace SIGA.Comun.Dto
{
    public class IngresoDto
    {
        public Int32 CodIngreso { get; set; }
        public string Numero { get; set; }
        public string Fecha { get; set; }
        public Int16 TipoOrigen { get; set; }
        public string Origen { get; set; }
        public string Movimiento { get; set; }
        public Int16 CodigoMovimiento { get; set; }
        public string Destino { get; set; }
        public Int16 CodigoAlmacenDestino { get; set; }
        public Int16 CodigoEstadoSalida { get; set; }
        public string Estado { get; set; }


    }

}
