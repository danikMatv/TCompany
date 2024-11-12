using DTO.Entity;

namespace DAL.Repository
{
    public interface IManagers
    {
        List<Managers> GetAll();
        Managers GetById(int id);
        Managers Create(Managers managers);
        Managers Update(int id,Managers managers);
        Managers Delete(int id);
        

    }
}
