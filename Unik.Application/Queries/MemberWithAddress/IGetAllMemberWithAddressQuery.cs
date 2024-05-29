using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.MemberWithAddress.DTO;

namespace Unik.Application.Queries.MemberWithAddress
{
    public interface IGetAllMemberWithAddressQuery
    {
        IEnumerable<MemberWithAddressQueryResultDto> GetAllMemberWithAddress();
    }
}
