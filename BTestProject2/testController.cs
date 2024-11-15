using BLL.IServices;
using DTO.Entity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplication1.Controllers;
using Xunit;

namespace BTestProject2
{
    public class GoodsControllerTests
    {
        [Fact] // Use [Fact] instead of [Test] for XUnit
        public void Index_ReturnsViewWithGoodsList()
        {
            // Arrange
            var mockGoodsService = new Mock<IGoodsService>();
            mockGoodsService.Setup(service => service.GetAll())
                .Returns(new List<Goods>
                {
                    new Goods { id = 1, name = "Item1", price = 100, manager_id = 1 },
                    new Goods { id = 2, name = "Item2", price = 200, manager_id = 2 }
                });

            var controller = new GoodsController(mockGoodsService.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result); // Verify result is of type ViewResult
            var model = Assert.IsAssignableFrom<List<Goods>>(viewResult.Model); // Verify the model type
            Assert.Equal(2, model.Count); // Check the number of items in the model
        }
    }
}
