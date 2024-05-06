using WebAppFront.Services.Models.Item;

namespace WebAppFront.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemQueryResultDto>> GetAllItem();
        Task<ItemQueryResultDto> GetItemById(int id);
        Task EditItem(ItemEditRequestDto itemRequest);
        Task CreateItem(ItemCreateRequestDto itemRequest);
        Task DeleteItem(int id);
    }
}
