using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Models;
using DDB2DA_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDB2DA_HFT_2021221.Test
{
    [TestFixture]
    public class DriverLogicTest
    {
        Mock<IDriverRepository> mockedDriverRepository;


        [Test]
        public void TestListByTeamId()
        {
            mockedDriverRepository = new Mock<IDriverRepository>(MockBehavior.Loose);
            DriverLogic logic = new DriverLogic(mockedDriverRepository.Object);

            List<Driver> drivers = new List<Driver>
            {
                new Driver() { Id = 33, ShortName = "VER", FirstName = "Max", LastName = "Verstappen", Points = 262.5, TeamId = 2, Nationality = "NED" },
                new Driver() { Id = 44, ShortName = "HAM", FirstName = "Lewis", LastName = "Hamilton", Points = 256.5, TeamId = 1, Nationality = "GBR" },
                new Driver() { Id = 77, ShortName = "BOT", FirstName = "Valtteri", LastName = "Bottas", Points = 177, TeamId = 4, Nationality = "FIN" },
                new Driver() { Id = 4, ShortName = "NOR", FirstName = "Lando", LastName = "Norris", Points = 145, TeamId = 3, Nationality = "GBR" },
                new Driver() { Id = 11, ShortName = "PER", FirstName = "Sergio", LastName = "Perez", Points = 135, TeamId = 2, Nationality = "MEX" }
            };

            List<Driver> expectedResult = new List<Driver> { drivers[0], drivers[4] };

            mockedDriverRepository.Setup(x => x.ReadAll()).Returns(drivers.AsQueryable());

            var result = logic.ReadAll().Where(x => x.TeamId == 2);

            Assert.That(result, Is.EquivalentTo(expectedResult));
            
        }


        [Test]
        public void TestCreateDriverWithAlreadyExistingId()
        {
            mockedDriverRepository = new Mock<IDriverRepository>(MockBehavior.Loose);
            DriverLogic logic = new DriverLogic(mockedDriverRepository.Object);

            Driver driver = new Driver
            {
                Id = 1,
                FirstName = "asd",
                LastName = "kek",
                ShortName = "KEK",
                Nationality = "LOL",
                Points = 0,
                TeamId = 2,
            };

            mockedDriverRepository.Setup(x => x.Create(driver));

            Assert.That(() => logic.Create(driver), Throws.Nothing);
        }

        [Test]
        public void TestCreateWithoutShortName()
        {
            mockedDriverRepository = new Mock<IDriverRepository>(MockBehavior.Loose);
            DriverLogic logic = new DriverLogic(mockedDriverRepository.Object);
            Driver driver = new Driver
            {
                Id = 11,
                FirstName = "asd",
                LastName = "kek",
                Nationality = "LOL",
                Points = 0,
                TeamId = 2,
            };

            Assert.Throws(typeof(NullReferenceException),() => logic.Create(driver));
        }

        [Test]
        public void TestCreateWithExistingShortName()
        {
            mockedDriverRepository = new Mock<IDriverRepository>(MockBehavior.Loose);
            DriverLogic logic = new DriverLogic(mockedDriverRepository.Object);

            List<Driver> drivers = new List<Driver>
            {
                new Driver
                {
                    Id = 1, FirstName = "asd", LastName = "kek",ShortName = "123", Nationality = "LOL", Points = 0, TeamId = 1
                },
                new Driver
                {
                    Id = 2, FirstName = "asd", LastName = "kek",ShortName = "456", Nationality = "LOL", Points = 0, TeamId = 2
                },
                new Driver
                {
                    Id = 3, FirstName = "asd", LastName = "kek",ShortName = "789", Nationality = "LOL", Points = 0, TeamId = 3
                }
            };

            mockedDriverRepository.Setup(x => x.ReadAll()).Returns(drivers.AsQueryable());

            Driver sameShortName = new Driver { Id = 4, FirstName = "asd", LastName = "kek", ShortName = "123", Nationality = "LOL", Points = 0, TeamId = 2 };

            Assert.Throws(typeof(InvalidOperationException), () => logic.Create(sameShortName));

        }

        [Test]
        public void TestDeleteWithNonexistingId()
        {
            mockedDriverRepository = new Mock<IDriverRepository>(MockBehavior.Loose);
            DriverLogic logic = new DriverLogic(mockedDriverRepository.Object);

            List<Driver> drivers = new List<Driver>
            {
                new Driver
                {
                    Id = 1, FirstName = "asd", LastName = "kek",ShortName = "123", Nationality = "LOL", Points = 0, TeamId = 2,
                },
                new Driver
                {
                    Id = 2, FirstName = "asd", LastName = "kek",ShortName = "456", Nationality = "LOL", Points = 0, TeamId = 2,
                },
                new Driver
                {
                    Id = 3, FirstName = "asd", LastName = "kek",ShortName = "789", Nationality = "LOL", Points = 0, TeamId = 2,
                },
            };

            mockedDriverRepository.Setup(x => x.ReadAll()).Returns(drivers.AsQueryable());

            Assert.Throws(typeof(NullReferenceException), () => logic.Delete(5));
        }
    }
}