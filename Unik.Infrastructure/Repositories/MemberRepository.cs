using SqlServerContext;
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

        void IMemberRepository.Add(Member member)
        {
            _db.Add(member);
            _db.SaveChanges();
        }

        void IMemberRepository.Delete(Member member)
        {
            _db.Remove(member);
            _db.SaveChanges();
        }

        IEnumerable<Member> IMemberRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Member IMemberRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void IMemberRepository.Update(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
