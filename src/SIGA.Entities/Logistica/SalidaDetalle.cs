using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class SalidaDetalle
    {

        public int CodSalida { get; set; }
        public int CodGeneral { get; set; }
        public decimal StoSalidaDetalle { get; set; }
        public decimal CanSalidaDetalle { get; set; }
        public Int16 CodigoEmpresa { get; set; }
        public string Comentario { get; set; }

    }

}
