using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Item;

namespace WebAppFront.Services.Implementation
{
    /// <summary>
    /// Service til håndtering af items
    /// </summary>
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IItemService.CreateItem(ItemCreateRequestDto itemRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Item/create", itemRequest);
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Failed to create item");
            }
        }

        async Task IItemService.DeleteItem(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Item/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Failed to delete item");
            }
        }

        async Task IItemService.EditItem(ItemEditRequestDto itemRequest)
        {
           var response = await _httpClient.PutAsJsonAsync("api/Item/edit", itemRequest);
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Failed to edit item");
            }
        }

        async Task<IEnumerable<ItemQueryResultDto>> IItemService.GetAllItem()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ItemQueryResultDto>>("api/Item/getall");
        }

        async Task<ItemQueryResultDto> IItemService.GetItemById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ItemQueryResultDto>($"api/Item/{id}");
        }
    }
}
