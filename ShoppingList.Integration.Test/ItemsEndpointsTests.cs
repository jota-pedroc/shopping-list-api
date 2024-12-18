using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using shopping_list_api.model;

namespace ShoppingList.Integration.Test
{
    [TestClass]
    public class ItemsEndpointsTests
    {
        private readonly HttpClient _client;

        public ItemsEndpointsTests()
        {
            // Set up a WebApplicationFactory to create the test server
            var factory = new WebApplicationFactory<Program>(); 
            _client = factory.CreateClient();
        }

        [TestMethod]
        public async Task GetAllItems_ReturnsOkResponse()
        {
            // Act
            var response = await _client.GetAsync("/api/v1/items");

            // Assert
            response.EnsureSuccessStatusCode();  // Status code 200-299 indicates success
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(!string.IsNullOrEmpty(content));  // Check if response content is not empty
        }

        [TestMethod]
        public async Task GetItemById_ReturnsOkResponse_WhenItemExists()
        {
            // Arrange
            var itemId = new Guid("d6089e16-62f7-4131-8ed4-13fbc2e1c85d");  // Replace with a valid item ID in your test DB
            var expectedItem = new ItemModel()
            {
                Id = itemId,
                Name = "Paçoca",
            };

            // Act
            var response = await _client.GetAsync($"/api/v1/items/{itemId}");

            // Assert
            response.EnsureSuccessStatusCode();  // Status code 200
            var content = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<ItemModel>(content);  // Deserialize to Item model

            Assert.IsNotNull(item);
            Assert.AreEqual(expectedItem.Id, item.Id);
            Assert.AreEqual(expectedItem.Name, item.Name);
        }

        [TestMethod]
        public async Task GetItemById_ReturnsNotFound_WhenItemDoesNotExist()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();  // Non-existent GUID

            // Act
            var response = await _client.GetAsync($"/api/v1/items/{nonExistentId}");

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);  // 404 Not Found
        }
    }
}
