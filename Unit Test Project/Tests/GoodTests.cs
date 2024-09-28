using Xunit;
using Microsoft.EntityFrameworkCore;
using DALEF.Conc;
using DALEF.Ct;

namespace Unit_Test_Project.Tests
{
    public class GoodTests
    {
        private readonly GoodsDalEf _goodsDal;
        private readonly DbContextOptions<ImdbContext> _dbContextOptions;

        public GoodTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ImdbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            using (var context = new ImdbContext("your_connection_string"))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            _goodsDal = new GoodsDalEf("your_connection_string", config.CreateMapper());
        }


        [Fact]
        public void CreateNewGoods_ShouldAddGoodsToDatabase()
        {
            var goods = new Goods { name = "Test Good", price = 100.0, manager_id = 1 };
            var createdGoods = _goodsDal.Create(goods);
            using (var context = new ImdbContext(_dbContextOptions))
            {
                var foundGoods = context.Goods.Find(createdGoods.id);
                Assert.NotNull(foundGoods);
                Assert.Equal("Test Good", foundGoods.name);
            }
        }

        [Fact]
        public void GetAllGoods_ShouldReturnAllGoods()
        {
            
            _goodsDal.Create(new Goods { name = "Good 1", price = 50.0, manager_id = 1 });
            _goodsDal.Create(new Goods { name = "Good 2", price = 75.0, manager_id = 2 });

            
            var goodsList = _goodsDal.GetAll();

            
            Assert.Equal(2, goodsList.Count);
        }

        [Fact]
        public void GetGoodsByGoodsId_ShouldReturnCorrectGoods()
        {
            
            var createdGoods = _goodsDal.Create(new Goods { name = "Test Good", price = 100.0, manager_id = 1 });

            
            var foundGoods = _goodsDal.GetById(createdGoods.id);

            
            Assert.NotNull(foundGoods);
            Assert.Equal("Test Good", foundGoods.name);
        }

        [Fact]
        public void UpdateGoodsByGoodsId_ShouldUpdateGoods()
        {
            
            var createdGoods = _goodsDal.Create(new Goods { name = "Old Name", price = 50.0, manager_id = 1 });
            createdGoods.name = "Updated Name";

            
            _goodsDal.Update(createdGoods.id, createdGoods);

            
            var updatedGoods = _goodsDal.GetById(createdGoods.id);
            Assert.Equal("Updated Name", updatedGoods.name);
        }

        [Fact]
        public void DeleteGoodsByGoodsId_ShouldRemoveGoods()
        {
            
            var createdGoods = _goodsDal.Create(new Goods { name = "Test Good", price = 100.0, manager_id = 1 });

            
            var deletedGoods = _goodsDal.Delete(createdGoods.id);

            
            using (var context = new ImdbContext(_dbContextOptions))
            {
                var foundGoods = context.Goods.Find(createdGoods.id);
                Assert.Null(foundGoods);
            }
        }
    }

}
