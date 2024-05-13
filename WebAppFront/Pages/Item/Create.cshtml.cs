using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppFront.Pages.Item
{
    [Authorize(Roles = "Formand, Bestyrelse")]
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
