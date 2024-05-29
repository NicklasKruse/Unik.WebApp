using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.MemberWithAddress.RequestModels;

namespace Unik.Application.Commands.MemberWithAddress
{
    public interface IEditMemberWithAddress
    {
        void Edit(MemberWithAddressEditRequestDto dto);
    }
}
