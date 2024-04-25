using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.Invitation.RequestModels;

namespace Unik.Application.Commands.Invitation
{
    public interface IEditInvitationCommand
    {
        void EditInvitation(InvitationEditRequestDto invitationEditRequestDto);
    }
}
