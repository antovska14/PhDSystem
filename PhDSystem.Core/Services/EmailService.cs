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
        private readonly SmtpConfig _smtpConfig;

        public EmailService(IEmailClient emailClient, SmtpConfig smtpConfig)
        {
            _emailClient = emailClient;
            _smtpConfig = smtpConfig;
        }

        public async Task NotifyUserForInitialCredentials(string email, string password)
        {
            EmailMessage message = new EmailMessage
            {
                Sender = new MailboxAddress(_smtpConfig.FromName, _smtpConfig.From),
                Reciever = new MailboxAddress(email, email),
                Subject = EmailConstants.AccountCreatedSubject,
                Content = string.Format(EmailConstants.AccountCreatedContent, password)
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
