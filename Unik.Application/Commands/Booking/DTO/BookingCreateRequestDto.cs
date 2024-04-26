using Unik.Domain.ValueObjects;

namespace Unik.Application.Commands.Booking.DTO
{
    public class BookingCreateRequestDto
    {
        public List<int> ItemIds { get; set; }
        //public string UserId { get; set; } //Tilknyt Userid
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
