using Purchases.Services;

namespace Purchases.PurchasesEndpoints;

public static class PurchasesEndpoints
{
    public static IEndpointRouteBuilder MapPurchaseEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/purchases", async (IPurchasesService purchasesService) => Results.Ok(await purchasesService.GetPurchasesAsync()));
        endpoints.MapGet("/purchases/{id:guid}",
            async (IPurchasesService purchasesService, Guid id) =>
            {
                var result = await purchasesService.GetPurchaseByIdAsync(id);
                return result == null ? Results.NotFound() : Results.Ok(result);
            });
        return endpoints;
    }
}