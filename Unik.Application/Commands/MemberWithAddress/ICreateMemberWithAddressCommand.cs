using Unik.Application.Commands.MemberWithAddress.RequestModels;

namespace Unik.Application.Commands.MemberWithAddress
{
    public interface ICreateMemberWithAddressCommand
    {
        void CreateMemberWithAddress(MemberWithAddressRequestDto createMemberWithAddressDto);
    }
}
