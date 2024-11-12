using Moq;
using BLL.Services;
using DTO.Entity;
using DAL.Repository;

namespace BTestProject2
{
    public class ShippingServiceTest
    {
        [Fact]
        public void GetById_ReturnsCorrectShipping()
        {
            var mockShippingDal = new Mock<IShipping>();
            var expectedShipping = new Shipping { id = 3, status = "Shipped" };
            mockShippingDal.Setup(dal => dal.GetById(3)).Returns(expectedShipping);

            var shippingService = new ShippingService(mockShippingDal.Object);

            var shipping = shippingService.GetById(3);

            Assert.NotNull(shipping);
            Assert.Equal(3, shipping.id);
            Assert.Equal("Shipped", shipping.status);
        }

        [Fact]
        public void Create_CreatesNewShipping()
        {
            var mockShippingDal = new Mock<IShipping>();
            var shippingToCreate = new Shipping { id = 4, status = "Pending" };
            mockShippingDal.Setup(dal => dal.Create(It.IsAny<Shipping>())).Returns(shippingToCreate);

            var shippingService = new ShippingService(mockShippingDal.Object);

            var createdShipping = shippingService.Create(shippingToCreate);

            Assert.NotNull(createdShipping);
            Assert.Equal(4, createdShipping.id);
            Assert.Equal("Pending", createdShipping.status);
        }

        [Fact]
        public void Update_UpdatesExistingShipping()
        {
            var mockShippingDal = new Mock<IShipping>();
            var updatedShipping = new Shipping { id = 3, status = "Delivered" };
            mockShippingDal.Setup(dal => dal.Update(3, It.IsAny<Shipping>())).Returns(updatedShipping);

            var shippingService = new ShippingService(mockShippingDal.Object);

            var result = shippingService.Update(3, updatedShipping);

            Assert.NotNull(result);
            Assert.Equal(3, result.id);
            Assert.Equal("Delivered", result.status);
        }

        [Fact]
        public void Delete_DeletesShipping()
        {
            var mockShippingDal = new Mock<IShipping>();
            var shippingToDelete = new Shipping { id = 3, status = "Shipped" };
            mockShippingDal.Setup(dal => dal.Delete(3)).Returns(shippingToDelete);

            var shippingService = new ShippingService(mockShippingDal.Object);

            var deletedShipping = shippingService.Delete(3);

            Assert.NotNull(deletedShipping);
            Assert.Equal(3, deletedShipping.id);
            Assert.Equal("Shipped", deletedShipping.status);
        }

        [Fact]
        public void GetAll_ReturnsAllShippings()
        {
            var mockShippingDal = new Mock<IShipping>();
            var shippingList = new List<Shipping>
            {
                new Shipping { id = 1, status = "Shipped" },
                new Shipping { id = 2, status = "Pending" }
            };
            mockShippingDal.Setup(dal => dal.GetAll()).Returns(shippingList);

            var shippingService = new ShippingService(mockShippingDal.Object);

            var result = shippingService.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, s => s.status == "Shipped");
            Assert.Contains(result, s => s.status == "Pending");
        }

        [Fact]
        public void GetAllByStatus_ReturnsShippingsWithSpecificStatus()
        {
            var mockShippingDal = new Mock<IShipping>();
            var shippingList = new List<Shipping>
            {
                new Shipping { id = 1, status = "Shipped" },
                new Shipping { id = 2, status = "Shipped" },
                new Shipping { id = 3, status = "Pending" }
            };
            mockShippingDal.Setup(dal => dal.GetAllByStatus("Shipped")).Returns(shippingList.Where(s => s.status == "Shipped").ToList());

            var shippingService = new ShippingService(mockShippingDal.Object);

            var result = shippingService.GetAllByStatus("Shipped");

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.All(result, s => Assert.Equal("Shipped", s.status));
        }

        [Fact]
        public void GetShippingsByGoodsId_ReturnsShippingsForSpecificGoods()
        {
            var mockShippingDal = new Mock<IShipping>();
            var shippingList = new List<Shipping>
            {
                new Shipping { id = 1, goods_id = 1, status = "Shipped" },
                new Shipping { id = 2, goods_id = 1, status = "Pending" },
                new Shipping { id = 3, goods_id = 2, status = "Shipped" }
            };
            mockShippingDal.Setup(dal => dal.GetShippingsByGoodsId(1)).Returns(shippingList.Where(s => s.goods_id == 1).ToList());

            var shippingService = new ShippingService(mockShippingDal.Object);

            var result = shippingService.GetShippingsByGoodsId(1);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.All(result, s => Assert.Equal(1, s.goods_id));
        }

        [Fact]
        public void GetShippingsByGoodsIdAndStatusNotAppreved_ReturnsShippingsForSpecificGoodsAndStatus()
        {
            var mockShippingDal = new Mock<IShipping>();
            var shippingList = new List<Shipping>
            {
                new Shipping { id = 1, goods_id = 1, status = "Shipped" },
                new Shipping { id = 2, goods_id = 1, status = "Pending" },
                new Shipping { id = 3, goods_id = 2, status = "Shipped" }
            };
            mockShippingDal.Setup(dal => dal.GetShippingsByGoodsIdAndStatusNotAppreved(1))
                .Returns(shippingList.Where(s => s.goods_id == 1 && s.status != "Approved").ToList());

            var shippingService = new ShippingService(mockShippingDal.Object);

            var result = shippingService.GetShippingsByGoodsIdAndStatusNotAppreved(1);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.All(result, s => Assert.Equal(1, s.goods_id));
            Assert.All(result, s => Assert.NotEqual("Approved", s.status));
        }
    }
}
