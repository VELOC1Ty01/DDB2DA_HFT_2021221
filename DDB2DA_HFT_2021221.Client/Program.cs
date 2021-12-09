using DDB2DA_HFT_2021221.Models;
using System;
using System.Linq;

namespace DDB2DA_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            //F1DbContext context = new F1DbContext();

            //Team redbull = context.Team.Where(x => x.Drivers.Any(u => u.Id == 4)).FirstOrDefault();

            //Console.WriteLine(redbull.Name);

            System.Threading.Thread.Sleep(5000);

            try
            {
                RestService rest = new RestService("http://localhost:21304");
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }



        }

        static void GetQuery<T>(RestService rest, string query)
        {
            var list = rest.Get<T>($"query/{query.ToLower()}");

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        static void DriverCRUDs(RestService rest)
        {
            Console.WriteLine("Presenting CRUD methods on a new Driver");

            Driver driver = new Driver
            {
                FirstName = "Michael",
                LastName = "Schumacher",
                Id = 7,
                Nationality = "GER",
                Points = 0,
                ShortName = "SCM",
                TeamId = 4
            };

            rest.Post<Driver>(driver, "driver");
            Console.WriteLine("New driver registered.");

            int driverId = rest.Get<Driver>("driver").Count - 1;
            Driver temp = rest.Get<Driver>(driverId, "driver");
            rest.Put<Driver>(new Driver()
            {
                FirstName = "Mick",
                LastName = temp.LastName,
                Nationality = temp.Nationality,
                Id = temp.Id,
                ShortName = temp.ShortName,
                Points = 8,
                TeamId = 10
            }, "driver");
            Console.WriteLine("Driver is updated.");

            rest.Delete(driverId, "driver");
            Console.WriteLine("Driver deleted");

            Driver verstappen = rest.Get<Driver>(33, "driver");
            Console.WriteLine($"Driver with racing number 33: {verstappen.FirstName} {verstappen.LastName}");

            var drivers = rest.Get<Driver>("driver");
            foreach (Driver drvr in drivers)
            {
                Console.WriteLine(drvr.ToString());
            }
            Console.ReadLine();
        }

        static void TeamCRUDs(RestService rest)
        {
            Console.WriteLine("Presenting CRUD methods on a new Team");

            Team team = new Team()
            {
                Name = "BraumGP",
                Id = 11,
                Points = 0,
            };

            rest.Post<Team>(team, "team");
            Console.WriteLine("New team registered.");

            int teamId = rest.Get<Team>("team").Count - 1;
            Team temp = rest.Get<Team>(teamId, "team");
            rest.Put<Team>(new Team()
            {
                Id = temp.Id,
                Points = 8,
                Name = "BraumGP - updated"
            }, "team");
            Console.WriteLine("Team is updated.");

            rest.Delete(teamId, "team");
            Console.WriteLine("Team deleted");

            Team haaas = rest.Get<Team>(10, "team");
            Console.WriteLine($"Team with id 10: {haaas.Name}");

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
                Id = 15,
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

            rest.Delete(gpId, "grandprix");
            Console.WriteLine("GP deleted");

            GrandPrix idk = rest.Get<GrandPrix>(10, "grandprix");
            Console.WriteLine($"GP with id 10: {idk.Name}");

            var gps = rest.Get<GrandPrix>("grandprix");
            foreach (GrandPrix gap in gps)
            {
                Console.WriteLine(gap.ToString());
            }
            Console.ReadLine();
        }


    }
}
