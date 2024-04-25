using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Repositories;

namespace Unik.Application.Commands.Invitation.Implementation
{
    public class DeleteInvitationCommand : IDeleteInvitationCommand
    {
        private readonly IInvitationRepository _invitationRepository;

        public DeleteInvitationCommand(IInvitationRepository invitationRepository)
        {
            _invitationRepository = invitationRepository;
        }

        void IDeleteInvitationCommand.DeleteInvitation(int id)
        {
            var model = _invitationRepository.Load(id);
            _invitationRepository.Delete(model);
        }
    }
}
