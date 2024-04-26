using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.ValueObjects;

namespace Unik.Application.Commands.Booking.DTO
{
    public class BookingDeleteRequestDto
    {
        public int Id { get; set; }
        public Domain.ValueObjects.Item Item { get; set; }
        //public List<Item> Items { get; set; }
        public string UserId { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
