using System.Net;
using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Booking;

namespace WebAppFront.Services.Implementation
{
    /// <summary>
    /// Service til håndtering af booking
    /// </summary>
    public class BookingService : IBookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// I denne metode oprettes en booking og derefter opkræves et depositum
        /// </summary>
        /// <param name="bookingRequest"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        async Task IBookingService.CreateBooking(BookingCreateRequestDto bookingRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Booking/create", bookingRequest);
            if (response.IsSuccessStatusCode)
            {
                ChargeDepositRequestDto depositRequest = new ChargeDepositRequestDto
                {
                    Amount = 300m //Fixed pris for depositum
                };
                await ChargeDeposit(depositRequest);
                return;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest) 
            {
                throw new Exception("Bad Request");
            }
            else
            {
                throw new Exception("Failed to create booking");
            }
        }

        async Task IBookingService.DeleteBooking(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Booking/delete/{id}/");
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Failed to delete booking");
            }
        }

        async Task IBookingService.EditBooking(BookingEditRequestDto bookingRequest)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Booking/edit", bookingRequest);
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Failed to edit booking");
            }
        }

        async Task<IEnumerable<BookingQueryResultDto>> IBookingService.GetAllBooking()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BookingQueryResultDto>>("api/Booking/getall");
        }

        async Task<BookingQueryResultDto> IBookingService.GetBookingById(int id)
        {
            return await _httpClient.GetFromJsonAsync<BookingQueryResultDto>($"api/Booking/{id}");
        }

        /// <summary>
        /// Her hentes alle bookinger og sorteres efter startdato
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookingQueryResultDto>> GetAllBookingsSortedByDate()
        {
            var bookings = await _httpClient.GetFromJsonAsync<IEnumerable<BookingQueryResultDto>>("api/Booking/getall");
            return bookings.OrderBy(b => b.StartDate);
        }
        /// <summary>
        /// Henter alle bookinger i et givent tidsrum
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<BookingQueryResultDto>> GetBookingsByDateRange(DateTime startDate, DateTime endDate)
        {
            var bookings = await _httpClient.GetFromJsonAsync<IEnumerable<BookingQueryResultDto>>("api/Booking/getall");
            return bookings.Where(b => b.StartDate >= startDate && b.StartDate <= endDate);
        }
        /// <summary>
        /// Kald til backend for at opkræve depositum
        /// </summary>
        /// <param name="depositRequest"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ChargeDeposit(ChargeDepositRequestDto depositRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Booking/chargeDeposit", depositRequest);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to charge deposit: {error}");
            }
        }
    }
}
