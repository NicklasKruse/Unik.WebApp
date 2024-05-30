using WebAppFront.Services.Models.Addresses;

namespace WebAppFront.Services.Interfaces
{
    /// <summary>
    /// Nanvgivning misvisende. Det er til MemberWithAddress, ikke bare addresser
    /// </summary>
    public interface IAddressService
    {
        Task CreateMemberWithAddress(ForeningsMedlemCreateRequestDto foreningsMedlem);
        Task<IEnumerable<ForeningsMedlemQueryResultDto>> GetAllMemberWithAddress();
        Task DeleteMemberWithAddress(int id);
    }
}
