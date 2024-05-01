using WebAppFront.Services.Models.Member;

namespace WebAppFront.Services.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberQueryResultDto>> GetAllMember();
        Task<MemberQueryResultDto> GetMemberById(int id);
        Task EditMember(MemberEditRequestDto memberRequest);
        Task CreateMember(MemberCreateRequestDto memberRequest);

        Task DeleteMember(int id);

    }
}
