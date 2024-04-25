using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontConnectLibrary.Models.Booking
{
    public class BookingCreateRequestDto
    {
        //public List<Item> Items { get; set; } //Opret nyt dto object til Item
       // public string UserId { get; set; } //Tilknyt Userid
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
