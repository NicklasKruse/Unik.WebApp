using Microsoft.EntityFrameworkCore;
using SqlServerContext;
using Unik.Application.Queries.Booking.DTO;
using Unik.Application.Repository;
using Unik.Domain.Entities;

namespace Unik.Infrastructure.Repositories
{
    /// <summary>
    /// Repository til Booking
    /// </summary>
    public class BookingRepository : IBookingRepository
    {
        private readonly BackendDbContext _context;
        public BookingRepository(BackendDbContext backendDbContext)
        {
            _context = backendDbContext;
        }

        public void UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        void IBookingRepository.AddBooking(Booking booking)
        {
            _context.Add(booking);
            _context.SaveChanges();
        }

        void IBookingRepository.DeleteBooking(Booking booking)
        {
            _context.Remove(booking);
            _context.SaveChanges();
        }

        IEnumerable<BookingQueryResultDto> IBookingRepository.GetAllBooking()
        {
            foreach (var booking in _context.Bookings.Include(b => b.Item).AsNoTracking())
            {
                yield return new BookingQueryResultDto
                {
                    Id = booking.Id,
                    ItemId = booking.Item.Id,
                    UserId = booking.UserId,
                    StartDate = booking.StartDate,
                    EndDate = booking.EndDate,
                    CreatedBy = booking.CreatedBy
                };
            }
        }
        /// <summary>
        /// Get booking by id og vis en DTO kopi af booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        BookingQueryResultDto IBookingRepository.GetById(int id)
        {
            var model = _context.Bookings.Include(b => b.Item).AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                throw new Exception("Booking not found");
            }
            return new BookingQueryResultDto
            {
                Id = model.Id,
                ItemId = model.Item.Id,
                UserId = model.UserId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                CreatedBy = model.CreatedBy
            };
        }
        /// <summary>
        /// Load specific booking fra databasen
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Booking IBookingRepository.Load(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception("Booking not found");
            return booking;
        }

        void IBookingRepository.UpdateBooking(Booking booking)
        {
            _context.Update(booking);
            _context.SaveChanges();
        }
    }
}
