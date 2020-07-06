using MimeKit;
using PhDSystem.Core.Clients.Interfaces;
using PhDSystem.Core.Constants;
using PhDSystem.Core.Models;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Entities;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailClient _emailClient;

        public EmailService(IEmailClient emailClient)
        {
            _emailClient = emailClient;
        }

        public async Task NotifyUserForInitialCredentials(User user)
        {
            EmailMessage message = new EmailMessage
            {
                Sender = new MailboxAddress(EmailConstants.PhdSystem, EmailConstants.PhdSystemEmail),
                Reciever = new MailboxAddress(EmailConstants.PhdSystem, user.Email),
                Subject = EmailConstants.AccountCreatedSubject,
                Content = string.Format(EmailConstants.AccountCreatedContent, user.Password)
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
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return mimeMessage;
        }
    }
}
