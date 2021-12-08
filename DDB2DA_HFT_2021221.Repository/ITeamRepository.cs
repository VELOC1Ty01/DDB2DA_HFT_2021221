using DDB2DA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Repository
{
    public interface ITeamRepository
    {
        void Create(Team team);
        Team ReadOne(int teamId);
        IQueryable<Team> ReadAll();
        void Update(Team team);
        void Delete(int teamId);

        /// <summary>
        /// Adds points to the existing ones.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="newPoints"></param>
        void AddPoints(int teamId, double newPoints);
    }
}
