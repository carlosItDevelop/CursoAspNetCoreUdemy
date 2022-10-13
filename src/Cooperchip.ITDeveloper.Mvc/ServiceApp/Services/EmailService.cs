using Cooperchip.ITDeveloper.Mvc.ServiceApp.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace Cooperchip.ITDeveloper.Mvc.ServiceApp.Services
{
    public static class EmailService
    {
        public static void EnviarEmail(string fromAddress, string toAddress, string subjectText, string bodyText, [FromServices] EmailCredentialsSettings options)
        {
            var newMessage = new MailMessage();
            var senderAddress = new MailAddress(fromAddress);
            var recipentAddress = new MailAddress(toAddress);

            newMessage.To.Add(recipentAddress);
            newMessage.From = senderAddress;
            newMessage.Subject = subjectText;
            newMessage.Body = bodyText;
            newMessage.BodyEncoding = System.Text.Encoding.UTF8;
            newMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(options.EmailSender, options.EmailPassword)
            };
            client.Send(newMessage);
        }
    }
}
