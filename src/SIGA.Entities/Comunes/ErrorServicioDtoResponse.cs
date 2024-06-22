using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Entities.Comunes
{ 
    public class ErrorServicioDtoResponse
    {
         
        public TipoErrorServicioDtoResponse Tipo { get; set; }
        
        public DateTime Fecha { get; set; }
        
        public string Mensaje { get; set; }
        
        public string Codigo { get; set; }

        
        public string CodigoReglaNegocio { get; set; }

        public ErrorServicioDtoResponse()
        {
            Fecha = DateTime.Now;
        }

        public ErrorServicioDtoResponse(string codigo, string mensaje)
        {
            this.CodigoReglaNegocio = codigo;
            this.Mensaje = mensaje ;
        }

    }
}
