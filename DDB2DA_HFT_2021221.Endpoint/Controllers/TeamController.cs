using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")] //team
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamLogic logic;

        public TeamController(ITeamLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Team> GetAll()
        {
            return logic.ReadAll();
        }


        [HttpDelete("{teamId}")]
        public void Delete([FromRoute] int teamId)
        {
            logic.Delete(teamId);
        }

        [HttpPost("{team}")]
        public void Post([FromBody]Team team)
        {
            logic.Create(team);
        }

        [HttpPost]
        public void CreateOne([FromBody] Team team)
        {
            logic.Create(team);
        }

        [HttpGet("{id}")]
        public Team Get(int id)
        {
            return logic.ReadOne(id);
        }

        [HttpPut]
        public void Put([FromBody] Team team)
        {
            logic.Update(team);
        }


    }
}
