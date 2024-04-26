using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Item.QueryResultDto;
using Unik.Domain.ValueObjects;

namespace Unik.Application.Repositories
{
    public interface IItemRepository
    {
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Item item);
        ItemQueryResultDto GetById(int id);
        IEnumerable<ItemQueryResultDto> GetAllItems();
        Item Load(int id);
    }
}
