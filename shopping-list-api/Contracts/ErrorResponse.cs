namespace shopping_list_api.Contracts;

public class ErrorResponse
{
    public string? Message { get; set; }
    public string? Title { get; set; }
    public int StatusCode { get; set; }
}