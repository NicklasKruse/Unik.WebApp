using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Item.QueryResultDto;
using Unik.Application.Repositories;

namespace Unik.Application.Queries.Item.Implementation
{
    public class GetAllItemQuery : IGetAllItemQuery
    {
        private readonly IItemRepository _itemRepository;
        public GetAllItemQuery(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        IEnumerable<ItemQueryResultDto> IGetAllItemQuery.GetAllItem()
        {
           return _itemRepository.GetAllItems();
        }
    }
}
