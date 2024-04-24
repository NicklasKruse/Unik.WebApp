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
        Task CreateMember(MemberCreateRequestDto memberRequest);
        
        Task DeleteMember(int id);
        
    }
}
