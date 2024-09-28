using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IGoods
    {
        List<Goods> GetAll();
        Goods GetById(int id);

        Goods Create(Goods goods);
        Goods Update(int id, Goods goods);
        Goods Delete(int id);
    }
}
