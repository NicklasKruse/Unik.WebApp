using Unik.Application.Queries.Invitation.DTO;
using Unik.Domain.Entities;

namespace Unik.Application.Repositories
{
    public interface IInvitationRepository
    {
        void Create(Invitation invitation);
        void Update(Invitation invitation);
        void Delete(Invitation invitation);
        InvitationQueryResultDto GetById(int id);
        IEnumerable<InvitationQueryResultDto> GetAll();
        Invitation Load(int id);
    }
}
