using DTO.Entity;

namespace BLL.IServices
{
    public interface IManagersService
    {
        public Managers login(string username, string password);
    }
}
