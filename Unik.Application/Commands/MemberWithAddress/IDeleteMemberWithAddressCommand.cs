using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application.Commands.MemberWithAddress
{
    public interface IDeleteMemberWithAddressCommand
    {
       void Delete(int id);
    }
}
