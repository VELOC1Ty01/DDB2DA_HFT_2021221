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
    }
}
