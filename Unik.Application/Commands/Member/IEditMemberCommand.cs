using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.Member.DTO;

namespace Unik.Application.Commands.Member
{
    public interface IEditMemberCommand
    {
        void Edit(MemberEditRequestDto editMemberDto);
    }
}
