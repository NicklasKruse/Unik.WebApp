using FrontConnectLibrary.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontConnectLibrary.Interfaces
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
