using FrontConnectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontConnectLibrary.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberQueryResultDto>> GetAllMember();
        Task<MemberQueryResultDto> GetMemberById(int id);
        Task EditMember(MemberEditRequestDto memberRequest);
        Task CreateMember(MemberCreateRequestDto memberRequest);
        
        Task DeleteMember(int id);
        
    }
}
