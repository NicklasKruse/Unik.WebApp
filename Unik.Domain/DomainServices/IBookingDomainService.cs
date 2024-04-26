using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Entities;
using Unik.Domain.ValueObjects;

namespace Unik.Domain.Ínterfaces
{
    public interface IBookingDomainService
    {
        void UpdateBookingWithItems(Booking booking, List<Item> items);
    }
}
