using Unik.Application.Commands.MemberWithAddress.RequestModels;

namespace Unik.Application.Commands.MemberWithAddress
{
    public interface ICreateMemberWithAddressCommand
    {
        Task CreateMemberWithAddress(MemberWithAddressRequestDto createMemberWithAddressDto);
    }
}
