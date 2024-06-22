using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class DocumentoNoVenta
    {
        public int CodDocNoVenta { get; set; }
        public string CodTipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public int ProCodigo { get; set; }
        public DateTime FecDocumento { get; set; }
        public Int16 CodMoneda { get; set; }
        public Int16 CodTipoMovimiento { get; set; }
        public Int16 CodEmpresa { get; set; }
        public Int16 CodTipoEntidad { get; set; }
        public Int16 CodTipoDocumentoDos { get; set; }
        public string NumeroDocumentoDos { get; set; }
        public string OrdenCompra { get; set; }
        public string Gui_Numero { get; set; }

        public Int16 CodEstSalida { get; set; }
        public Int16 CodSede { get; set; }
        public Int16 CodAlmacen { get; set; }
        public Int16 CodigoUsuario { get; set; }
        public Int16 CodigoSalida { get; set; }




    }
}
