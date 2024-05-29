using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.ServiceContracts.EmailService;

namespace Unik.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        Task IEmailSender.SendEmailAsync(string emailRecipient, string subject, string message, string sender)
        {
            SmtpClient client = new SmtpClient
            {
                Port = 1025,
                Host = "fake-smtp-server",
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
            };

            return client.SendMailAsync(sender, emailRecipient, subject, message);
        }
    }
}
