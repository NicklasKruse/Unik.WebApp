using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application.Commands.Item
{
    public interface IDeleteItemCommand
    {
        void Delete(int id);
    }
}
