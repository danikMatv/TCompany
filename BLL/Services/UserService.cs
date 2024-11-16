using BLL.IServices;
using DAL.Repository;
using DTO.Entity;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUsers _users;

        public UserService(IUsers users)
        {
            _users = users;
        }

        public Users Create(Users user)
        {
            return _users.Create(user);
        }

        public Users Delete(int id)
        {
            return _users.Delete(id);
        }

        public List<Users> GetAll()
        {
            return _users.GetAll();
        }

        public Users GetById(int id)
        {
            return _users.GetById(id);
        }

        public Users login(string username, string password)
        {
            return _users.login(username, password);
        }

        public Users Update(int id, Users user)
        {
            return _users.Update(id, user);
        }
    }
}
