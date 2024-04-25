using Unik.Domain.ValueObjects;

namespace Unik.Application.Commands.Booking.DTO
{
    public class BookingCreateRequestDto
    {
        public List<Item> Items { get; set; }
        //public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
