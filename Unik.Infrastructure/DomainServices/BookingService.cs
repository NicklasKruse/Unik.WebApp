using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Ínterfaces;
using Unik.Domain.Models;

namespace Unik.Infrastructure.DomainServices
{
    //public class BookingService : IBookingDomainService
    //{
    //    //private readonly BookingContext _context;
    //    //public BookingService(BookingContext context)
    //    //{
    //    //    _context = context;
    //    //}
    //    //IEnumerable<Booking> IBookingDomainService.OtherBookings(Booking booking)
    //    //{
    //    //    return _context.Books.AsNoTracking().Where(a => a.Accommodation.Id == booking.Accommodation.Id && a.Id != booking.Id).ToList();
    //    //}

    //    bool IBookingDomainService.BookingOverlap(DateTime date)
    //    {
    //        return _db.BookingEntities.AsNoTracking().ToList().Any(b => b.Date.Date == date.Date);
    //    }
    //    public IEnumerable<Booking> OtherBookings(Booking booking)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
