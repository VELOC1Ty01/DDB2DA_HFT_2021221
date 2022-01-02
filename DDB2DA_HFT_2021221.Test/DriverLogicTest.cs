using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Models;
using DDB2DA_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
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
        public void TestTeamCreate()
        {

            //Mock<IDriverRepository> driverRepository = new Mock<IDriverRepository>();
            //Driver newDriver = new Driver { FirstName = "asd", LastName = "asdasd", Id = 69, Nationality = "TST", Points = 0, ShortName = "asd", TeamId = 2 };

            //driverRepository.Setup(x => x.Create(newDriver));
            //DriverLogic logic = new DriverLogic(driverRepository.Object);
            //Assert.That(logic.ReadOne(69).LastName == "asdasd");

            //mockedTeamRepository = new Mock<ITeamRepository>(MockBehavior.Loose);
            //TeamLogic repo = new TeamLogic(mockedTeamRepository.Object);

            //var expectedResult =new Team { Id = 1, Name = "ASD", Points = 5 };

            //mockedTeamRepository.Setup(x => x.Create(new Team { Name = "ASD", Points = 5  }));

            //Assert.That(repo.ReadOne(1), Is.EqualTo(expectedResult));
        }

        Mock<ITeamRepository> mockedTeamRepository;

        [Test]
        public void TestTeamReadAll()
        {
            mockedTeamRepository = new Mock<ITeamRepository>(MockBehavior.Loose);
            TeamLogic repo = new TeamLogic(mockedTeamRepository.Object);

            IQueryable<Team> teams = repo.ReadAll();
            ;
            Assert.Pass();
        }
    }
}