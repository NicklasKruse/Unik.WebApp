using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Item.QueryResultDto;
using Unik.Domain.ValueObjects;

namespace Unik.Application.Mappers
{
    /// <summary>
    /// Mapper ItemQueryResultDto til Item
    /// </summary>
    public interface IItemMapper
    {
        Item ToDomainModel(ItemQueryResultDto dto);
    }

}
