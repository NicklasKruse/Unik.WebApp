using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Booking.DTO;
using Unik.Application.Repository;

namespace Unik.Application.Queries.Booking.Implementation
{
    public class GetBookingQuery : IGetBookingQuery
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingQuery(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        BookingQueryResultDto IGetBookingQuery.GetBooking(int id)
        {
            return _bookingRepository.GetById(id);
        }
    }
}
