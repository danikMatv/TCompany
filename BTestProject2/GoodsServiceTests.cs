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
        public void UpdateGoodsByGoodsId()
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
    }
}
