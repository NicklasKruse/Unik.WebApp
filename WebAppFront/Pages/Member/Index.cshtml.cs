using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;

namespace WebAppFront.Pages.Member
{
    public class IndexModel : PageModel
    {
        private readonly IMemberService _memberService;

        public IndexModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [BindProperty]
        public int DeleteMemberId { get; set; }
        public List<MemberIndexViewModel> Members { get; set; } = new List<MemberIndexViewModel>();

        public async Task OnGet()
        {
            var members = await _memberService.GetAllMember();
            Members = members.Select(member => new MemberIndexViewModel
            {
                Id = member.Id,
                Name = member.Name,
                Address = member.Address,
                RowVersion = member.RowVersion
            }).ToList();
        }
        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _memberService.DeleteMember(id);
            return RedirectToPage("./Index");
        }
    }

}
