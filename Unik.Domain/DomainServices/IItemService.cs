using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.ValueObjects;

namespace Unik.Domain.Ínterfaces
{
    public interface IItemService
    {
        public bool CanBookItem(Item item, DateTime startTime, DateTime endTime);
    }
}
