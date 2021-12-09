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
                 new Team { Id = x.Id, Name = x.Name,}
                 );
        }

        public IEnumerable<GrandPrix> GetDriverRaces(int driverId)
        {
            return grandPrixRepository.ReadAll()
                .Where(x => driverRepository
                .ReadOne(driverId).Team
                .TeamGPs == x.TeamGPs);
        }

        public IEnumerable<Driver> GetDriversFromTeam(int teamId)
        {
            return teamRepository.ReadOne(teamId).Drivers;
        }

        public IEnumerable<Driver> GetPointsFromDrivers(int teamId)
        {
            return teamRepository.ReadOne(teamId)
                .Drivers.Select(x => new Driver 
                { FirstName = x.FirstName,
                    LastName = x.LastName,
                    Points = x.Points });
        }

        public IEnumerable<Team> GetTeamsWhoSkippedGP()
        {

            return teamRepository.ReadAll().Where(x => x.TeamGPs.Count() != grandPrixRepository.ReadAll().Count());
        }
    }
}
