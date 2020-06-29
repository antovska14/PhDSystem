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

        public EmailService(IEmailClient emailClient)
        {
            _emailClient = emailClient;
        }

        public async Task NotifyUserForInitialCredentials(User user)
        {
            //TODO [DA]: Change the receiver email address with user.Email value
            EmailMessage message = new EmailMessage
            {
                Sender = new MailboxAddress("PhD System", "phdsystem14@gmail.com"),
                Reciever = new MailboxAddress("PhD System", "antovska14@gmail.com"),
                Subject = "PhD System Account Created",
                Content = $"Your account for PhD System has been created. Your initial password is {user.Password}. You are required to change you password in order to login."
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
