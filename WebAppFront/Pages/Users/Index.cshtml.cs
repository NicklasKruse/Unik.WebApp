using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppUserContext;

namespace WebAppFront.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly WebAppUserDbContext _dbContext;
        [BindProperty]
        public IEnumerable<IdentityUser> users { get; set; } = Enumerable.Empty<IdentityUser>();

        public IndexModel(WebAppUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            users = _dbContext.Users.ToList();
        }
    }
}
