using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Application.Commands.EmailCommand;
using Unik.Application.Commands.Invitation;
using Unik.Application.Commands.Invitation.RequestModels;
using Unik.Application.Queries.Invitation;
using Unik.Application.Queries.Invitation.DTO;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")] //api/Invitation
    [ApiController]
    public class InvitationController : Controller
    {
        private readonly ICreateInvitationCommand _createInvitationCommand;
        private readonly IGetInvitationQuery _getInvitationQuery;
        private readonly IGetAllInvitationQuery _getAllInvitationQuery;
        private readonly IEditInvitationCommand _editInvitationCommand;
        private readonly IDeleteInvitationCommand _deleteInvitationCommand;
        private readonly ISendEmailCommand _sendEmailCommand;

        public InvitationController(ICreateInvitationCommand createInvitationCommand, IGetInvitationQuery getInvitationQuery, IGetAllInvitationQuery getAllInvitationQuery, IEditInvitationCommand editInvitationCommand, IDeleteInvitationCommand deleteInvitationCommand, ISendEmailCommand sendEmailCommand)
        {
            _createInvitationCommand = createInvitationCommand;
            _getInvitationQuery = getInvitationQuery;
            _getAllInvitationQuery = getAllInvitationQuery;
            _editInvitationCommand = editInvitationCommand;
            _deleteInvitationCommand = deleteInvitationCommand;
            _sendEmailCommand = sendEmailCommand;
        }

        [HttpPost("create")] //api/Invitation/create 
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(InvitationRequestDto dto)
        { //2024-01-20 date time format til swagger
            try
            {
                _createInvitationCommand.CreateInvitation(dto);
                await _sendEmailCommand.SendEmailsToAllMembersAsync(dto.CreatedBy, dto.Description);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{id}/")] //api/invitation/delete/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InvitationDeleteRequestDto> Delete(int id)
        {
            try
            {
                _deleteInvitationCommand.DeleteInvitation(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }
        [HttpPut("edit")] //api/invitation/edit
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult Put([FromBody] InvitationEditRequestDto dto)
        {
            try
            {
                _editInvitationCommand.EditInvitation(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get/{id}")] //api/invitation/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InvitationQueryResultDto> Get(int id)
        {
            try
            {
                return Ok(_getInvitationQuery.GetInvitation(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getall")] //api/invitation/getall
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<InvitationQueryResultDto>> GetAll()
        {
            try
            {
                return Ok(_getAllInvitationQuery.GetAllInvitation());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
