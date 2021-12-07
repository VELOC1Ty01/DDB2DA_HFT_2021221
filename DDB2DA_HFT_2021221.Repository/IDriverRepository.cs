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

        /// <summary>
        /// Changes a drivers Id, aka. the driver number.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newId"></param>
        void ChangeId(int id, int newId);
        /// <summary>
        /// Adds points to a drivers existing points. Use this to update a driver's points after a GP.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="points"></param>
        void AddPoints(int id, double points);

        void ChangeTeam(int id, int newTeamId);
    }
}
