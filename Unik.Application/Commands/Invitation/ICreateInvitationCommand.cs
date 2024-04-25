using Unik.Application.Commands.Invitation.RequestModels;

namespace Unik.Application.Commands.Invitation
{
    public interface ICreateInvitationCommand
    {
        void CreateInvitation(InvitationRequestDto invitationRequestDto);
    }
}
