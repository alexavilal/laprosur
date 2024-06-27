using System;

namespace SIGA.Entities.Logistica
{
    public class OrdenCompra
    {
        public int OrdCodigo { get; set; }
        public string OrdNumero{ get; set; }
        public DateTime OrdFechaEmision { get; set; }
        public DateTime OrdFechaEntrega { get; set; }
        public int CodProveedor { get; set; }
        public Int16 CodMoneda { get; set; }
        public string OrdDireccion { get; set; }
        public string OrdNroRuc { get; set; }
        public string OrdContacto { get; set; }
        public string OrdTelefono { get; set; }        
        public int CodFormaPago { get; set; }
        public string OrdReferencia { get; set; }
        public string OrdNroCuentaCorriente { get; set; }
        public string OrdSolicitatoPor { get; set; }
        public string OrdNroCotizacion { get; set; }
        public string OrdObservacion { get; set; }
        public Int16 OrdEstado { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuModCodigo { get; set; }
        public Int16 UsuCodigo { get; set; }
    }

    public class OrdenCompraRequest: OrdenCompra
    {
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }

    public class OrdenCompraResponse: OrdenCompra
    {
        public decimal Total { get; set; }
        public string DesMoneda { get; set; }
        public string DesProveedor { get; set; }

        public string OrdFechaEmisionFormato
        {
            get
            {
                return OrdFechaEmision.ToString("dd/MM/yyyy");
            }
        }

    }
}



