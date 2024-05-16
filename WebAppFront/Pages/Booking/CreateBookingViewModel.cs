using WebAppFront.Services.Models.Item;

namespace WebAppFront.Pages.Booking
{
    public class CreateBookingViewModel
    {
        public ItemQueryResultDto Item { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
