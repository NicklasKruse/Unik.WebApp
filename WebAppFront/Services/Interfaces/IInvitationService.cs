using WebAppFront.Services.Models.Invitation;

namespace WebAppFront.Services.Interfaces
{
    public interface IInvitationService
    {
        Task<IEnumerable<InvitationQueryResultDto>> GetAllInvitation();
        Task<InvitationQueryResultDto> GetInvitationById(int id);
        Task EditInvitation(InvitationEditRequestDto invitationRequest);
        Task CreateInvitation(InvitationCreateRequestDto invitationRequest);
        
        Task DeleteInvitation(int id);
    }
}
