using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Member;

namespace WebAppFront.Pages.Member
{
    [Authorize(Roles = "Formand, Bestyrelse")]
    public class CreateModel : PageModel
    {
        private readonly IMemberService _memberService;
        public CreateModel(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [BindProperty] public CreateMemberViewModel CreateMemberViewModel { get; set; } = new(); //vi laver en bindproperty så vi kan opsamle data fra vores form og bruge det i vores post metode til at oprette et nyt medlem
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var member = new MemberCreateRequestDto
                {
                    Name = CreateMemberViewModel.Name,
                    Address = CreateMemberViewModel.Address
            };
            await _memberService.CreateMember(member);
            return RedirectToPage("Index");
        }
    }
}
