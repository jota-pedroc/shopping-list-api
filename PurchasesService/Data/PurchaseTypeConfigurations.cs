using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Purchases.Models;

namespace Purchases.Data;

public class PurchaseTypeConfigurations : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("Purchases");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Quantity).IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
    }
}