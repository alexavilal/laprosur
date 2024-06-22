using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Entities.Logistica
{
    public class Requerimiento
    {
        public int ReqCodigo { get; set; }
        public int CodEmpresa { get; set; }
        public int CodOficina { get; set; }
        public string ReqNumero { get; set; }
        public string ReqFecha { get; set; }
        public string ReqHora { get; set; }
        public string ReqPrioridad { get; set; }
        public string Req_ProductoFabricar { get; set; }
        public string Req_Cantidad { get; set; }
        public string Req_Area { get; set; }
        public string ReqFechaInicio { get; set; }

        public string ReqFechaFinal { get; set; }
        public string Req_CentroCosto { get; set; }
        public string Req_EquipoMaquina { get; set; }
        public string Req_Codigo { get; set; }
        public string Req_Observacion { get; set; }
        public int UsuCodigoSolicitante { get; set; }
        public int UsuCreCodigo { get; set; }
        public DateTime? FecCre { get; set; }
        public int? UsuModCodigo { get; set; }
        public DateTime? FecMod { get; set; }
    }
}
