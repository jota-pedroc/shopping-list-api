using Purchases.Contracts;
using Purchases.Models;

namespace Purchases.Mappers;

public interface IPurchaseMapper
{
    public PurchaseResponse MapToResponse(Purchase purchase);
}