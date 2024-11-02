using AutoMapper;
using DAL.Repository;
using DALEF.Ct;
using DALEF.Models;
using DTO.Entity;

namespace DALEF.Conc
{
    public class GoodsDalEf : IGoods
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public GoodsDalEf(string connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        public Goods Create(Goods goods)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblGoods = _mapper.Map<TblGoods>(goods);
                context.Goods.Add(tblGoods);
                context.SaveChanges();

                goods.id = tblGoods.id;
                return goods;
            }
        }

        public Goods Delete(int id)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblGoods = context.Goods.FirstOrDefault(e => e.id == id);
                if (tblGoods != null)
                {
                    context.Goods.Remove(tblGoods);
                    context.SaveChanges();
                }
                return _mapper.Map<Goods>(tblGoods);
            }
        }

        public List<Goods> GetAll()
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblGoods = context.Goods.ToList();
                return _mapper.Map<List<Goods>>(tblGoods);
            }
        }

        public List<Goods> GetAllRelatedGoods(int managerId)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblGoods = context.Goods
                    .Where(g => g.manager_id == managerId)
                    .ToList();

                return _mapper.Map<List<Goods>>(tblGoods);
            }
        }

        public Goods GetById(int id)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblGoods = context.Goods.FirstOrDefault(e => e.id == id);
                return _mapper.Map<Goods>(tblGoods);
            }
        }

        public Goods Update(int id, Goods goods)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblGoods = context.Goods.FirstOrDefault(e => e.id == id);
                if (tblGoods != null)
                {
                    _mapper.Map(goods, tblGoods);
                    context.SaveChanges();
                }
                return goods;
            }
        }
    }
}
