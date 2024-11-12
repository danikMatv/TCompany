using Xunit;
using Moq;
using BLL.Services;
using BLL.IServices;
using DTO.Entity;
using DAL.Repository;

namespace BTestProject2
{
    public class GoodsServiceTests
    {
        [Fact]
        public void GetById_ReturnsCorrectGoods()
        {
            var mockGoodsDal = new Mock<IGoods>();
            var expectedGoods = new Goods { id = 3, name = "Item" };
            mockGoodsDal.Setup(dal => dal.GetById(3)).Returns(expectedGoods);

            var goodsService = new GoodsService(mockGoodsDal.Object);

            var goods = goodsService.GetById(3);

            Assert.NotNull(goods);
            Assert.Equal(3, goods.id);
            Assert.Equal("Item", goods.name);
        }

        [Fact]
        public void Create_CreatesNewGoods()
        {
            var mockGoodsDal = new Mock<IGoods>();
            var goodsToCreate = new Goods { id = 4, name = "NewItem" };
            mockGoodsDal.Setup(dal => dal.Create(It.IsAny<Goods>())).Returns(goodsToCreate);

            var goodsService = new GoodsService(mockGoodsDal.Object);

            var createdGoods = goodsService.Create(goodsToCreate);

            Assert.NotNull(createdGoods);
            Assert.Equal(4, createdGoods.id);
            Assert.Equal("NewItem", createdGoods.name);
        }

        [Fact]
        public void Update_UpdatesExistingGoods()
        {
            var mockGoodsDal = new Mock<IGoods>();
            var updatedGoods = new Goods { id = 3, name = "UpdatedItem" };
            mockGoodsDal.Setup(dal => dal.Update(3, It.IsAny<Goods>())).Returns(updatedGoods);

            var goodsService = new GoodsService(mockGoodsDal.Object);

            var result = goodsService.Update(3, updatedGoods);

            Assert.NotNull(result);
            Assert.Equal(3, result.id);
            Assert.Equal("UpdatedItem", result.name);
        }

        [Fact]
        public void Delete_DeletesGoods()
        {
            var mockGoodsDal = new Mock<IGoods>();
            var goodsToDelete = new Goods { id = 3, name = "ItemToDelete" };
            mockGoodsDal.Setup(dal => dal.Delete(3)).Returns(goodsToDelete);

            var goodsService = new GoodsService(mockGoodsDal.Object);

            var deletedGoods = goodsService.Delete(3);

            Assert.NotNull(deletedGoods);
            Assert.Equal(3, deletedGoods.id);
            Assert.Equal("ItemToDelete", deletedGoods.name);
        }

        [Fact]
        public void GetAll_ReturnsAllGoods()
        {
            var mockGoodsDal = new Mock<IGoods>();
            var goodsList = new List<Goods>
            {
                new Goods { id = 1, name = "Item1" },
                new Goods { id = 2, name = "Item2" }
            };
            mockGoodsDal.Setup(dal => dal.GetAll()).Returns(goodsList);

            var goodsService = new GoodsService(mockGoodsDal.Object);

            var result = goodsService.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, g => g.name == "Item1");
            Assert.Contains(result, g => g.name == "Item2");
        }
    }
}
