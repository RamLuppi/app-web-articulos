using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailNegocio
    {
        private MailMessage email;
        private SmtpClient server;
        public void emailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("mailConcactoAdminServer@gmail.com", "12345678");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }
        public void enviarCorreo(string cuerpo)
        {
            email = new MailMessage();
            email.From= new MailAddress("appwebnoresponder@noresponder.com","12345678");
            email.To.Add("mailConcactoAdminServer@gmail.com");
            string asunto = "Error no contemplado App articulos";
            email.Subject = asunto;
            email.Body = cuerpo;

            try
            {
                server.Send(email);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
