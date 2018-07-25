using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BurganWallet.Helpers.Email
{
    public class EmailCustomService
    {
        private readonly EmailConfiguration _mailConfig;

        /// <summary>
        /// Creates default email service
        /// </summary>
        public EmailCustomService()
        {
            _mailConfig = new EmailConfiguration();
            var emailUserName = ConfigurationManager.AppSettings["EmailUsername"];
            var emailPassword = ConfigurationManager.AppSettings["EmailPassword"];
            var emailHost = ConfigurationManager.AppSettings["EmailHost"];
            var emailPort = Int32.Parse(ConfigurationManager.AppSettings["EmailPort"]);
            var emailSsl = Boolean.Parse(ConfigurationManager.AppSettings["EmailSsl"]);
            _mailConfig.Username = emailUserName;
            _mailConfig.Password = emailPassword;
            _mailConfig.Host = emailHost;
            _mailConfig.Port = emailPort;
            _mailConfig.Ssl = emailSsl;
        }
        public async Task SendEmailMessage(IdentityMessage message)
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = _mailConfig.Host,
                    Port = _mailConfig.Port,
                    EnableSsl = _mailConfig.Ssl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_mailConfig.Username, _mailConfig.Password)
                };

                var smtpMessage = new MailMessage();
                smtpMessage.From = new MailAddress(_mailConfig.Username);
                smtpMessage.To.Add(new MailAddress(message.Destination));
                smtpMessage.Subject = message.Subject;
                smtpMessage.Body = message.Body;
                await smtp.SendMailAsync(smtpMessage);
            }
            catch (Exception ex)
            {
                //todo: add logging integration
                //throw;
            }
        }
    }
}