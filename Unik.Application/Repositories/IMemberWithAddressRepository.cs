using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.MemberWithAddress.DTO;
using Unik.Domain.Entities;
using Unik.Domain.ValueObjects;

namespace Unik.Application.Repositories
{
    public interface IMemberWithAddressRepository
    {
        Task CreateMemberWithAddress(MemberWithAddress foreningsMedlem);
        GetAddressQueryResultDto GetAddressByStreetCityZipCodeCountry(string street, string city, string zipCode, string country);
        MemberWithAddress Load(string Street, string City, string ZipCode, string Country);
        MemberWithAddress Load(int id);
        void DeleteMemberWithAddress(MemberWithAddress MWA);
        void UpdateMemberWithAddress(MemberWithAddress MWA);
        Task<IEnumerable<MemberWithAddressQueryResultDto>> GetAllMemberWithAddressAsync();
        IEnumerable<MemberWithAddressQueryResultDto> GetAllMemberWithAddress();
    }
}
