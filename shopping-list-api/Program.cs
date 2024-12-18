using shopping_list_api.Endpoints;
using shopping_list_api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("internal");
}

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.MapGroup("/api/v1")
    .WithTags("Item endpoints")
    .MapItemsEndpoints();

app.Run();

public partial class Program { }
