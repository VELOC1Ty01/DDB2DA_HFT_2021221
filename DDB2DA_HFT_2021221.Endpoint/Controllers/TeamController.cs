using DDB2DA_HFT_2021221.Endpoint.Services;
using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public TeamController(ITeamLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<Team> GetAll()
        {
            return logic.ReadAll();
        }


        [HttpDelete("{teamId}")]
        public void Delete([FromRoute] int teamId)
        {
            var teamToDelete = this.logic.ReadOne(teamId);
            logic.Delete(teamId);
            this.hub.Clients.All.SendAsync("TeamDeleted", teamToDelete);
        }

        [HttpPost("{team}")]
        public void Post([FromBody]Team team)
        {
            logic.Create(team);
            this.hub.Clients.All.SendAsync("TeamCreated", team);
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
            this.hub.Clients.All.SendAsync("TeamUpdated", team);
        }


    }
}
