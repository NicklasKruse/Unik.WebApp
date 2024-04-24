using Unik.Domain.ValueObjects;

namespace Unik.Application.Commands.Booking.DTO
{
    public class BookingCreateDto
    {
        public List<Item> BookingItems { get; set; }
        //public string UserId { get; set; } Når vi laver login
        //public BookingDates BookingDates { get; set; }
    }
}
