using Unik.Application.Queries.MemberWithAddress.DTO;
using Unik.Application.Repositories;

namespace Unik.Application.Queries.MemberWithAddress.Implementation
{
    /// <summary>
    /// Har to metoder. Synkron og asynkron
    /// </summary>
    public class GetAllMemberWithAddressQuery : IGetAllMemberWithAddressQuery
    {
        private readonly IMemberWithAddressRepository _memberWithAddressRepository;

        public GetAllMemberWithAddressQuery(IMemberWithAddressRepository memberWithAddressRepository)
        {
            _memberWithAddressRepository = memberWithAddressRepository;
        }
        /// <summary>
        /// Async - bruges i email service
        /// </summary>
        /// <returns></returns>
        async Task<IEnumerable<MemberWithAddressQueryResultDto>> IGetAllMemberWithAddressQuery.GetAllMemberWithAddressAsync()
        {
           return await _memberWithAddressRepository.GetAllMemberWithAddressAsync();
        }
        IEnumerable<MemberWithAddressQueryResultDto> IGetAllMemberWithAddressQuery.GetAllMemberWithAddress()
        {
            return _memberWithAddressRepository.GetAllMemberWithAddress();
        }
    }
}
