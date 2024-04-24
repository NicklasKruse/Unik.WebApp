using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Invitation.DTO;
using Unik.Application.Repositories;

namespace Unik.Application.Queries.Invitation.Implementation
{
    public class GetInvitationQuery : IGetInvitationQuery
    {
        private readonly IInvitationRepository _invitationRepository;

        public GetInvitationQuery(IInvitationRepository invitationRepository)
        {
            _invitationRepository = invitationRepository;
        }

        InvitationQueryResultDto IGetInvitationQuery.GetInvitation(int id)
        {
            return _invitationRepository.GetById(id);
        }
    }
}
