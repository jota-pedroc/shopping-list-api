using Microsoft.EntityFrameworkCore;
using Purchases.Data;
using Purchases.Mappers;

namespace Purchases.Services;

public static class ServiceExtensions
{

    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        if (builder.Configuration == null) throw new ArgumentNullException(nameof(builder.Configuration));

        builder.Services.AddDbContext<ApplicationContext>(configure =>
        {
            configure.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        
        // Adding services
        builder.Services.AddSingleton<IPurchaseMapper, PurchaseMapper>();
        builder.Services.AddScoped<IPurchasesService, PurchasesService>();
        builder.Services.AddProblemDetails();

    }
    
}