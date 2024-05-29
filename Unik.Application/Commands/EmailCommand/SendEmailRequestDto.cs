using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application.Commands.EmailCommand
{
    public class SendEmailRequestDto 
    {
        public string EmailRecipient { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
    }
}
