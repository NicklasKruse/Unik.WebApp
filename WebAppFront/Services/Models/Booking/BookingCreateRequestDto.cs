using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppFront.Services.Models.Item;

namespace WebAppFront.Services.Models.Booking
{
    public class BookingCreateRequestDto
    {
        //public ItemQueryResultDto Item{ get; set; }
        public int ItemId { get; set; } 
        public string UserId { get; set; } //Tilknyt Userid
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
