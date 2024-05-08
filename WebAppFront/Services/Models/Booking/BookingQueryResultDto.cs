using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppFront.Services.Models.Booking
{
    public class BookingQueryResultDto
    {
        public int ItemId { get; set; }
        public string UserId { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
