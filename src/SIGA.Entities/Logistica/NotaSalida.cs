using System;

namespace SIGA.Entities.Logistica
{
    public class NotaSalida
    {
        public int NtsCodigo { get; set; }
        public string NtsNumero { get; set; }
        public Int16 CodAlmacen { get; set; }
        public string NtsTransaccion { get; set; }        
        public DateTime NtsFechaEmision { get; set; }
        public DateTime NtsFechaDocumento { get; set; }
        public int CodProveedor { get; set; }
        public string NtsCliente { get; set; }
        public string NtsNroDocReferencia { get; set; }
        public string NtsAutorizado { get; set; }
        public string NtsCentroCosto { get; set; }        
        public Int16 CodMoneda { get; set; }        
        public string NtsComentario { get; set; }        
        public Int16 NtsEstado { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuModCodigo { get; set; }
        public Int16 UsuCodigo { get; set; }
    }

    public class NotaSalidaRequest : NotaSalida
    {
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}
