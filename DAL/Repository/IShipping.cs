using DTO.Entity;

namespace DAL.Repository
{
    public interface IShipping
    {
        List<Shipping> GetAll();
        Shipping GetById(int id);
        Shipping Create(Shipping shipping);
        Shipping Update(int id, Shipping shipping);
        Shipping Delete(int id);
        List<Shipping> GetAllByStatus(string status);
        List<Shipping> GetShippingsByGoodsId(int goodsId);
        List<Shipping> GetShippingsByGoodsIdAndStatusNotAppreved(int goodsId);
    }
}
