using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Application.Commands.MemberWithAddress;
using Unik.Application.Commands.MemberWithAddress.RequestModels;
using Unik.Application.Queries.MemberWithAddress;
using Unik.Application.Queries.MemberWithAddress.DTO;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberWithAddressController : Controller
    {
        private readonly ICreateMemberWithAddressCommand _createMemberWithAddressCommand;
        private readonly IGetAllMemberWithAddressQuery _getAllMemberWithAddressQuery;
        private readonly IDeleteMemberWithAddressCommand _deleteMemberWithAddressCommand;

        public MemberWithAddressController(ICreateMemberWithAddressCommand createMemberWithAddressCommand, IGetAllMemberWithAddressQuery getAllMemberWithAddressQuery, IDeleteMemberWithAddressCommand deleteMemberWithAddressCommand)
        {
            _createMemberWithAddressCommand = createMemberWithAddressCommand;
            _getAllMemberWithAddressQuery = getAllMemberWithAddressQuery;
            _deleteMemberWithAddressCommand = deleteMemberWithAddressCommand;
        }

        [HttpPost("create")] //api/MemberWithAddress/create
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(MemberWithAddressRequestDto dto)
        {
            try
            {
                await _createMemberWithAddressCommand.CreateMemberWithAddress(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet] //api/MemberWithAddress
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<MemberWithAddressQueryResultDto>> Get()
        {
            var membersWithAddress = _getAllMemberWithAddressQuery.GetAllMemberWithAddress();
            return membersWithAddress.ToList();
        }

        [HttpDelete("delete/{id}")] //api/MemberWithAddress/delete/{id}
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MemberWithAddressDeleteRequestDto> Delete(int id)
        {
            try
            {
                _deleteMemberWithAddressCommand.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
