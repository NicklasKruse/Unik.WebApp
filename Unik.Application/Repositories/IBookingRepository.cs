using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Booking.DTO;
using Unik.Domain.Entities;

namespace Unik.Application.Repository
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(Booking booking);
        BookingQueryResultDto GetById(int id);
        IEnumerable<BookingQueryResultDto> GetAllBooking();
        Booking Load(int id);
    }
}
