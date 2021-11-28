using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
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

        [HttpPost]
        public void CreateOne([FromBody] Team team)
        {
            logic.Create(team);
        }

        [HttpPut]
        public void UpdateOne([FromBody] Team team)
        {
            logic.Update(team);
        }

        [HttpDelete("{teamId}")]
        public void DeleteOne([FromRoute] int teamId)
        {
            logic.Delete(teamId);
        }
    }
}
