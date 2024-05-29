using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application.ServiceContracts.EmailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string emailRecipient, string subject, string message, string sender);
    }
}
