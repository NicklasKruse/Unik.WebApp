using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.Item.DTO;
using Unik.Application.Repositories;

namespace Unik.Application.Commands.Item.Implementation
{
    public class CreateItemCommand : ICreateItemCommand
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateItemCommand(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            this.unitOfWork = unitOfWork;
        }
        void ICreateItemCommand.CreateItem(ItemCreateRequestDto createItemDto)
        {
            try
            {
                unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);

                var item = new Domain.ValueObjects.Item(createItemDto.Description);
                _itemRepository.AddItem(item);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}
