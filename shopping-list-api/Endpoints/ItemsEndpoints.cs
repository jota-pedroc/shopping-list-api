using shopping_list_api.Interfaces;

namespace shopping_list_api.Endpoints;

public static class ItemsEndpoints
{
    public static IEndpointRouteBuilder MapItemsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/items", async (IItemService itemService) => Results.Ok(await itemService.GetItemsAsync()));
        endpoints.MapGet("/items/{id:guid}",
            async (IItemService itemService, Guid id) =>
            {
                var result = await itemService.GetItemByIdAsync(id);
                return result == null ? Results.NotFound() : Results.Ok(result);
            });
        return endpoints;
    }
}