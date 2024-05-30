using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;

namespace WebAppFront.Pages.Invitations
{

    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IInvitationService _invitationService;

        public IndexModel(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }
        public List<InvitationIndexViewModel> Invitations { get; set; } = new List<InvitationIndexViewModel>();
        public async Task OnGet()
        {
            var invitations = await _invitationService.GetAllInvitation();
            Invitations = invitations.Select(invitation => new InvitationIndexViewModel
            {
                Id = invitation.Id,
                Description = invitation.Description,
                Date = invitation.Date,
                CreatedBy = invitation.CreatedBy

            }).ToList();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _invitationService.DeleteInvitation(id);
            return RedirectToPage("./Index");
        }
    }
}
