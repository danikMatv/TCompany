using Xunit;
using Moq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DTO.Entity;
using DALEF.Conc;
using DALEF.Ct;
using DALEF.Models;
using Unit_Test_Project.ForTest;

namespace Unit_Test_Project
{
    public class ShippingTests
    {
        private readonly DbContextOptions<ImdbContext> _dbContextOptions;
        private readonly IMapper _mapper;

        public ShippingTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ImdbContext>()
                .UseInMemoryDatabase(databaseName: "ShippingTestDB")
                .Options;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Shipping, TblShipping>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Create_ShouldAddShippingToDatabase_Transaction()
        {
            using (var context = new ImdbContext(_dbContextOptions))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    
                    var shippingDal = new ShippingDalEf(context, _mapper);
                    var shipping = new Shipping { start_adress = "Start Address", destination = "Destination", goods_id = 1 };

                    
                    var createdShipping = shippingDal.Create(shipping);

                    
                    var foundShipping = context.Shippings.Find(createdShipping.id);
                    Assert.NotNull(foundShipping);
                    Assert.Equal("Start Address", foundShipping.start_adress);
                    Assert.Equal("Destination", foundShipping.destination);

                    
                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public void GetAll_ShouldReturnAllShippings_Transaction()
        {
            using (var context = new ImdbContext(_dbContextOptions))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    
                    var shippingDal = new ShippingDalEf(context, _mapper);
                    shippingDal.Create(new Shipping { start_adress = "Address 1", destination = "Dest 1", goods_id = 1 });
                    shippingDal.Create(new Shipping { start_adress = "Address 2", destination = "Dest 2", goods_id = 2 });

                    
                    var shippingList = shippingDal.GetAll();

                    
                    Assert.Equal(2, shippingList.Count);

                    
                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public void GetById_ShouldReturnCorrectShipping_Transaction()
        {
            using (var context = new ImdbContext(_dbContextOptions))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    
                    var shippingDal = new ShippingDalEf(context, _mapper);
                    var createdShipping = shippingDal.Create(new Shipping { start_adress = "Test Start", destination = "Test Dest", goods_id = 1 });

                    
                    var foundShipping = shippingDal.GetById(createdShipping.id);

                    
                    Assert.NotNull(foundShipping);
                    Assert.Equal("Test Start", foundShipping.start_adress);

                    
                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public void Update_ShouldModifyShipping_Transaction()
        {
            using (var context = new ImdbContext(_dbContextOptions))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    
                    var shippingDal = new ShippingDalEf(context, _mapper);
                    var createdShipping = shippingDal.Create(new Shipping { start_adress = "Old Address", destination = "Old Destination", goods_id = 1 });
                    createdShipping.start_adress = "Updated Address";

                    
                    shippingDal.Update(createdShipping.id, createdShipping);

                    
                    var updatedShipping = shippingDal.GetById(createdShipping.id);
                    Assert.Equal("Updated Address", updatedShipping.start_adress);

                    
                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public void Delete_ShouldRemoveShipping_Transaction()
        {
            using (var context = new ImdbContext(_dbContextOptions))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    
                    var shippingDal = new ShippingDalEf(context, _mapper);
                    var createdShipping = shippingDal.Create(new Shipping { start_adress = "To be deleted", destination = "Dest", goods_id = 1 });

                    
                    var deletedShipping = shippingDal.Delete(createdShipping.id);

                    
                    var foundShipping = context.Shippings.Find(createdShipping.id);
                    Assert.Null(foundShipping);

                    
                    transaction.Rollback();
                }
            }
        }
    }
}

