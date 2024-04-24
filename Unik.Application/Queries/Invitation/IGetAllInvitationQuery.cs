using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Invitation.DTO;

namespace Unik.Application.Queries.Invitation
{
    public interface IGetAllInvitationQuery
    {
        IEnumerable<InvitationQueryResultDto> GetAllInvitation();
    }
}
