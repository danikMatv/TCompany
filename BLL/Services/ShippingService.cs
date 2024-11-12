using BLL.IServices;
using DAL.Repository;
using DTO.Entity;
using System.Data.SqlClient;


namespace BLL.Services
{
    public class ShippingService : IShippingSevice
    {
        private readonly IShipping shippingInt;
        public ShippingService(IShipping shippingDal)
        {
            this.shippingInt = shippingDal ?? throw new ArgumentNullException(nameof(shippingDal));
        }

        public Shipping Create(Shipping shipping)
        {
            return shippingInt.Create(shipping);
        }

        public Shipping Delete(int id)
        {
            return shippingInt.Delete(id);
        }

        public List<Shipping> GetAll()
        {
            return shippingInt.GetAll();
        }

        public List<Shipping> GetAllByStatus(string status)
        {
           return shippingInt.GetAllByStatus(status);
        }

        public Shipping GetById(int id)
        {
            return shippingInt.GetById(id);
        }

        public List<Shipping> GetShippingsByGoodsId(int goodsId)
        {
           return shippingInt.GetShippingsByGoodsId(goodsId);
        }

        public List<Shipping> GetShippingsByGoodsIdAndStatusNotAppreved(int goodsId)
        {
            return shippingInt.GetShippingsByGoodsIdAndStatusNotAppreved(goodsId);
        }

        public Shipping Update(int id, Shipping shipping)
        {
            return shippingInt.Update(id, shipping);
        }
    }
}
