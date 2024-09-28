using DTO.Entity;

namespace DAL.Repository
{
    public interface IGoods
    {
        List<Goods> GetAll();
        Goods GetById(int id);
        Goods Create(Goods goods);
        Goods Update(int id, Goods goods);
        Goods Delete(int id);
    }
}
