using DDB2DA_HFT_2021221.Data;
using DDB2DA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Repository
{
    public class DriverRepository : IDriverRepository
    {
        F1DbContext context;

        public DriverRepository(F1DbContext context)
        {
            this.context = context;
        }

        public void Create(Driver driver)
        {
            context.Drivers.Add(driver);
            context.SaveChanges();
        }

        public Driver ReadOne(int driverId)
        {
            return context
                .Drivers
                .FirstOrDefault(x => x.Id.Equals(driverId));
        }

        public IQueryable<Driver> ReadAll()
        {
            return
                context.Drivers;
        }

        public void Update(Driver driver)
        {
            Driver old = ReadOne(driver.Id);

            if (old == null)
            {
                throw new InvalidOperationException("There is no Driver with \"" + driver.Id + "\" id.");
            }


            old.FirstName = driver.FirstName;
            old.LastName = driver.LastName;
            old.ShortName = driver.ShortName;
            old.Nationality = driver.Nationality;
            old.Points = driver.Points;
            old.TeamId = driver.TeamId;

            context.SaveChanges();
        }

        public void Delete(int driverId)
        {
            context.Drivers.Remove(ReadOne(driverId));
            context.SaveChanges();
        }

        public void ChangeId(int id, int newId)
        {
            Driver driver = ReadOne(id);

            if (driver != null)
            {
                driver.Id = newId;
                context.SaveChanges();
                return;
            }

            throw new InvalidOperationException("There is no Driver with the Id: " + id);
        }

        public void AddPoints(int id, double points)
        {
            Driver driver = ReadOne(id);
            if (driver != null)
            {
                driver.Points += points;
                context.SaveChanges();
                return;
            }

            throw new InvalidOperationException("There is no Driver with the Id: " + id);
        }

        public void ChangeTeam(int id, int newTeamId)
        {
            Driver driver = ReadOne(id);

            if (driver != null)
            {
                driver.TeamId = newTeamId;
                context.SaveChanges();
                return;
            }

            throw new InvalidOperationException("There is no Driver with the Id: " + id);
        }
    }
}
