using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;

namespace WebAppFront.Pages.Users
{
    [Authorize(Roles = "Formand")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAddressService _addressService;

        [BindProperty(SupportsGet = true)] // for at sikre at vi kan opdatere selectedrole løbende.
        public string SelectedRole { get; set; }

        public IEnumerable<IdentityUser> Users { get; set; } = Enumerable.Empty<IdentityUser>();
        public List<MemberWithAddressViewModel> Members { get; set; } = new List<MemberWithAddressViewModel>();

        public IndexModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IAddressService addressService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _addressService = addressService;
        }
        /// <summary>
        /// Se alle brugere i systemet. Hvis en rolle er valgt, vises kun brugere med denne rolle.
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            var allUsers = _userManager.Users.ToList();
            var members = await _addressService.GetAllMemberWithAddress();

            Members = members.Select(member => new MemberWithAddressViewModel
            {
                Id = member.Id,
                Address = member.Address,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                RowVersion = member.RowVersion,
                DateOfCreation = member.DateOfCreation,
                CreatedBy = member.CreatedBy,
                LastModifiedDate = member.LastModifiedDate
            }).ToList();

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
        public async Task<IActionResult> OnPostDeleteAsync(string stringId, int intId)
        {
            var user = await _userManager.FindByIdAsync(stringId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            else
            {
                try
                {
                    await _addressService.DeleteMemberWithAddress(intId);
                    await _userManager.DeleteAsync(user);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                
            }

            return RedirectToPage("./Index");
        }
    }
}
