using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Item.QueryResultDto;

namespace Unik.Application.Queries.Item
{
    public interface IGetItemQuery
    {
        ItemQueryResultDto GetItem(int id);
    }
}
