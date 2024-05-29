using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Net.Mime;
using Unik.Application.Commands.Booking;
using Unik.Application.Commands.Booking.DTO;
using Unik.Application.Commands.EmailCommand;
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
        private readonly ISendEmailCommand _sendEmailCommand;

        public BookingController(IGetAllBookingQuery getAllBookingQuery, IGetBookingQuery getBookingQuery, ICreateBookingCommand createBookingCommand, IEditBookingCommand editBookingCommand, IDeleteBookingCommand deleteBookingCommand, ILogger<BookingController> logger, ISendEmailCommand sendEmailCommand)
        {
            _getAllBookingQuery = getAllBookingQuery;
            _getBookingQuery = getBookingQuery;
            _createBookingCommand = createBookingCommand;
            _editBookingCommand = editBookingCommand;
            _deleteBookingCommand = deleteBookingCommand;
            _logger = logger;
            _sendEmailCommand = sendEmailCommand;
        }

        [HttpPost("create")] //api/Booking/create
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(BookingCreateRequestDto dto)
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
                _sendEmailCommand.SendToSingleUser(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{id}/")] //api/Booking/delete/{id}
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingDeleteRequestDto> Delete(int id)
        {
            try
            {
                _deleteBookingCommand.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit")] //api/Booking/edit
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult Put([FromBody] BookingEditRequestDto dto)
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
        [HttpGet("{id}")] //api/Booking/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BookingQueryResultDto>> GetAll()
        {
           var bookings = _getAllBookingQuery.GetAllBooking();
            return bookings.ToList(); //ToList()
        }
        /// <summary>
        /// Kaos metode. Det er til stripe
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("chargeDeposit")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] ChargeDepositRequestDto dto)
        {
            try
            {
                //var pmservice = new PaymentMethodService();
                //var paymentMethod = pmservice.Get("pm_1MqLiJLkdIwHu7ixUEgbFdYF");

                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(dto.Amount * 100), // amount * 100, det er i øre/cents
                    Currency = "usd",
                    PaymentMethod = "pm_card_visa",//Vælg payment method, det er fra stripes test kort
                    Confirm = true,
                    ReturnUrl = "http://localhost:8082/Booking", //Den skal have en url, hvor den skal sende brugeren hen efter betalingen er gennemført
                };

                var service = new PaymentIntentService();
                PaymentIntent paymentIntent = await service.CreateAsync(options);

                if (paymentIntent.Status != "succeeded")//For at undgå at opkræve flere gange
                {

                    var confirmOptions = new PaymentIntentConfirmOptions { };
                    await service.ConfirmAsync(paymentIntent.Id, confirmOptions);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to charge deposit");
                return BadRequest(ex.Message);
            }
        }


        //[HttpPost("chargeDeposit")]
        //public async Task<IActionResult> ChargeDeposit([FromBody] ChargeDepositRequestDto dto)
        //{
        //    try
        //    {
        //        // Logic to charge deposit using Stripe
        //        // This might involve creating a PaymentIntent and confirming it
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Failed to charge deposit");
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
