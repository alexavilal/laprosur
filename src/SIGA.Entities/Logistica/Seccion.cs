using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Entities.Logistica
{
    public class Seccion
    {
        public int CodigoSeccion { get; set; }

        public string DescripcionSeccion { get; set; }

        public string DescripcionCorta { get; set; }

        public int CodigoAlmacen { get; set; }

        public short UsuarioCreacion { get; set; }

        public string DescripcionAlmacen { get; set; }
    }
}
