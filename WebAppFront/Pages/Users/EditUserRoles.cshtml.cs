using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebAppFront.Pages.Users
{
    [Authorize(Roles = "Formand")]
    public class EditUserRolesModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EditUserRolesModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public string UserId { get; set; }

        public List<IdentityRole> AvailableRoles { get; set; }

        [BindProperty]
        public List<string> SelectedRoles { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("User ID not provided");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            UserId = user.Id;
            AvailableRoles = await _roleManager.Roles.ToListAsync();
            SelectedRoles = (await _userManager.GetRolesAsync(user)).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var rolesToAdd = SelectedRoles.Except(currentRoles);
            var rolesToRemove = currentRoles.Except(SelectedRoles);

            foreach (var role in rolesToAdd)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            foreach (var role in rolesToRemove)
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }

            return RedirectToPage("./Index");
        }
    }
}