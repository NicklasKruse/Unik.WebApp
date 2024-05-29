using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        IEnumerable<MemberWithAddressQueryResultDto> IGetAllMemberWithAddressQuery.GetAllMemberWithAddress()
        {
           return _memberWithAddressRepository.GetAllMemberWithAddress();
        }
    }
}
