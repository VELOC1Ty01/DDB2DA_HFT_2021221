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

        public void Create(Driver driver)
        {
            repo.Create(driver);
        }

        public void Delete(int driverId)
        {
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
