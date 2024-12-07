using Microsoft.AspNetCore.Mvc;

namespace shopping_list_api;

[Route("api/[controller]")]
[ApiController]
public class ShoppingListController : Controller
{
    [HttpGet]
    public async Task<ActionResult<string>> GetShoppingList()
    {
        return "Hello world";
    }
}