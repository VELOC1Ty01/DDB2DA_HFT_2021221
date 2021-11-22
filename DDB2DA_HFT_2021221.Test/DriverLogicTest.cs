using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Models;
using DDB2DA_HFT_2021221.Repository;
using NUnit.Framework;
using System.Linq;

namespace DDB2DA_HFT_2021221.Test
{
    [TestFixture]
    class DriverLogicTest
    {
        class FakeDriverRepository : IDriverRepository
        {
            public void Create(Driver driver)
            {
                throw new System.NotImplementedException();
            }

            public void Delete(int driverId)
            {
                throw new System.NotImplementedException();
            }

            public IQueryable<Driver> ReadAll()
            {
                throw new System.NotImplementedException();
            }

            public Driver ReadOne(int driverId)
            {
                throw new System.NotImplementedException();
            }

            public void Update(Driver driver)
            {
                throw new System.NotImplementedException();
            }
        }

        IDriverLogic logic;

        [SetUp]
        public void Setup()
        {
            logic = new DriverLogic(new FakeDriverRepository());
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}