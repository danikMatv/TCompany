using AutoMapper;
using DAL.Repository;
using DALEF.Ct;
using DALEF.Models;
using DTO.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DALEF.Conc
{
    public class ShippingDalEf : IShipping
    {
        private readonly IServiceProvider _serviceProvider;  // Додаємо IServiceProvider для доступу до DI контейнера
        private readonly IMapper _mapper;

        // Замість рядка підключення передаємо IServiceProvider
        public ShippingDalEf(IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }

        // Отримуємо контекст через DI контейнер
        private ImdbContext GetContext()
        {
            var options = _serviceProvider.GetRequiredService<DbContextOptions<R2024Context>>();  // Отримуємо DbContextOptions через DI
            return new ImdbContext(options);  // Створюємо контекст з переданими налаштуваннями
        }

        public List<Shipping> GetShippingsByGoodsId(int goodsId)
        {
            using (var context = GetContext())  // Використовуємо метод GetContext
            {
                var tblShippings = context.Shippings
                                          .Where(s => s.goods_id == goodsId)
                                          .ToList();
                return _mapper.Map<List<Shipping>>(tblShippings);
            }
        }

        public List<Shipping> GetShippingsByGoodsIdAndStatusNotAppreved(int goodsId)
        {
            using (var context = GetContext())  // Використовуємо метод GetContext
            {
                var tblShippings = context.Shippings
                    .Where(s => s.goods_id == goodsId && s.status != "Approved")
                    .ToList();

                return _mapper.Map<List<Shipping>>(tblShippings);
            }
        }

        public Shipping Create(Shipping shipping)
        {
            using (var context = GetContext())  // Використовуємо метод GetContext
            {
                var tblShipping = _mapper.Map<TblShipping>(shipping);
                context.Shippings.Add(tblShipping);
                context.SaveChanges();

                shipping.id = tblShipping.id;
                return shipping;
            }
        }

        public Shipping Delete(int id)
        {
            using (var context = GetContext())  // Використовуємо метод GetContext
            {
                var tblShipping = context.Shippings.FirstOrDefault(e => e.id == id);
                if (tblShipping != null)
                {
                    context.Shippings.Remove(tblShipping);
                    context.SaveChanges();
                }
                return _mapper.Map<Shipping>(tblShipping);
            }
        }

        public List<Shipping> GetAll()
        {
            using (var context = GetContext())  // Використовуємо метод GetContext
            {
                var tblShippings = context.Shippings.ToList();
                return _mapper.Map<List<Shipping>>(tblShippings);
            }
        }

        public List<Shipping> GetAllByStatus(string status)
        {
            using (var context = GetContext())  // Використовуємо метод GetContext
            {
                var tblShippings = context.Shippings
                                          .Where(s => s.status == status)
                                          .ToList();

                return _mapper.Map<List<Shipping>>(tblShippings);
            }
        }

        public Shipping GetById(int id)
        {
            using (var context = GetContext())  // Використовуємо метод GetContext
            {
                var tblShipping = context.Shippings.FirstOrDefault(e => e.id == id);
                return _mapper.Map<Shipping>(tblShipping);
            }
        }

        public Shipping Update(int id, Shipping shipping)
        {
            using (var context = GetContext())  // Використовуємо метод GetContext
            {
                var tblStipping = context.Shippings.FirstOrDefault(e => e.id == id);
                if (tblStipping != null)
                {
                    _mapper.Map(shipping, tblStipping);
                    context.SaveChanges();
                }
                return shipping;
            }
        }
    }
}
