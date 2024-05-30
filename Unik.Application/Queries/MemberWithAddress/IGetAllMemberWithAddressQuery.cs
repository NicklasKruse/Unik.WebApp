using Unik.Application.Queries.MemberWithAddress.DTO;

namespace Unik.Application.Queries.MemberWithAddress
{
    public interface IGetAllMemberWithAddressQuery
    {
        Task<IEnumerable<MemberWithAddressQueryResultDto>> GetAllMemberWithAddressAsync();
        IEnumerable<MemberWithAddressQueryResultDto> GetAllMemberWithAddress();
    }
}
