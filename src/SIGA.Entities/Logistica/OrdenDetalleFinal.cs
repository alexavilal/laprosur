using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class OrdenDetalleFinal
    { 
        public int CodOrdenCompra	{get;set;}
        public int CodGeneral	{get;set;}
        public decimal PrecioDetalleOrdenCompra {get;set;}
        public decimal CantPedDetalleOrdenCompra {get;set;}
        public decimal SubTotalDetalleOrdenCompra {get;set;}
        public decimal Alm1 { get; set; }
        public decimal Alm2 { get; set; }
        public decimal Alm3 { get; set; }
        public decimal Alm4 { get; set; }
        public decimal Alm5 { get; set; }
        public decimal Alm6 { get; set; }
        public decimal Alm7 { get; set; }
        public decimal Alm8 { get; set; }
        public decimal Alm9 { get; set; }
        public decimal Alm10 { get; set; }
        public Decimal PrecioAnterior { get; set; }
        public string Origen { get; set; }
        public string CodigoExterno { get; set; }
        public string Descripcion { get; set; }


    }
}
