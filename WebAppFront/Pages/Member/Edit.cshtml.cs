using FrontConnectLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppFront.Pages.Member
{
    public class EditModel : PageModel
    {
        private readonly IMemberService _memberService;

        public EditModel(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [BindProperty] public EditMemberViewModel EditModel { get; set; }
        public async Task<IActionResult> OnGet(int? memberId)
        {
            if(memberId == null)
            {
                return NotFound();
            }
            var member = await _memberService.GetMemberById(memberId);

            EditModel = new EditMemberViewModel
            {
                Id = member.Id,
                Name = member.Name,
                Address = member.Address,
                RowVersion = member.RowVersion
            };
        }
    }
}
