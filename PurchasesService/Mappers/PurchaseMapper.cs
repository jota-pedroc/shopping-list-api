using Purchases.Contracts;
using Purchases.Models;

namespace Purchases.Mappers;

public class PurchaseMapper : IPurchaseMapper
{
    public PurchaseResponse MapToResponse(Purchase purchase)
    {
        if (purchase == null) return null;
        
        return new PurchaseResponse
        {
            Id = purchase.Id,
            Date = purchase.Date,
            ItemId = purchase.ItemId,
            Quantity = purchase.Quantity,
            PricePerUnit = purchase.PricePerUnit,
        };
    }
}