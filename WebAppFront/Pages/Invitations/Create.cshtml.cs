using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Pages.Member;
using WebAppFront.Services.Implementation;
using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Invitation;

namespace WebAppFront.Pages.Invitations
{
    public class CreateModel : PageModel
    {
        private readonly IInvitationService _invitationService;

        public CreateModel(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }
        [BindProperty]
        public CreateInvitationViewModel CreateInvitationVM { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var invitation = new InvitationCreateRequestDto
            {
                Date = CreateInvitationVM.Date,
                Description = CreateInvitationVM.Description,
                CreatedBy = User.Identity.Name,
                DateOfCreation = DateTime.UtcNow,
            };

            await _invitationService.CreateInvitation(invitation);
            return RedirectToPage("Index");
        }

    }
}
