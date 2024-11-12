using BLL.IServices;
using DAL.Repository;
using DAL.Service;
using DTO.Entity;
using System.Data.SqlClient;

namespace BLL.Services
{
    public class GoodsService : IGoodsService
    {
        private readonly IGoods goodsDal;
        public GoodsService(IGoods goodsDal)
        {
            this.goodsDal = goodsDal ?? throw new ArgumentNullException(nameof(goodsDal));
        }

        public Goods Create(Goods goods)
        {
            return goodsDal.Create(goods);
        }

        public Goods Delete(int id)
        {
            return goodsDal.Delete(id);
        }

        public List<Goods> GetAll()
        {
            return goodsDal.GetAll();
        }

        public Goods GetById(int id)
        {
            return goodsDal.GetById(id);
        }

        public Goods Update(int id, Goods goods)
        {
            return goodsDal.Update(id, goods);
        }
    }
}
