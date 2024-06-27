using System;

namespace SIGA.Entities.Logistica
{
    public class General : Marca
    {
        public int CodGeneral { get; set; }
        public Int16 CodEmpresa { get; set; }
        public Int16 CodTipoCodigo { get; set; }
        public bool IndCodigoBarra { get; set; }
        public string CodBarra { get; set; }
        public Int16 CodMarca { get; set; }
        public Int16 CodMaterial { get; set; }
        public int CodFamilia { get; set; }
        public int CodSubFamilia { get; set; }
        public string CodExtGeneral { get; set; }
        public string DesLarGeneral { get; set; }
        public string DesCorGeneral { get; set; }
        public Int16 CodColor { get; set; }
        public Int16 CodCapacidad { get; set; }
        public Int16 CodForma { get; set; }
        public string AltoGeneral { get; set; }
        public string LargoGeneral { get; set; }
        public string AnchoGeneral { get; set; }
        public string Cicuferenciageneral { get; set; }
        public decimal Empaque { get; set; }
        public Int16 CodUnidadMedida { get; set; }
        public Int16 CodEmpaque { get; set; }
        public string AltoEmpaque { get; set; }
        public string AnchoEmpaque { get; set; }
        public string LargoEmpaque { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal LeadTime { get; set; }
        public decimal Reposicion { get; set; }

        public string EstCodigo { get; set; }
        public DateTime FecCre { get; set; }
        public int UsuCreCodigo { get; set; }
        public DateTime FecMod { get; set; }
        public int UsuModCodigo { get; set; }
        public Int16 Temporal { get; set; }
        public string Codigo1 { get; set; }
        public string Codigo2 { get; set; }
        public string Codigo3 { get; set; }
        public string Codigo4 { get; set; }
        public string Codigo5 { get; set; }
        public string Codigo6 { get; set; }
        public string Codigo7 { get; set; }
        public string Codigo8 { get; set; }
        public string Codigo9 { get; set; }
        public string Codigo10 { get; set; }
        public string CodigoZurece { get; set; }
        public Int16 CodGeneralClasificacion { get; set; }
        public int CodSeccion { get; set; }
        public int Inafecto { get; set; }

        public bool FlagVenta { get; set; }

        public string Venta { get; set; }

    }
}
