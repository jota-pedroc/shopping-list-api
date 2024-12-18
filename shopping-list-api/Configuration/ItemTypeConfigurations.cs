using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopping_list_api.model;

namespace shopping_list_api.Configuration;

public class ItemTypeConfigurations : IEntityTypeConfiguration<ItemModel>
{
    public void Configure(EntityTypeBuilder<ItemModel> builder)
    {
        builder.ToTable("Items");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(500);

        builder.HasData(
            new ItemModel()
            {
                Id =new Guid("d6089e16-62f7-4131-8ed4-13fbc2e1c85d"),
                Name = "Paçoca"
            },
            new ItemModel()
            {
                Id = new Guid("b17b0981-e76f-48fb-a12e-d33eba793523"),
                Name = "Queijo"
            }
        );
    }
}