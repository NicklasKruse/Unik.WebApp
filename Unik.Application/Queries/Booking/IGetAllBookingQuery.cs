using Unik.Application.Queries.Booking.DTO;

namespace Unik.Application.Queries.Booking
{
    public interface IGetAllBookingQuery
    {
        IEnumerable<BookingQueryResultDto> GetAllBooking();
    }
}
