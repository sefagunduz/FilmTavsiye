using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class MailManager
    {

        private MailMessage CreateMessage(string ToMail)
        {
            MailMessage message = new MailMessage();
            message.Subject = "I recommend you a movie.";
            message.Body = string.Empty;
            message.To.Add(ToMail);
            message.IsBodyHtml = true;

            return message;
        }

        private bool MailSend(int Port, string HostMailServer, string SenderMail, string SenderPassword, MailMessage Message)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = Port;
                client.Host = HostMailServer;
                client.EnableSsl = false;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(SenderMail, SenderPassword);
                client.Send(Message);
                return true;
            }
            catch (Exception)
            {
                return true;
                throw;
            }
        }
    }
}
