using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhDSystem.Core.Clients.Interfaces
{
    public interface IEmailClient
    {
        Task SendEmailMessage(MimeMessage message);
    }
}
