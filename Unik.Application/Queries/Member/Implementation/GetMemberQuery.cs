using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Member.DTO;
using Unik.Application.Repositories;

namespace Unik.Application.Queries.Member.Implementation
{
    public class GetMemberQuery : IGetMemberQuery
    {
        private readonly IMemberRepository _memberRepository;
        public GetMemberQuery(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        MemberQueryResultDto IGetMemberQuery.GetMember(int id)
        {
            return _memberRepository.GetById(id);
        }
    }
}
