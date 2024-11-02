using AutoMapper;
using DALEF.Models;
using DAL.Repository;
using DTO.Entity;
using DALEF.Ct;

namespace DALEF.Conc
{
    public class ManagersDalEf : IManagers
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public ManagersDalEf(string connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        public Managers Create(Managers managers)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                Console.WriteLine(managers.last_Name.ToString());
                var tblManager = _mapper.Map<TblManagers>(managers);
                context.Managerss.Add(tblManager);
                context.SaveChanges();

                managers.id = tblManager.id;
                return managers;
            }
        }

        public List<Managers> GetAll()
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblManagers = context.Managerss.ToList();
                return _mapper.Map<List<Managers>>(tblManagers);
            }
        }



        public Managers GetById(int id)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblManager = context.Managerss.FirstOrDefault(e => e.id == id);
                return _mapper.Map<Managers>(tblManager);
            }
        }

        public Managers Update(int id, Managers managers)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblManager = context.Managerss.FirstOrDefault(e => e.id == id);
                if (tblManager != null)
                {
                    _mapper.Map(managers, tblManager);
                    context.SaveChanges();
                }
                return managers;
            }
        }

        public Managers Delete(int id)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblManager = context.Managerss.FirstOrDefault(e => e.id == id);
                if (tblManager != null)
                {
                    context.Managerss.Remove(tblManager);
                    context.SaveChanges();
                }
                return _mapper.Map<Managers>(tblManager);
            }
        }

        public Managers login(string email, string password)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var manager = context.Managerss.FirstOrDefault(m => m.email == email);

                if (manager == null)
                {
                    return null;
                }
                else if (BCrypt.Net.BCrypt.Verify(password, manager.password))
                {
                    return _mapper.Map<Managers>(manager);
                }
                else
                {
                    return null; 
                }
            }
        }


    }
}
