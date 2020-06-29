using MimeKit;
using PhDSystem.Core.Clients.Interfaces;
using PhDSystem.Core.Models;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Entities;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailClient _emailClient;
        private readonly NotificationMetadata _notificationMetadata;

        public EmailService(IEmailClient emailClient, NotificationMetadata notificationMetadata)
        {
            _emailClient = emailClient;
            _notificationMetadata = notificationMetadata;
        }

        public async Task NotifyUserForInitialCredentials(User user)
        {
            EmailMessage message = new EmailMessage
            {
                Sender = new MailboxAddress("Self", "antovska14@gmail.com"),
                Reciever = new MailboxAddress("Self", "antovska14@gmail.com"),
                Subject = "Welcome",
                Content = "Hello World!"
            };

            var mimeMessage = CreateEmailMessage(message);

            await _emailClient.SendEmailMessage(mimeMessage);
        }

        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(message.Sender);
            mimeMessage.To.Add(message.Reciever);
            mimeMessage.Subject = message.Subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            { Text = message.Content };
            return mimeMessage;
        }
    }
}
