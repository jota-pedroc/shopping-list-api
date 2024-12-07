using Microsoft.EntityFrameworkCore;
using shopping_list_api.AppContext;
using shopping_list_api.Contracts;
using shopping_list_api.Interfaces;

namespace shopping_list_api.Services;

public class ItemService(ApplicationContext context, ILogger<ItemService> logger) : IItemService
{
    public async Task<ItemResponse?> GetItemByIdAsync(Guid id)
    {
        try
        {
            var item = await context.Items.FindAsync(id);
            if (item == null)
            {
                logger.LogWarning("Item with id: {id} not found", id);
                return null;
            }

            return new ItemResponse()
            {
                Id = item.Id,
                Name = item.Name,
            };
        }
        catch (Exception ex)
        {
            logger.LogError("Error retrieving item: {Message}", ex.Message);
            throw;
        }
        
    }

    public async Task<IEnumerable<ItemResponse>> GetItemsAsync()
    {
        
        try
        {
            var items = await context.Items.ToListAsync();
            return items.Select(i => new ItemResponse()
            {
                Id = i.Id,
                Name = i.Name,
            });
        }
        catch (Exception ex)
        {
            logger.LogError("Error retrieving items: {Message}", ex.Message);
            throw;
        }
    }
}