using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Application.Commands.Member;
using Unik.Application.Commands.Member.DTO;
using Unik.Application.Queries.Member;
using Unik.Application.Queries.Member.DTO;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")] //api/Member
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ICreateMemberCommand _createMemberCommand;
        private readonly IGetMemberQuery _getMemberQuery;
        private readonly IGetAllMemberQuery _getAllMemberQuery;
        private readonly IEditMemberCommand _editMemberCommand;
        private readonly IDeleteMemberCommand _deleteMemberCommand;
        public MemberController(ICreateMemberCommand createMemberCommand, IGetAllMemberQuery getAllMemberQuery, IEditMemberCommand editMemberCommand, IDeleteMemberCommand deleteMemberCommand, IGetMemberQuery getMemberQuery)
        {
            _createMemberCommand = createMemberCommand;
            _getMemberQuery = getMemberQuery;
            _getAllMemberQuery = getAllMemberQuery;
            _editMemberCommand = editMemberCommand;
            _deleteMemberCommand = deleteMemberCommand;
        }

        [HttpPost("create")] //api/Member/create
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(MemberCreateRequestDto dto)
        {
            try
            {
                _createMemberCommand.CreateMember(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{id}/")] //api/Member/delete/{id}
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MemberDeleteRequestDto> Delete(int id)
        {
            try
            {
                _deleteMemberCommand.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } //Kan ikke mappe? AutoMapper tid?
        }

        [HttpPut("edit")] //api/Member/edit
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult Put([FromBody] MemberEditRequestDto dto)//Viker når frontend er klar. Det er frontconnectlibrary der skal sende data
        {
            try
            {
                _editMemberCommand.Edit(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}/")]//api/Member/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MemberQueryResultDto> Get(int id)
        {

            var member = _getMemberQuery.GetMember(id);
            return member;
        }/// <summary>
        /// ssssssTT
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<MemberQueryResultDto>> Get()
        {
            var members = _getAllMemberQuery.GetAllMember();
            return members.ToList();
        }
    }
}
