using Unik.Application.Queries.MemberWithAddress.DTO;
using Unik.Application.Repositories;

namespace Unik.Application.Queries.MemberWithAddress.Implementation
{
    public class GetAddressQuery : IGetAddressQuery
    {
        private readonly IMemberWithAddressRepository _memberWithAddressRepository;

        public GetAddressQuery(IMemberWithAddressRepository memberWithAddressRepository)
        {
            _memberWithAddressRepository = memberWithAddressRepository;
        }

        GetAddressQueryResultDto IGetAddressQuery.GetAddressByStreetCityZipCodeCountry(string street, string city, string zipCode, string country)
        {
            return _memberWithAddressRepository.GetAddressByStreetCityZipCodeCountry(street, city, zipCode, country);

        }
    }
}
