using MailKit.Net.Smtp;
using MimeKit;
using PhDSystem.Core.Clients.Interfaces;
using PhDSystem.Core.Models;
using System.Threading.Tasks;

namespace PhDSystem.Core.Clients
{
    public class EmailClient : IEmailClient
    {
        private readonly NotificationMetadata _notificationMetadata;

        public EmailClient(NotificationMetadata notificationMetadata)
        {
            _notificationMetadata = notificationMetadata;
        }

        public async Task SendEmailMessage(MimeMessage message)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync(_notificationMetadata.SmtpServer,
                _notificationMetadata.Port, true);
                await smtpClient.AuthenticateAsync(_notificationMetadata.UserName,
                _notificationMetadata.Password);
                await smtpClient.SendAsync(message);
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}
