using System;

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
            this.Mensaje = mensaje;
        }

    }
}
