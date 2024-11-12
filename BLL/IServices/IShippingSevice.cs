using DTO.Entity;

namespace BLL.IServices
{
    public interface IShippingSevice
    {
        public List<Shipping> GetAllByStatus(string status);
        public Shipping GetById(int id);
    }
}
