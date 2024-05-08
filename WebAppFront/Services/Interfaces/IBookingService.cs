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

        Task<IEnumerable<BookingQueryResultDto>> GetAllBookingsSortedByDate();
        /// <summary>
        /// Sorter efter dato interval
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<IEnumerable<BookingQueryResultDto>> GetBookingsByDateRange(DateTime startDate, DateTime endDate);
    }
}
