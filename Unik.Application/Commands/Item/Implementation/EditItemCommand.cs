using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.Item.DTO;
using Unik.Application.Repositories;

namespace Unik.Application.Commands.Item.Implementation
{
    public class EditItemCommand : IEditItemCommand
    {
        private readonly IItemRepository _itemRepository;
        public EditItemCommand(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        void IEditItemCommand.Edit(ItemEditRequestDto editItemDto)
        {
            var model = _itemRepository.Load(editItemDto.Id);
            if (model == null)
            {
                throw new Exception("Item not found");
            }
            model.Edit(editItemDto.Description, editItemDto.Damage);

            _itemRepository.UpdateItem(model);
        }
    }
}
