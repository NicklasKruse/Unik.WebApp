using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Domain.ValueObjects
{
    public class InvitationAcceptance
    {
        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public string UserEmail { get; private set; }
        public int AttendanceAmount { get; private set; }

        public InvitationAcceptance(string userId, string userName, string userEmail, int attendanceAmount)
        {
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
            AttendanceAmount = attendanceAmount;
        }
    }

}
