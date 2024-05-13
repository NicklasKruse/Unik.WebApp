using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;

namespace WebAppFront.Pages.Item
{
    [Authorize(Roles = "Formand, Bestyrelse")]
    public class IndexModel : PageModel
    {
        private readonly IItemService itemService;

        public IndexModel(IItemService itemService)
        {
            this.itemService = itemService;
        }
        [BindProperty]
        public List<ItemIndexViewModel> Items { get; set; } = new List<ItemIndexViewModel>();  
        public async Task OnGet()
        {
            var items = await itemService.GetAllItem();
            Items = items.Select(item => new ItemIndexViewModel
            {
                Id = item.Id,
                Damage = item.Damage,
                Description = item.Description,
            }).ToList();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await itemService.DeleteItem(id);
            return RedirectToPage("./Index");
        }
    }
}
