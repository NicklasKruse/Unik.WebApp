using Unik.Application.Queries.MemberWithAddress.DTO;
using Unik.Application.Repositories;

namespace Unik.Application.Queries.MemberWithAddress.Implementation
{
    public class GetAllMemberWithAddressQuery : IGetAllMemberWithAddressQuery
    {
        private readonly IMemberWithAddressRepository _memberWithAddressRepository;

        public GetAllMemberWithAddressQuery(IMemberWithAddressRepository memberWithAddressRepository)
        {
            _memberWithAddressRepository = memberWithAddressRepository;
        }

        async Task<IEnumerable<MemberWithAddressQueryResultDto>> IGetAllMemberWithAddressQuery.GetAllMemberWithAddress()
        {
           return await _memberWithAddressRepository.GetAllMemberWithAddress();
        }
    }
}
