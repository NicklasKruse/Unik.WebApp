using Microsoft.AspNetCore.Identity;

namespace WebAppFront.Pages.Users
{
    public class EditUserRolesViewModel
    {
        public string UserId { get; set; }
        public List<string> SelectedRoles { get; set; } = new List<string>();
        public List<IdentityRole> AvailableRoles { get; set; }
    }

}
