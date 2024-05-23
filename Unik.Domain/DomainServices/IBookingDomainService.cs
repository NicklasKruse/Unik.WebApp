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
        bool BookingExistsOnDate(DateTime date, Item item);
    }
}
