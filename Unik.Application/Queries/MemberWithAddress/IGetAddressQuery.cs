using Unik.Application.Queries.MemberWithAddress.DTO;

namespace Unik.Application.Queries.MemberWithAddress
{
    public interface IGetAddressQuery
    {
        GetAddressQueryResultDto GetAddressByStreetCityZipCodeCountry(string street, string city, string zipCode, string country);
    }
}
