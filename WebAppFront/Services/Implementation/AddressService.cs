using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Addresses;

namespace WebAppFront.Services.Implementation
{
    /// <summary>
    /// Service til MemberWithAddress
    /// </summary>
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

        async Task IAddressService.DeleteMemberWithAddress(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/MemberWithAddress/delete/{id}/");
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Kunne ikke slette medlem med adresse");
            }
        }

        async Task<IEnumerable<ForeningsMedlemQueryResultDto>> IAddressService.GetAllMemberWithAddress()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ForeningsMedlemQueryResultDto>>("api/MemberWithAddress");
        }
    }
}
