using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Member.DTO;

namespace Unik.Application.Queries.Member
{
    public interface IGetAllMemberQuery
    {
        IEnumerable<MemberQueryResultDto> GetAllMember();
    }
}
