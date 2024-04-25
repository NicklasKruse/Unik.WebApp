using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application.Commands.Invitation
{
    public interface IDeleteInvitationCommand
    {
        void DeleteInvitation(int id);

    }
}
