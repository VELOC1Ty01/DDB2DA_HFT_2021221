using DDB2DA_HFT_2021221.Data;
using DDB2DA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Repository
{
    public class TeamRepository : ITeamRepository
    {
        F1DbContext context;

        public TeamRepository(F1DbContext context)
        {
            this.context = context;
        }

        public void AddPoints(int teamId, double newPoints)
        {
            Team team = ReadOne(teamId);

            if (team != null)
            {
                team.Points += newPoints;
                return;
            }

            throw new InvalidOperationException("Could not find team with the Id: " + teamId);
        }

        public void Create(Team team)
        {
            context.Team.Add(team);
            context.SaveChanges();
        }

        public void Delete(int teamId)
        {
            context.Team.Remove(ReadOne(teamId));
            context.SaveChanges();
        }

        public IQueryable<Team> ReadAll()
        {
            return context.Team;
        }

        public Team ReadOne(int teamId)
        {
            return
                context
                .Team
                .FirstOrDefault(x => x.Id.Equals(teamId));
        }

        public void Update(Team team)
        {
            Team old = ReadOne(team.Id);

            old.TeamGPs = team.TeamGPs;
            old.Name = team.Name;
            old.Points = team.Points;
        }
    }
}
