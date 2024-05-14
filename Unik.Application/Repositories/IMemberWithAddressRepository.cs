using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Entities;

namespace Unik.Application.Repositories
{
    public interface IMemberWithAddressRepository
    {
        void CreateMemberWithAddress(MemberWithAddress foreningsMedlem);
    }
}
