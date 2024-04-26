using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Mappers;
using Unik.Application.Queries.Item.QueryResultDto;
using Unik.Domain.ValueObjects;

namespace Unik.Infrastructure.Mappers
{
    /// <summary>
    /// Mapper ItemQueryResultDto til Item
    /// </summary>
    public class ItemMapper : IItemMapper
    {
        public Item ToDomainModel(ItemQueryResultDto dto)
        {
            return new Item(dto.Description)
            {
                Id = dto.Id,
                Damage = dto.Damage
            };
        }
    }

}
