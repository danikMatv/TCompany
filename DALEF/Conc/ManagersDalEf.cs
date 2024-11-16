using AutoMapper;
using DALEF.Models;
using DAL.Repository;
using DTO.Entity;
using DALEF.Ct;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DALEF.Conc
{
    public class ManagersDalEf : IManagers
    {
        private readonly IServiceProvider _serviceProvider;  // Додаємо IServiceProvider для доступу до DI контейнера
        private readonly IMapper _mapper;

        // Замість рядка передаємо IServiceProvider
        public ManagersDalEf(IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }

        private ImdbContext GetContext()
        {
            var options = _serviceProvider.GetRequiredService<DbContextOptions<R2024Context>>();  // Отримуємо DbContextOptions через DI
            return new ImdbContext(options);  // Створюємо контекст з переданими налаштуваннями
        }

        public Managers Create(Managers managers)
        {
            using (var context = GetContext())  // Використовуємо метод GetContext для отримання ImdbContext
            {
                var tblManager = _mapper.Map<TblManagers>(managers);
                context.Managerss.Add(tblManager);
                context.SaveChanges();

                managers.id = tblManager.id;
                return managers;
            }
        }

        public List<Managers> GetAll()
        {
            using (var context = GetContext())  // Використовуємо метод GetContext
            {
                var tblManagers = context.Managerss.ToList();
                return _mapper.Map<List<Managers>>(tblManagers);
            }
        }

        public Managers GetById(int id)
        {
            using (var context = GetContext())  // Використовуємо метод GetContext
            {
                var tblManager = context.Managerss.FirstOrDefault(e => e.id == id);
                return _mapper.Map<Managers>(tblManager);
            }
        }

        public Managers Update(int id, Managers managers)
        {
            using (var context = GetContext())  // Використовуємо метод GetContext
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
            using (var context = GetContext())  // Використовуємо метод GetContext
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
            using (var context = GetContext())  // Використовуємо метод GetContext
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
