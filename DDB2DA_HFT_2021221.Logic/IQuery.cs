using DDB2DA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Logic
{
    public interface IQuery
    {
        /// <summary>
        /// Calculates a team's points by the sum of their drivers points.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Team> GetTeamPointsFromDrivers(int teamId);

        /// <summary>
        /// Lists drivers of a team.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Driver> GetDriversFromTeam(int teamId);

        /// <summary>
        /// Gets teams who participated in all GPs.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Team> GetAllOutTeams();

        /// <summary>
        /// Get teams who did not participate in all GPs.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Team> GetTeamsWhoSkippedGP();

        /// <summary>
        /// Gets all the races a driver participated in.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GrandPrix> GetDriverRaces(int driverId);
    }
}
