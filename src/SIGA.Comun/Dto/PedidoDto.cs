namespace SIGA.Comun.Dto
{
    public class PedidoDto
    {

        public int CodigoPedido { get; set; }
        public int CodigoTipoDocumento { get; set; }
        public string NumeroPedido { get; set; }
        public bool FlagProvincia { get; set; }
        public string Fecha { get; set; }
        public string CodigoCliente { get; set; }
        public int CodFormaPago { get; set; }
        public int CodigoDocumentoCliente { get; set; }
        public string NumeroDocumentoCliente { get; set; }
        public int CodTipoCLiente { get; set; }
        public int CodSubTipo { get; set; }
        public int CodCategoria { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int CodigoEstado { get; set; }

    }
}
