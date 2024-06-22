using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class OrdenCompra
    {
        public int CodOrdenCompra { get; set; }
        public string NumeroOrdenCompra { get; set; }
        public DateTime FechaOrdenCompra { get; set; }
        public string DesSede { get; set; }
        public string RazonSocial { get; set; }
        public int ProCodigo { get; set; }
        public Int16 CodPago { get; set; }
        public Int16 CodMoneda { get; set; }
        public Int16 CodTipoPedido { get; set; }
        public Int16 CodTipoDescuento { get; set; }
        public string EstCodigo { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public Int16 CodSede { get; set; }
        public int CodigoProveedor { get; set; }
        public Int16 CodTipoOrden  { get; set; }
        public Int16 CodFormaPago { get; set; }
        public int CodigoOrdenOrigen { get; set; }
        public Int16 CodigoTipoDcto { get; set; }
        public Int16 CodOrdenEstado { get; set; }
        public Decimal SubTotalOrdenCompra {get;set;}
        public Decimal DctoOrdenCompra  {get;set;}
        public Decimal NetoOrdenCompra {get;set;}
        public Decimal IGVOrdenCompra {get;set;}
        public Decimal TotalOrdenCompra {get;set;}
        public int? Alm_Codigo {get;set;}
        public Int16 CodEmpresa {get;set;}
        public int? CodSugerido {get;set;}
        public int? UsuAutorizado {get;set;}
        public DateTime FechaDespacho { get; set; }
        public Int16 UsuContacto { get; set; }
        public Decimal TipoCambio { get; set; }
        public bool PreciosConIGV { get; set; }

    }
}



