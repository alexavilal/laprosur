using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Mantenimientos
{
    public class ManGeneralRequest
    {
        public int CodGeneral { get; set; }
        public string CodExtGeneral { get; set; }
        public string DesCorGeneral { get; set; }
        public string DesLarGeneral { get; set; }
        public Int16 CodMarca { get; set; }
        public string EstCodigo { get; set; }
        public string CodBarra { get; set; }
        public Int16 CodEmpresa { get; set; }
        public int CodFamilia { get; set; }
        public int CodSubFamilia { get; set; }
        public string RutaArchivoGeneral { get; set; }
        public Int16 CodUnidadMedida { get; set; }
    

    }
}
