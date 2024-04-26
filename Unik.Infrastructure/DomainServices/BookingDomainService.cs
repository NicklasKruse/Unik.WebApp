using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Entities;
using Unik.Domain.Ínterfaces;
using Unik.Domain.ValueObjects;

namespace Unik.Infrastructure.DomainServices
{
    // In Unik.Infrastructure
    public class BookingDomainService : IBookingDomainService
    {
        public void UpdateBookingWithItems(Booking booking, Item item)
        {
            booking.Edit(item, booking.StartDate, booking.EndDate);
        }
    }

}
