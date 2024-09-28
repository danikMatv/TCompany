using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IShipping
    {
        List<Shipping> GetAll();
        Shipping GetById(int id);

        Shipping Create(Shipping shipping);
        Shipping Update(int id, Shipping shipping);
        Shipping Delete(int id);
    }
}
