using System;

namespace SIGA.Entities.Ventas
{
    public class ClienteContacto
    {
        public Int16 CodClienteContacto { get; set; }
        public string CodCliente { get; set; }
        public string NomConCliente { get; set; }
        public string ApellidoConCliente { get; set; }
        public DateTime FecNacConCliente { get; set; }
        public string CargoConCliente { get; set; }
        public string CorConCliente { get; set; }
        public string AreaConCliente { get; set; }
        public string TeleConCliente { get; set; }
        public string operador1 { get; set; }
        public string operador2 { get; set; }
        public Int16 CodOperador { get; set; }
        public string CelConCliente1 { get; set; }
        public Int16 CodOperador2 { get; set; }
        public string CelConCliente2 { get; set; }
        public string EstCodigo { get; set; }
        public DateTime FecCre { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public DateTime FecMod { get; set; }
        public Int16 UsuModCodigo { get; set; }

    }
}
