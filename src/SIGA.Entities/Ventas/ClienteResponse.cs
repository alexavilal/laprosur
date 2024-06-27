using System;

namespace SIGA.Entities.Ventas
{
    public class ClienteResponse
    {
        public string CodCliente { get; set; }
        public string DesTipoDocumento { get; set; }
        public string NumDocumentoCliente { get; set; }
        public string RazSocCliente { get; set; }
        public string NomCliente { get; set; }
        public string NomComCliente { get; set; }
        public string Est_Codigo { get; set; }


        public Int16 CodTipoDocumento { get; set; }
        public Int16 CodSubTipo { get; set; }
        public Int16 CodTipoCliente { get; set; }

        public string ApePatCliente { get; set; }
        public string ApeMatCliente { get; set; }
        public string DirCliente { get; set; }
        public string Correo { get; set; }
        public string Sexo { get; set; }
        public Int16 CodFormaPago { get; set; }
        public decimal LineaCreditoCliente_1 { get; set; }
        public decimal LineaCreditoCliente_2 { get; set; }
        public decimal SaldoCreditoCliente_1 { get; set; }
        public decimal SaldoCreditoCliente_2 { get; set; }
        public Int16 UsuVendedorInicio { get; set; }
        public Int16 UsuRepresentante { get; set; }
        public string DesTipoCliente { get; set; }
        public string DesSubTipo { get; set; }
        public DateTime FechaAniveCliente { get; set; }
        public string PaginaWeb { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public Int16 UsuMod { get; set; }
        public Int16 CodigoCategoria { get; set; }

        public int CodPolitica { get; set; }

        public int CodUsuarioVendedor { get; set; }

        public string DesPolitica { get; set; }

        public string Vendedor { get; set; }

        public string PlacaVehiculo { get; set; }
    }
}
