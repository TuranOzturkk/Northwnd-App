using System.Net;
using System.Net.Mail;

namespace Infrastructure.Utilities
{
    public static class MailHelper
    {
        public static void SendMail(string from, string to, string subject, string message,string password)
        {
            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(from, password);
            client.Host = "------------------------------------";
            client.Port = 587;
            client.EnableSsl = true;

            client.Send(mailMessage);
        }
        public static void iletisimmail(string from, string to, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            
            client.Host = "-----------------------------------------";
            client.Port = 587;
            client.EnableSsl = true;

            client.Send(mailMessage);
        }
    }
}
