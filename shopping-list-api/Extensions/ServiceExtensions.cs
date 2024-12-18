using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using shopping_list_api.AppContext;
using shopping_list_api.Exceptions;
using shopping_list_api.Interfaces;
using shopping_list_api.Services;

namespace shopping_list_api.Extensions;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));
        if (builder.Configuration == null) throw new ArgumentNullException(nameof(builder.Configuration));

        // Adding the database context
        builder.Services.AddDbContext<ApplicationContext>(configure =>
        {
            configure.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
        });

        // Adding validators from the current assembly
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Adding services
        builder.Services.AddScoped<IItemService, ItemService>();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();
    }
}