﻿namespace Purchases.Models;

public class Purchase
{
    public Guid Id { get; set; }
    public Guid ItemId { get; set; }
    public decimal Quantity { get; set; }
    public long PricePerUnit { get; set; }
    public DateTime Date { get; set; }
    
    public Store Store { get; set; }
}