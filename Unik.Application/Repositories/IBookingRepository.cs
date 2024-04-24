using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Models;

namespace Unik.Application.Repository
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(Booking booking);
        Booking GetBooking(Guid id);
        IEnumerable<Booking> GetAllBookings();
        int GetNextKey();
    }
}
