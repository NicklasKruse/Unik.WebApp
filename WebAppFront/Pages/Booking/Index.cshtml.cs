using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Booking;

namespace WebAppFront.Pages.Booking
{
    public class IndexModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public IndexModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public IEnumerable<BookingQueryResultDto> SortedBookings { get; set; }
        public IEnumerable<BookingQueryResultDto> SelectedDateRangeBookings { get; set; }
        public DateTime SelectedStartDate { get; set; }
        public DateTime SelectedEndDate { get; set; }


        public async Task OnGetAsync()
        {
            SortedBookings = await _bookingService.GetAllBookingsSortedByDate();
        }
        public async Task OnPostAsync()
        {
            SortedBookings = await _bookingService.GetAllBookingsSortedByDate();
            SelectedDateRangeBookings = await _bookingService.GetBookingsByDateRange(SelectedStartDate, SelectedEndDate);
        }
    }
}
