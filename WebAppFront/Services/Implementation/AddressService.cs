using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Addresses;

namespace WebAppFront.Services.Implementation
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IAddressService.CreateMemberWithAddress(ForeningsMedlemCreateRequestDto foreningsMedlem)
        {
            var response = await _httpClient.PostAsJsonAsync("api/MemberWithAddress/create", foreningsMedlem);
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Kunne ikke oprette medlem med adresse");
            }
        }
    }
}
