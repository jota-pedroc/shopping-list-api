using Purchases.Services;

namespace Purchases;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapPurchasesService(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/purchase/{id:guid}",
            async (IPurchasesService purchasesService, Guid id ) =>
            {
                var result = await purchasesService.GetPurchaseByIdAsync(id);
                return result == null ? Results.NotFound() : Results.Ok(result);
            });
        return endpoints;
    }
    
}