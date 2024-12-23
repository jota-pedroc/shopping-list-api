using Purchases.Contracts;

namespace Purchases.Services;

public interface IPurchasesService
{
    Task<IEnumerable<PurchaseResponse>> GetPurchasesAsync();
    Task<PurchaseResponse?> GetPurchaseByIdAsync(Guid id);
}