using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using PhDSystem.Core.Clients.Interfaces;
using PhDSystem.Core.Models;
using System;
using System.Threading.Tasks;

namespace PhDSystem.Core.Clients
{
    public class EmailClient : IEmailClient
    {
        private readonly SmtpConfig _smtpConfig;

        public EmailClient(SmtpConfig smtpConfig)
        {
            _smtpConfig = smtpConfig;
        }

        public async Task SendEmailMessage(MimeMessage message)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync(_smtpConfig.SmtpServer, _smtpConfig.Port);
                await smtpClient.AuthenticateAsync(_smtpConfig.UserName, _smtpConfig.Password);
                await smtpClient.SendAsync(message);
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}
