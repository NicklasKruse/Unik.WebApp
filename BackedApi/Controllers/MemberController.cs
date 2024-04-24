using Microsoft.AspNetCore.Mvc;
using Unik.Application.Commands.Member;
using Unik.Application.Commands.Member.DTO;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")] //api/Member
    [ApiController]
    public class MemberController : Controller
    {
        private readonly ICreateMemberCommand _createMemberCommand;
        public MemberController(ICreateMemberCommand createMemberCommand)
        {
            _createMemberCommand = createMemberCommand;
        }

        [HttpPost("create")] //api/Member/create
        public IActionResult Create(MemberCreateRequestDto dto)
        {
            try
            {
                _createMemberCommand.CreateMember(dto);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
