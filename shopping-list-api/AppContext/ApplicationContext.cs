using Microsoft.EntityFrameworkCore;
using shopping_list_api.model;

namespace shopping_list_api.AppContext;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    
    public ApplicationContext()
    {
    }

    private const string DefaultSchema = "itemsapi";
    
    public virtual DbSet<ItemModel> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(DefaultSchema);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}