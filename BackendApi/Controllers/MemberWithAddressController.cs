using Microsoft.AspNetCore.Mvc;
using Unik.Application.Commands.MemberWithAddress;
using Unik.Application.Commands.MemberWithAddress.RequestModels;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberWithAddressController : Controller
    {
        private readonly ICreateMemberWithAddressCommand _createMemberWithAddressCommand;

        public MemberWithAddressController(ICreateMemberWithAddressCommand createMemberWithAddressCommand)
        {
            _createMemberWithAddressCommand = createMemberWithAddressCommand;
        }

        [HttpPost("create")] //api/MemberWithAddress/create
        public async Task<IActionResult> Create(MemberWithAddressRequestDto dto)
        {
            try
            {
                await _createMemberWithAddressCommand.CreateMemberWithAddress(dto);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet] //Er nød til at have en get her for ellers vil swagger ikke være med
        public IActionResult Index()
        {
            return View();
        }
    }
}
