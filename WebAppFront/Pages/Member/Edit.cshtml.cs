using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;

namespace WebAppFront.Pages.Member
{
    public class EditModel : PageModel
    {
        private readonly IMemberService _memberService;

        public EditModel(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [BindProperty] public EditMemberViewModel EditViewModel { get; set; }
        public async Task<IActionResult> OnGet(int memberId)
        {
            if(memberId == null)
            {
                return NotFound();
            }
            var member = await _memberService.GetMemberById(memberId);

            EditViewModel = new EditMemberViewModel
            {
                Id = member.Id, 
                Name = member.Name,
                Address = member.Address,
                RowVersion = member.RowVersion
            };
            return Page();
        }
    }
}
