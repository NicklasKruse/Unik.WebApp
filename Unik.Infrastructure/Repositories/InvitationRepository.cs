using Microsoft.EntityFrameworkCore;
using SqlServerContext;
using Unik.Application.Queries.Invitation.DTO;
using Unik.Application.Repositories;
using Unik.Domain.Entities;

namespace Unik.Infrastructure.Repositories
{
    /// <summary>
    /// Invitation repository
    /// </summary>
    public class InvitationRepository : IInvitationRepository
    {
        private readonly BackendDbContext _context;
        public InvitationRepository(BackendDbContext context)
        {
            _context = context;
        }

        void IInvitationRepository.Create(Invitation invitation)
        {
            _context.Add(invitation);
            _context.SaveChanges();
        }

        void IInvitationRepository.Delete(Invitation invitation)
        {
           _context.Remove(invitation);
            _context.SaveChanges();
        }

        IEnumerable<InvitationQueryResultDto> IInvitationRepository.GetAll()
        {
            foreach(var invitation in _context.Invitations.AsNoTracking())
            {
                yield return new InvitationQueryResultDto
                {
                    Id = invitation.Id,
                    Description = invitation.Description,
                    Date = invitation.Date,
                    CreatedBy = invitation.CreatedBy,
                    RowVersion = invitation.RowVersion
                };
            }
        }
        /// <summary>
        /// Get invitation by id og vis en DTO kopi af invitation. Brug .Load hvis du skal redigere invitation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        InvitationQueryResultDto IInvitationRepository.GetById(int id)
        {
            var model = _context.Invitations.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(model == null)
            {
                throw new Exception("Invitation not found");
            }
            return new InvitationQueryResultDto
            {
                Id = model.Id,
                Description = model.Description,
                Date = model.Date,
                RowVersion = model.RowVersion
            };
        }
        Invitation IInvitationRepository.Load(int id)
        {
            var invitation = _context.Invitations.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception("Invitation not found");
            return invitation;
        }

        void IInvitationRepository.Update(Invitation invitation)
        {
            _context.Update(invitation);
            _context.SaveChanges();
        }
    }
}
