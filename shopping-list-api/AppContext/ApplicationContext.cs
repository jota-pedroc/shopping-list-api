using Microsoft.EntityFrameworkCore;
using shopping_list_api.Configuration;
using shopping_list_api.model;

namespace shopping_list_api.AppContext;

public class ApplicationContext(DbContextOptions<ApplicationContext> options): DbContext(options)
{

    private const string DefaultSchema = "itemsapi";
    
    public DbSet<ItemModel> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(DefaultSchema);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}