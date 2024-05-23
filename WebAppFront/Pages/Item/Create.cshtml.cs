using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Item;

namespace WebAppFront.Pages.Item
{
    /// <summary>
    /// Oprettelse af et nyt item. Kan kun tilgås af formand og bestyrelse
    /// </summary>
    [Authorize(Roles = "Formand, Bestyrelse")]
    public class CreateModel : PageModel
    {
        private readonly IItemService _itemService;

        public CreateModel(IItemService itemService)
        {
            _itemService = itemService;
        }
        [BindProperty]
        public CreateItemViewModel CreateItemVM { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var item = new ItemCreateRequestDto
            {
                Description = CreateItemVM.Description,
            };

            await _itemService.CreateItem(item);
            return RedirectToPage("Index");
        }
        public void OnGet()
        {
        }
    }
}
