using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppFront.Pages.Users
{
    [Authorize(Roles = "Formand")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        [BindProperty(SupportsGet = true)] // For at sikre 
        public string SelectedRole { get; set; }

        public IEnumerable<IdentityUser> Users { get; set; } = Enumerable.Empty<IdentityUser>();

        public IndexModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task OnGetAsync()
        {
            var allUsers = _userManager.Users.ToList();

            if (!string.IsNullOrEmpty(SelectedRole))
            {
                var role = await _roleManager.FindByNameAsync(SelectedRole);
                if (role != null)
                {
                    Users = allUsers.Where(user => _userManager.IsInRoleAsync(user, SelectedRole).Result);
                }
            }
            else
            {
                Users = allUsers;
            }
        }
    }
}
