using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.Booking.DTO;

namespace Unik.Application.Queries.Booking
{
    public interface IGetBookingQuery
    {
        BookingQueryResultDto GetBooking(int id);
    }
}
