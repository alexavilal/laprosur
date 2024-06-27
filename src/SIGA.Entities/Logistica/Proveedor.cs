using System;

namespace SIGA.Entities.Logistica
{
    public class Proveedor
    {
        public int ProCodigo { get; set; }
        public string ProRazonSocial { get; set; }
        public string ProNombreComercial { get; set; }
        public Int16 CodTipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string ProPaginaWeb { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FecAniProveedor { get; set; }
        public DateTime FecCreacion { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public string Estado { get; set; }
        public byte ProConMarca { get; set; }
        public string TipoDocumento { get; set; }
        public string Direccion { get; set; }
    }

    public class ProveedorRequest: Proveedor { }

    public class ProveedorResponse : Proveedor { }
}
