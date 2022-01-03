using DDB2DA_HFT_2021221.Data;
using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Models;
using DDB2DA_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Test
{
    [TestFixture]
    public class NonCrudTests
    {

        //public IEnumerable<Team> GetPointsFromDrivers();

        //public IEnumerable<Driver> GetDriversFromTeam(int teamId);

        //public IEnumerable<Team> GetAllOutTeams();

        //public IEnumerable<Team> GetTeamsWhoSkippedGP();

        //public IEnumerable<GrandPrix> GetDriverRaces(int driverId);


        Mock<IDriverRepository> driverRepo;
        Mock<IGrandPrixRepository> gpRepo;
        Mock<ITeamRepository> teamRepo;

        List<Team> GetPointsFromDriversResult;

        private QueryLogic TestGetPointsFromDriversMock()
        {
            teamRepo = new Mock<ITeamRepository>();
            driverRepo = new Mock<IDriverRepository>();
            gpRepo = new Mock<IGrandPrixRepository>();



            Team mercedes = new Team() { Id = 1, Name = "Mercedes", Points = 500, Drivers = new List<Driver> { } };
            Team redbull = new Team() { Id = 2, Name = "Red Bull Racing Honda", Points = 390, Drivers = new List<Driver> { } };
            Team mclaren = new Team() { Id = 3, Name = "McLaren Mercedes", Points = 240, Drivers = new List<Driver> { } };

            Driver ver = new Driver() { Id = 33, ShortName = "VER", FirstName = "Max", LastName = "Verstappen", Points = 262.5, TeamId = redbull.Id, Nationality = "NED" };
            Driver ham = new Driver() { Id = 44, ShortName = "HAM", FirstName = "Lewis", LastName = "Hamilton", Points = 256.5, TeamId = mercedes.Id, Nationality = "GBR" };
            Driver bot = new Driver() { Id = 77, ShortName = "BOT", FirstName = "Valtteri", LastName = "Bottas", Points = 177, TeamId = mercedes.Id, Nationality = "FIN" };
            Driver nor = new Driver() { Id = 4, ShortName = "NOR", FirstName = "Lando", LastName = "Norris", Points = 145, TeamId = mclaren.Id, Nationality = "GBR" };
            Driver per = new Driver() { Id = 11, ShortName = "PER", FirstName = "Sergio", LastName = "Perez", Points = 135, TeamId = redbull.Id, Nationality = "MEX" };

            mercedes.Drivers.Add(ham); mercedes.Drivers.Add(bot);
            redbull.Drivers.Add(ver); redbull.Drivers.Add(per);
            mclaren.Drivers.Add(nor);

            List<Team> teams = new List<Team>()
            {
                mercedes,redbull,mclaren
            };

            List<Driver> drivers = new List<Driver>()
            {
                ver,ham,bot,nor,per
            };

            GetPointsFromDriversResult = new List<Team>()
            {
                 new Team() { Id = 1, Name = "Mercedes", Points = 433.5 },
                 new Team() { Id = 2, Name = "Red Bull Racing Honda", Points = 397.5 },
                 new Team() { Id = 3, Name = "McLaren Mercedes", Points = 145 }
            };

            driverRepo.Setup(x => x.ReadAll()).Returns(drivers.AsQueryable());
            teamRepo.Setup(x => x.ReadAll()).Returns(teams.AsQueryable());
            QueryLogic logic = new QueryLogic(driverRepo.Object, teamRepo.Object, gpRepo.Object);

            return logic;
        }

        [Test]
        public void TestGetPointsFromDrivers()
        {
            var logic = TestGetPointsFromDriversMock();

            Assert.That(logic.GetPointsFromDrivers().Select(x => x.Points), Is.EquivalentTo(GetPointsFromDriversResult.Select(x => x.Points)));

        }

        [Test]
        public void TestGetDriversFromTeam()
        {
            teamRepo = new Mock<ITeamRepository>();
            driverRepo = new Mock<IDriverRepository>();
            gpRepo = new Mock<IGrandPrixRepository>();

            Team mercedes = new Team() { Id = 1, Name = "Mercedes", Points = 500, Drivers =
                new List<Driver> { 
                new Driver() { Id = 44, ShortName = "HAM", FirstName = "Lewis", LastName = "Hamilton", Points = 256.5, TeamId = 1 , Nationality = "GBR" },
                new Driver() { Id = 77, ShortName = "BOT", FirstName = "Valtteri", LastName = "Bottas", Points = 177, TeamId = 1 , Nationality = "FIN" }
                }
            };

            List<Driver> expectedResult = new List<Driver>
            {
                new Driver() { Id = 44, ShortName = "HAM", FirstName = "Lewis", LastName = "Hamilton", Points = 256.5, TeamId = 1 , Nationality = "GBR" },
                new Driver() { Id = 77, ShortName = "BOT", FirstName = "Valtteri", LastName = "Bottas", Points = 177, TeamId = 1 , Nationality = "FIN" }
            };

            teamRepo.Setup(x => x.ReadOne(1)).Returns(mercedes);

            QueryLogic logic = new QueryLogic(driverRepo.Object, teamRepo.Object, gpRepo.Object);

            var result = logic.GetDriversFromTeam(1);

            Assert.That(result.Select(x => x.Id),Is.EquivalentTo(expectedResult.Select(x => x.Id)));

        }
        private QueryLogic TestGetAllOutTeamsMock()
        {
            F1DbContext context = new F1DbContext();

            teamRepo = new Mock<ITeamRepository>();
            driverRepo = new Mock<IDriverRepository>();
            gpRepo = new Mock<IGrandPrixRepository>();

            teamRepo.Setup(x => x.ReadAll()).Returns(context.Team);
            gpRepo.Setup(x => x.ReadAll()).Returns(context.GrandPrix);

            QueryLogic logic = new QueryLogic(driverRepo.Object, teamRepo.Object, gpRepo.Object);

            return logic;
        }


        [Test]
        public void TestGetAllOutTeams()
        {
            QueryLogic logic = TestGetAllOutTeamsMock();

            IEnumerable<Team> result = logic.GetAllOutTeams();

            Team mercedes = new Team() { Id = 1, Name = "Mercedes", Points = 433.5 };
            Team redbull = new Team() { Id = 2, Name = "Red Bull Racing Honda", Points = 397.5 };
            Team mclaren = new Team() { Id = 3, Name = "McLaren Mercedes", Points = 240 };
            Team ferrari = new Team() { Id = 4, Name = "Ferrari", Points = 232.5 };
            Team alpine = new Team() { Id = 5, Name = "Alpine Renault", Points = 104 };
            Team alphatauri = new Team() { Id = 6, Name = "Alphatauri Honda", Points = 92 };
            Team astonmartin = new Team() { Id = 7, Name = "Aston Martin Mercedes", Points = 61 };

            List<Team> expected = new List<Team> { mercedes, redbull, mclaren, ferrari, alpine, alphatauri, astonmartin };

            Assert.That(result.Select(x => x.Name), Is.EquivalentTo(expected.Select(x => x.Name)));

        }

        private QueryLogic TestGetTeamsWhoSkippedGPMock()
        {
            F1DbContext context = new F1DbContext();

            teamRepo = new Mock<ITeamRepository>();
            driverRepo = new Mock<IDriverRepository>();
            gpRepo = new Mock<IGrandPrixRepository>();

            teamRepo.Setup(x => x.ReadAll()).Returns(context.Team);
            gpRepo.Setup(x => x.ReadAll()).Returns(context.GrandPrix);

            QueryLogic logic = new QueryLogic(driverRepo.Object, teamRepo.Object, gpRepo.Object);

            return logic;
        }

        [Test]
        public void TestGetTeamsWhoSkippedGP()
        {
            QueryLogic logic = TestGetTeamsWhoSkippedGPMock();

            IEnumerable<Team> result = logic.GetTeamsWhoSkippedGP();

            Team williams = new Team() { Id = 8, Name = "Williams Mercedes", Points = 23 };
            Team alfaromeo = new Team() { Id = 9, Name = "Alfa Romeo Racing Ferrari", Points = 7 };
            Team haas = new Team() { Id = 10, Name = "Haas Ferrari", Points = 0 };

            List<Team> expected = new List<Team> { williams, alfaromeo, haas };

            Assert.That(result.Select(x => x.Name), Is.EquivalentTo(expected.Select(x => x.Name)));

        }

        private QueryLogic TestGetDriverRacesMock()
        {
            F1DbContext context = new F1DbContext();

            teamRepo = new Mock<ITeamRepository>();
            driverRepo = new Mock<IDriverRepository>();
            gpRepo = new Mock<IGrandPrixRepository>();

            teamRepo.Setup(x => x.ReadAll()).Returns(context.Team);
            gpRepo.Setup(x => x.ReadAll()).Returns(context.GrandPrix);
            driverRepo.Setup(x => x.ReadAll()).Returns(context.Drivers);
            driverRepo.Setup(x => x.ReadOne(It.IsAny<int>())).Returns(context.Drivers.Find(47));


            QueryLogic logic = new QueryLogic(driverRepo.Object, teamRepo.Object, gpRepo.Object);

            return logic;
        }

        [Test]
        public void TestGetDriverRaces()
        {
            QueryLogic logic = TestGetDriverRacesMock();

           
            GrandPrix emil = new GrandPrix() { Id = 2, Name = "Emilia Romagna Grand Prix", Date = new DateTime(2021, 04, 18), Track = "Autodromo Enzo e Dino Ferrari" };                      
            GrandPrix mon = new GrandPrix() { Id = 5, Name = "Monaco GP", Date = new DateTime(2021, 05, 23), Track = "Circuit de Monaco" };          
            GrandPrix fre = new GrandPrix() { Id = 7, Name = "French GP", Date = new DateTime(2021, 06, 20), Track = "Circuit Paul Ricard" };
            GrandPrix ste = new GrandPrix() { Id = 8, Name = "Steiermark GP", Date = new DateTime(2021, 06, 27), Track = "Red Bull Ring" };
            GrandPrix aus = new GrandPrix() { Id = 9, Name = "Austrian GP", Date = new DateTime(2021, 07, 04), Track = "Red Bull Ring" };
            GrandPrix brt = new GrandPrix() { Id = 10, Name = "British GP", Date = new DateTime(2021, 07, 18), Track = "Silverstone Circuit" };
            GrandPrix hun = new GrandPrix() { Id = 11, Name = "Hungarian GP", Date = new DateTime(2021, 08, 1), Track = "Hungaroring" };

            List<GrandPrix> expected = new List<GrandPrix> { emil, mon, fre, ste, aus, brt, hun };

            IEnumerable<GrandPrix> result = logic.GetDriverRaces(47);

            Assert.That(result.Select(x => x.Name), Is.EquivalentTo(expected.Select(x => x.Name)));


        }

    }
}
