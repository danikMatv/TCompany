using DALEF.Conc;
using AutoMapper;
using DTO.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DALEF.Mapping;

namespace Unit_Test_Project.Tests
{
    [TestClass]
    public class GoodsTests
    {
        string connStr = "Data Source=HP_DANIK\\SQLEXPRESS01;Initial Catalog=TradingCompany;Integrated Security=True;Encrypt=False;";
        MapperConfiguration config = new MapperConfiguration(c => c.AddMaps(typeof(MovieProfile).Assembly));

        [TestMethod]
        public void CreateNewGoods()
        {
            int managerId = 1;
            var goods = new Goods
            {
                name = "New Item",
                price = 100.50,
                manager_id = managerId
            };

            var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
            Goods createdGoods = goodsDal.Create(goods);

            Goods g = GetGoodsByGoodsId(createdGoods.id);
            Assert.IsNotNull(g);
            Assert.AreEqual("New Item", g.name);
            Assert.AreEqual(100.50, g.price);
        }

        [TestMethod]
        public void UpdateGoodsByGoodsId()
        {
            var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
            var goods = goodsDal.GetById(3);
            goods.name = "Updated Item";
            goods.price = 150.75;

            goodsDal.Update(goods.id, goods);
            Goods updatedGoods = GetGoodsByGoodsId(goods.id);

            Assert.IsNotNull(updatedGoods);
            Assert.AreEqual("Updated Item", updatedGoods.name);
            Assert.AreEqual(150.75, updatedGoods.price);
        }

        [TestMethod]
        public void DeleteGoodsByGoodsId()
        {
            var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
            int goodsIdToDelete = 2;
            var deletedGoods = goodsDal.Delete(goodsIdToDelete);

            Goods g = GetGoodsByGoodsId(goodsIdToDelete);
            Assert.IsNull(g);
        }

        [TestMethod]
        public void GetAllGoods()
        {
            var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
            var goods = goodsDal.GetAll();

            Assert.IsNotNull(goods);
            Assert.IsTrue(goods.Count > 0);
        }

        public Goods GetGoodsByGoodsId(int goodsId)
        {
            var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
            return goodsDal.GetById(goodsId);
        }

        [TestMethod]
        public void GetGoodsById()
        {
            var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
            var goods = goodsDal.GetById(3);

            Assert.IsNotNull(goods);
            Assert.AreEqual(3, goods.id);
        }
    }

}
