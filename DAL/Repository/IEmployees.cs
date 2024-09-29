using DTO.Entity;

namespace DAL.Repository
{
    public interface IEmployees
    {
        Employees login(string username, string password);
        List<Employees> GetAll();
        Employees GetById(int id);
        Employees Create(Employees employee);
        Employees Update(int id,Employees employee);
        Employees Delete(int id);
        

    }
}
