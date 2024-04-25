using FrontConnectLibrary.Models.Invitation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontConnectLibrary.Interfaces
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
