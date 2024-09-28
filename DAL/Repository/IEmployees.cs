using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IEmployees
    {
        List<Employees> GetAll();
        Employees GetById(int id);

        Employees Create(Employees employee);
        Employees Update(int id,Employees employee);
        Employees Delete(int id);
    }
}
