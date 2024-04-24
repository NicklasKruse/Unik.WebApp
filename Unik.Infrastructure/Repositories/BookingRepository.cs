using SqlServerContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Repository;
using Unik.Domain.Models;

namespace Unik.Infrastructure.Repositories
{
    public class BookingRepository
    {
        private readonly BackendDbContext _context;
        public BookingRepository(BackendDbContext backendDbContext)
        {
            _context = backendDbContext;
        }
        public void AddBooking(Booking booking)
        {
            //_context.Add(booking.Id, booking);
        }

        public void DeleteBooking(Booking booking)
        {
            _context.Remove(booking.Id);
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return null;
        }

        public Booking GetBooking(Guid id)
        {
            return null;
        }
        public void UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

    }
}
