using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Application.Commands.Booking;
using Unik.Application.Commands.Booking.DTO;
using Unik.Application.Queries.Booking;
using Unik.Application.Queries.Booking.DTO;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")] //api/Booking
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IGetAllBookingQuery _getAllBookingQuery;
        private readonly IGetBookingQuery _getBookingQuery;
        private readonly ICreateBookingCommand _createBookingCommand;
        private readonly IEditBookingCommand _editBookingCommand;
        private readonly IDeleteBookingCommand _deleteBookingCommand;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IGetAllBookingQuery getAllBookingQuery, IGetBookingQuery getBookingQuery, ICreateBookingCommand createBookingCommand, IEditBookingCommand editBookingCommand, IDeleteBookingCommand deleteBookingCommand, ILogger<BookingController> logger)
        {
            _getAllBookingQuery = getAllBookingQuery;
            _getBookingQuery = getBookingQuery;
            _createBookingCommand = createBookingCommand;
            _editBookingCommand = editBookingCommand;
            _deleteBookingCommand = deleteBookingCommand;
            _logger = logger;
        }

        [HttpPost("create")] //api/Booking/create
        public IActionResult Create(BookingCreateRequestDto dto)
        {
            if(!ModelState.IsValid)
            {
                foreach(var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError(error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            try
            {
                _createBookingCommand.CreateBooking(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{id}/")] //api/Booking/delete/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookingDeleteRequestDto> Delete(int id)
        {
            try
            {
                _deleteBookingCommand.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit")] //api/Booking/edit
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult Edit([FromBody] BookingEditRequestDto dto)
        {
            try
            {
                _editBookingCommand.Edit(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")] //api/Booking/get/{id}
        public ActionResult<BookingQueryResultDto> Get(int id)
        {
            try
            {
                return Ok(_getBookingQuery.GetBooking(id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getall")] //api/Booking/getall
        public ActionResult<IEnumerable<BookingQueryResultDto>> GetAll()
        {
           var bookings = _getAllBookingQuery.GetAllBooking();
            return bookings.ToList(); //ToList()
        }

    }
}
