using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using AIMGSM.Interfaces;

namespace AIMGSM.Services
{
    public class ContactService : IContactService
    {
        private readonly IConfiguration _configuration;

        public ContactService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string name, string email, string message)
        {
            string subject = "New Contact Request from " + name;
            string body = "Name: " + name + "<br />" +
                          "Email: " + email + "<br />" +
                          "Message: " + message;

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(_configuration.GetValue<string>("Contact:ToEmail"));
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress(email);

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = _configuration.GetValue<string>("Contact:SmtpHost");
            smtpClient.Port = _configuration.GetValue<int>("Contact:SmtpPort");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_configuration.GetValue<string>("Contact:SmtpUsername"), _configuration.GetValue<string>("Contact:SmtpPassword"));
            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
        }
    }
}
