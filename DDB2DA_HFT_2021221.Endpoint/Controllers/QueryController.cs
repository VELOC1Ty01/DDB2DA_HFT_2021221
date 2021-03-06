using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDB2DA_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        IQueryLogic logic;

        public QueryController(IQueryLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Team> GetPointsFromDrivers()
        {
            return logic.GetPointsFromDrivers();
        }

        [HttpGet]       
        public IEnumerable<Driver> GetDriversFromTeam()
        {
            return logic.GetDriversFromTeam(1);
        }

        [HttpGet]
        public IEnumerable<Team> GetAllOutTeams()
        {
            return logic.GetAllOutTeams();
        }

        [HttpGet]
        public IEnumerable<Team> GetTeamsWhoSkippedGP()
        {
            return logic.GetTeamsWhoSkippedGP();
        }

        [HttpGet]
        public IEnumerable<GrandPrix> GetDriverRaces()
        {
            return logic.GetDriverRaces(33);
        }

    }
}
