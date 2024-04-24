using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Domain.DomainServices
{
    public interface IInvitationService
    {
        void AcceptInvitation(string userId, string userName, string userEmail, int attendanceAmount);
    }
}
