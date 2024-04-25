using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application.Queries.Invitation.DTO
{
    public class InvitationAcceptanceQueryResultDto
    {
       // public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int AttendanceAmount { get; set; }
    }
}
