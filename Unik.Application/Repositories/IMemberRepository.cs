using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Entities;

namespace Unik.Application.Repositories
{
    public interface IMemberRepository
    {
        void Add(Member member);
        void Update(Member member);
        void Delete(Member member);
        Member GetById(int id);
        IEnumerable<Member> GetAll();
    }
}
