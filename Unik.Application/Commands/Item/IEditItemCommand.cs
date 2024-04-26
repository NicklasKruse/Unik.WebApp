using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.Item.DTO;

namespace Unik.Application.Commands.Item
{
    public interface IEditItemCommand
    {
        void Edit(ItemEditRequestDto editItemDto);
    }
}
