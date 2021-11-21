using DDB2DA_HFT_2021221.Models;
using DDB2DA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Logic
{
    public class TeamLogic : ITeamLogic
    {
        ITeamRepository repo;

        public TeamLogic(ITeamRepository repo)
        {
            this.repo = repo;
        }
        public void Create(Team team)
        {
            repo.Create(team);
        }

        public void Delete(int teamId)
        {
           repo.Delete(teamId);
        }

        public IQueryable<Team> ReadAll()
        {
            return repo.ReadAll();
        }

        public Team ReadOne(int teamId)
        {
            return repo.ReadOne(teamId);
        }

        public void Update(Team team)
        {
            repo.Update(team);
        }
    }
}
