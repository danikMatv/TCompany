using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUsers
    {
        Users login(string username, string password);
        List<Users> GetAll();
        Users GetById(int id);
        Users Create(Users user);
        Users Update(int id, Users user);
        Users Delete(int id);
    }
}
