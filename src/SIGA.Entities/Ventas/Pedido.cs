using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Ventas
{
    public class Pedido
    {

        public Int16 CodTipoDocumento {get;set;}
        public string CodCliente {get;set;}
        public string DirEmiPedido {get;set;}
        public byte CodMoneda {get;set;}
        public Decimal BruEmiPedido {get;set;}
        public Decimal DtoEmiPedido {get;set;}
        public Decimal NetEmiPedido {get;set;}
        public byte CodSede { get; set; }
        public Decimal MonDolares {get;set;}
        public Decimal MonCredito {get;set;}
        public Decimal MonCuentaPedido {get;set;}
        public string RazSocPedido  {get;set;}
        public string DirPedido {get;set;}
        public string CorNumPedido {get;set;}
        public int CodPedido {get;set;}
        public string CodTipo { get; set; }
        public bool? DesAdiPedido { get; set; }
        public string DesSede { get; set; }
        public string FechaEmision { get; set; }
        public string Estado { get; set; }
        public byte CodPedidoEstado {get;set;}
        public byte CodEmpresa {get;set;}
        public string SecEmpresa {get;set;}
        
        public ClienteResponse Cliente { get; set; }
        public byte CodValidez { get; set; }
        public string DesValidez { get; set; }
        public byte CodLugar { get; set; }
        public string DesLugar { get; set; }
        public string TiempoEntrega { get; set; }
        public int CodTipoPago { get; set; }
        public string DesTipoPago { get; set; }
        public byte CodBanco { get; set; }
        public string DesBanco { get; set; }
        public string NumCuenta { get; set; }
        public Int16 CodTipoCliente { get; set; }
        public Int16 CodSubTipo { get; set; }
        public Int16 CodTipoDocumentoCliente { get; set; }
        public string NumeroDocumentoCliente { get; set; }
        public string DireccionCliente { get; set; }

        public string LugarEntrega { get; set; }
        public Int16 TiempoEntregaDias { get; set; }
        public int CodMedio { get; set; }
        public string DesMedio { get; set; }
        public string Correo { get; set; }
        public Int16 CodigoUsuario { get; set; }
        public Int16 TipoPedido { get; set; }
        public bool FlagProvincia { get; set; }

       
        public int CodTarjeta { get; set; }

    }
}
