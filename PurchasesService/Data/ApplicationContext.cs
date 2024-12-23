using Microsoft.EntityFrameworkCore;
using Purchases.Models;

namespace Purchases.Data;

public class ApplicationContext : DbContext
{
    private const string DefaultSchema = "Purchases";

    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Purchase> Purchases { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(DefaultSchema);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}