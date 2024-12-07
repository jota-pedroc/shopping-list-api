namespace shopping_list_api.Contracts;

public record ItemResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}