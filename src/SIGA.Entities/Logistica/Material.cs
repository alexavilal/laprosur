using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{

    public class Material
    {

        public Int16 CodMaterial { get; set; }
        public string DesMaterial { get; set; }
        public string Estado { get; set; }
        public string UsuCrea { get; set; }
        public string FecCrea { get; set; }

        public string UsuModi { get; set; }
        public string FecModi { get; set; }
       

    }
}
