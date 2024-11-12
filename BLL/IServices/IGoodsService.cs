using DTO.Entity;

namespace BLL.IServices
{
    public interface IGoodsService
    {
        List<Goods> GetAll();
        Goods GetById(int id);
        Goods Create(Goods goods);
        Goods Update(int id, Goods goods);
        Goods Delete(int id);
    }
}
