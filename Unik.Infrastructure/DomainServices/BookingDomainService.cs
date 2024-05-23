using Microsoft.EntityFrameworkCore;
using SqlServerContext;
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
   
    public class BookingDomainService : IBookingDomainService
    {
        private readonly BackendDbContext _context;

        public BookingDomainService(BackendDbContext context)
        {
            _context = context;
        }

        public void UpdateBookingWithItems(Booking booking, Item item)
        {
            booking.Edit(item, booking.StartDate, booking.EndDate);
        }
        bool IBookingDomainService.BookingExistsOnDate(DateTime date, Item item)
        {
            return _context.Bookings.AsNoTracking().ToList().Any(a => a.StartDate <= date && a.EndDate >= date && a.Item.Id == item.Id);
        }
    }

}
