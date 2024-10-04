using DALEF.Conc;
using AutoMapper;
using DTO.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DALEF.Mapping;

namespace Unit_Test_Project.Tests
{
    [TestClass]
    public class ShippingTests
    {
        string connStr = "Data Source=HP_DANIK\\SQLEXPRESS01;Initial Catalog=TradingCompany;Integrated Security=True;Encrypt=False;";
        MapperConfiguration config = new MapperConfiguration(c => c.AddMaps(typeof(MovieProfile).Assembly));

        [TestMethod]
        public void CreateNewShipping()
        {
            var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
            var shipping = new Shipping
            {
                start_adress = "Start",
                destination = "Destination",
                goods_id = 4
            };

            Shipping createdShipping = shippingDal.Create(shipping);
            Shipping s = GetShippingByShippingId(createdShipping.id);

            Assert.IsNotNull(s);
            Assert.AreEqual("Start", s.start_adress);
            Assert.AreEqual("Destination", s.destination);
        }

        [TestMethod]
        public void UpdateShippingByShippingId()
        {
            var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
            var shipping = shippingDal.GetById(10);
            shipping.start_adress = "Updated Start";
            shipping.destination = "Updated Destination";

            shippingDal.Update(shipping.id, shipping);
            Shipping updatedShipping = GetShippingByShippingId(shipping.id);

            Assert.IsNotNull(updatedShipping);
            Assert.AreEqual("Updated Start", updatedShipping.start_adress);
            Assert.AreEqual("Updated Destination", updatedShipping.destination);
        }

        [TestMethod]
        public void DeleteShippingByShippingId()
        {
            var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
            int shippingIdToDelete = 2;
            var deletedShipping = shippingDal.Delete(shippingIdToDelete);

            Shipping s = GetShippingByShippingId(shippingIdToDelete);
            Assert.IsNull(s);
        }

        [TestMethod]
        public void GetAllShipping()
        {
            var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
            var shippings = shippingDal.GetAll();

            Assert.IsNotNull(shippings);
            Assert.IsTrue(shippings.Count > 0);
        }

        public Shipping GetShippingByShippingId(int shippingId)
        {
            var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
            return shippingDal.GetById(shippingId);
        }

        [TestMethod]
        public void GetShippingById()
        {
            var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
            var shipping = shippingDal.GetById(10);

            Assert.IsNotNull(shipping);
            Assert.AreEqual(10, shipping.id);
        }
    }
}
