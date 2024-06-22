using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Entities.Ventas
{
    public class Guia
    {
        public int GuiCodigo { get; set; }
        public int CodEmpresa { get; set; }
        public int CodOficina { get; set; }
        public int CodTransportista { get; set; }
        public string GuiNumero { get; set; }
        public string GuiVale { get; set; }
        public int CodPolitica { get; set; }
        public int CodZona { get; set; }
        public DateTime? GuiFecha { get; set; }
        public string CodCliente { get; set; }
        public int CodMoneda { get; set; }
        public decimal GuiImporte { get; set; }
        public string GuiPlaca { get; set; }
        public int CodFormaPago { get; set; }
        public int GuiEstado { get; set; }
        public string GuiComentarioAnulacion { get; set; }
        public int UsuCodigo { get; set; }
        public int UsuCreCodigo { get; set; }
    }
}
