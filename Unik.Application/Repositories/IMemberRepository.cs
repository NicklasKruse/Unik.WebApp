using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Member.DTO;
using Unik.Domain.Entities;

namespace Unik.Application.Repositories
{
    public interface IMemberRepository
    {
        void Create(Member member);
        void Update(Member member);
        void Delete(Member member);
        MemberQueryResultDto GetById(int id); // qdto 
        IEnumerable<MemberQueryResultDto> GetAll();//qdto
        Member Load(int id);
    }
}
