using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public  class Ajuste
    {
        public int CodAjuste { get; set; }
        public string NumAjuste { get; set; }
        public Int16  CodTipoMovimiento { get; set; }
        public DateTime FecAjuste { get; set; }
        public DateTime FecAjuste_Fin { get; set; }
        public Int16  CodSede { get; set; }
        public Int16  CodAlmacen { get; set; }
        public string MotAjuste  { get; set; }
        public string EstCodigo  { get; set; }
        public Int16 UsuCre { get; set; }
        public string Sede { get; set; }
        public string Almacen { get; set; }
        public string Usuario { get; set; }
        public DateTime FecCre { get; set; }
        public string hola { get; set; }
    }
}
