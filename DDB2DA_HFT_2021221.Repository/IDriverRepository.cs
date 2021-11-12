using DDB2DA_HFT_2021221.Models;
using System;
using System.Linq;

namespace DDB2DA_HFT_2021221.Repository
{
    public interface IDriverRepository
    {
        void Create(Driver driver);
        Driver ReadOne(int driverId);
        IQueryable<Driver> ReadAll();
        void Update(Driver driver);
        void Delete(int driverId);
    }
}
