using DDB2DA_HFT_2021221.Models;
using DDB2DA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Logic
{
    public class QueryLogic : IQueryLogic
    {
        IDriverRepository driverRepository;
        ITeamRepository teamRepository;
        IGrandPrixRepository grandPrixRepository;

        public QueryLogic(IDriverRepository driverRepository, ITeamRepository teamRepository,IGrandPrixRepository grandPrixRepository)
        {
            this.driverRepository = driverRepository;
            this.teamRepository = teamRepository;
            this.grandPrixRepository = grandPrixRepository;
        }

        public IEnumerable<Team> GetAllOutTeams()
        {

            return teamRepository.ReadAll()
                .Where(x => x.TeamGPs.Count() == grandPrixRepository.ReadAll().Count())
                .Select(x => 
                 new Team { Id = x.Id, Name = x.Name, Points = x.Points}
                 );
        }

        public IEnumerable<GrandPrix> GetDriverRaces(int driverId)
        {
            int teamId = driverRepository.ReadOne(driverId).TeamId;

            return grandPrixRepository.ReadAll()
                .Where(x => x.TeamGPs.Select(y => y.TeamID)
                .Contains(teamId));

        }

        public IEnumerable<Driver> GetDriversFromTeam(int teamId)
        {
            return teamRepository.ReadOne(teamId).Drivers;
        }


        public IEnumerable<Team> GetPointsFromDrivers()
        {
            return teamRepository.ReadAll().Select(x => new Team
            {
                Name = x.Name.ToString(),
                Points = x.Drivers.Sum(y => y.Points),
                Id = x.Id
            });
        }

        public IEnumerable<Team> GetTeamsWhoSkippedGP()
        {

            return teamRepository.ReadAll()
                .Where(x => x.TeamGPs.Count() != grandPrixRepository.ReadAll().Count());
        }



    }
}
