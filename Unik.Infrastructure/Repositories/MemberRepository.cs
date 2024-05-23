using Microsoft.EntityFrameworkCore;
using SqlServerContext;
using Unik.Application.Queries.Member.DTO;
using Unik.Application.Repositories;
using Unik.Domain.Entities;

namespace Unik.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly BackendDbContext _db;
        public MemberRepository(BackendDbContext db)
        {
            _db = db;
        }

        public Member Load(int id)
        {
            var member = _db.Memberships.FirstOrDefault(x => x.Id == id);
            if(member == null)
            {
                throw new Exception("Member not found");
            }
            return member;
        }

        void IMemberRepository.Create(Member member)
        {
            _db.Add(member);
            _db.SaveChanges();
        }

        void IMemberRepository.Delete(Member member)
        {
            _db.Remove(member);
            _db.SaveChanges();
        }

        IEnumerable<MemberQueryResultDto> IMemberRepository.GetAll()
        {

            foreach (var member in _db.Memberships.AsNoTracking())
            {
                
                yield return new MemberQueryResultDto
                {
                    Id = member.Id,
                    Name = member.Name,
                    Address = member.Address,
                   // UserId = member.UserId,
                    RowVersion = member.RowVersion
                };
            }
        }

        MemberQueryResultDto IMemberRepository.GetById(int id)
        {
            var model = _db.Memberships.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                throw new Exception("Member not found");
            }
            return new MemberQueryResultDto
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                //UserId = model.UserId,
                RowVersion = model.RowVersion
            };
        }

        void IMemberRepository.Update(Member member)
        {
            _db.Update(member);
            _db.SaveChanges();
        }
    }
}
