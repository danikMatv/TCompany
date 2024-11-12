using Xunit;
using Moq;
using System.Data.SqlClient;
using BLL.Services;

namespace BTestProject2
{
    public class GoodsServiceTests
    {
        string connStr = "Data Source=HP_DANIK\\SQLEXPRESS01;Initial Catalog=TradingCompany;Integrated Security=True;Encrypt=False;";

        [Fact]
        public void UpdateGoodsByGoodsId()
        {
            var goodsDal = new GoodsService(connStr);
            var goods = goodsDal.GetById(3);

            Assert.NotNull(goods);
            Assert.Equal(3, goods.id);
        }
    }
}
