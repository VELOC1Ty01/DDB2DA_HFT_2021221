using DDB2DA_HFT_2021221.Models;
using System;
using System.Linq;

namespace DDB2DA_HFT_2021221.Logic
{
    public interface IDriverLogic
    {
        void Create(Driver driver);
        Driver ReadOne(int driverId);
        IQueryable<Driver> ReadAll();
        void Update(Driver driver);
        void Delete(int driverId);

        void ChangeId(int id, int newId);
        void AddPoints(int id, double points);
        void ChangeTeam(int id, int newTeamId);
    }
}
