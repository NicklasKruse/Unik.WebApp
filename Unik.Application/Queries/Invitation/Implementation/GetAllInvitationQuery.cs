using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Invitation.DTO;
using Unik.Application.Repositories;

namespace Unik.Application.Queries.Invitation.Implementation
{
    public class GetAllInvitationQuery: IGetAllInvitationQuery
    {
        private readonly IInvitationRepository _invitationRepository;

        public GetAllInvitationQuery(IInvitationRepository invitationRepository)
        {
            _invitationRepository = invitationRepository;
        }

        IEnumerable<InvitationQueryResultDto> IGetAllInvitationQuery.GetAllInvitation()
        {
            return _invitationRepository.GetAll();
        }
    }
}
