using System.ComponentModel.DataAnnotations;
using Unik.Domain.ValueObjects;

namespace Unik.Application.Commands.Booking.DTO
{
    public class BookingCreateRequestDto
    {
        //public Domain.ValueObjects.Item Item { get; set; }
        public int ItemId { get; set; }
        public string UserId { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
