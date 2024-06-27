using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Nissi.nFact
{
    public class Servicios
    {
        public static string ruta { get; set; }
        public static string token { get; set; }


        public static async Task<string> TotalConsultas(string url, string token, int VersionTLS)
        {
            // Simulación de una operación asíncrona, como hacer una solicitud HTTP.
            string result = string.Empty;
            string strJson = string.Empty;

            using (WebClient client = new WebClient())
            {
                try
                {
                    if (VersionTLS.Equals(1))
                    {
                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    }

                    client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                    /// ASI COMO EL TOKEN UNICO
                    client.Headers[HttpRequestHeader.Authorization] = "Token token=" + token;

                    result = await client.DownloadStringTaskAsync(url);


                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
                return result;
            }
        }




        public static Entidades.EmpresaBusqueda BusquedaRucDni(int TipoBusqueda, string NumeroDocumento)
        {
            Entidades.EmpresaBusqueda objEmpresa = new Entidades.EmpresaBusqueda();
            string apiURL = string.Empty;

            try
            {
                switch (TipoBusqueda)
                {
                    case 1: apiURL = "https://api.apis.net.pe/v2/sunat/ruc?numero=" + NumeroDocumento; break;
                    case 2: apiURL = "https://api.apis.net.pe/v2/reniec/dni?numero=" + NumeroDocumento; break;
                }

                var result = Nissi.nFact.Sistema.SendJsonBusquedaRUC(apiURL, "", "apis-token-5874.NtMY-tguJXtM75YMyVyx5k5r3VGD-RST", 1);
                objEmpresa = Newtonsoft.Json.JsonConvert.DeserializeObject<Entidades.EmpresaBusqueda>(result);
            }
            catch (Exception ex)
            {
                objEmpresa.Exito = -1;
            }
            return objEmpresa;
        }

        public static Nissi.nFact.Entidades.Respuesta GenerarGuiaRemision(Nissi.nFact.Entidades.GuiaRemision pGuia, int VersionTLS)
        {
            pGuia.operacion = Nissi.nFact.Sistema.Operacion.generar_guia;


            string json = JsonConvert.SerializeObject(pGuia, Formatting.Indented);
            byte[] bytes = Encoding.Default.GetBytes(json);
            string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

            /// #### ENVIAR EL ARCHIVO A NUBEFACT ####
            string json_de_respuesta = Nissi.nFact.Sistema.SendJson(ruta, json_en_utf_8, token, VersionTLS);
            dynamic r = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);
            string r2 = JsonConvert.SerializeObject(r, Formatting.Indented);
            dynamic json_r_in = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(r2);

            ///#### LEER RESPUESTA DE NUBEFACT ####
            dynamic leer_respuesta = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);
            return leer_respuesta;

        }

        public static Nissi.nFact.Entidades.Respuesta ConsultarGuiaRemision(Nissi.nFact.Entidades.consultar_guia pGuia, int VersionTLS)
        {
            pGuia.operacion = Nissi.nFact.Sistema.Operacion.consultar_guia;
            string json = JsonConvert.SerializeObject(pGuia, Formatting.Indented);
            byte[] bytes = Encoding.Default.GetBytes(json);
            string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

            /// #### ENVIAR EL ARCHIVO A NUBEFACT ####
            string json_de_respuesta = Nissi.nFact.Sistema.SendJson(ruta, json_en_utf_8, token, VersionTLS);
            dynamic r = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);
            string r2 = JsonConvert.SerializeObject(r, Formatting.Indented);
            dynamic json_r_in = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(r2);

            ///#### LEER RESPUESTA DE NUBEFACT ####
            dynamic leer_respuesta = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);
            return leer_respuesta;

        }


        public static Nissi.nFact.Entidades.Respuesta GenerarDocumento(Nissi.nFact.Entidades.Invoice pInvoice, int VersionTLS)
        {
            pInvoice.operacion = Nissi.nFact.Sistema.Operacion.generar_comprobante;

            string json = JsonConvert.SerializeObject(pInvoice, Formatting.Indented);
            byte[] bytes = Encoding.Default.GetBytes(json);
            string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

            /// #### ENVIAR EL ARCHIVO A NUBEFACT ####
            string json_de_respuesta = Nissi.nFact.Sistema.SendJson(ruta, json_en_utf_8, token, VersionTLS);
            dynamic r = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);
            string r2 = JsonConvert.SerializeObject(r, Formatting.Indented);
            dynamic json_r_in = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(r2);

            ///#### LEER RESPUESTA DE NUBEFACT ####
            dynamic leer_respuesta = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);


            return leer_respuesta;
        }

        public static Nissi.nFact.Entidades.Respuesta ConsultarDocumento(Nissi.nFact.Entidades.Invoice pInvoice, int VersionTLS)
        {
            pInvoice.operacion = Nissi.nFact.Sistema.Operacion.consultar_comprobante;

            string json = JsonConvert.SerializeObject(pInvoice, Formatting.Indented);
            byte[] bytes = Encoding.Default.GetBytes(json);
            string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

            /// #### ENVIAR EL ARCHIVO A NUBEFACT ####
            string json_de_respuesta = Nissi.nFact.Sistema.SendJson(ruta, json_en_utf_8, token, VersionTLS);
            dynamic r = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);
            string r2 = JsonConvert.SerializeObject(r, Formatting.Indented);
            dynamic json_r_in = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(r2);

            ///#### LEER RESPUESTA DE NUBEFACT ####
            dynamic leer_respuesta = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);

            return leer_respuesta;
        }

        public static Nissi.nFact.Entidades.Respuesta AnularDocumento(Nissi.nFact.Entidades.Invoice pInvoice, int VersionTLS)
        {
            pInvoice.operacion = Nissi.nFact.Sistema.Operacion.generar_anulacion;

            try
            {
                string json = JsonConvert.SerializeObject(pInvoice, Formatting.Indented);
                byte[] bytes = Encoding.Default.GetBytes(json);
                string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

                /// #### ENVIAR EL ARCHIVO A NUBEFACT ####
                string json_de_respuesta = Nissi.nFact.Sistema.SendJson(ruta, json_en_utf_8, token, VersionTLS);
                dynamic r = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);
                string r2 = JsonConvert.SerializeObject(r, Formatting.Indented);
                dynamic json_r_in = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(r2);

                ///#### LEER RESPUESTA DE NUBEFACT ####

                dynamic leer_respuesta = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);



                return leer_respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public static Nissi.nFact.Entidades.Respuesta ConsultarAnulacion(Nissi.nFact.Entidades.Invoice pInvoice, int VersionTLS)
        {
            pInvoice.operacion = Nissi.nFact.Sistema.Operacion.consultar_anulacion;

            string json = JsonConvert.SerializeObject(pInvoice, Formatting.Indented);
            byte[] bytes = Encoding.Default.GetBytes(json);
            string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

            /// #### ENVIAR EL ARCHIVO A NUBEFACT ####
            string json_de_respuesta = Nissi.nFact.Sistema.SendJson(ruta, json_en_utf_8, token, VersionTLS);
            dynamic r = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);
            string r2 = JsonConvert.SerializeObject(r, Formatting.Indented);
            dynamic json_r_in = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(r2);

            ///#### LEER RESPUESTA DE NUBEFACT ####
            dynamic leer_respuesta = JsonConvert.DeserializeObject<Nissi.nFact.Entidades.Respuesta>(json_de_respuesta);

            return leer_respuesta;
        }
    }


}