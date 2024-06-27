using System.Net.Mail;

namespace SIGA.Comun
{
    public class EnvioCorreo
    {
        System.Net.Mail.MailMessage _Message = new System.Net.Mail.MailMessage();
        System.Net.Mail.SmtpClient _SMTP = new System.Net.Mail.SmtpClient();

        public void sbEnviar(string strPara, string strAsunto, string strMensaje, string attachmentFilename1, string attachmentFilename2)
        {



            _SMTP.Credentials = new System.Net.NetworkCredential("siga@zurece.com", "siga123");
            //_SMTP.Host = "smtp.gmail.com";
            _SMTP.Host = "zurece.com";

            //_SMTP.Port = 587;
            //_SMTP.EnableSsl = true;

            // CONFIGURACION DEL MENSAJE
            _Message.To.Add(strPara);
            //Cuenta de Correo al que se le quiere enviar el e-mail
            _Message.From = new System.Net.Mail.MailAddress("siga@zurece.com", "Sistema", System.Text.Encoding.UTF8);
            //Quien lo envía
            _Message.Subject = strAsunto;
            //Sujeto del e-mail
            _Message.SubjectEncoding = System.Text.Encoding.UTF8;
            //Codificacion
            _Message.Body = strMensaje;
            //contenido del mail
            _Message.BodyEncoding = System.Text.Encoding.UTF8;
            _Message.Priority = System.Net.Mail.MailPriority.Normal;
            _Message.IsBodyHtml = true;


            if (attachmentFilename1 != null)
                _Message.Attachments.Add(new Attachment(attachmentFilename1));

            if (attachmentFilename2 != null)
                _Message.Attachments.Add(new Attachment(attachmentFilename2));

            //ENVIO
            try
            {
                _SMTP.Send(_Message);

            }
            catch (System.Net.Mail.SmtpException ex)
            {

            }
        }
        //CONFIGURACIÓN DEL STMP


    }
}
