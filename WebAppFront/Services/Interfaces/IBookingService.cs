using WebAppFront.Services.Models.Booking;

namespace WebAppFront.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingQueryResultDto>> GetAllBooking();
        Task<BookingQueryResultDto> GetBookingById(int id);
        Task EditBooking(BookingEditRequestDto bookingRequest);
        Task CreateBooking(BookingCreateRequestDto bookingRequest);

        Task DeleteBooking(int id);
    }
}
