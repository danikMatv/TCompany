using AutoMapper;
using DAL.Repository;
using DALEF.Ct;
using DALEF.Models;
using DTO.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DALEF.Conc
{
    public class GoodsDalEf : IGoods
    {
        private readonly ImdbContext _context;
        private readonly IMapper _mapper;

        public GoodsDalEf(ImdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Goods Create(Goods goods)
        {
            var tblGoods = _mapper.Map<TblGoods>(goods);
            _context.Goods.Add(tblGoods);
            _context.SaveChanges();

            goods.id = tblGoods.id;
            return goods;
        }

        public Goods Delete(int id)
        {
            var tblGoods = _context.Goods.FirstOrDefault(e => e.id == id);
            if (tblGoods != null)
            {
                _context.Goods.Remove(tblGoods);
                _context.SaveChanges();
            }
            return _mapper.Map<Goods>(tblGoods);
        }

        public List<Goods> GetAll()
        {
            var tblGoods = _context.Goods.ToList();
            return _mapper.Map<List<Goods>>(tblGoods);
        }

        public List<Goods> GetAllRelatedGoods(int managerId)
        {
            var tblGoods = _context.Goods
                .Where(g => g.manager_id == managerId)
                .ToList();

            return _mapper.Map<List<Goods>>(tblGoods);
        }

        public Goods GetById(int id)
        {
            var tblGoods = _context.Goods.FirstOrDefault(e => e.id == id);
            return _mapper.Map<Goods>(tblGoods);
        }

        public Goods Update(int id, Goods goods)
        {
            var tblGoods = _context.Goods.FirstOrDefault(e => e.id == id);
            if (tblGoods != null)
            {
                _mapper.Map(goods, tblGoods);
                _context.SaveChanges();
            }
            return goods;
        }
    }
}
