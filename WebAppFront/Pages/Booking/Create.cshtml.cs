using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Pages.Item;
using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Booking;

namespace WebAppFront.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly IItemService _itemService;
        public CreateModel(IBookingService bookingService, IItemService itemService)
        {
            _bookingService = bookingService;
            _itemService = itemService;
        }
        [BindProperty] public CreateBookingViewModel CreateBookingViewModel { get; set; } = new CreateBookingViewModel();
        [BindProperty] public List<ItemIndexViewModel> Items { get; set; } = new List<ItemIndexViewModel>();

        public async Task OnGet()
        {
            var items = await _itemService.GetAllItem();
            Items = items.Select(item => new ItemIndexViewModel
            {
                Id = item.Id,
                Damage = item.Damage,
                Description = item.Description,
            }).ToList();
        }
        public async Task<IActionResult> OnPost(int id)
        {
            var item = await _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            var booking = new BookingCreateRequestDto
            {
                ItemId = item.Id,
                UserId = string.Empty, // string.Empty er nødvendig. Var tænkt som createdby. Slet hvis har tid
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                DateOfCreation = DateTime.Now,
                CreatedBy = User.Identity.Name
            };
            try
            {
                await _bookingService.CreateBooking(booking);

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}: Dette Item er allerede booked på denne dato";
                return RedirectToPage("Create");
            };
            return RedirectToPage("Index");
        }
    }
}
