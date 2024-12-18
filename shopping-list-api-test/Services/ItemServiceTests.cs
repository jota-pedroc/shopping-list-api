using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using shopping_list_api.AppContext;
using shopping_list_api.model;
using shopping_list_api.Services;

namespace shopping_list_tests.Services
{
    [TestClass]
    public class ItemServiceTests
    {
        private Mock<ApplicationContext> _mockContext;
        private Mock<ILogger<ItemService>> _mockLogger;
        private ItemService _itemService;

        [TestInitialize]
        public void TestInitialize()
        {
            var mockSet = new Mock<DbSet<ItemModel>>();
            _mockContext = new Mock<ApplicationContext>();
            _mockContext.Setup(m => m.Items).Returns(mockSet.Object);
            
            _mockLogger = new Mock<ILogger<ItemService>>();
            _itemService = new ItemService(_mockContext.Object, _mockLogger.Object);

            
        }

        [TestMethod]
        public async Task GetItemByIdAsync_ItemFound_ReturnsItemResponse()
        {
            // Arrange
            var itemId = Guid.NewGuid();
            var mockItem = new ItemModel
            {
                Id = itemId,
                Name = "Test Item"
            };

            _mockContext.Setup(c => c.Items.FindAsync(itemId)).ReturnsAsync(mockItem);

            // Act
            var result = await _itemService.GetItemByIdAsync(itemId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(mockItem.Id, result?.Id);
            Assert.AreEqual(mockItem.Name, result?.Name);
        }

        [TestMethod]
        public async Task GetItemByIdAsync_ItemNotFound_ReturnsNull()
        {
            // Arrange
            var itemId = Guid.NewGuid();

            _mockContext.Setup(c => c.Items.FindAsync(itemId)).ReturnsAsync((ItemModel?)null);

            // Act
            var result = await _itemService.GetItemByIdAsync(itemId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task GetItemByIdAsync_ExceptionThrown_ThrowsException()
        {
            // Arrange
            var itemId = Guid.NewGuid();
            var exceptionMessage = "Database error";
            _mockContext.Setup(c => c.Items.FindAsync(itemId)).ThrowsAsync(new Exception(exceptionMessage));

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(() => _itemService.GetItemByIdAsync(itemId));
        }

        [TestMethod]
        public async Task GetItemsAsync_ReturnsItems()
        {
            // Arrange
            var mockItems = new List<ItemModel>
            {
                new ItemModel { Name = "BBB" },
                new ItemModel { Name = "ZZZ" },
                new ItemModel { Name = "AAA" },
            };
            var data = mockItems.AsQueryable();
            
            var mockSet = new Mock<DbSet<ItemModel>>();
            mockSet.As<IDbAsyncEnumerable<ItemModel>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<ItemModel>(data.GetEnumerator()));
            
            mockSet.As<IAsyncEnumerable<ItemModel>>()
                .Setup(m => m.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new TestDbAsyncEnumerator<ItemModel>(data.GetEnumerator()));

            mockSet.As<IQueryable<ItemModel>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<ItemModel>(data.Provider));

            mockSet.As<IQueryable<ItemModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ItemModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ItemModel>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            _mockContext = new Mock<ApplicationContext>();
            _mockContext.Setup(c => c.Items).Returns(mockSet.Object);
            _itemService = new ItemService(_mockContext.Object, _mockLogger.Object);

            // Act
            var result = await _itemService.GetItemsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(mockItems.Count, result.Count());
            Assert.AreEqual(mockItems[0].Name, result.First().Name);
        }
    }
}
