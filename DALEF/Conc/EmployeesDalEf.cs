using AutoMapper;
using DALEF.Models;
using DAL.Repository;
using DTO.Entity;
using DALEF.Ct;

namespace DALEF.Conc
{
    public class EmployeesDalEf : IEmployees
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public EmployeesDalEf(string connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        public Employees Create(Employees employee)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                Console.WriteLine(employee.last_Name.ToString());
                var tblEmployee = _mapper.Map<TblEmployees>(employee);
                context.Employeess.Add(tblEmployee);
                context.SaveChanges();

                employee.id = tblEmployee.id;
                return employee;
            }
        }

        public List<Employees> GetAll()
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblEmployees = context.Employeess.ToList();
                return _mapper.Map<List<Employees>>(tblEmployees);
            }
        }



        public Employees GetById(int id)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblEmployee = context.Employeess.FirstOrDefault(e => e.id == id);
                return _mapper.Map<Employees>(tblEmployee);
            }
        }

        public Employees Update(int id, Employees employee)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblEmployee = context.Employeess.FirstOrDefault(e => e.id == id);
                if (tblEmployee != null)
                {
                    _mapper.Map(employee, tblEmployee);
                    context.SaveChanges();
                }
                return employee;
            }
        }

        public Employees Delete(int id)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblEmployee = context.Employeess.FirstOrDefault(e => e.id == id);
                if (tblEmployee != null)
                {
                    context.Employeess.Remove(tblEmployee);
                    context.SaveChanges();
                }
                return _mapper.Map<Employees>(tblEmployee);
            }
        }

        public Employees login(string first_name, string password)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblEmployee = context.Employeess
                    .FirstOrDefault(e => e.first_Name == first_name && e.password == password);

                return _mapper.Map<Employees>(tblEmployee);
            }
        }


    }
}
