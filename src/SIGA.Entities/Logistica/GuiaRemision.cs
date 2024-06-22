using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class GuiaRemision
    {

        public int CodGuia { get; set; }
        public string NumGuia { get; set; }
        public int CodEmpresa { get; set; }
        public string FechaGuia { get; set; }
        public string PartidaGuia { get; set; }
        public string LlegadaGuia { get; set; }
        public string RazonGuia { get; set; }
        public string RucGuia { get; set; }
        public string DircGuia { get; set; }
        public string TraGuia { get; set; }
        public string TraRucGuia { get; set; }
        public string DirTraGuia { get; set; }
        public string LocTraGuia { get; set; }
        public string PlaVehGuia { get; set; }
        public string CodTipoDocumento { get; set; }
        public string NumTipoDocumento { get; set; }
        public string EntregadoGuia { get; set; }
        public string AutorizadoGuia { get; set; }
        public string RecibidoGuia { get; set; }
        public byte CodTipoMovimiento { get; set; }
        public string EstCodigo { get; set; }
        public Int16 UsuCreCodigo { get; set; }
        public int CodigoTraslado { get; set; }
        public int CodigoDocumento { get; set; }
        public String operacion { get; set; }
        public int CodTipoGuia { get; set; }
        public int tipo_de_comprobante { get; set; }
        public String serie { get; set; }
        public int numero { get; set; }
        public int cliente_tipo_de_documento { get; set; }
        public String cliente_numero_de_documento { get; set; }
        public String cliente_denominacion { get; set; }
        public String cliente_direccion { get; set; }
        public String cliente_email { get; set; }
        public String cliente_email_1 { get; set; }
        public String cliente_email_2 { get; set; }
        public String fecha_de_emision { get; set; }
        public String observaciones { get; set; }
        public String motivo_de_traslado { get; set; }
        public Decimal peso_bruto_total { get; set; }
        public String peso_bruto_unidad_de_medida { get; set; }
        public int numero_de_bultos { get; set; }
        public String tipo_de_transporte { get; set; }
        public String fecha_de_inicio_de_traslado { get; set; }
        public int transportista_documento_tipo { get; set; }
        public String transportista_documento_numero { get; set; }
        public String transportista_denominacion { get; set; }
        public String transportista_placa_numero { get; set; }
        public int ?conductor_documento_tipo { get; set; }
        public String conductor_documento_numero { get; set; }
        public String conductor_nombre { get; set; }
        public String conductor_apellidos { get; set; }
        public String conductor_numero_licencia { get; set; }
        public String punto_de_partida_ubigeo { get; set; }
        public String punto_de_partida_direccion { get; set; }
        public String punto_de_llegada_ubigeo { get; set; }
        public String punto_de_llegada_direccion { get; set; }
        public String punto_de_llegada_codigo_establecimiento { get; set; }
        public String enviar_automaticamente_al_cliente { get; set; }
        public String formato_de_pdf { get; set; }

    
    }

    public class DocumentoRelacionadoGuiaRemision
    {
        public int CodGuia { get; set; }
        public int CodDocumento { get; set; }
        public int idDetalleDocumento { get; set; }
        public string tipo { get; set; }
        public string  serie { get; set; }
        public int numero { get; set; }
    }
    public class VehiculoAdicionalGuiaRemision
    {
        public int CodGuia { get; set; }

        public int idDetalleGuia { get; set; }

        public string placa_numero { get; set; }

    }
    
    public class ConductoresSecundarios
    {
        public int documento_tipo { get; set; }

        public string documento_numero { get; set; }
        public string nombre { get; set; }

        public string apellidos { get; set; }

        public string numero_licencia { get; set; }


    }

}
