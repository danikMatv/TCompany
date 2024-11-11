using AutoMapper;
using DAL.Repository;
using DALEF.Conc;
using DALEF.Ct;
using DALEF.Mapping;
using DALEF.Models;
using DTO.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_Project.Tests
{
    [TestClass]
    public class ManagersTests
    {
        private readonly string connStr = "Data Source=HP_DANIK\\SQLEXPRESS01;Initial Catalog=TradingCompany;Integrated Security=True;Encrypt=False;";
        private readonly MapperConfiguration config = new MapperConfiguration(c => c.AddMaps(typeof(MovieProfile).Assembly));

        [TestMethod]
        public void GetAllManagers()
        {
            var manager = new Managers
            {
                first_Name = "5555555555555555555",
                last_Name = "5555555555555555555",
                password = "5555555555555555555",
                phone_Number = "5555555555555555555",
                email = "5555555555555555555@gmail.com"
            };

            var employeesDal = new ManagersDalEf(connStr, config.CreateMapper());
            Managers createdManager = employeesDal.Create(manager);
            var managers = employeesDal.GetAll();
            Assert.IsNotNull(managers);
            Assert.AreEqual("5555555555555555555", managers.Last().first_Name);
            employeesDal.Delete(createdManager.id);
        }

        private Managers GetManagerByManagerId(int managerId)
        {
            var employeesDal = new ManagersDalEf(connStr, config.CreateMapper());
            return employeesDal.GetById(managerId);
        }

        [TestMethod]
        public void UpdateManagerByManagerId()
        {
            var manager = new Managers
            {
                first_Name = "4444444444444",
                last_Name = "4444444444444",
                password = "4444444444444",
                phone_Number = "4444444444444",
                email = "4444444444444@gmail.com"
            };

            var employeesDal = new ManagersDalEf(connStr, config.CreateMapper());
            Managers createdManager = employeesDal.Create(manager);

            createdManager.first_Name = "firstName";
            createdManager.last_Name = "lastName";
            createdManager.phone_Number = "111111111111111";
            createdManager.email = "emasasdasdil";

            employeesDal.Update(7, createdManager);
            var updatedManager = GetManagerByManagerId(createdManager.id);

            Assert.IsNotNull(updatedManager);
            Assert.AreEqual("11111111111111", updatedManager.phone_Number);
            Assert.AreEqual("firstName", updatedManager.first_Name);
            employeesDal.Delete(updatedManager.id);
        }

        [TestMethod]
        public void DeleteManagerByManagerId()
        {
            var manager = new Managers
            {
                first_Name = "22222222222222222222",
                last_Name = "22222222222222222222",
                password = "22222222222222222222",
                phone_Number = "22222222222222222222",
                email = "22222222222222222222@gmail.com"
            };

            var employeesDal = new ManagersDalEf(connStr, config.CreateMapper());
            Managers createdManager = employeesDal.Create(manager);
            Managers retrievedManager = GetManagerByManagerId(createdManager.id);
            int managerId = retrievedManager.id;
            var deletedManager = employeesDal.Delete(managerId);
            var resultManager = GetManagerByManagerId(managerId);

            Assert.IsNull(resultManager);
            Assert.IsNotNull(deletedManager);
        }

        [TestMethod]
        public void CreateNewManager()
        {
            var manager = new Managers
            {
                first_Name = "3333333333333333",
                last_Name = "3333333333333333",
                password = "3333333333333333",
                phone_Number = "3333333333333333",
                email = "3333333333333333"
            };

            var employeesDal = new ManagersDalEf(connStr, config.CreateMapper());
            Managers createdManager = employeesDal.Create(manager);
            Managers retrievedManager = GetManagerByManagerId(createdManager.id);

            Assert.IsNotNull(retrievedManager);
            Assert.AreEqual("3333333333333333", retrievedManager.first_Name);
            employeesDal.Delete(retrievedManager.id);
        }
    }
}
