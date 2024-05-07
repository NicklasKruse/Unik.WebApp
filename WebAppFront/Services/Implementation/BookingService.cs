using System.Net;
using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Booking;

namespace WebAppFront.Services.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IBookingService.CreateBooking(BookingCreateRequestDto bookingRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Booking/create", bookingRequest);
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound) 
            {
                throw new Exception("Endpoint not found");
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
    }
}
