using shopping_list_api.Contracts;

namespace shopping_list_api.Interfaces;

public interface IItemService
{
    Task<ItemResponse?> GetItemByIdAsync(Guid id);
    Task<IEnumerable<ItemResponse>> GetItemsAsync();
}