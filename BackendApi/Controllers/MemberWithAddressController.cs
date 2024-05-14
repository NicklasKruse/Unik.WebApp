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

        [HttpPost("create")]
        public IActionResult Create(MemberWithAddressRequestDto dto)
        {
            try
            {
                _createMemberWithAddressCommand.CreateMemberWithAddress(dto);
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
