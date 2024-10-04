using AutoMapper;
using DAL.Repository;
using DALEF.Conc;
using DALEF.Mapping;
using DTO.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Unit_Test_Project.Tests
{
    [TestClass]
    public class EmployeesTests
    {
        string connStr = "Data Source=HP_DANIK\\SQLEXPRESS01;Initial Catalog=TradingCompany;Integrated Security=True;Encrypt=False;";
        MapperConfiguration config = new MapperConfiguration(c => c.AddMaps(typeof(MovieProfile).Assembly));
        [TestMethod]
        public void GetAllManagers()
        {
            var employeesDal = new EmployeesDalEf(connStr, config.CreateMapper());
            var managers = employeesDal.GetAll();
            Assert.IsNotNull(managers);
            Assert.AreEqual("ewsd", managers[1].first_Name);
        }
        public Employees GetManagerByManagerId(int managerId)
        {
            var employeesDal = new EmployeesDalEf(connStr, config.CreateMapper());
            var manager = employeesDal.GetById(managerId);
            return manager;
        }
        [TestMethod]
        public void UpdateManagerByManagerId()
        {
            var employeesDal = new EmployeesDalEf(connStr, config.CreateMapper());
            var manager = employeesDal.GetById(7);
            manager.first_Name = "firstName";
            manager.last_Name = "lastName";
            manager.phone_Number = "pNumber";
            manager.position = "position";
            manager.email = "email";
            employeesDal.Update(7, manager);
            Employees e = GetManagerByManagerId(manager.id);
            Assert.IsNotNull(e);
            Assert.AreEqual("pNumber", e.phone_Number);
        }
        [TestMethod]
        public void DeleteManagerByManagerId()
        {
            if (int.TryParse(Console.ReadLine(), out int managerId))
            {
                managerId = 10;
                var employeesDal = new EmployeesDalEf(connStr, config.CreateMapper());
                var deletedManager = employeesDal.Delete(managerId);
                Employees em = GetManagerByManagerId(managerId);
                Assert.IsNotNull(em);
            }
        }
        [TestMethod]
        public void CreateNewManager()
        {
            var manager = new Employees
            {
                first_Name = "Alan",
                last_Name = "lastName",
                password = "pass",
                phone_Number = "12322023",
                position = "position",
                email = "email"
            };
            var employeesDal = new EmployeesDalEf(connStr, config.CreateMapper());
            Employees employees = employeesDal.Create(manager);
            Employees em = GetManagerByManagerId(employees.id);
            Assert.IsNotNull(em);
            Assert.AreEqual("Alan", em.first_Name);
        }
    }
}
