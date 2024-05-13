using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;

namespace WebAppFront.Pages.Item
{
    [Authorize(Roles = "Formand, Bestyrelse")]
    public class EditModel : PageModel
    {
        private readonly IItemService _itemService;

        public EditModel(IItemService itemService)
        {
            _itemService = itemService;
        }
        [BindProperty] public EditItemViewModel EditViewModel { get; set; } //Binder data fra form

        public async Task<IActionResult> OnGet(int id)
        {
            var item = await _itemService.GetItemById(id);

            EditViewModel = new EditItemViewModel
            {
                Id = item.Id,
                Damage = item.Damage,
                Description = item.Description,
            };
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var updatedItem = new Services.Models.Item.ItemEditRequestDto
            {
                Id = EditViewModel.Id,
                Damage = EditViewModel.Damage,
                Description = EditViewModel.Description,
            };
            await _itemService.EditItem(updatedItem);
            return RedirectToPage("./Index");
        }
    }
}
