using Unik.Application.Queries.Member.DTO;
using Unik.Application.Repositories;

namespace Unik.Application.Queries.Member.Implementation
{
    public class GetAllMemberQuery : IGetAllMemberQuery
    {
        private readonly IMemberRepository _memberRepository;
        public GetAllMemberQuery(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        IEnumerable<MemberQueryResultDto> IGetAllMemberQuery.GetAllMember()
        {
            return _memberRepository.GetAll();
        }
    }
}
