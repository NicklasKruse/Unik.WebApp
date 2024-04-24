using Unik.Application.Queries.Member.DTO;

namespace Unik.Application.Queries.Member
{
    public interface IGetMemberQuery
    {
        MemberQueryResultDto GetMember(int id);
    }
}
