using Microsoft.EntityFrameworkCore;
using Purchases.Contracts;
using Purchases.Data;
using Purchases.Mappers;

namespace Purchases.Services;

public class PurchasesService(ApplicationContext context, ILogger<PurchasesService> logger, IPurchaseMapper mapper)
    : IPurchasesService
{
    public async Task<IEnumerable<PurchaseResponse>> GetPurchasesAsync()
    {
        try
        {
            return (await context.Purchases.ToListAsync()).Select(mapper.MapToResponse);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while retrieving purchases");
            throw;
        }
    }

    public async Task<PurchaseResponse?> GetPurchaseByIdAsync(Guid id)
    {
        try
        {
            var purchase = await context.Purchases.FindAsync(id);
            if (purchase != null) return mapper.MapToResponse(purchase);
            
            logger.LogWarning("Purchase with id: {id} was not found", id);   
            return null;
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while retrieving purchase with id {id}", id);
            throw;
        }
    }
}