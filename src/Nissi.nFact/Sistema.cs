using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Nissi.nFact
{
    public class Sistema
    {
        public class Operacion {
            public const string generar_comprobante = "generar_comprobante";
            public const string consultar_comprobante = "consultar_comprobante";
            public const string generar_anulacion = "generar_anulacion";
            public const string consultar_anulacion = "consultar_anulacion";
            public const string generar_guia = "generar_guia";
            public const string consultar_guia = "consultar_guia";


        }

      

        public static string SendJsonBusquedaRUC(string ruta, string json, string token, int VersionTLS)
        {
            string respuesta = string.Empty;
            try
            {
                using (var client = new WebClient())
                {
                    ///System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tl

                    if (VersionTLS.Equals(1))
                    {
                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    }
                    /// ESPECIFICAMOS EL TIPO DE DOCUMENTO EN EL ENCABEZADO
                    client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                    /// ASI COMO EL TOKEN UNICO
                    client.Headers[HttpRequestHeader.Authorization] = "Token token=" + token;

                    /// OBTENEMOS LA RESPUESTA
                    if (json.Length > 0)
                    {

                        respuesta = client.UploadString(ruta, "POST", json);
                    }
                    else
                    {

                        respuesta = client.DownloadString(ruta);
                    }
                    /// Y LA 'RETORNAMOS'
                    return respuesta;
                }
            }
            catch (WebException ex)
            {
                /// EN CASO EXISTA ALGUN ERROR, LO TOMAMOS
                respuesta = ex.Message.ToString();
                /// Y LO 'RETORNAMOS'
                return respuesta;
            }
        }


        public static string SendJson(string ruta, string json, string token, int VersionTLS)
        {
            try
            {
                using (var client = new WebClient())
                {
                    ///System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tl
                    
                    if (VersionTLS.Equals(1))
                    {
                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    }
                    /// ESPECIFICAMOS EL TIPO DE DOCUMENTO EN EL ENCABEZADO
                    client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                    /// ASI COMO EL TOKEN UNICO
                    client.Headers[HttpRequestHeader.Authorization] = "Token token=" + token;
                    /// OBTENEMOS LA RESPUESTA
                    string respuesta = client.UploadString(ruta, "POST", json);

                    if (client.ResponseHeaders != null)
                    {
                        string statusCodeString = client.ResponseHeaders["Status"];

                        if (int.TryParse(statusCodeString, out int statusCode))
                        {
                            Console.WriteLine($"Código de estado: {statusCode}");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo obtener el código de estado.");
                        }

                    }
                    /// Y LA 'RETORNAMOS'
                    return respuesta;
                }
            }
            catch (WebException ex)
            {
                /// EN CASO EXISTA ALGUN ERROR, LO TOMAMOS
                var respuesta = string.Empty;

                if (ex.Response is HttpWebResponse response)
                {
                    respuesta = "Error en la solicitud. Código de estado" + response.StatusCode.ToString();
                }
                else
                {
                    respuesta = "Error en la solicitud. Detalles:" + ex.Message.ToString();
                }

                /// Y LO 'RETORNAMOS'
                return respuesta;
            }
        }

    }
}
