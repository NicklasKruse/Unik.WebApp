using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;

namespace WebAppFront.Pages.Member
{
    [Authorize(Roles = "Formand, Bestyrelse")]
    public class EditModel : PageModel
    {
        private readonly IMemberService _memberService;

        public EditModel(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [BindProperty] public EditMemberViewModel EditViewModel { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var member = await _memberService.GetMemberById(id);

            EditViewModel = new EditMemberViewModel
            {
                Id = member.Id, 
                Name = member.Name,
                Address = member.Address,
                RowVersion = member.RowVersion
            };
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updatedMember = new Services.Models.Member.MemberEditRequestDto
            {
                Id = EditViewModel.Id,
                Name = EditViewModel.Name,
                Address = EditViewModel.Address,
                RowVersion = EditViewModel.RowVersion
            };

            await _memberService.EditMember(updatedMember);

            return RedirectToPage("./Index");
        }
    }
}
