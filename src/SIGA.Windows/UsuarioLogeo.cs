using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGA.Windows
{

    static class UsuarioLogeo
    {


        public static Int16 Codigo;
        public static string Nombre;
        public static string UsuarioCaja;
        public static string UsuarioSession;

        public static void Inicializar()
        {
            Codigo = 0;
            Nombre = string.Empty;
            UsuarioCaja = string.Empty;
            UsuarioSession = string.Empty;
        }

       
    }

    static class Variables
    {
        public static Int32 TLS12{ get;set;}
    }
}