using AutoMapper;
using DALEF.Conc;
using DALEF.Mapping;
using DTO.Entity;
using Xunit;

namespace Unit_Test_Project.Tests
{
    public class EmployeesTests
    {
        string connStr = "Data Source=HP_DANIK\\SQLEXPRESS01;Initial Catalog=TradingCompany;Integrated Security=True;Encrypt=False;";

        MapperConfiguration config = new MapperConfiguration(c => c.AddMaps(typeof(MovieProfile).Assembly));

        [Fact]
        public void GetAllManagers()
        {
            Console.WriteLine("Before creating DAL instance.");
            var employeesDal = new EmployeesDalEf(connStr, config.CreateMapper());
            Console.WriteLine("Before calling GetAll.");
            List<Employees> managers = employeesDal.GetAll();
            Console.WriteLine("After calling GetAll.");

            Assert.Equal(2, managers.Count);
        }

    }
}
