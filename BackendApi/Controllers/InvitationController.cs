using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
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

        public InvitationController(ICreateInvitationCommand createInvitationCommand, IGetInvitationQuery getInvitationQuery, IGetAllInvitationQuery getAllInvitationQuery, IEditInvitationCommand editInvitationCommand, IDeleteInvitationCommand deleteInvitationCommand)
        {
            _createInvitationCommand = createInvitationCommand;
            _getInvitationQuery = getInvitationQuery;
            _getAllInvitationQuery = getAllInvitationQuery;
            _editInvitationCommand = editInvitationCommand;
            _deleteInvitationCommand = deleteInvitationCommand;
        }

        [HttpPost("create")] //api/Invitation/create 
        public IActionResult Post(InvitationRequestDto dto)
        { //2024-01-20 date time format til swagger
            try
            {
                _createInvitationCommand.CreateInvitation(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{id}/")] //api/invitation/delete/{id}
        public ActionResult<InvitationDeleteRequestDto> Delete(int id)
        {
            try
            {
                _deleteInvitationCommand.DeleteInvitation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }
        [HttpPut("edit")] //api/invitation/edit
        [Consumes(MediaTypeNames.Application.Json)]
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
