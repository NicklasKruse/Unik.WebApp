using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Booking.DTO;
using Unik.Application.Repository;

namespace Unik.Application.Queries.Booking.Implementation
{
    public class GetAllBookingQuery : IGetAllBookingQuery
    {
        private readonly IBookingRepository _bookingRepository;

        public GetAllBookingQuery(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        IEnumerable<BookingQueryResultDto> IGetAllBookingQuery.GetAllBooking()
        {
            return _bookingRepository.GetAllBooking();
        }
    }
}
