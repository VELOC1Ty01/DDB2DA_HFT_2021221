using ConsoleTools;
using DDB2DA_HFT_2021221.Models;
using System;
using System.Linq;

namespace DDB2DA_HFT_2021221.Client
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Run()
        {
            System.Threading.Thread.Sleep(3000);

            RestService rest = new RestService("http://localhost:21304");


            ConsoleMenu startMenu = new ConsoleMenu();
            ConsoleMenu crudMenu = new ConsoleMenu();
            ConsoleMenu queryMenu = new ConsoleMenu();

            startMenu
                .Add("Query methods", () => queryMenu.Show())
                .Add("CRUD methods", () => crudMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            queryMenu
                .Add("Get Teams Who Were Present In All Races", () => GetQuery<Team>(rest, "GetAllOutTeams"))
                .Add("GetTeamsWhoSkippedGP", () => GetQuery<Team>(rest, "GetTeamsWhoSkippedGP"))
                .Add("GetPointsFromDrivers", () => GetQuery<Team>(rest, "GetPointsFromDrivers"))
                .Add("GetDriversFromTeam (Mercedes)", () => GetQuery<Driver>(rest, "GetDriversFromTeam"))
                .Add("Get Races where Driver33 was Present", () => GetQuery<GrandPrix>(rest, "GetDriverRaces"))
                .Add("Back", ConsoleMenu.Close);

            crudMenu
                .Add("Test CRUD for Driver", () => DriverCRUDs(rest))
                .Add("Test CRUD for Team", () => TeamCRUDs(rest))
                .Add("Test CRUD for GrandPrix", () => GpCRUDs(rest))
                .Add("Back", ConsoleMenu.Close); ;

            startMenu.Show();
        }

        static void GetQuery<T>(RestService rest, string query)
        {
            var list = rest.Get<T>($"query/{query.ToLower()}");

            foreach (var item in list)
                  Console.WriteLine(item.ToString());

            Console.ReadLine();
        }

        static void DriverCRUDs(RestService rest)
        {
            Console.WriteLine("Presenting CRUD methods on a new Driver");

            Driver driver = new Driver
            {
                FirstName = "Michael",
                LastName = "Schumacher",
                Nationality = "GER",
                Points = 0,
                ShortName = "SCM",
                TeamId = 4
            };

            rest.Post<Driver>(driver, "driver");
            Console.WriteLine("New driver registered.");
            
            int driverId = 47;
            Driver temp = rest.Get<Driver>(driverId,"driver");
            rest.Put<Driver>(new Driver()
            {
                FirstName = "Mick",
                LastName = temp.LastName,
                Nationality = temp.Nationality,
                ShortName = temp.ShortName,
                Points = 8,
                TeamId = 10,
                Id = 47

            }, "driver");
            Console.WriteLine("Driver is updated.");

            rest.Delete(driverId, "driver");
            Console.WriteLine("Driver deleted");

            Driver verstappen = rest.Get<Driver>(33, "driver");
            Console.WriteLine($"Driver with racing number 33: {verstappen.FirstName} {verstappen.LastName}");
            Console.WriteLine();

            Console.WriteLine("All drivers:");
            var drivers = rest.Get<Driver>("driver");
            foreach (Driver drvr in drivers)
            {
                Console.WriteLine(drvr.Id + " " + drvr.FirstName + " " + drvr.LastName);
            }
            Console.ReadLine();
        }

        static void TeamCRUDs(RestService rest)
        {
            Console.WriteLine("Presenting CRUD methods on a new Team\n");

            Team team = new Team()
            {
                Name = "Porsche",
                Points = 6
            };

            rest.Post<Team>(team, "team");
            Console.WriteLine("New team registered.\n");

            int teamId = rest.Get<Team>("team").Max(x => x.Id);
            Team temp = rest.Get<Team>(teamId, "team");
            rest.Put<Team>(new Team()
            {
                Id = temp.Id,
                TeamGPs = temp.TeamGPs,
                Points = temp.Points + 5,
                Name = "BraumGP - updated"
            }, "team");
            Console.WriteLine("Team is updated.\n");

            rest.Delete(teamId, "team");
            Console.WriteLine("Team deleted\n");

            Team haaas = rest.Get<Team>(10, "team");
            Console.WriteLine($"Team with id 10: {haaas.Name}\n");

            var teams = rest.Get<Team>("team");
            foreach (Team tm in teams)
            {
                Console.WriteLine(tm.ToString());
            }
            Console.ReadLine();
        }

        static void GpCRUDs(RestService rest)
        {
            Console.WriteLine("Presenting CRUD methods on a new GrandPrix");

            GrandPrix gp = new GrandPrix()
            {
                Name = "Magyar nagydij",
                Date = DateTime.Today,
                Track = "Hungaroring"
            };

            rest.Post<GrandPrix>(gp, "grandprix");
            Console.WriteLine("New GrandPrix registered.");

            int gpId = rest.Get<GrandPrix>("grandprix").Count - 1;
            GrandPrix temp = rest.Get<GrandPrix>(gpId, "grandprix");
            rest.Put<GrandPrix>(new GrandPrix()
            {
                Id = temp.Id,
                Track = "Kakucsring",
                Name = temp.Name,
                Date = temp.Date
            }, "grandprix");
            Console.WriteLine("GP is updated.");

            var gps = rest.Get<GrandPrix>("grandprix");
            foreach (GrandPrix gap in gps)
            {
                Console.WriteLine(gap.ToString());
            }

            rest.Delete(gpId, "grandprix");
            Console.WriteLine("GP deleted");

            GrandPrix idk = rest.Get<GrandPrix>(10, "grandprix");
            Console.WriteLine($"GP with id 10: {idk.Name}");

            Console.ReadLine();
        }


    }
}
