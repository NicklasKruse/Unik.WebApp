using WebAppFront.Services.Models.Addresses;

namespace WebAppFront.Services.Interfaces
{
    public interface IAddressService
    {
        Task CreateMemberWithAddress(ForeningsMedlemCreateRequestDto foreningsMedlem);
    }
}
