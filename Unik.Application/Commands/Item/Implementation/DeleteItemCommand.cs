using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Repositories;

namespace Unik.Application.Commands.Item.Implementation
{
    public class DeleteItemCommand : IDeleteItemCommand
    {
        private readonly IItemRepository _itemRepository;

        public DeleteItemCommand(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        void IDeleteItemCommand.Delete(int id)
        {
            var model = _itemRepository.Load(id);
            if (model == null)
            {
                throw new Exception("Item not found");
            }
            _itemRepository.DeleteItem(model);
        }
    }
}
