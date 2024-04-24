using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application.Commands.Member
{
    public interface IDeleteMemberCommand
    {
        /// <summary>
        /// Vælger medlem der skal slettes via Id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);//
    }
}
