using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class DetalleDocumentoIngreso
    {



        public int CodGeneral { get; set; }
        public string CodigoExterno { get; set; }
        public string Descripcion { get; set; }
        public int CodOrdenCompra { get; set; }
        public decimal TotOrdenCompra { get; set; }
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
        public decimal TotalIngresado { get; set; }
        public Int16 CodigoEmpresa { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal TotalRecibido { get; set; }
        public decimal Faltante { get; set; }
        public int CodigoGuia { get; set; }
        public decimal? Precio { get; set; }
        
    }
}
