using BLL.Services;
using DTO.Entity;
using Moq;
using System.Data.SqlClient;
using Xunit;
namespace BTestProject1
{
    public class GoodsServiceTests
    {
        [Fact]
        public void GetById_ShouldReturnGoods_WhenGoodsExists()
        {
            var mockConnection = new Mock<SqlConnection>();
            var mockCommand = new Mock<SqlCommand>();
            var mockReader = new Mock<SqlDataReader>();

            int goodsId = 1;
            string goodsName = "Sample Goods";
            int goodsPrice = 100;
            int managerId = 2;

            mockReader.SetupSequence(reader => reader.Read())
                      .Returns(true)
                      .Returns(false);

            mockReader.Setup(reader => reader["id"]).Returns(goodsId);
            mockReader.Setup(reader => reader["name"]).Returns(goodsName);
            mockReader.Setup(reader => reader["price"]).Returns(goodsPrice);
            mockReader.Setup(reader => reader["manager_id"]).Returns(managerId);
            mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(mockReader.Object);
            mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);

            var goodsService = new GoodsService(mockConnection.Object);

            Goods result = goodsService.GetById(goodsId);

            Assert.NotNull(result);
            Assert.Equal(goodsId, result.id);
            Assert.Equal(goodsName, result.name);
            Assert.Equal(goodsPrice, result.price);
            Assert.Equal(managerId, result.manager_id);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenGoodsDoesNotExist()
        {
            var mockConnection = new Mock<SqlConnection>();
            var mockCommand = new Mock<SqlCommand>();
            var mockReader = new Mock<SqlDataReader>();

            mockReader.Setup(reader => reader.Read()).Returns(false);

            mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(mockReader.Object);

            mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);

            var goodsService = new GoodsService(mockConnection.Object);

            Goods result = goodsService.GetById(1);

            Assert.Null(result);
        }
    }
}
