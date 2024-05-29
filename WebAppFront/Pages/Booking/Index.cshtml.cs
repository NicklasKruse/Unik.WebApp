using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Pages.Item;
using WebAppFront.Services.Implementation;
using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Booking;

namespace WebAppFront.Pages.Booking
{
    public class IndexModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly IItemService _itemService;

        public IndexModel(IBookingService bookingService, IItemService itemService)
        {
            _bookingService = bookingService;
            _itemService = itemService;

        }
        public IEnumerable<BookingQueryResultDto> SortedBookings { get; set; }
        public IEnumerable<BookingQueryResultDto> SelectedDateRangeBookings { get; set; }
        public DateTime SelectedStartDate { get; set; }
        public DateTime SelectedEndDate { get; set; }
        public List<ItemIndexViewModel> Items { get; set; } = new List<ItemIndexViewModel>();


        public async Task OnGetAsync()
        {
            SortedBookings = await _bookingService.GetAllBookingsSortedByDate();
            var items = await _itemService.GetAllItem();
            foreach(var item in items)
            {
                Items.Add(new ItemIndexViewModel
                {
                    Description = item.Description
                });
            }
        }
        public async Task OnPostAsync()
        {
            SortedBookings = await _bookingService.GetAllBookingsSortedByDate();
            SelectedDateRangeBookings = await _bookingService.GetBookingsByDateRange(SelectedStartDate, SelectedEndDate);
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var booking = await _bookingService.GetBookingById(id);

            if (booking != null && User.Identity.Name == booking.CreatedBy || User.IsInRole("Formand"))
            {
                await _bookingService.DeleteBooking(id);
                TempData["SuccessMessage"] = "Booking Slettet";
                return RedirectToPage("./Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Kun formand eller den bruger der har booked dette item kan slette en booking.";
                return RedirectToPage("./Index"); 
            }
        }
    }
}
