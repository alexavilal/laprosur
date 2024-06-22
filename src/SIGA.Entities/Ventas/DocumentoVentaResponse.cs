using System; 
using System.Collections.Generic;
using System.Text;

namespace SIGA.Entities.Ventas
{

    public class DocumentoVentaResponse
    {

        public int CodDocumento { get; set; }
        public byte CodEmpresa { get; set; }
        public short CodTipoDocumento { get; set; }
        public string NumDocumentoVenta { get; set; }
        public string CodCliente { get; set; }
        public DateTime FecEmiDocumento { get; set; }
        public string DirDocumentoVenta { get; set; }
        public decimal MonBruDocumento { get; set; }
        public decimal MonImpDocumento { get; set; }
        public decimal DesDocumento { get; set; }
        public decimal MonNetDocumento { get; set; }
        public string GlosaDocumento { get; set; }
        public string NumLetDocumento { get; set; }
        public byte CodMoneda { get; set; }
        public string EstCodigo { get; set; }
        public DateTime FecCre { get; set; }
        public short UsuCreCodigo { get; set; }
        public DateTime FecMod { get; set; }
        public short UsuModCodigo { get; set; }
        public byte CodOrigen { get; set; }
        public int CodigoCaja { get; set; }
        public int CodigoPedido { get; set; }
        public Int16 CodigoVendedor { get; set; }
        public Decimal MontoEfectivo { get; set; }
        public Decimal MontoVuelto { get; set; }
        public int CodigoMaquina { get; set; }
        public string DescripcionPago { get; set; }
        public string TipoFormato { get; set; }
        public decimal MonInaDocumento { get; set; }
        public decimal MonGravDocumento { get; set; }
    }   
}




	