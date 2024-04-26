using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Item.QueryResultDto;
using Unik.Application.Repositories;

namespace Unik.Application.Queries.Item.Implementation
{
    public class GetItemQuery : IGetItemQuery
    {
        private readonly IItemRepository _itemRepository;

        public GetItemQuery(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        ItemQueryResultDto IGetItemQuery.GetItem(int id)
        {
            return _itemRepository.GetById(id);
        }
    }
}
