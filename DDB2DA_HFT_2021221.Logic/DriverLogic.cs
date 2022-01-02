using DDB2DA_HFT_2021221.Models;
using DDB2DA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Logic
{
    public class DriverLogic : IDriverLogic
    {
        IDriverRepository repo;

        public DriverLogic(IDriverRepository repo)
        {
            this.repo = repo;
        }

        public void AddPoints(int id, double points)
        {
            repo.AddPoints(id, points);
        }

        public void ChangeId(int id, int newId)
        {
            repo.ChangeId(id, newId);
        }

        public void ChangeTeam(int id, int newTeamId)
        {
            repo.ChangeTeam(id, newTeamId);
        }

        public void Create(Driver driver)
        {
            if (ReadOne(driver.Id) != null)
            {
                throw new InvalidOperationException
                    ("Creating new item with Id: (" + driver.Id + ") is not possible: this item already exists.");
            }

            repo.Create(driver);
        }

        public void Delete(int driverId)
        {
            if (ReadOne(driverId) == null)
            {
                throw new NullReferenceException("Driver with the Id: (" + driverId + ") cannot be found.");
            }

            repo.Delete(driverId);
        }

        public IQueryable<Driver> ReadAll()
        {
            return repo.ReadAll();
        }

        public Driver ReadOne(int driverId)
        {
           
            return repo.ReadOne(driverId);
        }

        public void Update(Driver driver)
        {
            repo.Update(driver);
        }
    }
}
