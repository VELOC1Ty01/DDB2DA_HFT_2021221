using DDB2DA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Logic
{
    public interface ITeamLogic
    {
        void Create(Team team);
        Team ReadOne(int teamId);
        IQueryable<Team> ReadAll();
        void Update(Team team);
        void Delete(int teamId);

        void AddPoints(int teamId, double newPoints);
    }
}
