using DTO.Entity;

namespace BLL.IServices
{
    public interface IUserService
    {
        Users login(string username, string password);
        List<Users> GetAll();
        Users GetById(int id);
        Users Create(Users user);
        Users Update(int id, Users user);
        Users Delete(int id);
    }
}
