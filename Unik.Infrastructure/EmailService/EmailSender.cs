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
                Port = 587,
                Host = "smtp.example.com",
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("username@example.com", "password")
            };

            return client.SendMailAsync(sender, emailRecipient, subject, message);
        }
    }
}
